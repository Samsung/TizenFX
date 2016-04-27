// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;

namespace Tizen.Applications.Messages
{
    /// <summary>
    /// An extended EventArgs class which contains remote message port information and message
    /// </summary>
    public class MessageReceivedEventArgs : EventArgs
    {
        /// <summary>
        /// Contains AppId, Port Name, Trusted
        /// </summary>
        public RemoteValues Remote { get; internal set; }

        /// <summary>
        /// The message passed from the remote application
        /// </summary>
        public Bundle Message { get; internal set; }
    }
}
