using ICQ.Bot.Types.ReplyMarkups;

namespace ICQ.Bot.Requests.Abstractions
{
    public interface IReplyMarkupMessage<TMarkup>
        where TMarkup : IReplyMarkup
    {
        TMarkup ReplyMarkup { get; set; }
    }
}
