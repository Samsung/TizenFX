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
    /// UltravioletSensor changed event arguments. Class for storing the data returned by ultraviolet sensor
    /// </summary>
    public class UltravioletSensorDataUpdatedEventArgs : EventArgs
    {
        internal UltravioletSensorDataUpdatedEventArgs(float ultravioletIndex)
        {
            UltravioletIndex = ultravioletIndex;
        }

        /// <summary>
        /// Gets the value of the ultraviolet index.
        /// </summary>
        public float UltravioletIndex { get; private set; }
    }
}