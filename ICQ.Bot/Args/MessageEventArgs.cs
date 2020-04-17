using ICQ.Bot.Types;
using System;

namespace ICQ.Bot.Args
{
    public class MessageEventArgs : EventArgs
    {
        public Message Message { get; private set; }
        internal MessageEventArgs(Update update)
        {
            Message = update.Payload;
        }

        internal MessageEventArgs(Message message)
        {
            Message = message;
        }

        public static implicit operator MessageEventArgs(UpdateEventArgs e) => new MessageEventArgs(e.Update);
    }
}
