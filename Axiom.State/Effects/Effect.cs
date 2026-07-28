using System;
using System.Threading.Tasks;

namespace Axiom.State.Effects;

public abstract class Effect<TState> where TState : struct
{
    internal abstract Task ResolveEffect(TState state, object?[] args, StateStore<TState> store);
    internal abstract EffectActionHandler<TState> GetHandler(Actions.StateActionGeneric action);
}