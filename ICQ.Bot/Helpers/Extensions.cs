using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace ICQ.Bot.Helpers
{
    public static class Extensions
    {
        internal static string EncodeUtf8(this string value) =>
            string.Join(string.Empty, Encoding.UTF8.GetBytes(value).Select(Convert.ToChar));

        internal static void AddStreamContent(
            this MultipartFormDataContent multipartContent,
            Stream content,
            string name,
            string fileName = default)
        {
            string contentDisposition = $@"form-data; name=""{name}""";
            if (!string.IsNullOrWhiteSpace(fileName))
            {
                contentDisposition = $@"{contentDisposition}; fileName=""{fileName}""";
            }

            HttpContent mediaPartContent = new StreamContent(content)
            {
                Headers =
                {
                    {"Content-Type", "application/octet-stream"},
                    {"Content-Disposition", contentDisposition}
                }
            };

            multipartContent.Add(mediaPartContent, name);
        }
    }
}
