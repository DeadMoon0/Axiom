using Axiom.State.Selectors;

namespace Axiom.Wpf.Sample.State.Users;

public static class UserSelectors
{
    public static Selector<MainState, UserState> SelectUserViaId(int id) => Selector.Index((MainState state) => state.Users, (MainState state) => Array.FindIndex(state.Users, (u) => u.Id == id));
    public static Selector<MainState, UserState> SelectSelectedUser { get; } = Selector.Index((MainState state) => state.Users, (MainState state) => Array.FindIndex(state.Users, (u) => u.Id == state.SelectedUser));
}