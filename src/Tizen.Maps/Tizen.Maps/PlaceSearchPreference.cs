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
    /// Preferences for place search requests
    /// </summary>
    public class PlaceSearchPreference
    {
        internal Interop.PreferenceHandle handle;

        private string _language = string.Empty;
        private string _countryCode = string.Empty;
        private Interop.DistanceUnit? _distanceUnit;

        private IDictionary<string, string> _properties = new Dictionary<string, string>();

        /// <summary>
        /// Constructor for search preference
        /// </summary>
        public PlaceSearchPreference()
        {
            IntPtr nativeHandle;
            var err = Interop.Preference.Create(out nativeHandle);
            err.WarnIfFailed("Failed to create native preference handle");

            handle = new Interop.PreferenceHandle(nativeHandle);
        }

        /// <summary>
        /// Constructor for search preference
        /// </summary>
        public PlaceSearchPreference(IDictionary<string, string> properties) : this()
        {
            _properties = properties;
            foreach (var item in properties)
            {
                var err = Interop.Preference.SetProperty(handle, item.Key, item.Value);
                err.WarnIfFailed(string.Format("Failed to set property: {0} = {1}", item.Key, item.Value));
            }
        }

        /// <summary>
        /// Distance unit
        /// </summary>
        public DistanceUnit Unit
        {
            get
            {
                if (_distanceUnit == null)
                {
                    var err = Interop.Preference.GetDistanceUnit(handle, out _distanceUnit);
                    err.WarnIfFailed("Failed to get distance unit for this preference");
                }
                return (DistanceUnit)_distanceUnit;
            }
            set
            {
                var err = Interop.Preference.SetDistanceUnit(handle, (Interop.DistanceUnit)value);
                if (err.WarnIfFailed("Failed to set distance unit for this preference"))
                {
                    _distanceUnit = (Interop.DistanceUnit)value;
                }
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
                    var err = Interop.Preference.GetLanguage(handle, out _language);
                    err.WarnIfFailed("Failed to get language for this preference");
                }
                return _language;
            }
            set
            {
                var err = Interop.Preference.SetLanguage(handle, value);
                if (err.WarnIfFailed("Failed to set language for this preference"))
                {
                    _language = value;
                }
            }
        }

        /// <summary>
        /// Maximum result count for a service request
        /// </summary>
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

        /// <summary>
        /// Preferred country
        /// </summary>
        public string CountryCode
        {
            get
            {
                if (string.IsNullOrEmpty(_countryCode))
                {
                    var err = Interop.Preference.GetCountryCode(handle, out _countryCode);
                    err.WarnIfFailed("Failed to get country code for this preference");
                }
                return _countryCode;
            }
            set
            {
                var err = Interop.Preference.SetCountryCode(handle, value);
                if (err.WarnIfFailed("Failed to set country code for this preference"))
                {
                    _countryCode = value;
                }
            }
        }

        /// <summary>
        /// Search properties as key value pair
        /// </summary>
        public IReadOnlyDictionary<string, string> Properties
        {
            get
            {
                return _properties as IReadOnlyDictionary<string, string>;
            }
        }
    }
}
