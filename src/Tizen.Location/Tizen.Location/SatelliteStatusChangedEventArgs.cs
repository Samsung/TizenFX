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
    public class SatelliteStatusChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Class Constructor for SatelliteStatusChangedEventArgs class.
        /// </summary>
        /// <param name="activeCount"> The number of active satellites.</param>
        /// <param name="inviewCount"> The number of satellites in view.</param>
        /// <param name="timestamp"> The time at which the data has been extracted.</param>
        public SatelliteStatusChangedEventArgs(uint activeCount, uint inviewCount, DateTime timestamp)
        {
            ActiveCount = activeCount;
            InViewCount = inviewCount;
            Timestamp = timestamp;
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
        public DateTime Timestamp { get; private set; }
    }
}
