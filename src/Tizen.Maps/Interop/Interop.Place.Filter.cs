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
    internal static partial class PlaceFilter
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool PlaceFilterPropertiesCallback(int index, int total, string key, IntPtr /* void */ value, IntPtr /* void */ userData);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_filter_create")]
        internal static extern ErrorCode Create(out IntPtr /* maps_place_filter_h */ filter);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_filter_destroy")]
        internal static extern ErrorCode Destroy(IntPtr /* maps_place_filter_h */ filter);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_filter_clone")]
        internal static extern ErrorCode Clone(PlaceFilterHandle /* maps_place_filter_h */ origin, out IntPtr /* maps_place_filter_h */ cloned);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_filter_get")]
        internal static extern ErrorCode Get(PlaceFilterHandle /* maps_place_filter_h */ filter, string key, out string value);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_filter_get_keyword")]
        internal static extern ErrorCode GetKeyword(PlaceFilterHandle /* maps_place_filter_h */ filter, out string keyword);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_filter_get_place_name")]
        internal static extern ErrorCode GetPlaceName(PlaceFilterHandle /* maps_place_filter_h */ filter, out string placeName);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_filter_get_category")]
        internal static extern ErrorCode GetCategory(PlaceFilterHandle /* maps_place_filter_h */ filter, out IntPtr /* maps_place_category_h */ category);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_filter_foreach_property")]
        internal static extern ErrorCode ForeachProperty(PlaceFilterHandle /* maps_place_filter_h */ filter, PlaceFilterPropertiesCallback callback, IntPtr /* void */ userData);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_filter_get_place_address")]
        internal static extern ErrorCode GetPlaceAddress(PlaceFilterHandle /* maps_place_filter_h */ filter, out string placeAddress);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_filter_set")]
        internal static extern ErrorCode Set(PlaceFilterHandle /* maps_place_filter_h */ filter, string key, string value);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_filter_set_keyword")]
        internal static extern ErrorCode SetKeyword(PlaceFilterHandle /* maps_place_filter_h */ filter, string keyword);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_filter_set_place_name")]
        internal static extern ErrorCode SetPlaceName(PlaceFilterHandle /* maps_place_filter_h */ filter, string placeName);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_filter_set_category")]
        internal static extern ErrorCode SetCategory(PlaceFilterHandle /* maps_place_filter_h */ filter, PlaceCategoryHandle /* maps_place_category_h */ category);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_filter_set_place_address")]
        internal static extern ErrorCode SetPlaceAddress(PlaceFilterHandle /* maps_place_filter_h */ filter, string placeAddress);
    }

    internal class PlaceFilterHandle : SafeMapsHandle
    {
        public PlaceFilterHandle(IntPtr handle, bool ownsHandle = true) : base(handle, ownsHandle) { Destroy = PlaceFilter.Destroy; }
    }
}
