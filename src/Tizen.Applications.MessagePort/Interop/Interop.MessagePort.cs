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

using Tizen.Applications;

internal static partial class Interop
{
    internal static partial class MessagePort
    {
        [LibraryImport(Libraries.MessagePort, EntryPoint = "message_port_register_local_port", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int RegisterPort(string local_port, message_port_message_cb callback, IntPtr userData);

        [LibraryImport(Libraries.MessagePort, EntryPoint = "message_port_register_trusted_local_port", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int RegisterTrustedPort(string trusted_local_port, message_port_message_cb callback, IntPtr userData);

        [LibraryImport(Libraries.MessagePort, EntryPoint = "message_port_unregister_local_port")]
        internal static partial int UnregisterPort(int local_port_id);

        [LibraryImport(Libraries.MessagePort, EntryPoint = "message_port_unregister_trusted_local_port")]
        internal static partial int UnregisterTrustedPort(int trusted_local_port_id);

        [LibraryImport(Libraries.MessagePort, EntryPoint = "message_port_send_message_with_local_port", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int SendMessageWithLocalPort(string remote_app_id, string remote_port, SafeBundleHandle message, int local_port_id);

        [LibraryImport(Libraries.MessagePort, EntryPoint = "message_port_send_trusted_message_with_local_port", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int SendTrustedMessageWithLocalPort(string remote_app_id, string remote_port, SafeBundleHandle message, int local_port_id);

        [LibraryImport(Libraries.MessagePort, EntryPoint = "message_port_check_remote_port", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int CheckRemotePort(string remote_app_id, string remote_port, [MarshalAs(UnmanagedType.U1)] out bool exist);

        [LibraryImport(Libraries.MessagePort, EntryPoint = "message_port_check_trusted_remote_port", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int CheckTrustedRemotePort(string remote_app_id, string remote_port, [MarshalAs(UnmanagedType.U1)] out bool exist);

        [LibraryImport(Libraries.MessagePort, EntryPoint = "message_port_add_registered_cb", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int AddRegisteredCallback(string remote_app_id, string remote_port, [MarshalAs(UnmanagedType.U1)] bool trusted_remote_port, message_port_registration_event_cb callback, IntPtr userData, out int watcher_id);

        [LibraryImport(Libraries.MessagePort, EntryPoint = "message_port_add_unregistered_cb", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial int AddUnregisteredCallback(string remote_app_id, string remote_port, [MarshalAs(UnmanagedType.U1)] bool trusted_remote_port, message_port_registration_event_cb callback, IntPtr userData, out int watcher_id);

        [LibraryImport(Libraries.MessagePort, EntryPoint = "message_port_remove_registration_event_cb")]
        internal static partial int RemoveRegistrationCallback(int watcher_id);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void message_port_message_cb(int local_port_id, string remote_app_id, string remote_port, bool trusted_remote_port, IntPtr message, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void message_port_registration_event_cb(string remote_app_id, string remote_port, bool trusted_remote_port, IntPtr userData);
    }
}
