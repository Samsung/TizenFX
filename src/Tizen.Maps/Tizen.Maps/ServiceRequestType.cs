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
    /// Service Requests available in the Maps Service
    /// </summary>
    public enum ServiceRequestType
    {
        /// <summary>
        /// Service request to get position <see cref="Geocoordinates"/> for a given free-formed address string is allowed
        /// </summary>
        Geocode = Interop.ServiceType.Geocode,
        /// <summary>
        /// Service request to get position <see cref="Geocoordinates"/>  for a given address, within the specified bounding <see cref="Area"/>, is allowed
        /// </summary>
        GeocodeInsideArea = Interop.ServiceType.GeocodeInsideArea,
        /// <summary>
        /// Service request to get position <see cref="Geocoordinates"/> for a given <see cref="PlaceAddress"/> is allowed
        /// </summary>
        GeocodeByStructuredAddress = Interop.ServiceType.GeocodeByStructuredAddress,
        /// <summary>
        /// Service request to get <see cref="PlaceAddress"/> for a given <see cref="Geocoordinates"/> is allowed
        /// </summary>
        ReverseGeocode = Interop.ServiceType.ReverseGeocode,
        /// <summary>
        /// Service request to get <see cref="PlaceAddress"/> for a given <see cref="GeocoordinatesList"/> is allowed
        /// </summary>
        MultiReverseGeocode = Interop.ServiceType.MultiReverseGeocode,

        /// <summary>
        /// Service request to query <see cref="Place"/> information for a given <see cref="Geocoordinates"/> is allowed
        /// </summary>
        SearchPlace = Interop.ServiceType.SearchPlace,
        /// <summary>
        /// Service request to query <see cref="Place"/> information for a given <see cref="Area"/> is allowed
        /// </summary>
        SearchPlaceByArea = Interop.ServiceType.SearchPlaceByArea,
        /// <summary>
        /// Service request to query <see cref="Place"/> information for a given free-formed address string is allowed
        /// </summary>
        SearchPlaceByAddress = Interop.ServiceType.SearchPlaceByAddress,
        /// <summary>
        /// Service request to query <see cref="Place"/> information list for all places in a given <see cref="Area"/> is allowed
        /// </summary>
        SearchPlaceList = Interop.ServiceType.SearchPlaceList,
        /// <summary>
        /// Service request to get detailed <see cref="Place"/> information for a given <see cref="PlaceUrl"/> is allowed
        /// </summary>
        SearchGetPlaceDetails = Interop.ServiceType.SearchGetPlaceDetails,

        /// <summary>
        /// Service request to query <see cref="Route"/> information from a given origin <see cref="Geocoordinates"/> and destination <see cref="Geocoordinates"/> is allowed
        /// </summary>
        SearchByEndPoint = Interop.ServiceType.SearchRoute,
        /// <summary>
        /// Service request to query <see cref="Route"/> information passing through specified way-points <see cref="GeocoordinatesList"/> is allowed
        /// </summary>
        SearchWithWaypoints = Interop.ServiceType.SearchRouteWaypoints,

        /// <summary>
        /// Map view service is allowed
        /// </summary>
        View = Interop.ServiceType.View,
        /// <summary>
        /// Map view snapshot service is allowed
        /// </summary>
        ViewSnapshot = Interop.ServiceType.ViewSnapshot,

        /// <summary>
        /// Canceling a request is allowed
        /// </summary>
        CancelRequest = Interop.ServiceType.CancelRequest,
    }
}
