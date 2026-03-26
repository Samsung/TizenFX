using System.Collections.Generic;

namespace Tizen.AIAvatar
{
    internal sealed class Message
    {
        public string role { get; set; }
        public string content { get; set; }
    }

    internal sealed class Prompt
    {
        public string model { get; set; }
        public List<Message> messages { get; set; }
        public double temperature { get; set; }
        public int seed { get; set; }
    }
}
