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
    [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_marker_get_type")]
    internal static extern ErrorCode GetType(this MarkerHandle /* maps_view_object_h */ marker, out ViewMarkerType /* maps_view_marker_type_e */ type);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_marker_get_coordinates")]
    internal static extern ErrorCode GetCoordinates(this MarkerHandle /* maps_view_object_h */ marker, out IntPtr /* maps_coordinates_h */ coordinates);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_marker_set_coordinates")]
    internal static extern ErrorCode SetCoordinates(this MarkerHandle /* maps_view_object_h */ marker, CoordinatesHandle /* maps_coordinates_h */ coordinates);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_marker_get_image_file")]
    internal static extern ErrorCode GetImageFile(this MarkerHandle /* maps_view_object_h */ marker, out string filePath);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_marker_set_image_file")]
    internal static extern ErrorCode SetImageFile(this MarkerHandle /* maps_view_object_h */ marker, string filePath);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_marker_get_z_order")]
    internal static extern ErrorCode GetZOrder(this MarkerHandle /* maps_view_object_h */ marker, out int zOrder);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_marker_set_z_order")]
    internal static extern ErrorCode SetZOrder(this MarkerHandle /* maps_view_object_h */ marker, int zOrder);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_marker_get_size")]
    internal static extern ErrorCode GetSize(this MarkerHandle /* maps_view_object_h */ marker, out int width, out int height);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_marker_resize")]
    internal static extern ErrorCode Resize(this MarkerHandle /* maps_view_object_h */ marker, int width, int height);

    internal static ErrorCode GetSize(this MarkerHandle /* maps_view_object_h */ marker, out Size size)
    {
        size = new Size(0, 0);
        return GetSize(marker, out size.Width, out size.Height);
    }

    internal static ErrorCode SetSize(this MarkerHandle /* maps_view_object_h */ marker, Size size)
    {
        return Resize(marker, size.Width, size.Height);
    }

    internal class MarkerHandle : ViewObjectHandle
    {
        [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_create_marker")]
        internal static extern ErrorCode CreateMarker(CoordinatesHandle /* maps_coordinates_h */ coordinates, string imageFilePath, ViewMarkerType /* maps_view_marker_type_e */ type, out IntPtr /* maps_view_object_h */ marker);

        internal ViewMarkerType Type
        {
            get { return NativeGet<ViewMarkerType>(this.GetType); }
        }

        internal string ImageFile
        {
            get { return NativeGet(this.GetImageFile); }
            set { NativeSet(this.SetImageFile, value); }
        }

        internal int ZOrder
        {
            get { return NativeGet<int>(this.GetZOrder); }
            set { NativeSet(this.SetZOrder, value); }
        }

        internal Size MarkerSize
        {
            get { return NativeGet<Size>(this.GetSize); }
            set { NativeSet(this.SetSize, value); }
        }

        internal CoordinatesHandle Coordinates
        {
            get { return NativeGet(this.GetCoordinates, CoordinatesHandle.Create); }
            set { NativeSet(this.SetCoordinates, value); }
        }

        internal MarkerHandle(CoordinatesHandle coordinates, string imagePath, ViewMarkerType type) : base(IntPtr.Zero, true)
        {
            var clonedCoordinatesHandle = CoordinatesHandle.CloneFrom(coordinates);
            CreateMarker(clonedCoordinatesHandle, imagePath, type, out handle).ThrowIfFailed("Failed to create native handle for marker");
            clonedCoordinatesHandle.HasOwnership = false;
        }
    }
}
