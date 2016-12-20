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
    internal static partial class Smartcard
    {
        //capi-network-smartcard-0.0.6-2.1.armv7l.rpm
        //Smartcard Manager
        [DllImport(Libraries.Smartcard, EntryPoint = "smartcard_initialize")]
        internal static extern int Initialize();
        [DllImport(Libraries.Smartcard, EntryPoint = "smartcard_deinitialize")]
        internal static extern int Deinitialize();
        [DllImport(Libraries.Smartcard, EntryPoint = "smartcard_get_readers")]
        internal static extern int GetReaders(out IntPtr readers, out int len);

        internal static class Reader
        {
            [DllImport(Libraries.Smartcard, EntryPoint = "smartcard_reader_get_name")]
            internal static extern int ReaderGetName(int reader, out IntPtr readerName);
            [DllImport(Libraries.Smartcard, EntryPoint = "smartcard_reader_is_secure_element_present")]
            internal static extern int ReaderIsSecureElementPresent(int reader, out bool present);
            [DllImport(Libraries.Smartcard, EntryPoint = "smartcard_reader_open_session")]
            internal static extern int ReaderOpenSession(int reader, out int session);
            [DllImport(Libraries.Smartcard, EntryPoint = "smartcard_reader_close_sessions")]
            internal static extern int ReaderCloseSessions(int reader);
        }

        internal static class Session
        {
            [DllImport(Libraries.Smartcard, EntryPoint = "smartcard_session_get_reader")]
            internal static extern int SessionGetReader(int session, out int reader);
            [DllImport(Libraries.Smartcard, EntryPoint = "smartcard_session_get_atr")]
            internal static extern int SessionGetAtr(int session, out IntPtr atr, out int len);
            [DllImport(Libraries.Smartcard, EntryPoint = "smartcard_session_close")]
            internal static extern int SessionClose(int session);
            [DllImport(Libraries.Smartcard, EntryPoint = "smartcard_session_is_closed")]
            internal static extern int SessionIsClosed(int session, out bool closed);
            [DllImport(Libraries.Smartcard, EntryPoint = "smartcard_session_close_channels")]
            internal static extern int SessionCloseChannels(int session);
            [DllImport(Libraries.Smartcard, EntryPoint = "smartcard_session_open_basic_channel")]
            internal static extern int SessionOpenBasicChannel(int session, byte[] aid, int aidLen, byte p2, out int channel);
            [DllImport(Libraries.Smartcard, EntryPoint = "smartcard_session_open_logical_channel")]
            internal static extern int SessionOpenLogicalChannel(int session, byte[] aid, int aidLen, byte p2, out int channel);
        }

        internal static class Channel
        {
            [DllImport(Libraries.Smartcard, EntryPoint = "smartcard_channel_close")]
            internal static extern int ChannelClose(int channel);
            [DllImport(Libraries.Smartcard, EntryPoint = "smartcard_channel_is_basic_channel")]
            internal static extern int ChannelIsBasicChannel(int channel, out bool basicChannel);
            [DllImport(Libraries.Smartcard, EntryPoint = "smartcard_channel_is_closed")]
            internal static extern int ChannelIsClosed(int channel, out bool closed);
            [DllImport(Libraries.Smartcard, EntryPoint = "smartcard_channel_get_select_response")]
            internal static extern int ChannelGetSelectResponse(int channel, out IntPtr selectResp, out int len);
            [DllImport(Libraries.Smartcard, EntryPoint = "smartcard_channel_get_session")]
            internal static extern int ChannelGetSession(int channel, out int session);
            [DllImport(Libraries.Smartcard, EntryPoint = "smartcard_channel_transmit")]
            internal static extern int ChannelTransmit(int channel, byte[] cmd, int cmdLen, out IntPtr resp, out int len);
            [DllImport(Libraries.Smartcard, EntryPoint = "smartcard_channel_transmit_retrieve_response")]
            internal static extern int ChannelTransmitRetrieveResponse(int channel, out IntPtr name, out int len);
            [DllImport(Libraries.Smartcard, EntryPoint = "smartcard_channel_select_next")]
            internal static extern int ChannelSelectNext(int channel, out bool success);
        }
    }
}
