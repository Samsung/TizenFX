using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tizen.Applications
{
    public class AppControlReceivedEventArgs
    {
        public AppControlReceivedEventArgs(ReceivedAppControl control)
        {
            ReceivedAppControl = control;
        }

        public ReceivedAppControl ReceivedAppControl { get; private set; }
    }
}
