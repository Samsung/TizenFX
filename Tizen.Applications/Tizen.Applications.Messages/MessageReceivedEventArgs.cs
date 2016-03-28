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
        private RemoteValues _remote;
        private Bundle _message;

        /// <summary>
        /// Constructor
        /// </summary>
        public MessageReceivedEventArgs(Bundle message, string appId, string portName, bool trusted)
        {
            _message = message;

            _remote = new RemoteValues();
            _remote.AppId = appId;
            _remote.PortName = portName;
            _remote.Trusted = trusted;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public MessageReceivedEventArgs(Bundle message)
        {
            _message = message;
        }

        /// <summary>
        /// Contains AppId, Port Name, Trusted
        /// </summary>
        public RemoteValues Remote
        {
            get
            {
                return _remote;
            }
        }

        /// <summary>
        /// The message passed from the remote application
        /// </summary>
        public Bundle Message
        {
            get
            {
                return _message;
            }
        }
    }
}
