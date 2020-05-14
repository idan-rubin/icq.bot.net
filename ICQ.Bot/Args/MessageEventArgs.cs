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

                if (update.Payload.Message != null)
                {
                    Message.Caption = update.Payload.Message.Caption;
                    Message.FileId = update.Payload.Message.FileId;
                    Message.FileType = update.Payload.Message.FileType;
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
