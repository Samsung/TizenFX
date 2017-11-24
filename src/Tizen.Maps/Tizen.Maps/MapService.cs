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
    /// Map service class for service request.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public partial class MapService : IDisposable
    {
        internal Interop.ServiceHandle handle;

        private PlaceFilter _filter;
        private SearchPreference _searchPreference;

        private static List<string> s_providers;
        private string _serviceProvider;


        /// <summary>
        /// Creates a new maps service object for given service provider.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="serviceProvider">A string representing the name of the map service provider.</param>
        /// <param name="serviceProviderKey">A string representing a certificate key to use the map service provider.</param>
        /// <privilege>http://tizen.org/privilege/mapservice</privilege>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <exception cref="System.NotSupportedException">Thrown when the required feature is not supported.</exception>
        /// <exception cref="System.ArgumentException">Thrown when parameters are invalid.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when a native operation failed to allocate memory and connect to the service.</exception>
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
        /// Destroy the MapService object.
        /// </summary>
        ~MapService()
        {
            Dispose(false);
        }

        /// <summary>
        /// Gets the list of available map service providers.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The list of map service providers.</value>
        /// <privilege>http://tizen.org/privilege/mapservice</privilege>
        /// <exception cref="System.NotSupportedException">Thrown when the required feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when application does not have privilege to access this property.</exception>
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
        /// Gets the name of the map service provider.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Provider { get { return _serviceProvider; } }

        /// <summary>
        /// Gets a user consent for the map service provider
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <privilege>http://tizen.org/privilege/mapservice</privilege>
        public bool UserConsented
        {
            get
            {
                return handle.UserConsented;
            }
        }

        /// <summary>
        /// Gets and sets a string representing keys for the map service provider.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>Typically, the provider key is issued by each maps provider after signing up for a plan in the website.
        /// Depending on the plan and its provider which you have signed, you might have to pay for the network traffic.</remarks>
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
        /// Gets and sets a filter used for the place search result.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets the search preferences used for <see cref="GeocodeRequest"/> or <see cref="ReverseGeocodeRequest"/>.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public IGeocodePreference GeocodePreferences
        {
            get
            {
                return Preferences as IGeocodePreference;
            }
        }

        /// <summary>
        /// Gets the search preferences used for <see cref="PlaceSearchRequest"/>.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public IPlaceSearchPreference PlaceSearchPreferences
        {
            get
            {
                return Preferences as IPlaceSearchPreference;
            }
        }

        /// <summary>
        /// Gets the search preferences used for <see cref="RouteSearchRequest"/>.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public IRouteSearchPreference RouteSearchPreferences
        {
            get
            {
                return Preferences as IRouteSearchPreference;
            }
        }

        /// <summary>
        /// Gets and sets the search preferences.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// <since_tizen> 4 </since_tizen>
        /// <returns>Returns true if user agreed that the application can use maps data, otherwise false.</returns>
        /// <privilege>http://tizen.org/privilege/mapservice</privilege>
        /// <exception cref="System.NotSupportedException">Thrown when the required feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when application does not have some privilege to access this method.</exception>
        public async Task<bool> RequestUserConsent()
        {
            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            Interop.RequestUserConsentwithHandleCallback cb = (consented, userData) =>
            {
                tcs.TrySetResult(consented);
            };

            var err = handle.RequestUserConsent(cb, IntPtr.Zero);
            if (err.IsFailed())
            {
                tcs.TrySetException(err.GetException("Failed to get user consent"));
            }
            return await tcs.Task.ConfigureAwait(false);
        }

        /// <summary>
        /// Checks if the maps service supports the given request.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="type">Request type to check</param>
        /// <returns>Returns true if the maps service supports a request, otherwise false.</returns>
        /// <privilege>http://tizen.org/privilege/mapservice</privilege>
        /// <exception cref="System.NotSupportedException">Thrown when the required feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when application does not have some privilege to access this method.</exception>
        public bool IsSupported(ServiceRequestType type)
        {
            bool result = false;
            var err = handle.IsServiceSupported((Interop.ServiceType)type, out result);
            err.WarnIfFailed($"Failed to get if {type} is supported");
            return (err.IsSuccess()) ? result : false;
        }

        /// <summary>
        /// Checks if the maps service supports a given data feature.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
	    /// <param name="data">Data feature to check.</param>
        /// <returns>Returns true if the maps service supports a data feature, otherwise false.</returns>
        /// <privilege>http://tizen.org/privilege/mapservice</privilege>
        /// <exception cref="System.NotSupportedException">Thrown when the required feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when application does not have some privilege to access this method.</exception>
        public bool IsSupported(ServiceData data)
        {
            bool result = false;
            var err = handle.IsDataSupported((Interop.ServiceData)data, out result);
            err.WarnIfFailed($"Failed to get if {data} data is supported");
            return (err.IsSuccess()) ? result : false;
        }

        /// <summary>
        /// Creates a geocode search request for the given free-formed address string.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="address">A string representing free-formed address.</param>
        /// <returns>Returns a GeocodeRequest object created with an address string.</returns>
        public GeocodeRequest CreateGeocodeRequest(string address)
        {
            return new GeocodeRequest(this, address);
        }

        /// <summary>
        /// Creates a geocode search request for the given free-formed address string, within the specified boundary.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="address">A string representing the free-formed address.</param>
        /// <param name="boundary">An instance of Area object representing the interested area.</param>
        /// <seealso cref="Area"/>
        /// <returns>Returns a GeocodeRequest object created with an address string and a specified boundary.</returns>
        public GeocodeRequest CreateGeocodeRequest(string address, Area boundary)
        {
            return new GeocodeRequest(this, address, boundary);
        }

        /// <summary>
        /// Creates a geocode search request for the given structured address.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="address">A string representing the address of interest.</param>
        /// <returns>Returns a GeocodeRequest object created with a structured address.</returns>
        public GeocodeRequest CreateGeocodeRequest(PlaceAddress address)
        {
            return new GeocodeRequest(this, address);
        }

        /// <summary>
        /// Creates a reverse geocode search request for the given latitude and longitude.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="latitude">Latitude of the interested place.</param>
        /// <param name="longitude">Longitude of the interested place.</param>
        /// <returns>Returns a ReverseGeocodeRequest object created with the location coordinates.</returns>
        public ReverseGeocodeRequest CreateReverseGeocodeRequest(double latitude, double longitude)
        {
            return new ReverseGeocodeRequest(this, latitude, longitude);
        }

        /// <summary>
        /// Creates a reverse geocode search request for the given position coordinates list.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="coordinates">Coordinates list with [2 ~ 100] coordinates.</param>
        /// <returns>Returns a MultiReverseGeocodeRequest object created with a list of location coordinates.</returns>
        public MultiReverseGeocodeRequest CreateMultiReverseGeocodeRequest(IEnumerable<Geocoordinates> coordinates)
        {
            return new MultiReverseGeocodeRequest(this, coordinates);
        }

        /// <summary>
        /// Creates a route search request for the origin and destination points.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="from">Starting point.</param>
        /// <param name="to">Destination.</param>
        /// <returns>Returns a RouteSearchRequest object created with the origin and destination coordinates.</returns>
        public RouteSearchRequest CreateRouteSearchRequest(Geocoordinates from, Geocoordinates to)
        {
            return new RouteSearchRequest(this, from, to);
        }

        /// <summary>
        /// Creates a place search request for a specified search radius around a given coordinates position.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="coordinates">Geographical coordinates of the center.</param>
        /// <param name="distance">A double value representing the radius of an area to search places.</param>
        /// <returns>Returns a PlaceSearchRequest object created with the location coordinates and search radius.</returns>
        public PlaceSearchRequest CreatePlaceSearchRequest(Geocoordinates coordinates, int distance)
        {
            return new PlaceSearchRequest(this, coordinates, distance);
        }

        /// <summary>
        /// Creates a place search request for places within a specified boundary.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="boundary">An instance of Area object representing and area to search interested places.</param>
        /// <returns>Returns a PlaceSearchRequest object created with a specified boundary.</returns>
        public PlaceSearchRequest CreatePlaceSearchRequest(Area boundary)
        {
            return new PlaceSearchRequest(this, boundary);
        }

        /// <summary>
        /// Creates a place search request for a free-formed address within the boundary.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="address">A string which represents a free-formed address.</param>
        /// <param name="boundary">An instance of area object representing an area to search interested places.</param>
        /// <returns>Returns a PlaceSearchRequest object created with an address string and a specified boundary.</returns>
        public PlaceSearchRequest CreatePlaceSearchRequest(string address, Area boundary)
        {
            return new PlaceSearchRequest(this, address, boundary);
        }

        #region IDisposable Support
        private bool _disposedValue = false;

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">If true, managed and unmanaged resources can be disposed, otherwise only unmanaged resources can be disposed.</param>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _filter?.Dispose();
                    _searchPreference?.Dispose();
                }
                handle?.Dispose();
                _disposedValue = true;
            }
        }

        /// <summary>
        /// Releases all the resources used by this object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
