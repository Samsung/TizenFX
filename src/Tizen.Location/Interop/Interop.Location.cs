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
using Tizen.Location;

internal static partial class Interop
{
    internal static partial class Locator
    {
        [DllImport(Libraries.Location, EntryPoint = "location_manager_create")]
        internal static extern int Create(int locationMethod, out IntPtr handle);

        [DllImport(Libraries.Location, EntryPoint = "location_manager_destroy")]
        internal static extern int Destroy(IntPtr handle);

        [DllImport(Libraries.Location, EntryPoint = "location_manager_start")]
        internal static extern int Start(IntPtr handle);

        [DllImport(Libraries.Location, EntryPoint = "location_manager_stop")]
        internal static extern int Stop(IntPtr handle);

        [DllImport(Libraries.Location, EntryPoint = "location_manager_enable_mock_location")]
        internal static extern int EnableMock(bool enable);

        [DllImport(Libraries.Location, EntryPoint = "location_manager_set_mock_location")]
        internal static extern int SetMockLocation(IntPtr handle, double latitude, double longitude, double altitude, double speed, double direction, double accuracy);

        [DllImport(Libraries.Location, EntryPoint = "location_manager_clear_mock_location")]
        internal static extern int ClearMock(IntPtr handle);

        [DllImport(Libraries.Location, EntryPoint = "location_manager_get_method")]
        internal static extern int GetLocationType(IntPtr handle, out LocationType method);

        [DllImport(Libraries.Location, EntryPoint = "location_manager_get_location")]
        internal static extern int GetLocation(IntPtr handle, out double altitude, out double latitude, out double longitude, out double climb, out double direction, out double speed, out LocationAccuracy level, out double horizontal, out double vertical, out int timestamp);

        [DllImport(Libraries.Location, EntryPoint = "location_manager_get_last_location")]
        internal static extern int GetLastLocation(IntPtr handle, out double altitude, out double latitude, out double longitude, out double climb, out double direction, out double speed, out LocationAccuracy level, out double horizontal, out double vertical, out int timestamp);

        [DllImport(Libraries.Location, EntryPoint = "location_manager_add_boundary")]
        internal static extern int AddBoundary(IntPtr managerHandle, IntPtr boundsHandle);

        [DllImport(Libraries.Location, EntryPoint = "location_manager_remove_boundary")]
        internal static extern int RemoveBoundary(IntPtr managerHandle, IntPtr boundsHandle);
    }

    internal static partial class LocatorHelper
    {
        [DllImport(Libraries.Location, EntryPoint = "location_manager_is_enabled_method")]
        internal static extern int IsEnabled(int locationMethod, out bool status);

        [DllImport(Libraries.Location, EntryPoint = "location_manager_is_supported_method")]
        internal static extern bool IsSupported(int locationMethod);
    }

    internal static partial class Location
    {
        [DllImport(Libraries.Location, EntryPoint = "location_manager_get_distance")]
        internal static extern int GetDistanceBetween(double startLatitude, double startLongitude, double endLatitude, double endLongitude, out double distance);
    }

    internal static partial class LocatorEvent
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ServiceStatechangedCallback(ServiceState state, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ZonechangedCallback(BoundaryState state, double latitude, double longitude, double altitude, int timesatmp, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void SettingchangedCallback(LocationType method, bool enable, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void LocationchangedCallback(double latitude, double longitude, double altitude, double speed, double direction, double horizontalAcc, int timeStamp, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void LocationUpdatedCallback(LocationError error, double latitude, double longitude, double altitude, int timestamp, double speed, double direction, double climb, IntPtr userData);

        [DllImport(Libraries.Location, EntryPoint = "location_manager_set_service_state_changed_cb")]
        internal static extern int SetServiceStateChangedCallback(IntPtr handle, ServiceStatechangedCallback callback, IntPtr userData);

        [DllImport(Libraries.Location, EntryPoint = "location_manager_unset_service_state_changed_cb")]
        internal static extern int UnSetServiceStateChangedCallback(IntPtr handle);

        [DllImport(Libraries.Location, EntryPoint = "location_manager_set_zone_changed_cb")]
        internal static extern int SetZoneChangedCallback(IntPtr handle, ZonechangedCallback callback, IntPtr userData);

        [DllImport(Libraries.Location, EntryPoint = "location_manager_unset_zone_changed_cb")]
        internal static extern int UnSetZoneChangedCallback(IntPtr handle);

        [DllImport(Libraries.Location, EntryPoint = "location_manager_set_setting_changed_cb")]
        internal static extern int SetSettingChangedCallback(int method, SettingchangedCallback callback, IntPtr userData);

        [DllImport(Libraries.Location, EntryPoint = "location_manager_unset_setting_changed_cb")]
        internal static extern int UnSetSettingChangedCallback(int method);

        [DllImport(Libraries.Location, EntryPoint = "location_manager_set_distance_based_location_changed_cb")]
        internal static extern int SetDistanceBasedLocationChangedCallback(IntPtr handle, LocationchangedCallback callback, int interval, double distance, IntPtr userData);

        [DllImport(Libraries.Location, EntryPoint = "location_manager_unset_distance_based_location_changed_cb")]
        internal static extern int UnSetDistanceBasedLocationChangedCallback(IntPtr handle);

        [DllImport(Libraries.Location, EntryPoint = "location_manager_set_location_changed_cb")]
        internal static extern int SetLocationChangedCallback(IntPtr handle, LocationchangedCallback callback, int interval, IntPtr userData);

        [DllImport(Libraries.Location, EntryPoint = "location_manager_unset_location_changed_cb")]
        internal static extern int UnSetLocationChangedCallback(IntPtr handle);

        [DllImport(Libraries.Location, EntryPoint = "location_manager_request_single_location")]
        internal static extern int GetSingleLocation(IntPtr handle, int timeout, LocationUpdatedCallback callback, IntPtr userData);
    }

    internal static partial class LocationBoundary
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool PolygonCoordinatesCallback(Coordinate coordinates, IntPtr userData);

        [DllImport(Libraries.Location, EntryPoint = "location_bounds_create_rect")]
        internal static extern int CreateRectangularBoundary(Coordinate topLeft, Coordinate bottomLeft, out IntPtr boundsHandle);

        [DllImport(Libraries.Location, EntryPoint = "location_bounds_create_circle")]
        internal static extern int CreateCircleBoundary(Coordinate center, double radius, out IntPtr boundsHandle);

        [DllImport(Libraries.Location, EntryPoint = "location_bounds_create_polygon")]
        internal static extern int CreatePolygonBoundary(IntPtr list, int listLength, out IntPtr boundsHandle);

        [DllImport(Libraries.Location, EntryPoint = "location_bounds_get_rect_coords")]
        internal static extern int GetRectangleCoordinates(IntPtr handle, out Coordinate topLeft, out Coordinate bottomRight);

        [DllImport(Libraries.Location, EntryPoint = "location_bounds_get_circle_coords")]
        internal static extern int GetCircleCoordinates(IntPtr handle, out Coordinate center, out double radius);

        [DllImport(Libraries.Location, EntryPoint = "location_bounds_foreach_polygon_coords")]
        internal static extern int GetForEachPolygonCoordinates(IntPtr handle, PolygonCoordinatesCallback callback, IntPtr userData);

        [DllImport(Libraries.Location, EntryPoint = "location_bounds_contains_coordinates")]
        internal static extern bool IsValidCoordinates(IntPtr handle, Coordinate coordinate);

        [DllImport(Libraries.Location, EntryPoint = "location_bounds_destroy")]
        internal static extern int DestroyBoundary(IntPtr handle);
    }

    internal static partial class GpsSatellite
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void SatelliteStatuschangedCallback(uint numActive, uint numInView, int timeStamp, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool SatelliteStatusinfomationCallback(uint azimuth, uint elevation, uint prn, uint snr, bool isActive, IntPtr userData);

        [DllImport(Libraries.Location, EntryPoint = "gps_status_get_nmea")]
        internal static extern int GetNMEAData(IntPtr handle, out string nmea);

        [DllImport(Libraries.Location, EntryPoint = "gps_status_get_satellite")]
        internal static extern int GetSatelliteStatus(IntPtr handle, out uint numberOfActive, out uint numberInView, out int timestamp);

        [DllImport(Libraries.Location, EntryPoint = "gps_status_set_satellite_updated_cb")]
        internal static extern int SetSatelliteStatusChangedCallback(IntPtr handle, SatelliteStatuschangedCallback callback, int interval, IntPtr userData);

        [DllImport(Libraries.Location, EntryPoint = "gps_status_unset_satellite_updated_cb")]
        internal static extern int UnSetSatelliteStatusChangedCallback(IntPtr handle);

        [DllImport(Libraries.Location, EntryPoint = "gps_status_foreach_satellites_in_view")]
        internal static extern int GetForEachSatelliteInView(IntPtr handle, SatelliteStatusinfomationCallback callback, IntPtr userData);
    }

    internal static DateTime ConvertDateTime(int timestamp)
    {
        DateTime dateTime = DateTime.Now;

        DateTime start = DateTime.SpecifyKind(new DateTime(1970, 1, 1).AddSeconds(timestamp), DateTimeKind.Utc);
        dateTime = start.ToLocalTime();

        return dateTime;
    }
}
