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

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_get_type")]
    internal static extern ErrorCode GetType(this ViewObjectHandle /* maps_view_object_h */ viewObject, out ViewObjectType /* maps_view_object_type_e */ type);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_set_visible")]
    internal static extern ErrorCode SetVisible(this ViewObjectHandle /* maps_view_object_h */ viewObject, bool visible);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_get_visible")]
    internal static extern ErrorCode GetVisible(this ViewObjectHandle /* maps_view_object_h */ viewObject, out bool visible);

    internal class ViewObjectHandle : SafeMapsHandle
    {
        [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_destroy")]
        internal static extern ErrorCode Destroy(IntPtr /* maps_view_object_h */ viewObject);

        internal bool IsVisible
        {
            get { return NativeGet<bool>(this.GetVisible); }
            set { NativeSet(this.SetVisible, value); }
        }

        public ViewObjectHandle(IntPtr handle, bool needToRelease) : base(handle, needToRelease, Destroy)
        {
        }

        internal static ViewObjectHandle Create(IntPtr nativeHandle)
        {
            return new ViewObjectHandle(nativeHandle, true);
        }
    }
}
