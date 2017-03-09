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
    internal static partial class Face
    {
        [DllImport(Libraries.MediaContent, EntryPoint = "media_face_clone")]
        internal static extern MediaContentError Clone(out IntPtr dst, IntPtr src);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_face_destroy")]
        internal static extern MediaContentError Destroy(IntPtr face);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_face_get_face_id")]
        internal static extern MediaContentError GetFaceId(IntPtr face, out IntPtr face_id);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_face_get_media_id")]
        internal static extern MediaContentError GetMediaId(IntPtr face, out IntPtr media_id);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_face_get_face_rect")]
        internal static extern MediaContentError GetFaceRect(IntPtr face, out int rect_x, out int rect_y, out int rect_w, out int IntPtr);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_face_get_orientation")]
        internal static extern MediaContentError GetOrientation(IntPtr face, out int orientation);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_face_get_tag")]
        internal static extern MediaContentError GetTag(IntPtr face, out IntPtr tag);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_face_create")]
        internal static extern MediaContentError Create(string media_id, out IntPtr face);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_face_set_face_rect")]
        internal static extern MediaContentError SetFaceRect(IntPtr face, int rect_x, int rect_y, int rect_w, int IntPtr);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_face_set_orientation")]
        internal static extern MediaContentError SetOrientation(IntPtr face, int orientation);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_face_set_tag")]
        internal static extern MediaContentError SetTag(IntPtr face, string tag);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_face_insert_to_db")]
        internal static extern MediaContentError InsertToDb(IntPtr face);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_face_update_to_db")]
        internal static extern MediaContentError UpdateToDb(IntPtr face);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_face_delete_from_db")]
        internal static extern MediaContentError DeleteFromDb(string face_id);
    }
}
