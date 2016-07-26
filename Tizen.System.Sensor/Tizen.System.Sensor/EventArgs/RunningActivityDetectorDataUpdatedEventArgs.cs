// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;

namespace Tizen.System.Sensor
{
    /// <summary>
    /// RunningActivityDetector changed event arguments. Class for storing the data returned by running activity detector
    /// </summary>
    public class RunningActivityDetectorDataUpdatedEventArgs : EventArgs
    {
        internal RunningActivityDetectorDataUpdatedEventArgs(float state)
        {
            Running = (DetectorState) state;
        }

        /// <summary>
        /// Gets the running state.
        /// </summary>
        public DetectorState Running { get; private set; }
    }
}
