using Axiom.State.Reducers;

namespace Axiom.Wpf.Sample.State;

public class MainReducer : Reducer<MainState>
{
    public MainReducer()
    {
        On(MainActions.SetTitleAction, (state, title) =>
        {
            return state with
            {
                AppTitle = title
            };
        });
        On(MainActions.SetSelectedUser, (state, userId) =>
        {
            return state with
            {
                SelectedUser = userId
            };
        });
        On(MainActions.Orchestrator1Action, (state) =>
        {
            return state with
            {
                Orchestrator1 = true
            };
        });
        On(MainActions.Orchestrator2Action, (state) =>
        {
            return state with
            {
                Orchestrator2 = true
            };
        });
        On(MainActions.Orchestrator3Action, (state) =>
        {
            return state with
            {
                Orchestrator3 = true
            };
        });
        On(MainActions.OrchestratorFinalSuccessAction, (state) =>
        {
            return state with
            {
                OrchestratorSuccess = true
            };
        });
    }
}