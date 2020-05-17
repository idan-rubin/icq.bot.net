using ICQ.Bot.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Specialized;
using System.Net.Http;
using System.Web;

namespace ICQ.Bot.Requests
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class AnswerCallbackQueryRequest : RequestBase<ActionResponse>
    {
        [JsonProperty(Required = Required.Always)]
        public string QueryId { get; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Text { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool ShowAlert { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Url { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int CacheTime { get; set; }

        public AnswerCallbackQueryRequest(string callbackQueryId)
            : base("/messages/answerCallbackQuery", HttpMethod.Get)
        {
            QueryId = callbackQueryId;
        }

        public override NameValueCollection BuildParameters()
        {
            var result = new NameValueCollection
            {
                { "queryId", QueryId }
            };

            if (!string.IsNullOrWhiteSpace(Text))
            {
                result.Add("text", Text);
            }

            if (ShowAlert)
            {
                result.Add("showAlert", "true");
            }

            if (!string.IsNullOrWhiteSpace(Url))
            {
                result.Add("url", Url);
            }

            return result;
        }
    }
}
