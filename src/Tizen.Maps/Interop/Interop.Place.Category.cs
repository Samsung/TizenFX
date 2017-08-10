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
    [DllImport(Libraries.MapService, EntryPoint = "maps_place_category_get_id")]
    internal static extern ErrorCode GetId(this PlaceCategoryHandle /* maps_place_category_h */ category, out string id);

    [DllImport(Libraries.MapService, EntryPoint = "maps_place_category_set_id")]
    internal static extern ErrorCode SetId(this PlaceCategoryHandle /* maps_place_category_h */ category, string id);

    [DllImport(Libraries.MapService, EntryPoint = "maps_place_category_get_name")]
    internal static extern ErrorCode GetName(this PlaceCategoryHandle /* maps_place_category_h */ category, out string name);

    [DllImport(Libraries.MapService, EntryPoint = "maps_place_category_set_name")]
    internal static extern ErrorCode SetName(this PlaceCategoryHandle /* maps_place_category_h */ category, string name);

    [DllImport(Libraries.MapService, EntryPoint = "maps_place_category_get_url")]
    internal static extern ErrorCode GetUrl(this PlaceCategoryHandle /* maps_place_category_h */ category, out string url);

    [DllImport(Libraries.MapService, EntryPoint = "maps_place_category_set_url")]
    internal static extern ErrorCode SetUrl(this PlaceCategoryHandle /* maps_place_category_h */ category, string url);

    internal class PlaceCategoryHandle : SafeMapsHandle
    {
        [DllImport(Libraries.MapService, EntryPoint = "maps_place_category_create")]
        internal static extern ErrorCode Create(out IntPtr /* maps_place_category_h */ category);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_category_destroy")]
        internal static extern ErrorCode Destroy(IntPtr /* maps_place_category_h */ category);

        internal string Id
        {
            get { return NativeGet(this.GetId); }
            set { NativeSet(this.SetId, value); }
        }

        internal string Name
        {
            get { return NativeGet(this.GetName); }
            set { NativeSet(this.SetName, value); }
        }

        internal string Url
        {
            get { return NativeGet(this.GetUrl); }
            set { NativeSet(this.SetUrl, value); }
        }

        public PlaceCategoryHandle(IntPtr handle, bool needToRelease) : base(handle, needToRelease, Destroy)
        {
        }

        internal PlaceCategoryHandle() : this(IntPtr.Zero, true)
        {
            Create(out handle).ThrowIfFailed("Failed to create native handle");
        }

        internal static PlaceCategoryHandle Create(IntPtr nativeHandle)
        {
            return new PlaceCategoryHandle(nativeHandle, true);
        }
    }
}
