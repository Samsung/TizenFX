/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd All Rights Reserved
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
    internal static partial class BookInfo
    {
        [DllImport(Libraries.MediaContent, EntryPoint = "book_meta_destroy")]
        internal static extern MediaContentError Destroy(IntPtr handle);

        [DllImport(Libraries.MediaContent, EntryPoint = "book_meta_get_media_id")]
        internal static extern MediaContentError GetMediaId(IntPtr handle, out IntPtr mediaId);

        [DllImport(Libraries.MediaContent, EntryPoint = "book_meta_get_subject")]
        internal static extern MediaContentError GetSubject(IntPtr handle, out IntPtr subject);

        [DllImport(Libraries.MediaContent, EntryPoint = "book_meta_get_author")]
        internal static extern MediaContentError GetAuthor(IntPtr handle, out IntPtr author);

        [DllImport(Libraries.MediaContent, EntryPoint = "book_meta_get_date")]
        internal static extern MediaContentError GetDate(IntPtr handle, out IntPtr date);

        [DllImport(Libraries.MediaContent, EntryPoint = "book_meta_get_publisher")]
        internal static extern MediaContentError GetPublisher(IntPtr handle, out IntPtr publisher);

        [DllImport(Libraries.MediaContent, EntryPoint = "book_meta_get_path_with_keyword(")]
        internal static extern MediaContentError GetPathByKeyword(IntPtr handle, ref string[] path, out uint count);
    }
}
