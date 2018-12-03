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

namespace Tizen.Tapi
{
    internal enum TapiError
    {
        Success = 0,
        InvalidInput = -1,
        InvalidPtr = -2,
        NotSupported = -3,
        Depricated = -4,
        SystemOutOfMemory = -5,
        SystemRpcLinkDown = -6,
        ServiceNotReady = -7,
        ServerFailure = -8,
        OemPluginFailure = -9,
        TransportLayerFailure = -10,
        InvalidDataLength = -11,
        RequestMaxInProgress = -12,
        OfflineModeError = -13,
        EventClassUnknown = -14,
        EventUnknown = -15,
        RegistrationOpFailed = -16,
        OperationFailed = -17,
        InvalidOperation = -18,
        AccessDenied = -19,
        SystemRpcLinkNotEst = -100,
        ApiNotSupported = -101,
        ServerLayerFailure = -102,
        InvalidCallId = -200,
        CallContextOverflow = -201,
        CouldNotGetCallContext = -202,
        ContextSearchRetNonCallContext = -203,
        CouldNotDestroyContext = -204,
        InvalidLineId = -205,
        InvalidCallHandle = -206,
        InvalidCallState = -207,
        CallPreCondFailed = -208,
        CallSameReqPending = -209,
        ModemPoweredOff = -300,
        ModemAlreadyOn = -301,
        ModemAlreadyOff = -302,
        NetTextDeviceNotReady = -400,
        NetTextScaAddrNotSet = -401,
        NetTextInvalidDataLength = -402,
        NetTextScaAddressNotSet = -403,
        SimCardError = -500,
        SimNotFound = -501,
        SimNotInitialized = -502,
        SimLocked = -503,
        SimPermBlocked = -504,
        SimServiceDisabled = -505,
        SatInvalidCommandId = -600,
        SatCommandTypeMismatch = -601,
        SatEventNotRequiredByUsim = -602,
        NetworkInvalidContext = -700,
        NetworkPlmnNotAllowed = -701,
        NetworkRoamingNotAllowed = -702,
        MiscReturnNull = -800,
        MiscvalidityError = -801,
        MiscInputParamError = -802,
        MiscOutParamNull = -803
    }

    internal static class TapiUtility
    {
        internal const string LogTag = "Tizen.Tapi";
        internal const int MaxVersionLen = 32;
        internal const int MiscProdCodeMaxLen = 32;
        internal const int ModelIdMaxLen = 17;
        internal const int MiscPrlEriVersionMaxLen = 17;
        internal const int MiscMeSnMaxLen = 32;
        internal const int MiscMeDeviceNameMaxLen = 32;
        internal const int CallDialNumberMaxLen = 83;
        internal const int CallNameMaxSize = 97;

        internal static string ConvertNotiToString(Notification noti)
        {
            switch(noti)
            {
                case Notification.IdleVoiceCall:
                    return "org.tizen.telephony.Call:VoiceCallStatusIdle";
                case Notification.ActiveVoiceCall:
                    return "org.tizen.telephony.Call:VoiceCallStatusActive";
                case Notification.HeldVoiceCall:
                    return "org.tizen.telephony.Call:VoiceCallStatusHeld";
                case Notification.DialingVoiceCall:
                    return "org.tizen.telephony.Call:VoiceCallStatusDialing";
                case Notification.AlertVoiceCall:
                    return "org.tizen.telephony.Call:VoiceCallStatusAlert";
                case Notification.IncomingVoiceCall:
                    return "org.tizen.telephony.Call:VoiceCallStatusIncoming";
                case Notification.IdleVideoCall:
                    return "org.tizen.telephony.Call:VideoCallStatusIdle";
                case Notification.ActiveVideoCall:
                    return "org.tizen.telephony.Call:VideoCallStatusActive";
                case Notification.DialingVideoCall:
                    return "org.tizen.telephony.Call:VideoCallStatusDialing";
                case Notification.AlertVideoCall:
                    return "org.tizen.telephony.Call:VideoCallStatusAlert";
                case Notification.IncomingVideoCall:
                    return "org.tizen.telephony.Call:VideoCallStatusIncoming";
                case Notification.WaitingCallInfo:
                    return "org.tizen.telephony.Call:Waiting";
                case Notification.ForwardCallInfo:
                    return "org.tizen.telephony.Call:Forwarded";
                case Notification.BarredIncomingCallInfo:
                    return "org.tizen.telephony.Call:BarredIncoming";
                case Notification.BarredOutgoingCallInfo:
                    return "org.tizen.telephony.Call:BarredOutgoing";
                case Notification.DeflectCallInfo:
                    return "org.tizen.telephony.Call:Deflected";
                case Notification.ClirCallInfo:
                    return "org.tizen.telephony.Call:ClirSuppressionReject";
                case Notification.ForwardUnconditionalCallInfo:
                    return "org.tizen.telephony.Call:ForwardUnconditional";
                case Notification.ForwardConditionalCallInfo:
                    return "org.tizen.telephony.Call:ForwardConditional";
                case Notification.ForwardedCallInfo:
                    return "org.tizen.telephony.Call:ForwardedCall";
                case Notification.DeflectedCallInfo:
                    return "org.tizen.telephony.Call:DeflectedCall";
                case Notification.TransferredCallInfo:
                    return "org.tizen.telephony.Call:TransferedCall";
                case Notification.HeldCallInfo:
                    return "org.tizen.telephony.Call:CallHeld";
                case Notification.ActiveCallInfo:
                    return "org.tizen.telephony.Call:CallActive";
                case Notification.JoinedCallInfo:
                    return "org.tizen.telephony.Call:CallJoined";
                case Notification.TransferAlertCallInfo:
                    return "org.tizen.telephony.Call:TransferAlert";
                case Notification.CfCheckMessageCallInfo:
                    return "org.tizen.telephony.Call:CfCheckMessage";
                case Notification.RecCallInfo:
                    return "org.tizen.telephony.Call:CallInfoRec";
                case Notification.FallbackCallInfo:
                    return "org.tizen.telephony.Call:CallFallback";
                case Notification.PrivacyModeCall:
                    return "org.tizen.telephony.Call:CallPrivacyMode";
                case Notification.OtaspCall:
                    return "org.tizen.telephony.Call:CallOtaspStatus";
                case Notification.OtapaCall:
                    return "org.tizen.telephony.Call:CallOtapaStatus";
                case Notification.CallSignalInfo:
                    return "org.tizen.telephony.Call:CallSignalInfo";
                case Notification.CallSoundPath:
                    return "org.tizen.telephony.Call:CallSoundPath";
                case Notification.CallSoundRingbackTone:
                    return "org.tizen.telephony.Call:CallSoundRingbackTone";
                case Notification.CallSoundWbamr:
                    return "org.tizen.telephony.Call:CallSoundWbamr";
                case Notification.CallSoundNoiceReduction:
                    return "org.tizen.telephony.Call:CallSoundNoiseReduction";
                case Notification.CallSoundClock:
                    return "org.tizen.telephony.Call:CallSoundClockStatus";
                case Notification.CallPreferredVoiceSubscription:
                    return "org.tizen.telephony.Call:CallPreferredVoiceSubscription";
                case Notification.CallModifiableInfo:
                    return "org.tizen.telephony.Call:Modifiable";
                case Notification.CallupgradeRequested:
                    return "org.tizen.telephony.Call:CallUpgradeRequested";
                case Notification.CallDowngraded:
                    return "org.tizen.telephony.Call:CallDowngraded";
                case Notification.ModemPower:
                    return "org.tizen.telephony.Modem:Power";
                case Notification.SimStatus:
                    return "org.tizen.telephony.Sim:Status";
                case Notification.SimRefreshed:
                    return "org.tizen.telephony.Sim:Refreshed";
                case Notification.SapStatus:
                    return "org.tizen.telephony.Sap:Status";
                case Notification.SapDisconnect:
                    return "org.tizen.telephony.Sap:Disconnect";
                case Notification.SatSetupMenu:
                    return "org.tizen.telephony.SAT:SetupMenu";
                case Notification.SatDisplayText:
                    return "org.tizen.telephony.SAT:DisplayText";
                case Notification.SatSelectItem:
                    return "org.tizen.telephony.SAT:SelectItem";
                case Notification.SatGetInKey:
                    return "org.tizen.telephony.SAT:GetInkey";
                case Notification.SatGetInput:
                    return "org.tizen.telephony.SAT:GetInput";
                case Notification.SatRefresh:
                    return "org.tizen.telephony.SAT:Refresh";
                case Notification.SatSendSms:
                    return "org.tizen.telephony.SAT:SendSMS";
                case Notification.SatSetupEventList:
                    return "org.tizen.telephony.SAT:SetupEventList";
                case Notification.SatSendDtmf:
                    return "org.tizen.telephony.SAT:SendDtmf";
                case Notification.SatEndProactiveSession:
                    return "org.tizen.telephony.SAT:EndProactiveSession";
                case Notification.SatCallControlResult:
                    return "org.tizen.telephony.SAT:CallControlResult";
                case Notification.SatMoSmControlResult:
                    return "org.tizen.telephony.SAT:MoSmControlResult";
                case Notification.SatSetupCall:
                    return "org.tizen.telephony.SAT:SetupCall";
                case Notification.SatSendSs:
                    return "org.tizen.telephony.SAT:SendSS";
                case Notification.SatSetupUssd:
                    return "org.tizen.telephony.SAT:SetupUSSD";
                case Notification.PhonebookStatus:
                    return "org.tizen.telephony.Phonebook:Status";
                case Notification.PhonebookContactChange:
                    return "org.tizen.telephony.Phonebook:ContactChange";
                case Notification.NetworkRegistrationStatus:
                    return "org.tizen.telephony.Network:RegistrationStatus";
                case Notification.NetworkCellInfo:
                    return "org.tizen.telephony.Network:CellInfo";
                case Notification.NetworkChange:
                    return "org.tizen.telephony.Network:Change";
                case Notification.NetworkTimeInfo:
                    return "org.tizen.telephony.Network:TimeInfo";
                case Notification.NetworkIdentity:
                    return "org.tizen.telephony.Network:Identity";
                case Notification.NetworkSignalStrength:
                    return "org.tizen.telephony.Network:SignalStrength";
                case Notification.NetworkEmergencyCallbackMode:
                    return "org.tizen.telephony.Network:EmergencyCallbackMode";
                case Notification.NetworkDefaultDataSubscription:
                    return "org.tizen.telephony.Network:DefaultDataSubscription";
                case Notification.NetworkDefaultSubscription:
                    return "org.tizen.telephony.Network:DefaultSubscription";
                case Notification.NetworkCellId:
                    return "org.tizen.telephony.Network:CellId";
                case Notification.NetworkLac:
                    return "org.tizen.telephony.Network:Lac";
                case Notification.NetworkTac:
                    return "org.tizen.telephony.Network:Tac";
                case Notification.NetworkSystemId:
                    return "org.tizen.telephony.Network:SystemId";
                case Notification.NetworkNetworkId:
                    return "org.tizen.telephony.Network:NetworkId";
                case Notification.NetworkBsId:
                    return "org.tizen.telephony.Network:BsId";
                case Notification.NetworkBsLatitude:
                    return "org.tizen.telephony.Network:BsLatitude";
                case Notification.NetworkBsLongitude:
                    return "org.tizen.telephony.Network:BsLongitude";
                case Notification.NetworkVolteStatus:
                    return "org.tizen.telephony.Network:VolteStatus";
                case Notification.NetworkEpdgStatus:
                    return "org.tizen.telephony.Network:EpdgStatus";
                case Notification.SsUssd:
                    return "org.tizen.telephony.Ss:NotifyUSSD";
                case Notification.SsReleaseComplete:
                    return "org.tizen.telephony.Ss:ReleaseComplete";
                case Notification.SsNotifyForwarding:
                    return "org.tizen.telephony.Ss:NotifyForwarding";
                case Notification.SsNotifyBarring:
                    return "org.tizen.telephony.Ss:NotifyBarring";
                case Notification.SsNotifyWaiting:
                    return "org.tizen.telephony.Ss:NotifyWaiting";
                case Notification.SsNotifyInfo:
                    return "org.tizen.telephony.Ss:NotifySsInfo";
                case Notification.SmsIncomingMsg:
                    return "org.tizen.telephony.sms:IncommingMsg";
                case Notification.SmsIncomingCbMsg:
                    return "org.tizen.telephony.sms:IncommingCbMsg";
                case Notification.SmsIncomingEtwsMsg:
                    return "org.tizen.telephony.sms:IncommingEtwsMsg";
                case Notification.SmsMemoryStatus:
                    return "org.tizen.telephony.sms:MemoryStatus";
                case Notification.SmsReady:
                    return "org.tizen.telephony.sms:SmsReady";
                case Notification.OemData:
                    return "org.tizen.telephony.OEM:OemData";
                default:
                    return null;
            }
        }

        internal static string ConvertPropToString(Property prop)
        {
            switch(prop)
            {
                case Property.ModemPower:
                    return "org.tizen.telephony.Modem:power";
                case Property.ModemDongleStatus:
                    return "org.tizen.telephony.Modem:dongle_status";
                case Property.ModemDongleLogin:
                    return "org.tizen.telephony.Modem:dongle_login";
                case Property.SimCallForwardState:
                    return "org.tizen.telephony.Sim:cf_state";
                case Property.NetworkLac:
                    return "org.tizen.telephony.Network:lac";
                case Property.NetworkTac:
                    return "org.tizen.telephony.Network:tac";
                case Property.NetworkPlmn:
                    return "org.tizen.telephony.Network:plmn";
                case Property.NetworkCellId:
                    return ".tizen.telephony.Network:cell_id";
                case Property.NetworkPhysicalCellId:
                    return "org.tizen.telephony.Network:physical_cell_id";
                case Property.NetworkServiceType:
                    return "org.tizen.telephony.Network:service_type";
                case Property.NetworkAct:
                    return "org.tizen.telephony.Network:access_technology";
                case Property.NetworkPsType:
                    return "org.tizen.telephony.Network:ps_type";
                case Property.NetworkCircuitStatus:
                    return "org.tizen.telephony.Network:circuit_status";
                case Property.NetworkPacketStatus:
                    return "org.tizen.telephony.Network:packet_status";
                case Property.NetworkRoamingStatus:
                    return "org.tizen.telephony.Network:roaming_status";
                case Property.NetworkNameOption:
                    return "org.tizen.telephony.Network:name_option";
                case Property.NetworkName:
                    return "org.tizen.telephony.Network:network_name";
                case Property.NetworkSpnName:
                    return "org.tizen.telephony.Network:spn_name";
                case Property.NetworkSignalDbm:
                    return "org.tizen.telephony.Network:sig_dbm";
                case Property.NetworkSignalLevel:
                    return "org.tizen.telephony.Network:sig_level";
                case Property.NetworkImsVoiceStatus:
                    return "org.tizen.telephony.Network:ims_voice_status";
                case Property.NetworkVolteEnable:
                    return "org.tizen.telephony.Network:volte_enable";
                case Property.NetworkLteBand:
                    return "org.tizen.telephony.Network:lte_band_type";
                default:
                    return null;
            }
        }

        internal static void ThrowTapiException(int exception, IntPtr handle)
        {
            ThrowException(exception, (handle == IntPtr.Zero), "");
        }

        internal static void ThrowTapiException(int exception, IntPtr handle, string message)
        {
            ThrowException(exception, (handle == IntPtr.Zero), message);
        }

        private static void ThrowException(int exception, bool isHandleNull, string message)
        {
            TapiError _error = (TapiError)exception;
            switch (_error)
            {
                case TapiError.NotSupported:
                    throw new NotSupportedException("Unsupported feature http://tizen.org/feature/network.telephony");
                case TapiError.AccessDenied:
                    throw new UnauthorizedAccessException("Permission denied " + message);
                case TapiError.SystemOutOfMemory:
                    throw new OutOfMemoryException("System out of memory");
                case TapiError.InvalidPtr:
                    if (isHandleNull)
                    {
                        throw new InvalidOperationException("Invalid instance (object may have been disposed or released)");
                    }
                    else
                        throw new ArgumentException("Invalid parameter");
                case TapiError.InvalidInput:
                    throw new ArgumentException("Invalid parameter");
                default:
                    throw new InvalidOperationException(_error.ToString());
            }
        }
    }
}
