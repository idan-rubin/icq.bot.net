namespace ICQ.Bot.Exceptions
{
    public class InvalidStickerSetNameException : InvalidParameterException
    {
        public InvalidStickerSetNameException(string message)
            : base("name", message)
        {
        }
    }
}