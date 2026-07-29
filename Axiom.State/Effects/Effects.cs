using Axiom.State.Actions;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;

namespace Axiom.State.Effects;

public abstract partial class Effects<TState> where TState : struct
{
    internal readonly List<EffectActionHandler<TState>> _handers = [];

    protected void On(Actions.StateActionGeneric action, Func<TState, EffectResult<TState>> effect) => _handers.Add(new ActionEffect<TState>((s, args) => effect(s)).GetHandler(action));

    protected void OnAsync<TResult>(Actions.StateActionAsyncGeneric<TResult> stateAction, Func<TState, Task<TResult>> action)
    {
        On(stateAction.BeginAction, (s) => DoAction(() => action(s), (v) => Do(stateAction.SuccessAction, v), (e) => Do(stateAction.ErrorAction, e)));
    }

    protected void OnAsync(Actions.StateActionAsyncGeneric stateAction, Func<TState, Task> action)
    {
        On(stateAction.BeginAction, (s) => DoAction(() => action(s), () => Do(stateAction.SuccessAction), (e) => Do(stateAction.ErrorAction, e)));
    }

    protected EffectResult<TState> DoNothing() => new EffectSingleResult<TState>(null, []);

    protected EffectResult<TState> DoAction<T>(Func<Task<T>> action, Func<T, EffectResult<TState>> onSuccess, Func<Exception, EffectResult<TState>> onError)
    {
        return new EffectAsyncResult<TState>(action().ToObservable().Select(x => onSuccess(x)).Catch((Exception e) => Observable.Return(onError(e))).ToTask());
    }

    protected EffectResult<TState> DoAction(Func<Task> action, Func<EffectResult<TState>> onSuccess, Func<Exception, EffectResult<TState>> onError)
    {
        return new EffectAsyncResult<TState>(action().ToObservable().Select(x => onSuccess()).Catch((Exception e) => Observable.Return(onError(e))).ToTask());
    }

    protected EffectResult<TState> Await(EffectResult<TState> action, Actions.StateActionGeneric successfulAction, Actions.StateActionGeneric errorAction, bool isSuccessRequired = true)
    {
        return new EffectAwaitableResult<TState>(action, successfulAction, errorAction, isSuccessRequired);
    }

    protected EffectResult<TState> Orchestrate(IEnumerable<EffectResult<TState>> dos, Func<EffectResult<TState>> onSuccess, Func<Exception, EffectResult<TState>> onError)
    {
        return new EffectMultiResult<TState>([.. dos], onSuccess, onError);
    }
}