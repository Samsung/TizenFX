// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). Pitchou
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;

namespace Tizen.Sensor
{
    /// <summary>
    /// HeartRateMonitor changed event arguments. Class for storing the data returned by heart rate monitor
    /// </summary>
    public class HeartRateMonitorDataUpdatedEventArgs : EventArgs
    {
        internal HeartRateMonitorDataUpdatedEventArgs(int heartRate)
        {
            HeartRate = heartRate;
        }

        /// <summary>
        /// Gets the value of the heartRate.
        /// </summary>
        public int HeartRate { get; private set; }
    }
}