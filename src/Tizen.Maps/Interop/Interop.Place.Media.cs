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
    [DllImport(Libraries.MapService, EntryPoint = "maps_place_media_get_attribution")]
    internal static extern ErrorCode GetAttribution(this PlaceMediaHandle /* maps_place_media_h */ media, out string attribution);

    [DllImport(Libraries.MapService, EntryPoint = "maps_place_media_get_supplier")]
    internal static extern ErrorCode GetSupplier(this PlaceMediaHandle /* maps_place_media_h */ media, out IntPtr /* maps_place_link_object_h */ supplier);

    [DllImport(Libraries.MapService, EntryPoint = "maps_place_media_get_via")]
    internal static extern ErrorCode GetVia(this PlaceMediaHandle /* maps_place_media_h */ media, out IntPtr /* maps_place_link_object_h */ via);

    internal class PlaceMediaHandle : SafeMapsHandle
    {
        [DllImport(Libraries.MapService, EntryPoint = "maps_place_media_destroy")]
        internal static extern ErrorCode Destroy(IntPtr /* maps_place_media_h */ media);

        internal string Attribution
        {
            get { return NativeGet(this.GetAttribution); }
        }

        internal PlaceLinkObjectHandle Supplier
        {
            get { return NativeGet(this.GetSupplier, PlaceLinkObjectHandle.Create); }
        }

        internal PlaceLinkObjectHandle Via
        {
            get { return NativeGet(this.GetVia, PlaceLinkObjectHandle.Create); }
        }

        public PlaceMediaHandle(IntPtr handle, bool needToRelease) : base(handle, needToRelease, Destroy)
        {
        }

        internal static PlaceMediaHandle Create(IntPtr nativeHandle)
        {
            return new PlaceMediaHandle(nativeHandle, true);
        }
    }
}
