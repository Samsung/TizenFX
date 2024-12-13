using System.Collections.Generic;

namespace Tizen.AIAvatar
{
    internal class Message
    {
        public string role { get; set; }
        public string content { get; set; }
    }

    internal class Prompt
    {
        public string model { get; set; }
        public List<Message> messages { get; set; }
        public double temperature { get; set; }
        public int seed { get; set; }
    }
}
