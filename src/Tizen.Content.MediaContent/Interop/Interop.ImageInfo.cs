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
using System.Runtime.InteropServices.Marshalling;
using Tizen.Content.MediaContent;

internal static partial class Interop
{
    internal static partial class ImageInfo
    {
        [DllImport(Libraries.MediaContent, EntryPoint = "image_meta_destroy")]
        internal static extern MediaContentError Destroy(IntPtr media);

        [DllImport(Libraries.MediaContent, EntryPoint = "image_meta_get_orientation")]
        internal static extern MediaContentError GetOrientation(IntPtr handle, out Orientation orientation);

        [DllImport(Libraries.MediaContent, EntryPoint = "image_meta_get_date_taken")]
        internal static extern MediaContentError GetDateTaken(IntPtr handle, out IntPtr dateTaken);

        [DllImport(Libraries.MediaContent, EntryPoint = "image_meta_get_exposure_time")]
        internal static extern MediaContentError GetExposureTime(IntPtr handle, out IntPtr exposureTime); // Deprecated

        [DllImport(Libraries.MediaContent, EntryPoint = "image_meta_get_fnumber")]
        internal static extern MediaContentError GetFNumber(IntPtr handle, out double fNumber); // Deprecated

        [DllImport(Libraries.MediaContent, EntryPoint = "image_meta_get_iso")]
        internal static extern MediaContentError GetISO(IntPtr handle, out int iso); // Deprecated

        [DllImport(Libraries.MediaContent, EntryPoint = "image_meta_get_model")]
        internal static extern MediaContentError GetModel(IntPtr handle, out IntPtr model); // Deprecated

        [DllImport(Libraries.MediaContent, EntryPoint = "image_meta_get_width")]
        internal static extern MediaContentError GetWidth(IntPtr handle, out int width);

        [DllImport(Libraries.MediaContent, EntryPoint = "image_meta_get_height")]
        internal static extern MediaContentError GetHeight(IntPtr handle, out int width);
    }
}




