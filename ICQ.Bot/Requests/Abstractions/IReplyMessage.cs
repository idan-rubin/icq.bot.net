namespace ICQ.Bot.Requests.Abstractions
{
    public interface IReplyMessage
    {
        int ReplyToMessageId { get; set; }
    }
}
