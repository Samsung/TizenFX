/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd All Rights Reserved
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
    internal static class SignalingServer
    {
        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_signaling_server_create")]
        internal static extern WebRTCErrorCode Create(int port, out IntPtr handle);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_signaling_server_destroy")]
        internal static extern WebRTCErrorCode Destroy(IntPtr handle);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_signaling_server_start")]
        internal static extern WebRTCErrorCode Start(IntPtr handle);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_signaling_server_stop")]
        internal static extern WebRTCErrorCode Stop(IntPtr handle);
    }

    internal static class SignalingClient
    {
        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_signaling_connect")]
        internal static extern WebRTCErrorCode Connect(string serverIp, int port, SignalingMessageCallback callback, IntPtr userData, out IntPtr clientHandle);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_signaling_disconnect")]
        internal static extern WebRTCErrorCode Disconnect(IntPtr clientHandle);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_signaling_request_session")]
        internal static extern WebRTCErrorCode RequestSession(IntPtr clientHandle, int peerId);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_signaling_send_message")]
        internal static extern WebRTCErrorCode SendMessage(IntPtr clientHandle, string message);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_signaling_get_id")]
        internal static extern WebRTCErrorCode GetID(IntPtr clientHandle, out int id);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void SignalingMessageCallback(SignalingMessageType type, string message, IntPtr userData);
    }
}