using ICQ.Bot.Types.Enums;

namespace ICQ.Bot.Types
{
    public interface IInputMedia
    {
        string Type { get; }
        InputMedia Media { get; }
        string Caption { get; }
        ParseMode ParseMode { get; }
    }
}
