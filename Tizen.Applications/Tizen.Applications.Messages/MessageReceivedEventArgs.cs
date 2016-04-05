using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tizen.Applications.Messages
{
    /// <summary>
    /// An extended EventArgs class which contains remote message port information and message
    /// </summary>
    public class MessageReceivedEventArgs : EventArgs
    {
        /// <summary>
        /// Contains AppId, Port Name, Trusted
        /// </summary>
        public RemoteValues Remote
        {
            get;
            internal set;
        }

        /// <summary>
        /// The message passed from the remote application
        /// </summary>
        public Bundle Message
        {
            get;
            internal set;
        }
    }
}
