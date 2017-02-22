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

internal static partial class Interop
{
    internal enum VideoCodec
    {
        Mpeg4, // VIDEO_UTIL_VIDEO_CODEC_MPEG4
        H263, // VIDEO_UTIL_VIDEO_CODEC_H263
        H264, // VIDEO_UTIL_VIDEO_CODEC_H264
        None, // VIDEO_UTIL_VIDEO_CODEC_NONE
    }

    internal enum AudioCodec
    {
        Aac, // VIDEO_UTIL_AUDIO_CODEC_AAC
        Amrnb, // VIDEO_UTIL_AUDIO_CODEC_AMRNB
        None, // VIDEO_UTIL_AUDIO_CODEC_NONE
    }

    internal enum VideoFileFormat
    {
        Format3Gp, // VIDEO_UTIL_FILE_FORMAT_3GP
        FormatMp4, // VIDEO_UTIL_FILE_FORMAT_MP4
        FormatMax, // VIDEO_UTIL_FILE_FORMAT_MAX
    }


    [DllImport(Libraries.VideoUtil, EntryPoint = "video_util_foreach_supported_file_format")]
    internal static extern ErrorCode ForeachSupportedFileFormat(this VideoTranscoderHandle /* video_util_h */ handle, VideoTranscoderHandle.SupportedFileFormatCallback callback, IntPtr /* void */ userData);

    [DllImport(Libraries.VideoUtil, EntryPoint = "video_util_foreach_supported_video_codec")]
    internal static extern ErrorCode ForeachSupportedVideoCodec(this VideoTranscoderHandle /* video_util_h */ handle, VideoTranscoderHandle.SupportedVideoEncoderCallback callback, IntPtr /* void */ userData);

    [DllImport(Libraries.VideoUtil, EntryPoint = "video_util_foreach_supported_audio_codec")]
    internal static extern ErrorCode ForeachSupportedAudioCodec(this VideoTranscoderHandle /* video_util_h */ handle, VideoTranscoderHandle.SupportedAudioEncoderCallback callback, IntPtr /* void */ userData);

    [DllImport(Libraries.VideoUtil, EntryPoint = "video_util_start_transcoding")]
    internal static extern ErrorCode StartTranscoding(this VideoTranscoderHandle /* video_util_h */ handle, ulong start, ulong duration,
        string outPath, VideoTranscoderHandle.TranscodingProgressCallback progressCb, VideoTranscoderHandle.TranscodingCompletedCallback completedCb, IntPtr /* void */ userData);

    [DllImport(Libraries.VideoUtil, EntryPoint = "video_util_cancel_transcoding")]
    internal static extern ErrorCode CancelTranscoding(this VideoTranscoderHandle /* video_util_h */ handle);

    [DllImport(Libraries.VideoUtil, EntryPoint = "video_util_get_progress_transcoding")]
    internal static extern ErrorCode GetProgressTranscoding(this VideoTranscoderHandle /* video_util_h */ handle, out ulong currentPosition, out ulong duration);

    [DllImport(Libraries.VideoUtil, EntryPoint = "video_util_set_resolution")]
    internal static extern ErrorCode SetResolution(this VideoTranscoderHandle /* video_util_h */ handle, int width, int height);


    [DllImport(Libraries.VideoUtil, EntryPoint = "video_util_set_file_path")]
    internal static extern ErrorCode SetFilePath(this VideoTranscoderHandle /* video_util_h */ handle, string path);

    [DllImport(Libraries.VideoUtil, EntryPoint = "video_util_set_accurate_mode")]
    internal static extern ErrorCode SetAccurateMode(this VideoTranscoderHandle /* video_util_h */ handle, bool mode);

    [DllImport(Libraries.VideoUtil, EntryPoint = "video_util_set_video_codec")]
    internal static extern ErrorCode SetVideoCodec(this VideoTranscoderHandle /* video_util_h */ handle, VideoCodec /* video_util_video_codec_e */ codec);

    [DllImport(Libraries.VideoUtil, EntryPoint = "video_util_set_audio_codec")]
    internal static extern ErrorCode SetAudioCodec(this VideoTranscoderHandle /* video_util_h */ handle, AudioCodec /* video_util_audio_codec_e */ codec);

    [DllImport(Libraries.VideoUtil, EntryPoint = "video_util_set_file_format")]
    internal static extern ErrorCode SetFileFormat(this VideoTranscoderHandle /* video_util_h */ handle, VideoFileFormat /* video_util_file_format_e */ format);

    [DllImport(Libraries.VideoUtil, EntryPoint = "video_util_set_fps")]
    internal static extern ErrorCode SetFps(this VideoTranscoderHandle /* video_util_h */ handle, int fps);

    internal class VideoTranscoderHandle : SafeMultimediaHandle
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void TranscodingProgressCallback(ulong currentPosition, ulong duration, IntPtr /* void */ userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void TranscodingCompletedCallback(ErrorCode /* video_util_error_e */ errorCode, IntPtr /* void */ userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool SupportedFileFormatCallback(VideoFileFormat /* video_util_file_format_e */ format, IntPtr /* void */ userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool SupportedVideoEncoderCallback(VideoCodec /* video_util_video_codec_e */ codec, IntPtr /* void */ userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool SupportedAudioEncoderCallback(AudioCodec /* video_util_audio_codec_e */ codec, IntPtr /* void */ userData);

        [DllImport(Libraries.VideoUtil, EntryPoint = "video_util_create")]
        internal static extern ErrorCode Create(out IntPtr /* video_util_h */ handle);

        [DllImport(Libraries.VideoUtil, EntryPoint = "video_util_destroy")]
        internal static extern ErrorCode Destroy(IntPtr /* video_util_h */ handle);

        internal string InputFile
        {
            set { NativeSet(this.SetFilePath, value); }
        }

        internal bool AccurateModeEnabled
        {
            set { NativeSet(this.SetAccurateMode, value); }
        }

        internal VideoCodec VideoCodec
        {
            set { NativeSet(this.SetVideoCodec, value); }
        }

        internal AudioCodec AudioCodec
        {
            set { NativeSet(this.SetAudioCodec, value); }
        }

        internal VideoFileFormat FileFormat
        {
            set { NativeSet(this.SetFileFormat, value); }
        }

        internal int Fps
        {
            set { NativeSet(this.SetFps, value); }
        }

        internal VideoTranscoderHandle(IntPtr handle, bool needToRelease) : base(handle, needToRelease)
        {
        }

        internal VideoTranscoderHandle() : this(CreateNativeHandle(), true)
        {
        }

        internal static IntPtr CreateNativeHandle()
        {
            IntPtr handle;
            Create(out handle).ThrowIfFailed("Failed to create native handle");
            return handle;
        }

        internal override ErrorCode DisposeNativeHandle()
        {
            return Destroy(handle);
        }

        internal void ForeachSupportedFileFormat(Action<VideoFileFormat> action)
        {
            SupportedFileFormatCallback callback = (codec, userData) =>
            {
                action(codec);
                return true;
            };

            this.ForeachSupportedFileFormat(callback, IntPtr.Zero).ThrowIfFailed("Failed to get supported file format list from native handle");
        }

        internal void ForeachSupportedVideoCodec(Action<VideoCodec> action)
        {
            SupportedVideoEncoderCallback callback = (codec, userData) =>
            {
                action(codec);
                return true;
            };

            this.ForeachSupportedVideoCodec(callback, IntPtr.Zero).ThrowIfFailed("Failed to get supported video codec list from native handle");
        }

        internal void ForeachSupportedAudioCodec(Action<AudioCodec> action)
        {
            SupportedAudioEncoderCallback callback = (codec, userData) =>
            {
                action(codec);
                return true;
            };

            this.ForeachSupportedAudioCodec(callback, IntPtr.Zero).ThrowIfFailed("Failed to get supported audio codec list from native handle");
        }
    }
}
