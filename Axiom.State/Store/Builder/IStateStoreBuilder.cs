using Axiom.State.Store.Builder.Actions;

namespace Axiom.State.Store.Builder;

public interface IStateStoreBuilder<TState> :
    IStateStoreAddReducerAction<TState>,
    IStateStoreBuildAction<TState>,
    IStateStoreAddEffectsAction<TState>,
    IStateStoreUseSynchronizationContextAction<TState>,
    IStateStoreAddCopyStrategies<TState>
    where TState : struct;