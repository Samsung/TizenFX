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
    /// This class is an event arguments of the CacheUpdated event.
    /// </summary>
    public class CacheUpdatedEventArgs : EventArgs
    {
        internal CacheUpdatedEventArgs() { }

        /// <summary>
        /// Indicates the updated representation of the resource
        /// </summary>
        public Representation Representation { get; internal set; }
    }
}
