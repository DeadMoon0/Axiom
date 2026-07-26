using Axiom.State.Effects;

namespace Axiom.Wpf.Sample.State.Users;

public class UserEffects : Effects<MainState>
{
    public UserEffects()
    {
        OnAsync(UserActions.LoadUserAction, (s) => MockAPI.LoadUsers());
    }
}