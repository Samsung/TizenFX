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
    /// LightSensor changed event arguments. Class for storing the data returned by light sensor
    /// </summary>
    public class LightSensorDataUpdatedEventArgs : EventArgs
    {
        internal LightSensorDataUpdatedEventArgs(float level)
        {
            Level = level;
        }

        /// <summary>
        /// Gets the level of the light.
        /// </summary>
        public float Level { get; private set; }
    }
}