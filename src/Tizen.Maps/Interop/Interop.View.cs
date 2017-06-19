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
using ElmSharp;

internal static partial class Interop
{
    internal enum ViewType
    {
        Normal, // MAPS_VIEW_TYPE_NORMAL
        Satellite, // MAPS_VIEW_TYPE_SATELLITE
        Terrain, // MAPS_VIEW_TYPE_TERRAIN
        Hybrid, // MAPS_VIEW_TYPE_HYBRID
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void ViewOnEventCallback(ViewEventType /* maps_view_event_type_e */ type, IntPtr /* maps_view_event_data_h */ eventData, IntPtr /* void */ userData);


    [DllImport(Libraries.MapService, EntryPoint = "maps_view_get_zoom_level")]
    internal static extern ErrorCode GetZoomLevel(this ViewHandle /* maps_view_h */ view, out int level);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_set_zoom_level")]
    internal static extern ErrorCode SetZoomLevel(this ViewHandle /* maps_view_h */ view, int level);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_get_min_zoom_level")]
    internal static extern ErrorCode GetMinZoomLevel(this ViewHandle /* maps_view_h */ view, out int minZoomLevel);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_set_min_zoom_level")]
    internal static extern ErrorCode SetMinZoomLevel(this ViewHandle /* maps_view_h */ view, int minZoomLevel);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_get_max_zoom_level")]
    internal static extern ErrorCode GetMaxZoomLevel(this ViewHandle /* maps_view_h */ view, out int maxZoomLevel);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_set_max_zoom_level")]
    internal static extern ErrorCode SetMaxZoomLevel(this ViewHandle /* maps_view_h */ view, int maxZoomLevel);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_get_orientation")]
    internal static extern ErrorCode GetOrientation(this ViewHandle /* maps_view_h */ view, out double rotationAngle);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_set_orientation")]
    internal static extern ErrorCode SetOrientation(this ViewHandle /* maps_view_h */ view, double rotationAngle);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_get_language")]
    internal static extern ErrorCode GetLanguage(this ViewHandle /* maps_view_h */ view, out string language);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_set_language")]
    internal static extern ErrorCode SetLanguage(this ViewHandle /* maps_view_h */ view, string language);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_set_type")]
    internal static extern ErrorCode SetMapType(this ViewHandle /* maps_view_h */ view, ViewType /* maps_view_type_e */ type);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_get_type")]
    internal static extern ErrorCode GetMapType(this ViewHandle /* maps_view_h */ view, out ViewType /* maps_view_type_e */ type);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_get_buildings_enabled")]
    internal static extern ErrorCode GetBuildingsEnabled(this ViewHandle /* maps_view_h */ view, out bool enable);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_set_buildings_enabled")]
    internal static extern ErrorCode SetBuildingsEnabled(this ViewHandle /* maps_view_h */ view, bool enable);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_get_traffic_enabled")]
    internal static extern ErrorCode GetTrafficEnabled(this ViewHandle /* maps_view_h */ view, out bool enable);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_set_traffic_enabled")]
    internal static extern ErrorCode SetTrafficEnabled(this ViewHandle /* maps_view_h */ view, bool enable);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_get_public_transit_enabled")]
    internal static extern ErrorCode GetPublicTransitEnabled(this ViewHandle /* maps_view_h */ view, out bool enable);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_set_public_transit_enabled")]
    internal static extern ErrorCode SetPublicTransitEnabled(this ViewHandle /* maps_view_h */ view, bool enable);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_get_scalebar_enabled")]
    internal static extern ErrorCode GetScaleBarEnabled(this ViewHandle /* maps_view_h */ view, out bool enabled);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_set_scalebar_enabled")]
    internal static extern ErrorCode SetScaleBarEnabled(this ViewHandle /* maps_view_h */ view, bool enable);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_get_screen_location")]
    internal static extern ErrorCode GetScreenLocation(this ViewHandle /* maps_view_h */ view, out int x, out int y, out int width, out int height);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_set_screen_location")]
    internal static extern ErrorCode SetScreenLocation(this ViewHandle /* maps_view_h */ view, int x, int y, int width, int height);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_get_visibility")]
    internal static extern ErrorCode GetVisibility(this ViewHandle /* maps_view_h */ view, out bool visible);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_set_visibility")]
    internal static extern ErrorCode SetVisibility(this ViewHandle /* maps_view_h */ view, bool visible);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_get_viewport")]
    internal static extern ErrorCode GetViewport(this ViewHandle /* maps_view_h */ view, out IntPtr viewport);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_get_center")]
    internal static extern ErrorCode GetCenter(this ViewHandle /* maps_view_h */ view, out IntPtr /* maps_coordinates_h */ coordinates);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_set_center")]
    internal static extern ErrorCode SetCenter(this ViewHandle /* maps_view_h */ view, CoordinatesHandle /* maps_coordinates_h */ coordinates);


    [DllImport(Libraries.MapService, EntryPoint = "maps_view_get_gesture_enabled")]
    internal static extern ErrorCode GetGestureEnabled(this ViewHandle /* maps_view_h */ view, ViewGesture /* maps_view_gesture_e */ gesture, out bool enabled);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_set_gesture_enabled")]
    internal static extern ErrorCode SetGestureEnabled(this ViewHandle /* maps_view_h */ view, ViewGesture /* maps_view_gesture_e */ gesture, bool enabled);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_set_event_cb")]
    internal static extern ErrorCode SetEventCb(this ViewHandle /* maps_view_h */ view, ViewEventType /* maps_view_event_type_e */ type, ViewOnEventCallback callback, IntPtr /* void */ userData);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_unset_event_cb")]
    internal static extern ErrorCode UnsetEventCb(this ViewHandle /* maps_view_h */ view, ViewEventType /* maps_view_event_type_e */ type);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_screen_to_geolocation")]
    internal static extern ErrorCode ScreenToGeolocation(this ViewHandle /* maps_view_h */ view, int x, int y, out IntPtr /* maps_coordinates_h */ coordinates);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_geolocation_to_screen")]
    internal static extern ErrorCode GeolocationToScreen(this ViewHandle /* maps_view_h */ view, CoordinatesHandle /* maps_coordinates_h */ coordinates, out int x, out int y);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_move")]
    internal static extern ErrorCode Move(this ViewHandle /* maps_view_h */ view, int x, int y);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_resize")]
    internal static extern ErrorCode Resize(this ViewHandle /* maps_view_h */ view, int width, int height);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_add_object")]
    internal static extern ErrorCode AddObject(this ViewHandle /* maps_view_h */ view, ViewObjectHandle /* maps_view_object_h */ viewObject);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_remove_object")]
    internal static extern ErrorCode RemoveObject(this ViewHandle /* maps_view_h */ view, ViewObjectHandle /* maps_view_object_h */ viewObject);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_remove_all_objects")]
    internal static extern ErrorCode RemoveAllObjects(this ViewHandle /* maps_view_h */ view);

    internal class ViewHandle : SafeMapsHandle
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool ViewObjectCallback(int index, int total, IntPtr /* maps_view_object_h */ viewObject, IntPtr /* void */ userData);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_foreach_object")]
        internal static extern ErrorCode ForeachObject(ViewHandle /* maps_view_h */ view, ViewObjectCallback callback, IntPtr /* void */ userData);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_create")]
        internal static extern ErrorCode Create(ServiceHandle /* maps_service_h */ maps, IntPtr obj, out IntPtr /* maps_view_h */ view);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_destroy")]
        internal static extern ErrorCode Destroy(IntPtr /* maps_view_h */ view);

        internal int ZoomLevel
        {
            get { return NativeGet<int>(this.GetZoomLevel); }
            set { NativeSet(this.SetZoomLevel, value); }
        }

        internal int MinimumZoomLevel
        {
            get { return NativeGet<int>(this.GetMinZoomLevel); }
            set { NativeSet(this.SetMinZoomLevel, value); }
        }

        internal int MaximumZoomLevel
        {
            get { return NativeGet<int>(this.GetMaxZoomLevel); }
            set { NativeSet(this.SetMaxZoomLevel, value); }
        }

        internal double Orientation
        {
            get { return NativeGet<double>(this.GetOrientation); }
            set { NativeSet(this.SetOrientation, value); }
        }

        internal ViewType MapType
        {
            get { return NativeGet<ViewType>(this.GetMapType); }
            set { NativeSet(this.SetMapType, value); }
        }

        internal bool BuildingsEnabled
        {
            get { return NativeGet<bool>(this.GetBuildingsEnabled); }
            set { NativeSet(this.SetBuildingsEnabled, value); }
        }

        internal bool TrafficEnabled
        {
            get { return NativeGet<bool>(this.GetTrafficEnabled); }
            set { NativeSet(this.SetTrafficEnabled, value); }
        }

        internal bool PublicTransitEnabled
        {
            get { return NativeGet<bool>(this.GetPublicTransitEnabled); }
            set { NativeSet(this.SetPublicTransitEnabled, value); }
        }
        internal bool ScaleBarEnabled
        {
            get { return NativeGet<bool>(this.GetScaleBarEnabled); }
            set { NativeSet(this.SetScaleBarEnabled, value); }
        }

        internal string Language
        {
            get { return NativeGet(this.GetLanguage); }
            set { NativeSet(this.SetLanguage, value); }
        }

        internal bool IsVisible
        {
            get { return NativeGet<bool>(this.GetVisibility); }
            set { NativeSet(this.SetVisibility, value); }
        }

        internal CoordinatesHandle Center
        {
            get { return NativeGet(this.GetCenter, CoordinatesHandle.Create); }
            set { NativeSet(this.SetCenter, value); }
        }

        public ViewHandle(IntPtr handle, bool needToRelease) : base(handle, needToRelease, Destroy)
        {
        }

        public ViewHandle(ServiceHandle maps, IntPtr evasObject) : this(IntPtr.Zero, true)
        {
            Create(maps, evasObject, out handle).ThrowIfFailed("Failed to create native handle");
        }

        internal CoordinatesHandle ScreenToGeolocation(Point position)
        {
            IntPtr coordinates;
            this.ScreenToGeolocation(position.X, position.Y, out coordinates).WarnIfFailed("Failed to convert screen position to geocoordinates");
            return CoordinatesHandle.Create(coordinates);
        }

        internal Point GeolocationToScreen(CoordinatesHandle coordinates)
        {
            int x, y;
            this.GeolocationToScreen(coordinates, out x, out y).WarnIfFailed("Failed to convert geocoordinates to screen position");
            return new Point() { X = x, Y = y };
        }
    }
}
