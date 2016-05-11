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
    /// FoundErrorEventArgs class. This class is an event arguments of the FoundError event.
    /// </summary>
    public class FindingErrorOccurredEventArgs : EventArgs
    {
        /// <summary>
        /// RequestId property.
        /// </summary>
        /// <returns>int RequestId.</returns>
        public int RequestId { get; internal set; }

        /// <summary>
        /// Result property.
        /// </summary>
        /// <returns>FindingError Result.</returns>
        public Exception Error { get; internal set; }
    }
}
