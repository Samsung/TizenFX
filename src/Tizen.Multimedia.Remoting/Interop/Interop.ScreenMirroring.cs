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
using System.Drawing;
using System.Runtime.InteropServices;
using Tizen.Internals;
using Tizen.Multimedia;
using Tizen.Multimedia.Remoting;

internal static partial class Interop
{
    internal static partial class ScreenMirroring
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void StateChangedCallback(ScreenMirroringErrorCode error,
            ScreenMirroringState state, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void SrcDisplayOrientationReceivedCallback(ScreenMirroringDisplayOrientation orientation, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void UibcInfoReceivedCallback(ScreenMirroringErrorCode error, IntPtr info, IntPtr userData);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_create")]
        internal static extern ScreenMirroringErrorCode Create(out IntPtr handle);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_set_state_changed_cb")]
        internal static extern ScreenMirroringErrorCode SetStateChangedCb(IntPtr handle,
            StateChangedCallback cb, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_set_ip_and_port")]
        internal static extern ScreenMirroringErrorCode SetIpAndPort(IntPtr handle, string ip, string port);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_set_display")]
        internal static extern ScreenMirroringErrorCode SetDisplay(IntPtr handle, int type, IntPtr display);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_set_display_mode")]
        internal static extern ScreenMirroringErrorCode SetDisplayMode(IntPtr handle, ScreenMirroringDisplayMode mode);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_set_display_roi")]
        internal static extern ScreenMirroringErrorCode SetDisplayRoi(IntPtr handle, int x, int y, int width, int height);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_set_display_rotation")]
        internal static extern ScreenMirroringErrorCode SetDisplayRotation(IntPtr handle, Rotation rotatjion);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_set_ecore_wl_display")]
        internal static extern ScreenMirroringErrorCode SetEcoreDisplay(IntPtr handle, IntPtr display);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_set_resolution")]
        internal static extern ScreenMirroringErrorCode SetResolution(IntPtr handle, ScreenMirroringResolutions resolution);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_set_src_device_type")]
        internal static extern ScreenMirroringErrorCode SetSrcDeviceType(IntPtr handle, ScreenMirroringDeviceType type);

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

        // UIBC
        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_set_src_display_orientation_notify_cb")]
        internal static extern ScreenMirroringErrorCode SetSrcDisplayOrientationChangedCb(IntPtr handle,
            SrcDisplayOrientationReceivedCallback callback, IntPtr userData = default);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_set_uibc_info_received_cb")]
        internal static extern ScreenMirroringErrorCode SetUibcInfoReceivedCb(IntPtr handle,
            UibcInfoReceivedCallback callback, IntPtr userData = default);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_set_window_size")]
        internal static extern ScreenMirroringErrorCode SetWindowSize(IntPtr handle, int width, int height);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_enable_uibc")]
        internal static extern ScreenMirroringErrorCode EnableUibc(IntPtr handle, ScreenMirroringCaptureMode mode);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_send_generic_mouse_event")]
        internal static extern ScreenMirroringErrorCode SendGenericMouseEvent(IntPtr handle, IntPtr uibcEvent);

        [DllImport(Libraries.ScreenMirroring, EntryPoint = "scmirroring_sink_send_generic_key_event")]
        internal static extern ScreenMirroringErrorCode SendGenericKeyEvent(IntPtr handle, ScreenMirroringKeyEventType type, ushort keyCode1, ushort keyCode2);

        [NativeStruct("scmirroring_uibc_input_s", Include = "scmirroring_type_internal.h", PkgConfig = "capi-media-screen-mirroring")]
        [StructLayout(LayoutKind.Sequential)]
        internal struct UibcInput
        {
            internal ScreenMirroringUibcInputType type;
            internal ScreenMirroringUibcInputPath path;
        }

        [NativeStruct("scmirroring_uibc_info_s", Include = "scmirroring_type_internal.h", PkgConfig = "capi-media-screen-mirroring")]
        [StructLayout(LayoutKind.Sequential)]
        internal struct UibcInfo
        {
            internal string Ip;
            internal uint Port;
            internal uint GenCapability;
            internal int Width;
            internal int Height;
            internal IntPtr hidcCapsList;
            internal uint hidcCapsSize;
        }

        [NativeStruct("scmirroring_uibc_mouse_s", Include = "scmirroring_type_internal.h", PkgConfig = "capi-media-screen-mirroring")]
        [StructLayout(LayoutKind.Sequential)]
        internal struct UibcMouse
        {
            internal ushort id;
            internal ushort x;
            internal ushort y;
        }

        [NativeStruct("scmirroring_uibc_mouse_event_s", Include = "scmirroring_type_internal.h", PkgConfig = "capi-media-screen-mirroring")]
        [StructLayout(LayoutKind.Sequential)]
        internal struct UibcMouseEvent
        {
            internal int size;
            internal ScreenMirroringMouseEventType type;
            internal IntPtr uibcMouse;
        }
    }
}
