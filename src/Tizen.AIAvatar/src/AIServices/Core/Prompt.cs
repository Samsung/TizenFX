using System.Collections.Generic;

namespace Tizen.AIAvatar
{
    internal class Message
    {
        internal string role { get; set; }
        internal string content { get; set; }
    }

    internal class Prompt
    {
        internal string model { get; set; }
        internal List<Message> messages { get; set; }
        internal double temperature { get; set; }
    }
}
