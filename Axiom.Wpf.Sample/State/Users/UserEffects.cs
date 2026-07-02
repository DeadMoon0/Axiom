using Axiom.State.Effects;

namespace Axiom.Wpf.Sample.State.Users;

public class UserEffects : Effects<MainState>
{
    public UserEffects()
    {
        On(UserActions.LoadUserAction, Effect(
            (state) => MockAPI.LoadUsers(),
            (users) => Do(UserActions.LoadUserSuccessAction, users),
            (error) => Do(UserActions.LoadUserFailedAction, error)
        ));
    }
}