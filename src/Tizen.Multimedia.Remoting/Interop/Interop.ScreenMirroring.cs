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
    internal static partial class ScreenMirroring
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void StateChangedCallback(IntPtr userData, int state, int error);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_create")]
        internal static extern int Create(out IntPtr scmirroringSink);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_set_state_changed_cb")]
        internal static extern int SetStateChangedCb(IntPtr scmirroringSink, StateChangedCallback cb, IntPtr userData);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_set_ip_and_port")]
        internal static extern int SetIpAndPort(IntPtr scmirroringSink, string ip, string port);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_set_display")]
        internal static extern int SetDisplay(IntPtr scmirroringSink, int type, IntPtr display);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_set_resolution")]
        internal static extern int SetResolution(IntPtr scmirroringSink, int resolution);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_prepare")]
        internal static extern int Prepare(IntPtr scmirroringSink);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_connect")]
        internal static extern int ConnectAsync(IntPtr scmirroringSink);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_start")]
        internal static extern int StartAsync(IntPtr scmirroringSink);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_pause")]
        internal static extern int PauseAsync(IntPtr scmirroringSink);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_resume")]
        internal static extern int ResumeAsync(IntPtr scmirroringSink);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_disconnect")]
        internal static extern int Disconnect(IntPtr scmirroringSink);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_unprepare")]
        internal static extern int Unprepare(IntPtr scmirroringSink);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_unset_state_changed_cb")]
        internal static extern int UnsetStateChangedCb(IntPtr scmirroringSink);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_destroy")]
        internal static extern int Destroy(IntPtr scmirroringSink);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_get_negotiated_video_codec")]
        internal static extern int GetNegotiatedVideoCodec(ref IntPtr scmirroringSink, out int codec);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_get_negotiated_video_resolution")]
        internal static extern int GetNegotiatedVideoResolution(ref IntPtr scmirroringSink, out int width, out int height);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_get_negotiated_video_frame_rate")]
        internal static extern int GetNegotiatedVideoFrameRate(ref IntPtr scmirroringSink, out int frameRate);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_get_negotiated_audio_codec")]
        internal static extern int GetNegotiatedAudioCodec(ref IntPtr scmirroringSink, out int codec);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_get_negotiated_audio_channel")]
        internal static extern int GetNegotiatedAudioChannel(ref IntPtr scmirroringSink, out int channel);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_get_negotiated_audio_sample_rate")]
        internal static extern int GetNegotiatedAudioSampleRate(ref IntPtr scmirroringSink, out int sampleRate);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_get_negotiated_audio_bitwidth")]
        internal static extern int GetNegotiatedAudioBitwidth(ref IntPtr scmirroringSink, out int bitwidth);
    }
}
