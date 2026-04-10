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
    internal static partial class Group
    {
        [DllImport(Libraries.MediaContent, EntryPoint = "media_group_get_group_count_from_db")]
        internal static extern MediaContentError GetGroupCount(FilterHandle filter,
            MediaInfoColumnKey group, out int count);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_group_get_media_count_from_db")]
        internal static extern MediaContentError GetMediaCount(string groupName,
            MediaInfoColumnKey groupType, FilterHandle filter, out int count);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool MediaGroupCallback(string groupName, IntPtr data);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_group_foreach_group_from_db")]
        internal static extern MediaContentError ForeachGroup(FilterHandle filter,
            MediaInfoColumnKey group, MediaGroupCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.MediaContent, EntryPoint = "media_group_foreach_media_from_db")]
        internal static extern MediaContentError ForeachMedia(string groupName, MediaInfoColumnKey group,
            FilterHandle filter, Common.ItemCallback callback, IntPtr userData = default(IntPtr));
    }
}
