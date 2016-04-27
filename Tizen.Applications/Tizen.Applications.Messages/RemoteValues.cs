// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

namespace Tizen.Applications.Messages
{
    /// <summary>
    /// Contains AppId, Port Name, Trusted
    /// </summary>
    public class RemoteValues
    {
        /// <summary>
        /// The ID of the remote application that sent this message
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// The name of the remote message port
        /// </summary>
        public string PortName { get; set; }

        /// <summary>
        /// If true the remote port is a trusted port, otherwise if false it is not
        /// </summary>
        public bool Trusted { get; set; }
    }
}
