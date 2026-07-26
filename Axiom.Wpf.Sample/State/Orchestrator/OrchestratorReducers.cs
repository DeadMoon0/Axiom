using Axiom.State.Reducers;

namespace Axiom.Wpf.Sample.State.Orchestrator;

public class OrchestratorReducers : Reducer<MainState>
{
    public OrchestratorReducers()
    {
        Scope(OrchestratorSelectors.SelectOrchestrator)
            .On(OrchestratorActions.Orchestrator1Action, (state) =>
            {
                return state with
                {
                    Orchestrator1 = true
                };
            })
            .On(OrchestratorActions.Orchestrator2Action, (state) =>
            {
                return state with
                {
                    Orchestrator2 = true
                };
            })
            .On(OrchestratorActions.Orchestrator3Action, (state) =>
            {
                return state with
                {
                    Orchestrator3 = true
                };
            })
            .On(OrchestratorActions.OrchestratorFinalSuccessAction, (state) =>
            {
                return state with
                {
                    OrchestratorSuccess = true
                };
            });
    }
}