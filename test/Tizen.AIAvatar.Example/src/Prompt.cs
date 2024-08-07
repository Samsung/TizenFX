uing System.Collections.Generic;

namespace AIAvatar
{
    public class Message
    {
        public string role { get; set; }
        public string content { get; set; }
    }

    public class Prompt
    {
        public string model { get; set; }
        public List<Message> messages { get; set; }
        public double temperature { get; set; }
    }
}
