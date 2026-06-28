using Axiom.Wpf.Sample.State.Users;

namespace Axiom.Wpf.Sample.State;

public record struct MainState()
{
    public string AppTitle = "Axiom Sample App";
    public bool IsUserLoading = false;
    public UserState[] Users = [];
}