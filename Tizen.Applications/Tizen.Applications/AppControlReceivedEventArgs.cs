// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;

namespace Tizen.Applications
{
    /// <summary>
    /// Arguments for the event that raised when the application receives the AppControl.
    /// </summary>
    public class AppControlReceivedEventArgs : EventArgs
    {
        /// <summary>
        /// The received AppControl.
        /// </summary>
        public ReceivedAppControl ReceivedAppControl { get; internal set; }
    }
}
