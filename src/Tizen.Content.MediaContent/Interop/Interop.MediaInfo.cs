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
    internal static partial class MediaInfo
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ThumbnailCompletedCallback(MediaContentError error, string filePath, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void FaceDetectionCompletedCallback(MediaContentError error, int count, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void InsertCompletedCallback(MediaContentError error, IntPtr userData);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_insert_to_db")]
        internal static extern MediaContentError Insert(string filePath, out MediaInfoHandle info);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_insert_batch_to_db")]
        internal static extern MediaContentError BatchInsert(string[] filePathArray, int arrayLength,
            InsertCompletedCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_delete_from_db")]
        internal static extern MediaContentError Delete(string mediaId);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_destroy")]
        internal static extern MediaContentError Destroy(IntPtr handle);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_media_count_from_db")]
        internal static extern MediaContentError GetMediaCount(FilterHandle filter, out int mediaCount);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_foreach_media_from_db")]
        internal static extern MediaContentError ForeachMedia(FilterHandle filter, Common.ItemCallback callback,
            IntPtr userData = default(IntPtr));

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_tag_count_from_db")]
        internal static extern MediaContentError GetTagCount(string mediaId, FilterHandle filter, out int tagCount);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_foreach_tag_from_db")]
        internal static extern MediaContentError ForeachTags(string mediaId, FilterHandle filter,
            Common.ItemCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_bookmark_count_from_db")]
        internal static extern MediaContentError GetBookmarkCount(string mediaId, FilterHandle filter, out int bookmarkCount);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_foreach_bookmark_from_db")]
        internal static extern MediaContentError ForeachBookmarks(string mediaId, FilterHandle filter,
            Common.ItemCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_face_count_from_db")]
        internal static extern MediaContentError GetFaceCount(string mediaId, FilterHandle filter, out int bookmarkCount);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_foreach_face_from_db")]
        internal static extern MediaContentError ForeachFaces(string mediaId, FilterHandle filter,
            Common.ItemCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_image")]
        internal static extern MediaContentError GetImage(MediaInfoHandle handle, out IntPtr imageHandle);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_video")]
        internal static extern MediaContentError GetVideo(MediaInfoHandle handle, out IntPtr videoHandle);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_audio")]
        internal static extern MediaContentError GetAudio(MediaInfoHandle handle, out IntPtr audioHandle);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_book")]
        internal static extern MediaContentError GetBook(MediaInfoHandle handle, out IntPtr bookHandle);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_media_id")]
        internal static extern MediaContentError GetMediaId(MediaInfoHandle mediaInformationHandle, out IntPtr mediaId);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_file_path")]
        internal static extern MediaContentError GetFilePath(MediaInfoHandle mediaInformationHandle, out IntPtr filePath);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_display_name")]
        internal static extern MediaContentError GetDisplayName(MediaInfoHandle mediaInformationHandle, out IntPtr name);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_media_type")]
        internal static extern MediaContentError GetMediaType(MediaInfoHandle mediaInformationHandle, out MediaType type);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_mime_type")]
        internal static extern MediaContentError GetMimeType(MediaInfoHandle mediaInformationHandle, out IntPtr mimeType);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_size")]
        internal static extern MediaContentError GetSize(MediaInfoHandle mediaInformationHandle, out long size);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_added_time")]
        internal static extern MediaContentError GetAddedTime(MediaInfoHandle handle, out IntPtr posixTime);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_modified_time")]
        internal static extern MediaContentError GetModifiedTime(MediaInfoHandle handle, out IntPtr posixTime);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_timeline")]
        internal static extern MediaContentError GetTimeline(MediaInfoHandle handle, out IntPtr posixTime);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_thumbnail_path")]
        internal static extern MediaContentError GetThumbnailPath(MediaInfoHandle mediaInformationHandle, out IntPtr filePath);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_description")]
        internal static extern MediaContentError GetDescription(MediaInfoHandle mediaInformationHandle, out IntPtr description);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_longitude")]
        internal static extern MediaContentError GetLongitude(MediaInfoHandle mediaInformationHandle, out double longitude);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_latitude")]
        internal static extern MediaContentError GetLatitude(MediaInfoHandle mediaInformationHandle, out double latitude);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_altitude")]
        internal static extern MediaContentError GetAltitude(MediaInfoHandle mediaInformationHandle, out double altitude);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_rating")]
        internal static extern MediaContentError GetRating(MediaInfoHandle mediaInformationHandle, out int rating);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_favorite")]
        internal static extern MediaContentError GetFavorite(MediaInfoHandle mediaInformationHandle, out bool favorite);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_title")]
        internal static extern MediaContentError GetTitle(MediaInfoHandle mediaInformationHandle, out IntPtr title);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_storage_id")]
        internal static extern MediaContentError GetStorageId(MediaInfoHandle mediaInformationHandle, out IntPtr storageId);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_is_drm")]
        internal static extern MediaContentError IsDrm(MediaInfoHandle mediaInformationHandle, out bool isDrm);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_storage_type")]
        internal static extern MediaContentError GetStorageType(MediaInfoHandle mediaInformationHandle, out StorageType storageType);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_media_from_db")]
        internal static extern MediaContentError GetMediaFromDB(string mediaId, out MediaInfoHandle handle);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_set_favorite")]
        internal static extern MediaContentError SetFavorite(MediaInfoHandle mediaInformationHandle, bool favorite);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_update_to_db")]
        internal static extern MediaContentError UpdateToDB(MediaInfoHandle mediaInformationHandle);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_move_to_db")]
        internal static extern MediaContentError MoveToDB(MediaInfoHandle mediaInformationHandle, string dstPath);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_create_thumbnail")]
        internal static extern MediaContentError CreateThumbnail(MediaInfoHandle handle,
            ThumbnailCompletedCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_cancel_thumbnail")]
        internal static extern MediaContentError CancelThumbnail(MediaInfoHandle mediaInformationHandle);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_start_face_detection")]
        internal static extern MediaContentError StartFaceDetection(MediaInfoHandle handle,
            FaceDetectionCompletedCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_cancel_face_detection")]
        internal static extern MediaContentError CancelFaceDetection(MediaInfoHandle handle);
    }

    internal sealed class MediaInfoHandle : SafeHandle
    {
        public MediaInfoHandle()
            : base(IntPtr.Zero, true)
        {
        }

        public MediaInfoHandle(IntPtr handle)
            : this()
        {
            SetHandle(handle);
        }

        public override bool IsInvalid
        {
            get { return handle == IntPtr.Zero; }
        }

        protected override bool ReleaseHandle()
        {
            MediaInfo.Destroy(handle);
            return true;
        }
    }
}
