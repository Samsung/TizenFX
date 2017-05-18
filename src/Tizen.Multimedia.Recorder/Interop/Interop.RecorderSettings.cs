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
    internal static partial class RecorderSettings
    {
        [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_get_audio_channel")]
        internal static extern RecorderError GetAudioChannel(IntPtr handle, out int channelCount);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_set_audio_channel")]
        internal static extern RecorderError SetAudioChannel(IntPtr handle, int channelCount);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_get_audio_device")]
        internal static extern RecorderError GetAudioDevice(IntPtr handle, out RecorderAudioDevice device);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_set_audio_device")]
        internal static extern RecorderError SetAudioDevice(IntPtr handle, RecorderAudioDevice device);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_get_audio_level")]
        internal static extern RecorderError GetAudioLevel(IntPtr handle, out double dB);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_get_audio_samplerate")]
        internal static extern RecorderError GetAudioSampleRate(IntPtr handle, out int sampleRate);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_set_audio_samplerate")]
        internal static extern RecorderError SetAudioSampleRate(IntPtr handle, int sampleRate);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_get_audio_encoder_bitrate")]
        internal static extern RecorderError GetAudioEncoderBitrate(IntPtr handle, out int bitRate);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_set_audio_encoder_bitrate")]
        internal static extern RecorderError SetAudioEncoderBitrate(IntPtr handle, int bitRate);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_get_video_encoder_bitrate")]
        internal static extern RecorderError GetVideoEncoderBitrate(IntPtr handle, out int bitRate);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_set_video_encoder_bitrate")]
        internal static extern RecorderError SetVideoEncoderBitrate(IntPtr handle, int bitRate);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_get_audio_encoder")]
        internal static extern RecorderError GetAudioEncoder(IntPtr handle, out RecorderAudioCodec codec);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_set_audio_encoder")]
        internal static extern RecorderError SetAudioEncoder(IntPtr handle, RecorderAudioCodec codec);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_get_video_encoder")]
        internal static extern RecorderError GetVideoEncoder(IntPtr handle, out RecorderVideoCodec codec);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_set_video_encoder")]
        internal static extern RecorderError SetVideoEncoder(IntPtr handle, RecorderVideoCodec codec);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_get_file_format")]
        internal static extern RecorderError GetFileFormat(IntPtr handle, out RecorderFileFormat format);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_set_file_format")]
        internal static extern RecorderError SetFileFormat(IntPtr handle, RecorderFileFormat format);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_get_filename")]
        internal static extern RecorderError GetFileName(IntPtr handle, out IntPtr path);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_set_filename")]
        internal static extern RecorderError SetFileName(IntPtr handle, string path);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_get_size_limit")]
        internal static extern RecorderError GetSizeLimit(IntPtr handle, out int kbyte);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_set_size_limit")]
        internal static extern RecorderError SetSizeLimit(IntPtr handle, int kbyte);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_get_time_limit")]
        internal static extern RecorderError GetTimeLimit(IntPtr handle, out int second);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_set_time_limit")]
        internal static extern RecorderError SetTimeLimit(IntPtr handle, int second);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_is_muted")]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool GetMute(IntPtr handle);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_set_mute")]
        internal static extern RecorderError SetMute(IntPtr handle, bool enable);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_get_recording_motion_rate")]
        internal static extern RecorderError GetMotionRate(IntPtr handle, out double motionRate);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_set_recording_motion_rate")]
        internal static extern RecorderError SetMotionRate(IntPtr handle, double motionRate);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_get_orientation_tag")]
        internal static extern RecorderError GetOrientationTag(IntPtr handle, out RecorderOrientation orientation);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_attr_set_orientation_tag")]
        internal static extern RecorderError SetOrientationTag(IntPtr handle, RecorderOrientation orientation);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_get_video_resolution")]
        internal static extern RecorderError GetVideoResolution(IntPtr handle, out int width, out int height);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_set_video_resolution")]
        internal static extern RecorderError SetVideoResolution(IntPtr handle, int width, int height);
    }
}
