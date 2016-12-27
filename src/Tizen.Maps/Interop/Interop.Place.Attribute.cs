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
    internal static partial class PlaceAttribute
    {
        [DllImport(Libraries.MapService, EntryPoint = "maps_place_attribute_destroy")]
        internal static extern ErrorCode Destroy(IntPtr /* maps_place_attribute_h */ attribute);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_attribute_clone")]
        internal static extern ErrorCode Clone(PlaceAttributeHandle /* maps_place_attribute_h */ origin, out IntPtr /* maps_place_attribute_h */ cloned);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_attribute_get_id")]
        internal static extern ErrorCode GetId(PlaceAttributeHandle /* maps_place_attribute_h */ attribute, out string id);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_attribute_get_label")]
        internal static extern ErrorCode GetLabel(PlaceAttributeHandle /* maps_place_attribute_h */ attribute, out string label);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_attribute_get_text")]
        internal static extern ErrorCode GetText(PlaceAttributeHandle /* maps_place_attribute_h */ attribute, out string text);
    }

    internal class PlaceAttributeHandle : SafeMapsHandle
    {
        public PlaceAttributeHandle(IntPtr handle, bool ownsHandle = true) : base(handle, ownsHandle) { Destroy = PlaceAttribute.Destroy; }
    }
}
