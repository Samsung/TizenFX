using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tizen.Applications.Messages
{
    /// <summary>
    /// Contains AppId, Port Name, Trusted
    /// </summary>
    public struct RemoteValues
    {
        /// <summary>
        /// The ID of the remote application that sent this message
        /// </summary>
        public string AppId;
        /// <summary>
        /// The name of the remote message port
        /// </summary>
        public string PortName;
        /// <summary>
        /// If true the remote port is a trusted port, otherwise if false it is not
        /// </summary>
        public bool Trusted;
    }
}
