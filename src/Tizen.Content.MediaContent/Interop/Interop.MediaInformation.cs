/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc.("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.


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
        internal static extern int Insert(string filePath, out SafeMediaInformationHandle info);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_insert_batch_to_db", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int BatchInsert(string[] filePathArray, int arrayLength, MediaInsertCompletedCallback callback, IntPtr userData);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_insert_burst_shot_to_db", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int BurstShotInsert(string[] filePathArray, int arrayLength, MediaInsertBurstShotCompletedCallback callback, IntPtr userData);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_delete_from_db", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Delete(string mediaId);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_delete_batch_from_db", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int BatchDelete(IntPtr filter);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_destroy", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Destroy(IntPtr mediaInformationHandle);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_clone", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Clone(out SafeMediaInformationHandle dst, IntPtr src);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_media_count_from_db", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetMediaCount(IntPtr filter, out int mediaCount);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_foreach_media_from_db", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetAllMedia(IntPtr filter, MediaInformationCallback callback, IntPtr userData);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_tag_count_from_db", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetTagCount(string mediaId, IntPtr filter, out int tagCount);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_foreach_tag_from_db", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetAllTags(string mediaId, IntPtr filter, MediaTagCallback callback, IntPtr userData);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_bookmark_count_from_db", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetBookmarkCount(string mediaId, IntPtr filter, out int bookmarkCount);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_foreach_bookmark_from_db", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetAllBookmarks(string mediaId, IntPtr filter, MediaBookmarkCallback callback, IntPtr userData);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_face_count_from_db", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetFaceCount(string mediaId, IntPtr filter, out int bookmarkCount);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_foreach_face_from_db", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetAllFaces(string mediaId, IntPtr filter, MediaFaceCallback callback, IntPtr userData);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_image", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetImage(IntPtr mediaInformationHandle, out Interop.ImageInformation.SafeImageInformationHandle image);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_video", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetVideo(IntPtr mediaInformationHandle, out Interop.VideoInformation.SafeVideoInformationHandle video);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_audio", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetAudio(IntPtr mediaInformationHandle, out Interop.AudioInformation.SafeAudioInformationHandle audio);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_media_id", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetMediaId(SafeMediaInformationHandle mediaInformationHandle, out string mediaId);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_file_path", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetFilePath(SafeMediaInformationHandle mediaInformationHandle, out string filePath);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_display_name", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetDisplayName(SafeMediaInformationHandle mediaInformationHandle, out string name);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_media_type", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetMediaType(SafeMediaInformationHandle mediaInformationHandle, out MediaContentType type);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_mime_type", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetMimeType(SafeMediaInformationHandle mediaInformationHandle, out string mimeType);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_size", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetSize(SafeMediaInformationHandle mediaInformationHandle, out long size);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_added_time", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetAddedTime(SafeMediaInformationHandle mediaInformationHandle, out int addedTime);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_modified_time", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetModifiedTime(SafeMediaInformationHandle mediaInformationHandle, out int time);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_timeline", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetTimeline(SafeMediaInformationHandle mediaInformationHandle, out int time);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_thumbnail_path", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetThumbnailPath(SafeMediaInformationHandle mediaInformationHandle, out string filePath);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_description", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetDescription(SafeMediaInformationHandle mediaInformationHandle, out string description);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_longitude", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetLongitude(SafeMediaInformationHandle mediaInformationHandle, out double longitude);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_latitude", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetLatitude(SafeMediaInformationHandle mediaInformationHandle, out double latitude);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_altitude", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetAltitude(SafeMediaInformationHandle mediaInformationHandle, out double altitude);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_weather", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetWeather(SafeMediaInformationHandle mediaInformationHandle, out string weather);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_rating", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetRating(SafeMediaInformationHandle mediaInformationHandle, out int rating);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_favorite", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetFavorite(SafeMediaInformationHandle mediaInformationHandle, out bool favorite);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_author", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetAuthor(SafeMediaInformationHandle mediaInformationHandle, out string author);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_provider", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetProvider(SafeMediaInformationHandle mediaInformationHandle, out string provider);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_content_name", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetContentName(SafeMediaInformationHandle mediaInformationHandle, out string contentName);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_title", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetTitle(SafeMediaInformationHandle mediaInformationHandle, out string title);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_category", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetCategory(SafeMediaInformationHandle mediaInformationHandle, out string category);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_location_tag", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetLocationTag(SafeMediaInformationHandle mediaInformationHandle, out string locationTag);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_age_rating", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetAgeRating(SafeMediaInformationHandle mediaInformationHandle, out string ageRating);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_keyword", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetKeyword(SafeMediaInformationHandle mediaInformationHandle, out string keyword);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_storage_id", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetStorageId(SafeMediaInformationHandle mediaInformationHandle, out string storageId);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_is_drm", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int IsDrm(SafeMediaInformationHandle mediaInformationHandle, out bool isDrm);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_storage_type", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetStorageType(SafeMediaInformationHandle mediaInformationHandle, out ContentStorageType storageType);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_played_count", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetPlayedCount(SafeMediaInformationHandle mediaInformationHandle, out int playedCount);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_played_time", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetPlayedAt(SafeMediaInformationHandle mediaInformationHandle, out int playedTime);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_get_media_from_db", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetMediaFromDB(string mediaId, out SafeMediaInformationHandle mediaInformationHandle);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_increase_played_count", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int IncreasePlayedCount(SafeMediaInformationHandle mediaInformationHandle);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_set_played_time", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetPlayedAt(SafeMediaInformationHandle mediaInformationHandle);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_set_display_name", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetDisplayName(SafeMediaInformationHandle mediaInformationHandle, string displayName);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_set_description", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetDescription(SafeMediaInformationHandle mediaInformationHandle, string description);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_set_longitude", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetLongitude(SafeMediaInformationHandle mediaInformationHandle, double longitude);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_set_latitude", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetLatitude(SafeMediaInformationHandle mediaInformationHandle, double latitude);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_set_altitude", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetAltitude(SafeMediaInformationHandle mediaInformationHandle, double altitude);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_set_weather", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetWeather(SafeMediaInformationHandle mediaInformationHandle, string weather);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_set_rating", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetRating(SafeMediaInformationHandle mediaInformationHandle, int rating);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_set_favorite", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetFavorite(SafeMediaInformationHandle mediaInformationHandle, bool favorite);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_set_author", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetAuthor(SafeMediaInformationHandle mediaInformationHandle, string author);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_set_provider", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetProvider(SafeMediaInformationHandle mediaInformationHandle, string provider);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_set_content_name", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetContentName(SafeMediaInformationHandle mediaInformationHandle, string contentName);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_set_category", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetCategory(SafeMediaInformationHandle mediaInformationHandle, string category);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_set_location_tag", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetLocationTag(SafeMediaInformationHandle mediaInformationHandle, string locationTag);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_set_age_rating", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetAgeRating(SafeMediaInformationHandle mediaInformationHandle, string ageRating);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_set_keyword", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetKeyword(SafeMediaInformationHandle mediaInformationHandle, string keyword);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_update_to_db", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int UpdateToDB(IntPtr mediaInformationHandle);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_refresh_metadata_to_db", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int RefreshMetadataToDB(string mediaId);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_set_added_time", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetAddedTime(SafeMediaInformationHandle mediaInformationHandle, int addedTime);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_move_to_db", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int MoveToDB(SafeMediaInformationHandle mediaInformationHandle, string dstPath);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_create_thumbnail", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int CreateThumbnail(SafeMediaInformationHandle mediaInformationHandle, MediaThumbnailCompletedCallback callback, IntPtr userData);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_info_cancel_thumbnail", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int CancelThumbnail(SafeMediaInformationHandle mediaInformationHandle);

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
