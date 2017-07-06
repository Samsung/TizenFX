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
    /// <since_tizen>3</since_tizen>
    public class SearchPreference : IGeocodePreference, IPlaceSearchPreference, IRouteSearchPreference, IDisposable
    {
        internal Interop.PreferenceHandle handle;
        private IDictionary<string, string> _properties = new Dictionary<string, string>();

        /// <summary>
        /// Constructors a new search preference.
        /// </summary>
        /// <since_tizen>3</since_tizen>
        public SearchPreference()
        {
            handle = new Interop.PreferenceHandle();
        }

        /// <summary>
        /// Constructors a new search preference.
        /// </summary>
        internal SearchPreference(Interop.PreferenceHandle nativeHandle)
        {
            handle = nativeHandle;
        }

        /// <summary>
        /// Gets or sets preferred language.
        /// </summary>
        /// <since_tizen>3</since_tizen>
        /// <remarks>Language should be specified as an ISO 3166 alpha-2 two letter country-code
        /// followed by ISO 639-1 for the two-letter language code.<br/>e.g. "ko-KR", "en-US".</remarks>
        public string Language
        {
            get
            {
                return handle.Language;
            }
            set
            {
                Log.Info(string.Format("Language is changed from {0} to {1}", handle.Language, value));
                handle.Language = value;
            }
        }

        /// <summary>
        /// Gets or sets the maximum result count for each service request.
        /// </summary>
        /// <since_tizen>3</since_tizen>
        /// <remarks>Setting negative value will not have any effect on MaxResults value</remarks>
        public int MaxResults
        {
            get
            {
                return handle.MaxResult;
            }
            set
            {
                Log.Info(string.Format("MaxResult is changed from {0} to {1}", handle.MaxResult, value));
                handle.MaxResult = value;
            }
        }

        /// <summary>
        /// Gets or sets distance unit.
        /// </summary>
        /// <since_tizen>3</since_tizen>
        public DistanceUnit Unit
        {
            get
            {
                return (DistanceUnit)handle.Unit;
            }
            set
            {
                Log.Info(string.Format("Unit is changed from {0} to {1}", handle.Unit, value));
                handle.Unit = (Interop.DistanceUnit)value;
            }
        }

        /// <summary>
        /// Gets or sets preferred country.
        /// </summary>
        /// <since_tizen>3</since_tizen>
        public string CountryCode
        {
            get
            {
                return handle.CountryCode;
            }
            set
            {
                Log.Info(string.Format("CountryCode is changed from {0} to {1}", handle.CountryCode, value));
                handle.CountryCode = value;
            }
        }

        /// <summary>
        /// Gets or sets search properties as key value pair.
        /// </summary>
        /// <since_tizen>3</since_tizen>
        public IReadOnlyDictionary<string, string> Properties
        {
            get
            {
                Action<string, string> action = (key, value) =>
                {
                    _properties[key] = value;
                };

                handle.ForeachProperty(action);
                return (IReadOnlyDictionary<string, string>)_properties;
            }
            set
            {
                foreach (var prop in value)
                {
                    _properties[prop.Key] = prop.Value;
                    handle.SetProperty(prop.Key, prop.Value);
                    Log.Info(string.Format("Properties is changed to [{0}, {1}]", prop.Key, prop.Value));
                }
            }
        }

        /// <summary>
        /// Gets or sets route optimization.
        /// </summary>
        /// <since_tizen>3</since_tizen>
        public RouteOptimization Optimization
        {
            get
            {
                return (RouteOptimization)handle.Optimization;
            }
            set
            {
                Log.Info(string.Format("Optimization is changed from {0} to {1}", handle.Optimization, value));
                handle.Optimization = (Interop.RouteOptimization)value;
            }
        }

        /// <summary>
        /// Gets or sets route transport mode.
        /// </summary>
        /// <since_tizen>3</since_tizen>
        public TransportMode Mode
        {
            get
            {
                return (TransportMode)handle.TransportMode;
            }
            set
            {
                Log.Info(string.Format("TransportMode is changed from {0} to {1}", handle.TransportMode, value));
                handle.TransportMode = (Interop.RouteTransportMode)value;
            }
        }

        /// <summary>
        /// Gets or sets route feature weight.
        /// </summary>
        /// <since_tizen>3</since_tizen>
        public RouteFeatureWeight RouteFeatureWeight
        {
            get
            {
                return (RouteFeatureWeight)handle.FeatureWeight;
            }
            set
            {
                Log.Info(string.Format("RouteFeatureWeight is changed from {0} to {1}", handle.FeatureWeight, value));
                handle.FeatureWeight = (Interop.RouteFeatureWeight)value;
            }
        }

        /// <summary>
        /// Gets or sets route feature.
        /// </summary>
        /// <since_tizen>3</since_tizen>
        public RouteFeature RouteFeature
        {
            get
            {
                return (RouteFeature)handle.Feature;
            }
            set
            {
                Log.Info(string.Format("RouteFeature is changed from {0} to {1}", handle.Feature, value));
                handle.Feature = (Interop.RouteRequestFeature)value;
            }
        }

        /// <summary>
        /// Gets or sets if searching for alternative routes is enabled.
        /// </summary>
        /// <since_tizen>3</since_tizen>
        public bool SearchAlternativeRoutes
        {
            get
            {
                return handle.AlternativesEnabled;
            }
            set
            {
                Log.Info(string.Format("SearchAlternativeRoutes is {0}", (value ? "enabled" : "disabled")));
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

        /// <summary>
        /// Releases all resources used by this object.
        /// </summary>
        /// <since_tizen>3</since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
