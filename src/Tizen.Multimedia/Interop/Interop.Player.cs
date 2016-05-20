using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class Player
    {

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void PlaybackCompletedCallback(IntPtr userData);
	
	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void PlaybackInterruptedCallback(int code, IntPtr userData);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void PlaybackErrorCallback(int code, IntPtr userData);

	//[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	//internal delegate void VideoFrameDecodedCallback(MediaPacket packet, IntPtr userData);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void SubtitleUpdatedCallback(ulong duration, string text, IntPtr userData);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void BufferingProgressCallback(int percent, IntPtr userData);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void ProgressiveDownloadMessageCallback(int type, IntPtr userData);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void VideoStreamChangedCallback(int width, int height, int fps, int bitrate, IntPtr userData);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void BufferStatusCallback(int status, IntPtr userData);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void SeekOffsetChangedCallback(UInt64 offset, IntPtr userData);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void VideoCaptureCallback(byte[] data, int width, int height, uint size, IntPtr userData);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void PrepareCallback(IntPtr userData);

	[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
	internal delegate void SeekCompletedCallback(IntPtr userData);


	[DllImport(Libraries.Player, EntryPoint = "player_create")]
	internal static extern int  Create(out IntPtr player);

	[DllImport(Libraries.Player, EntryPoint = "player_destroy")]
	internal static extern int  Destroy(IntPtr player);

	[DllImport(Libraries.Player, EntryPoint = "player_prepare")]
	internal static extern int  Prepare(IntPtr player);

	[DllImport(Libraries.Player, EntryPoint = "player_prepare_async")]
	internal static extern int  PrepareAsync(IntPtr player, PrepareCallback cb, IntPtr userData);

	[DllImport(Libraries.Player, EntryPoint = "player_unprepare")]
	internal static extern int  Unprepare(IntPtr player);

	[DllImport(Libraries.Player, EntryPoint = "player_set_uri")]
	internal static extern int  SetUri(IntPtr player, string uri);

	[DllImport(Libraries.Player, EntryPoint = "player_set_display")]
	internal static extern int  SetDisplay(IntPtr player, int type, IntPtr display);

	[DllImport(Libraries.Player, EntryPoint = "player_start")]
	internal static extern int  Start(IntPtr player);

	[DllImport(Libraries.Player, EntryPoint = "player_stop")]
	internal static extern int  Stop(IntPtr player);

	[DllImport(Libraries.Player, EntryPoint = "player_pause")]
	internal static extern int  Pause(IntPtr player);

	[DllImport(Libraries.Player, EntryPoint = "player_set_memory_buffer")]
	internal static extern int  SetMemoryBuffer(IntPtr player, IntPtr data, int size);

	[DllImport(Libraries.Player, EntryPoint = "player_get_state")]
	internal static extern int  GetState(IntPtr player, out int state);

	[DllImport(Libraries.Player, EntryPoint = "player_set_volume")]
	internal static extern int  SetVolume(IntPtr player, float left, float right);

	[DllImport(Libraries.Player, EntryPoint = "player_get_volume")]
	internal static extern int  GetVolume(IntPtr player, out float left, out float right);

	[DllImport(Libraries.Player, EntryPoint = "player_set_audio_policy_info")]
	internal static extern int  SetAudioPolicyInfo(IntPtr player, IntPtr stream_info);

	[DllImport(Libraries.Player, EntryPoint = "player_set_audio_latency_mode")]
	internal static extern int  SetAudioLatencyMode(IntPtr player, int latency_mode);

	[DllImport(Libraries.Player, EntryPoint = "player_get_audio_latency_mode")]
	internal static extern int  GetAudioLatencyMode(IntPtr player, out int latency_mode);

	[DllImport(Libraries.Player, EntryPoint = "player_get_play_position")]
	internal static extern int  GetPlayPosition(IntPtr player, out int millisecond);

	[DllImport(Libraries.Player, EntryPoint = "player_set_play_position")]
	internal static extern int  SetPlayPosition(IntPtr player, int millisecond, bool accurate, SeekCompletedCallback cb, IntPtr userData);

	[DllImport(Libraries.Player, EntryPoint = "player_set_mute")]
	internal static extern int  SetMute(IntPtr player, bool muted);

	[DllImport(Libraries.Player, EntryPoint = "player_is_muted")]
	internal static extern int  IsMuted(IntPtr player, out bool muted);

	[DllImport(Libraries.Player, EntryPoint = "player_set_looping")]
	internal static extern int  SetLooping(IntPtr player, bool looping);

	[DllImport(Libraries.Player, EntryPoint = "player_is_looping")]
	internal static extern int  IsLooping(IntPtr player, out bool looping);

	[DllImport(Libraries.Player, EntryPoint = "player_set_completed_cb")]
	internal static extern int  SetCompletedCb(IntPtr player, PlaybackCompletedCallback callback, IntPtr user_data);

	[DllImport(Libraries.Player, EntryPoint = "player_unset_completed_cb")]
	internal static extern int  UnsetCompletedCb(IntPtr player);

	[DllImport(Libraries.Player, EntryPoint = "player_set_interrupted_cb")]
	internal static extern int  SetInterruptedCb(IntPtr player, PlaybackInterruptedCallback callback, IntPtr user_data);

	[DllImport(Libraries.Player, EntryPoint = "player_unset_interrupted_cb")]
	internal static extern int  UnsetInterruptedCb(IntPtr player);

	[DllImport(Libraries.Player, EntryPoint = "player_set_error_cb")]
	internal static extern int  SetErrorCb(IntPtr player, PlaybackErrorCallback callback, IntPtr user_data);

	[DllImport(Libraries.Player, EntryPoint = "player_unset_error_cb")]
	internal static extern int  UnsetErrorCb(IntPtr player);

	[DllImport(Libraries.Player, EntryPoint = "player_capture_video")]
	internal static extern int  CaptureVideo(IntPtr player, VideoCaptureCallback callback, IntPtr user_data);

	//[DllImport(Libraries.Player, EntryPoint = "player_set_media_packet_video_frame_decoded_cb")]
	//internal static extern int  SetMediaPacketVideoFrameDecodedCb(IntPtr player, _videoFrameDecodedCallback callback, IntPtr user_data);

	[DllImport(Libraries.Player, EntryPoint = "player_unset_media_packet_video_frame_decoded_cb")]
	internal static extern int  UnsetMediaPacketVideoFrameDecodedCb(IntPtr player);

	[DllImport(Libraries.Player, EntryPoint = "player_set_streaming_cookie")]
	internal static extern int  SetStreamingCookie(IntPtr player, string cookie, int size);

	[DllImport(Libraries.Player, EntryPoint = "player_set_streaming_user_agent")]
	internal static extern int  SetStreamingUserAgent(IntPtr player, string user_agent, int size);

	[DllImport(Libraries.Player, EntryPoint = "player_get_streaming_download_progress")]
	internal static extern int  GetStreamingDownloadProgress(IntPtr player, out int start, out int current);

	[DllImport(Libraries.Player, EntryPoint = "player_set_buffering_cb")]
	internal static extern int  SetBufferingCb(IntPtr player, BufferingProgressCallback callback, IntPtr user_data);

	[DllImport(Libraries.Player, EntryPoint = "player_unset_buffering_cb")]
	internal static extern int  UnsetBufferingCb(IntPtr player);

	[DllImport(Libraries.Player, EntryPoint = "player_set_progressive_download_path")]
	internal static extern int  SetProgressiveDownloadPath(IntPtr player, string path);

	//[DllImport(Libraries.Player, EntryPoint = "player_get_progressive_download_status")]
	//internal static extern int  GetProgressiveDownloadStatus(IntPtr player, unsigned long *current, unsigned long *total_size);

	[DllImport(Libraries.Player, EntryPoint = "player_set_progressive_download_message_cb")]
	internal static extern int  SetProgressiveDownloadMessageCb(IntPtr player, ProgressiveDownloadMessageCallback callback, IntPtr user_data);

	[DllImport(Libraries.Player, EntryPoint = "player_unset_progressive_download_message_cb")]
	internal static extern int  UnsetProgressiveDownloadMessageCb(IntPtr player);

	[DllImport(Libraries.Player, EntryPoint = "player_set_playback_rate")]
	internal static extern int  SetPlaybackRate(IntPtr player, float rate);

	[DllImport(Libraries.Player, EntryPoint = "player_push_media_stream")]
	internal static extern int  PushMediaStream(IntPtr player, IntPtr packet);

	[DllImport(Libraries.Player, EntryPoint = "player_set_media_stream_info")]
	internal static extern int  SetMediaStreamInfo(IntPtr player, int type, IntPtr format);

	[DllImport(Libraries.Player, EntryPoint = "player_set_media_stream_buffer_status_cb")]
	internal static extern int  SetMediaStreamBufferStatusCb(IntPtr player, int type, BufferStatusCallback callback, IntPtr user_data);

	[DllImport(Libraries.Player, EntryPoint = "player_unset_media_stream_buffer_status_cb")]
	internal static extern int  UnsetMediaStreamBufferStatusCb(IntPtr player, int type);

	[DllImport(Libraries.Player, EntryPoint = "player_set_media_stream_seek_cb")]
	internal static extern int  SetMediaStreamSeekCb(IntPtr player, int type, SeekOffsetChangedCallback callback, IntPtr user_data);

	[DllImport(Libraries.Player, EntryPoint = "player_unset_media_stream_seek_cb")]
	internal static extern int  UnsetMediaStreamSeekCb(IntPtr player, int type);

	[DllImport(Libraries.Player, EntryPoint = "player_set_media_stream_buffer_max_size")]
	internal static extern int  SetMediaStreamBufferMaxSize(IntPtr player, int type, ulong max_size);

	[DllImport(Libraries.Player, EntryPoint = "player_get_media_stream_buffer_max_size")]
	internal static extern int  GetMediaStreamBufferMaxSize(IntPtr player, int type, out ulong max_size);

	[DllImport(Libraries.Player, EntryPoint = "player_set_media_stream_buffer_min_threshold")]
	internal static extern int  SetMediaStreamBufferMinThreshold(IntPtr player, int type, uint percent);

	[DllImport(Libraries.Player, EntryPoint = "player_get_media_stream_buffer_min_threshold")]
	internal static extern int  GetMediaStreamBufferMinThreshold(IntPtr player, int type, out uint percent);

	[DllImport(Libraries.Player, EntryPoint = "player_audio_effect_get_equalizer_bands_count")]
	internal static extern int  AudioEffectGetEqualizerBandsCount(IntPtr player, out int count);

	[DllImport(Libraries.Player, EntryPoint = "player_audio_effect_set_equalizer_band_level")]
	internal static extern int  AudioEffectSetEqualizerBandLevel(IntPtr player, int index, int level);

	[DllImport(Libraries.Player, EntryPoint = "player_audio_effect_get_equalizer_band_level")]
	internal static extern int  AudioEffectGetEqualizerBandLevel(IntPtr player, int index, out int level);

	[DllImport(Libraries.Player, EntryPoint = "player_audio_effect_set_equalizer_all_bands")]
	internal static extern int  AudioEffectSetEqualizerAllBands(IntPtr player, out int band_levels, int length);

	[DllImport(Libraries.Player, EntryPoint = "player_audio_effect_get_equalizer_level_range")]
	internal static extern int  AudioEffectGetEqualizerLevelRange(IntPtr player, out int min, out int max);

	[DllImport(Libraries.Player, EntryPoint = "player_audio_effect_get_equalizer_band_frequency")]
	internal static extern int  AudioEffectGetEqualizerBandFrequency(IntPtr player, int index, out int frequency);

	[DllImport(Libraries.Player, EntryPoint = "player_audio_effect_get_equalizer_band_frequency_range")]
	internal static extern int  AudioEffectGetEqualizerBandFrequencyRange(IntPtr player, int index, out int range);

	[DllImport(Libraries.Player, EntryPoint = "player_audio_effect_equalizer_clear")]
	internal static extern int  AudioEffectEqualizerClear(IntPtr player);

	[DllImport(Libraries.Player, EntryPoint = "player_audio_effect_equalizer_is_available")]
	internal static extern int  AudioEffectEqualizerIsAvailable(IntPtr player, out bool available);

	[DllImport(Libraries.Player, EntryPoint = "player_set_display_mode")]
	internal static extern int  SetDisplayMode(IntPtr player, int mode);

	[DllImport(Libraries.Player, EntryPoint = "player_get_display_mode")]
	internal static extern int  GetDisplayMode(IntPtr player, out int mode);

	[DllImport(Libraries.Player, EntryPoint = "player_set_display_visible")]
	internal static extern int  SetDisplayVisible(IntPtr player, bool visible);

	[DllImport(Libraries.Player, EntryPoint = "player_is_display_visible")]
	internal static extern int  IsDisplayVisible(IntPtr player, out bool visible);

	[DllImport(Libraries.Player, EntryPoint = "player_set_display_rotation")]
	internal static extern int  SetDisplayRotation(IntPtr player, int rotation);

	[DllImport(Libraries.Player, EntryPoint = "player_get_display_rotation")]
	internal static extern int  GetDisplayRotation(IntPtr player, out int rotation);

	[DllImport(Libraries.Player, EntryPoint = "player_get_content_info")]
	internal static extern int  GetContentInfo(IntPtr player, int key, out string value);

	[DllImport(Libraries.Player, EntryPoint = "player_get_codec_info")]
	internal static extern int  GetCodecInfo(IntPtr player, out string audio_codec, out string video_codec);

	[DllImport(Libraries.Player, EntryPoint = "player_get_audio_stream_info")]
	internal static extern int  GetAudioStreamInfo(IntPtr player, out int sample_rate, out int channel, out int bit_rate);

	[DllImport(Libraries.Player, EntryPoint = "player_get_video_stream_info")]
	internal static extern int  GetVideoStreamInfo(IntPtr player, out int fps, out int bit_rate);

	[DllImport(Libraries.Player, EntryPoint = "player_get_album_art")]
	internal static extern int  GetAlbumArt(IntPtr player, out IntPtr album_art, out int size);

	[DllImport(Libraries.Player, EntryPoint = "player_get_video_size")]
	internal static extern int  GetVideoSize(IntPtr player, out int width, out int height);

	[DllImport(Libraries.Player, EntryPoint = "player_get_duration")]
	internal static extern int  GetDuration(IntPtr player, out int duration);

	[DllImport(Libraries.Player, EntryPoint = "player_set_subtitle_path")]
	internal static extern int  SetSubtitlePath(IntPtr player, string path);

	[DllImport(Libraries.Player, EntryPoint = "player_set_subtitle_updated_cb")]
	internal static extern int  SetSubtitleUpdatedCb(IntPtr player, SubtitleUpdatedCallback callback, IntPtr user_data);

	[DllImport(Libraries.Player, EntryPoint = "player_unset_subtitle_updated_cb")]
	internal static extern int  UnsetSubtitleUpdatedCb(IntPtr player);

	[DllImport(Libraries.Player, EntryPoint = "player_set_subtitle_position_offset")]
	internal static extern int  SetSubtitlePositionOffset(IntPtr player, int millisecond);

	[DllImport(Libraries.Player, EntryPoint = "player_set_video_stream_changed_cb")]
	internal static extern int  SetVideoStreamChangedCb(IntPtr player, VideoStreamChangedCallback callback, IntPtr user_data);

	[DllImport(Libraries.Player, EntryPoint = "player_unset_video_stream_changed_cb")]
	internal static extern int  UnsetVideoStreamChangedCb(IntPtr player);

	[DllImport(Libraries.Player, EntryPoint = "player_get_track_count")]
	internal static extern int  GetTrackCount(IntPtr player, int type, out int count);

	[DllImport(Libraries.Player, EntryPoint = "player_select_track")]
	internal static extern int  SelectTrack(IntPtr player, int type, int index);

	[DllImport(Libraries.Player, EntryPoint = "player_get_current_track")]
	internal static extern int  GetCurrentTrack(IntPtr player, int type, out int index);

	[DllImport(Libraries.Player, EntryPoint = "player_get_track_language_code")]
	internal static extern int  GetTrackLanguageCode(IntPtr player, int type, int index, out string code);

    }
}