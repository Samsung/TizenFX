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
    internal static partial class PlaceEditorial
    {
        [DllImport(Libraries.MapService, EntryPoint = "maps_place_editorial_destroy")]
        internal static extern ErrorCode Destroy(IntPtr /* maps_place_editorial_h */ editorial);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_editorial_clone")]
        internal static extern ErrorCode Clone(PlaceEditorialHandle /* maps_place_editorial_h */ origin, out IntPtr /* maps_place_editorial_h */ cloned);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_editorial_get_description")]
        internal static extern ErrorCode GetDescription(PlaceEditorialHandle /* maps_place_editorial_h */ editorial, out string description);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_editorial_get_language")]
        internal static extern ErrorCode GetLanguage(PlaceEditorialHandle /* maps_place_editorial_h */ editorial, out string language);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_editorial_get_media")]
        internal static extern ErrorCode GetMedia(PlaceEditorialHandle /* maps_place_editorial_h */ editorial, out IntPtr /* maps_place_media_h */ media);
    }

    internal class PlaceEditorialHandle : SafeMapsHandle
    {
        public PlaceEditorialHandle(IntPtr handle, bool ownsHandle = true) : base(handle, ownsHandle) { Destroy = PlaceEditorial.Destroy; }
    }
}
