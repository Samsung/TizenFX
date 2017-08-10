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
    [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_overlay_set_coordinates")]
    internal static extern ErrorCode SetCoordinates(this OverlayHandle /* maps_view_object_h */ overlay, CoordinatesHandle /* maps_coordinates_h */ coordinates);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_overlay_get_coordinates")]
    internal static extern ErrorCode GetCoordinates(this OverlayHandle /* maps_view_object_h */ overlay, out IntPtr /* maps_coordinates_h */ coordinates);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_overlay_set_min_zoom_level")]
    internal static extern ErrorCode SetMinZoomLevel(this OverlayHandle /* maps_view_object_h */ overlay, int zoom);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_overlay_get_min_zoom_level")]
    internal static extern ErrorCode GetMinZoomLevel(this OverlayHandle /* maps_view_object_h */ overlay, out int zoom);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_overlay_set_max_zoom_level")]
    internal static extern ErrorCode SetMaxZoomLevel(this OverlayHandle /* maps_view_object_h */ overlay, int zoom);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_overlay_get_max_zoom_level")]
    internal static extern ErrorCode GetMaxZoomLevel(this OverlayHandle /* maps_view_object_h */ overlay, out int zoom);

    internal class OverlayHandle : ViewObjectHandle
    {
        [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_create_overlay")]
        internal static extern ErrorCode CreateOverlay(CoordinatesHandle /* maps_coordinates_h */ coordinates, IntPtr viewObject, ViewOverlayType /* maps_view_overlay_type_e */ type, out IntPtr /* maps_view_object_h */ overlay);

        internal int MinZoomLevel
        {
            get { return NativeGet<int>(this.GetMinZoomLevel); }
            set { NativeSet(this.SetMinZoomLevel, value); }
        }

        internal int MaxZoomLevel
        {
            get { return NativeGet<int>(this.GetMaxZoomLevel); }
            set { NativeSet(this.SetMaxZoomLevel, value); }
        }


        internal CoordinatesHandle Coordinates
        {
            get { return NativeGet(this.GetCoordinates, CoordinatesHandle.Create); }
            set { NativeSet(this.SetCoordinates, value); }
        }

        internal OverlayHandle(CoordinatesHandle coordinates, EvasObject viewObject, ViewOverlayType type) : base(IntPtr.Zero, true)
        {
            var clonedCoordinatesHandle = CoordinatesHandle.CloneFrom(coordinates);
            CreateOverlay(clonedCoordinatesHandle, viewObject, type, out handle).ThrowIfFailed("Failed to create native overlay handle");
            clonedCoordinatesHandle.HasOwnership = false;
        }
    }
}
