using Axiom.State.Effects;

namespace Axiom.Wpf.Sample.State.Orchestrator;

public class OrchestratorEffects : Effects<MainState>
{
    public OrchestratorEffects()
    {
        On(OrchestratorActions.OrchestratorStartAction, (s) => Orchestrate
        (
            [
                Await(Do(OrchestratorActions.Orchestrator1Action), OrchestratorActions.Orchestrator1SuccessAction, OrchestratorActions.Orchestrator1FailureAction),
                Await(Do(OrchestratorActions.Orchestrator2Action), OrchestratorActions.Orchestrator2SuccessAction, OrchestratorActions.Orchestrator2FailureAction),
                Await(Do(OrchestratorActions.Orchestrator3Action), OrchestratorActions.Orchestrator3SuccessAction, OrchestratorActions.Orchestrator3FailureAction),
            ],
            () => Do(OrchestratorActions.OrchestratorFinalSuccessAction),
            (e) => DoNothing()
        ));
        On(OrchestratorActions.Orchestrator1Action, (s) => 
            DoAction
            (
                () => Task.Delay(5000), 
                () => Do(OrchestratorActions.Orchestrator1SuccessAction), 
                (e) => Do(OrchestratorActions.Orchestrator1FailureAction)
            )
        );
        On(OrchestratorActions.Orchestrator2Action, (s) =>
            DoAction
            (
                () => Task.Delay(5000),
                () => Do(OrchestratorActions.Orchestrator2SuccessAction),
                (e) => Do(OrchestratorActions.Orchestrator2FailureAction)
            )
        );
        On(OrchestratorActions.Orchestrator3Action, (s) =>
            DoAction
            (
                () => Task.Delay(5000),
                () => Do(OrchestratorActions.Orchestrator3SuccessAction),
                (e) => Do(OrchestratorActions.Orchestrator3FailureAction)
            )
        );
    }
}
