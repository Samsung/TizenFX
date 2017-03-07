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
        internal static extern MediaContentError Destroy(IntPtr media);

        [DllImport(Libraries.MediaContent, EntryPoint = "video_meta_clone", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError Clone(out SafeVideoInformationHandle dst, SafeVideoInformationHandle src);

        [DllImport(Libraries.MediaContent, EntryPoint = "video_meta_get_media_id", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetMediaId(SafeVideoInformationHandle videoInformationHandle, out IntPtr mediaId);

        [DllImport(Libraries.MediaContent, EntryPoint = "video_meta_get_album", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetAlbum(SafeVideoInformationHandle videoInformationHandle, out IntPtr albumName);

        [DllImport(Libraries.MediaContent, EntryPoint = "video_meta_get_artist", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetArtist(SafeVideoInformationHandle videoInformationHandle, out IntPtr artistName);

        [DllImport(Libraries.MediaContent, EntryPoint = "video_meta_get_album_artist", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetAlbumArtist(SafeVideoInformationHandle videoInformationHandle, out IntPtr albumArtistName);

        [DllImport(Libraries.MediaContent, EntryPoint = "video_meta_get_genre", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetGenre(SafeVideoInformationHandle videoInformationHandle, out IntPtr genreName);

        [DllImport(Libraries.MediaContent, EntryPoint = "video_meta_get_composer", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetComposer(SafeVideoInformationHandle videoInformationHandle, out IntPtr composerName);

        [DllImport(Libraries.MediaContent, EntryPoint = "video_meta_get_year", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetYear(SafeVideoInformationHandle videoInformationHandle, out IntPtr year);

        [DllImport(Libraries.MediaContent, EntryPoint = "video_meta_get_recorded_date", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetRecordedDate(SafeVideoInformationHandle videoInformationHandle, out IntPtr recordedDate);

        [DllImport(Libraries.MediaContent, EntryPoint = "video_meta_get_copyright", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetCopyright(SafeVideoInformationHandle videoInformationHandle, out IntPtr copyright);

        [DllImport(Libraries.MediaContent, EntryPoint = "video_meta_get_track_num", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetTrackNum(SafeVideoInformationHandle videoInformationHandle, out IntPtr trackNum);

        [DllImport(Libraries.MediaContent, EntryPoint = "video_meta_get_bit_rate", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetBitRate(SafeVideoInformationHandle videoInformationHandle, out int bitRate);

        [DllImport(Libraries.MediaContent, EntryPoint = "video_meta_get_duration", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetDuration(SafeVideoInformationHandle videoInformationHandle, out int duration);

        [DllImport(Libraries.MediaContent, EntryPoint = "video_meta_get_width", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetWidth(SafeVideoInformationHandle videoInformationHandle, out int width);

        [DllImport(Libraries.MediaContent, EntryPoint = "video_meta_get_height", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetHeight(SafeVideoInformationHandle videoInformationHandle, out int width);

        [DllImport(Libraries.MediaContent, EntryPoint = "video_meta_get_played_count", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetPlayedCount(SafeVideoInformationHandle videoInformationHandle, out int playedCount);

        [DllImport(Libraries.MediaContent, EntryPoint = "video_meta_get_played_time", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetPlayedTime(SafeVideoInformationHandle videoInformationHandle, out int playedTime);

        [DllImport(Libraries.MediaContent, EntryPoint = "video_meta_get_played_position", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetPlayedPosition(SafeVideoInformationHandle videoInformationHandle, out int playedPosition);

        [DllImport(Libraries.MediaContent, EntryPoint = "video_meta_set_played_count", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError SetPlayedCount(SafeVideoInformationHandle videoInformationHandle, int playedCount);

        [DllImport(Libraries.MediaContent, EntryPoint = "video_meta_set_played_time", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError SetPlayedTime(SafeVideoInformationHandle videoInformationHandle, int playedTime);

        [DllImport(Libraries.MediaContent, EntryPoint = "video_meta_set_played_position", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError SetPlayedPosition(SafeVideoInformationHandle videoInformationHandle, int playedPosition);

        [DllImport(Libraries.MediaContent, EntryPoint = "video_meta_update_to_db", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError UpdateToDB(IntPtr videoInformationHandle);

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
                VideoInformation.Destroy(this.handle);
                this.SetHandle(IntPtr.Zero);
                return true;
            }
        }
    }
}