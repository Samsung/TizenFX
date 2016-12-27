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
    /// Preferences for Geocode service requests
    /// </summary>
    public class GeocodePreference
    {
        internal Interop.PreferenceHandle handle;

        private string _language = string.Empty;

        /// <summary>
        /// Constructor for search preference
        /// </summary>
        public GeocodePreference()
        {
            IntPtr nativeHandle;
            var err = Interop.Preference.Create(out nativeHandle);
            if(err.ThrowIfFailed("Failed to create native preference handle"))
            {
                handle = new Interop.PreferenceHandle(nativeHandle);
            }
        }

        /// <summary>
        /// Preferred language
        /// </summary>
        /// <remarks>
        /// Language should be specified as an ISO 3166 alpha-2 two letter country-code followed by ISO 639-1 for the two-letter language code e.g. "ko-KR"
        /// </remarks>
        public string Language
        {
            get
            {
                if (string.IsNullOrEmpty(_language))
                {
                    string language;
                    var err = Interop.Preference.GetLanguage(handle, out language);
                    if (err.WarnIfFailed("Failed to get language for this preference"))
                    {
                        _language = language;
                    }
                }
                return _language;
            }
            set
            {
                var err = Interop.Preference.SetLanguage(handle, value == null ? "" : value);
                if (err.WarnIfFailed("Failed to set language for this preference"))
                {
                    _language = value;
                }
            }
        }

        /// <summary>
        /// Maximum result count for a service request
        /// </summary>
        /// <remarks>Setting negative value will not have any effect on MaxResults value</remarks>
        public int MaxResults
        {
            get
            {
                int _maxResults = 0;
                var err = Interop.Preference.GetMaxResults(handle, out _maxResults);
                err.WarnIfFailed("Failed to get max result count for this preference");
                return _maxResults;
            }
            set
            {
                var err = Interop.Preference.SetMaxResults(handle, value);
                err.WarnIfFailed("Failed to set max result count for this preference");
            }
        }
    }
}
