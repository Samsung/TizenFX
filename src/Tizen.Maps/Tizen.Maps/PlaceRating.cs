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

namespace Tizen.Maps
{
    /// <summary>
    /// Place rating information, used in place discovery and search requests.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class PlaceRating
    {
        private int _count;
        private double _average;

        internal PlaceRating(Interop.PlaceRatingHandle handle)
        {
            _count = handle.Count;
            _average = handle.Average;
        }

        /// <summary>
        /// Gets the number of users rated for this place rating.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int UserCount { get { return _count; } }

        /// <summary>
        /// Gets the average value of this place rating.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public double Average { get { return _average; } }

        /// <summary>
        /// Returns a string that represents this object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>Returns a string which presents this object.</returns>
        public override string ToString()
        {
            return $"{Average}({UserCount} reviews)";
        }
    }
}
