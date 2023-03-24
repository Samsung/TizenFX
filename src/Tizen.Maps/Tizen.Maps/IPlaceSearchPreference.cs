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
using System.Collections.Generic;

namespace Tizen.Maps
{
    /// <summary>
    /// The preferences for a place search.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Obsolete("Deprecated since API11. Might be removed in API13.")]
    public interface IPlaceSearchPreference
    {
        /// <summary>
        /// Gets or sets the distance unit.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        DistanceUnit Unit { get; set; }

        /// <summary>
        /// Gets or sets the preferred language.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>Language should be specified as an ISO 3166 alpha-2 two letter country-code
        /// followed by ISO 639-1 for the two-letter language code.<br/>e.g. "ko-KR", "en-US".</remarks>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        string Language { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of results.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        int MaxResults { get; set; }

        /// <summary>
        /// Gets or sets a string that represents the code of a preferred country.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        string CountryCode { get; set; }

        /// <summary>
        /// Gets or sets the search properties as a key value pair.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	[Obsolete("Deprecated since API11. Might be removed in API13.")]
        IReadOnlyDictionary<string, string> Properties { get; set; }
    }
}
