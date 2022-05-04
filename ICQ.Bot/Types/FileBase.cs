using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ICQ.Bot.Types
{
    /// <summary>
    /// File info wrapper base
    /// </summary>
    /// <remarks>
    /// All parameters marked as Json Optional cause there are no such parameters in Json Payload 
    /// <see cref="File"/>, (see API reference: <seealso cref="https://agent.mail.ru/botapi/?lang=en#/files/get_files_getInfo"/>)
    /// </remarks>
    [JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public abstract class FileBase
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string FileId { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string FileUniqueId { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]        
        public int FileSize { get; set; }
    }
}
