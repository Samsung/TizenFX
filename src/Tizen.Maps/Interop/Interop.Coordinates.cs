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
    internal static partial class Coordinates
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool CoordinatesCallback(int index, IntPtr /* maps_coordinates_h */ coordinates, IntPtr /* void */ userData);

        [DllImport(Libraries.MapService, EntryPoint = "maps_coordinates_create")]
        internal static extern ErrorCode Create(double latitude, double longitude, out IntPtr /* maps_coordinates_h */ coordinates);

        [DllImport(Libraries.MapService, EntryPoint = "maps_coordinates_destroy")]
        internal static extern ErrorCode Destroy(IntPtr /* maps_coordinates_h */ coordinates);

        [DllImport(Libraries.MapService, EntryPoint = "maps_coordinates_clone")]
        internal static extern ErrorCode Clone(IntPtr /* maps_coordinates_h */ origin, out IntPtr /* maps_coordinates_h */ cloned);

        [DllImport(Libraries.MapService, EntryPoint = "maps_coordinates_get_latitude")]
        internal static extern ErrorCode GetLatitude(CoordinatesHandle /* maps_coordinates_h */ coordinates, out double latitude);

        [DllImport(Libraries.MapService, EntryPoint = "maps_coordinates_get_longitude")]
        internal static extern ErrorCode GetLongitude(CoordinatesHandle /* maps_coordinates_h */ coordinates, out double longitude);

        [DllImport(Libraries.MapService, EntryPoint = "maps_coordinates_get_latitude_longitude")]
        internal static extern ErrorCode GetLatitudeLongitude(CoordinatesHandle /* maps_coordinates_h */ coordinates, out double latitude, out double longitude);

        [DllImport(Libraries.MapService, EntryPoint = "maps_coordinates_set_latitude")]
        internal static extern ErrorCode SetLatitude(CoordinatesHandle /* maps_coordinates_h */ coordinates, double latitude);

        [DllImport(Libraries.MapService, EntryPoint = "maps_coordinates_set_longitude")]
        internal static extern ErrorCode SetLongitude(CoordinatesHandle /* maps_coordinates_h */ coordinates, double longitude);

        [DllImport(Libraries.MapService, EntryPoint = "maps_coordinates_set_latitude_longitude")]
        internal static extern ErrorCode SetLatitudeLongitude(CoordinatesHandle /* maps_coordinates_h */ coordinates, double latitude, double longitude);

        [DllImport(Libraries.MapService, EntryPoint = "maps_coordinates_list_create")]
        internal static extern ErrorCode ListCreate(out IntPtr /* maps_coordinates_list_h */ coordinatesList);

        [DllImport(Libraries.MapService, EntryPoint = "maps_coordinates_list_destroy")]
        internal static extern ErrorCode ListDestroy(IntPtr /* maps_coordinates_list_h */ coordinatesList);

        [DllImport(Libraries.MapService, EntryPoint = "maps_coordinates_list_append")]
        internal static extern ErrorCode ListAppend(CoordinatesListHandle /* maps_coordinates_list_h */ coordinatesList, IntPtr /* maps_coordinates_h */ coordinates);

        [DllImport(Libraries.MapService, EntryPoint = "maps_coordinates_list_remove")]
        internal static extern ErrorCode ListRemove(CoordinatesListHandle /* maps_coordinates_list_h */ coordinatesList, CoordinatesHandle /* maps_coordinates_h */ coordinates);

        [DllImport(Libraries.MapService, EntryPoint = "maps_coordinates_list_get_length")]
        internal static extern ErrorCode ListGetLength(CoordinatesListHandle /* maps_coordinates_list_h */ coordinatesList, out int length);

        [DllImport(Libraries.MapService, EntryPoint = "maps_coordinates_list_foreach")]
        internal static extern ErrorCode ListForeach(CoordinatesListHandle /* maps_coordinates_list_h */ coordinatesList, CoordinatesCallback callback, IntPtr /* void */ userData);
    }

    internal class CoordinatesHandle : SafeMapsHandle
    {
        public CoordinatesHandle(IntPtr handle, bool ownsHandle = true) : base(handle, ownsHandle) { Destroy = Coordinates.Destroy; }
    }

    internal class CoordinatesListHandle : SafeMapsHandle
    {
        public CoordinatesListHandle(IntPtr handle, bool ownsHandle = true) : base(handle, ownsHandle) { Destroy = Coordinates.ListDestroy; }
    }
}
