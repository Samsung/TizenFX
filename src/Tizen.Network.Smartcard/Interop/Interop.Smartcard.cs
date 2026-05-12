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

internal static partial class Interop
{
    internal static partial class Smartcard
    {
        //capi-network-smartcard-0.0.6-2.1.armv7l.rpm
        //Smartcard Manager
        [LibraryImport(Libraries.Smartcard, EntryPoint = "smartcard_initialize")]
        internal static partial int Initialize();
        [LibraryImport(Libraries.Smartcard, EntryPoint = "smartcard_deinitialize")]
        internal static partial int Deinitialize();
        [LibraryImport(Libraries.Smartcard, EntryPoint = "smartcard_get_readers")]
        internal static partial int GetReaders(out IntPtr readers, out int len);

        internal static partial class Reader
        {
            [LibraryImport(Libraries.Smartcard, EntryPoint = "smartcard_reader_get_name")]
            internal static partial int ReaderGetName(int reader, out IntPtr readerName);
            [LibraryImport(Libraries.Smartcard, EntryPoint = "smartcard_reader_is_secure_element_present")]
            internal static partial int ReaderIsSecureElementPresent(int reader, [MarshalAs(UnmanagedType.U1)] out bool present);
            [LibraryImport(Libraries.Smartcard, EntryPoint = "smartcard_reader_open_session")]
            internal static partial int ReaderOpenSession(int reader, out int session);
            [LibraryImport(Libraries.Smartcard, EntryPoint = "smartcard_reader_close_sessions")]
            internal static partial int ReaderCloseSessions(int reader);
        }

        internal static partial class Session
        {
            [LibraryImport(Libraries.Smartcard, EntryPoint = "smartcard_session_get_reader")]
            internal static partial int SessionGetReader(int session, out int reader);
            [LibraryImport(Libraries.Smartcard, EntryPoint = "smartcard_session_get_atr")]
            internal static partial int SessionGetAtr(int session, out IntPtr atr, out int len);
            [LibraryImport(Libraries.Smartcard, EntryPoint = "smartcard_session_close")]
            internal static partial int SessionClose(int session);
            [LibraryImport(Libraries.Smartcard, EntryPoint = "smartcard_session_is_closed")]
            internal static partial int SessionIsClosed(int session, [MarshalAs(UnmanagedType.U1)] out bool closed);
            [LibraryImport(Libraries.Smartcard, EntryPoint = "smartcard_session_close_channels")]
            internal static partial int SessionCloseChannels(int session);
            [LibraryImport(Libraries.Smartcard, EntryPoint = "smartcard_session_open_basic_channel")]
            internal static partial int SessionOpenBasicChannel(int session, byte[] aid, int aidLen, byte p2, out int channel);
            [LibraryImport(Libraries.Smartcard, EntryPoint = "smartcard_session_open_logical_channel")]
            internal static partial int SessionOpenLogicalChannel(int session, byte[] aid, int aidLen, byte p2, out int channel);
        }

        internal static partial class Channel
        {
            [LibraryImport(Libraries.Smartcard, EntryPoint = "smartcard_channel_close")]
            internal static partial int ChannelClose(int channel);
            [LibraryImport(Libraries.Smartcard, EntryPoint = "smartcard_channel_is_basic_channel")]
            internal static partial int ChannelIsBasicChannel(int channel, [MarshalAs(UnmanagedType.U1)] out bool basicChannel);
            [LibraryImport(Libraries.Smartcard, EntryPoint = "smartcard_channel_is_closed")]
            internal static partial int ChannelIsClosed(int channel, [MarshalAs(UnmanagedType.U1)] out bool closed);
            [LibraryImport(Libraries.Smartcard, EntryPoint = "smartcard_channel_get_select_response")]
            internal static partial int ChannelGetSelectResponse(int channel, out IntPtr selectResp, out int len);
            [LibraryImport(Libraries.Smartcard, EntryPoint = "smartcard_channel_get_session")]
            internal static partial int ChannelGetSession(int channel, out int session);
            [LibraryImport(Libraries.Smartcard, EntryPoint = "smartcard_channel_transmit")]
            internal static partial int ChannelTransmit(int channel, byte[] cmd, int cmdLen, out IntPtr resp, out int len);
            [LibraryImport(Libraries.Smartcard, EntryPoint = "smartcard_channel_transmit_retrieve_response")]
            internal static partial int ChannelTransmitRetrieveResponse(int channel, out IntPtr name, out int len);
            [LibraryImport(Libraries.Smartcard, EntryPoint = "smartcard_channel_select_next")]
            internal static partial int ChannelSelectNext(int channel, [MarshalAs(UnmanagedType.U1)] out bool success);
        }
    }
}




