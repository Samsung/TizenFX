using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tizen.Applications
{
    /// <summary>
    /// 
    /// </summary>
    public class AppControlReplyReceivedEventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public AppControl Request { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        public AppControl Reply { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        public AppControlLaunchResult Result { get; internal set; }
    }
}
