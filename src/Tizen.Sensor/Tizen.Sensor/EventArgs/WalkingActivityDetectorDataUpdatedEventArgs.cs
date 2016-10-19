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
    /// WalkingActivityDetector changed event arguments. Class for storing the data returned by walking activity detector
    /// </summary>
    public class WalkingActivityDetectorDataUpdatedEventArgs : EventArgs
    {
        internal WalkingActivityDetectorDataUpdatedEventArgs(float state)
        {
            Walking = (DetectorState) state;
        }

        /// <summary>
        /// Gets the walking state.
        /// </summary>
        public DetectorState Walking { get; private set; }
    }
}
