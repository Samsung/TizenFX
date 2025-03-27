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
    internal static partial class Face // Deprecated all
    {
        //[DllImport(Libraries.MediaContent, EntryPoint = "media_face_create")]
        //internal static extern MediaContentError Create(string mediaId, out IntPtr face); // Deprecated

        //[DllImport(Libraries.MediaContent, EntryPoint = "media_face_destroy")]
        //internal static extern MediaContentError Destroy(IntPtr face); // Deprecated

        //[DllImport(Libraries.MediaContent, EntryPoint = "media_face_clone")]
        //internal static extern MediaContentError Clone(out IntPtr dst, IntPtr src); // Deprecated

        //[DllImport(Libraries.MediaContent, EntryPoint = "media_face_get_face_id")]
        //internal static extern MediaContentError GetId(IntPtr face, out IntPtr faceId); // Deprecated

        //[DllImport(Libraries.MediaContent, EntryPoint = "media_face_get_media_id")]
        //internal static extern MediaContentError GetMediaId(IntPtr face, out IntPtr mediaId); // Deprecated

        //[DllImport(Libraries.MediaContent, EntryPoint = "media_face_get_face_rect")]
        //internal static extern MediaContentError GetFaceRect(IntPtr face, // Deprecated
        //    out int x, out int y, out int w, out int h);

        //[DllImport(Libraries.MediaContent, EntryPoint = "media_face_get_orientation")]
        //internal static extern MediaContentError GetOrientation(IntPtr face, out Orientation orientation); // Deprecated

        //[DllImport(Libraries.MediaContent, EntryPoint = "media_face_get_tag")]
        //internal static extern MediaContentError GetTag(IntPtr face, out IntPtr tag); // Deprecated

        //[DllImport(Libraries.MediaContent, EntryPoint = "media_face_set_face_rect")]
        //internal static extern MediaContentError SetFaceRect(IntPtr face, int x, int y, int w, int h); // Deprecated

        //[DllImport(Libraries.MediaContent, EntryPoint = "media_face_set_orientation")]
        //internal static extern MediaContentError SetOrientation(IntPtr face, Orientation orientation); // Deprecated

        //[DllImport(Libraries.MediaContent, EntryPoint = "media_face_set_tag")]
        //internal static extern MediaContentError SetTag(IntPtr face, string tag); // Deprecated

        //[DllImport(Libraries.MediaContent, EntryPoint = "media_face_insert_to_db")]
        //internal static extern MediaContentError Insert(IntPtr handle); // Deprecated

        //[DllImport(Libraries.MediaContent, EntryPoint = "media_face_update_to_db")]
        //internal static extern MediaContentError Update(IntPtr face); // Deprecated

        //[DllImport(Libraries.MediaContent, EntryPoint = "media_face_delete_from_db")]
        ////internal static extern MediaContentError DeleteFromDb(string faceId); // Deprecated

        //[DllImport(Libraries.MediaContent, EntryPoint = "media_face_foreach_face_from_db")]
        //internal static extern MediaContentError ForeachFromDb(FilterHandle filter, // Deprecated
        //    Common.ItemCallback callback, IntPtr userData = default(IntPtr));
    }
}
