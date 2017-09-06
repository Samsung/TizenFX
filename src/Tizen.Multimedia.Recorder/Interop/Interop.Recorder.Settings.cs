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
using Tizen.Multimedia;

internal static partial class Interop
{
    internal static partial class Recorder
    {
        [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_get_audio_channel")]
        internal static extern RecorderErrorCode GetAudioChannel(RecorderHandle handle, out int channelCount);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_set_audio_channel")]
        internal static extern RecorderErrorCode SetAudioChannel(RecorderHandle handle, int channelCount);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_get_audio_device")]
        internal static extern RecorderErrorCode GetAudioDevice(RecorderHandle handle, out RecorderAudioDevice device);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_set_audio_device")]
        internal static extern RecorderErrorCode SetAudioDevice(RecorderHandle handle, RecorderAudioDevice device);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_get_audio_level")]
        internal static extern RecorderErrorCode GetAudioLevel(RecorderHandle handle, out double dB);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_get_audio_samplerate")]
        internal static extern RecorderErrorCode GetAudioSampleRate(RecorderHandle handle, out int sampleRate);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_set_audio_samplerate")]
        internal static extern RecorderErrorCode SetAudioSampleRate(RecorderHandle handle, int sampleRate);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_get_audio_encoder_bitrate")]
        internal static extern RecorderErrorCode GetAudioEncoderBitrate(RecorderHandle handle, out int bitRate);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_set_audio_encoder_bitrate")]
        internal static extern RecorderErrorCode SetAudioEncoderBitrate(RecorderHandle handle, int bitRate);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_get_video_encoder_bitrate")]
        internal static extern RecorderErrorCode GetVideoEncoderBitrate(RecorderHandle handle, out int bitRate);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_set_video_encoder_bitrate")]
        internal static extern RecorderErrorCode SetVideoEncoderBitrate(RecorderHandle handle, int bitRate);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_get_audio_encoder")]
        internal static extern RecorderErrorCode GetAudioEncoder(RecorderHandle handle, out RecorderAudioCodec codec);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_set_audio_encoder")]
        internal static extern RecorderErrorCode SetAudioEncoder(RecorderHandle handle, RecorderAudioCodec codec);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_get_video_encoder")]
        internal static extern RecorderErrorCode GetVideoEncoder(RecorderHandle handle, out RecorderVideoCodec codec);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_set_video_encoder")]
        internal static extern RecorderErrorCode SetVideoEncoder(RecorderHandle handle, RecorderVideoCodec codec);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_get_file_format")]
        internal static extern RecorderErrorCode GetFileFormat(RecorderHandle handle, out RecorderFileFormat format);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_set_file_format")]
        internal static extern RecorderErrorCode SetFileFormat(RecorderHandle handle, RecorderFileFormat format);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_get_filename")]
        internal static extern RecorderErrorCode GetFileName(RecorderHandle handle, out IntPtr path);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_set_filename")]
        internal static extern RecorderErrorCode SetFileName(RecorderHandle handle, string path);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_get_size_limit")]
        internal static extern RecorderErrorCode GetSizeLimit(RecorderHandle handle, out int kbyte);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_set_size_limit")]
        internal static extern RecorderErrorCode SetSizeLimit(RecorderHandle handle, int kbyte);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_get_time_limit")]
        internal static extern RecorderErrorCode GetTimeLimit(RecorderHandle handle, out int second);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_set_time_limit")]
        internal static extern RecorderErrorCode SetTimeLimit(RecorderHandle handle, int second);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_is_muted")]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool GetMute(RecorderHandle handle);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_set_mute")]
        internal static extern RecorderErrorCode SetMute(RecorderHandle handle, bool enable);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_get_recording_motion_rate")]
        internal static extern RecorderErrorCode GetMotionRate(RecorderHandle handle, out double motionRate);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_set_recording_motion_rate")]
        internal static extern RecorderErrorCode SetMotionRate(RecorderHandle handle, double motionRate);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_get_orientation_tag")]
        internal static extern RecorderErrorCode GetOrientationTag(RecorderHandle handle, out Rotation orientation);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_set_orientation_tag")]
        internal static extern RecorderErrorCode SetOrientationTag(RecorderHandle handle, Rotation orientation);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_get_video_resolution")]
        internal static extern RecorderErrorCode GetVideoResolution(RecorderHandle handle, out int width, out int height);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_set_video_resolution")]
        internal static extern RecorderErrorCode SetVideoResolution(RecorderHandle handle, int width, int height);
    }
}
