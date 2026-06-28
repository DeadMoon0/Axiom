namespace Axiom.Wpf.Sample.State.Users;

public static class UserSelectors
{
    public static Func<MainState, UserState> SelectUserWithId(int id) => (state) => state.Users.FirstOrDefault(x => x.Id == id);
    public static Func<MainState, UserState> SelectSelectedUser() => (state) => SelectUserWithId(state.SelectedUser)(state);
}