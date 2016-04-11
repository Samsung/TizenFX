// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

namespace Tizen.Applications
{
    /// <summary>
    /// Enumeration for App Control Result.
    /// </summary>
    public enum AppControlReplyResult
    {
        /// <summary>
        /// Operation is succeeded
        /// </summary>
        Succeeded = 0,

        /// <summary>
        /// Operation is failed by the callee
        /// </summary>
        Failed = -1,

        /// <summary>
        /// Operation is canceled by the platform
        /// </summary>
        Canceled = -2,
    }
}
