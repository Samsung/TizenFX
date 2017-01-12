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
    [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_polyline_set_polyline")]
    internal static extern ErrorCode SetPolyline(this PolylineHandle /* maps_view_object_h */ polyline, CoordinatesListHandle /* maps_coordinates_list_h */ points);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_polyline_set_color")]
    internal static extern ErrorCode SetColor(this PolylineHandle /* maps_view_object_h */ polyline, byte r, byte g, byte b, byte a);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_polyline_get_color")]
    internal static extern ErrorCode GetColor(this PolylineHandle /* maps_view_object_h */ polyline, out byte r, out byte g, out byte b, out byte a);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_polyline_set_width")]
    internal static extern ErrorCode SetWidth(this PolylineHandle /* maps_view_object_h */ polyline, int width);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_polyline_get_width")]
    internal static extern ErrorCode GetWidth(this PolylineHandle /* maps_view_object_h */ polyline, out int width);

    internal static ErrorCode GetColor(this PolylineHandle /* maps_view_object_h */ polyline, out Color color)
    {
        byte r, g, b, a;
        var err = polyline.GetColor(out r, out g, out b, out a);
        color = new Color(r, g, b, a);
        return err;
    }

    internal static ErrorCode SetColor(this PolylineHandle /* maps_view_object_h */ polyline, Color color)
    {
        return polyline.SetColor((byte)color.R, (byte)color.G, (byte)color.B, (byte)color.A);
    }

    internal class PolylineHandle : ViewObjectHandle
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool CoordinatesCallback(int index, IntPtr /* maps_coordinates_h */ coordinates, IntPtr /* void */ userData);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_create_polyline")]
        internal static extern ErrorCode CreatePolyline(CoordinatesListHandle /* maps_coordinates_list_h */ coordinates, byte r, byte g, byte b, byte a, int width, out IntPtr /* maps_view_object_h */ polyline);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_polyline_foreach_point")]
        internal static extern ErrorCode ForeachPoint(IntPtr /* maps_view_object_h */ polyline, CoordinatesCallback callback, IntPtr /* void */ userData);

        internal Color LineColor
        {
            get { return NativeGet<Color>(this.GetColor); }
            set { NativeSet(this.SetColor, value); }
        }

        internal int LineWidth
        {
            get { return NativeGet<int>(this.GetWidth); }
            set { NativeSet(this.SetWidth, value); }
        }

        internal PolylineHandle(CoordinatesListHandle coordinates, Color color, int width) : base(IntPtr.Zero, true)
        {
            CreatePolyline(coordinates, (byte)color.R, (byte)color.G, (byte)color.B, (byte)color.A, width, out handle).ThrowIfFailed("Failed to create native polyline handle");
            coordinates.HasOwnership = false;
        }

        internal void ForeachPoint(Action<CoordinatesHandle> action)
        {
            CoordinatesCallback callback = (index, handle, userData) =>
            {
                action(CoordinatesHandle.CloneFrom(handle));
                return true;
            };

            ForeachPoint(handle, callback, IntPtr.Zero).WarnIfFailed("Failed to get coordinates list from native handle");
        }
    }
}
