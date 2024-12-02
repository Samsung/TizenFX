using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tizen.AIAvatar.Samsung
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
    }
}
