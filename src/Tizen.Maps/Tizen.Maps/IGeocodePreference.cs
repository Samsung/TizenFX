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


namespace Tizen.Maps
{
    /// <summary>
    /// Preferences for geocode searches
    /// </summary>
    /// <since_tizen>3</since_tizen>
    public interface IGeocodePreference
    {
        /// <summary>
        /// Gets or sets a string that presents preferred language.
        /// </summary>
        /// <since_tizen>3</since_tizen>
        /// <remarks>Language should be specified as an ISO 3166 alpha-2 two letter country-code
        /// followed by ISO 639-1 for the two-letter language code.<br/>e.g. "ko-KR", "en-US".</remarks>
        string Language { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of results.
        /// </summary>
        /// <since_tizen>3</since_tizen>
        /// <remarks>Setting negative value will not have any effect on MaxResults value.</remarks>
        int MaxResults { get; set; }
    }
}
