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
    /// Preferences for route search requests
    /// </summary>
    public class SearchPreference : IGeocodePreference, IPlaceSearchPreference, IRouteSearchPreference, IDisposable
    {
        internal Interop.PreferenceHandle handle;
        private IReadOnlyDictionary<string, string> _properties = new Dictionary<string, string>();

        /// <summary>
        /// Constructor for search preference
        /// </summary>
        public SearchPreference()
        {
            handle = new Interop.PreferenceHandle();
        }

        /// <summary>
        /// Constructor for search preference
        /// </summary>
        internal SearchPreference(Interop.PreferenceHandle nativeHandle)
        {
            handle = nativeHandle;
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
                return handle.Language;
            }
            set
            {
                handle.Language = value;
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
                return handle.MaxResult;
            }
            set
            {
                handle.MaxResult = value;
            }
        }

        /// <summary>
        /// Distance unit
        /// </summary>
        public DistanceUnit Unit
        {
            get
            {
                return (DistanceUnit)handle.Unit;
            }
            set
            {
                handle.Unit = (Interop.DistanceUnit)value;
            }
        }

        /// <summary>
        /// Preferred country
        /// </summary>
        public string CountryCode
        {
            get
            {
                return handle.CountryCode;
            }
            set
            {
                handle.CountryCode = value;
            }
        }

        /// <summary>
        /// Search properties as key value pair
        /// </summary>
        public IReadOnlyDictionary<string, string> Properties
        {
            get
            {
                return _properties;
            }
            set
            {
                _properties = value;
            }
        }

        /// <summary>
        /// Selected route optimization
        /// </summary>
        public RouteOptimization Optimization
        {
            get
            {
                return (RouteOptimization)handle.Optimization;
            }
            set
            {
                handle.Optimization = (Interop.RouteOptimization)value;
            }
        }

        /// <summary>
        /// Route transport mode
        /// </summary>
        public TransportMode Mode
        {
            get
            {
                return (TransportMode)handle.TransportMode;
            }
            set
            {
                handle.TransportMode = (Interop.RouteTransportMode)value;
            }
        }

        /// <summary>
        /// Route feature weight
        /// </summary>
        public RouteFeatureWeight RouteFeatureWeight
        {
            get
            {
                return (RouteFeatureWeight)handle.FeatureWeight;
            }
            set
            {
                handle.FeatureWeight = (Interop.RouteFeatureWeight)value;
            }
        }

        /// <summary>
        /// Route feature
        /// </summary>
        public RouteFeature RouteFeature
        {
            get
            {
                return (RouteFeature)handle.Feature;
            }
            set
            {
                handle.Feature = (Interop.RouteRequestFeature)value;
            }
        }

        /// <summary>
        /// Indicate if search for alternative routes is enabled.
        /// </summary>
        public bool SearchAlternativeRoutes
        {
            get
            {
                return handle.AlternativesEnabled;
            }
            set
            {
                handle.AlternativesEnabled = value;
            }
        }

        #region IDisposable Support
        private bool _disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                handle.Dispose();
                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
