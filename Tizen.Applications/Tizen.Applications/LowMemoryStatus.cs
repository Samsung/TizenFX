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
    /// Enumeration for low memory status.
    /// </summary>
    public enum LowMemoryStatus
    {
        /// <summary>
        /// Normal status
        /// </summary>
        Normal = 0x01,

        /// <summary>
        /// Soft warning status
        /// </summary>
        SoftWarning = 0x02,

        /// <summary>
        /// Hard warning status
        /// </summary>
        HardWarning = 0x04,
    }
}
