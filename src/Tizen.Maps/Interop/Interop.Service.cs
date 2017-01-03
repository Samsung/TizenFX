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
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal enum ServiceType
    {
        Geocode, // MAPS_SERVICE_GEOCODE
        GeocodeInsideArea, // MAPS_SERVICE_GEOCODE_INSIDE_AREA
        GeocodeByStructuredAddress, // MAPS_SERVICE_GEOCODE_BY_STRUCTURED_ADDRESS
        ReverseGeocode, // MAPS_SERVICE_REVERSE_GEOCODE
        SearchPlace, // MAPS_SERVICE_SEARCH_PLACE
        SearchPlaceByArea, // MAPS_SERVICE_SEARCH_PLACE_BY_AREA
        SearchPlaceByAddress, // MAPS_SERVICE_SEARCH_PLACE_BY_ADDRESS
        SearchRoute, // MAPS_SERVICE_SEARCH_ROUTE
        SearchRouteWaypoints, // MAPS_SERVICE_SEARCH_ROUTE_WAYPOINTS
        CancelRequest, // MAPS_SERVICE_CANCEL_REQUEST
        MultiReverseGeocode, // MAPS_SERVICE_MULTI_REVERSE_GEOCODE
        SearchPlaceList, // MAPS_SERVICE_SEARCH_PLACE_LIST
        SearchGetPlaceDetails, // MAPS_SERVICE_SEARCH_GET_PLACE_DETAILS

        View = 0x100, // MAPS_SERVICE_VIEW
        ViewSnapshot, // MAPS_SERVICE_VIEW_SNAPSHOT
    }

    internal enum ServiceData
    {
        PlaceAddress, // MAPS_PLACE_ADDRESS
        PlaceRating, // MAPS_PLACE_RATING
        PlaceCategories, // MAPS_PLACE_CATEGORIES
        PlaceAttributes, // MAPS_PLACE_ATTRIBUTES
        PlaceContacts, // MAPS_PLACE_CONTACTS
        PlaceEditorials, // MAPS_PLACE_EDITORIALS
        PlaceReviews, // MAPS_PLACE_REVIEWS
        PlaceImage, // MAPS_PLACE_IMAGE
        PlaceSupplier, // MAPS_PLACE_SUPPLIER
        PlaceRelated, // MAPS_PLACE_RELATED
        RoutePath, // MAPS_ROUTE_PATH
        RouteSegmentsPath, // MAPS_ROUTE_SEGMENTS_PATH
        RouteSegmentsManeuvers, // MAPS_ROUTE_SEGMENTS_MANEUVERS

        ViewTraffic = 0x100, // MAPS_VIEW_TRAFFIC
        ViewPublicTransit, // MAPS_VIEW_PUBLIC_TRANSIT
        ViewBuilding, // MAPS_VIEW_BUILDING
        ViewScalebar, // MAPS_VIEW_SCALEBAR
    }

    internal static partial class Service
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool ProviderInfoCallback(string mapsProvider, IntPtr /* void */ userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void RequestUserConsentCallback(bool consented, string provider, IntPtr /* void */ userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool GeocodeCallback(ErrorCode /* maps_error_e */ result, int requestId, int index, int total, IntPtr /* maps_coordinates_h */ coordinates, IntPtr /* void */ userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ReverseGeocodeCallback(ErrorCode /* maps_error_e */ result, int requestId, int index, int total, IntPtr /* maps_address_h */ address, IntPtr /* void */ userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool MultiReverseGeocodeCallback(ErrorCode /* maps_error_e */ result, int requestId, int total, IntPtr /* maps_address_list_h */ addressList, IntPtr /* void */ userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool SearchPlaceCallback(ErrorCode /* maps_error_e */ error, int requestId, int index, int total, IntPtr /* maps_place_h */ place, IntPtr /* void */ userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void SearchPlaceListCallback(ErrorCode /* maps_error_e */ error, int requestId, int total, IntPtr /* maps_place_list_h */ placeList, IntPtr /* void */ userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void GetPlaceDetailsCallback(ErrorCode /* maps_error_e */ error, int requestId, IntPtr /* maps_place_h */ place, IntPtr /* void */ userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool SearchRouteCallback(ErrorCode /* maps_error_e */ error, int requestId, int index, int total, IntPtr /* maps_route_h */ route, IntPtr /* void */ userData);

        [DllImport(Libraries.MapService, EntryPoint = "maps_service_foreach_provider")]
        internal static extern ErrorCode ForeachProvider(ProviderInfoCallback callback, IntPtr /* void */ userData);

        [DllImport(Libraries.MapService, EntryPoint = "maps_service_request_user_consent")]
        internal static extern ErrorCode RequestUserConsent(string provider, RequestUserConsentCallback callback, IntPtr /* void */ userData);

        [DllImport(Libraries.MapService, EntryPoint = "maps_service_create")]
        internal static extern ErrorCode Create(string provider, out IntPtr /* maps_service_h */ maps);

        [DllImport(Libraries.MapService, EntryPoint = "maps_service_destroy")]
        internal static extern ErrorCode Destroy(IntPtr /* maps_service_h */ maps);

        [DllImport(Libraries.MapService, EntryPoint = "maps_service_set_provider_key")]
        internal static extern ErrorCode SetProviderKey(ServiceHandle /* maps_service_h */ maps, string providerKey);

        [DllImport(Libraries.MapService, EntryPoint = "maps_service_get_provider_key")]
        internal static extern ErrorCode GetProviderKey(ServiceHandle /* maps_service_h */ maps, out string providerKey);

        [DllImport(Libraries.MapService, EntryPoint = "maps_service_set_preference")]
        internal static extern ErrorCode SetPreference(ServiceHandle /* maps_service_h */ maps, PreferenceHandle /* maps_preference_h */ preference);

        [DllImport(Libraries.MapService, EntryPoint = "maps_service_get_preference")]
        internal static extern ErrorCode GetPreference(ServiceHandle /* maps_service_h */ maps, out IntPtr /* maps_preference_h */ preference);

        [DllImport(Libraries.MapService, EntryPoint = "maps_service_provider_is_service_supported")]
        internal static extern ErrorCode ProviderIsServiceSupported(ServiceHandle /* maps_service_h */ maps, ServiceType /* maps_service_e */ service, out bool supported);

        [DllImport(Libraries.MapService, EntryPoint = "maps_service_provider_is_data_supported")]
        internal static extern ErrorCode ProviderIsDataSupported(ServiceHandle /* maps_service_h */ maps, ServiceData /* maps_service_data_e */ data, out bool supported);

        [DllImport(Libraries.MapService, EntryPoint = "maps_service_cancel_request")]
        internal static extern ErrorCode CancelRequest(ServiceHandle /* maps_service_h */ maps, int requestId);

        [DllImport(Libraries.MapService, EntryPoint = "maps_service_geocode")]
        internal static extern ErrorCode Geocode(ServiceHandle /* maps_service_h */ maps, string address, PreferenceHandle /* maps_preference_h */ preference, GeocodeCallback callback, IntPtr /* void */ userData, out int requestId);

        [DllImport(Libraries.MapService, EntryPoint = "maps_service_geocode_inside_area")]
        internal static extern ErrorCode GeocodeInsideArea(ServiceHandle /* maps_service_h */ maps, string address, AreaHandle /* maps_area_h */ bounds, PreferenceHandle /* maps_preference_h */ preference, GeocodeCallback callback, IntPtr /* void */ userData, out int requestId);

        [DllImport(Libraries.MapService, EntryPoint = "maps_service_geocode_by_structured_address")]
        internal static extern ErrorCode GeocodeByStructuredAddress(ServiceHandle /* maps_service_h */ maps, AddressHandle /* maps_address_h */ address, PreferenceHandle /* maps_preference_h */ preference, GeocodeCallback callback, IntPtr /* void */ userData, out int requestId);

        [DllImport(Libraries.MapService, EntryPoint = "maps_service_reverse_geocode")]
        internal static extern ErrorCode ReverseGeocode(ServiceHandle /* maps_service_h */ maps, double latitude, double longitude, PreferenceHandle /* maps_preference_h */ preference, ReverseGeocodeCallback callback, IntPtr /* void */ userData, out int requestId);

        [DllImport(Libraries.MapService, EntryPoint = "maps_service_multi_reverse_geocode")]
        internal static extern ErrorCode MultiReverseGeocode(ServiceHandle /* maps_service_h */ maps, CoordinatesListHandle /* maps_coordinates_list_h */ coordinatesList, PreferenceHandle /* maps_preference_h */ preference, MultiReverseGeocodeCallback callback, IntPtr /* void */ userData, out int requestId);

        [DllImport(Libraries.MapService, EntryPoint = "maps_service_search_place")]
        internal static extern ErrorCode SearchPlace(ServiceHandle /* maps_service_h */ maps, CoordinatesHandle /* maps_coordinates_h */ position, int distance, PlaceFilterHandle /* maps_place_filter_h */ filter, PreferenceHandle /* maps_preference_h */ preference, SearchPlaceCallback callback, IntPtr /* void */ userData, out int requestId);

        [DllImport(Libraries.MapService, EntryPoint = "maps_service_search_place_by_area")]
        internal static extern ErrorCode SearchPlaceByArea(ServiceHandle /* maps_service_h */ maps, AreaHandle /* maps_area_h */ boundary, PlaceFilterHandle /* maps_place_filter_h */ filter, PreferenceHandle /* maps_preference_h */ preference, SearchPlaceCallback callback, IntPtr /* void */ userData, out int requestId);

        [DllImport(Libraries.MapService, EntryPoint = "maps_service_search_place_by_address")]
        internal static extern ErrorCode SearchPlaceByAddress(ServiceHandle /* maps_service_h */ maps, string address, AreaHandle /* maps_area_h */ boundary, PlaceFilterHandle /* maps_place_filter_h */ filter, PreferenceHandle /* maps_preference_h */ preference, SearchPlaceCallback callback, IntPtr /* void */ userData, out int requestId);

        [DllImport(Libraries.MapService, EntryPoint = "maps_service_search_place_list")]
        internal static extern ErrorCode SearchPlaceList(ServiceHandle /* maps_service_h */ maps, AreaHandle /* maps_area_h */ boundary, PlaceFilterHandle /* maps_place_filter_h */ filter, PreferenceHandle /* maps_preference_h */ preference, SearchPlaceListCallback callback, IntPtr /* void */ userData, out int requestId);

        [DllImport(Libraries.MapService, EntryPoint = "maps_service_get_place_details")]
        internal static extern ErrorCode GetPlaceDetails(ServiceHandle /* maps_service_h */ maps, string uri, GetPlaceDetailsCallback callback, IntPtr /* void */ userData, out int requestId);

        [DllImport(Libraries.MapService, EntryPoint = "maps_service_search_route")]
        internal static extern ErrorCode SearchRoute(ServiceHandle /* maps_service_h */ maps, CoordinatesHandle /* maps_coordinates_h */ origin, CoordinatesHandle /* maps_coordinates_h */ destination, PreferenceHandle /* maps_preference_h */ preference, SearchRouteCallback callback, IntPtr /* void */ userData, out int requestId);

        [DllImport(Libraries.MapService, EntryPoint = "maps_service_search_route_waypoints")]
        internal static extern ErrorCode SearchRouteWaypoints(ServiceHandle /* maps_service_h */ maps, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] [In] IntPtr[] /* maps_coordinates_h */ waypointList, int waypointNum, PreferenceHandle /* maps_preference_h */ preference, SearchRouteCallback callback, IntPtr /* void */ userData, out int requestId);
    }

    internal class ServiceHandle : SafeMapsHandle
    {
        public ServiceHandle(IntPtr handle, bool ownsHandle = true) : base(handle, ownsHandle) { Destroy = Service.Destroy; }
    }
}
