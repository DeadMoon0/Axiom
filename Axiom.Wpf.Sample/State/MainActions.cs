using Axiom.State.Actions;

namespace Axiom.Wpf.Sample.State;

public static class MainActions
{
    public static readonly StateAction<string> SetTitleAction = new("[MainActions] SetTitleAction");
}