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
    internal static partial class MediaInformation
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void MediaThumbnailCompletedCallback(MediaContentError error, string filePath, IntPtr UserData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool MediaTagCallback(IntPtr tagHandle, IntPtr UserData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool MediaBookmarkCallback(IntPtr bookmarkHandle, IntPtr UserData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool MediaFaceCallback(IntPtr bookmarkHandle, IntPtr UserData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void MediaInsertCompletedCallback(MediaContentError error, IntPtr UserData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void MediaInsertBurstShotCompletedCallback(MediaContentError error, IntPtr UserData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool MediaInformationCallback(IntPtr mediaInformationHandle, IntPtr UserData);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_insert_to_db", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError Insert(string filePath, out SafeMediaInformationHandle info);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_insert_batch_to_db", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError BatchInsert(string[] filePathArray, int arrayLength, MediaInsertCompletedCallback callback, IntPtr userData);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_insert_burst_shot_to_db", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError BurstShotInsert(string[] filePathArray, int arrayLength, MediaInsertBurstShotCompletedCallback callback, IntPtr userData);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_delete_from_db", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError Delete(string mediaId);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_delete_batch_from_db", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError BatchDelete(IntPtr filter);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_destroy", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError Destroy(IntPtr mediaInformationHandle);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_clone", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError Clone(out SafeMediaInformationHandle dst, IntPtr src);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_media_count_from_db", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetMediaCount(IntPtr filter, out int mediaCount);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_foreach_media_from_db", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetAllMedia(IntPtr filter, MediaInformationCallback callback, IntPtr userData);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_tag_count_from_db", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetTagCount(string mediaId, IntPtr filter, out int tagCount);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_foreach_tag_from_db", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetAllTags(string mediaId, IntPtr filter, MediaTagCallback callback, IntPtr userData);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_bookmark_count_from_db", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetBookmarkCount(string mediaId, IntPtr filter, out int bookmarkCount);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_foreach_bookmark_from_db", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetAllBookmarks(string mediaId, IntPtr filter, MediaBookmarkCallback callback, IntPtr userData);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_face_count_from_db", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetFaceCount(string mediaId, IntPtr filter, out int bookmarkCount);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_foreach_face_from_db", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetAllFaces(string mediaId, IntPtr filter, MediaFaceCallback callback, IntPtr userData);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_image", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetImage(IntPtr mediaInformationHandle, out Interop.ImageInformation.SafeImageInformationHandle image);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_video", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetVideo(IntPtr mediaInformationHandle, out Interop.VideoInformation.SafeVideoInformationHandle video);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_audio", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetAudio(IntPtr mediaInformationHandle, out Interop.AudioInformation.SafeAudioInformationHandle audio);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_media_id", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetMediaId(SafeMediaInformationHandle mediaInformationHandle, out IntPtr mediaId);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_file_path", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetFilePath(SafeMediaInformationHandle mediaInformationHandle, out IntPtr filePath);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_display_name", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetDisplayName(SafeMediaInformationHandle mediaInformationHandle, out IntPtr name);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_media_type", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetMediaType(SafeMediaInformationHandle mediaInformationHandle, out MediaContentType type);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_mime_type", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetMimeType(SafeMediaInformationHandle mediaInformationHandle, out IntPtr mimeType);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_size", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetSize(SafeMediaInformationHandle mediaInformationHandle, out long size);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_added_time", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetAddedTime(SafeMediaInformationHandle mediaInformationHandle, out int addedTime);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_modified_time", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetModifiedTime(SafeMediaInformationHandle mediaInformationHandle, out int time);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_timeline", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetTimeline(SafeMediaInformationHandle mediaInformationHandle, out int time);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_thumbnail_path", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetThumbnailPath(SafeMediaInformationHandle mediaInformationHandle, out IntPtr filePath);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_description", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetDescription(SafeMediaInformationHandle mediaInformationHandle, out IntPtr description);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_longitude", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetLongitude(SafeMediaInformationHandle mediaInformationHandle, out double longitude);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_latitude", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetLatitude(SafeMediaInformationHandle mediaInformationHandle, out double latitude);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_altitude", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetAltitude(SafeMediaInformationHandle mediaInformationHandle, out double altitude);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_weather", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetWeather(SafeMediaInformationHandle mediaInformationHandle, out IntPtr weather);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_rating", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetRating(SafeMediaInformationHandle mediaInformationHandle, out int rating);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_favorite", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetFavorite(SafeMediaInformationHandle mediaInformationHandle, out bool favorite);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_author", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetAuthor(SafeMediaInformationHandle mediaInformationHandle, out IntPtr author);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_provider", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetProvider(SafeMediaInformationHandle mediaInformationHandle, out IntPtr provider);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_content_name", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetContentName(SafeMediaInformationHandle mediaInformationHandle, out IntPtr contentName);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_title", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetTitle(SafeMediaInformationHandle mediaInformationHandle, out IntPtr title);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_category", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetCategory(SafeMediaInformationHandle mediaInformationHandle, out IntPtr category);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_location_tag", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetLocationTag(SafeMediaInformationHandle mediaInformationHandle, out IntPtr locationTag);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_age_rating", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetAgeRating(SafeMediaInformationHandle mediaInformationHandle, out IntPtr ageRating);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_keyword", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetKeyword(SafeMediaInformationHandle mediaInformationHandle, out IntPtr keyword);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_storage_id", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetStorageId(SafeMediaInformationHandle mediaInformationHandle, out IntPtr storageId);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_is_drm", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError IsDrm(SafeMediaInformationHandle mediaInformationHandle, out bool isDrm);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_storage_type", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetStorageType(SafeMediaInformationHandle mediaInformationHandle, out ContentStorageType storageType);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_played_count", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetPlayedCount(SafeMediaInformationHandle mediaInformationHandle, out int playedCount);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_played_time", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetPlayedAt(SafeMediaInformationHandle mediaInformationHandle, out int playedTime);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_media_from_db", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetMediaFromDB(string mediaId, out SafeMediaInformationHandle mediaInformationHandle);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_increase_played_count", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError IncreasePlayedCount(SafeMediaInformationHandle mediaInformationHandle);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_set_played_time", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError SetPlayedAt(SafeMediaInformationHandle mediaInformationHandle);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_set_display_name", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError SetDisplayName(SafeMediaInformationHandle mediaInformationHandle, string displayName);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_set_description", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError SetDescription(SafeMediaInformationHandle mediaInformationHandle, string description);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_set_longitude", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError SetLongitude(SafeMediaInformationHandle mediaInformationHandle, double longitude);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_set_latitude", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError SetLatitude(SafeMediaInformationHandle mediaInformationHandle, double latitude);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_set_altitude", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError SetAltitude(SafeMediaInformationHandle mediaInformationHandle, double altitude);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_set_weather", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError SetWeather(SafeMediaInformationHandle mediaInformationHandle, string weather);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_set_rating", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError SetRating(SafeMediaInformationHandle mediaInformationHandle, int rating);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_set_favorite", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError SetFavorite(SafeMediaInformationHandle mediaInformationHandle, bool favorite);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_set_author", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError SetAuthor(SafeMediaInformationHandle mediaInformationHandle, string author);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_set_provider", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError SetProvider(SafeMediaInformationHandle mediaInformationHandle, string provider);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_set_content_name", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError SetContentName(SafeMediaInformationHandle mediaInformationHandle, string contentName);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_set_category", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError SetCategory(SafeMediaInformationHandle mediaInformationHandle, string category);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_set_location_tag", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError SetLocationTag(SafeMediaInformationHandle mediaInformationHandle, string locationTag);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_set_age_rating", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError SetAgeRating(SafeMediaInformationHandle mediaInformationHandle, string ageRating);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_set_keyword", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError SetKeyword(SafeMediaInformationHandle mediaInformationHandle, string keyword);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_update_to_db", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError UpdateToDB(IntPtr mediaInformationHandle);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_refresh_metadata_to_db", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError RefreshMetadataToDB(string mediaId);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_set_added_time", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError SetAddedTime(SafeMediaInformationHandle mediaInformationHandle, int addedTime);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_move_to_db", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError MoveToDB(SafeMediaInformationHandle mediaInformationHandle, string dstPath);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_create_thumbnail", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError CreateThumbnail(SafeMediaInformationHandle mediaInformationHandle, MediaThumbnailCompletedCallback callback, IntPtr userData);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_cancel_thumbnail", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError CancelThumbnail(SafeMediaInformationHandle mediaInformationHandle);

        internal sealed class SafeMediaInformationHandle : SafeHandle
        {
            public SafeMediaInformationHandle(IntPtr handle)
                : base(handle, true)
            {
            }
            public SafeMediaInformationHandle()
                : base(IntPtr.Zero, true)
            {
            }

            public override bool IsInvalid
            {
                get { return this.handle == IntPtr.Zero; }
            }

            protected override bool ReleaseHandle()
            {
                MediaInformation.Destroy(this.handle);
                this.SetHandle(IntPtr.Zero);
                return true;
            }
        }
    }
}
