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
    /// Enumeration for result of response
    /// </summary>
    public enum ResponseCode
    {
        /// <summary>
        /// Indicates result of response for success
        /// </summary>
        Ok = 0,
        /// <summary>
        /// Indicates result of response for some error
        /// </summary>
        Error,
        /// <summary>
        /// Indicates result of response for created resource
        /// </summary>
        Created,
        /// <summary>
        ///  Indicates result of response for deleted resource
        /// </summary>
        Deleted,
        /// <summary>
        /// Indicates result of response for slow resource
        /// </summary>
        Slow,
        /// <summary>
        /// Indicates result of response for accessing unauthorized resource
        /// </summary>
        Forbidden
    }
}
