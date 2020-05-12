using System;
using ICQ.Bot.Types;

namespace ICQ.Bot.Args
{
    public class CallbackQueryEventArgs : EventArgs
    {
        public string CallbackData { get; }
        internal CallbackQueryEventArgs(Update update)
        {
            CallbackData = update.Payload.CallbackData;
        }

        internal CallbackQueryEventArgs(string callbackData)
        {
            CallbackData = callbackData;
        }

        public static implicit operator CallbackQueryEventArgs(UpdateEventArgs e) => new CallbackQueryEventArgs(e.Update);
    }
}
