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
        /// PresenceId property.
        /// </summary>
        /// <returns>int PresenceId.</returns>
        public int PresenceId { get; internal set; }

        /// <summary>
        /// EventType property.
        /// </summary>
        /// <returns>PresenceEventType EventType.</returns>
        public PresenceEventType EventType { get; internal set; }

        /// <summary>
        /// HostAddress property.
        /// </summary>
        /// <returns>string HostAddress.</returns>
        public string HostAddress { get; internal set; }

        /// <summary>
        /// Type property.
        /// </summary>
        /// <returns>string Type.</returns>
        public string Type { get; internal set; }
    }
}
