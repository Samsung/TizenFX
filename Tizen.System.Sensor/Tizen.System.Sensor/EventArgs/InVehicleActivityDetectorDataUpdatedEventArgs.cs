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
    /// InVehicleActivityDetector changed event arguments. Class for storing the data returned by in-vehicle activity detector
    /// </summary>
    public class InVehicleActivityDetectorDataUpdatedEventArgs : EventArgs
    {
        internal InVehicleActivityDetectorDataUpdatedEventArgs(float state)
        {
            InVehicle = (DetectorState) state;
        }

        /// <summary>
        /// Gets the in-vehicle state.
        /// </summary>
        public DetectorState InVehicle { get; private set; }
    }
}
