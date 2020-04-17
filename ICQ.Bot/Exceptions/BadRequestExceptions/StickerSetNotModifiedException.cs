namespace ICQ.Bot.Exceptions
{
    public class StickerSetNotModifiedException : BadRequestException
    {
        public StickerSetNotModifiedException(string message)
            : base(message)
        {
        }
    }
}