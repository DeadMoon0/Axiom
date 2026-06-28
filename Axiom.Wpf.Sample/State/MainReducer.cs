using Axiom.State.Reducers;

namespace Axiom.Wpf.Sample.State;

public class MainReducer : Reducer<MainState>
{
    public MainReducer()
    {
        On(MainActions.SetTitleAction, (state, title) =>
        {
            return state with
            {
                AppTitle = title
            };
        });
    }
}