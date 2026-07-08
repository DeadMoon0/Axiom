using Axiom.State.Actions;
using System.Threading.Tasks;

namespace Axiom.State.Effects;

internal record EffectActionHandler<TState>(StateActionGeneric Action, Effect<TState> Effect)  where TState : struct 
{
    internal Task Resolve(TState state, StateStore<TState> store)
    {
        return Effect.ResolveEffect(state, store);
    }
}