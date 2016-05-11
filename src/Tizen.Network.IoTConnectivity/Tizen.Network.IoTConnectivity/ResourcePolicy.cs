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
    /// Enumeration for policy which can be held in a resource.
    /// </summary>
    [Flags]
    public enum ResourcePolicy
    {
        /// <summary>
        /// Indicates resource uninitialized
        /// </summary>
        NoProperty = 0,
        /// <summary>
        /// Indicates resource that is allowed to be discovered
        /// </summary>
        Discoverable = (1 << 0),
        /// <summary>
        /// Indicates resource that is allowed to be observed
        /// </summary>
        Observable = (1 << 1),
        /// <summary>
        /// Indicates resource initialized and activated
        /// </summary>
        Active = (1 << 2),
        /// <summary>
        /// Indicates resource which takes some delay to respond
        /// </summary>
        Slow = (1 << 3),
        /// <summary>
        /// Indicates secure resource
        /// </summary>
        Secure = (1 << 4),
        /// <summary>
        /// When this bit is set, the resource is allowed to be discovered only if discovery request contains an explicit querystring.
        /// </summary>
        ExplicitDiscoverable = (1 << 5),
    }
}
