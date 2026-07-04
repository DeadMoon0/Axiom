using Axiom.State.Actions;
using Axiom.State.Effects;
using Axiom.State.Exceptions;
using Axiom.State.Reducers;
using Axiom.State.Selectors;
using Axiom.State.StateCopyProviders;
using Axiom.State.Store.Builder;
using OneOf;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;

namespace Axiom.State;

public partial class StateStore<TState> where TState : struct
{
    private record ChangeQueueItem(TState NewState, ParameterizedAction Action);
    private record ChangeQueueError(Exception Exception, ParameterizedAction Action);

    private static StateStore<TState>? @default = null;
    public static StateStore<TState> Default { get => @default ?? throw new InvalidOperationException("You must first Build a Store and then add it as the Default."); }

    public static IStateStoreBuilder<TState> Create() => new StateStoreBuilder<TState>();

    private readonly ImmutableDictionary<StateActionGeneric, ReducerActionHander<TState>> _reducerHanders;
    private readonly ImmutableDictionary<StateActionGeneric, EffectActionHandler<TState>[]> _effectHanders;
    private readonly BlockingCollection<OneOf<ChangeQueueItem, ChangeQueueError>> _changeQueue = [];
    private readonly StateCloneContext _cloneContext;
    private readonly SynchronizationContext? _synchronizationContext;
    private readonly BehaviorSubject<TState> _subject = new(new());
    private readonly object _stateLock = new object();

    internal StateStore(
        ImmutableDictionary<StateActionGeneric, ReducerActionHander<TState>> reducerHanders, 
        ImmutableDictionary<StateActionGeneric, EffectActionHandler<TState>[]> effectHanders, 
        SynchronizationContext? synchronizationContext, 
        StateCloneStrategy[] customCloneStrategy, 
        bool makeDefault
    )
    {
        _reducerHanders = reducerHanders;
        _effectHanders = effectHanders;
        _synchronizationContext = synchronizationContext;
        _cloneContext = new StateCloneContext();
        _cloneContext.RegisterStrategies(customCloneStrategy);

        Task.Run(ProcessChangeQueue);

        if (makeDefault || @default is null) @default = this;
    }

    internal void DispatchInner(StateActionGeneric action, object?[] args)
    {
        TState newState;
        lock (_stateLock)
        {
            Debug.WriteLine(this.GetType() + ": Dispatch Action" + action.Name);
            //var copiedValue = _cloneContext.DeepClone(_subject.Value); //TODO: Reuse when independent State becomes a real thing.
            newState = _reducerHanders.TryGetValue(action, out var handler) ? handler.Reducer(_subject.Value, args) : throw new NoReducerFoundForActionException(action);
            if (newState.Equals(_subject.Value)) return;
            var paramAction = new ParameterizedAction { Action = action, Parameters = args };
            _changeQueue.Add(new ChangeQueueItem(newState, paramAction));
        }
    }

    public IObservable<T> Bind<T>(Func<TState, T> selector)
    {
        lock (_stateLock) return AddSynchronizationContext(_subject).Select(x => selector(x));
    }

    public IObservable<T> Bind<T>(Selector<TState, T> selector)
    {
        lock (_stateLock) return AddSynchronizationContext(_subject).Select(x => selector.GetSelected(x));
    }

    private IObservable<T> AddSynchronizationContext<T>(IObservable<T> observable)
    {
        if (_synchronizationContext is null) return observable;
        return observable.ObserveOn(_synchronizationContext);
    }

    public T GetValue<T>(Func<TState, T> selector)
    {
        lock (_stateLock) return selector(_subject.Value);
    }

    //TODO: 
    //public bool Rollback()
    //{

    //}

    //public void Commit()
    //{

    //}

    private async Task ProcessChangeQueue()
    {
        foreach (OneOf<ChangeQueueItem, ChangeQueueError> itemOrError in _changeQueue.GetConsumingEnumerable())
        {
            await itemOrError.Match(async (item) =>
            {
                _subject.OnNext(item.NewState);
                foreach (var hander in _effectHanders.TryGetValue(item.Action.Action, out var handers) ? handers : [])
                {
                    _ = hander.Resolve(item.NewState, this);
                }
            },
            (error) =>
            {
                _subject.OnError(error.Exception);
                return Task.CompletedTask;
            });
        }
    }
}