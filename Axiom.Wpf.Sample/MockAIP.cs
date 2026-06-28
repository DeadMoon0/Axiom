using Axiom.Wpf.Sample.State.Users;
using Axiom.Wpf.Sample.State.Users.Messages;

namespace Axiom.Wpf.Sample;

public static class MockAIP
{
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
                Messages = [
                    new MessageState { Id = 1, Message = "Morning — are we still on for 9:30?", FromThisUser = true },
                    new MessageState { Id = 2, Message = "Yep, I’ll be there a few minutes early.", FromThisUser = false },
                    new MessageState { Id = 3, Message = "Great. I’m sending the deck now.", FromThisUser = true },
                    new MessageState { Id = 4, Message = "Got it, reviewing shortly.", FromThisUser = false },
                    new MessageState { Id = 5, Message = "Can you add the Q3 numbers on slide 4?", FromThisUser = false },
                    new MessageState { Id = 6, Message = "Yes, I’ll update that now.", FromThisUser = true },
                    new MessageState { Id = 7, Message = "Thanks.", FromThisUser = false },
                    new MessageState { Id = 8, Message = "Also moving the client call to 2:00?", FromThisUser = true },
                    new MessageState { Id = 9, Message = "Works for me.", FromThisUser = false },
                    new MessageState { Id = 10, Message = "Perfect.", FromThisUser = true },
                    new MessageState { Id = 11, Message = "I left comments in the doc.", FromThisUser = false },
                    new MessageState { Id = 12, Message = "Saw them — thanks.", FromThisUser = true },
                    new MessageState { Id = 13, Message = "Any chance we can simplify the budget section?", FromThisUser = false },
                    new MessageState { Id = 14, Message = "Yes, I’ll trim it down.", FromThisUser = true },
                    new MessageState { Id = 15, Message = "Great.", FromThisUser = false },
                    new MessageState { Id = 16, Message = "I’m stepping out for lunch.", FromThisUser = true },
                    new MessageState { Id = 17, Message = "No problem, ping me when you’re back.", FromThisUser = false },
                    new MessageState { Id = 18, Message = "Will do.", FromThisUser = true },
                    new MessageState { Id = 19, Message = "Slide 6 looks much better now.", FromThisUser = false },
                    new MessageState { Id = 20, Message = "Awesome, glad it works.", FromThisUser = true }
                ]
            },
            new UserState
            {
                Id = 2,
                UserName = "Noah",
                UserSuffix = "CA",
                Messages = [
                    new MessageState { Id = 1, Message = "Did the plumber ever show up?", FromThisUser = false },
                    new MessageState { Id = 2, Message = "Yeah, he came around noon and fixed the leak.", FromThisUser = true },
                    new MessageState { Id = 3, Message = "Nice. Was it expensive?", FromThisUser = false },
                    new MessageState { Id = 4, Message = "Not too bad, thankfully.", FromThisUser = true },
                    new MessageState { Id = 5, Message = "Can you send me the receipt?", FromThisUser = false },
                    new MessageState { Id = 6, Message = "Sure, I’ll forward it tonight.", FromThisUser = true },
                    new MessageState { Id = 7, Message = "Thanks.", FromThisUser = false },
                    new MessageState { Id = 8, Message = "Also, the grocery order came in.", FromThisUser = true },
                    new MessageState { Id = 9, Message = "Did they forget anything?", FromThisUser = false },
                    new MessageState { Id = 10, Message = "Just the oat milk.", FromThisUser = true },
                    new MessageState { Id = 11, Message = "I can grab that tomorrow.", FromThisUser = false },
                    new MessageState { Id = 12, Message = "Perfect.", FromThisUser = true },
                    new MessageState { Id = 13, Message = "Are you still picking up the kids?", FromThisUser = false },
                    new MessageState { Id = 14, Message = "Yes, I’ll leave by 3:15.", FromThisUser = true },
                    new MessageState { Id = 15, Message = "Okay, I’ll let them know.", FromThisUser = false },
                    new MessageState { Id = 16, Message = "I’m making pasta for dinner.", FromThisUser = true },
                    new MessageState { Id = 17, Message = "Sounds good.", FromThisUser = false },
                    new MessageState { Id = 18, Message = "Do we have parmesan?", FromThisUser = true },
                    new MessageState { Id = 19, Message = "Yes, in the top drawer.", FromThisUser = false },
                    new MessageState { Id = 20, Message = "Great, thanks.", FromThisUser = true }
                ]
            },
            new UserState
            {
                Id = 3,
                UserName = "Mia",
                UserSuffix = "TX",
                Messages = [
                    new MessageState { Id = 1, Message = "I’m running 10 minutes late.", FromThisUser = true },
                    new MessageState { Id = 2, Message = "No worries, just grab a seat when you get here.", FromThisUser = false },
                    new MessageState { Id = 3, Message = "Did you already order?", FromThisUser = true },
                    new MessageState { Id = 4, Message = "Yep — I got the salmon salad.", FromThisUser = false },
                    new MessageState { Id = 5, Message = "I’ll take the same.", FromThisUser = true },
                    new MessageState { Id = 6, Message = "Perfect.", FromThisUser = false },
                    new MessageState { Id = 7, Message = "How’s your week going?", FromThisUser = true },
                    new MessageState { Id = 8, Message = "Busy, but good. Lots of meetings.", FromThisUser = false },
                    new MessageState { Id = 9, Message = "Same here.", FromThisUser = true },
                    new MessageState { Id = 10, Message = "At least the weather is nice.", FromThisUser = false },
                    new MessageState { Id = 11, Message = "True, finally.", FromThisUser = true },
                    new MessageState { Id = 12, Message = "Want to go for a walk after lunch?", FromThisUser = false },
                    new MessageState { Id = 13, Message = "Sure, I could use the break.", FromThisUser = true },
                    new MessageState { Id = 14, Message = "Great.", FromThisUser = false },
                    new MessageState { Id = 15, Message = "I need coffee first.", FromThisUser = true },
                    new MessageState { Id = 16, Message = "Same.", FromThisUser = false },
                    new MessageState { Id = 17, Message = "The new project starts Monday.", FromThisUser = true },
                    new MessageState { Id = 18, Message = "Good to know.", FromThisUser = false },
                    new MessageState { Id = 19, Message = "I’ll send over the notes later.", FromThisUser = true },
                    new MessageState { Id = 20, Message = "Thanks, appreciate it.", FromThisUser = false }
                ]
            },
            new UserState
            {
                Id = 4,
                UserName = "Ethan",
                UserSuffix = "WA",
                Messages = [
                    new MessageState { Id = 1, Message = "Did you see the game last night?", FromThisUser = false },
                    new MessageState { Id = 2, Message = "Yeah, that overtime finish was wild.", FromThisUser = true },
                    new MessageState { Id = 3, Message = "I couldn’t believe that last shot.", FromThisUser = false },
                    new MessageState { Id = 4, Message = "Same here. Total clutch moment.", FromThisUser = true },
                    new MessageState { Id = 5, Message = "You’re coming to the watch party Friday?", FromThisUser = false },
                    new MessageState { Id = 6, Message = "Absolutely.", FromThisUser = true },
                    new MessageState { Id = 7, Message = "Bring chips if you can.", FromThisUser = false },
                    new MessageState { Id = 8, Message = "I’ve got it.", FromThisUser = true },
                    new MessageState { Id = 9, Message = "Nice. What time are you heading over?", FromThisUser = false },
                    new MessageState { Id = 10, Message = "Around 6:30.", FromThisUser = true },
                    new MessageState { Id = 11, Message = "Perfect.", FromThisUser = false },
                    new MessageState { Id = 12, Message = "I’m trying a new hot sauce recipe.", FromThisUser = true },
                    new MessageState { Id = 13, Message = "That sounds dangerous.", FromThisUser = false },
                    new MessageState { Id = 14, Message = "Only a little.", FromThisUser = true },
                    new MessageState { Id = 15, Message = "Do you need help setting up?", FromThisUser = false },
                    new MessageState { Id = 16, Message = "Maybe with the speakers.", FromThisUser = true },
                    new MessageState { Id = 17, Message = "I can handle that.", FromThisUser = false },
                    new MessageState { Id = 18, Message = "Cool, see you then.", FromThisUser = true },
                    new MessageState { Id = 19, Message = "Looking forward to it.", FromThisUser = false },
                    new MessageState { Id = 20, Message = "Same.", FromThisUser = true }
                ]
            },
            new UserState
            {
                Id = 5,
                UserName = "Sophia",
                UserSuffix = "FL",
                Messages = [
                    new MessageState { Id = 1, Message = "Are you free to review the brochure today?", FromThisUser = true },
                    new MessageState { Id = 2, Message = "Yes, send it over.", FromThisUser = false },
                    new MessageState { Id = 3, Message = "I think the headline needs work.", FromThisUser = false },
                    new MessageState { Id = 4, Message = "Agreed, I’ll rewrite it.", FromThisUser = true },
                    new MessageState { Id = 5, Message = "The photos look good though.", FromThisUser = false },
                    new MessageState { Id = 6, Message = "Glad to hear that.", FromThisUser = true },
                    new MessageState { Id = 7, Message = "Can we make the CTA more prominent?", FromThisUser = false },
                    new MessageState { Id = 8, Message = "Yes, I’ll enlarge it.", FromThisUser = true },
                    new MessageState { Id = 9, Message = "Thanks.", FromThisUser = false },
                    new MessageState { Id = 10, Message = "I’ll have the revision by 4.", FromThisUser = true },
                    new MessageState { Id = 11, Message = "Great.", FromThisUser = false },
                    new MessageState { Id = 12, Message = "Client liked the first draft overall.", FromThisUser = true },
                    new MessageState { Id = 13, Message = "That’s a good sign.", FromThisUser = false },
                    new MessageState { Id = 14, Message = "They want a more modern tone.", FromThisUser = true },
                    new MessageState { Id = 15, Message = "Okay, that’s manageable.", FromThisUser = false },
                    new MessageState { Id = 16, Message = "I’m updating the footer now.", FromThisUser = true },
                    new MessageState { Id = 17, Message = "Perfect.", FromThisUser = false },
                    new MessageState { Id = 18, Message = "Can you check spelling once I’m done?", FromThisUser = true },
                    new MessageState { Id = 19, Message = "Of course.", FromThisUser = false },
                    new MessageState { Id = 20, Message = "Awesome, thanks.", FromThisUser = true }
                ]
            },
            new UserState
            {
                Id = 6,
                UserName = "Liam",
                UserSuffix = "IL",
                Messages = [
                    new MessageState { Id = 1, Message = "Train’s delayed again.", FromThisUser = false },
                    new MessageState { Id = 2, Message = "Of course it is.", FromThisUser = true },
                    new MessageState { Id = 3, Message = "I’ll probably be home by 7.", FromThisUser = false },
                    new MessageState { Id = 4, Message = "Okay, I’ll start dinner later.", FromThisUser = true },
                    new MessageState { Id = 5, Message = "Thanks.", FromThisUser = false },
                    new MessageState { Id = 6, Message = "Do you want me to pick up anything on the way?", FromThisUser = true },
                    new MessageState { Id = 7, Message = "Maybe bread and fruit.", FromThisUser = false },
                    new MessageState { Id = 8, Message = "Got it.", FromThisUser = true },
                    new MessageState { Id = 9, Message = "I have a meeting that ran long.", FromThisUser = false },
                    new MessageState { Id = 10, Message = "No stress.", FromThisUser = true },
                    new MessageState { Id = 11, Message = "The client was happy though.", FromThisUser = false },
                    new MessageState { Id = 12, Message = "That’s good.", FromThisUser = true },
                    new MessageState { Id = 13, Message = "I’ll be on the 6:10.", FromThisUser = false },
                    new MessageState { Id = 14, Message = "Okay, text me if that changes.", FromThisUser = true },
                    new MessageState { Id = 15, Message = "Will do.", FromThisUser = false },
                    new MessageState { Id = 16, Message = "Can you feed the cat?", FromThisUser = false },
                    new MessageState { Id = 17, Message = "Already done.", FromThisUser = true },
                    new MessageState { Id = 18, Message = "Thanks.", FromThisUser = false },
                    new MessageState { Id = 19, Message = "I owe you one.", FromThisUser = false },
                    new MessageState { Id = 20, Message = "You always say that.", FromThisUser = true }
                ]
            },
            new UserState
            {
                Id = 7,
                UserName = "Olivia",
                UserSuffix = "MA",
                Messages = [
                    new MessageState { Id = 1, Message = "Can you look over my resume tonight?", FromThisUser = true },
                    new MessageState { Id = 2, Message = "Absolutely, send it through.", FromThisUser = false },
                    new MessageState { Id = 3, Message = "I’m applying for the product role.", FromThisUser = true },
                    new MessageState { Id = 4, Message = "Nice, that’s a good fit for you.", FromThisUser = false },
                    new MessageState { Id = 5, Message = "I’m nervous about the cover letter.", FromThisUser = true },
                    new MessageState { Id = 6, Message = "Don’t overthink it. Keep it simple.", FromThisUser = false },
                    new MessageState { Id = 7, Message = "Good advice.", FromThisUser = true },
                    new MessageState { Id = 8, Message = "I’ll mark up the resume first.", FromThisUser = false },
                    new MessageState { Id = 9, Message = "Thanks.", FromThisUser = true },
                    new MessageState { Id = 10, Message = "Did you already update LinkedIn?", FromThisUser = false },
                    new MessageState { Id = 11, Message = "Not yet, but I will.", FromThisUser = true },
                    new MessageState { Id = 12, Message = "That’s worth doing.", FromThisUser = false },
                    new MessageState { Id = 13, Message = "I have a few bullet points to tighten.", FromThisUser = true },
                    new MessageState { Id = 14, Message = "Great, I can help with that.", FromThisUser = false },
                    new MessageState { Id = 15, Message = "Could you call me after dinner?", FromThisUser = true },
                    new MessageState { Id = 16, Message = "Sure.", FromThisUser = false },
                    new MessageState { Id = 17, Message = "I’m free around 8.", FromThisUser = true },
                    new MessageState { Id = 18, Message = "Works for me.", FromThisUser = false },
                    new MessageState { Id = 19, Message = "You’ve got this.", FromThisUser = false },
                    new MessageState { Id = 20, Message = "Thanks — that helps.", FromThisUser = true }
                ]
            },
            new UserState
            {
                Id = 8,
                UserName = "James",
                UserSuffix = "CO",
                Messages = [
                    new MessageState { Id = 1, Message = "The meeting got moved to tomorrow.", FromThisUser = false },
                    new MessageState { Id = 2, Message = "Thanks for the heads-up.", FromThisUser = true },
                    new MessageState { Id = 3, Message = "I already sent the calendar update.", FromThisUser = false },
                    new MessageState { Id = 4, Message = "Perfect.", FromThisUser = true },
                    new MessageState { Id = 5, Message = "Did you get a chance to test the build?", FromThisUser = false },
                    new MessageState { Id = 6, Message = "Yes, it passed on my machine.", FromThisUser = true },
                    new MessageState { Id = 7, Message = "Great news.", FromThisUser = false },
                    new MessageState { Id = 8, Message = "There’s one small UI glitch on mobile.", FromThisUser = true },
                    new MessageState { Id = 9, Message = "I’ll fix that this afternoon.", FromThisUser = false },
                    new MessageState { Id = 10, Message = "Cool.", FromThisUser = true },
                    new MessageState { Id = 11, Message = "The release notes are nearly done.", FromThisUser = false },
                    new MessageState { Id = 12, Message = "Send them when ready.", FromThisUser = true },
                    new MessageState { Id = 13, Message = "Will do.", FromThisUser = false },
                    new MessageState { Id = 14, Message = "I’m adding screenshots now.", FromThisUser = true },
                    new MessageState { Id = 15, Message = "Nice.", FromThisUser = false },
                    new MessageState { Id = 16, Message = "Can we push by end of day?", FromThisUser = false },
                    new MessageState { Id = 17, Message = "Yes, that should be fine.", FromThisUser = true },
                    new MessageState { Id = 18, Message = "Awesome.", FromThisUser = false },
                    new MessageState { Id = 19, Message = "I’ll keep you posted.", FromThisUser = true },
                    new MessageState { Id = 20, Message = "Thanks.", FromThisUser = false }
                ]
            },
            new UserState
            {
                Id = 9,
                UserName = "Isabella",
                UserSuffix = "AZ",
                Messages = [
                    new MessageState { Id = 1, Message = "Dinner was excellent last night.", FromThisUser = false },
                    new MessageState { Id = 2, Message = "Glad you liked it.", FromThisUser = true },
                    new MessageState { Id = 3, Message = "You should share the recipe.", FromThisUser = false },
                    new MessageState { Id = 4, Message = "I can send it over.", FromThisUser = true },
                    new MessageState { Id = 5, Message = "Please do.", FromThisUser = false },
                    new MessageState { Id = 6, Message = "It’s pretty easy, actually.", FromThisUser = true },
                    new MessageState { Id = 7, Message = "Even better.", FromThisUser = false },
                    new MessageState { Id = 8, Message = "I used fresh basil and lemon.", FromThisUser = true },
                    new MessageState { Id = 9, Message = "That explains it.", FromThisUser = false },
                    new MessageState { Id = 10, Message = "Are you free this weekend?", FromThisUser = true },
                    new MessageState { Id = 11, Message = "I think so.", FromThisUser = false },
                    new MessageState { Id = 12, Message = "Want to check out the market?", FromThisUser = true },
                    new MessageState { Id = 13, Message = "Yes, that sounds fun.", FromThisUser = false },
                    new MessageState { Id = 14, Message = "Great.", FromThisUser = true },
                    new MessageState { Id = 15, Message = "I still owe you lunch.", FromThisUser = false },
                    new MessageState { Id = 16, Message = "We can make it happen.", FromThisUser = true },
                    new MessageState { Id = 17, Message = "Saturday maybe?", FromThisUser = false },
                    new MessageState { Id = 18, Message = "Saturday works.", FromThisUser = true },
                    new MessageState { Id = 19, Message = "Perfect.", FromThisUser = false },
                    new MessageState { Id = 20, Message = "See you then.", FromThisUser = true }
                ]
            },
            new UserState
            {
                Id = 10,
                UserName = "Lucas",
                UserSuffix = "OR",
                Messages = [
                    new MessageState { Id = 1, Message = "The server restarted overnight.", FromThisUser = true },
                    new MessageState { Id = 2, Message = "Did anything fail?", FromThisUser = false },
                    new MessageState { Id = 3, Message = "A couple jobs retried but recovered.", FromThisUser = true },
                    new MessageState { Id = 4, Message = "Good. Keep an eye on logs.", FromThisUser = false },
                    new MessageState { Id = 5, Message = "Already doing that.", FromThisUser = true },
                    new MessageState { Id = 6, Message = "Any user complaints yet?", FromThisUser = false },
                    new MessageState { Id = 7, Message = "None so far.", FromThisUser = true },
                    new MessageState { Id = 8, Message = "Great.", FromThisUser = false },
                    new MessageState { Id = 9, Message = "I’m patching the config issue now.", FromThisUser = true },
                    new MessageState { Id = 10, Message = "Thanks.", FromThisUser = false },
                    new MessageState { Id = 11, Message = "We should schedule maintenance for Sunday.", FromThisUser = true },
                    new MessageState { Id = 12, Message = "Agreed.", FromThisUser = false },
                    new MessageState { Id = 13, Message = "I’ll draft the notice.", FromThisUser = true },
                    new MessageState { Id = 14, Message = "Please do.", FromThisUser = false },
                    new MessageState { Id = 15, Message = "Also rotating the API keys.", FromThisUser = true },
                    new MessageState { Id = 16, Message = "Good call.", FromThisUser = false },
                    new MessageState { Id = 17, Message = "Rollback plan is ready.", FromThisUser = true },
                    new MessageState { Id = 18, Message = "Excellent.", FromThisUser = false },
                    new MessageState { Id = 19, Message = "I’ll send an update in Slack.", FromThisUser = true },
                    new MessageState { Id = 20, Message = "Sounds good.", FromThisUser = false }
                ]
            }
        ];
    }
}