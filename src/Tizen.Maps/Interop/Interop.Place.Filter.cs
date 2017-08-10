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
    [DllImport(Libraries.MapService, EntryPoint = "maps_place_filter_get")]
    internal static extern ErrorCode Get(this PlaceFilterHandle /* maps_place_filter_h */ filter, string key, out string value);

    [DllImport(Libraries.MapService, EntryPoint = "maps_place_filter_set")]
    internal static extern ErrorCode Set(this PlaceFilterHandle /* maps_place_filter_h */ filter, string key, string value);

    [DllImport(Libraries.MapService, EntryPoint = "maps_place_filter_get_keyword")]
    internal static extern ErrorCode GetKeyword(this PlaceFilterHandle /* maps_place_filter_h */ filter, out string keyword);

    [DllImport(Libraries.MapService, EntryPoint = "maps_place_filter_set_keyword")]
    internal static extern ErrorCode SetKeyword(this PlaceFilterHandle /* maps_place_filter_h */ filter, string keyword);

    [DllImport(Libraries.MapService, EntryPoint = "maps_place_filter_get_place_name")]
    internal static extern ErrorCode GetPlaceName(this PlaceFilterHandle /* maps_place_filter_h */ filter, out string placeName);

    [DllImport(Libraries.MapService, EntryPoint = "maps_place_filter_set_place_name")]
    internal static extern ErrorCode SetPlaceName(this PlaceFilterHandle /* maps_place_filter_h */ filter, string placeName);

    [DllImport(Libraries.MapService, EntryPoint = "maps_place_filter_get_category")]
    internal static extern ErrorCode GetCategory(this PlaceFilterHandle /* maps_place_filter_h */ filter, out IntPtr /* maps_place_category_h */ category);

    [DllImport(Libraries.MapService, EntryPoint = "maps_place_filter_set_category")]
    internal static extern ErrorCode SetCategory(this PlaceFilterHandle /* maps_place_filter_h */ filter, PlaceCategoryHandle /* maps_place_category_h */ category);

    [DllImport(Libraries.MapService, EntryPoint = "maps_place_filter_get_place_address")]
    internal static extern ErrorCode GetPlaceAddress(this PlaceFilterHandle /* maps_place_filter_h */ filter, out string placeAddress);

    [DllImport(Libraries.MapService, EntryPoint = "maps_place_filter_set_place_address")]
    internal static extern ErrorCode SetPlaceAddress(this PlaceFilterHandle /* maps_place_filter_h */ filter, string placeAddress);

    internal class PlaceFilterHandle : SafeMapsHandle
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool PlaceFilterPropertiesCallback(int index, int total, string key, IntPtr /* void */ value, IntPtr /* void */ userData);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_filter_foreach_property")]
        internal static extern ErrorCode ForeachProperty(IntPtr /* maps_place_filter_h */ filter, PlaceFilterPropertiesCallback callback, IntPtr /* void */ userData);


        [DllImport(Libraries.MapService, EntryPoint = "maps_place_filter_create")]
        internal static extern ErrorCode Create(out IntPtr /* maps_place_filter_h */ filter);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_filter_destroy")]
        internal static extern ErrorCode Destroy(IntPtr /* maps_place_filter_h */ filter);

        internal string Keyword
        {
            get { return NativeGet(this.GetKeyword); }
            set { NativeSet(this.SetKeyword, value); }
        }

        internal string PlaceName
        {
            get { return NativeGet(this.GetPlaceName); }
            set { NativeSet(this.SetPlaceName, value); }
        }

        internal string PlaceAddress
        {
            get { return NativeGet(this.GetPlaceAddress); }
            set { NativeSet(this.SetPlaceAddress, value); }
        }

        internal PlaceCategoryHandle Category
        {
            get { return NativeGet(this.GetCategory, PlaceCategoryHandle.Create); }
            set { NativeSet(this.SetCategory, value); }
        }

        public PlaceFilterHandle(IntPtr handle, bool needToRelease) : base(handle, needToRelease, Destroy)
        {
        }

        public PlaceFilterHandle() : this(IntPtr.Zero, true)
        {
            Create(out handle).ThrowIfFailed("Failed to create native handle");
        }

        internal void ForeachProperty(Action<string, string> action)
        {
            PlaceFilterPropertiesCallback callback = (index, total, key, value, userData) =>
            {
                action(key, Marshal.PtrToStringUni(value));
                return true;
            };

            ForeachProperty(handle, callback, IntPtr.Zero).WarnIfFailed("Failed to get address list from native handle");
        }
    }
}
