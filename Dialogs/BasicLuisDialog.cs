using System;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;

namespace LuisBot.FormOrder
{
    // For more information about this template visit http://aka.ms/azurebots-csharp-luis
    [Serializable]
    public class BasicLuisDialog : LuisDialog<object>
    {
        public BasicLuisDialog() : base(new LuisService(new LuisModelAttribute(ConfigurationManager.AppSettings["LuisAppId"], ConfigurationManager.AppSettings["LuisAPIKey"])))
        {
        }

        internal static IDialog<FormOrder> FromForm(object buildForm)
        {
            throw new NotImplementedException();
        }

        public override async Task StartAsync(IDialogContext context)
        {


            // Determine bots reaction for speech purposes
            
            var message = context.MakeMessage();
            string spoken = "hat der alte Hexenmeister sich doch einmal fortbegeben";
            message.Speak = SSMLHelper.Speak(spoken);
            

            // Send card and bots reaction to user.
            message.InputHint = Microsoft.Bot.Connector.InputHints.AcceptingInput;
            await context.PostAsync(message);

            context.Done<object>(null);
        }

        [LuisIntent("None")]
        public async Task NoneIntent(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"You have reached the none intent. You said: {result.Query}"); //
            context.Wait(MessageReceived);
        }

        [LuisIntent("help")]
        public async Task helpIntent(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"You have reached the help intent. You said: {result.Query}"); //
            context.Wait(MessageReceived);
        }

        [LuisIntent("openPage")]
        public async Task openPageIntent(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"You have reached the openPage intent. You said: {result.Query}"); //
            context.Wait(MessageReceived);
        }

        [LuisIntent("closeApp")]
        public async Task closeAppIntent(IDialogContext context, LuisResult result)
        {
            await context.PostAsync($"You have reached the close App intent. You said: {result.Query}"); //
            context.Wait(MessageReceived);
        }
    }
}