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
    /// FaceDownGestureDetector changed event arguments. Class for storing the data returned by face down gesture detector.
    /// </summary>
    public class FaceDownGestureDetectorDataUpdatedEventArgs : EventArgs
    {
        internal FaceDownGestureDetectorDataUpdatedEventArgs(float state)
        {
            FaceDown = (DetectorState) state;
        }

        /// <summary>
        /// Gets the face down state.
        /// </summary>
        public DetectorState FaceDown { get; private set; }
    }
}
