using Axiom.State;
using Axiom.Wpf.Sample.State;
using Axiom.Wpf.Sample.State.Users;
using Axiom.Wpf.Sample.State.Users.Messages;
using System.Collections.Concurrent;

namespace Axiom.Wpf.Sample;

public static class MockAPI
{
    private readonly static BlockingCollection<(int, MessageState)> _messageQueue = [];

    public static async Task ReceiveMessages()
    {
        foreach (var item in _messageQueue.GetConsumingEnumerable())
        {
            StateStore<MainState>.Default.Dispatch(MessageActions.AddMessageAction, item.Item1, item.Item2);
        }
    }

    public static async Task SendMessage(int id, MessageState message)
    {
        StateStore<MainState>.Default.Dispatch(MessageActions.AddMessageAction, id, message);

        await Task.Delay(3000);
        StateStore<MainState>.Default.Dispatch(MessageActions.SetIsSendAction, id, message.Id, true);
        _messageQueue.Add((id, message with { FromThisUser = false, Id = message.Id + 1, IsSend = true }));
    }

    public static async Task<UserState[]> LoadUsers()
    {
        await Task.Delay(1000);
        return
        [
    new UserState
    {
        Id = 1,
        UserName = "Ava",
        UserSuffix = "NY",
        Messages = new Dictionary<int, MessageState>
        {
            { 1, new MessageState { Id = 1, Message = "Morning — are we still on for 9:30?", FromThisUser = true } },
            { 2, new MessageState { Id = 2, Message = "Yep, I’ll be there a few minutes early.", FromThisUser = false } },
            { 3, new MessageState { Id = 3, Message = "Great. I’m sending the deck now.", FromThisUser = true } },
            { 4, new MessageState { Id = 4, Message = "Got it, reviewing shortly.", FromThisUser = false } },
            { 5, new MessageState { Id = 5, Message = "Can you add the Q3 numbers on slide 4?", FromThisUser = false } },
            { 6, new MessageState { Id = 6, Message = "Yes, I’ll update that now.", FromThisUser = true } },
            { 7, new MessageState { Id = 7, Message = "Thanks.", FromThisUser = false } },
            { 8, new MessageState { Id = 8, Message = "Also moving the client call to 2:00?", FromThisUser = true } },
            { 9, new MessageState { Id = 9, Message = "Works for me.", FromThisUser = false } },
            { 10, new MessageState { Id = 10, Message = "Perfect.", FromThisUser = true } },
            { 11, new MessageState { Id = 11, Message = "I left comments in the doc.", FromThisUser = false } },
            { 12, new MessageState { Id = 12, Message = "Saw them — thanks.", FromThisUser = true } },
            { 13, new MessageState { Id = 13, Message = "Any chance we can simplify the budget section?", FromThisUser = false } },
            { 14, new MessageState { Id = 14, Message = "Yes, I’ll trim it down.", FromThisUser = true } },
            { 15, new MessageState { Id = 15, Message = "Great.", FromThisUser = false } },
            { 16, new MessageState { Id = 16, Message = "I’m stepping out for lunch.", FromThisUser = true } },
            { 17, new MessageState { Id = 17, Message = "No problem, ping me when you’re back.", FromThisUser = false } },
            { 18, new MessageState { Id = 18, Message = "Will do.", FromThisUser = true } },
            { 19, new MessageState { Id = 19, Message = "Slide 6 looks much better now.", FromThisUser = false } },
            { 20, new MessageState { Id = 20, Message = "Awesome, glad it works.", FromThisUser = true } }
        }
    },
    new UserState
    {
        Id = 2,
        UserName = "Noah",
        UserSuffix = "CA",
        Messages = new Dictionary<int, MessageState>
        {
            { 1, new MessageState { Id = 1, Message = "Did the plumber ever show up?", FromThisUser = false } },
            { 2, new MessageState { Id = 2, Message = "Yeah, he came around noon and fixed the leak.", FromThisUser = true } },
            { 3, new MessageState { Id = 3, Message = "Nice. Was it expensive?", FromThisUser = false } },
            { 4, new MessageState { Id = 4, Message = "Not too bad, thankfully.", FromThisUser = true } },
            { 5, new MessageState { Id = 5, Message = "Can you send me the receipt?", FromThisUser = false } },
            { 6, new MessageState { Id = 6, Message = "Sure, I’ll forward it tonight.", FromThisUser = true } },
            { 7, new MessageState { Id = 7, Message = "Thanks.", FromThisUser = false } },
            { 8, new MessageState { Id = 8, Message = "Also, the grocery order came in.", FromThisUser = true } },
            { 9, new MessageState { Id = 9, Message = "Did they forget anything?", FromThisUser = false } },
            { 10, new MessageState { Id = 10, Message = "Just the oat milk.", FromThisUser = true } },
            { 11, new MessageState { Id = 11, Message = "I can grab that tomorrow.", FromThisUser = false } },
            { 12, new MessageState { Id = 12, Message = "Perfect.", FromThisUser = true } },
            { 13, new MessageState { Id = 13, Message = "Are you still picking up the kids?", FromThisUser = false } },
            { 14, new MessageState { Id = 14, Message = "Yes, I’ll leave by 3:15.", FromThisUser = true } },
            { 15, new MessageState { Id = 15, Message = "Okay, I’ll let them know.", FromThisUser = false } },
            { 16, new MessageState { Id = 16, Message = "I’m making pasta for dinner.", FromThisUser = true } },
            { 17, new MessageState { Id = 17, Message = "Sounds good.", FromThisUser = false } },
            { 18, new MessageState { Id = 18, Message = "Do we have parmesan?", FromThisUser = true } },
            { 19, new MessageState { Id = 19, Message = "Yes, in the top drawer.", FromThisUser = false } },
            { 20, new MessageState { Id = 20, Message = "Great, thanks.", FromThisUser = true } }
        }
    },
    new UserState
    {
        Id = 3,
        UserName = "Mia",
        UserSuffix = "TX",
        Messages = new Dictionary<int, MessageState>
        {
            { 1, new MessageState { Id = 1, Message = "I’m running 10 minutes late.", FromThisUser = true } },
            { 2, new MessageState { Id = 2, Message = "No worries, just grab a seat when you get here.", FromThisUser = false } },
            { 3, new MessageState { Id = 3, Message = "Did you already order?", FromThisUser = true } },
            { 4, new MessageState { Id = 4, Message = "Yep — I got the salmon salad.", FromThisUser = false } },
            { 5, new MessageState { Id = 5, Message = "I’ll take the same.", FromThisUser = true } },
            { 6, new MessageState { Id = 6, Message = "Perfect.", FromThisUser = false } },
            { 7, new MessageState { Id = 7, Message = "How’s your week going?", FromThisUser = true } },
            { 8, new MessageState { Id = 8, Message = "Busy, but good. Lots of meetings.", FromThisUser = false } },
            { 9, new MessageState { Id = 9, Message = "Same here.", FromThisUser = true } },
            { 10, new MessageState { Id = 10, Message = "At least the weather is nice.", FromThisUser = false } },
            { 11, new MessageState { Id = 11, Message = "True, finally.", FromThisUser = true } },
            { 12, new MessageState { Id = 12, Message = "Want to go for a walk after lunch?", FromThisUser = false } },
            { 13, new MessageState { Id = 13, Message = "Sure, I could use the break.", FromThisUser = true } },
            { 14, new MessageState { Id = 14, Message = "Great.", FromThisUser = false } },
            { 15, new MessageState { Id = 15, Message = "I need coffee first.", FromThisUser = true } },
            { 16, new MessageState { Id = 16, Message = "Same.", FromThisUser = false } },
            { 17, new MessageState { Id = 17, Message = "The new project starts Monday.", FromThisUser = true } },
            { 18, new MessageState { Id = 18, Message = "Good to know.", FromThisUser = false } },
            { 19, new MessageState { Id = 19, Message = "I’ll send over the notes later.", FromThisUser = true } },
            { 20, new MessageState { Id = 20, Message = "Thanks, appreciate it.", FromThisUser = false } }
        }
    },
    new UserState
    {
        Id = 4,
        UserName = "Ethan",
        UserSuffix = "WA",
        Messages = new Dictionary<int, MessageState>
        {
            { 1, new MessageState { Id = 1, Message = "Did you see the game last night?", FromThisUser = false } },
            { 2, new MessageState { Id = 2, Message = "Yeah, that overtime finish was wild.", FromThisUser = true } },
            { 3, new MessageState { Id = 3, Message = "I couldn’t believe that last shot.", FromThisUser = false } },
            { 4, new MessageState { Id = 4, Message = "Same here. Total clutch moment.", FromThisUser = true } },
            { 5, new MessageState { Id = 5, Message = "You’re coming to the watch party Friday?", FromThisUser = false } },
            { 6, new MessageState { Id = 6, Message = "Absolutely.", FromThisUser = true } },
            { 7, new MessageState { Id = 7, Message = "Bring chips if you can.", FromThisUser = false } },
            { 8, new MessageState { Id = 8, Message = "I’ve got it.", FromThisUser = true } },
            { 9, new MessageState { Id = 9, Message = "Nice. What time are you heading over?", FromThisUser = false } },
            { 10, new MessageState { Id = 10, Message = "Around 6:30.", FromThisUser = true } },
            { 11, new MessageState { Id = 11, Message = "Perfect.", FromThisUser = false } },
            { 12, new MessageState { Id = 12, Message = "I’m trying a new hot sauce recipe.", FromThisUser = true } },
            { 13, new MessageState { Id = 13, Message = "That sounds dangerous.", FromThisUser = false } },
            { 14, new MessageState { Id = 14, Message = "Only a little.", FromThisUser = true } },
            { 15, new MessageState { Id = 15, Message = "Do you need help setting up?", FromThisUser = false } },
            { 16, new MessageState { Id = 16, Message = "Maybe with the speakers.", FromThisUser = true } },
            { 17, new MessageState { Id = 17, Message = "I can handle that.", FromThisUser = false } },
            { 18, new MessageState { Id = 18, Message = "Cool, see you then.", FromThisUser = true } },
            { 19, new MessageState { Id = 19, Message = "Looking forward to it.", FromThisUser = false } },
            { 20, new MessageState { Id = 20, Message = "Same.", FromThisUser = true } }
        }
    },
    new UserState
    {
        Id = 5,
        UserName = "Sophia",
        UserSuffix = "FL",
        Messages = new Dictionary<int, MessageState>
        {
            { 1, new MessageState { Id = 1, Message = "Are you free to review the brochure today?", FromThisUser = true } },
            { 2, new MessageState { Id = 2, Message = "Yes, send it over.", FromThisUser = false } },
            { 3, new MessageState { Id = 3, Message = "I think the headline needs work.", FromThisUser = false } },
            { 4, new MessageState { Id = 4, Message = "Agreed, I’ll rewrite it.", FromThisUser = true } },
            { 5, new MessageState { Id = 5, Message = "The photos look good though.", FromThisUser = false } },
            { 6, new MessageState { Id = 6, Message = "Glad to hear that.", FromThisUser = true } },
            { 7, new MessageState { Id = 7, Message = "Can we make the CTA more prominent?", FromThisUser = false } },
            { 8, new MessageState { Id = 8, Message = "Yes, I’ll enlarge it.", FromThisUser = true } },
            { 9, new MessageState { Id = 9, Message = "Thanks.", FromThisUser = false } },
            { 10, new MessageState { Id = 10, Message = "I’ll have the revision by 4.", FromThisUser = true } },
            { 11, new MessageState { Id = 11, Message = "Great.", FromThisUser = false } },
            { 12, new MessageState { Id = 12, Message = "Client liked the first draft overall.", FromThisUser = true } },
            { 13, new MessageState { Id = 13, Message = "That’s a good sign.", FromThisUser = false } },
            { 14, new MessageState { Id = 14, Message = "They want a more modern tone.", FromThisUser = true } },
            { 15, new MessageState { Id = 15, Message = "Okay, that’s manageable.", FromThisUser = false } },
            { 16, new MessageState { Id = 16, Message = "I’m updating the footer now.", FromThisUser = true } },
            { 17, new MessageState { Id = 17, Message = "Perfect.", FromThisUser = false } },
            { 18, new MessageState { Id = 18, Message = "Can you check spelling once I’m done?", FromThisUser = true } },
            { 19, new MessageState { Id = 19, Message = "Of course.", FromThisUser = false } },
            { 20, new MessageState { Id = 20, Message = "Awesome, thanks.", FromThisUser = true } }
        }
    },
    new UserState
    {
        Id = 6,
        UserName = "Liam",
        UserSuffix = "IL",
        Messages = new Dictionary<int, MessageState>
        {
            { 1, new MessageState { Id = 1, Message = "Train’s delayed again.", FromThisUser = false } },
            { 2, new MessageState { Id = 2, Message = "Of course it is.", FromThisUser = true } },
            { 3, new MessageState { Id = 3, Message = "I’ll probably be home by 7.", FromThisUser = false } },
            { 4, new MessageState { Id = 4, Message = "Okay, I’ll start dinner later.", FromThisUser = true } },
            { 5, new MessageState { Id = 5, Message = "Thanks.", FromThisUser = false } },
            { 6, new MessageState { Id = 6, Message = "Do you want me to pick up anything on the way?", FromThisUser = true } },
            { 7, new MessageState { Id = 7, Message = "Maybe bread and fruit.", FromThisUser = false } },
            { 8, new MessageState { Id = 8, Message = "Got it.", FromThisUser = true } },
            { 9, new MessageState { Id = 9, Message = "I have a meeting that ran long.", FromThisUser = false } },
            { 10, new MessageState { Id = 10, Message = "No stress.", FromThisUser = true } },
            { 11, new MessageState { Id = 11, Message = "The client was happy though.", FromThisUser = false } },
            { 12, new MessageState { Id = 12, Message = "That’s good.", FromThisUser = true } },
            { 13, new MessageState { Id = 13, Message = "I’ll be on the 6:10.", FromThisUser = false } },
            { 14, new MessageState { Id = 14, Message = "Okay, text me if that changes.", FromThisUser = true } },
            { 15, new MessageState { Id = 15, Message = "Will do.", FromThisUser = false } },
            { 16, new MessageState { Id = 16, Message = "Can you feed the cat?", FromThisUser = false } },
            { 17, new MessageState { Id = 17, Message = "Already done.", FromThisUser = true } },
            { 18, new MessageState { Id = 18, Message = "Thanks.", FromThisUser = false } },
            { 19, new MessageState { Id = 19, Message = "I owe you one.", FromThisUser = false } },
            { 20, new MessageState { Id = 20, Message = "You always say that.", FromThisUser = true } }
        }
    },
    new UserState
    {
        Id = 7,
        UserName = "Olivia",
        UserSuffix = "MA",
        Messages = new Dictionary<int, MessageState>
        {
            { 1, new MessageState { Id = 1, Message = "Can you look over my resume tonight?", FromThisUser = true } },
            { 2, new MessageState { Id = 2, Message = "Absolutely, send it through.", FromThisUser = false } },
            { 3, new MessageState { Id = 3, Message = "I’m applying for the product role.", FromThisUser = true } },
            { 4, new MessageState { Id = 4, Message = "Nice, that’s a good fit for you.", FromThisUser = false } },
            { 5, new MessageState { Id = 5, Message = "I’m nervous about the cover letter.", FromThisUser = true } },
            { 6, new MessageState { Id = 6, Message = "Don’t overthink it. Keep it simple.", FromThisUser = false } },
            { 7, new MessageState { Id = 7, Message = "Good advice.", FromThisUser = true } },
            { 8, new MessageState { Id = 8, Message = "I’ll mark up the resume first.", FromThisUser = false } },
            { 9, new MessageState { Id = 9, Message = "Thanks.", FromThisUser = true } },
            { 10, new MessageState { Id = 10, Message = "Did you already update LinkedIn?", FromThisUser = false } },
            { 11, new MessageState { Id = 11, Message = "Not yet, but I will.", FromThisUser = true } },
            { 12, new MessageState { Id = 12, Message = "That’s worth doing.", FromThisUser = false } },
            { 13, new MessageState { Id = 13, Message = "I have a few bullet points to tighten.", FromThisUser = true } },
            { 14, new MessageState { Id = 14, Message = "Great, I can help with that.", FromThisUser = false } },
            { 15, new MessageState { Id = 15, Message = "Could you call me after dinner?", FromThisUser = true } },
            { 16, new MessageState { Id = 16, Message = "Sure.", FromThisUser = false } },
            { 17, new MessageState { Id = 17, Message = "I’m free around 8.", FromThisUser = true } },
            { 18, new MessageState { Id = 18, Message = "Works for me.", FromThisUser = false } },
            { 19, new MessageState { Id = 19, Message = "You’ve got this.", FromThisUser = false } },
            { 20, new MessageState { Id = 20, Message = "Thanks — that helps.", FromThisUser = true } }
        }
    },
    new UserState
    {
        Id = 8,
        UserName = "James",
        UserSuffix = "CO",
        Messages = new Dictionary<int, MessageState>
        {
            { 1, new MessageState { Id = 1, Message = "The meeting got moved to tomorrow.", FromThisUser = false } },
            { 2, new MessageState { Id = 2, Message = "Thanks for the heads-up.", FromThisUser = true } },
            { 3, new MessageState { Id = 3, Message = "I already sent the calendar update.", FromThisUser = false } },
            { 4, new MessageState { Id = 4, Message = "Perfect.", FromThisUser = true } },
            { 5, new MessageState { Id = 5, Message = "Did you get a chance to test the build?", FromThisUser = false } },
            { 6, new MessageState { Id = 6, Message = "Yes, it passed on my machine.", FromThisUser = true } },
            { 7, new MessageState { Id = 7, Message = "Great news.", FromThisUser = false } },
            { 8, new MessageState { Id = 8, Message = "There’s one small UI glitch on mobile.", FromThisUser = true } },
            { 9, new MessageState { Id = 9, Message = "I’ll fix that this afternoon.", FromThisUser = false } },
            { 10, new MessageState { Id = 10, Message = "Cool.", FromThisUser = true } },
            { 11, new MessageState { Id = 11, Message = "The release notes are nearly done.", FromThisUser = false } },
            { 12, new MessageState { Id = 12, Message = "Send them when ready.", FromThisUser = true } },
            { 13, new MessageState { Id = 13, Message = "Will do.", FromThisUser = false } },
            { 14, new MessageState { Id = 14, Message = "I’m adding screenshots now.", FromThisUser = true } },
            { 15, new MessageState { Id = 15, Message = "Nice.", FromThisUser = false } },
            { 16, new MessageState { Id = 16, Message = "Can we push by end of day?", FromThisUser = false } },
            { 17, new MessageState { Id = 17, Message = "Yes, that should be fine.", FromThisUser = true } },
            { 18, new MessageState { Id = 18, Message = "Awesome.", FromThisUser = false } },
            { 19, new MessageState { Id = 19, Message = "I’ll keep you posted.", FromThisUser = true } },
            { 20, new MessageState { Id = 20, Message = "Thanks.", FromThisUser = false } }
        }
    },
    new UserState
    {
        Id = 9,
        UserName = "Isabella",
        UserSuffix = "AZ",
        Messages = new Dictionary<int, MessageState>
        {
            { 1, new MessageState { Id = 1, Message = "Dinner was excellent last night.", FromThisUser = false } },
            { 2, new MessageState { Id = 2, Message = "Glad you liked it.", FromThisUser = true } },
            { 3, new MessageState { Id = 3, Message = "You should share the recipe.", FromThisUser = false } },
            { 4, new MessageState { Id = 4, Message = "I can send it over.", FromThisUser = true } },
            { 5, new MessageState { Id = 5, Message = "Please do.", FromThisUser = false } },
            { 6, new MessageState { Id = 6, Message = "It’s pretty easy, actually.", FromThisUser = true } },
            { 7, new MessageState { Id = 7, Message = "Even better.", FromThisUser = false } },
            { 8, new MessageState { Id = 8, Message = "I used fresh basil and lemon.", FromThisUser = true } },
            { 9, new MessageState { Id = 9, Message = "That explains it.", FromThisUser = false } },
            { 10, new MessageState { Id = 10, Message = "Are you free this weekend?", FromThisUser = true } },
            { 11, new MessageState { Id = 11, Message = "I think so.", FromThisUser = false } },
            { 12, new MessageState { Id = 12, Message = "Want to check out the market?", FromThisUser = true } },
            { 13, new MessageState { Id = 13, Message = "Yes, that sounds fun.", FromThisUser = false } },
            { 14, new MessageState { Id = 14, Message = "Great.", FromThisUser = true } },
            { 15, new MessageState { Id = 15, Message = "I still owe you lunch.", FromThisUser = false } },
            { 16, new MessageState { Id = 16, Message = "We can make it happen.", FromThisUser = true } },
            { 17, new MessageState { Id = 17, Message = "Saturday maybe?", FromThisUser = false } },
            { 18, new MessageState { Id = 18, Message = "Saturday works.", FromThisUser = true } },
            { 19, new MessageState { Id = 19, Message = "Perfect.", FromThisUser = false } },
            { 20, new MessageState { Id = 20, Message = "See you then.", FromThisUser = true } }
        }
    },
    new UserState
    {
        Id = 10,
        UserName = "Lucas",
        UserSuffix = "OR",
        Messages = new Dictionary<int, MessageState>
        {
            { 1, new MessageState { Id = 1, Message = "The server restarted overnight.", FromThisUser = true } },
            { 2, new MessageState { Id = 2, Message = "Did anything fail?", FromThisUser = false } },
            { 3, new MessageState { Id = 3, Message = "A couple jobs retried but recovered.", FromThisUser = true } },
            { 4, new MessageState { Id = 4, Message = "Good. Keep an eye on logs.", FromThisUser = false } },
            { 5, new MessageState { Id = 5, Message = "Already doing that.", FromThisUser = true } },
            { 6, new MessageState { Id = 6, Message = "Any user complaints yet?", FromThisUser = false } },
            { 7, new MessageState { Id = 7, Message = "None so far.", FromThisUser = true } },
            { 8, new MessageState { Id = 8, Message = "Great.", FromThisUser = false } },
            { 9, new MessageState { Id = 9, Message = "I’m patching the config issue now.", FromThisUser = true } },
            { 10, new MessageState { Id = 10, Message = "Thanks.", FromThisUser = false } },
            { 11, new MessageState { Id = 11, Message = "We should schedule maintenance for Sunday.", FromThisUser = true } },
            { 12, new MessageState { Id = 12, Message = "Agreed.", FromThisUser = false } },
            { 13, new MessageState { Id = 13, Message = "I’ll draft the notice.", FromThisUser = true } },
            { 14, new MessageState { Id = 14, Message = "Please do.", FromThisUser = false } },
            { 15, new MessageState { Id = 15, Message = "Also rotating the API keys.", FromThisUser = true } },
            { 16, new MessageState { Id = 16, Message = "Good call.", FromThisUser = false } },
            { 17, new MessageState { Id = 17, Message = "Rollback plan is ready.", FromThisUser = true } },
            { 18, new MessageState { Id = 18, Message = "Excellent.", FromThisUser = false } },
            { 19, new MessageState { Id = 19, Message = "I’ll send an update in Slack.", FromThisUser = true } },
            { 20, new MessageState { Id = 20, Message = "Sounds good.", FromThisUser = false } }
        }
    }
];
    }
}