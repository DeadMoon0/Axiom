using Axiom.State.Selectors;

namespace Axiom.Wpf.Sample.State.Orchestrator;

public static class OrchestratorSelectors
{
    public static readonly Selector<MainState, OrchestratorState> SelectOrchestrator = Selector.Property((MainState x) => x.Orchestrator);
}