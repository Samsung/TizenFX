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
using Tizen.Location.Geofence;

internal static partial class Interop
{
    internal static partial class Geofence
    {
        [DllImport(Libraries.Geofence, EntryPoint = "geofence_create_geopoint")]
        public static extern int CreateGPSFence(int placeId, double latitude, double longitude, int radius, string address, out IntPtr handle);

        [DllImport(Libraries.Geofence, EntryPoint = "geofence_create_bluetooth")]
        public static extern int CreateBTFence(int placeId, string bssid, string ssid, out IntPtr handle);

        [DllImport(Libraries.Geofence, EntryPoint = "geofence_create_wifi")]
        public static extern int CreateWiFiFence(int placeId, string bssid, string ssid, out IntPtr handle);

        [DllImport(Libraries.Geofence, EntryPoint = "geofence_destroy")]
        public static extern int Destroy(IntPtr handle);

        [DllImport(Libraries.Geofence, EntryPoint = "geofence_status_create")]
        public static extern int CreateFenceStatus(int placeId, out IntPtr statusHandle);

        [DllImport(Libraries.Geofence, EntryPoint = "geofence_status_destroy")]
        public static extern int ReleaseFenceStatus(IntPtr statusHandle);

        [DllImport(Libraries.Geofence, EntryPoint = "geofence_get_type")]
        public static extern int FenceType(IntPtr handle, out FenceType type);

        [DllImport(Libraries.Geofence, EntryPoint = "geofence_get_place_id")]
        public static extern int FencePlaceID(IntPtr handle, out int placeId);

        [DllImport(Libraries.Geofence, EntryPoint = "geofence_get_latitude")]
        public static extern int FenceLatitude(IntPtr handle, out double latitude);

        [DllImport(Libraries.Geofence, EntryPoint = "geofence_get_longitude")]
        public static extern int FenceLongitude(IntPtr handle, out double longitude);

        [DllImport(Libraries.Geofence, EntryPoint = "geofence_get_radius")]
        public static extern int FenceRadius(IntPtr handle, out int radius);

        [DllImport(Libraries.Geofence, EntryPoint = "geofence_get_address")]
        public static extern int FenceAddress(IntPtr handle, out string address);

        [DllImport(Libraries.Geofence, EntryPoint = "geofence_get_bssid")]
        public static extern int FenceBSSID(IntPtr handle, out string bssid);

        [DllImport(Libraries.Geofence, EntryPoint = "geofence_get_ssid")]
        public static extern int FenceSSID(IntPtr handle, out string ssid);

        [DllImport(Libraries.Geofence, EntryPoint = "geofence_status_get_state")]
        public static extern int FenceState(IntPtr statusHandle, out GeofenceState state);

        [DllImport(Libraries.Geofence, EntryPoint = "geofence_status_get_duration")]
        public static extern int FenceDuration(IntPtr statusHandle, out int seconds);

    }

    internal static partial class GeofenceManager
    {
        public delegate bool StateChangedCallback(int fenceId,GeofenceState state,IntPtr userData);

        [DllImport(Libraries.Geofence, EntryPoint = "geofence_manager_is_supported")]
        public static extern int IsSupported(out bool supported);

        [DllImport(Libraries.Geofence, EntryPoint = "geofence_manager_create")]
        public static extern int Create(out IntPtr handle);

        [DllImport(Libraries.Geofence, EntryPoint = "geofence_manager_destroy")]
        public static extern int Destroy(IntPtr handle);

        [DllImport(Libraries.Geofence, EntryPoint = "geofence_manager_start")]
        public static extern int Start(IntPtr handle, int fenceId);

        [DllImport(Libraries.Geofence, EntryPoint = "geofence_manager_stop")]
        public static extern int Stop(IntPtr handle, int fenceId);

        [DllImport(Libraries.Geofence, EntryPoint = "geofence_manager_set_geofence_state_changed_cb")]
        public static extern int SetStateChangedCB(IntPtr handle, StateChangedCallback callback, IntPtr userData);

        [DllImport(Libraries.Geofence, EntryPoint = "geofence_manager_unset_geofence_state_changed_cb")]
        public static extern int UnsetStateChangedCB(IntPtr handle);
    }

    internal static partial class VirtualPerimeter
    {
        public delegate bool ForEachPlaceListCallback(int placeId, string placeName, int placeIndex, int placeCount, IntPtr userData);

        public delegate bool ForEachFenceListCallback(int fenceId, IntPtr fenceHandle, int placeIndex, int placeCount, IntPtr userData);

        public delegate bool ProximityStateChangedCallback(int fenceId, ProximityState state, ProximityProvider provider, IntPtr userData);

        public delegate bool GeofenceEventCallback(int placeId,int fenceId, GeofenceError error, GeoFenceEventType eventType, IntPtr userData);

        [DllImport(Libraries.Geofence, EntryPoint = "geofence_manager_add_place")]
        public static extern int AddPlace(IntPtr handle, string placeName, out int placeId);

        [DllImport(Libraries.Geofence, EntryPoint = "geofence_manager_update_place")]
        public static extern int UpdatePlace(IntPtr handle, int placeId, string placeName);

        [DllImport(Libraries.Geofence, EntryPoint = "geofence_manager_remove_place")]
        public static extern int RemovePlace(IntPtr handle, int placeId);

        [DllImport(Libraries.Geofence, EntryPoint = "geofence_manager_add_fence")]
        public static extern int AddFence(IntPtr handle, IntPtr fenceHandle, out int fenceId);

        [DllImport(Libraries.Geofence, EntryPoint = "geofence_manager_remove_fence")]
        public static extern int RemoveFence(IntPtr handle, int fenceId);

        [DllImport(Libraries.Geofence, EntryPoint = "geofence_manager_set_geofence_event_cb")]
        public static extern int SetGeofenceEventCB(IntPtr handle, GeofenceEventCallback callback, IntPtr userData);

        [DllImport(Libraries.Geofence, EntryPoint = "geofence_manager_unset_geofence_event_cb")]
        public static extern int UnsetGeofenceEventCB(IntPtr handle);

        [DllImport(Libraries.Geofence, EntryPoint = "geofence_manager_set_geofence_proximity_state_changed_cb")]
        public static extern int SetProximityStateCB(IntPtr handle, ProximityStateChangedCallback callback, IntPtr userData);

        [DllImport(Libraries.Geofence, EntryPoint = "geofence_manager_unset_geofence_proximity_state_changed_cb")]
        public static extern int UnsetProximityStateCB(IntPtr handle);

        [DllImport(Libraries.Geofence, EntryPoint = "geofence_manager_foreach_geofence_list")]
        public static extern int GetForEachFenceList(IntPtr handle, ForEachFenceListCallback callback, IntPtr userData);

        [DllImport(Libraries.Geofence, EntryPoint = "geofence_manager_foreach_place_geofence_list")]
        public static extern int GetForEachPlaceFenceList(IntPtr handle,int placeId, ForEachFenceListCallback callback, IntPtr userData);

        [DllImport(Libraries.Geofence, EntryPoint = "geofence_manager_foreach_place_list")]
        public static extern int GetForEachPlaceList(IntPtr handle, ForEachPlaceListCallback callback, IntPtr userData);

        [DllImport(Libraries.Geofence, EntryPoint = "geofence_manager_get_place_name")]
        public static extern int GetPlaceName(IntPtr handle, int placeId, out string placeName);

    }
}
