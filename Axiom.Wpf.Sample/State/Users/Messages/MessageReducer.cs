using Axiom.State.Reducers;

namespace Axiom.Wpf.Sample.State.Users.Messages;

public class MessageReducer : Reducer<MainState>
{
    public MessageReducer()
    {
        On(MessageActions.AddMessageAction, 
            (userId, msg) => UserSelectors.SelectUserViaId(userId),
            (user, userId, msg) =>
            {
                user.Messages.Add(msg.Id, msg);
                return user;
            }
        );
        On(MessageActions.SetIsSendAction,
            (userId, msgId, isSend) => UserSelectors.SelectUserViaId(userId).Then(MessageSelectors.SelectMessageViaId(msgId)),
            (msg, userId, msgId, isSend) =>
            {
                return msg with { IsSend = isSend };
            }
        );
    }
}