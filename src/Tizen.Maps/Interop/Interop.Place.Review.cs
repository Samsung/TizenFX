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
    internal static partial class PlaceReview
    {
        [DllImport(Libraries.MapService, EntryPoint = "maps_place_review_destroy")]
        internal static extern ErrorCode Destroy(IntPtr /* maps_place_review_h */ review);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_review_clone")]
        internal static extern ErrorCode Clone(PlaceReviewHandle /* maps_place_review_h */ origin, out IntPtr /* maps_place_review_h */ cloned);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_review_get_date")]
        internal static extern ErrorCode GetDate(PlaceReviewHandle /* maps_place_review_h */ review, out string date);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_review_get_title")]
        internal static extern ErrorCode GetTitle(PlaceReviewHandle /* maps_place_review_h */ review, out string title);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_review_get_rating")]
        internal static extern ErrorCode GetRating(PlaceReviewHandle /* maps_place_review_h */ review, out double rating);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_review_get_description")]
        internal static extern ErrorCode GetDescription(PlaceReviewHandle /* maps_place_review_h */ review, out string description);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_review_get_language")]
        internal static extern ErrorCode GetLanguage(PlaceReviewHandle /* maps_place_review_h */ review, out string language);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_review_get_media")]
        internal static extern ErrorCode GetMedia(PlaceReviewHandle /* maps_place_review_h */ review, out IntPtr /* maps_place_media_h */ media);

        [DllImport(Libraries.MapService, EntryPoint = "maps_place_review_get_user_link")]
        internal static extern ErrorCode GetUserLink(PlaceReviewHandle /* maps_place_review_h */ review, out IntPtr /* maps_place_link_object_h */ user);
    }

    internal class PlaceReviewHandle : SafeMapsHandle
    {
        public PlaceReviewHandle(IntPtr handle, bool ownsHandle = true) : base(handle, ownsHandle) { Destroy = PlaceReview.Destroy; }
    }
}
