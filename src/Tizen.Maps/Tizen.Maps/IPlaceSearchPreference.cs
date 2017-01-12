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


using System.Collections.Generic;

namespace Tizen.Maps
{
    /// <summary>
    /// Preferences for place searches
    /// </summary>
    public interface IPlaceSearchPreference
    {
        /// <summary>
        /// Distance unit
        /// </summary>
        DistanceUnit Unit { get; set; }

        /// <summary>
        /// Preferred language
        /// </summary>
        /// <remarks>
        /// Language should be specified as an ISO 3166 alpha-2 two letter country-code followed by ISO 639-1 for the two-letter language code e.g. "ko-KR"
        /// </remarks>
        string Language { get; set; }

        /// <summary>
        /// Maximum result count for a service request
        /// </summary>
        int MaxResults { get; set; }

        /// <summary>
        /// Preferred country
        /// </summary>
        string CountryCode { get; set; }

        /// <summary>
        /// Search properties as key value pair
        /// </summary>
        IReadOnlyDictionary<string, string> Properties { get; set; }
    }
}