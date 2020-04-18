using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using ICQ.Bot.Types;
using System.Net.Http;

namespace ICQ.Bot.Requests
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class KickChatMemberRequest : RequestBase<ActionResponse>
    {
        [JsonProperty(Required = Required.Always)]
        public ChatId ChatId { get; }

        [JsonProperty(Required = Required.Always)]
        public int UserId { get; }

        [JsonConverter(typeof(UnixDateTimeConverter))]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime UntilDate { get; set; }

        public KickChatMemberRequest(ChatId chatId, int userId)
            : base("/chats/blockUser", HttpMethod.Get)
        {
            ChatId = chatId;
            UserId = userId;

            QueryString = string.Format("?chatId={0}&userId={1}", ChatId, UserId);
        }
    }
}
