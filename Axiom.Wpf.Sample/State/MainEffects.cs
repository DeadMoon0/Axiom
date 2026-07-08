using Axiom.State.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axiom.Wpf.Sample.State;

public class MainEffects : Effects<MainState>
{
    public MainEffects()
    {
        On(MainActions.OrchestratorStartAction, Orchestrator
        (
            [
                (s) => Invoke(MainActions.Orchestrator1Action, MainActions.Orchestrator1SuccessAction, MainActions.Orchestrator1FailureAction),
                (s) => Invoke(MainActions.Orchestrator2Action, MainActions.Orchestrator2SuccessAction, MainActions.Orchestrator2FailureAction),
                (s) => Invoke(MainActions.Orchestrator3Action, MainActions.Orchestrator3SuccessAction, MainActions.Orchestrator3FailureAction),
            ],
            (s) => Do(MainActions.OrchestratorFinalSuccessAction),
            (s) => Do(MainActions.OrchestratorFinalFailureAction)
        ));
        On(MainActions.Orchestrator1Action, Effect
        (
            (s) => Task.Delay(5000).ContinueWith((t) => 0),
            (i) => Do(MainActions.Orchestrator1SuccessAction),
            (e) => Do(MainActions.Orchestrator1FailureAction)
        ));
        On(MainActions.Orchestrator2Action, Effect
        (
            (s) => Task.Delay(5000).ContinueWith((t) => 0),
            (i) => Do(MainActions.Orchestrator2SuccessAction),
            (e) => Do(MainActions.Orchestrator2FailureAction)
        ));
        On(MainActions.Orchestrator3Action, Effect
        (
            (s) => Task.Delay(5000).ContinueWith((t) => 0),
            (i) => Do(MainActions.Orchestrator3SuccessAction),
            (e) => Do(MainActions.Orchestrator3FailureAction)
        ));
    }
}