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
    public class ZoneChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Class Constructor for ZoneChangedEventArgs class.
        /// </summary>
        /// <param name="state"> An enumeration of type BoundaryState.</param>
        /// <param name="latitude"> The latitude value.</param>
        /// <param name="longitude"> The longitude value.</param>
        /// <param name="altitude"> The altitude value.</param>
        /// <param name="timestamp"> The timestamp value.</param>
        public ZoneChangedEventArgs(BoundaryState state, double latitude, double longitude, double altitude, DateTime timestamp)
        {
            BoundState = state;
            Latitude = latitude;
            Longitude = longitude;
            Altitude = altitude;
            TimeStamp = timestamp;
        }

        /// <summary>
        /// Get the Boundary State.
        /// </summary>
        public BoundaryState BoundState { get; private set; }

        /// <summary>
        /// Get the latitude.
        /// </summary>
        public double Latitude { get; private set; }

        /// <summary>
        /// Get the longitude.
        /// </summary>
        public double Longitude { get; private set; }

        /// <summary>
        /// Get the altitude.
        /// </summary>
        public double Altitude { get; private set; }

        /// <summary>
        /// Method to get the timestamp.
        /// </summary>
        public DateTime TimeStamp { get; private set; }
    }
}
