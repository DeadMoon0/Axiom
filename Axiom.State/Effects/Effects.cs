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

    protected void On(Actions.StateActionGeneric action, Func<TState, Task<EffectResult<TState>>> effect) => _handers.Add(new ActionEffect<TState>((s, args) => effect(s)).GetHandler(action));

    protected void OnAsync<TResult>(Actions.StateActionAsyncGeneric<TResult> stateAction, Func<TState, Task<TResult>> action)
    {
        On(stateAction.BeginAction, (s) => DoAction(() => action(s), (v) => Do(stateAction.SuccessAction, v), (e) => Do(stateAction.ErrorAction, e)));
    }

    protected void OnAsync(Actions.StateActionAsyncGeneric stateAction, Func<TState, Task> action)
    {
        On(stateAction.BeginAction, (s) => DoAction(() => action(s), () => Do(stateAction.SuccessAction), (e) => Do(stateAction.ErrorAction, e)));
    }

    protected EffectResult<TState> DoNothing() => new EffectResult<TState>(null, []);

    protected Task<EffectResult<TState>> DoAction<T>(Func<Task<T>> action, Func<T, EffectResult<TState>> onSuccess, Func<Exception, EffectResult<TState>> onError)
    {
        return action().ToObservable().Select(x => onSuccess(x)).Catch((Exception e) => Observable.Return(onError(e))).ToTask();
    }

    protected Task<EffectResult<TState>> DoAction(Func<Task> action, Func<EffectResult<TState>> onSuccess, Func<Exception, EffectResult<TState>> onError)
    {
        return action().ToObservable().Select(x => onSuccess()).Catch((Exception e) => Observable.Return(onError(e))).ToTask();
    }

    protected Task<Task> DoAwait(Actions.StateAction action, Actions.StateActionGeneric successfulAction, Actions.StateActionGeneric errorAction, bool isSuccessRequired = true)
    {

    }
    
    protected async Task<EffectResult<TState>> DoMany(IEnumerable<Func<Task<EffectResult<TState>>>> dos, Func<EffectResult<TState>> onSuccess, Func<Exception, EffectResult<TState>> onError)
    {
        foreach (var item in dos)
        {
            try
            {
                await item();
            }
            catch (Exception e)
            {
                return onError(e);
            }
        }
        return onSuccess();
    }
}