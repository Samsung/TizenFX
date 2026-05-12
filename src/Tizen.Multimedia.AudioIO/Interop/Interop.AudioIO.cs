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
    internal static partial class AudioIO
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void AudioStreamCallback(IntPtr handle, uint nbytes, IntPtr userdata);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void AudioStateChangedCallback(IntPtr handle, int previous, int current, bool byPolicy, IntPtr userData);

        internal static partial class AudioInput
        {
            [LibraryImport(Libraries.AudioIO, EntryPoint = "audio_in_set_state_changed_cb")]
            internal static partial AudioIOError SetStateChangedCallback(IntPtr handle, AudioStateChangedCallback callback, IntPtr user_data);

            [LibraryImport(Libraries.AudioIO, EntryPoint = "audio_in_set_stream_cb")]
            internal static partial AudioIOError SetStreamCallback(IntPtr handle, AudioStreamCallback callback, IntPtr user_data);

            [LibraryImport(Libraries.AudioIO, EntryPoint = "audio_in_create")]
            internal static partial AudioIOError Create(int sampleRate, int channel, int type, out IntPtr handle);

            [LibraryImport(Libraries.AudioIO, EntryPoint = "audio_in_destroy")]
            internal static partial AudioIOError Destroy(IntPtr handle);

            [LibraryImport(Libraries.AudioIO, EntryPoint = "audio_in_set_sound_stream_info")]
            internal static partial AudioIOError SetStreamInfo(IntPtr handle, AudioStreamPolicyHandle streamInfoHandle);

            [LibraryImport(Libraries.AudioIO, EntryPoint = "audio_in_prepare")]
            internal static partial AudioIOError Prepare(IntPtr handle);

            [LibraryImport(Libraries.AudioIO, EntryPoint = "audio_in_unprepare")]
            internal static partial AudioIOError Unprepare(IntPtr handle);

            [LibraryImport(Libraries.AudioIO, EntryPoint = "audio_in_pause")]
            internal static partial AudioIOError Pause(IntPtr handle);

            [LibraryImport(Libraries.AudioIO, EntryPoint = "audio_in_resume")]
            internal static partial AudioIOError Resume(IntPtr handle);

            [LibraryImport(Libraries.AudioIO, EntryPoint = "audio_in_flush")]
            internal static partial AudioIOError Flush(IntPtr handle);

            [LibraryImport(Libraries.AudioIO, EntryPoint = "audio_in_read")]
            internal static partial AudioIOError Read(IntPtr handle, byte[] buffer, int length);

            [LibraryImport(Libraries.AudioIO, EntryPoint = "audio_in_peek")]
            internal static partial AudioIOError Peek(IntPtr handle, out IntPtr buffer, ref uint length);

            [LibraryImport(Libraries.AudioIO, EntryPoint = "audio_in_drop")]
            internal static partial AudioIOError Drop(IntPtr handle);

            [LibraryImport(Libraries.AudioIO, EntryPoint = "audio_in_get_buffer_size")]
            internal static partial AudioIOError GetBufferSize(IntPtr handle, out int size);

            [LibraryImport(Libraries.AudioIO, EntryPoint = "audio_in_get_sample_rate")]
            internal static partial AudioIOError GetSampleRate(IntPtr handle, out int sampleRate);

            [LibraryImport(Libraries.AudioIO, EntryPoint = "audio_in_get_channel")]
            internal static partial AudioIOError GetChannel(IntPtr handle, out int channel);

            [LibraryImport(Libraries.AudioIO, EntryPoint = "audio_in_get_sample_type")]
            internal static partial AudioIOError GetSampleType(IntPtr handle, out int sampleType);

            [LibraryImport(Libraries.AudioIO, EntryPoint = "audio_in_get_volume")]
            internal static partial AudioIOError GetVolume(IntPtr handle, out double volume);

            [LibraryImport(Libraries.AudioIO, EntryPoint = "audio_in_set_volume")]
            internal static partial AudioIOError SetVolume(IntPtr handle, double volume);
        }
        internal static partial class AudioOutput
        {
            [LibraryImport(Libraries.AudioIO, EntryPoint = "audio_out_set_state_changed_cb")]
            internal static partial AudioIOError SetStateChangedCallback(IntPtr handle, AudioStateChangedCallback callback, IntPtr user_data);

            [LibraryImport(Libraries.AudioIO, EntryPoint = "audio_out_set_stream_cb")]
            internal static partial AudioIOError SetStreamChangedCallback(IntPtr handle, AudioStreamCallback callback, IntPtr user_data);

            [LibraryImport(Libraries.AudioIO, EntryPoint = "audio_out_create_new")]
            internal static partial AudioIOError Create(int sampleRate, int channel, int type, out IntPtr handle);

            [LibraryImport(Libraries.AudioIO, EntryPoint = "audio_out_destroy")]
            internal static partial AudioIOError Destroy(IntPtr handle);

            [LibraryImport(Libraries.AudioIO, EntryPoint = "audio_out_drain")]
            internal static partial AudioIOError Drain(IntPtr handle);

            [LibraryImport(Libraries.AudioIO, EntryPoint = "audio_out_flush")]
            internal static partial AudioIOError Flush(IntPtr handle);

            [LibraryImport(Libraries.AudioIO, EntryPoint = "audio_out_get_buffer_size")]
            internal static partial AudioIOError GetBufferSize(IntPtr handle, out int size);

            [LibraryImport(Libraries.AudioIO, EntryPoint = "audio_out_get_channel")]
            internal static partial AudioIOError GetChannel(IntPtr handle, out int channel);

            [LibraryImport(Libraries.AudioIO, EntryPoint = "audio_out_get_sample_rate")]
            internal static partial AudioIOError GetSampleRate(IntPtr handle, out int sampleRate);

            [LibraryImport(Libraries.AudioIO, EntryPoint = "audio_out_get_sample_type")]
            internal static partial AudioIOError GetSampleType(IntPtr handle, out int sampleType);

            [LibraryImport(Libraries.AudioIO, EntryPoint = "audio_out_get_sound_type")]
            internal static partial AudioIOError GetSoundType(IntPtr handle, out int soundType);

            [LibraryImport(Libraries.AudioIO, EntryPoint = "audio_out_pause")]
            internal static partial AudioIOError Pause(IntPtr handle);

            [LibraryImport(Libraries.AudioIO, EntryPoint = "audio_out_prepare")]
            internal static partial AudioIOError Prepare(IntPtr handle);

            [LibraryImport(Libraries.AudioIO, EntryPoint = "audio_out_resume")]
            internal static partial AudioIOError Resume(IntPtr handle);

            [LibraryImport(Libraries.AudioIO, EntryPoint = "audio_out_set_sound_stream_info")]
            internal static partial AudioIOError SetStreamInfo(IntPtr handle, AudioStreamPolicyHandle streamInfoHandle);

            [LibraryImport(Libraries.AudioIO, EntryPoint = "audio_out_unprepare")]
            internal static partial AudioIOError Unprepare(IntPtr handle);

            [LibraryImport(Libraries.AudioIO, EntryPoint = "audio_out_write")]
            internal static partial AudioIOError Write(IntPtr handle, byte[] buffer, uint length);
        }
    }
}

