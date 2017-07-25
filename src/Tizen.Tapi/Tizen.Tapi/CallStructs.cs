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
using System.Collections.Generic;
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
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = TapiUtility.CallDialNumberMaxLen)]
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
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = TapiUtility.CallNameMaxSize)]
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
        internal IntPtr Name;
        [MarshalAs(UnmanagedType.LPStr)]
        [FieldOffset(0)]
        internal IntPtr Number;
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
    internal struct CallInformationStruct
    {
        internal CallType Type;
        internal EmergencyType EType;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = TapiUtility.CallDialNumberMaxLen)]
        internal string PhoneNumber;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct CallBurstDtmfStruct
    {
        [MarshalAs(UnmanagedType.LPStr)]
        internal string Dtmf;
        internal CallDtmfPulseWidth Width;
        internal CallDtmfDigitInterval Interval;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct CallStatusStruct
    {
        internal int CallHandle;
        internal int BMoCall;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = TapiUtility.CallDialNumberMaxLen)]
        internal string PhoneNumber;
        internal CallType Type;
        internal CallState State;
        internal int BConferenceState;
        internal int BVolteCall;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct CallDeflectDestStruct
    {
        internal IntPtr DestinationNumber;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct CallVolumeRecordStruct
    {
        internal SoundDevice Device;
        internal SoundType Type;
        internal SoundVolume Volume;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct CallSoundPathStruct
    {
        internal SoundPath Path;
        internal ExtraVolume ExVolume;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct CallUpgradeDowngradeNotiStruct
    {
        internal int CallHandle;
        internal CallConfigType ConfigType;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct CallOperationsStruct
    {
        internal uint id;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct CallEndStruct
    {
        internal CallEndType type;
        internal uint id;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct CallVolumeStruct
    {
        internal uint number;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.LPStruct)]
        internal CallVolumeRecordStruct[] recordList;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct CallMuteStatusStruct
    {
        internal SoundMutePath Path;
        internal SoundMuteStatus Status;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct CallPrivacyModeStruct
    {
        internal CallPrivacyMode Mode;
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
                recordData.Name = Marshal.PtrToStringAnsi(record.Data.Name);
            }

            else if (record.Type == CallRecordType.Number)
            {
                recordData.Number = Marshal.PtrToStringAnsi(record.Data.Number);
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

        internal static CallStatus ConvertStatusStruct(CallStatusStruct statusStruct)
        {
            CallStatus statusData = new CallStatus();
            statusData.CallHandle = statusStruct.CallHandle;
            statusData.IsMoCall = Convert.ToBoolean(statusStruct.BMoCall);
            statusData.PhoneNumber = statusStruct.PhoneNumber;
            statusData.Type = statusStruct.Type;
            statusData.State = statusStruct.State;
            statusData.IsConferenceState = Convert.ToBoolean(statusStruct.BConferenceState);
            statusData.IsVolteCall = Convert.ToBoolean(statusStruct.BVolteCall);
            return statusData;
        }

        internal static CallVolumeInfo ConvertVolumeStruct(CallVolumeStruct volumeStruct)
        {
            List<CallVolumeRecord> records = new List<CallVolumeRecord>();
            foreach(CallVolumeRecordStruct record in volumeStruct.recordList)
            {
                records.Add(new CallVolumeRecord(record.Device, record.Type, record.Volume));
            }

            CallVolumeInfo volumeInfo = new CallVolumeInfo(volumeStruct.number, records);
            return volumeInfo;
        }
    }

    internal static class CallClassConversions
    {
        internal static CallInformationStruct ConvertCallInformationToStruct(CallInformation info)
        {
            CallInformationStruct callInfoStruct = new CallInformationStruct();
            callInfoStruct.Type = info.Type;
            callInfoStruct.EType = info.EType;
            callInfoStruct.PhoneNumber = info.PhoneNumber;
            return callInfoStruct;
        }

        internal static CallBurstDtmfStruct ConvertCallBurstToStruct(CallBurstDtmfData data)
        {
            CallBurstDtmfStruct callBurstStruct = new CallBurstDtmfStruct();
            callBurstStruct.Dtmf = data.Dtmf;
            callBurstStruct.Width = data.Width;
            callBurstStruct.Interval = data.Interval;
            return callBurstStruct;
        }

        internal static CallDeflectDestStruct ConvertByteDestinationToStruct(byte[] number)
        {
            CallDeflectDestStruct callDeflectStruct = new CallDeflectDestStruct();
            callDeflectStruct.DestinationNumber = Marshal.AllocHGlobal(83);
            Marshal.Copy(number, 0, callDeflectStruct.DestinationNumber, Math.Min(83, number.Length));
            return callDeflectStruct;
        }

        internal static CallVolumeRecordStruct ConvertVolumeRecordToStruct(CallVolumeRecord record)
        {
            CallVolumeRecordStruct volumeStruct = new CallVolumeRecordStruct();
            volumeStruct.Device = record.Device;
            volumeStruct.Type = record.Type;
            volumeStruct.Volume = record.Volume;
            return volumeStruct;
        }

        internal static CallSoundPathStruct ConvertSoundPathToStruct(CallSoundPathInfo info)
        {
            CallSoundPathStruct pathStruct = new CallSoundPathStruct();
            pathStruct.Path = info.Path;
            pathStruct.ExVolume = info.ExVolume;
            return pathStruct;
        }
    }
}
