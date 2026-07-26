using Axiom.State.Effects;

namespace Axiom.Wpf.Sample.State.Orchestrator;

public class OrchestratorEffects : Effects<MainState>
{
    public OrchestratorEffects()
    {
        On(OrchestratorActions.OrchestratorStartAction, Orchestrate
        (
            [
                (s) => Step(OrchestratorActions.Orchestrator1Action, OrchestratorActions.Orchestrator1SuccessAction, OrchestratorActions.Orchestrator1FailureAction),
                (s) => Step(OrchestratorActions.Orchestrator2Action, OrchestratorActions.Orchestrator2SuccessAction, OrchestratorActions.Orchestrator2FailureAction),
                (s) => Step(OrchestratorActions.Orchestrator3Action, OrchestratorActions.Orchestrator3SuccessAction, OrchestratorActions.Orchestrator3FailureAction),
            ],
            (s) => Do(OrchestratorActions.OrchestratorFinalSuccessAction),
            (s) => DoNothing()
        ));
        On(OrchestratorActions.Orchestrator1Action, Effect
        (
            (s) => Task.Delay(5000),
            () => Do(OrchestratorActions.Orchestrator1SuccessAction),
            (e) => Do(OrchestratorActions.Orchestrator1FailureAction)
        ));
        On(OrchestratorActions.Orchestrator2Action, Effect
        (
            (s) => Task.Delay(5000),
            () => Do(OrchestratorActions.Orchestrator2SuccessAction),
            (e) => Do(OrchestratorActions.Orchestrator2FailureAction)
        ));
        On(OrchestratorActions.Orchestrator3Action, Effect
        (
            (s) => Task.Delay(5000),
            () => Do(OrchestratorActions.Orchestrator3SuccessAction),
            (e) => Do(OrchestratorActions.Orchestrator3FailureAction)
        ));
    }
}
