using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tizen.Applications
{
    public class AppControlEventArgs : EventArgs
    {
        public AppControl AppControl { get; internal set; }
    }
}
