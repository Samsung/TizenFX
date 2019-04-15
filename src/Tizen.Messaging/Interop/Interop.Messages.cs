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
    internal static partial class Messages
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void MessageIncomingCallback(IntPtr messageHandle, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void MessageSentCallback(int result, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool MessageSearchCallback(IntPtr messageHandle, int index, int resultCount, int totalCount, IntPtr userData);

        [DllImport(Libraries.Messages, EntryPoint = "messages_open_service")]
        internal static extern int OpenService(out IntPtr serviceHandle);

        [DllImport(Libraries.Messages, EntryPoint = "messages_close_service")]
        internal static extern int CloseService(IntPtr serviceHandle);

        [DllImport(Libraries.Messages, EntryPoint = "messages_create_message")]
        internal static extern int CreateMessage(int type, out IntPtr messageHandle);

        [DllImport(Libraries.Messages, EntryPoint = "messages_destroy_message")]
        internal static extern int DestroyMessage(IntPtr messageHandle);

        [DllImport(Libraries.Messages, EntryPoint = "messages_get_message_id")]
        internal static extern int GetMessageId(IntPtr messageHandle, out int messageId);

        [DllImport(Libraries.Messages, EntryPoint = "messages_set_sim_id")]
        internal static extern int SetSimId(IntPtr messageHandle, int simId);

        [DllImport(Libraries.Messages, EntryPoint = "messages_get_sim_id")]
        internal static extern int GetSimId(IntPtr messageHandle, out int simId);

        [DllImport(Libraries.Messages, EntryPoint = "messages_set_mbox_type")]
        internal static extern int SetMboxType(IntPtr messageHandle, int mboxType);

        [DllImport(Libraries.Messages, EntryPoint = "messages_get_mbox_type")]
        internal static extern int GetMboxType(IntPtr messageHandle, out int mboxType);

        [DllImport(Libraries.Messages, EntryPoint = "messages_get_message_port")]
        internal static extern int GetMessagePort(IntPtr messageHandle, out int messagePort);

        [DllImport(Libraries.Messages, EntryPoint = "messages_get_message_type")]
        internal static extern int GetMessageType(IntPtr messageHandle, out int messageType);

        [DllImport(Libraries.Messages, EntryPoint = "messages_set_text")]
        internal static extern int SetText(IntPtr messageHandle, string text);

        [DllImport(Libraries.Messages, EntryPoint = "messages_get_text")]
        internal static extern int GetText(IntPtr messageHandle, out string text);

        [DllImport(Libraries.Messages, EntryPoint = "messages_set_time")]
        internal static extern int SetTime(IntPtr messageHandle, int time);

        [DllImport(Libraries.Messages, EntryPoint = "messages_get_time")]
        internal static extern int GetTime(IntPtr messageHandle, out int time);

        [DllImport(Libraries.Messages, EntryPoint = "messages_mms_set_subject")]
        internal static extern int SetSubject(IntPtr messageHandle, string subject);

        [DllImport(Libraries.Messages, EntryPoint = "messages_mms_get_subject")]
        internal static extern int GetSubject(IntPtr messageHandle, out string subject);

        [DllImport(Libraries.Messages, EntryPoint = "messages_add_address")]
        internal static extern int AddAddress(IntPtr messageHandle, string address, int type);

        [DllImport(Libraries.Messages, EntryPoint = "messages_get_address_count")]
        internal static extern int GetAddressCount(IntPtr messageHandle, out int count);

        [DllImport(Libraries.Messages, EntryPoint = "messages_get_address")]
        internal static extern int GetAddress(IntPtr messageHandle, int index, out string address, out int type);

        [DllImport(Libraries.Messages, EntryPoint = "messages_remove_all_addresses")]
        internal static extern int RemoveAllAddress(IntPtr messageHandle);

        [DllImport(Libraries.Messages, EntryPoint = "messages_mms_add_attachment")]
        internal static extern int AddAttachment(IntPtr messageHandle, int type, string path);

        [DllImport(Libraries.Messages, EntryPoint = "messages_mms_get_attachment_count")]
        internal static extern int GetAttachmentCount(IntPtr messageHandle, out int count);

        [DllImport(Libraries.Messages, EntryPoint = "messages_mms_get_attachment")]
        internal static extern int GetAttachment(IntPtr messageHandle, int index, out int type, out string path);

        [DllImport(Libraries.Messages, EntryPoint = "messages_mms_remove_all_attachments")]
        internal static extern int RemoveAllAttachment(IntPtr messageHandle);

        [DllImport(Libraries.Messages, EntryPoint = "messages_set_message_incoming_cb")]
        internal static extern int SetMessageIncomingCb(IntPtr serviceHandle, MessageIncomingCallback cb, IntPtr userData);

        [DllImport(Libraries.Messages, EntryPoint = "messages_unset_message_incoming_cb")]
        internal static extern int UnsetMessageIncomingCb(IntPtr serviceHandle);

        [DllImport(Libraries.Messages, EntryPoint = "messages_send_message")]
        internal static extern int SendMessage(IntPtr serviceHandle, IntPtr messageHandle, bool saveToSentbox, MessageSentCallback cb, IntPtr userData);

        [DllImport(Libraries.Messages, EntryPoint = "messages_search_message_by_id")]
        internal static extern int GetMessageById(IntPtr serviceHandle, int msgId, out IntPtr messageHandle);

        [DllImport(Libraries.Messages, EntryPoint = "messages_foreach_message")]
        internal static extern int SearchMessage(IntPtr serviceHandle, int mbox, int messageType, string textKeyword, string addressKeyword, int offset, int limit, MessageSearchCallback cb, IntPtr userData);

        [DllImport(Libraries.Messages, EntryPoint = "messages_get_message_count")]
        internal static extern int GetMessageCount(IntPtr serviceHandle, int mbox, int messageType, out int count);

    }
}
