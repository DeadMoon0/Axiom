namespace Axiom.State.Store.Builder.Actions;

public interface IStateStoreBuildAction<TState> where TState : struct
{
    public StateStore<TState> Build();
    public StateStore<TState> BuildAndMakeDefault();
}