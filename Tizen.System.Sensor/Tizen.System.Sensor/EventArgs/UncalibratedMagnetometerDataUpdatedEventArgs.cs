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
    /// UncalibratedMagnetometer changed event arguments. Class for storing the data returned by uncalibrated magnetometer
    /// </summary>
    public class UncalibratedMagnetometerDataUpdatedEventArgs : EventArgs
    {
        internal UncalibratedMagnetometerDataUpdatedEventArgs(float[] values)
        {
            X = values[0];
            Y = values[1];
            Z = values[2];
            BiasX = values[3];
            BiasY = values[4];
            BiasZ = values[5];
        }

        /// <summary>
        /// Gets the X component of the uncalibrated magnetometer data.
        /// </summary>
        public float X { get; private set; }

        /// <summary>
        /// Gets the Y component of the uncalibrated magnetometer data.
        /// </summary>
        public float Y { get; private set; }

        /// <summary>
        /// Gets the Z component of the uncalibrated magnetometer data.
        /// </summary>
        public float Z { get; private set; }

        /// <summary>
        /// Gets the BiasX component of the uncalibrated magnetometer data.
        /// </summary>
        public float BiasX { get; private set; }

        /// <summary>
        /// Gets the BiasY component of the uncalibrated magnetometer data.
        /// </summary>
        public float BiasY { get; private set; }

        /// <summary>
        /// Gets the BiasZ component of the uncalibrated magnetometer data.
        /// </summary>
        public float BiasZ { get; private set; }
    }
}