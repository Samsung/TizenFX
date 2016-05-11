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
    /// ResourceFoundEventArgs class. This class is an event arguments of the ResourceFound event.
    /// </summary>
    public class ResourceFoundEventArgs : EventArgs
    {
        /// <summary>
        /// RequestId property.
        /// </summary>
        /// <returns>int RequestId.</returns>
        public int RequestId { get; internal set; }

        /// <summary>
        /// Resource property.
        /// </summary>
        /// <returns>RemoteResource Resource.</returns>
        public RemoteResource Resource { get; internal set; }
    }
}
