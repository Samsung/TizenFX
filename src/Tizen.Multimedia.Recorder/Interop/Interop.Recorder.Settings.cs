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
using System.Runtime.InteropServices.Marshalling;
using Tizen.Multimedia;

internal static partial class Interop
{
    internal static partial class Recorder
    {
        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_attr_get_audio_channel")]
        internal static partial RecorderErrorCode GetAudioChannel(RecorderHandle handle, out int channelCount);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_attr_set_audio_channel")]
        internal static partial RecorderErrorCode SetAudioChannel(RecorderHandle handle, int channelCount);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_attr_get_audio_device")]
        internal static partial RecorderErrorCode GetAudioDevice(RecorderHandle handle, out RecorderAudioDevice device);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_attr_set_audio_device")]
        internal static partial RecorderErrorCode SetAudioDevice(RecorderHandle handle, RecorderAudioDevice device);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_get_audio_level")]
        internal static partial RecorderErrorCode GetAudioLevel(RecorderHandle handle, out double dB);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_attr_get_audio_samplerate")]
        internal static partial RecorderErrorCode GetAudioSampleRate(RecorderHandle handle, out int sampleRate);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_attr_set_audio_samplerate")]
        internal static partial RecorderErrorCode SetAudioSampleRate(RecorderHandle handle, int sampleRate);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_attr_get_audio_encoder_bitrate")]
        internal static partial RecorderErrorCode GetAudioEncoderBitrate(RecorderHandle handle, out int bitRate);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_attr_set_audio_encoder_bitrate")]
        internal static partial RecorderErrorCode SetAudioEncoderBitrate(RecorderHandle handle, int bitRate);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_attr_get_video_encoder_bitrate")]
        internal static partial RecorderErrorCode GetVideoEncoderBitrate(RecorderHandle handle, out int bitRate);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_attr_set_video_encoder_bitrate")]
        internal static partial RecorderErrorCode SetVideoEncoderBitrate(RecorderHandle handle, int bitRate);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_get_audio_encoder")]
        internal static partial RecorderErrorCode GetAudioEncoder(RecorderHandle handle, out RecorderAudioCodec codec);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_set_audio_encoder")]
        internal static partial RecorderErrorCode SetAudioEncoder(RecorderHandle handle, RecorderAudioCodec codec);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_get_video_encoder")]
        internal static partial RecorderErrorCode GetVideoEncoder(RecorderHandle handle, out RecorderVideoCodec codec);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_set_video_encoder")]
        internal static partial RecorderErrorCode SetVideoEncoder(RecorderHandle handle, RecorderVideoCodec codec);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_get_file_format")]
        internal static partial RecorderErrorCode GetFileFormat(RecorderHandle handle, out RecorderFileFormat format);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_set_file_format")]
        internal static partial RecorderErrorCode SetFileFormat(RecorderHandle handle, RecorderFileFormat format);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_get_filename")]
        internal static partial RecorderErrorCode GetFileName(RecorderHandle handle, out IntPtr path);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_set_filename", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial RecorderErrorCode SetFileName(RecorderHandle handle, string path);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_attr_get_size_limit")]
        internal static partial RecorderErrorCode GetSizeLimit(RecorderHandle handle, out int kbyte);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_attr_set_size_limit")]
        internal static partial RecorderErrorCode SetSizeLimit(RecorderHandle handle, int kbyte);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_attr_get_time_limit")]
        internal static partial RecorderErrorCode GetTimeLimit(RecorderHandle handle, out int second);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_attr_set_time_limit")]
        internal static partial RecorderErrorCode SetTimeLimit(RecorderHandle handle, int second);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_attr_is_muted")]
        [return: MarshalAs(UnmanagedType.U1)]
        internal static partial bool GetMute(RecorderHandle handle);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_attr_set_mute")]
        internal static partial RecorderErrorCode SetMute(RecorderHandle handle, [MarshalAs(UnmanagedType.U1)] bool enable);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_attr_get_recording_motion_rate")]
        internal static partial RecorderErrorCode GetMotionRate(RecorderHandle handle, out double motionRate);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_attr_set_recording_motion_rate")]
        internal static partial RecorderErrorCode SetMotionRate(RecorderHandle handle, double motionRate);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_attr_get_orientation_tag")]
        internal static partial RecorderErrorCode GetOrientationTag(RecorderHandle handle, out Rotation orientation);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_attr_set_orientation_tag")]
        internal static partial RecorderErrorCode SetOrientationTag(RecorderHandle handle, Rotation orientation);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_get_video_resolution")]
        internal static partial RecorderErrorCode GetVideoResolution(RecorderHandle handle, out int width, out int height);

        [LibraryImport(Libraries.Recorder, EntryPoint = "recorder_set_video_resolution")]
        internal static partial RecorderErrorCode SetVideoResolution(RecorderHandle handle, int width, int height);
    }
}
