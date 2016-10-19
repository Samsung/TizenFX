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
    /// SleepMonitor changed event arguments. Class for storing the data returned by sleep monitor
    /// </summary>
    public class SleepMonitorDataUpdatedEventArgs : EventArgs
    {
        internal SleepMonitorDataUpdatedEventArgs(int sleepState)
        {
            SleepState = (SleepMonitorState) sleepState;
        }

        /// <summary>
        /// Gets the value of the sleep state.
        /// </summary>
        public SleepMonitorState SleepState { get; private set; }
    }
}