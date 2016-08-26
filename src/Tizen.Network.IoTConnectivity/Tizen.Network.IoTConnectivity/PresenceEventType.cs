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
    /// Enumeration for operation of presence response.
    /// </summary>
    public enum PresenceEventType
    {
        /// <summary>
        /// Indicates for resource creation operation of server
        /// </summary>
        ResourceCreated = 0,
        /// <summary>
        /// Indicates for resource updation operation of server
        /// </summary>
        ResourceUpdated,
        /// <summary>
        /// Indicates for resource destruction operation of server
        /// </summary>
        ResourceDestroyed
    }
}
