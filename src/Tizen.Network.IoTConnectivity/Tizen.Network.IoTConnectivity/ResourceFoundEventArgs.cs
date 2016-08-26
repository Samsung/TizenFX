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
    /// This class is an event arguments of the ResourceFound event.
    /// </summary>
    public class ResourceFoundEventArgs : EventArgs
    {
        internal ResourceFoundEventArgs() { }

        /// <summary>
        /// Indicates the request id.
        /// This is the same request id returned by the <see cref="IoTConnectivityClientManager.StartFindingResource()"/> API.
        /// </summary>
        public int RequestId { get; internal set; }

        /// <summary>
        /// Remote resource which is found after <see cref="IoTConnectivityClientManager.StartFindingResource()"/>.
        /// </summary>
        /// <seealso cref="IoTConnectivityClientManager.ResourceFound"/>
        /// <seealso cref="IoTConnectivityClientManager.StartFindingResource()"/>
        public RemoteResource Resource { get; internal set; }
    }
}
