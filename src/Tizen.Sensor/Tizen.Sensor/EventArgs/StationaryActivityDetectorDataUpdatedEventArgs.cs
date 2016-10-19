// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;

namespace Tizen.Sensor
{
    /// <summary>
    /// StationaryActivityDetector changed event arguments. Class for storing the data returned by stationary activity detector
    /// </summary>
    public class StationaryActivityDetectorDataUpdatedEventArgs : EventArgs
    {
        internal StationaryActivityDetectorDataUpdatedEventArgs(float state)
        {
            Stationary = (DetectorState) state;
        }

        /// <summary>
        /// Gets the stationary state.
        /// </summary>
        public DetectorState Stationary { get; private set; }
    }
}
