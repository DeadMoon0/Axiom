using Axiom.State.Selectors;

namespace Axiom.Wpf.Sample.State.Users.Messages;

public static class MessageSelectors
{
    public static Selector<UserState, MessageState> SelectMessageViaId(int id) => Selector.Index((UserState user) => user.Messages, (UserState state) => id);
}