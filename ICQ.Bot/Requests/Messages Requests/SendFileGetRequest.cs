using ICQ.Bot.Exceptions;
using ICQ.Bot.Requests.Abstractions;
using ICQ.Bot.Types;
using ICQ.Bot.Types.InputFiles;
using ICQ.Bot.Types.ReplyMarkups;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http;
using System.Text;

namespace ICQ.Bot.Requests
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class SendFileGetRequest : FileRequestBase<MessagesResponse>,
                                       INotifiableMessage,
                                       IReplyMessage,
                                       IReplyMarkupMessage<IReplyMarkup>
    {
        public SendFileGetRequest(ChatId chatId, InputOnlineFile document)
            : base("/messages/sendFile", HttpMethod.Get)
        {
            ChatId = chatId;
            Document = document;
        }

        public override HttpContent ToHttpContent()
        {
            if (Document == null || string.IsNullOrWhiteSpace(Document.FileId))
            {
                throw new FileIdNotFoundException();
            }

            string queryString = string.Format("chatId={0}&fileId={1}", ChatId, Document.FileId);
            if (!string.IsNullOrWhiteSpace(Caption))
            {
                queryString = string.Format("{0}&caption={1}", queryString, Caption);
            }

            if (ReplyMarkup != null)
            {
                string markup = JsonConvert.SerializeObject(ReplyMarkup);
                queryString = string.Format("{0}&inlineKeyboardMarkup={1}", queryString, markup);
            }

            return new StringContent(queryString, Encoding.UTF8);
        }
    }
}
