using Axiom.State.Actions;
using Axiom.State.Effects;
using Axiom.State.Exceptions;
using Axiom.State.Reducers;
using Axiom.State.Store.Builder;
using OneOf;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;

namespace Axiom.State;

public class StateStore<TState> where TState : struct
{
    private record ChangeQueueItem(TState NewState, ParameterizedAction Action);
    private record ChangeQueueError(Exception Exception, ParameterizedAction Action);

    private static StateStore<TState>? @default = null;
    public static StateStore<TState> Default { get => @default ?? throw new InvalidOperationException("You must first Build a Store and then add it as the Default."); }

    public static IStateStoreBuilder<TState> Create() => new StateStoreBuilder<TState>();

    private readonly ImmutableDictionary<StateActionGeneric, ReducerActionHander<TState>> _reducerHanders;
    private readonly ImmutableDictionary<StateActionGeneric, EffectActionHandler<TState>[]> _effectHanders;
    private readonly BlockingCollection<OneOf<ChangeQueueItem, ChangeQueueError>> _changeQueue = [];
    private readonly SynchronizationContext? _synchronizationContext;
    private readonly BehaviorSubject<TState> _subject = new(new());
    private readonly object _stateLock = new object();

    internal StateStore(ImmutableDictionary<StateActionGeneric, ReducerActionHander<TState>> reducerHanders, ImmutableDictionary<StateActionGeneric, EffectActionHandler<TState>[]> effectHanders, SynchronizationContext? synchronizationContext, bool makeDefault)
    {
        _reducerHanders = reducerHanders;
        _effectHanders = effectHanders;
        _synchronizationContext = synchronizationContext;

        Task.Run(ProcessChangeQueue);

        if (makeDefault || @default is null) @default = this;
    }

    public void Dispatch(Actions.StateAction action) 
    { Dispatch(action, []); }
    public void Dispatch<T1>
        (Actions.StateAction<T1> action, T1 arg1)
    { Dispatch(action, [arg1]); }
    public void Dispatch<T1, T2>
        (Actions.StateAction<T1, T2> action, T1 arg1, T2 arg2)
    { Dispatch(action, [arg1, arg2]); }
    public void Dispatch<T1, T2, T3>
        (Actions.StateAction<T1, T2, T3> action, T1 arg1, T2 arg2, T3 arg3)
    { Dispatch(action, [arg1, arg2, arg3]); }
    public void Dispatch<T1, T2, T3, T4>
        (Actions.StateAction<T1, T2, T3, T4> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
    { Dispatch(action, [arg1, arg2, arg3, arg4]); }
    public void Dispatch<T1, T2, T3, T4, T5>
        (Actions.StateAction<T1, T2, T3, T4, T5> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
    { Dispatch(action, [arg1, arg2, arg3, arg4, arg5]); }
    public void Dispatch<T1, T2, T3, T4, T5, T6>
        (Actions.StateAction<T1, T2, T3, T4, T5, T6> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
    { Dispatch(action, [arg1, arg2, arg3, arg4, arg5, arg6]); }
    public void Dispatch<T1, T2, T3, T4, T5, T6, T7>
        (Actions.StateAction<T1, T2, T3, T4, T5, T6, T7> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
    { Dispatch(action, [arg1, arg2, arg3, arg4, arg5, arg6, arg7]); }
    public void Dispatch<T1, T2, T3, T4, T5, T6, T7, T8>
        (Actions.StateAction<T1, T2, T3, T4, T5, T6, T7, T8> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
    { Dispatch(action, [arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8]); }
    public void Dispatch<T1, T2, T3, T4, T5, T6, T7, T8, T9>
        (Actions.StateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
    { Dispatch(action, [arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9]); }
    public void Dispatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
        (Actions.StateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
    { Dispatch(action, [arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10]); }
    public void Dispatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
        (Actions.StateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
    { Dispatch(action, [arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11]); }
    public void Dispatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
        (Actions.StateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
    { Dispatch(action, [arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12]); }
    public void Dispatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
        (Actions.StateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
    { Dispatch(action, [arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13]); }
    public void Dispatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
        (Actions.StateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
    { Dispatch(action, [arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14]); }
    public void Dispatch<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>
        (Actions.StateAction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> action, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
    { Dispatch(action, [arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15]); }

    internal void Dispatch(StateActionGeneric action, object?[] args)
    {
        TState newState;
        lock (_stateLock)
        {
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

    public IObservable<TOut> Bind<TIn, TOut>(Func<TState, TIn> selector, Func<TIn, TOut> transform)
    {
        lock (_stateLock) return AddSynchronizationContext(_subject).Select(x => transform(selector(x)));
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
        List<Task> effects = [];
        foreach (OneOf<ChangeQueueItem, ChangeQueueError> itemOrError in _changeQueue.GetConsumingEnumerable())
        {
            await itemOrError.Match(async (item) =>
            {
                _subject.OnNext(item.NewState);
                effects.Clear();
                foreach (var hander in _effectHanders.TryGetValue(item.Action.Action, out var handers) ? handers : [])
                {
                    effects.Add(hander.Resolve(item.NewState, this));
                }
                await Task.WhenAll(effects);
            },
            (error) =>
            {
                _subject.OnError(error.Exception);
                return Task.CompletedTask;
            });
        }
    }
}