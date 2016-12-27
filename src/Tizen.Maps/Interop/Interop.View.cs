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
    internal enum ViewType
    {
        Normal, // MAPS_VIEW_TYPE_NORMAL
        Satellite, // MAPS_VIEW_TYPE_SATELLITE
        Terrain, // MAPS_VIEW_TYPE_TERRAIN
        Hybrid, // MAPS_VIEW_TYPE_HYBRID
    }

    internal static partial class View
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ViewOnEventCallback(ViewEventType /* maps_view_event_type_e */ type, IntPtr /* maps_view_event_data_h */ eventData, IntPtr /* void */ userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool ViewObjectCallback(int index, int total, IntPtr /* maps_view_object_h */ viewObject, IntPtr /* void */ userData);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_create")]
        internal static extern ErrorCode Create(ServiceHandle /* maps_service_h */ maps, IntPtr obj, out IntPtr /* maps_view_h */ view);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_destroy")]
        internal static extern ErrorCode Destroy(IntPtr /* maps_view_h */ view);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_set_center")]
        internal static extern ErrorCode SetCenter(ViewHandle /* maps_view_h */ view, CoordinatesHandle /* maps_coordinates_h */ coordinates);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_get_center")]
        internal static extern ErrorCode GetCenter(ViewHandle /* maps_view_h */ view, out IntPtr /* maps_coordinates_h */ coordinates);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_set_zoom_level")]
        internal static extern ErrorCode SetZoomLevel(ViewHandle /* maps_view_h */ view, int level);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_get_zoom_level")]
        internal static extern ErrorCode GetZoomLevel(ViewHandle /* maps_view_h */ view, out int level);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_set_min_zoom_level")]
        internal static extern ErrorCode SetMinZoomLevel(ViewHandle /* maps_view_h */ view, int level);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_get_min_zoom_level")]
        internal static extern ErrorCode GetMinZoomLevel(ViewHandle /* maps_view_h */ view, out int minZoomLevel);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_set_max_zoom_level")]
        internal static extern ErrorCode SetMaxZoomLevel(ViewHandle /* maps_view_h */ view, int level);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_get_max_zoom_level")]
        internal static extern ErrorCode GetMaxZoomLevel(ViewHandle /* maps_view_h */ view, out int maxZoomLevel);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_set_orientation")]
        internal static extern ErrorCode SetOrientation(ViewHandle /* maps_view_h */ view, double angle);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_get_orientation")]
        internal static extern ErrorCode GetOrientation(ViewHandle /* maps_view_h */ view, out double rotationAngle);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_screen_to_geolocation")]
        internal static extern ErrorCode ScreenToGeolocation(ViewHandle /* maps_view_h */ view, int x, int y, out IntPtr /* maps_coordinates_h */ coordinates);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_geolocation_to_screen")]
        internal static extern ErrorCode GeolocationToScreen(ViewHandle /* maps_view_h */ view, CoordinatesHandle /* maps_coordinates_h */ coordinates, out int x, out int y);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_set_type")]
        internal static extern ErrorCode SetType(ViewHandle /* maps_view_h */ view, ViewType /* maps_view_type_e */ type);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_get_type")]
        internal static extern ErrorCode GetType(ViewHandle /* maps_view_h */ view, out ViewType /* maps_view_type_e */ type);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_set_buildings_enabled")]
        internal static extern ErrorCode SetBuildingsEnabled(ViewHandle /* maps_view_h */ view, bool enable);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_get_buildings_enabled")]
        internal static extern ErrorCode GetBuildingsEnabled(ViewHandle /* maps_view_h */ view, out bool enable);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_set_traffic_enabled")]
        internal static extern ErrorCode SetTrafficEnabled(ViewHandle /* maps_view_h */ view, bool enable);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_get_traffic_enabled")]
        internal static extern ErrorCode GetTrafficEnabled(ViewHandle /* maps_view_h */ view, out bool enable);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_set_public_transit_enabled")]
        internal static extern ErrorCode SetPublicTransitEnabled(ViewHandle /* maps_view_h */ view, bool enable);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_get_public_transit_enabled")]
        internal static extern ErrorCode GetPublicTransitEnabled(ViewHandle /* maps_view_h */ view, out bool enable);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_set_language")]
        internal static extern ErrorCode SetLanguage(ViewHandle /* maps_view_h */ view, string language);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_get_language")]
        internal static extern ErrorCode GetLanguage(ViewHandle /* maps_view_h */ view, out string language);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_set_scalebar_enabled")]
        internal static extern ErrorCode SetScalebarEnabled(ViewHandle /* maps_view_h */ view, bool enable);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_get_scalebar_enabled")]
        internal static extern ErrorCode GetScalebarEnabled(ViewHandle /* maps_view_h */ view, out bool enabled);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_get_viewport")]
        internal static extern ErrorCode GetViewport(ViewHandle /* maps_view_h */ view, out IntPtr viewport);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_set_screen_location")]
        internal static extern ErrorCode SetScreenLocation(ViewHandle /* maps_view_h */ view, int x, int y, int width, int height);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_get_screen_location")]
        internal static extern ErrorCode GetScreenLocation(ViewHandle /* maps_view_h */ view, out int x, out int y, out int width, out int height);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_move")]
        internal static extern ErrorCode Move(ViewHandle /* maps_view_h */ view, int x, int y);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_resize")]
        internal static extern ErrorCode Resize(ViewHandle /* maps_view_h */ view, int width, int height);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_set_visibility")]
        internal static extern ErrorCode SetVisibility(ViewHandle /* maps_view_h */ view, bool visible);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_get_visibility")]
        internal static extern ErrorCode GetVisibility(ViewHandle /* maps_view_h */ view, out bool visible);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_set_event_cb")]
        internal static extern ErrorCode SetEventCb(ViewHandle /* maps_view_h */ view, ViewEventType /* maps_view_event_type_e */ type, ViewOnEventCallback callback, IntPtr /* void */ userData);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_unset_event_cb")]
        internal static extern ErrorCode UnsetEventCb(ViewHandle /* maps_view_h */ view, ViewEventType /* maps_view_event_type_e */ type);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_set_gesture_enabled")]
        internal static extern ErrorCode SetGestureEnabled(ViewHandle /* maps_view_h */ view, ViewGesture /* maps_view_gesture_e */ gesture, bool enabled);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_get_gesture_enabled")]
        internal static extern ErrorCode GetGestureEnabled(ViewHandle /* maps_view_h */ view, ViewGesture /* maps_view_gesture_e */ gesture, out bool enabled);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_add_object")]
        internal static extern ErrorCode AddObject(ViewHandle /* maps_view_h */ view, ViewObjectHandle /* maps_view_object_h */ viewObject);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_remove_object")]
        internal static extern ErrorCode RemoveObject(ViewHandle /* maps_view_h */ view, ViewObjectHandle /* maps_view_object_h */ viewObject);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_remove_all_objects")]
        internal static extern ErrorCode RemoveAllObjects(ViewHandle /* maps_view_h */ view);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_foreach_object")]
        internal static extern ErrorCode ForeachObject(ViewHandle /* maps_view_h */ view, ViewObjectCallback callback, IntPtr /* void */ userData);
    }

    internal class ViewHandle : SafeMapsHandle
    {
        public ViewHandle(IntPtr handle, bool ownsHandle = true) : base(handle, ownsHandle) { Destroy = View.Destroy; }
    }
}
