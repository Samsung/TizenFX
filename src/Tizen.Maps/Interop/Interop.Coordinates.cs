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
    [DllImport(Libraries.MapService, EntryPoint = "maps_coordinates_get_latitude")]
    internal static extern ErrorCode GetLatitude(this CoordinatesHandle /* maps_coordinates_h */ coordinates, out double latitude);

    [DllImport(Libraries.MapService, EntryPoint = "maps_coordinates_get_longitude")]
    internal static extern ErrorCode GetLongitude(this CoordinatesHandle /* maps_coordinates_h */ coordinates, out double longitude);

    internal class CoordinatesHandle : SafeMapsHandle
    {
        [DllImport(Libraries.MapService, EntryPoint = "maps_coordinates_create")]
        internal static extern ErrorCode Create(double latitude, double longitude, out IntPtr /* maps_coordinates_h */ coordinates);

        [DllImport(Libraries.MapService, EntryPoint = "maps_coordinates_destroy")]
        internal static extern ErrorCode Destroy(IntPtr /* maps_coordinates_h */ coordinates);

        [DllImport(Libraries.MapService, EntryPoint = "maps_coordinates_clone")]
        internal static extern ErrorCode Clone(IntPtr /* maps_coordinates_h */ origin, out IntPtr /* maps_coordinates_h */ cloned);

        internal double Latitude
        {
            get { return NativeGet<double>(this.GetLatitude); }
        }

        internal double Longitude
        {
            get { return NativeGet<double>(this.GetLongitude); }
        }

        internal CoordinatesHandle(IntPtr handle, bool needToRelease) : base(handle, needToRelease, Destroy)
        {
        }

        internal CoordinatesHandle(double latitude, double longitude) : this(IntPtr.Zero, true)
        {
            Create(latitude, longitude, out handle).ThrowIfFailed("Failed to create native handle");
        }

        internal static CoordinatesHandle CloneFrom(IntPtr nativeHandle)
        {
            IntPtr handle;
            Clone(nativeHandle, out handle).ThrowIfFailed("Failed to clone native handle");
            return new CoordinatesHandle(handle, true);
        }

        internal static CoordinatesHandle Create(IntPtr nativeHandle)
        {
            return new CoordinatesHandle(nativeHandle, true);
        }

        public override string ToString()
        {
            return $"[{Latitude}, {Longitude}]";
        }
    }
}
