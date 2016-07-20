/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.

using System;

namespace Tizen.Network.IoTConnectivity
{
    /// <summary>
    /// This class is an event arguments of the PresenceReceived event.
    /// </summary>
    public class PresenceReceivedEventArgs : EventArgs
    {
        internal PresenceReceivedEventArgs() { }

        /// <summary>
        /// Indicates request id of presence event.
        /// </summary>
        public int PresenceId { get; internal set; }

        /// <summary>
        /// Indicates event type
        /// </summary>
        public PresenceEventType EventType { get; internal set; }

        /// <summary>
        /// Indicates host address of resource
        /// </summary>
        public string HostAddress { get; internal set; }

        /// <summary>
        /// Indicates type of the resource
        /// </summary>
        public string Type { get; internal set; }
    }
}
