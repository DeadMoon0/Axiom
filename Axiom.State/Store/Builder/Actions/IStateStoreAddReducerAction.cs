using Axiom.State.Reducers;

namespace Axiom.State.Store.Builder.Actions;

public interface IStateStoreAddReducerAction<TState> where TState : struct
{
    public IStateStoreBuilder<TState> AddReducer(Reducer<TState> reducer);
}