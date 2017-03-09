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
    internal static partial class Tag
    {
        [DllImport(Libraries.MediaContent, EntryPoint = "media_tag_insert_to_db")]
        internal static extern MediaContentError InsertToDb(string tag_name, out IntPtr tag);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_tag_delete_from_db")]
        internal static extern MediaContentError DeleteFromDb(int tag_id);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_tag_get_tag_count_from_db")]
        internal static extern MediaContentError GetTagCountFromDb(IntPtr filter, out int tag_count);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_tag_get_media_count_from_db")]
        internal static extern MediaContentError GetMediaCountFromDb(int tag_id, IntPtr filter, out int media_count);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_tag_clone")]
        internal static extern MediaContentError Clone(out IntPtr dst, IntPtr src);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_tag_destroy")]
        internal static extern MediaContentError Destroy(IntPtr tag);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_tag_get_tag_id")]
        internal static extern MediaContentError GetTagId(IntPtr tag, out int tag_id);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_tag_get_name")]
        internal static extern MediaContentError GetName(IntPtr tag, out IntPtr tag_name);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_tag_get_tag_from_db")]
        internal static extern MediaContentError GetTagFromDb(int tag_id, out IntPtr tag);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_tag_add_media")]
        internal static extern MediaContentError AddMedia(IntPtr tag, string media_id);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_tag_remove_media")]
        internal static extern MediaContentError RemoveMedia(IntPtr tag, string media_id);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_tag_set_name")]
        internal static extern MediaContentError SetName(IntPtr tag, string tag_name);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_tag_update_to_db")]
        internal static extern MediaContentError UpdateToDb(IntPtr tag);

        //Callbacks
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool MediaInfoCallback(IntPtr mediaInformation, IntPtr data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool MediaTagCallback(IntPtr tag, IntPtr data);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_tag_foreach_tag_from_db")]
        internal static extern MediaContentError ForeachTagFromDb(IntPtr filter, MediaTagCallback callback, IntPtr user_data);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_tag_foreach_media_from_db")]
        internal static extern MediaContentError ForeachMediaFromDb(int tag_id, IntPtr filter, MediaInfoCallback callback, IntPtr user_data);
    }
}
