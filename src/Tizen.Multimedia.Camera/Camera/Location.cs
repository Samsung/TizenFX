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

namespace Tizen.Multimedia
{
    /// <summary>
    /// Location class containing GPS data details.
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Public constructor.
        /// </summary>
        /// <param name="latitude">Latitude data</param>
        /// <param name="longitude">Longitude data</param>
        /// <param name="altitude">Altitude data</param>
        public Location(double latitude, double longitude, double altitude)
        {
            Latitude = latitude;
            Longitude = longitude;
            Altitude = altitude;
        }

        /// <summary>
        /// The Latitude data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public double Latitude { get; }

        /// <summary>
        /// The Longitude data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public double Longitude { get; }

        /// <summary>
        /// The Altitude data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public double Altitude { get; }
    }
}

