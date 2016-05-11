/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.

namespace Tizen.Network.IoTConnectivity
{
    /// <summary>
    /// Observe type.
    /// </summary>
    public enum ObserveType
    {
        /// <summary>
        /// No observe action
        /// </summary>
        NoType = 0,

        /// <summary>
        /// Indicates action of registering observation
        /// </summary>
        Register = 1,

        /// <summary>
        /// Indicates action of unregistering observation
        /// </summary>
        Deregister = 2,
    }
}

