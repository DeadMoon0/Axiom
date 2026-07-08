using Axiom.Wpf.Sample.State.Users;

namespace Axiom.Wpf.Sample.State;

public record struct MainState()
{
    public string AppTitle = "Axiom Sample App";
    public bool IsUserLoading = false;
    public UserState[] Users = [];
    public int SelectedUser = -1;

    public bool Orchestrator1 = false;
    public bool Orchestrator2 = false;
    public bool Orchestrator3 = false;
    public bool OrchestratorSuccess = false;
}