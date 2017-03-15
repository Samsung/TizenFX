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
using Tizen.Content.MediaContent;

internal static partial class Interop
{
    internal static partial class Filter
    {
        [DllImport(Libraries.MediaContent, EntryPoint = "media_filter_create")]
        internal static extern MediaContentError Create(out IntPtr filter);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_filter_destroy")]
        internal static extern MediaContentError Destroy(IntPtr filter);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_filter_set_offset")]
        internal static extern MediaContentError SetOffset(IntPtr filter, int offset, int count);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_filter_set_condition")]
        internal static extern MediaContentError SetCondition(IntPtr filter, string condition, ContentCollation type);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_filter_set_order")]
        internal static extern MediaContentError SetOrder(IntPtr filter, ContentOrder order, string keyword, ContentCollation type);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_filter_set_storage")]
        internal static extern MediaContentError SetStorage(IntPtr filter, string storageId);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_filter_get_offset")]
        internal static extern MediaContentError GetOffset(IntPtr filter, out int offset, out int count);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_filter_get_condition")]
        internal static extern MediaContentError GetCondition(IntPtr filter, out IntPtr condition, out ContentCollation type);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_filter_get_order")]
        internal static extern MediaContentError GetOrder(IntPtr filter, out ContentOrder order, out IntPtr keyword, out ContentCollation type);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_filter_get_storage")]
        internal static extern MediaContentError GetStorage(IntPtr filter, out IntPtr storageId);
    }
}
