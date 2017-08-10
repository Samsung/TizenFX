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
    [DllImport(Libraries.MapService, EntryPoint = "maps_place_image_get_id")]
    internal static extern ErrorCode GetId(this PlaceImageHandle /* maps_place_image_h */ image, out string id);

    [DllImport(Libraries.MapService, EntryPoint = "maps_place_image_get_url")]
    internal static extern ErrorCode GetUrl(this PlaceImageHandle /* maps_place_image_h */ image, out string url);

    [DllImport(Libraries.MapService, EntryPoint = "maps_place_image_get_width")]
    internal static extern ErrorCode GetWidth(this PlaceImageHandle /* maps_place_image_h */ image, out int width);

    [DllImport(Libraries.MapService, EntryPoint = "maps_place_image_get_height")]
    internal static extern ErrorCode GetHeight(this PlaceImageHandle /* maps_place_image_h */ image, out int height);

    [DllImport(Libraries.MapService, EntryPoint = "maps_place_image_get_user_link")]
    internal static extern ErrorCode GetUserLink(this PlaceImageHandle /* maps_place_image_h */ image, out IntPtr /* maps_place_link_object_h */ user);

    [DllImport(Libraries.MapService, EntryPoint = "maps_place_image_get_media")]
    internal static extern ErrorCode GetMedia(this PlaceImageHandle /* maps_place_image_h */ image, out IntPtr /* maps_place_media_h */ media);

    internal class PlaceImageHandle : SafeMapsHandle
    {
        [DllImport(Libraries.MapService, EntryPoint = "maps_place_image_destroy")]
        internal static extern ErrorCode Destroy(IntPtr /* maps_place_image_h */ image);

        internal string Id
        {
            get { return NativeGet(this.GetId); }
        }

        internal string Url
        {
            get { return NativeGet(this.GetUrl); }
        }

        internal int Width
        {
            get { return NativeGet<int>(this.GetWidth); }
        }

        internal int Height
        {
            get { return NativeGet<int>(this.GetHeight); }
        }

        internal PlaceLinkObjectHandle User
        {
            get { return NativeGet(this.GetUserLink, PlaceLinkObjectHandle.Create); }
        }

        internal PlaceMediaHandle Media
        {
            get { return NativeGet(this.GetMedia, PlaceMediaHandle.Create); }
        }

        public PlaceImageHandle(IntPtr handle, bool needToRelease) : base(handle, needToRelease, Destroy)
        {
        }
    }
}
