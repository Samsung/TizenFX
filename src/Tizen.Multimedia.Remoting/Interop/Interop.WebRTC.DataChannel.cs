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
using Tizen.Applications;
using Tizen.Multimedia.Remoting;

internal static partial class Interop
{
    internal static partial class NativeDataChannel
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void CreatedCallback(IntPtr handle, IntPtr dataChanndelHandle, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void OpenedCallback(IntPtr dataChannelHandle, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void MessageReceivedCallback(IntPtr dataChannelHandle, DataChannelType type, IntPtr message, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ErrorOccurredCallback(IntPtr dataChanndelHandle, WebRTCErrorCode error, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ClosedCallback(IntPtr dataChanndelHandle, IntPtr userData);


        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_create_data_channel")]
        internal static extern WebRTCErrorCode Create(IntPtr handle, string label, SafeBundleHandle bundle, out IntPtr dataChanndelHandle);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_destroy_data_channel")]
        internal static extern WebRTCErrorCode Destroy(IntPtr dataChanndelHandle);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_data_channel_send_string")]
        internal static extern WebRTCErrorCode SendString(IntPtr dataChanndelHandle, string data);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_data_channel_send_bytes")]
        internal static extern WebRTCErrorCode SendBytes(IntPtr dataChanndelHandle, byte[] data, uint size);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_data_channel_get_label")]
        internal static extern WebRTCErrorCode GetLabel(IntPtr dataChanndelHandle, out string label);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_get_data")]
        internal static extern WebRTCErrorCode GetData(IntPtr byteDataHandle, out IntPtr data, out ulong size);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_set_data_channel_cb")]
        internal static extern WebRTCErrorCode SetCreatedByPeerCb(IntPtr handle, CreatedCallback callback, IntPtr userData = default);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_unset_data_channel_cb")]
        internal static extern WebRTCErrorCode UnsetCreatedByPeerCb(IntPtr handle);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_data_channel_set_open_cb")]
        internal static extern WebRTCErrorCode SetOpenedCb(IntPtr dataChanndelHandle, OpenedCallback callback, IntPtr userData = default);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_data_channel_unset_open_cb")]
        internal static extern WebRTCErrorCode UnsetOpenedCb(IntPtr dataChanndelHandle);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_data_channel_set_message_cb")]
        internal static extern WebRTCErrorCode SetMessageReceivedCb(IntPtr dataChanndelHandle, MessageReceivedCallback callback, IntPtr userData = default);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_data_channel_unset_message_cb")]
        internal static extern WebRTCErrorCode UnsetMessageReceivedCb(IntPtr dataChanndelHandle);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_data_channel_set_error_cb")]
        internal static extern WebRTCErrorCode SetErrorOccurredCb(IntPtr dataChanndelHandle, ErrorOccurredCallback callback, IntPtr userData = default);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_data_channel_unset_error_cb")]
        internal static extern WebRTCErrorCode UnsetErrorOccurredCb(IntPtr handle);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_data_channel_set_close_cb")]
        internal static extern WebRTCErrorCode SetClosedCb(IntPtr dataChanndelHandle, ClosedCallback callback, IntPtr userData = default);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_data_channel_unset_close_cb")]
        internal static extern WebRTCErrorCode UnsetClosedCb(IntPtr handle);
    }
}