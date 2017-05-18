using System;
using System.Runtime.InteropServices;
using Tizen;
using Tizen.Multimedia;

internal static partial class Interop
{
    internal static partial class NativePlayer
    {

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void PlaybackCompletedCallback(IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void PlaybackInterruptedCallback(PlaybackInterruptionReason code, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void PlaybackErrorCallback(int code, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void VideoFrameDecodedCallback(IntPtr packetHandle, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void SubtitleUpdatedCallback(uint duration, string text, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void BufferingProgressCallback(int percent, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void VideoStreamChangedCallback(int width, int height, int fps, int bitrate, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void MediaStreamBufferStatusCallback(MediaStreamBufferStatus status, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void MediaStreamSeekCallback(ulong offset, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void VideoCaptureCallback(IntPtr data, int width, int height, uint size, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void PrepareCallback(IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void SeekCompletedCallback(IntPtr userData);


        [DllImport(Libraries.Player, EntryPoint = "player_create")]
        internal static extern PlayerErrorCode Create(out PlayerHandle player);

        [DllImport(Libraries.Player, EntryPoint = "player_destroy")]
        internal static extern PlayerErrorCode Destroy(IntPtr player);

        [DllImport(Libraries.Player, EntryPoint = "player_prepare")]
        internal static extern PlayerErrorCode Prepare(IntPtr player);

        [DllImport(Libraries.Player, EntryPoint = "player_unprepare")]
        internal static extern PlayerErrorCode Unprepare(IntPtr player);

        [DllImport(Libraries.Player, EntryPoint = "player_set_uri")]
        internal static extern PlayerErrorCode SetUri(IntPtr player, string uri);

        [DllImport(Libraries.Player, EntryPoint = "player_set_display")]
        internal static extern PlayerErrorCode SetDisplay(IntPtr player, DisplayType type, IntPtr display);

        [DllImport(Libraries.Player, EntryPoint = "player_start")]
        internal static extern PlayerErrorCode Start(IntPtr player);

        [DllImport(Libraries.Player, EntryPoint = "player_stop")]
        internal static extern PlayerErrorCode Stop(IntPtr player);

        [DllImport(Libraries.Player, EntryPoint = "player_pause")]
        internal static extern PlayerErrorCode Pause(IntPtr player);

        [DllImport(Libraries.Player, EntryPoint = "player_set_memory_buffer")]
        internal static extern PlayerErrorCode SetMemoryBuffer(IntPtr player, byte[] data, int size);

        [DllImport(Libraries.Player, EntryPoint = "player_get_state")]
        internal static extern PlayerErrorCode GetState(IntPtr player, out int state);

        [DllImport(Libraries.Player, EntryPoint = "player_set_volume")]
        internal static extern PlayerErrorCode SetVolume(IntPtr player, float left, float right);

        [DllImport(Libraries.Player, EntryPoint = "player_get_volume")]
        internal static extern PlayerErrorCode GetVolume(IntPtr player, out float left, out float right);

        [DllImport(Libraries.Player, EntryPoint = "player_set_sound_stream_info")]
        internal static extern PlayerErrorCode SetAudioPolicyInfo(IntPtr player, IntPtr streamInfo);

        [DllImport(Libraries.Player, EntryPoint = "player_set_audio_latency_mode")]
        internal static extern PlayerErrorCode SetAudioLatencyMode(IntPtr player, AudioLatencyMode latencyMode);

        [DllImport(Libraries.Player, EntryPoint = "player_get_audio_latency_mode")]
        internal static extern PlayerErrorCode GetAudioLatencyMode(IntPtr player, out AudioLatencyMode latencyMode);

        [DllImport(Libraries.Player, EntryPoint = "player_get_play_position")]
        internal static extern PlayerErrorCode GetPlayPosition(IntPtr player, out int millisecond);

        [DllImport(Libraries.Player, EntryPoint = "player_set_play_position")]
        internal static extern PlayerErrorCode SetPlayPosition(IntPtr player, int millisecond,
            bool accurate, SeekCompletedCallback cb, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.Player, EntryPoint = "player_set_mute")]
        internal static extern PlayerErrorCode SetMute(IntPtr player, bool muted);

        [DllImport(Libraries.Player, EntryPoint = "player_is_muted")]
        internal static extern PlayerErrorCode IsMuted(IntPtr player, out bool muted);

        [DllImport(Libraries.Player, EntryPoint = "player_set_looping")]
        internal static extern PlayerErrorCode SetLooping(IntPtr player, bool looping);

        [DllImport(Libraries.Player, EntryPoint = "player_is_looping")]
        internal static extern PlayerErrorCode IsLooping(IntPtr player, out bool looping);

        [DllImport(Libraries.Player, EntryPoint = "player_set_completed_cb")]
        internal static extern PlayerErrorCode SetCompletedCb(IntPtr player,
            PlaybackCompletedCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.Player, EntryPoint = "player_unset_completed_cb")]
        internal static extern PlayerErrorCode UnsetCompletedCb(IntPtr player);

        [DllImport(Libraries.Player, EntryPoint = "player_set_interrupted_cb")]
        internal static extern PlayerErrorCode SetInterruptedCb(IntPtr player,
            PlaybackInterruptedCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.Player, EntryPoint = "player_unset_interrupted_cb")]
        internal static extern PlayerErrorCode UnsetInterruptedCb(IntPtr player);

        [DllImport(Libraries.Player, EntryPoint = "player_set_error_cb")]
        internal static extern PlayerErrorCode SetErrorCb(IntPtr player, PlaybackErrorCallback callback,
            IntPtr userData = default(IntPtr));

        [DllImport(Libraries.Player, EntryPoint = "player_unset_error_cb")]
        internal static extern PlayerErrorCode UnsetErrorCb(IntPtr player);

        [DllImport(Libraries.Player, EntryPoint = "player_capture_video")]
        internal static extern PlayerErrorCode CaptureVideo(IntPtr player, VideoCaptureCallback callback,
            IntPtr userData = default(IntPtr));

        [DllImport(Libraries.Player, EntryPoint = "player_set_media_packet_video_frame_decoded_cb")]
        internal static extern PlayerErrorCode SetVideoFrameDecodedCb(IntPtr player, VideoFrameDecodedCallback callback,
            IntPtr userData = default(IntPtr));

        [DllImport(Libraries.Player, EntryPoint = "player_unset_media_packet_video_frame_decoded_cb")]
        internal static extern PlayerErrorCode UnsetVideoFrameDecodedCb(IntPtr player);

        [DllImport(Libraries.Player, EntryPoint = "player_set_streaming_cookie")]
        internal static extern PlayerErrorCode SetStreamingCookie(IntPtr player, string cookie, int size);

        [DllImport(Libraries.Player, EntryPoint = "player_set_streaming_user_agent")]
        internal static extern PlayerErrorCode SetStreamingUserAgent(IntPtr player, string userAgent, int size);

        [DllImport(Libraries.Player, EntryPoint = "player_get_streaming_download_progress")]
        internal static extern PlayerErrorCode GetStreamingDownloadProgress(IntPtr player, out int start, out int current);

        [DllImport(Libraries.Player, EntryPoint = "player_set_buffering_cb")]
        internal static extern PlayerErrorCode SetBufferingCb(IntPtr player,
            BufferingProgressCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.Player, EntryPoint = "player_unset_buffering_cb")]
        internal static extern PlayerErrorCode UnsetBufferingCb(IntPtr player);

        [DllImport(Libraries.Player, EntryPoint = "player_set_playback_rate")]
        internal static extern PlayerErrorCode SetPlaybackRate(IntPtr player, float rate);

        [DllImport(Libraries.Player, EntryPoint = "player_push_media_stream")]
        internal static extern PlayerErrorCode PushMediaStream(IntPtr player, IntPtr packet);

        [DllImport(Libraries.Player, EntryPoint = "player_set_media_stream_info")]
        internal static extern PlayerErrorCode SetMediaStreamInfo(IntPtr player, int type, IntPtr format);

        [DllImport(Libraries.Player, EntryPoint = "player_set_media_stream_buffer_status_cb")]
        internal static extern PlayerErrorCode SetMediaStreamBufferStatusCb(IntPtr player, StreamType type,
            MediaStreamBufferStatusCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.Player, EntryPoint = "player_unset_media_stream_buffer_status_cb")]
        internal static extern PlayerErrorCode UnsetMediaStreamBufferStatusCb(IntPtr player, int type);

        [DllImport(Libraries.Player, EntryPoint = "player_set_media_stream_seek_cb")]
        internal static extern PlayerErrorCode SetMediaStreamSeekCb(IntPtr player, StreamType type,
            MediaStreamSeekCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.Player, EntryPoint = "player_unset_media_stream_seek_cb")]
        internal static extern PlayerErrorCode UnsetMediaStreamSeekCb(IntPtr player, int type);

        [DllImport(Libraries.Player, EntryPoint = "player_set_media_stream_buffer_max_size")]
        internal static extern PlayerErrorCode SetMediaStreamBufferMaxSize(IntPtr player, StreamType type, ulong maxSize);

        [DllImport(Libraries.Player, EntryPoint = "player_get_media_stream_buffer_max_size")]
        internal static extern PlayerErrorCode GetMediaStreamBufferMaxSize(IntPtr player, StreamType type, out ulong maxSize);

        [DllImport(Libraries.Player, EntryPoint = "player_set_media_stream_buffer_min_threshold")]
        internal static extern PlayerErrorCode SetMediaStreamBufferMinThreshold(IntPtr player, StreamType type, uint percent);

        [DllImport(Libraries.Player, EntryPoint = "player_get_media_stream_buffer_min_threshold")]
        internal static extern PlayerErrorCode GetMediaStreamBufferMinThreshold(IntPtr player, int type, out uint percent);

        [DllImport(Libraries.Player, EntryPoint = "player_audio_effect_get_equalizer_bands_count")]
        internal static extern PlayerErrorCode AudioEffectGetEqualizerBandsCount(IntPtr player, out int count);

        [DllImport(Libraries.Player, EntryPoint = "player_audio_effect_set_equalizer_band_level")]
        internal static extern PlayerErrorCode AudioEffectSetEqualizerBandLevel(IntPtr player, int index, int level);

        [DllImport(Libraries.Player, EntryPoint = "player_audio_effect_get_equalizer_band_level")]
        internal static extern PlayerErrorCode AudioEffectGetEqualizerBandLevel(IntPtr player, int index, out int level);

        [DllImport(Libraries.Player, EntryPoint = "player_audio_effect_set_equalizer_all_bands")]
        internal static extern PlayerErrorCode AudioEffectSetEqualizerAllBands(IntPtr player, out int band_levels, int length);

        [DllImport(Libraries.Player, EntryPoint = "player_audio_effect_get_equalizer_level_range")]
        internal static extern PlayerErrorCode AudioEffectGetEqualizerLevelRange(IntPtr player, out int min, out int max);

        [DllImport(Libraries.Player, EntryPoint = "player_audio_effect_get_equalizer_band_frequency")]
        internal static extern PlayerErrorCode AudioEffectGetEqualizerBandFrequency(IntPtr player, int index, out int frequency);

        [DllImport(Libraries.Player, EntryPoint = "player_audio_effect_get_equalizer_band_frequency_range")]
        internal static extern PlayerErrorCode AudioEffectGetEqualizerBandFrequencyRange(IntPtr player, int index, out int range);

        [DllImport(Libraries.Player, EntryPoint = "player_audio_effect_equalizer_clear")]
        internal static extern PlayerErrorCode AudioEffectEqualizerClear(IntPtr player);

        [DllImport(Libraries.Player, EntryPoint = "player_audio_effect_equalizer_is_available")]
        internal static extern PlayerErrorCode AudioEffectEqualizerIsAvailable(IntPtr player, out bool available);

        [DllImport(Libraries.Player, EntryPoint = "player_set_display_mode")]
        internal static extern PlayerErrorCode SetDisplayMode(IntPtr player, PlayerDisplayMode mode);

        [DllImport(Libraries.Player, EntryPoint = "player_get_display_mode")]
        internal static extern PlayerErrorCode GetDisplayMode(IntPtr player, out int mode);

        [DllImport(Libraries.Player, EntryPoint = "player_set_display_visible")]
        internal static extern PlayerErrorCode SetDisplayVisible(IntPtr player, bool visible);

        [DllImport(Libraries.Player, EntryPoint = "player_is_display_visible")]
        internal static extern PlayerErrorCode IsDisplayVisible(IntPtr player, out bool visible);

        [DllImport(Libraries.Player, EntryPoint = "player_set_display_rotation")]
        internal static extern PlayerErrorCode SetDisplayRotation(IntPtr player, PlayerDisplayRotation rotation);

        [DllImport(Libraries.Player, EntryPoint = "player_get_display_rotation")]
        internal static extern PlayerErrorCode GetDisplayRotation(IntPtr player, out int rotation);

        [DllImport(Libraries.Player, EntryPoint = "player_set_display_roi_area")]
        internal static extern PlayerErrorCode SetDisplayRoi(IntPtr player, int x, int y, int width, int height);

        [DllImport(Libraries.Player, EntryPoint = "player_get_content_info")]
        internal static extern PlayerErrorCode GetContentInfo(IntPtr player, StreamMetadataKey key, out IntPtr value);

        [DllImport(Libraries.Player, EntryPoint = "player_get_codec_info")]
        internal static extern PlayerErrorCode GetCodecInfo(IntPtr player, out IntPtr audioCodec, out IntPtr videoCodec);

        [DllImport(Libraries.Player, EntryPoint = "player_get_audio_stream_info")]
        internal static extern PlayerErrorCode GetAudioStreamInfo(IntPtr player, out int sampleRate, out int channel, out int bitRate);

        [DllImport(Libraries.Player, EntryPoint = "player_get_video_stream_info")]
        internal static extern PlayerErrorCode GetVideoStreamInfo(IntPtr player, out int fps, out int bitRate);

        [DllImport(Libraries.Player, EntryPoint = "player_get_album_art")]
        internal static extern PlayerErrorCode GetAlbumArt(IntPtr player, out IntPtr albumArt, out int size);

        [DllImport(Libraries.Player, EntryPoint = "player_get_video_size")]
        internal static extern PlayerErrorCode GetVideoSize(IntPtr player, out int width, out int height);

        [DllImport(Libraries.Player, EntryPoint = "player_get_duration")]
        internal static extern PlayerErrorCode GetDuration(IntPtr player, out int duration);

        [DllImport(Libraries.Player, EntryPoint = "player_set_subtitle_path")]
        internal static extern PlayerErrorCode SetSubtitlePath(IntPtr player, string path);

        [DllImport(Libraries.Player, EntryPoint = "player_set_subtitle_updated_cb")]
        internal static extern PlayerErrorCode SetSubtitleUpdatedCb(IntPtr player,
            SubtitleUpdatedCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.Player, EntryPoint = "player_unset_subtitle_updated_cb")]
        internal static extern PlayerErrorCode UnsetSubtitleUpdatedCb(IntPtr player);

        [DllImport(Libraries.Player, EntryPoint = "player_set_subtitle_position_offset")]
        internal static extern PlayerErrorCode SetSubtitlePositionOffset(IntPtr player, int millisecond);

        [DllImport(Libraries.Player, EntryPoint = "player_set_video_stream_changed_cb")]
        internal static extern PlayerErrorCode SetVideoStreamChangedCb(IntPtr player,
            VideoStreamChangedCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.Player, EntryPoint = "player_unset_video_stream_changed_cb")]
        internal static extern PlayerErrorCode UnsetVideoStreamChangedCb(IntPtr player);

        [DllImport(Libraries.Player, EntryPoint = "player_get_track_count")]
        internal static extern PlayerErrorCode GetTrackCount(IntPtr player, int type, out int count);

        [DllImport(Libraries.Player, EntryPoint = "player_select_track")]
        internal static extern PlayerErrorCode SelectTrack(IntPtr player, int type, int index);

        [DllImport(Libraries.Player, EntryPoint = "player_get_current_track")]
        internal static extern PlayerErrorCode GetCurrentTrack(IntPtr player, int type, out int index);

        [DllImport(Libraries.Player, EntryPoint = "player_get_track_language_code")]
        internal static extern PlayerErrorCode GetTrackLanguageCode(IntPtr player, int type, int index, out IntPtr code);
    }

    internal class PlayerHandle : SafeHandle
    {
        protected PlayerHandle() : base(IntPtr.Zero, true)
        {
        }

        public override bool IsInvalid => handle == IntPtr.Zero;

        protected override bool ReleaseHandle()
        {
            var ret = NativePlayer.Destroy(handle);
            if (ret != PlayerErrorCode.None)
            {
                Log.Debug(GetType().FullName, $"Failed to release native {GetType().Name}");
                return false;
            }

            return true;
        }
    }
}
