using ICQ.Bot.Types;
using System;
using System.Linq;

namespace ICQ.Bot.Args
{
    public class MessageEventArgs : EventArgs
    {
        public Message Message { get; private set; }
        internal MessageEventArgs(Update update)
        {
            if (update.Payload != null)
            {
                Message = new Message
                {
                    Text = update.Payload.Text,
                    From = update.Payload.From,
                    MsgId = update.Payload.MsgId,
                    Chat = update.Payload.Chat,
                    Timestamp = update.Payload.Timestamp
                };

                if (update.Payload.Parts != null && update.Payload.Parts.Count() != 0)
                {
                    var part = update.Payload.Parts.ToList()[0];
                    if (part.Payload != null)
                    {
                        Message.Caption = part.Payload.Caption;
                        Message.FileId = part.Payload.FileId;
                        Message.FileType = part.Payload.Type;
                    }
                }
            }
        }

        internal MessageEventArgs(Message message)
        {
            Message = message;
        }

        public static implicit operator MessageEventArgs(UpdateEventArgs e) => new MessageEventArgs(e.Update);
    }
}
