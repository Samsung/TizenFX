// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;


namespace Tizen.Location
{
    public class SatelliteStatusChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Class Constructor for SatelliteStatusChangedEventArgs class.
        /// </summary>
        /// <param name="activeCount"> The number of active satellites.</param>
        /// <param name="inviewCount"> The number of satellites in view.</param>
        /// <param name="timestamp"> The time at which the data has been extracted.</param>
        public SatelliteStatusChangedEventArgs(uint activeCount, uint inviewCount, DateTime timeStamp)
        {
            ActiveCount = activeCount;
            InViewCount = inviewCount;
            TimeStamp = timeStamp;
        }

        /// <summary>
        /// Gets the number of active satellites.
        /// </summary>
        public uint ActiveCount { get; private set; }

        /// <summary>
        /// Gets the number of satellites in view.
        /// </summary>
        public uint InViewCount { get; private set; }

        /// <summary>
        /// Get the timestamp.
        /// </summary>
        public DateTime TimeStamp { get; private set; }
    }
}
