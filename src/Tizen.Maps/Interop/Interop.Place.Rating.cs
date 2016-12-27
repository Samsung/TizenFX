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
    internal static partial class PlaceRating
    {
        [DllImport(Libraries.MapService, EntryPoint = "maps_place_rating_destroy")]
        internal static extern ErrorCode Destroy(IntPtr /* maps_place_rating_h */ rating);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_rating_clone")]
        internal static extern ErrorCode Clone(PlaceRatingHandle /* maps_place_rating_h */ origin, out IntPtr /* maps_place_rating_h */ cloned);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_rating_get_count")]
        internal static extern ErrorCode GetCount(PlaceRatingHandle /* maps_place_rating_h */ rating, out int count);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_rating_get_average")]
        internal static extern ErrorCode GetAverage(PlaceRatingHandle /* maps_place_rating_h */ rating, out double average);
    }

    internal class PlaceRatingHandle : SafeMapsHandle
    {
        public PlaceRatingHandle(IntPtr handle, bool ownsHandle = true) : base(handle, ownsHandle) { Destroy = PlaceRating.Destroy; }
    }
}
