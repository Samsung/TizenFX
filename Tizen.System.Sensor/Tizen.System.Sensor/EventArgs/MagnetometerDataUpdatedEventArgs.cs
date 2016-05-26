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
    /// Magnetometer changed event arguments. Class for storing the data returned by magnetometer sensor
    /// </summary>
    public class MagnetometerDataUpdatedEventArgs : EventArgs
    {
        internal MagnetometerDataUpdatedEventArgs(float[] values)
        {
            X = values[0];
            Y = values[1];
            Z = values[2];
        }

        /// <summary>
        /// Gets the X component of the magnetometer.
        /// </summary>
        public float X { get; private set; }

        /// <summary>
        /// Gets the Y component of the magnetometer.
        /// </summary>
        public float Y { get; private set; }

        /// <summary>
        /// Gets the Z component of the magnetometer.
        /// </summary>
        public float Z { get; private set; }
    }
}