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
    /// ProximitySensor changed event arguments. Class for storing the data returned by proximity sensor
    /// </summary>
    public class ProximitySensorDataUpdatedEventArgs : EventArgs
    {
        internal ProximitySensorDataUpdatedEventArgs(float proximity)
        {
            Proximity = (ProximitySensorState) proximity;
        }

        /// <summary>
        /// Gets the proximity state.
        /// </summary>
        public ProximitySensorState Proximity { get; private set; }
    }
}