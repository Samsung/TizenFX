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
using System.Threading.Tasks;

namespace Tizen.Maps
{
    /// <summary>
    /// Map service class for service request
    /// </summary>
    public partial class MapService : IDisposable
    {
        internal Interop.ServiceHandle handle;

        private PlaceFilter _filter;
        private SearchPreference _searchPreference;

        private static List<string> s_providers;
        private string _serviceProvider;


        /// <summary>
        /// Creates a new Maps Service object for given service provider
        /// </summary>
        /// <param name="serviceProvider">Name of map service provider</param>
        /// <param name="serviceProviderKey">Key string provided by map service provider</param>
        /// <exception cref="System.InvalidOperationException">Throws if native operation failed to allocate memory, connect to service</exception>
        /// <exception cref="System.UnauthorizedAccessException">Throws if user does not have privilege to access this API</exception>
        public MapService(string serviceProvider, string serviceProviderKey)
        {
            _serviceProvider = serviceProvider;
            handle = new Interop.ServiceHandle(serviceProvider);
            ProviderKey = serviceProviderKey;
            PlaceSearchFilter = new PlaceFilter();
            Preferences = new SearchPreference();
        }

        /// <summary>
        /// List of available map service providers
        /// </summary>
        public static IEnumerable<string> Providers
        {
            get
            {
                if (s_providers != null) return s_providers;

                s_providers = new List<string>();
                Interop.ServiceHandle.ForeachProvider(provider => s_providers.Add(provider));
                return s_providers;
            }
        }

        /// <summary>
        /// Name of map service provider
        /// </summary>
        public string Provider { get { return _serviceProvider; } }


        /// <summary>
        /// Key for map service provider
        /// </summary>
        public string ProviderKey
        {
            get
            {
                return handle.ProviderKey;
            }
            set
            {
                handle.ProviderKey = value;
            }
        }

        /// <summary>
        /// Filter used for place search result
        /// </summary>
        public PlaceFilter PlaceSearchFilter
        {
            get
            {
                return _filter;
            }
            set
            {
                if (value != null)
                {
                    _filter = value;
                }
            }
        }

        /// <summary>
        /// Search preferences used for Geocode/ ReverseGeocode request
        /// </summary>
        public IGeocodePreference GeocodePreferences
        {
            get
            {
                return Preferences as IGeocodePreference;
            }
        }

        /// <summary>
        /// Search preferences used for <see cref="Place"/> search request
        /// </summary>
        public IPlaceSearchPreference PlaceSearchPreferences
        {
            get
            {
                return Preferences as IPlaceSearchPreference;
            }
        }

        /// <summary>
        /// Search preferences used for <see cref="Route"/> search request
        /// </summary>
        public IRouteSearchPreference RouteSearchPreferences
        {
            get
            {
                return Preferences as IRouteSearchPreference;
            }
        }

        /// <summary>
        /// Search preferences
        /// </summary>
        public SearchPreference Preferences
        {
            get
            {
                if (_searchPreference == null)
                {
                    _searchPreference = new SearchPreference(handle.Preferences);
                }
                return _searchPreference;
            }
            set
            {
                if (value != null)
                {
                    handle.Preferences = value.handle;
                    _searchPreference = value;
                }
            }
        }

        /// <summary>
        /// Gets the user's consent to use maps data
        /// </summary>
        /// <returns>true if user agreed that the application can use maps data, false otherwise</returns>
        public static async Task<bool> RequestUserConsent(string provider)
        {
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            Interop.ServiceHandle.RequestUserConsentCallback cb = (consented, serviceProvider, userData) =>
            {
                tcs.TrySetResult(consented);
            };

            var err = Interop.ServiceHandle.RequestUserConsent(provider, cb, IntPtr.Zero);
            if (err.IsFailed())
            {
                tcs.TrySetException(err.GetException("Failed to get user consent"));
            }
            return await tcs.Task.ConfigureAwait(false);
        }

        /// <summary>
        /// Checks if the Maps Service supports given request
        /// </summary>
        /// <param name="type">request type to be checked</param>
        /// <returns>true if the Maps Service supports a request, false otherwise</returns>
        public bool IsSupported(ServiceRequestType type)
        {
            bool result;
            var err = handle.IsServiceSupported((Interop.ServiceType)type, out result);
            err.WarnIfFailed($"Failed to get if {type} is supported");
            return (err.IsSuccess()) ? result : false;
        }

        /// <summary>
        /// Checks if the Maps Service supports given data feature
        /// </summary>
        /// <param name="data">data feature to be checked </param>
        /// <returns>true if the Maps Service supports a data feature, false otherwise</returns>
        public bool IsSupported(ServiceData data)
        {
            bool result;
            var err = handle.IsDataSupported((Interop.ServiceData)data, out result);
            err.WarnIfFailed($"Failed to get if {data} data is supported");
            return (err.IsSuccess()) ? result : false;
        }

        /// <summary>
        /// Creates gGeocode search request for given free-formed address string
        /// </summary>
        /// <param name="address">Free-formed address</param>
        /// <returns>Returns GeocodeRequest object created with address string</returns>
        public GeocodeRequest CreateGeocodeRequest(string address)
        {
            return new GeocodeRequest(this, address);
        }

        /// <summary>
        /// Creates geocode search request for given free-formed address string, within the specified boundary
        /// </summary>
        /// <param name="address">Free-formed address</param>
        /// <param name="boundary">Interested area</param>
        /// <returns>Returns GeocodeRequest object created with address string and specified boundary</returns>
        public GeocodeRequest CreateGeocodeRequest(string address, Area boundary)
        {
            return new GeocodeRequest(this, address, boundary);
        }

        /// <summary>
        /// Creates geocode search request for given structured address
        /// </summary>
        /// <param name="address">address of interest</param>
        /// <returns>Returns GeocodeRequest object created with structured address</returns>
        public GeocodeRequest CreateGeocodeRequest(PlaceAddress address)
        {
            return new GeocodeRequest(this, address);
        }

        /// <summary>
        /// Creates reverse geocode search request for given latitude and longitude
        /// </summary>
        /// <param name="latitude">Latitude for location of interest</param>
        /// <param name="longitute">Longitude for location of interest</param>
        /// <returns>Returns ReverseGeocodeRequest object created with location coordinates</returns>
        public ReverseGeocodeRequest CreateReverseGeocodeRequest(double latitude, double longitute)
        {
            return new ReverseGeocodeRequest(this, latitude, longitute);
        }

        /// <summary>
        /// Creates reverse geocode search request for given position coordinates list
        /// </summary>
        /// <param name="coordinates">Coordinates list with [2 ~ 100] coordinates</param>
        /// <returns>Returns MultiReverseGeocodeRequest object created with list of location coordinates</returns>
        public MultiReverseGeocodeRequest CreateMultiReverseGeocodeRequest(IEnumerable<Geocoordinates> coordinates)
        {
            return new MultiReverseGeocodeRequest(this, coordinates);
        }

        /// <summary>
        /// Creates route search request for origin and destination points
        /// </summary>
        /// <param name="from">starting point</param>
        /// <param name="to">destination</param>
        /// <returns>Returns RouteSearchRequest object created with origin and destination coordinates</returns>
        public RouteSearchRequest CreateRouteSearchRequest(Geocoordinates from, Geocoordinates to)
        {
            return new RouteSearchRequest(this, from, to);
        }

        /// <summary>
        /// Creates place search request  for specified search radius around a given coordinates position
        /// </summary>
        /// <param name="coordinates">Interested position</param>
        /// <param name="distance">Search radius</param>
        /// <returns>Returns PlaceSearchRequest object created with location coordinates and search radius</returns>
        public PlaceSearchRequest CreatePlaceSearchRequest(Geocoordinates coordinates, int distance)
        {
            return new PlaceSearchRequest(this, coordinates, distance);
        }

        /// <summary>
        /// Creates place search for places within specified boundary
        /// </summary>
        /// <param name="boundary">Interested area</param>
        /// <returns>Returns PlaceSearchRequest object created with specified boundary</returns>
        public PlaceSearchRequest CreatePlaceSearchRequest(Area boundary)
        {
            return new PlaceSearchRequest(this, boundary);
        }

        /// <summary>
        /// Creates place search for free formed address within boundary
        /// </summary>
        /// <param name="address">Free-formed address</param>
        /// <param name="boundary">Interested area</param>
        /// <returns>Returns PlaceSearchRequest object created with address string and specified boundary</returns>
        public PlaceSearchRequest CreatePlaceSearchRequest(string address, Area boundary)
        {
            return new PlaceSearchRequest(this, address, boundary);
        }

        #region IDisposable Support
        private bool _disposedValue = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _filter.Dispose();
                    _searchPreference.Dispose();
                }
                handle.Dispose();
                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
