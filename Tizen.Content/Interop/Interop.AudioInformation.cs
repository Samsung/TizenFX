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
        internal static extern int Destroy(IntPtr media);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_clone", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Clone(out SafeAudioInformationHandle dst, SafeAudioInformationHandle src);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_media_id", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetMediaId(SafeAudioInformationHandle audioInformationHandle, out string mediaId);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_album", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetAlbum(SafeAudioInformationHandle audioInformationHandle, out string albumName);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_artist", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetArtist(SafeAudioInformationHandle audioInformationHandle, out string artistName);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_album_artist", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetAlbumArtist(SafeAudioInformationHandle audioInformationHandle, out string albumArtistName);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_genre", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetGenre(SafeAudioInformationHandle audioInformationHandle, out string genreName);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_composer", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetComposer(SafeAudioInformationHandle audioInformationHandle, out string composerName);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_year", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetYear(SafeAudioInformationHandle audioInformationHandle, out string year);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_recorded_date", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetRecordedDate(SafeAudioInformationHandle audioInformationHandle, out string recordedDate);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_copyright", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetCopyright(SafeAudioInformationHandle audioInformationHandle, out string copyright);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_track_num", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetTrackNum(SafeAudioInformationHandle audioInformationHandle, out string trackNum);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_bit_rate", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetBitRate(SafeAudioInformationHandle audioInformationHandle, out int bitRate);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_bitpersample", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetBitPerSample(SafeAudioInformationHandle audioInformationHandle, out int bitPerSample);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_sample_rate", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetSampleRate(SafeAudioInformationHandle audioInformationHandle, out int sampleRate);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_channel", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetChannel(SafeAudioInformationHandle audioInformationHandle, out int channel);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_duration", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetDuration(SafeAudioInformationHandle audioInformationHandle, out int duration);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_played_count", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetPlayedCount(SafeAudioInformationHandle audioInformationHandle, out int playedCount);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_played_time", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetPlayedTime(SafeAudioInformationHandle audioInformationHandle, out int playedTime);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_get_played_position", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetPlayedPosition(SafeAudioInformationHandle audioInformationHandle, out int playedPosition);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_set_played_count", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetPlayedCount(SafeAudioInformationHandle audioInformationHandle, int playedCount);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_set_played_time", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetPlayedTime(SafeAudioInformationHandle audioInformationHandle, int playedTime);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_set_played_position", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetPlayedPosition(SafeAudioInformationHandle audioInformationHandle, int playedPosition);

        [DllImport(Libraries.MediaContent, EntryPoint = "audio_meta_update_to_db", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int UpdateToDB(IntPtr audioInformationHandle);

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
                Tizen.Log.Info(Globals.LogTag, "SafeAudioInformationHandle::ReleaseHandle called");
                AudioInformation.Destroy(this.handle);
                this.SetHandle(IntPtr.Zero);
                return true;
            }
        }
    }
}