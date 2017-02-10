/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;

namespace Tizen.Location
{
    public class ZoneChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Class Constructor for ZoneChangedEventArgs class.
        /// </summary>
        /// <param name="state"> An enumeration of type BoundaryState.</param>
        /// <param name="latitude"> The latitude value[-90.0 ~ 90.0] (degrees).</param>
        /// <param name="longitude"> The longitude value[-180.0 ~ 180.0] (degrees).</param>
        /// <param name="altitude"> The altitude value.</param>
        /// <param name="timestamp"> The timestamp value.</param>
        public ZoneChangedEventArgs(BoundaryState state, double latitude, double longitude, double altitude, DateTime timestamp)
        {
            BoundState = state;
            Latitude = latitude;
            Longitude = longitude;
            Altitude = altitude;
            Timestamp = timestamp;
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
        public DateTime Timestamp { get; private set; }
    }
}
