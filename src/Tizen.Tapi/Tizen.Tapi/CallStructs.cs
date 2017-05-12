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
    internal struct CallIdleStatusNotiStruct
    {
        internal uint Id;
        internal CallEndCause Cause;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct CallIncomingInfoStruct
    {
        internal uint Handle;
        internal CallType Type;
        [MarshalAs(UnmanagedType.LPStr)]
        internal string CallerNumber;
        internal CallerName NameData;
        internal CallCliMode CliMode;
        internal CallNoCliCause CliCause;
        internal int IsForwarded;
        internal CallActiveLine ActiveLine;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct CallerName
    {
        internal CallNameMode NameMode;
        [MarshalAs(UnmanagedType.LPStr)]
        internal string Name;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct CallRecordLineControlStruct
    {
        internal byte PolarityIncluded;
        internal byte ToggleMode;
        internal byte ReversePolarity;
        internal byte PowerDenialTime;
    }

    [StructLayout(LayoutKind.Explicit)]
    internal struct CallRecordDataStruct
    {
        [MarshalAs(UnmanagedType.LPStr)]
        [FieldOffset(0)]
        internal string Name;
        [MarshalAs(UnmanagedType.LPStr)]
        [FieldOffset(0)]
        internal string Number;
        [FieldOffset(0)]
        internal CallRecordLineControlStruct LineCtrl;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct CallRecordStruct
    {
        internal uint Id;
        internal CallRecordType Type;
        internal CallRecordDataStruct Data;
    }

    [StructLayout(LayoutKind.Explicit)]
    internal struct CallSignalStruct
    {
        [FieldOffset(0)]
        internal CallToneSignal SignalTone;
        [FieldOffset(0)]
        internal CallIsdnAlertSignal IsdnAlert;
        [FieldOffset(0)]
        internal CallIs54bAlertSignal Is54bAlert;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct CallSignalInfoStruct
    {
        internal CallAlertSignal SignalType;
        internal CallAlertPitch PitchType;
        internal CallSignalStruct CallSignal;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct CallUpgradeDowngradeNotiStruct
    {
        internal int CallHandle;
        internal CallConfigType ConfigType;
    }

    internal static class CallStructConversions
    {
        internal static CallIdleStatusNotificationData ConvertCallIdleStatusNoti(CallIdleStatusNotiStruct idleStatusNoti)
        {
            CallIdleStatusNotificationData idleStatusNotiData = new CallIdleStatusNotificationData();
            idleStatusNotiData.Id = idleStatusNoti.Id;
            idleStatusNotiData.Cause = idleStatusNoti.Cause;
            return idleStatusNotiData;
        }

        internal static CallIncomingInfo ConvertIncomingCallInfo(CallIncomingInfoStruct incomingInfo)
        {
            CallIncomingInfo callIncoming = new CallIncomingInfo();
            callIncoming.Handle = incomingInfo.Handle;
            callIncoming.Type = incomingInfo.Type;
            callIncoming.Number = incomingInfo.CallerNumber;
            CallerNameInfo nameData = new CallerNameInfo();
            nameData.Mode = incomingInfo.NameData.NameMode;
            nameData.NameData = incomingInfo.NameData.Name;

            callIncoming.Name = nameData;
            callIncoming.Cli = incomingInfo.CliMode;
            callIncoming.Cause = incomingInfo.CliCause;
            if (incomingInfo.IsForwarded == 1)
            {
                callIncoming.IsFwded = true;
            }

            else if (incomingInfo.IsForwarded == 0)
            {
                callIncoming.IsFwded = false;
            }

            callIncoming.Line = incomingInfo.ActiveLine;

            return callIncoming;
        }

        internal static CallRecord ConvertCallRecordStruct(CallRecordStruct record)
        {
            CallRecord recordData = new CallRecord();
            recordData.Id = record.Id;
            recordData.Type = record.Type;
            if (record.Type == CallRecordType.Name)
            {
                recordData.Name = record.Data.Name;
            }

            else if (record.Type == CallRecordType.Number)
            {
                recordData.Number = record.Data.Number;
            }

            else if (record.Type == CallRecordType.LineControl)
            {
                CallRecordLineControl lineCtrl = new CallRecordLineControl();
                lineCtrl.PolarityInc = record.Data.LineCtrl.PolarityIncluded;
                lineCtrl.Toggle = record.Data.LineCtrl.ToggleMode;
                lineCtrl.ReversePol = record.Data.LineCtrl.ReversePolarity;
                lineCtrl.PowerTime = record.Data.LineCtrl.PowerDenialTime;
                recordData.LineCtrl = lineCtrl;
            }

            return recordData;
        }

        internal static CallSignalNotification ConvertCallSignalInfo(CallSignalInfoStruct signalInfo)
        {
            CallSignalNotification signalNoti = new CallSignalNotification();
            signalNoti.Signal = signalInfo.SignalType;
            signalNoti.Pitch = signalInfo.PitchType;
            if (signalInfo.SignalType == CallAlertSignal.Tone)
            {
                signalNoti.Tone = signalInfo.CallSignal.SignalTone;
            }

            else if (signalInfo.SignalType == CallAlertSignal.IsdnAlert)
            {
                signalNoti.Isdn = signalInfo.CallSignal.IsdnAlert;
            }

            else if (signalInfo.SignalType == CallAlertSignal.Is54bAlert)
            {
                signalNoti.Is54b = signalInfo.CallSignal.Is54bAlert;
            }

            return signalNoti;
        }

        internal static CallUpgradeDowngradeRequestNoti ConvertCallUpgradeNoti(CallUpgradeDowngradeNotiStruct notiStruct)
        {
            CallUpgradeDowngradeRequestNoti requestNoti = new CallUpgradeDowngradeRequestNoti();
            requestNoti.Handle = notiStruct.CallHandle;
            requestNoti.Type = notiStruct.ConfigType;
            return requestNoti;
        }
    }
}
