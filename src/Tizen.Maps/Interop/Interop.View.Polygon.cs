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
    [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_polygon_set_polygon")]
    internal static extern ErrorCode SetPolygon(this PolygonHandle /* maps_view_object_h */ polygon, CoordinatesListHandle /* maps_coordinates_list_h */ points);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_polygon_get_fill_color")]
    internal static extern ErrorCode GetFillColor(this PolygonHandle /* maps_view_object_h */ polygon, out byte r, out byte g, out byte b, out byte a);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_polygon_set_fill_color")]
    internal static extern ErrorCode SetFillColor(this PolygonHandle /* maps_view_object_h */ polygon, byte r, byte g, byte b, byte a);

    internal static ErrorCode GetFillColor(this PolygonHandle /* maps_view_object_h */ polygon, out Color color)
    {
        byte r, g, b, a;
        var err = polygon.GetFillColor(out r, out g, out b, out a);
        color = new Color(r, g, b, a);
        return err;
    }

    internal static ErrorCode SetFillColor(this PolygonHandle /* maps_view_object_h */ polygon, Color color)
    {
        return polygon.SetFillColor((byte)color.R, (byte)color.G, (byte)color.B, (byte)color.A);
    }

    internal class PolygonHandle : ViewObjectHandle
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool CoordinatesCallback(int index, IntPtr /* maps_coordinates_h */ coordinates, IntPtr /* void */ userData);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_polygon_foreach_point")]
        internal static extern ErrorCode ForeachPoint(IntPtr /* maps_view_object_h */ polygon, CoordinatesCallback callback, IntPtr /* void */ userData);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_object_create_polygon")]
        internal static extern ErrorCode CreatePolygon(CoordinatesListHandle /* maps_coordinates_list_h */ coordinates, byte r, byte g, byte b, byte a, out IntPtr /* maps_view_object_h */ polygon);

        internal Color FillColor
        {
            get { return NativeGet<Color>(this.GetFillColor); }
            set { NativeSet(this.SetFillColor, value); }
        }

        internal PolygonHandle(CoordinatesListHandle coordinates, Color color) : base(IntPtr.Zero, true)
        {
            CreatePolygon(coordinates, (byte)color.R, (byte)color.G, (byte)color.B, (byte)color.A, out handle).ThrowIfFailed("Failed to create native polygon handle");
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
