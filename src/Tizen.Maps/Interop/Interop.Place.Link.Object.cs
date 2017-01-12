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
    [DllImport(Libraries.MapService, EntryPoint = "maps_place_link_object_get_id")]
    internal static extern ErrorCode GetId(this PlaceLinkObjectHandle /* maps_place_link_object_h */ link, out string id);

    [DllImport(Libraries.MapService, EntryPoint = "maps_place_link_object_get_name")]
    internal static extern ErrorCode GetName(this PlaceLinkObjectHandle /* maps_place_link_object_h */ link, out string name);

    [DllImport(Libraries.MapService, EntryPoint = "maps_place_link_object_get_string")]
    internal static extern ErrorCode GetLink(this PlaceLinkObjectHandle /* maps_place_link_object_h */ link, out string linkString);

    [DllImport(Libraries.MapService, EntryPoint = "maps_place_link_object_get_type")]
    internal static extern ErrorCode GetType(this PlaceLinkObjectHandle /* maps_place_link_object_h */ link, out string type);

    internal class PlaceLinkObjectHandle : SafeMapsHandle
    {
        [DllImport(Libraries.MapService, EntryPoint = "maps_place_link_object_destroy")]
        internal static extern ErrorCode Destroy(IntPtr /* maps_place_link_object_h */ link);

        internal string Id
        {
            get { return NativeGet(this.GetId); }
        }

        internal string Name
        {
            get { return NativeGet(this.GetName); }
        }

        internal string Link
        {
            get { return NativeGet(this.GetLink); }
        }

        internal string Type
        {
            get { return NativeGet(this.GetType); }
        }

        public PlaceLinkObjectHandle(IntPtr handle, bool needToRelease) : base(handle, needToRelease, Destroy)
        {
        }

        internal static PlaceLinkObjectHandle Create(IntPtr nativeHandle)
        {
            return new PlaceLinkObjectHandle(nativeHandle, true);
        }
    }
}
