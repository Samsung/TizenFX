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
    internal static partial class RecorderFeatures
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool VideoResolutionCallback(int width, int height, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool FileFormatCallback(RecorderFileFormat format, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool AudioEncoderCallback(RecorderAudioCodec codec, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool VideoEncoderCallback(RecorderVideoCodec codec, IntPtr userData);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_foreach_supported_file_format")]
        internal static extern RecorderError FileFormats(IntPtr handle, FileFormatCallback callback, IntPtr userData);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_foreach_supported_audio_encoder")]
        internal static extern RecorderError AudioEncoders(IntPtr handle, AudioEncoderCallback callback, IntPtr userData);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_foreach_supported_video_encoder")]
        internal static extern RecorderError VideoEncoders(IntPtr handle, VideoEncoderCallback callback, IntPtr userData);

        [DllImport(Libraries.Recorder, EntryPoint = "recorder_foreach_supported_video_resolution")]
        internal static extern RecorderError VideoResolution(IntPtr handle, VideoResolutionCallback callback, IntPtr userData);
    }
}
