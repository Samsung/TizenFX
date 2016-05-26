// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). Pitchou
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;

namespace Tizen.System.Sensor
{
    /// <summary>
    /// OrientationSensor changed event arguments. Class for storing the data returned by orientation sensor
    /// </summary>
    public class OrientationSensorDataUpdatedEventArgs : EventArgs
    {
        internal OrientationSensorDataUpdatedEventArgs(float[] values)
        {
            Azimuth = values[0];
            Pitch = values[1];
            Roll = values[2];
        }

        /// <summary>
        /// Gets the azimuth component of the orientation.
        /// </summary>
        public float Azimuth { get; private set; }

        /// <summary>
        /// Gets the pitch component of the orientation.
        /// </summary>
        public float Pitch { get; private set; }

        /// <summary>
        /// Gets the roll component of the orientation.
        /// </summary>
        public float Roll { get; private set; }
    }
}