using Axiom.State.Actions;
using System;
using System.Threading.Tasks;

namespace Axiom.State.Effects;

public class ActionEffect<TState> : Effect<TState> where TState : struct
{
    private readonly Func<TState, Task<object>> _action;
    private readonly Func<object, EffectResult<TState>> _onSuccess;
    private readonly Func<Exception, EffectResult<TState>> _onError;

    internal ActionEffect(Func<TState, Task<object>> action, Func<object, EffectResult<TState>> onSuccess, Func<Exception, EffectResult<TState>> onError)    
    {
        _action = action;
        _onSuccess = onSuccess;
        _onError = onError;
    }

    internal override EffectActionHandler<TState> GetHandler(StateActionGeneric action)
    {
        return new EffectActionHandler<TState>(action, this);
    }

    internal async override Task ResolveEffect(TState state, StateStore<TState> store)
    {
        try
        {
            object result = await _action(state);
            _onSuccess(result).Dispatch(store);
        }
        catch (Exception e)
        {
            _onError(e).Dispatch(store);
        }
    }
}