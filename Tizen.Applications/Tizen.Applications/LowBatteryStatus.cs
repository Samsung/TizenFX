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
    /// Enumeration for low battery status.
    /// </summary>
    public enum LowBatteryStatus
    {
        /// <summary>
        /// 
        /// </summary>
        None = 0,

        /// <summary>
        /// The battery status is under 1%
        /// </summary>
        PowerOff = 1,

        /// <summary>
        /// The battery status is under 5%
        /// </summary>
        CriticalLow
    }
}
