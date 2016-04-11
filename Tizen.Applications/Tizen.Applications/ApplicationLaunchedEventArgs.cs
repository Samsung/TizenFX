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
    /// Arguments for the event that is raised when the application is launched.
    /// </summary>
    public class ApplicationLaunchedEventArgs : EventArgs
    {
        /// <summary>
        /// The information of the application.
        /// </summary>
        public ApplicationInfo ApplicationInfo { get; internal set; }        
    }
}

