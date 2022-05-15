using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


namespace ICQ.Bot.Types
{
    /// <summary>
    /// File object abstraction 
    /// </summary>
    /// <example>
    /// <code>
    /// {"filename": "Аттестат (из ЕАИСТО).jpg", 
    /// "size": 164242, "type": "image", 
    /// "url": "https://ub.icq.net/files/get/0ggaN0004SY5hwvsKsZYrTrmDrTxEnrj9hlc1Ess1jUyAhzLNDBx5mV7qhrKFdAxP4fL6xy0o1Vs717wasTFBuXKTdExEKkL5rpKvoDzLK6dH63s8NjU0xTR4vYKYnJYEgkyNG4KBbupdxgZHC7xhfDwtx4AYrTx/%D0%90%D1%82%D1%82%D0%B5%D1%81%D1%82%D0%B0%D1%82%20%28%D0%B8%D0%B7%20%D0%95%D0%90%D0%98%D0%A1%D0%A2%D0%9E%29.jpg", 
    /// "ok": true}
    /// </code>
    /// </example>
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class File : FileBase
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Type { get; set; }

        /// <summary>
        /// String representation of the base class <see cref="FileBase.FileSize"/> property
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Size 
        {
            get => base.FileSize.ToString();
            set
            {
                int res = 0;
                base.FileSize = int.TryParse(value, out res) ? res : 0;
            } 
        }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string FileName { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Url { get; set; }
    }
}
