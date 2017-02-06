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

using Tizen.Applications;

internal static partial class Interop
{
    internal static partial class MessagePort
    {
        [DllImport(Libraries.MessagePort, EntryPoint = "message_port_register_local_port", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int RegisterPort(string local_port, message_port_message_cb callback, IntPtr userData);

        [DllImport(Libraries.MessagePort, EntryPoint = "message_port_register_trusted_local_port", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int RegisterTrustedPort(string trusted_local_port, message_port_message_cb callback, IntPtr userData);

        [DllImport(Libraries.MessagePort, EntryPoint = "message_port_unregister_local_port", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int UnregisterPort(int local_port_id);

        [DllImport(Libraries.MessagePort, EntryPoint = "message_port_unregister_trusted_local_port", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int UnregisterTrustedPort(int trusted_local_port_id);

        [DllImport(Libraries.MessagePort, EntryPoint = "message_port_send_message_with_local_port", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SendMessageWithLocalPort(string remote_app_id, string remote_port, SafeBundleHandle message, int local_port_id);

        [DllImport(Libraries.MessagePort, EntryPoint = "message_port_send_trusted_message_with_local_port", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SendTrustedMessageWithLocalPort(string remote_app_id, string remote_port, SafeBundleHandle message, int local_port_id);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void message_port_message_cb(int local_port_id, string remote_app_id, string remote_port, bool trusted_remote_port, IntPtr message, IntPtr userData);
    }
}
