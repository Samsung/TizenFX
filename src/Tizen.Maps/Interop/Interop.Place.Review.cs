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
    [DllImport(Libraries.MapService, EntryPoint = "maps_place_review_get_date")]
    internal static extern ErrorCode GetDate(this PlaceReviewHandle /* maps_place_review_h */ review, out string date);

    [DllImport(Libraries.MapService, EntryPoint = "maps_place_review_get_title")]
    internal static extern ErrorCode GetTitle(this PlaceReviewHandle /* maps_place_review_h */ review, out string title);

    [DllImport(Libraries.MapService, EntryPoint = "maps_place_review_get_rating")]
    internal static extern ErrorCode GetRating(this PlaceReviewHandle /* maps_place_review_h */ review, out double rating);

    [DllImport(Libraries.MapService, EntryPoint = "maps_place_review_get_description")]
    internal static extern ErrorCode GetDescription(this PlaceReviewHandle /* maps_place_review_h */ review, out string description);

    [DllImport(Libraries.MapService, EntryPoint = "maps_place_review_get_language")]
    internal static extern ErrorCode GetLanguage(this PlaceReviewHandle /* maps_place_review_h */ review, out string language);

    [DllImport(Libraries.MapService, EntryPoint = "maps_place_review_get_media")]
    internal static extern ErrorCode GetMedia(this PlaceReviewHandle /* maps_place_review_h */ review, out IntPtr /* maps_place_media_h */ media);

    [DllImport(Libraries.MapService, EntryPoint = "maps_place_review_get_user_link")]
    internal static extern ErrorCode GetUserLink(this PlaceReviewHandle /* maps_place_review_h */ review, out IntPtr /* maps_place_link_object_h */ user);

    internal class PlaceReviewHandle : SafeMapsHandle
    {
        [DllImport(Libraries.MapService, EntryPoint = "maps_place_review_destroy")]
        internal static extern ErrorCode Destroy(IntPtr /* maps_place_review_h */ review);

        internal string Date
        {
            get { return NativeGet(this.GetDate); }
        }

        internal string Title
        {
            get { return NativeGet(this.GetTitle); }
        }
        internal string Language
        {
            get { return NativeGet(this.GetLanguage); }
        }
        internal string Description
        {
            get { return NativeGet(this.GetDescription); }
        }
        internal double Rating
        {
            get { return NativeGet<double>(this.GetRating); }
        }

        internal PlaceLinkObjectHandle User
        {
            get { return NativeGet(this.GetUserLink, PlaceLinkObjectHandle.Create); }
        }

        internal PlaceMediaHandle Media
        {
            get { return NativeGet(this.GetMedia, PlaceMediaHandle.Create); }
        }

        public PlaceReviewHandle(IntPtr handle, bool needToRelease) : base(handle, needToRelease, Destroy)
        {
        }
    }
}
