using System;

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
        public RemoteValues Remote { get; internal set; }

        /// <summary>
        /// The message passed from the remote application
        /// </summary>
        public Bundle Message { get; internal set; }
    }
}
