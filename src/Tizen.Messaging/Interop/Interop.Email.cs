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
    internal enum EmailRecipientType
    {
        To = 1,
        Cc = 2,
        Bcc = 3
    }

    internal static partial class Email
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void EmailSentCallback(IntPtr handle, int result, IntPtr userData);

        [DllImport(Libraries.Email, EntryPoint = "email_create_message")]
        internal static extern int CreateEmail(out IntPtr EmailHandle);

        [DllImport(Libraries.Email, EntryPoint = "email_destroy_message")]
        internal static extern int DestroyEmail(IntPtr EmailHandle);

        [DllImport(Libraries.Email, EntryPoint = "email_set_subject")]
        internal static extern int SetSubject(IntPtr EmailHandle, string text);

        [DllImport(Libraries.Email, EntryPoint = "email_set_body")]
        internal static extern int SetBody(IntPtr EmailHandle, string text);

        [DllImport(Libraries.Email, EntryPoint = "email_add_recipient")]
        internal static extern int AddRecipient(IntPtr EmailHandle, int type, string text);

        [DllImport(Libraries.Email, EntryPoint = "email_remove_all_recipient")]
        internal static extern int RemoveRecipient(IntPtr EmailHandle);

        [DllImport(Libraries.Email, EntryPoint = "email_add_attach")]
        internal static extern int AddAttachment(IntPtr EmailHandle, string text);

        [DllImport(Libraries.Email, EntryPoint = "email_remove_all_attachments")]
        internal static extern int RemoveAttachments(IntPtr EmailHandle);

        [DllImport(Libraries.Email, EntryPoint = "email_save_message")]
        internal static extern int SaveEmail(IntPtr EmailHandle);

        [DllImport(Libraries.Email, EntryPoint = "email_send_message")]
        internal static extern int SendEmail(IntPtr EmailHandle, bool SaveToSentBox);

        [DllImport(Libraries.Email, EntryPoint = "email_set_message_sent_cb")]
        internal static extern int SetCb(IntPtr EmailHandle, EmailSentCallback Cb, IntPtr UserData);

        [DllImport(Libraries.Email, EntryPoint = "email_unset_message_sent_cb")]
        internal static extern int UnsetCb(IntPtr EmailHandle);
    }
}
