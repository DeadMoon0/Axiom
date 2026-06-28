namespace Axiom.Wpf.Sample.State.Users.Messages;

public record struct MessageState()
{
    public int Id = 0;
    public string Message = "";
    public bool FromThisUser = false;
}