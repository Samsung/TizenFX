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
        internal static extern MediaContentError GetFaceId(IntPtr face, out string face_id);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_face_get_media_id")]
        internal static extern MediaContentError GetMediaId(IntPtr face, out string media_id);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_face_get_face_rect")]
        internal static extern MediaContentError GetFaceRect(IntPtr face, out int rect_x, out int rect_y, out int rect_w, out int IntPtr);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_face_get_orientation")]
        internal static extern MediaContentError GetOrientation(IntPtr face, out int orientation);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_face_get_tag")]
        internal static extern MediaContentError GetTag(IntPtr face, out string tag);

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
