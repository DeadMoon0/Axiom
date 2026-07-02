using Axiom.Wpf.Sample.State.Users.Messages;

namespace Axiom.Wpf.Sample.State.Users;

public record struct UserState()
{
    public int Id = 0;
    public string UserName = "NAME";
    public string UserSuffix = "SUFFIX";

    public Dictionary<int, MessageState> Messages = [];
}