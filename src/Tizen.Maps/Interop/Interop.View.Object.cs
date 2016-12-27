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
    internal enum ViewObjectType
    {
        Polyline, // MAPS_VIEW_OBJECT_POLYLINE
        Polygon, // MAPS_VIEW_OBJECT_POLYGON
        Marker, // MAPS_VIEW_OBJECT_MARKER
        Overlay, // MAPS_VIEW_OBJECT_OVERLAY
    }

    internal enum ViewMarkerType
    {
        Pin, // MAPS_VIEW_MARKER_PIN
        Sticker, // MAPS_VIEW_MARKER_STICKER
    }

    internal enum ViewOverlayType
    {
        Normal, // MAPS_VIEW_OVERLAY_NORMAL
        Bubble, // MAPS_VIEW_OVERLAY_BUBBLE
        Box, // MAPS_VIEW_OVERLAY_BOX
    }

    internal static partial class ViewObject
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool CoordinatesCallback(int index, IntPtr /* maps_coordinates_h */ coordinates, IntPtr /* void */ userData);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_create_marker")]
        internal static extern ErrorCode CreateMarker(CoordinatesHandle /* maps_coordinates_h */ coordinates, string imageFilePath, ViewMarkerType /* maps_view_marker_type_e */ type, out IntPtr /* maps_view_object_h */ marker);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_create_polyline")]
        internal static extern ErrorCode CreatePolyline(CoordinatesListHandle /* maps_coordinates_list_h */ coordinates, byte r, byte g, byte b, byte a, int width, out IntPtr /* maps_view_object_h */ polyline);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_create_polygon")]
        internal static extern ErrorCode CreatePolygon(CoordinatesListHandle /* maps_coordinates_list_h */ coordinates, byte r, byte g, byte b, byte a, out IntPtr /* maps_view_object_h */ polygon);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_create_overlay")]
        internal static extern ErrorCode CreateOverlay(CoordinatesHandle /* maps_coordinates_h */ coordinates, IntPtr viewObject, ViewOverlayType /* maps_view_overlay_type_e */ type, out IntPtr /* maps_view_object_h */ overlay);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_destroy")]
        internal static extern ErrorCode Destroy(IntPtr /* maps_view_object_h */ viewObject);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_get_type")]
        internal static extern ErrorCode GetType(ViewObjectHandle /* maps_view_object_h */ viewObject, out ViewObjectType /* maps_view_object_type_e */ type);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_set_visible")]
        internal static extern ErrorCode SetVisible(ViewObjectHandle /* maps_view_object_h */ viewObject, bool visible);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_get_visible")]
        internal static extern ErrorCode GetVisible(ViewObjectHandle /* maps_view_object_h */ viewObject, out bool visible);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_polyline_set_polyline")]
        internal static extern ErrorCode PolylineSetPolyline(ViewObjectHandle /* maps_view_object_h */ polyline, CoordinatesListHandle /* maps_coordinates_list_h */ points);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_polyline_foreach_point")]
        internal static extern ErrorCode PolylineForeachPoint(ViewObjectHandle /* maps_view_object_h */ polyline, CoordinatesCallback callback, IntPtr /* void */ userData);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_polyline_set_color")]
        internal static extern ErrorCode PolylineSetColor(ViewObjectHandle /* maps_view_object_h */ polyline, byte r, byte g, byte b, byte a);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_polyline_get_color")]
        internal static extern ErrorCode PolylineGetColor(ViewObjectHandle /* maps_view_object_h */ polyline, out byte r, out byte g, out byte b, out byte a);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_polyline_set_width")]
        internal static extern ErrorCode PolylineSetWidth(ViewObjectHandle /* maps_view_object_h */ polyline, int width);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_polyline_get_width")]
        internal static extern ErrorCode PolylineGetWidth(ViewObjectHandle /* maps_view_object_h */ polyline, out int width);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_polygon_set_polygon")]
        internal static extern ErrorCode PolygonSetPolygon(ViewObjectHandle /* maps_view_object_h */ polygon, CoordinatesListHandle /* maps_coordinates_list_h */ points);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_polygon_foreach_point")]
        internal static extern ErrorCode PolygonForeachPoint(ViewObjectHandle /* maps_view_object_h */ polygon, CoordinatesCallback callback, IntPtr /* void */ userData);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_polygon_set_fill_color")]
        internal static extern ErrorCode PolygonSetFillColor(ViewObjectHandle /* maps_view_object_h */ polygon, byte r, byte g, byte b, byte a);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_polygon_get_fill_color")]
        internal static extern ErrorCode PolygonGetFillColor(ViewObjectHandle /* maps_view_object_h */ polygon, out byte r, out byte g, out byte b, out byte a);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_marker_set_coordinates")]
        internal static extern ErrorCode MarkerSetCoordinates(ViewObjectHandle /* maps_view_object_h */ marker, CoordinatesHandle /* maps_coordinates_h */ coordinates);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_marker_resize")]
        internal static extern ErrorCode MarkerResize(ViewObjectHandle /* maps_view_object_h */ marker, int width, int height);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_marker_set_image_file")]
        internal static extern ErrorCode MarkerSetImageFile(ViewObjectHandle /* maps_view_object_h */ marker, string filePath);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_marker_get_image_file")]
        internal static extern ErrorCode MarkerGetImageFile(ViewObjectHandle /* maps_view_object_h */ marker, out string filePath);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_marker_get_coordinates")]
        internal static extern ErrorCode MarkerGetCoordinates(ViewObjectHandle /* maps_view_object_h */ marker, out IntPtr /* maps_coordinates_h */ coordinates);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_marker_get_size")]
        internal static extern ErrorCode MarkerGetSize(ViewObjectHandle /* maps_view_object_h */ marker, out int width, out int height);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_marker_get_type")]
        internal static extern ErrorCode MarkerGetType(ViewObjectHandle /* maps_view_object_h */ marker, out ViewMarkerType /* maps_view_marker_type_e */ type);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_marker_set_z_order")]
        internal static extern ErrorCode MarkerSetZOrder(ViewObjectHandle /* maps_view_object_h */ marker, int zOrder);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_marker_get_z_order")]
        internal static extern ErrorCode MarkerGetZOrder(ViewObjectHandle /* maps_view_object_h */ marker, out int zOrder);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_overlay_get_object")]
        internal static extern ErrorCode OverlayGetObject(ViewObjectHandle /* maps_view_object_h */ overlay, out IntPtr viewObject);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_overlay_set_coordinates")]
        internal static extern ErrorCode OverlaySetCoordinates(ViewObjectHandle /* maps_view_object_h */ overlay, CoordinatesHandle /* maps_coordinates_h */ coordinates);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_overlay_get_coordinates")]
        internal static extern ErrorCode OverlayGetCoordinates(ViewObjectHandle /* maps_view_object_h */ overlay, out IntPtr /* maps_coordinates_h */ coordinates);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_overlay_set_min_zoom_level")]
        internal static extern ErrorCode OverlaySetMinZoomLevel(ViewObjectHandle /* maps_view_object_h */ overlay, int zoom);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_overlay_get_min_zoom_level")]
        internal static extern ErrorCode OverlayGetMinZoomLevel(ViewObjectHandle /* maps_view_object_h */ overlay, out int zoom);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_overlay_set_max_zoom_level")]
        internal static extern ErrorCode OverlaySetMaxZoomLevel(ViewObjectHandle /* maps_view_object_h */ overlay, int zoom);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_overlay_get_max_zoom_level")]
        internal static extern ErrorCode OverlayGetMaxZoomLevel(ViewObjectHandle /* maps_view_object_h */ overlay, out int zoom);
    }

    internal class ViewObjectHandle : SafeMapsHandle
    {
        public ViewObjectHandle(IntPtr handle, bool ownsHandle = true) : base(handle, ownsHandle) { Destroy = ViewObject.Destroy; }
    }
}
