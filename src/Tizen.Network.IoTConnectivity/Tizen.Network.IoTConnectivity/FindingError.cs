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
    /// Enumeration for resource found errors
    /// </summary>
    internal enum FindingError
    {
        /// <summary>
        /// I/O error
        /// </summary>
        Io = 1,
        /// <summary>
        /// Out of memory
        /// </summary>
        OutOfMemory,
        /// <summary>
        /// Permission denied
        /// </summary>
        PermissionDenied,
        /// <summary>
        /// Not supported
        /// </summary>
        NotSupported,
        /// <summary>
        /// Invalid parameter
        /// </summary>
        InvalidParameter,
        /// <summary>
        /// No data available
        /// </summary>
        NoData,
        /// <summary>
        /// Time out
        /// </summary>
        TimeOut,
        /// <summary>
        /// IoTivity errors
        /// </summary>
        Iotivity,
        /// <summary>
        /// Representation errors
        /// </summary>
        Representation,
        /// <summary>
        /// Invalid type
        /// </summary>
        InvalidType,
        /// <summary>
        /// Already
        /// </summary>
        Already,
        /// <summary>
        /// System errors
        /// </summary>
        System
    }
}
