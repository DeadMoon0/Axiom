using Axiom.State.Actions;

namespace Axiom.Wpf.Sample.State.Users;

public static class UserActions
{
    public static readonly StateActionAsync<UserState[]> LoadUserAction = new(nameof(UserActions), nameof(LoadUserAction));

    public static readonly StateAction<UserState> AddUserAction = new(nameof(UserActions), nameof(AddUserAction));
    public static readonly StateAction<int, string> SetUserSuffixAction = new(nameof(UserActions), nameof(SetUserSuffixAction));
}