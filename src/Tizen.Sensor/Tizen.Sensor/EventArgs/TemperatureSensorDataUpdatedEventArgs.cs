// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). Pitchou
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;

namespace Tizen.Sensor
{
    /// <summary>
    /// TemperatureSensor changed event arguments. Class for storing the data returned by temperature sensor
    /// </summary>
    public class TemperatureSensorDataUpdatedEventArgs : EventArgs
    {
        internal TemperatureSensorDataUpdatedEventArgs(float temperature)
        {
            Temperature = temperature;
        }

        /// <summary>
        /// Gets the value of the temperature.
        /// </summary>
        public float Temperature { get; private set; }
    }
}