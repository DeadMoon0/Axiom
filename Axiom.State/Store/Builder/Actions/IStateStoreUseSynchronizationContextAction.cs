using System.Threading;

namespace Axiom.State.Store.Builder.Actions;

public interface IStateStoreUseSynchronizationContextAction<TState> where TState : struct
{
    public IStateStoreBuilder<TState> UseSynchronizationContext(SynchronizationContext context);
}