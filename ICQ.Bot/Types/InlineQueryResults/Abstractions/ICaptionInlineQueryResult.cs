using ICQ.Bot.Types.Enums;

namespace ICQ.Bot.Types.InlineQueryResults.Abstractions
{
    /// <summary>
    /// Represents an inline query result with caption
    /// </summary>
    public interface ICaptionInlineQueryResult
    {
        /// <summary>
        /// Optional. Caption of the result to be sent, 0-1024 characters.
        /// </summary>
        string Caption { get; set; }

        /// <summary>
        /// Optional. Future use.
        /// </summary>
        ParseMode ParseMode { get; set; }
    }
}
