using Axiom.State.Actions;

namespace Axiom.Wpf.Sample.State.Users;

public static class UserActions
{
    public static readonly StateAction LoadUserAction = new("[UserActions] LoadUserAction");
    public static readonly StateAction<UserState[]> LoadUserSuccessAction = new("[UserActions] LoadUserSuccessAction");
    public static readonly StateAction<Exception> LoadUserFailedAction = new("[UserActions] LoadUserFailedAction");

    public static readonly StateAction<UserState> AddUserAction = new("[UserActions] AddUserAction");
    public static readonly StateAction<int, string> SetUserSuffixAction = new("[UserActions] SetUserSuffixAction");
}