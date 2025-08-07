/*
* Copyright (c) 2023 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Text;
using Tizen.System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class Session
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void SubsessionReplyCallback(int result, IntPtr cb_data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void SubsessionEventCallback(SubsessionEventInfoNative info, IntPtr cb_data);

        [DllImport(Libraries.Session, EntryPoint = "subsession_add_user", CallingConvention = CallingConvention.Cdecl)]
        public static extern SessionError SubsessionAddUser(int session_uid, string user, SubsessionReplyCallback cb, IntPtr data);

        [DllImport(Libraries.Session, EntryPoint = "subsession_remove_user", CallingConvention = CallingConvention.Cdecl)]
        public static extern SessionError SubsessionRemoveUser(int session_uid, string user, SubsessionReplyCallback cb, IntPtr data);

        [DllImport(Libraries.Session, EntryPoint = "subsession_switch_user", CallingConvention = CallingConvention.Cdecl)]
        public static extern SessionError SubsessionSwitchUser(int session_uid, string next_user, SubsessionReplyCallback cb, IntPtr data);

        [DllImport(Libraries.Session, EntryPoint = "subsession_get_user_list", CallingConvention = CallingConvention.Cdecl)]
        public static extern SessionError SubsessionGetUserList(int session_uid, out IntPtr list, out int user_count);

        [DllImport(Libraries.Session, EntryPoint = "subsession_free_user_list", CallingConvention = CallingConvention.Cdecl)]
        public static extern void SubsessionFreeUserList(IntPtr list);

        [DllImport(Libraries.Session, EntryPoint = "subsession_get_current_user", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern SessionError SubsessionGetCurrentUser(int session_uid, StringBuilder user);

        [DllImport(Libraries.Session, EntryPoint = "subsession_register_event_callback", CallingConvention = CallingConvention.Cdecl)]
        public static extern SessionError SubesssionRegisterEventCallback(int session_uid, SessionEventType event_bits, SubsessionEventCallback cb, IntPtr data);

        [DllImport(Libraries.Session, EntryPoint = "subsession_unregister_event_callback", CallingConvention = CallingConvention.Cdecl)]
        public static extern SessionError SubesssionUnregisterEventCallback(int session_uid, SessionEventType event_bits);

        [DllImport(Libraries.Session, EntryPoint = "subsession_event_wait_done", CallingConvention = CallingConvention.Cdecl)]
        public static extern SessionError SubsessionEventWaitDone(SubsessionEventInfoNative info);

        [DllImport(Libraries.Libc, EntryPoint = "getuid", CallingConvention = CallingConvention.Cdecl)]
        public static extern int GetUID();
    }
}
