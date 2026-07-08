using Axiom.State.Actions;
using System;
using System.Threading.Tasks;

namespace Axiom.State.Effects;

public class OrchestratorEffect<TState> : Effect<TState> where TState : struct
{
    private readonly Func<TState, InvokeOrchestratorResult<TState>>[] _actions;
    private readonly Func<TState, EffectResult<TState>> _onSuccess;
    private readonly Func<TState, EffectResult<TState>> _onError;

    internal OrchestratorEffect(Func<TState, InvokeOrchestratorResult<TState>>[] actions, Func<TState, EffectResult<TState>> onSuccess, Func<TState, EffectResult<TState>> onError)    
    {
        _actions = actions;
        _onSuccess = onSuccess;
        _onError = onError;
    }

    internal override EffectActionHandler<TState> GetHandler(StateActionGeneric action)
    {
        return new EffectActionHandler<TState>(action, this);
    }

    internal override async Task ResolveEffect(TState state, StateStore<TState> store)
    {
        foreach (var item in _actions)
        {
            var orchAction = item(store.GetValue(x => x));
            TaskCompletionSource successCallback = new();
            TaskCompletionSource errorCallback = new();
            TaskCompletionSource successCancelation = store.AddActionCallback(orchAction._successfulAction, successCallback);
            TaskCompletionSource errorCancelation = store.AddActionCallback(orchAction._errorAction, errorCallback);

            orchAction.Dispatch(store);

            Task completed = await Task.WhenAny(successCallback.Task, errorCallback.Task);

            bool isError = completed != successCallback.Task;
            if (isError) successCancelation.TrySetResult();
            else errorCancelation.TrySetResult();

            if (isError && orchAction._isSuccessRequired)
            {
                _onError(store.GetValue(x => x)).Dispatch(store);
                return;
            }
        }
        _onSuccess(store.GetValue(x => x)).Dispatch(store);
    }
}