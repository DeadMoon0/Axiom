using Axiom.State.Actions;
using Axiom.State.Exceptions;
using System;
using System.Threading.Tasks;

namespace Axiom.State.Effects;

public class EffectSingleResult<TState> : EffectResult<TState> where TState : struct
{
    private readonly StateActionGeneric? _action;
    private readonly object?[] _args;

    internal EffectSingleResult(StateActionGeneric? action, object?[] args)
    {
        _action = action;
        _args = args;
    }

    internal override async Task DispatchAsync(StateStore<TState> store)
    {
        if (_action is not null) store.DispatchInner(_action, _args);
    }
}

public class EffectAsyncResult<TState> : EffectResult<TState> where TState : struct
{
    private readonly Task<EffectResult<TState>> _action;

    internal EffectAsyncResult(Task<EffectResult<TState>> action)
    {
        _action = action;
    }

    internal override async Task DispatchAsync(StateStore<TState> store)
    {
        await (await _action).DispatchAsync(store);
    }
}

public class EffectMultiResult<TState> : EffectResult<TState> where TState : struct
{
    private readonly Func<EffectResult<TState>>[] _result;
    private readonly Func<EffectResult<TState>> _onSuccess;
    private readonly Func<Exception, EffectResult<TState>> _onError;

    internal EffectMultiResult(Func<EffectResult<TState>>[] results, Func<EffectResult<TState>> onSuccess, Func<Exception, EffectResult<TState>> onError)
    {
        _result = results;
        _onSuccess = onSuccess;
        _onError = onError;
    }

    internal override async Task DispatchAsync(StateStore<TState> store)
    {
        try
        {
            foreach (var item in _result)
            {
                await item().DispatchAsync(store);
            }
        }
        catch (Exception e)
        {
            await _onError(e).DispatchAsync(store);
        }
        await _onSuccess().DispatchAsync(store);
    }
}

public class EffectAwaitableResult<TState> : EffectResult<TState> where TState : struct
{
    private readonly EffectResult<TState> _action;
    private readonly StateActionGeneric _successfulAction;
    private readonly StateActionGeneric _errorAction;
    private readonly bool _isSuccessRequired;

    internal EffectAwaitableResult(EffectResult<TState> action, StateActionGeneric successfulAction, StateActionGeneric errorAction, bool isSuccessRequired)
    {
        _action = action;
        _successfulAction = successfulAction;
        _errorAction = errorAction;
        _isSuccessRequired = isSuccessRequired;
    }

    internal override async Task DispatchAsync(StateStore<TState> store)
    {
        TaskCompletionSource successCallback = new();
        TaskCompletionSource errorCallback = new();
        TaskCompletionSource successCancelation = store.AddActionCallback(_successfulAction, successCallback);
        TaskCompletionSource errorCancelation = store.AddActionCallback(_errorAction, errorCallback);

        await _action.DispatchAsync(store);

        Task completed = await Task.WhenAny(successCallback.Task, errorCallback.Task);

        bool isError = completed != successCallback.Task;
        if (isError) successCancelation.TrySetResult();
        else errorCancelation.TrySetResult();

        if (isError && _isSuccessRequired)
        {
            throw new EffectAwaitableErrorActionTriggeredException("Action " + _action + " caused the Error Action: " + _errorAction + " to be Dispatched.");
        }
    }
}

public abstract class EffectResult<TState> where TState : struct
{
    internal abstract Task DispatchAsync(StateStore<TState> store);
}