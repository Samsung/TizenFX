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
    /// This class is an event arguments of the ObserverNotified event.
    /// </summary>
    public class ObserverNotifiedEventArgs : EventArgs
    {
        internal ObserverNotifiedEventArgs() { }

        /// <summary>
        /// Result of the observe response
        /// </summary>
        public ResponseCode Result { get; internal set; }

        /// <summary>
        /// Representation of the resource being observed.
        /// </summary>
        public Representation Representation { get; internal set; }
    }
}
