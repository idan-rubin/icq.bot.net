namespace ICQ.Bot.Requests.Abstractions
{
    public interface IReplyMessage
    {
        long ReplyToMessageId { get; set; }
    }
}
