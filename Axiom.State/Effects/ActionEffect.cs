using Axiom.State.Actions;
using System;
using System.Threading.Tasks;

namespace Axiom.State.Effects;

public class ActionEffect<TState> : Effect<TState> where TState : struct
{
    private readonly Func<TState, object?[], EffectResult<TState>> _action;

    internal ActionEffect(Func<TState, object?[], EffectResult<TState>> action)    
    {
        _action = action;
    }

    internal override EffectActionHandler<TState> GetHandler(StateActionGeneric action)
    {
        return new EffectActionHandler<TState>(action, this);
    }

    internal async override Task ResolveEffect(TState state, object?[] args, StateStore<TState> store)
    {
        await _action(state, args).DispatchAsync(store);
    }
}