using Axiom.State.StateCopyProviders;

namespace Axiom.State.Store.Builder.Actions;

public interface IStateStoreAddCopyStrategies<TState> where TState : struct
{
    public IStateStoreBuilder<TState> AddCopyStrategies(params StateCloneStrategy[] strategies);
}