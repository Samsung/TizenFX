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
    internal static partial class AudioInformation
    {
        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_destroy", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError Destroy(IntPtr media);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_clone", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError Clone(out SafeAudioInformationHandle dst, SafeAudioInformationHandle src);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_media_id", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetMediaId(SafeAudioInformationHandle audioInformationHandle, out string mediaId);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_album", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetAlbum(SafeAudioInformationHandle audioInformationHandle, out string albumName);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_artist", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetArtist(SafeAudioInformationHandle audioInformationHandle, out string artistName);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_album_artist", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetAlbumArtist(SafeAudioInformationHandle audioInformationHandle, out string albumArtistName);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_genre", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetGenre(SafeAudioInformationHandle audioInformationHandle, out string genreName);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_composer", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetComposer(SafeAudioInformationHandle audioInformationHandle, out string composerName);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_year", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetYear(SafeAudioInformationHandle audioInformationHandle, out string year);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_recorded_date", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetRecordedDate(SafeAudioInformationHandle audioInformationHandle, out string recordedDate);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_copyright", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetCopyright(SafeAudioInformationHandle audioInformationHandle, out string copyright);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_track_num", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetTrackNum(SafeAudioInformationHandle audioInformationHandle, out string trackNum);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_bit_rate", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetBitRate(SafeAudioInformationHandle audioInformationHandle, out int bitRate);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_bitpersample", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetBitPerSample(SafeAudioInformationHandle audioInformationHandle, out int bitPerSample);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_sample_rate", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetSampleRate(SafeAudioInformationHandle audioInformationHandle, out int sampleRate);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_channel", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetChannel(SafeAudioInformationHandle audioInformationHandle, out int channel);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_duration", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetDuration(SafeAudioInformationHandle audioInformationHandle, out int duration);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_played_count", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetPlayedCount(SafeAudioInformationHandle audioInformationHandle, out int playedCount);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_played_time", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetPlayedTime(SafeAudioInformationHandle audioInformationHandle, out int playedTime);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_played_position", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetPlayedPosition(SafeAudioInformationHandle audioInformationHandle, out int playedPosition);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_set_played_count", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError SetPlayedCount(SafeAudioInformationHandle audioInformationHandle, int playedCount);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_set_played_time", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError SetPlayedTime(SafeAudioInformationHandle audioInformationHandle, int playedTime);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_set_played_position", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError SetPlayedPosition(SafeAudioInformationHandle audioInformationHandle, int playedPosition);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_update_to_db", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError UpdateToDB(IntPtr audioInformationHandle);

        internal sealed class SafeAudioInformationHandle : SafeHandle
        {
            public SafeAudioInformationHandle()
                : base(IntPtr.Zero, true)
            {
            }

            public override bool IsInvalid
            {
                get { return this.handle == IntPtr.Zero; }
            }

            protected override bool ReleaseHandle()
            {
                AudioInformation.Destroy(this.handle);
                this.SetHandle(IntPtr.Zero);
                return true;
            }
        }
    }
}