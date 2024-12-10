using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tizen.AIAvatar.Samsung
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
