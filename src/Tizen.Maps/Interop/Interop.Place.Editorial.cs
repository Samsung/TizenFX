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
    [DllImport(Libraries.MapService, EntryPoint = "maps_place_editorial_get_description")]
    internal static extern ErrorCode GetDescription(this PlaceEditorialHandle /* maps_place_editorial_h */ editorial, out string description);

    [DllImport(Libraries.MapService, EntryPoint = "maps_place_editorial_get_language")]
    internal static extern ErrorCode GetLanguage(this PlaceEditorialHandle /* maps_place_editorial_h */ editorial, out string language);

    [DllImport(Libraries.MapService, EntryPoint = "maps_place_editorial_get_media")]
    internal static extern ErrorCode GetMedia(this PlaceEditorialHandle /* maps_place_editorial_h */ editorial, out IntPtr /* maps_place_media_h */ media);

    internal class PlaceEditorialHandle : SafeMapsHandle
    {
        [DllImport(Libraries.MapService, EntryPoint = "maps_place_editorial_destroy")]
        internal static extern ErrorCode Destroy(IntPtr /* maps_place_editorial_h */ editorial);

        internal string Description
        {
            get { return NativeGet(this.GetDescription); }
        }

        internal string Language
        {
            get { return NativeGet(this.GetLanguage); }
        }

        internal PlaceMediaHandle Media
        {
            get { return NativeGet(this.GetMedia, PlaceMediaHandle.Create); }
        }

        public PlaceEditorialHandle(IntPtr handle, bool needToRelease) : base(handle, needToRelease, Destroy)
        {
        }
    }
}
