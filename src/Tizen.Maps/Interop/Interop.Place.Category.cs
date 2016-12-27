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
    internal static partial class PlaceCategory
    {
        [DllImport(Libraries.MapService, EntryPoint = "maps_place_category_create")]
        internal static extern ErrorCode Create(out IntPtr /* maps_place_category_h */ category);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_category_clone")]
        internal static extern ErrorCode Clone(PlaceCategoryHandle /* maps_place_category_h */ origin, out IntPtr /* maps_place_category_h */ cloned);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_category_destroy")]
        internal static extern ErrorCode Destroy(IntPtr /* maps_place_category_h */ category);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_category_get_id")]
        internal static extern ErrorCode GetId(PlaceCategoryHandle /* maps_place_category_h */ category, out string id);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_category_get_name")]
        internal static extern ErrorCode GetName(PlaceCategoryHandle /* maps_place_category_h */ category, out string name);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_category_get_url")]
        internal static extern ErrorCode GetUrl(PlaceCategoryHandle /* maps_place_category_h */ category, out string url);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_category_set_id")]
        internal static extern ErrorCode SetId(PlaceCategoryHandle /* maps_place_category_h */ category, string id);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_category_set_name")]
        internal static extern ErrorCode SetName(PlaceCategoryHandle /* maps_place_category_h */ category, string name);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_category_set_url")]
        internal static extern ErrorCode SetUrl(PlaceCategoryHandle /* maps_place_category_h */ category, string url);
    }

    internal class PlaceCategoryHandle : SafeMapsHandle
    {
        public PlaceCategoryHandle(IntPtr handle, bool ownsHandle = true) : base(handle, ownsHandle) { Destroy = PlaceCategory.Destroy; }
    }
}
