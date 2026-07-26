using Axiom.State.Actions;

namespace Axiom.Wpf.Sample.State;

public static class MainActions
{
    public static readonly StateAction<string> SetTitleAction = new(nameof(MainActions), nameof(SetTitleAction));
    public static readonly StateAction<int> SetSelectedUser = new(nameof(MainActions), nameof(SetSelectedUser));
}