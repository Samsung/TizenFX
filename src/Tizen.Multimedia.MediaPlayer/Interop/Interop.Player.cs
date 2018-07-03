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

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool AdaptiveVariantCallback(int bandwidth, int width, int height, IntPtr userData);

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

        [DllImport(Libraries.Player, EntryPoint = "player_set_replaygain_enabled")]
        internal static extern PlayerErrorCode SetReplaygain(IntPtr player, bool enabled);

        [DllImport(Libraries.Player, EntryPoint = "player_is_replaygain_enabled")]
        internal static extern PlayerErrorCode IsReplaygain(IntPtr player, out bool enabled);

        [DllImport(Libraries.Player, EntryPoint = "player_set_sound_stream_info")]
        internal static extern PlayerErrorCode SetAudioPolicyInfo(IntPtr player, AudioStreamPolicyHandle streamInfo);

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

        [DllImport(Libraries.Player, EntryPoint = "player_set_streaming_buffering_time")]
        internal static extern PlayerErrorCode SetStreamingBufferingTime(IntPtr player, int bufferingTime, int reBufferingTime);

        [DllImport(Libraries.Player, EntryPoint = "player_get_streaming_buffering_time")]
        internal static extern PlayerErrorCode GetStreamingBufferingTime(IntPtr player, out int bufferingTime, out int reBufferingTime);

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
        internal static extern PlayerErrorCode SetMediaStreamInfo(IntPtr player, StreamType type, IntPtr format);

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
        internal static extern PlayerErrorCode GetTrackCount(IntPtr player, StreamType type, out int count);

        [DllImport(Libraries.Player, EntryPoint = "player_select_track")]
        internal static extern PlayerErrorCode SelectTrack(IntPtr player, StreamType type, int index);

        [DllImport(Libraries.Player, EntryPoint = "player_get_current_track")]
        internal static extern PlayerErrorCode GetCurrentTrack(IntPtr player, StreamType type,
            out int index);

        [DllImport(Libraries.Player, EntryPoint = "player_get_track_language_code")]
        internal static extern PlayerErrorCode GetTrackLanguageCode(IntPtr player, StreamType type,
            int index, out IntPtr code);

        [DllImport(Libraries.Player, EntryPoint = "player_set_audio_only")]
        internal static extern PlayerErrorCode SetAudioOnly(IntPtr player, bool audioOnly);

        [DllImport(Libraries.Player, EntryPoint = "player_is_audio_only")]
        internal static extern PlayerErrorCode IsAudioOnly(IntPtr player, out bool audioOnly);

        [DllImport(Libraries.Player, EntryPoint = "player_360_is_content_spherical")]
        internal static extern PlayerErrorCode IsSphericalContent(IntPtr player, out bool isspherical);

        [DllImport(Libraries.Player, EntryPoint = "player_360_set_enabled")]
        internal static extern PlayerErrorCode SetSphericalMode(IntPtr player, bool enabled);

        [DllImport(Libraries.Player, EntryPoint = "player_360_is_enabled")]
        internal static extern PlayerErrorCode IsSphericalMode(IntPtr player, out bool enabled);

        [DllImport(Libraries.Player, EntryPoint = "player_360_set_direction_of_view")]
        internal static extern PlayerErrorCode SetDirectionOfView(IntPtr player, float yaw, float pitch);

        [DllImport(Libraries.Player, EntryPoint = "player_360_get_direction_of_view")]
        internal static extern PlayerErrorCode GetDirectionOfView(IntPtr player, out float yaw, out float pitch);

        [DllImport(Libraries.Player, EntryPoint = "player_360_set_zoom")]
        internal static extern PlayerErrorCode SetZoom(IntPtr player, float level);

        [DllImport(Libraries.Player, EntryPoint = "player_360_get_zoom")]
        internal static extern PlayerErrorCode GetZoom(IntPtr player, out float level);

        [DllImport(Libraries.Player, EntryPoint = "player_360_set_field_of_view")]
        internal static extern PlayerErrorCode SetFieldOfView(IntPtr player, int horizontalDegrees, int verticalDegrees);

        [DllImport(Libraries.Player, EntryPoint = "player_360_get_field_of_view")]
        internal static extern PlayerErrorCode GetFieldOfView(IntPtr player, out int horizontalDegrees, out int verticalDegrees);

        [DllImport(Libraries.Player, EntryPoint = "player_foreach_adaptive_variant")]
        internal static extern PlayerErrorCode ForeachAdaptiveVariants(IntPtr player, AdaptiveVariantCallback callback, IntPtr userData);

        [DllImport(Libraries.Player, EntryPoint = "player_set_max_adaptive_variant_limit")]
        internal static extern PlayerErrorCode SetMaxLimit(IntPtr player, int bandwidth, int width, int height);

        [DllImport(Libraries.Player, EntryPoint = "player_get_max_adaptive_variant_limit")]
        internal static extern PlayerErrorCode GetMaxLimit(IntPtr player, out int bandwidth, out int width, out int height);
    }

    internal class PlayerHandle : SafeHandle
    {
        protected PlayerHandle() : base(IntPtr.Zero, true)
        {
        }

        internal PlayerHandle(IntPtr rawHandle) : this()
        {
            handle = rawHandle;
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
