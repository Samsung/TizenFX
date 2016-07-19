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
    /// This class represents remote response.
    /// </summary>
    public class RemoteResponse
    {
        /// <summary>
        /// Indicates the result of the response
        /// </summary>
        public ResponseCode Result { get; internal set; }

        /// <summary>
        /// Indicates representation of the response
        /// </summary>
        public Representation Representation { get; internal set; }

        /// <summary>
        /// Indicates header options of the response
        /// </summary>
        public ResourceOptions Options { get; internal set; }
    }
}
