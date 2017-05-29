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
        /// Creates a new Maps Service object for given service provider.
        /// </summary>
        /// <param name="serviceProvider">A string which representing name of map service provider</param>
        /// <param name="serviceProviderKey">A string which representing certificate key to use the map service provider</param>
        /// <privilege>http://tizen.org/privilege/mapservice</privilege>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <exception cref="System.NotSupportedException">Thrown when the required feature is not supported.</exception>
        /// <exception cref="System.ArgumentException">Thrown when parameters are invalid.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when native operation failed to allocate memory, connect to service.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when application does not have some privilege to access this method.</exception>
        public MapService(string serviceProvider, string serviceProviderKey)
        {
            _serviceProvider = serviceProvider;
            handle = new Interop.ServiceHandle(serviceProvider);
            ProviderKey = serviceProviderKey;
            PlaceSearchFilter = new PlaceFilter();
            Preferences = new SearchPreference();
        }

        /// <summary>
        /// Gets list of available map service providers.
        /// </summary>
        /// <value>The list of map service providers.</value>
        /// <privilege>http://tizen.org/privilege/mapservice</privilege>
        /// <exception cref="System.NotSupportedException">Thrown when the required feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when application does not have privileges to access this property.</exception>
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
        /// Gets name of map service provider.
        /// </summary>
        public string Provider { get { return _serviceProvider; } }


        /// <summary>
        /// Gets and sets a string representing keys for map service provider
        /// </summary>
        /// <remarks>Regaularly, the provider key is issued by each maps provider, after signing up for a plan in the web site.
        /// Depending on the plan and its provider which you have signed, you might pay for the network traffic.</remarks>
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
        /// Gets and sets a filter used for place search result.
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
        /// Gets search preferences used for <see cref="Geocode"/> or <see cref="ReverseGeocode"/> request.
        /// </summary>
        public IGeocodePreference GeocodePreferences
        {
            get
            {
                return Preferences as IGeocodePreference;
            }
        }

        /// <summary>
        /// Gets search preferences used for <see cref="Place"/> search request.
        /// </summary>
        public IPlaceSearchPreference PlaceSearchPreferences
        {
            get
            {
                return Preferences as IPlaceSearchPreference;
            }
        }

        /// <summary>
        /// Gets search preferences used for <see cref="Route"/> search request.
        /// </summary>
        public IRouteSearchPreference RouteSearchPreferences
        {
            get
            {
                return Preferences as IRouteSearchPreference;
            }
        }

        /// <summary>
        /// Gets and sets search preferences.
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
        /// Gets the user's consent to use maps data.
        /// </summary>
        /// <param name="provider">A string which representing the name of maps provider</param>
        /// <returns>Returns true if user agreed that the application can use maps data, otherwise false.</returns>
        /// <privilege>http://tizen.org/privilege/mapservice</privilege>
        /// <exception cref="System.NotSupportedException">Thrown when the required feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when application does not have some privilege to access this method.</exception>
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
        /// Checks if the Maps Service supports given request.
        /// </summary>
        /// <param name="type">Request type to check</param>
        /// <returns>Returns true if the Maps Service supports a request, otherwise false.</returns>
        /// <privilege>http://tizen.org/privilege/mapservice</privilege>
        /// <exception cref="System.NotSupportedException">Thrown when the required feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when application does not have some privilege to access this method.</exception>
        public bool IsSupported(ServiceRequestType type)
        {
            bool result;
            var err = handle.IsServiceSupported((Interop.ServiceType)type, out result);
            err.WarnIfFailed($"Failed to get if {type} is supported");
            return (err.IsSuccess()) ? result : false;
        }

        /// <summary>
        /// Checks if the Maps Service supports given data feature.
        /// </summary>
        /// <param name="data">Data feature to check</param>
        /// <returns>Returns true if the Maps Service supports a data feature, otherwise false.</returns>
        /// <privilege>http://tizen.org/privilege/mapservice</privilege>
        /// <exception cref="System.NotSupportedException">Thrown when the required feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when application does not have some privilege to access this method.</exception>
        public bool IsSupported(ServiceData data)
        {
            bool result;
            var err = handle.IsDataSupported((Interop.ServiceData)data, out result);
            err.WarnIfFailed($"Failed to get if {data} data is supported");
            return (err.IsSuccess()) ? result : false;
        }

        /// <summary>
        /// Creates geocode search request for given free-formed address string.
        /// </summary>
        /// <param name="address">A string which representing free-formed address</param>
        /// <returns>GeocodeRequest object created with address string</returns>
        public GeocodeRequest CreateGeocodeRequest(string address)
        {
            return new GeocodeRequest(this, address);
        }

        /// <summary>
        /// Creates geocode search request for given free-formed address string, within the specified boundary.
        /// </summary>
        /// <param name="address">A string which representing free-formed address</param>
        /// <param name="boundary">An instance of Area object which representing interested area</param>
        /// <seealso cref="Area"/>
        /// <returns>GeocodeRequest object created with address string and specified boundary</returns>
        public GeocodeRequest CreateGeocodeRequest(string address, Area boundary)
        {
            return new GeocodeRequest(this, address, boundary);
        }

        /// <summary>
        /// Creates geocode search request for given structured address.
        /// </summary>
        /// <param name="address">A string which representing address of interest</param>
        /// <returns>Returns GeocodeRequest object created with structured address</returns>
        public GeocodeRequest CreateGeocodeRequest(PlaceAddress address)
        {
            return new GeocodeRequest(this, address);
        }

        /// <summary>
        /// Creates a reverse geocode search request for given latitude and longitude.
        /// </summary>
        /// <param name="latitude">Latitude of interested place</param>
        /// <param name="longitute">Longitude of interested place</param>
        /// <returns>Returns ReverseGeocodeRequest object created with location coordinates</returns>
        public ReverseGeocodeRequest CreateReverseGeocodeRequest(double latitude, double longitute)
        {
            return new ReverseGeocodeRequest(this, latitude, longitute);
        }

        /// <summary>
        /// Creates a reverse geocode search request for given position coordinates list.
        /// </summary>
        /// <param name="coordinates">Coordinates list with [2 ~ 100] coordinates</param>
        /// <returns>Returns MultiReverseGeocodeRequest object created with list of location coordinates</returns>
        public MultiReverseGeocodeRequest CreateMultiReverseGeocodeRequest(IEnumerable<Geocoordinates> coordinates)
        {
            return new MultiReverseGeocodeRequest(this, coordinates);
        }

        /// <summary>
        /// Creates a route search request for origin and destination points.
        /// </summary>
        /// <param name="from">Starting point</param>
        /// <param name="to">Destination</param>
        /// <returns>Returns RouteSearchRequest object created with origin and destination coordinates</returns>
        public RouteSearchRequest CreateRouteSearchRequest(Geocoordinates from, Geocoordinates to)
        {
            return new RouteSearchRequest(this, from, to);
        }

        /// <summary>
        /// Creates a place search request for specified search radius around a given coordinates position.
        /// </summary>
        /// <param name="coordinates">A geographical coordinates of center</param>
        /// <param name="distance">A double value which representing radius of area to search places</param>
        /// <returns>Returns PlaceSearchRequest object created with location coordinates and search radius</returns>
        public PlaceSearchRequest CreatePlaceSearchRequest(Geocoordinates coordinates, int distance)
        {
            return new PlaceSearchRequest(this, coordinates, distance);
        }

        /// <summary>
        /// Creates a place search request for places within specified boundary.
        /// </summary>
        /// <param name="boundary">An instance of Area object which representing area to search interested places</param>
        /// <returns>Returns PlaceSearchRequest object created with specified boundary</returns>
        public PlaceSearchRequest CreatePlaceSearchRequest(Area boundary)
        {
            return new PlaceSearchRequest(this, boundary);
        }

        /// <summary>
        /// Creates a place search request for free-formed address within boundary.
        /// </summary>
        /// <param name="address">A string which representing free-formed address</param>
        /// <param name="boundary">An instance of Area object which representing area to search interested places</param>
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

        /// <summary>
        /// Releases all resources used by this object.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
