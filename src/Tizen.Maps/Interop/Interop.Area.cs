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
    internal enum AreaType
    {
        None, // MAPS_AREA_NONE
        Rectangle, // MAPS_AREA_RECTANGLE
        Circle, // MAPS_AREA_CIRCLE
    }

    internal static partial class Area
    {
        [DllImport(Libraries.MapService, EntryPoint = "maps_area_create_rectangle")]
        internal static extern ErrorCode CreateRectangle(CoordinatesHandle /* maps_coordinates_h */ topLeft, CoordinatesHandle /* maps_coordinates_h */ bottomRight, out IntPtr /* maps_area_h */ area);

        [DllImport(Libraries.MapService, EntryPoint = "maps_area_create_circle")]
        internal static extern ErrorCode CreateCircle(CoordinatesHandle /* maps_coordinates_h */ center, double radius, out IntPtr /* maps_area_h */ area);

        [DllImport(Libraries.MapService, EntryPoint = "maps_area_destroy")]
        internal static extern ErrorCode Destroy(IntPtr /* maps_area_h */ area);

        [DllImport(Libraries.MapService, EntryPoint = "maps_area_clone")]
        internal static extern ErrorCode Clone(AreaHandle /* maps_area_h */ origin, out IntPtr /* maps_area_h */ cloned);
    }

    internal class AreaHandle : SafeMapsHandle
    {
        public AreaHandle(IntPtr handle, bool ownsHandle = true) : base(handle, ownsHandle) { Destroy = Area.Destroy; }
    }
}
