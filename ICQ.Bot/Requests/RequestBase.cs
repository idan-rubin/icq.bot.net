using ICQ.Bot.Requests.Abstractions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;

namespace ICQ.Bot.Requests
{
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public abstract class RequestBase<TResponse> : IRequest<TResponse>
    {
        [JsonIgnore]
        public HttpMethod Method { get; }

        [JsonIgnore]
        public string MethodName { get; protected set; }

        protected RequestBase(string methodName, HttpMethod method)
        {
            MethodName = methodName;
            Method = method;
        }

        public abstract NameValueCollection BuildParameters();

        public HttpContent ToHttpContent()
        {
            NameValueCollection parameters = BuildParameters();
            if (parameters == null || parameters.Count == 0)
            {
                return null;
            }

            string queryString = ToQueryString(parameters);
            HttpContent result = new StringContent(queryString, Encoding.UTF8);
            return result;
        }

        //https://stackoverflow.com/questions/829080/how-to-build-a-query-string-for-a-url-in-c
        private static string ToQueryString(NameValueCollection nvc)
        {
            var array = (
                from key in nvc.AllKeys
                from value in nvc.GetValues(key).Where(v => v != null)
                select string.Format(
            "{0}={1}",
            HttpUtility.UrlEncode(key),
            HttpUtility.UrlEncode(value))
                ).ToArray();

            return string.Join("&", array);
        }
    }
}
