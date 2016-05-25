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
    internal static partial class VideoInformation
    {
        [DllImport(Libraries.MediaContent, EntryPoint = "video_meta_destroy", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Destroy(IntPtr media);

        [DllImport(Libraries.MediaContent, EntryPoint = "video_meta_clone", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Clone(out SafeVideoInformationHandle dst, SafeVideoInformationHandle src);

        [DllImport(Libraries.MediaContent, EntryPoint = "video_meta_get_media_id", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetMediaId(SafeVideoInformationHandle videoInformationHandle, out string mediaId);

        [DllImport(Libraries.MediaContent, EntryPoint = "video_meta_get_album", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetAlbum(SafeVideoInformationHandle videoInformationHandle, out string albumName);

        [DllImport(Libraries.MediaContent, EntryPoint = "video_meta_get_artist", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetArtist(SafeVideoInformationHandle videoInformationHandle, out string artistName);

        [DllImport(Libraries.MediaContent, EntryPoint = "video_meta_get_album_artist", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetAlbumArtist(SafeVideoInformationHandle videoInformationHandle, out string albumArtistName);

        [DllImport(Libraries.MediaContent, EntryPoint = "video_meta_get_genre", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetGenre(SafeVideoInformationHandle videoInformationHandle, out string genreName);

        [DllImport(Libraries.MediaContent, EntryPoint = "video_meta_get_composer", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetComposer(SafeVideoInformationHandle videoInformationHandle, out string composerName);

        [DllImport(Libraries.MediaContent, EntryPoint = "video_meta_get_year", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetYear(SafeVideoInformationHandle videoInformationHandle, out string year);

        [DllImport(Libraries.MediaContent, EntryPoint = "video_meta_get_recorded_date", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetRecordedDate(SafeVideoInformationHandle videoInformationHandle, out string recordedDate);

        [DllImport(Libraries.MediaContent, EntryPoint = "video_meta_get_copyright", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetCopyright(SafeVideoInformationHandle videoInformationHandle, out string copyright);

        [DllImport(Libraries.MediaContent, EntryPoint = "video_meta_get_track_num", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetTrackNum(SafeVideoInformationHandle videoInformationHandle, out string trackNum);

        [DllImport(Libraries.MediaContent, EntryPoint = "video_meta_get_bit_rate", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetBitRate(SafeVideoInformationHandle videoInformationHandle, out int bitRate);

        [DllImport(Libraries.MediaContent, EntryPoint = "video_meta_get_duration", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetDuration(SafeVideoInformationHandle videoInformationHandle, out int duration);

        [DllImport(Libraries.MediaContent, EntryPoint = "video_meta_get_width", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetWidth(SafeVideoInformationHandle videoInformationHandle, out int width);

        [DllImport(Libraries.MediaContent, EntryPoint = "video_meta_get_height", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetHeight(SafeVideoInformationHandle videoInformationHandle, out int width);

        [DllImport(Libraries.MediaContent, EntryPoint = "video_meta_get_played_count", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetPlayedCount(SafeVideoInformationHandle videoInformationHandle, out int playedCount);

        [DllImport(Libraries.MediaContent, EntryPoint = "video_meta_get_played_time", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetPlayedTime(SafeVideoInformationHandle videoInformationHandle, out int playedTime);

        [DllImport(Libraries.MediaContent, EntryPoint = "video_meta_get_played_position", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetPlayedPosition(SafeVideoInformationHandle videoInformationHandle, out int playedPosition);

        [DllImport(Libraries.MediaContent, EntryPoint = "video_meta_set_played_count", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetPlayedCount(SafeVideoInformationHandle videoInformationHandle, int playedCount);

        [DllImport(Libraries.MediaContent, EntryPoint = "video_meta_set_played_time", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetPlayedTime(SafeVideoInformationHandle videoInformationHandle, int playedTime);

        [DllImport(Libraries.MediaContent, EntryPoint = "video_meta_set_played_position", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetPlayedPosition(SafeVideoInformationHandle videoInformationHandle, int playedPosition);

        [DllImport(Libraries.MediaContent, EntryPoint = "video_meta_update_to_db", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int UpdateToDB(IntPtr videoInformationHandle);

        internal sealed class SafeVideoInformationHandle : SafeHandle
        {
            public SafeVideoInformationHandle()
                : base(IntPtr.Zero, true)
            {
            }

            public override bool IsInvalid
            {
                get { return this.handle == IntPtr.Zero; }
            }

            protected override bool ReleaseHandle()
            {
                Tizen.Log.Info(Globals.LogTag, "SafeVideoInformationHandle::ReleaseHandle called");
                VideoInformation.Destroy(this.handle);
                this.SetHandle(IntPtr.Zero);
                return true;
            }
        }
    }
}