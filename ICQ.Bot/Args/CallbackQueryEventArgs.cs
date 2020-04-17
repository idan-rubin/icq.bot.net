using System;
using ICQ.Bot.Types;

namespace ICQ.Bot.Args
{
    public class CallbackQueryEventArgs : EventArgs
    {
        public string CallbackQuery { get; }
        internal CallbackQueryEventArgs(Update update)
        {
            CallbackQuery = update.CallbackQuery;
        }

        internal CallbackQueryEventArgs(string callbackQuery)
        {
            CallbackQuery = callbackQuery;
        }

        public static implicit operator CallbackQueryEventArgs(UpdateEventArgs e) => new CallbackQueryEventArgs(e.Update);
    }
}
