/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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

    [StructLayout(LayoutKind.Sequential)]
    internal struct SmsDataPackageStruct
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst=20)]
        internal string Sca;
        internal int Length;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst=256)]
        internal string SzData;
        internal SmsNetType Format;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SmsDataStruct
    {
        internal int Index;
        internal SmsMessageStatus Status;
        internal SmsDataPackageStruct Data;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SmsCbConfigStruct
    {
        internal int Net3gppType;
        internal int CbEnabled;
        internal byte MsgIdMaxCount;
        internal int MsgIdRangeCount;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=50, ArraySubType = UnmanagedType.LPStruct)]
        internal SmsCbMsgStruct[] MsgIds;
    }

    [StructLayout(LayoutKind.Explicit)]
    internal struct SmsCbMsgStruct
    {
        [FieldOffset(0)]
        internal SmsCbMsg3gppStruct Net3gpp;
        [FieldOffset(0)]
        internal SmsCbMsg3gpp2Struct Net3gpp2;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SmsCbMsg3gppStruct
    {
        internal ushort FromMsgId;
        internal ushort ToMsgId;
        internal byte Selected;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SmsCbMsg3gpp2Struct
    {
        internal ushort CbCategory;
        internal ushort CbLanguage;
        internal byte Selected;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SmsParamsStruct
    {
        internal byte RecordIndex;
        internal byte RecordLength;
        internal ulong AlphaIdLength;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst=129)]
        internal string AlphaId;
        internal byte ParamIndicator;
        internal SmsAddressStruct DestinationAddress;
        internal SmsAddressStruct ServiceCenterAddress;
        internal ushort TpProtocolId;
        internal ushort TpDataCodingScheme;
        internal ushort TpValidityPeriod;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SmsAddressStruct
    {
        internal uint DialNumLength;
        internal SimTypeOfNumber Type;
        internal SimNumberPlanIdentity Identity;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst=21)]
        internal string DiallingNumber;
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
