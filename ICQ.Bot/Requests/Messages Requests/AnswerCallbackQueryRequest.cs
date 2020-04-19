using ICQ.Bot.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http;
using System.Text;
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

        public AnswerCallbackQueryRequest(string callbackQueryId, string text, bool showAlert, string url)
            : base("/messages/answerCallbackQuery", HttpMethod.Get)
        {
            QueryId = callbackQueryId;
            Text = text;
            ShowAlert = showAlert;
            Url = url;
        }

        public override HttpContent ToHttpContent()
        {
            string queryString = string.Format("queryId={0}&text={1}", QueryId, Text);
            if (ShowAlert)
            {
                queryString = string.Format("{0}&showAlert=true", queryString);
            }

            if (!string.IsNullOrWhiteSpace(Url))
            {
                Url = HttpUtility.UrlEncode(Url);
                queryString = string.Format("{0}&url={1}", queryString, Url);
            }

            return new StringContent(queryString, Encoding.UTF8);
        }
    }
}
