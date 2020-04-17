using System;
using ICQ.Bot.Types;

namespace ICQ.Bot.Args
{
    public class UpdateEventArgs : EventArgs
    {
        public Update Update { get; private set; }

        internal UpdateEventArgs(Update update)
        {
            Update = update;
        }
    }
}