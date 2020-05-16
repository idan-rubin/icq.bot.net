using System;
using ICQ.Bot.Types;

namespace ICQ.Bot.Args
{
    public class CallbackQueryEventArgs : EventArgs
    {
        public string CallbackData { get; }
        public string QueryId { get; }
        public Message Message { get; }
        public string Text { get; }
        public User From { get; }
        public Chat Chat { get; }
        internal CallbackQueryEventArgs(Update update)
        {
            CallbackData = update.Payload.CallbackData;
            QueryId = update.Payload.QueryId;
            Message = update.Payload.Message;
            From = update.Payload.From;
            Chat = update.Payload.Chat;
            Text = update.Payload.Text;
        }

        public static implicit operator CallbackQueryEventArgs(UpdateEventArgs e) => new CallbackQueryEventArgs(e.Update);
    }
}
