using Newtonsoft.Json;
using ICQ.Bot.Converters;
using System.Web;

namespace ICQ.Bot.Types
{
    [JsonConverter(typeof(ChatIdConverter))]
    public class ChatId
    {
        public readonly long Identifier;
        public readonly string Username;

        public ChatId(long identifier)
        {
            Identifier = identifier;
        }

        public ChatId(int chatId)
        {
            Identifier = chatId;
        }

        public ChatId(string username)
        {
            if (!string.IsNullOrWhiteSpace(username))
            {
                Username = username;
            }
            else if (int.TryParse(username, out int chatId))
            {
                Identifier = chatId;
            }
            else if (long.TryParse(username, out long identifier))
            {
                Identifier = identifier;
            }

            if (!string.IsNullOrWhiteSpace(Username))
            {
                Username = HttpUtility.UrlEncode(Username);
            }
        }

        public override bool Equals(object obj) => ((string)this).Equals(obj);
        public override int GetHashCode() => ((string)this).GetHashCode();
        public override string ToString() => this;
        public static implicit operator ChatId(long identifier) => new ChatId(identifier);
        public static implicit operator ChatId(int chatId) => new ChatId(chatId);
        public static implicit operator ChatId(string username) => new ChatId(username);
        public static implicit operator string(ChatId chatid) => chatid.Username ?? chatid.Identifier.ToString();
        public static implicit operator ChatId(Chat chat) =>  chat.ChatId;
    }
}