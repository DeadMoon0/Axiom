using Axiom.State.Actions;

namespace Axiom.Wpf.Sample.State.Orchestrator;

public static class OrchestratorActions
{
    public static readonly StateAction OrchestratorStartAction = new(nameof(MainActions), nameof(OrchestratorStartAction), true);
    public static readonly StateAction Orchestrator1Action = new(nameof(MainActions), nameof(Orchestrator1Action));
    public static readonly StateAction Orchestrator1SuccessAction = new(nameof(MainActions), nameof(Orchestrator1SuccessAction), true);
    public static readonly StateAction Orchestrator1FailureAction = new(nameof(MainActions), nameof(Orchestrator1FailureAction), true);
    public static readonly StateAction Orchestrator2Action = new(nameof(MainActions), nameof(Orchestrator2Action));
    public static readonly StateAction Orchestrator2SuccessAction = new(nameof(MainActions), nameof(Orchestrator2SuccessAction), true);
    public static readonly StateAction Orchestrator2FailureAction = new(nameof(MainActions), nameof(Orchestrator2FailureAction), true);
    public static readonly StateAction Orchestrator3Action = new(nameof(MainActions), nameof(Orchestrator3Action));
    public static readonly StateAction Orchestrator3SuccessAction = new(nameof(MainActions), nameof(Orchestrator3SuccessAction), true);
    public static readonly StateAction Orchestrator3FailureAction = new(nameof(MainActions), nameof(Orchestrator3FailureAction), true);
    public static readonly StateAction OrchestratorFinalSuccessAction = new(nameof(MainActions), nameof(OrchestratorFinalSuccessAction));
    public static readonly StateAction OrchestratorFinalFailureAction = new(nameof(MainActions), nameof(OrchestratorFinalFailureAction));
}