using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ICQ.Bot.Types
{
    /// <summary>
    /// File object abstraction 
    /// </summary>
    /// <example>
    /// <code>
    /// {"filename": "Новый прейскурант - Scan ГАЗПРОМ[13582].pdf", "size": 362738, "type": "application", 
    /// "url": "https://ub.icq.net/files/get/dFhlO9tuqZ3YMxyHLwrsuoNwrs8Pqh6xq5Cv5ge3Z8Cx6rszAhty6CHKRQipwgWFyVuKVcncSKZHKcBKFgEGLgDwa6Fh5fV0IhYXIa9hpPTs3sMjTyJKXv4EUgxK7NQhTbdJlKtjdZcKTLokng41S8rh8MLwrs/%D0%9D%D0%BE%D0%B2%D1%8B%D0%B9%20%D0%BF%D1%80%D0%B5%D0%B9%D1%81%D0%BA%D1%83%D1%80%D0%B0%D0%BD%D1%82%20-%20Scan%20%D0%93%D0%90%D0%97%D0%9F%D0%A0%D0%9E%D0%9C%5B13582%5D.pdf", 
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
