using Axiom.State.Effects;

namespace Axiom.State.Store.Builder.Actions;

public interface IStateStoreAddEffectsAction<TState> where TState : struct
{
    public IStateStoreBuilder<TState> AddEffects(Effects<TState> effects);
}