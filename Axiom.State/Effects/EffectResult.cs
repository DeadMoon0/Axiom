using Axiom.State.Actions;

namespace Axiom.State.Effects;

public class EffectResult<TState> where TState : struct
{
    private readonly StateActionGeneric _action;
    private readonly object?[] _args;

    internal EffectResult(StateActionGeneric action, object?[] args)
    {
        _action = action;
        _args = args;
    }

    internal void Dispatch(StateStore<TState> store)
    {
        store.DispatchInner(_action, _args);
    }
}