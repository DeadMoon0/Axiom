using Axiom.State.Reducers;

namespace Axiom.Wpf.Sample.State.Users.Messages;

public class MessageReducer : Reducer<MainState>
{
    public MessageReducer()
    {
        On(MessageActions.AddMessageAction, (state, userId, msg) =>
        {
            int index = Array.FindIndex(state.Users, (user) => user.Id == userId);
            state.Users[index].Messages = [.. state.Users[index].Messages, msg];
            return state;
        });
        On(MessageActions.SetIsSendAction, (state, userId, msgId, isSend) =>
        {
            int userIndex = Array.FindIndex(state.Users, (user) => user.Id == userId);
            int messageIndex = Array.FindIndex(state.Users[userIndex].Messages, (msg) => msg.Id == msgId);
            state.Users[userIndex].Messages[messageIndex] = state.Users[userIndex].Messages[messageIndex] with { IsSend = isSend };
            return state;
        });
    }
}