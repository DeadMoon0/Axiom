using Axiom.State.Reducers;

namespace Axiom.Wpf.Sample.State.Users;

public class UserReducer : Reducer<MainState>
{
    public UserReducer()
    {
        On(UserActions.AddUserAction, (state, user) =>
        {
            return state with
            {
                Users = [..state.Users, user]
            };
        });
        On(UserActions.SetUserSuffixAction, (state, id, name) =>
        {
            for (int i = 0; i < state.Users.Length; i++)
            {
                if (state.Users[i].Id != id) continue;
                state.Users[i] = state.Users[i] with { UserSuffix = name };
            }
            return state;
        });
        On(UserActions.LoadUserAction, (state) =>
        {
            return state with { IsUserLoading = true };
        });
        On(UserActions.LoadUserSuccessAction, (state, users) =>
        {
            return state with 
            { 
                Users = users, 
                IsUserLoading = false
            };
        });
    }
}