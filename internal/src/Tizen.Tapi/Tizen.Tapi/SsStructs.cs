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

using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Tizen.Tapi
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct SsBarringInfoStruct
    {
        internal SsClass Class;
        internal SsBarringMode Mode;
        internal SsBarringType Type;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        internal string Password;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SsBarringRecordStruct
    {
        internal SsClass Class;
        internal SsStatus Status;
        internal SsBarringType Type;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SsBarringResponseStruct
    {
        internal int RecordNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5, ArraySubType = UnmanagedType.LPStruct)]
        internal SsBarringRecordStruct[] Record;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SsUssdMsgInfoStruct
    {
        internal SsUssdType Type;
        internal byte Dcs;
        internal int Length;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 208)]
        internal string UssdString;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SsUssdResponseStruct
    {
        internal SsUssdType Type;
        internal SsUssdStatus Status;
        internal byte Dcs;
        internal int Length;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 208)]
        internal string UssdString;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SsReleaseCompleteMsgStruct
    {
        internal byte MsgLength;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        internal string Message;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SsWaitingInfoStruct
    {
        internal SsClass Class;
        internal SsCallWaitingMode Mode;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SsWaitingRecordStruct
    {
        internal SsClass Class;
        internal SsStatus Status;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SsWaitingResponseStruct
    {
        internal int RecordNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5, ArraySubType = UnmanagedType.LPStruct)]
        internal SsWaitingRecordStruct[] Record;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SsForwardInfoStruct
    {
        internal SsClass Class;
        internal SsForwardMode Mode;
        internal SsForwardCondition Condition;
        internal SsNoReplyTime NoReplyTimer;
        internal SsForwardTypeOfNumber Ton;
        internal SsForwardNumberingPlanIdentity Npi;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 82)]
        internal string PhoneNumber;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SsForwardRecordStruct
    {
        internal SsClass Class;
        internal SsStatus Status;
        internal SsForwardCondition Condition;
        internal int IsForwardingNumPresent;
        internal SsNoReplyTime NoReplyTime;
        internal SsForwardTypeOfNumber Ton;
        internal SsForwardNumberingPlanIdentity Npi;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 83)]
        internal string ForwardingNum;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SsForwardResponseStruct
    {
        internal int RecordNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5, ArraySubType = UnmanagedType.LPStruct)]
        internal SsForwardRecordStruct[] Record;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SsInfoStruct
    {
        internal SsCause Cause;
        internal SsInfoType Type;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SsCliResponseStruct
    {
        internal SsLineIdentificationType Type;
        internal SsCliStatus Status;
    }

    internal static class SsStructConversions
    {
        internal static SsForwardRecord ConvertSsForwardRecordStruct(SsForwardRecordStruct recordStruct)
        {
            SsForwardRecord record = new SsForwardRecord();
            record.SsClass = recordStruct.Class;
            record.SsStatus = recordStruct.Status;
            record.Condition = recordStruct.Condition;
            if (recordStruct.IsForwardingNumPresent == 1)
            {
                record.IsNumPresent = true;
            }

            else if (recordStruct.IsForwardingNumPresent == 0)
            {
                record.IsNumPresent = false;
            }

            record.NoReply = recordStruct.NoReplyTime;
            record.Type = recordStruct.Ton;
            record.NumIdPlan = recordStruct.Npi;
            record.ForwardNum = recordStruct.ForwardingNum;
            return record;
        }

        internal static SsUssdMsgInfo ConvertSsMsgStruct(SsUssdMsgInfoStruct msgStruct)
        {
            SsUssdMsgInfo info = new SsUssdMsgInfo();
            info.Length = msgStruct.Length;
            info.Dcs = msgStruct.Dcs;
            info.UssdString = msgStruct.UssdString;
            info.Type = msgStruct.Type;
            return info;
        }

        internal static SsReleaseCompleteMsgInfo ConvertReleaseMsgStruct(SsReleaseCompleteMsgStruct msgStruct)
        {
            SsReleaseCompleteMsgInfo info = new SsReleaseCompleteMsgInfo();
            info.Length = msgStruct.MsgLength;
            info.Msg = Encoding.ASCII.GetBytes(msgStruct.Message);
            return info;
        }

        internal static SsForwardResponse ConvertForwardRspStruct(SsForwardResponseStruct responseStruct)
        {
            SsForwardResponse info = new SsForwardResponse();
            List<SsForwardRecord> recordList = new List<SsForwardRecord>();
            foreach (SsForwardRecordStruct item in responseStruct.Record)
            {
                recordList.Add(ConvertSsForwardRecordStruct(item));
            }

            info.RecordNum = responseStruct.RecordNum;
            info.RecordList = recordList;
            return info;
        }

        internal static SsBarringResponse ConvertBarringRspStruct(SsBarringResponseStruct responseStruct)
        {
            SsBarringResponse info = new SsBarringResponse();
            List<SsBarringRecord> barringList = new List<SsBarringRecord>();
            foreach (SsBarringRecordStruct item in responseStruct.Record)
            {
                SsBarringRecord record = new SsBarringRecord();
                record.SsClass = item.Class;
                record.SsStatus = item.Status;
                record.SsType = item.Type;
                barringList.Add(record);
            }

            info.RecordNum = responseStruct.RecordNum;
            info.RecordList = barringList;
            return info;
        }

        internal static SsWaitingResponse ConvertWaitingRspStruct(SsWaitingResponseStruct responseStruct)
        {
            SsWaitingResponse info = new SsWaitingResponse();
            List<SsWaitingRecord> waitingList = new List<SsWaitingRecord>();
            foreach (SsWaitingRecordStruct item in responseStruct.Record)
            {
                SsWaitingRecord record = new SsWaitingRecord();
                record.SsClass = item.Class;
                record.SsStatus = item.Status;
                waitingList.Add(record);
            }

            info.RecordNum = responseStruct.RecordNum;
            info.RecordList = waitingList;
            return info;
        }

        internal static SsInfo ConvertInfoStruct(SsInfoStruct infoStruct)
        {
            SsInfo info = new SsInfo();
            info.Cse = infoStruct.Cause;
            info.Type = infoStruct.Type;
            return info;
        }

        internal static SsCliResponse ConvertSsCliResponseStruct(SsCliResponseStruct responseStruct)
        {
            SsCliResponse response = new SsCliResponse();
            response.LineType = responseStruct.Type;
            response.CliStatus = responseStruct.Status;
            return response;
        }

        internal static SsUssdResponse ConvertSsUssdResponseStruct(SsUssdResponseStruct responseStruct)
        {
            SsUssdResponse response = new SsUssdResponse();
            response.UssdType = responseStruct.Type;
            response.UssdStatus = responseStruct.Status;
            response.DcsInfo = responseStruct.Dcs;
            response.UssdLength = responseStruct.Length;
            response.UssdInfo = responseStruct.UssdString;
            return response;
        }
    }

    internal static class SsClassConversions
    {
        internal static SsBarringInfoStruct ConvertSsBarringInfo(SsBarringInfo info)
        {
            SsBarringInfoStruct barringStruct = new SsBarringInfoStruct();
            barringStruct.Class = info.Class;
            barringStruct.Mode = info.Mode;
            barringStruct.Type = info.Type;
            barringStruct.Password = info.Password;
            return barringStruct;
        }

        internal static SsForwardInfoStruct ConvertSsForwardInfo(SsForwardInfo info)
        {
            SsForwardInfoStruct forwardStruct = new SsForwardInfoStruct();
            forwardStruct.Class = info.Class;
            forwardStruct.Mode = info.Mode;
            forwardStruct.Condition = info.Condition;
            forwardStruct.NoReplyTimer = info.NoReplyTimer;
            forwardStruct.Ton = info.Ton;
            forwardStruct.Npi = info.Npi;
            forwardStruct.PhoneNumber = info.PhoneNumber;
            return forwardStruct;
        }

        internal static SsWaitingInfoStruct ConvertSsWaitingInfo(SsWaitingInfo info)
        {
            SsWaitingInfoStruct waitingStruct = new SsWaitingInfoStruct();
            waitingStruct.Class = info.Class;
            waitingStruct.Mode = info.Mode;
            return waitingStruct;
        }

        internal static SsUssdMsgInfoStruct ConvertSsUssdMsgInfo(SsUssdMsgInfo info)
        {
            SsUssdMsgInfoStruct msgStruct = new SsUssdMsgInfoStruct();
            msgStruct.Type = info.Type;
            msgStruct.Dcs = info.Dcs;
            msgStruct.Length = info.Length;
            msgStruct.UssdString = info.UssdString;
            return msgStruct;
        }
    }
}
