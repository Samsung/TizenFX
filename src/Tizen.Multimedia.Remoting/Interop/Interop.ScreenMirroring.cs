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
using Tizen.Multimedia.Remoting;

internal static partial class Interop
{
    internal static partial class ScreenMirroring
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void StateChangedCallback(ScreenMirroringErrorCode error,
            ScreenMirroringState state, IntPtr userData);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_create")]
        internal static extern ScreenMirroringErrorCode Create(out IntPtr handle);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_set_state_changed_cb")]
        internal static extern ScreenMirroringErrorCode SetStateChangedCb(IntPtr handle,
            StateChangedCallback cb, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_set_ip_and_port")]
        internal static extern ScreenMirroringErrorCode SetIpAndPort(IntPtr handle, string ip, string port);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_set_display")]
        internal static extern ScreenMirroringErrorCode SetDisplay(IntPtr handle, int type, IntPtr display);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_set_resolution")]
        internal static extern ScreenMirroringErrorCode SetResolution(IntPtr handle, ScreenMirroringResolutions resolution);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_prepare")]
        internal static extern ScreenMirroringErrorCode Prepare(IntPtr handle);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_connect")]
        internal static extern ScreenMirroringErrorCode Connect(IntPtr handle);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_start")]
        internal static extern ScreenMirroringErrorCode Start(IntPtr handle);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_pause")]
        internal static extern ScreenMirroringErrorCode Pause(IntPtr handle);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_resume")]
        internal static extern ScreenMirroringErrorCode Resume(IntPtr handle);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_disconnect")]
        internal static extern ScreenMirroringErrorCode Disconnect(IntPtr handle);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_unprepare")]
        internal static extern ScreenMirroringErrorCode Unprepare(IntPtr handle);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_unset_state_changed_cb")]
        internal static extern int UnsetStateChangedCb(IntPtr handle);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_destroy")]
        internal static extern int Destroy(IntPtr handle);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_get_negotiated_video_codec")]
        internal static extern ScreenMirroringErrorCode GetNegotiatedVideoCodec(ref IntPtr handle,
            out ScreenMirroringVideoCodec codec);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_get_negotiated_video_resolution")]
        internal static extern ScreenMirroringErrorCode GetNegotiatedVideoResolution(ref IntPtr handle,
            out int width, out int height);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_get_negotiated_video_frame_rate")]
        internal static extern ScreenMirroringErrorCode GetNegotiatedVideoFrameRate(ref IntPtr handle,
            out int frameRate);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_get_negotiated_audio_codec")]
        internal static extern ScreenMirroringErrorCode GetNegotiatedAudioCodec(ref IntPtr handle,
            out ScreenMirroringAudioCodec codec);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_get_negotiated_audio_channel")]
        internal static extern ScreenMirroringErrorCode GetNegotiatedAudioChannel(ref IntPtr handle,
            out int channel);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_get_negotiated_audio_sample_rate")]
        internal static extern ScreenMirroringErrorCode GetNegotiatedAudioSampleRate(ref IntPtr handle,
            out int sampleRate);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_get_negotiated_audio_bitwidth")]
        internal static extern ScreenMirroringErrorCode GetNegotiatedAudioBitwidth(ref IntPtr handle,
            out int bitwidth);
    }
}
