using Axiom.State.Actions;

namespace Axiom.Wpf.Sample.State.Users.Messages;

public static class MessageActions
{
    public static readonly StateAction<int, MessageState> AddMessageAction = new("[MessageActions] AddMessageAction");
    public static readonly StateAction<int, int, bool> SetIsSendAction = new("[MessageActions] SetIsSendAction");
}