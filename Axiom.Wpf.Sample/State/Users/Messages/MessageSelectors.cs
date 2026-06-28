using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Axiom.Wpf.Sample.State.Users.Messages;

public static class MessageSelectors
{
    public static Func<UserState, MessageState> SelectMessageWithId(int id) => (user) => user.Messages.FirstOrDefault(x => x.Id == id);
}