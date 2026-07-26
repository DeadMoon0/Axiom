using Axiom.State.Selectors;

namespace Axiom.State.Reducers;

public abstract partial class Reducer<TState>() : ReducerScope<TState, TState>(Selector.Self<TState>(), []) where TState : struct
{

}