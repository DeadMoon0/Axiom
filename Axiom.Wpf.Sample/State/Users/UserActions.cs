using Axiom.State.Actions;

namespace Axiom.Wpf.Sample.State.Users;

public static class UserActions
{
    public static readonly StateAction LoadUserAction = new(nameof(UserActions), nameof(LoadUserAction));
    public static readonly StateAction<UserState[]> LoadUserSuccessAction = new(nameof(UserActions), nameof(LoadUserSuccessAction));
    public static readonly StateAction<Exception> LoadUserFailedAction = new(nameof(UserActions), nameof(LoadUserFailedAction));

    public static readonly StateAction<UserState> AddUserAction = new(nameof(UserActions), nameof(AddUserAction));
    public static readonly StateAction<int, string> SetUserSuffixAction = new(nameof(UserActions), nameof(SetUserSuffixAction));
}