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

using System.Runtime.InteropServices;

namespace Tizen.Tapi
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct SmsIncomingMsgNotiStruct
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
        internal string Sca;
        internal int MsgLength;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        internal string SzData;
        internal SmsNetType Format;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SmsIncomingCbMsgNotiStruct
    {
        internal SmsCbMsgType CbMsgType;
        internal short Length;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1253)]
        internal string SzMsgData;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SmsIncomingEtwsMsgNotiStruct
    {
        internal SmsEtwsMsgType EtwsMsgType;
        internal short Length;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1253)]
        internal string SzMsgData;
    }

    internal static class SmsStructConversions
    {
        internal static SmsIncomingMessageNoti ConvertSmsIncomingStruct(SmsIncomingMsgNotiStruct msgStruct)
        {
            SmsIncomingMessageNoti msgNoti = new SmsIncomingMessageNoti();
            msgNoti.ScaVal = msgStruct.Sca;
            msgNoti.MsgLength = msgStruct.MsgLength;
            msgNoti.FormatType = msgStruct.Format;
            msgNoti.Data = msgStruct.SzData;
            return msgNoti;
        }

        internal static SmsIncomingCbMessageNoti ConvertSmsIncomingCbStruct(SmsIncomingCbMsgNotiStruct msgStruct)
        {
            SmsIncomingCbMessageNoti msgNoti = new SmsIncomingCbMessageNoti();
            msgNoti.Len = msgStruct.Length;
            msgNoti.CbType = msgStruct.CbMsgType;
            msgNoti.Data = msgStruct.SzMsgData;
            return msgNoti;
        }

        internal static SmsIncomingEtwsMessageNoti ConvertSmsIncomingEtwsStruct(SmsIncomingEtwsMsgNotiStruct msgStruct)
        {
            SmsIncomingEtwsMessageNoti msgNoti = new SmsIncomingEtwsMessageNoti();
            msgNoti.Len = msgStruct.Length;
            msgNoti.EtwsType = msgStruct.EtwsMsgType;
            msgNoti.Data = msgStruct.SzMsgData;
            return msgNoti;
        }
    }
}
