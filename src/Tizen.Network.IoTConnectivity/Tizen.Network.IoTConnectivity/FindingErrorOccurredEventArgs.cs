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
    /// This class is an event arguments of the FindingErrorOccurred event.
    /// </summary>
    public class FindingErrorOccurredEventArgs : EventArgs
    {
        internal FindingErrorOccurredEventArgs() { }

        /// <summary>
        /// The request id of the operation which caused this error
        /// </summary>
        public int RequestId { get; internal set; }

        /// <summary>
        /// Contains error details.
        /// </summary>
        public Exception Error { get; internal set; }
    }
}
