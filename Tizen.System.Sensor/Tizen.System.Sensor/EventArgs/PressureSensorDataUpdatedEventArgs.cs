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
    /// PressureSensor changed event arguments. Class for storing the data returned by pressure sensor
    /// </summary>
    public class PressureSensorDataUpdatedEventArgs : EventArgs
    {
        internal PressureSensorDataUpdatedEventArgs(float pressure)
        {
            Pressure = pressure;
        }

        /// <summary>
        /// Gets the value of the pressure.
        /// </summary>
        public float Pressure { get; private set; }
    }
}