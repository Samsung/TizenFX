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
    internal static partial class AudioIO
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void AudioStreamCallback(IntPtr handle, uint nbytes, IntPtr userdata);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void AudioStateChangedCallback(IntPtr handle, int previous, int current, bool byPolicy, IntPtr userData);

        internal static partial class AudioInput
        {
            [DllImport(Libraries.AudioIO, EntryPoint = "audio_in_set_state_changed_cb")]
            internal static extern int SetStateChangedCallback(IntPtr handle, AudioStateChangedCallback callback, IntPtr user_data);

            [DllImport(Libraries.AudioIO, EntryPoint = "audio_in_set_stream_cb")]
            internal static extern int SetStreamCallback(IntPtr handle, AudioStreamCallback callback, IntPtr user_data);

            [DllImport(Libraries.AudioIO, EntryPoint = "audio_in_create")]
            internal static extern int Create(int sampleRate, int channel, int type, out IntPtr handle);

            [DllImport(Libraries.AudioIO, EntryPoint = "audio_in_destroy")]
            internal static extern int Destroy(IntPtr handle);

            [DllImport(Libraries.AudioIO, EntryPoint = "audio_in_set_sound_stream_info")]
            internal static extern int SetStreamInfo(IntPtr handle, AudioStreamPolicyHandle streamInfoHandle);

            [DllImport(Libraries.AudioIO, EntryPoint = "audio_in_prepare")]
            internal static extern int Prepare(IntPtr handle);

            [DllImport(Libraries.AudioIO, EntryPoint = "audio_in_unprepare")]
            internal static extern int Unprepare(IntPtr handle);

            [DllImport(Libraries.AudioIO, EntryPoint = "audio_in_pause")]
            internal static extern int Pause(IntPtr handle);

            [DllImport(Libraries.AudioIO, EntryPoint = "audio_in_resume")]
            internal static extern int Resume(IntPtr handle);

            [DllImport(Libraries.AudioIO, EntryPoint = "audio_in_flush")]
            internal static extern int Flush(IntPtr handle);

            [DllImport(Libraries.AudioIO, EntryPoint = "audio_in_read")]
            internal static extern int Read(IntPtr handle, byte[] buffer, int length);

            [DllImport(Libraries.AudioIO, EntryPoint = "audio_in_get_buffer_size")]
            internal static extern int GetBufferSize(IntPtr handle, out int size);

            [DllImport(Libraries.AudioIO, EntryPoint = "audio_in_get_sample_rate")]
            internal static extern int GetSampleRate(IntPtr handle, out int sampleRate);

            [DllImport(Libraries.AudioIO, EntryPoint = "audio_in_get_channel")]
            internal static extern int GetChannel(IntPtr handle, out int channel);

            [DllImport(Libraries.AudioIO, EntryPoint = "audio_in_get_sample_type")]
            internal static extern int GetSampleType(IntPtr handle, out int sampleType);

            [DllImport(Libraries.AudioIO, EntryPoint = "audio_in_peek")]
            internal static extern int Peek(IntPtr handle, out IntPtr buffer, ref uint length);

            [DllImport(Libraries.AudioIO, EntryPoint = "audio_in_drop")]
            internal static extern int Drop(IntPtr handle);
        }
        internal static partial class AudioOutput
        {
            [DllImport(Libraries.AudioIO, EntryPoint = "audio_out_set_state_changed_cb")]
            internal static extern int SetStateChangedCallback(IntPtr handle, AudioStateChangedCallback callback, IntPtr user_data);

            [DllImport(Libraries.AudioIO, EntryPoint = "audio_out_set_stream_cb")]
            internal static extern int SetStreamChangedCallback(IntPtr handle, AudioStreamCallback callback, IntPtr user_data);

            [DllImport(Libraries.AudioIO, EntryPoint = "audio_out_create_new")]
            internal static extern int Create(int sampleRate, int channel, int type, out IntPtr handle);

            [DllImport(Libraries.AudioIO, EntryPoint = "audio_out_destroy")]
            internal static extern int Destroy(IntPtr handle);

            [DllImport(Libraries.AudioIO, EntryPoint = "audio_out_drain")]
            internal static extern int Drain(IntPtr handle);

            [DllImport(Libraries.AudioIO, EntryPoint = "audio_out_flush")]
            internal static extern int Flush(IntPtr handle);

            [DllImport(Libraries.AudioIO, EntryPoint = "audio_out_get_buffer_size")]
            internal static extern int GetBufferSize(IntPtr handle, out int size);

            [DllImport(Libraries.AudioIO, EntryPoint = "audio_out_get_channel")]
            internal static extern int GetChannel(IntPtr handle, out int channel);

            [DllImport(Libraries.AudioIO, EntryPoint = "audio_out_get_sample_rate")]
            internal static extern int GetSampleRate(IntPtr handle, out int sampleRate);

            [DllImport(Libraries.AudioIO, EntryPoint = "audio_out_get_sample_type")]
            internal static extern int GetSampleType(IntPtr handle, out int sampleType);

            [DllImport(Libraries.AudioIO, EntryPoint = "audio_out_get_sound_type")]
            internal static extern int GetSoundType(IntPtr handle, out int soundType);

            [DllImport(Libraries.AudioIO, EntryPoint = "audio_out_pause")]
            internal static extern int Pause(IntPtr handle);

            [DllImport(Libraries.AudioIO, EntryPoint = "audio_out_prepare")]
            internal static extern int Prepare(IntPtr handle);

            [DllImport(Libraries.AudioIO, EntryPoint = "audio_out_resume")]
            internal static extern int Resume(IntPtr handle);

            [DllImport(Libraries.AudioIO, EntryPoint = "audio_out_set_sound_stream_info")]
            internal static extern int SetStreamInfo(IntPtr handle, AudioStreamPolicyHandle streamInfoHandle);

            [DllImport(Libraries.AudioIO, EntryPoint = "audio_out_unprepare")]
            internal static extern int Unprepare(IntPtr handle);

            [DllImport(Libraries.AudioIO, EntryPoint = "audio_out_write")]
            internal static extern int Write(IntPtr handle, byte[] buffer, uint length);
        }
    }
}
