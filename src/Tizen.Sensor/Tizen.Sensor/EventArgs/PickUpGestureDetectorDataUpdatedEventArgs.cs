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
    /// PickUpGestureDetector changed event arguments. Class for storing the data returned by pick up gesture detector
    /// </summary>
    public class PickUpGestureDetectorDataUpdatedEventArgs : EventArgs
    {
        internal PickUpGestureDetectorDataUpdatedEventArgs(float state)
        {
            PickUp = (DetectorState) state;
        }

        /// <summary>
        /// Gets the pick up state.
        /// </summary>
        public DetectorState PickUp { get; private set; }
    }
}
