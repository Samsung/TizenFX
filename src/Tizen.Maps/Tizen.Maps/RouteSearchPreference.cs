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
    /// Preferences for route search requests
    /// </summary>
    public class RouteSearchPreference
    {
        internal Interop.PreferenceHandle handle;

        private Interop.DistanceUnit? _distanceUnit;
        private Interop.RouteOptimization? _routeOptimization;
        private Interop.RouteTransportMode? _transportMode;
        private Interop.RouteFeatureWeight? _featureWeight;
        private Interop.RouteRequestFeature? _requestFeature;
        private bool? _searchAlternativeRoutes;

        /// <summary>
        /// Constructor for search preference
        /// </summary>
        public RouteSearchPreference()
        {
            IntPtr nativeHandle;
            var err = Interop.Preference.Create(out nativeHandle);
            err.ThrowIfFailed("Failed to create native preference handle");

            handle = new Interop.PreferenceHandle(nativeHandle);
        }

        internal RouteSearchPreference(Interop.PreferenceHandle handle)
        {
            this.handle = handle;
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
        /// Selected route optimization
        /// </summary>
        public RouteOptimization Optimization
        {
            get
            {
                if (_routeOptimization == null)
                {
                    var err = Interop.Preference.GetRouteOptimization(handle, out _routeOptimization);
                    err.WarnIfFailed("Failed to get route optimization for this preference");
                }
                return (RouteOptimization)_routeOptimization;
            }
            set
            {
                var err = Interop.Preference.SetRouteOptimization(handle, (Interop.RouteOptimization)value);
                if (err.WarnIfFailed("Failed to set route optimization for this preference"))
                {
                    _routeOptimization = (Interop.RouteOptimization)value;
                }
            }
        }

        /// <summary>
        /// Route transport mode
        /// </summary>
        public TransportMode Mode
        {
            get
            {
                if (_transportMode == null)
                {
                    var err = Interop.Preference.GetRouteTransportMode(handle, out _transportMode);
                    err.WarnIfFailed("Failed to get route transport mode for this preference");
                }
                return (TransportMode)_transportMode;
            }
            set
            {
                var err = Interop.Preference.SetRouteTransportMode(handle, (Interop.RouteTransportMode)value);
                if (err.WarnIfFailed("Failed to set route transport mode for this preference"))
                {
                    _transportMode = (Interop.RouteTransportMode)value;
                }
            }
        }

        /// <summary>
        /// Route feature weight
        /// </summary>
        public RouteFeatureWeight RouteFeatureWeight
        {
            get
            {
                if (_featureWeight == null)
                {
                    var err = Interop.Preference.GetRouteFeatureWeight(handle, out _featureWeight);
                    err.WarnIfFailed("Failed to get route feature weight for this preference");
                }
                return (RouteFeatureWeight)_featureWeight;
            }
            set
            {
                var err = Interop.Preference.SetRouteFeatureWeight(handle, (Interop.RouteFeatureWeight)value);
                if (err.WarnIfFailed("Failed to set route feature weight for this preference"))
                {
                    _featureWeight = (Interop.RouteFeatureWeight)value;
                }
            }
        }

        /// <summary>
        /// Route feature
        /// </summary>
        public RouteFeature RouteFeature
        {
            get
            {
                if (_requestFeature == null)
                {
                    var err = Interop.Preference.GetRouteFeature(handle, out _requestFeature);
                    err.WarnIfFailed("Failed to get route feature for this preference");
                }
                return (RouteFeature)_requestFeature;
            }
            set
            {
                var err = Interop.Preference.SetRouteFeature(handle, (Interop.RouteRequestFeature)value);
                if (err.WarnIfFailed("Failed to set route request feature for this preference"))
                {
                    _requestFeature = (Interop.RouteRequestFeature)value;
                }
            }
        }

        /// <summary>
        /// Indicate if search for alternative routes is enabled.
        /// </summary>
        public bool SearchAlternativeRoutes
        {
            get
            {
                if (_searchAlternativeRoutes == null)
                {
                    var err = Interop.Preference.GetRouteAlternativesEnabled(handle, out _searchAlternativeRoutes);
                    err.WarnIfFailed("Failed to get preference for alternative route search");
                }
                return (bool)_searchAlternativeRoutes;
            }
            set
            {
                var err = Interop.Preference.SetRouteAlternativesEnabled(handle, value);
                if (err.WarnIfFailed("Failed to enable alternative route searches"))
                {
                    _searchAlternativeRoutes = value;
                }
            }
        }
    }
}