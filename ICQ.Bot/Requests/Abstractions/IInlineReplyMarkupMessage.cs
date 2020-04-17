using ICQ.Bot.Types.ReplyMarkups;

namespace ICQ.Bot.Requests.Abstractions
{
    public interface IInlineReplyMarkupMessage : IReplyMarkupMessage<InlineKeyboardMarkup>
    {
        new InlineKeyboardMarkup ReplyMarkup { get; set; }
    }
}
