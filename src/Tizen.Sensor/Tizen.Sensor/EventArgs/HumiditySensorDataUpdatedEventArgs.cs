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
    /// HumiditySensor changed event arguments. Class for storing the data returned by humidity sensor
    /// </summary>
    public class HumiditySensorDataUpdatedEventArgs : EventArgs
    {
        internal HumiditySensorDataUpdatedEventArgs(float humidity)
        {
            Humidity = humidity;
        }

        /// <summary>
        /// Gets the value of the humidity.
        /// </summary>
        public float Humidity { get; private set; }
    }
}