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

namespace Tizen.Tapi
{
    /// <summary>
    /// Enumerations for the types of Notification.
    /// </summary>
    public enum Notification
    {
        /// <summary>
        /// Voice call idle status notification.
        /// </summary>
        IdleVoiceCall,
        /// <summary>
        /// Voice call active status notification.
        /// </summary>
        ActiveVoiceCall,
        /// <summary>
        /// Voice call held status notification.
        /// </summary>
        HeldVoiceCall,
        /// <summary>
        /// Voice call dialing status notification.
        /// </summary>
        DialingVoiceCall,
        /// <summary>
        /// Voice call alerting status notification.
        /// </summary>
        AlertVoiceCall,
        /// <summary>
        /// Voice call incoming status notification.
        /// </summary>
        IncomingVoiceCall,
        /// <summary>
        /// Video call idle status notification.
        /// </summary>
        IdleVideoCall,
        /// <summary>
        /// Video call active status notification.
        /// </summary>
        ActiveVideoCall,
        /// <summary>
        /// Video call dialing status notification.
        /// </summary>
        DialingVideoCall,
        /// <summary>
        /// Video call alerting status notification.
        /// </summary>
        AlertVideoCall,
        /// <summary>
        /// Video call incoming status notification.
        /// </summary>
        IncomingVideoCall,
        /// <summary>
        /// Outgoing call waiting nofificaiton.
        /// </summary>
        WaitingCallInfo,
        /// <summary>
        /// Outgoing call forwarded notification.
        /// </summary>
        ForwardCallInfo,
        /// <summary>
        /// Incoming call barred notification.
        /// </summary>
        BarredIncomingCallInfo,
        /// <summary>
        /// Outgoing call barred notification.
        /// </summary>
        BarredOutgoingCallInfo,
        /// <summary>
        /// Mo call deflected notification.
        /// </summary>
        DeflectCallInfo,
        /// <summary>
        /// CLIR suppression reject notification.
        /// </summary>
        ClirCallInfo,
        /// <summary>
        /// Unconditional call forward active notification.
        /// </summary>
        ForwardUnconditionalCallInfo,
        /// <summary>
        /// Conditional call forward active notification.
        /// </summary>
        ForwardConditionalCallInfo,
        /// <summary>
        /// Incoming call forwarded notification.
        /// </summary>
        ForwardedCallInfo,
        /// <summary>
        /// MT deflected call notification.
        /// </summary>
        DeflectedCallInfo,
        /// <summary>
        /// MT transferred call notification.
        /// </summary>
        TransferredCallInfo,
        /// <summary>
        /// Call is in held notification.
        /// </summary>
        HeldCallInfo,
        /// <summary>
        /// Call is in retrieved notificaiton.
        /// </summary>
        ActiveCallInfo,
        /// <summary>
        /// Call in in multiparty notificaiton.
        /// </summary>
        JoinedCallInfo,
        /// <summary>
        /// Call transfer alerting notificaiton.
        /// </summary>
        TransferAlertCallInfo,
        /// <summary>
        /// Call forward check message notification.
        /// </summary>
        CfCheckMessageCallInfo,
        /// <summary>
        /// New call information notification (CDMA only).
        /// </summary>
        RecCallInfo,
        /// <summary>
        /// Call info fallback notification.
        /// </summary>
        FallbackCallInfo,
        /// <summary>
        /// Voice privacy mode change notification (CDMA only).
        /// </summary>
        PrivacyModeCall,
        /// <summary>
        /// OTASP(Over The Air Service Provisioning) status notification (CDMA only).
        /// </summary>
        OtaspCall,
        /// <summary>
        /// OTAPA(Over The Air Parameter Administration) status notification (CDMA only).
        /// </summary>
        OtapaCall,
        /// <summary>
        /// Call signal information notification (CDMA only).
        /// </summary>
        CallSignalInfo,
        /// <summary>
        /// Call sound patch change notification.
        /// </summary>
        CallSoundPath,
        /// <summary>
        /// Call ringback tone sound patch change notification.
        /// </summary>
        CallSoundRingbackTone,
        /// <summary>
        /// Call sound WB-AMR(Wide Band Adaptive Multi-Rate) status notification.
        /// </summary>
        CallSoundWbamr,
        /// <summary>
        /// Call sound noise reduction notification.
        /// </summary>
        CallSoundNoiceReduction,
        /// <summary>
        /// Call sound clock status notification.
        /// </summary>
        CallSoundClock,
        /// <summary>
        /// Preferred voice subscription notification.
        /// </summary>
        CallPreferredVoiceSubscription,
        /// <summary>
        /// VoLTE call which can provide upgrade/downgrade - caller/callee are all in VoLTE call.
        /// </summary>
        CallModifiableInfo,
        /// <summary>
        /// VoLTE call for which upgrade call request is initiated from MT.
        /// </summary>
        CallupgradeRequested,
        /// <summary>
        /// VoLTE call for which downgrade call request is initiated from MT.
        /// </summary>
        CallDowngraded,
        /// <summary>
        /// Modem power notification.
        /// </summary>
        ModemPower,
        /// <summary>
        /// SIM status notification.
        /// </summary>
        SimStatus,
        /// <summary>
        /// SIM refresh notification.
        /// </summary>
        SimRefreshed,
        /// <summary>
        /// Sap card status notification.
        /// </summary>
        SapStatus,
        /// <summary>
        /// Sap disconnect type notification.
        /// </summary>
        SapDisconnect,
        /// <summary>
        /// Sat setup menu notification.
        /// </summary>
        SatSetupMenu,
        /// <summary>
        /// Sat display text notification.
        /// </summary>
        SatDisplayText,
        /// <summary>
        /// Sat select item notification.
        /// </summary>
        SatSelectItem,
        /// <summary>
        /// Sat get inkey notification.
        /// </summary>
        SatGetInKey,
        /// <summary>
        /// Sat get input notification.
        /// </summary>
        SatGetInput,
        /// <summary>
        /// Sat refresh notification.
        /// </summary>
        SatRefresh,
        /// <summary>
        /// Sat send sms notification.
        /// </summary>
        SatSendSms,
        /// <summary>
        /// Sat setup event list notification.
        /// </summary>
        SatSetupEventList,
        /// <summary>
        /// Sat send dtmf notification.
        /// </summary>
        SatSendDtmf,
        /// <summary>
        /// Sat end proactive session notification.
        /// </summary>
        SatEndProactiveSession,
        /// <summary>
        /// Sat call control result notification.
        /// </summary>
        SatCallControlResult,
        /// <summary>
        /// Sat mo sms control result notification.
        /// </summary>
        SatMoSmControlResult,
        /// <summary>
        /// Sat setup call notification.
        /// </summary>
        SatSetupCall,
        /// <summary>
        /// Sat send SS notification.
        /// </summary>
        SatSendSs,
        /// <summary>
        /// Sat setup USSD notification.
        /// </summary>
        SatSetupUssd,
        /// <summary>
        /// Phonebook status notification.
        /// </summary>
        PhonebookStatus,
        /// <summary>
        /// Phonebook change notification.
        /// </summary>
        PhonebookContactChange,
        /// <summary>
        /// Network registration status notification.
        /// </summary>
        NetworkRegistrationStatus,
        /// <summary>
        /// Network cell information notification.
        /// </summary>
        NetworkCellInfo,
        /// <summary>
        /// Network change notification.
        /// </summary>
        NetworkChange,
        /// <summary>
        /// Network time information notification.
        /// </summary>
        NetworkTimeInfo,
        /// <summary>
        /// Network identity notification.
        /// </summary>
        NetworkIdentity,
        /// <summary>
        /// Network signal strength notification.
        /// </summary>
        NetworkSignalStrength,
        /// <summary>
        /// Network emergency callback mode notification.
        /// </summary>
        NetworkEmergencyCallbackMode,
        /// <summary>
        /// Network default data subscription notification.
        /// </summary>
        NetworkDefaultDataSubscription,
        /// <summary>
        /// Network default subscription notification.
        /// </summary>
        NetworkDefaultSubscription,
        /// <summary>
        /// Network cell ID.
        /// </summary>
        NetworkCellId,
        /// <summary>
        /// Network LAC (Location Area Code).
        /// </summary>
        NetworkLac,
        /// <summary>
        /// Network TAC (Tracking Area Code).
        /// </summary>
        NetworkTac,
        /// <summary>
        /// Network system ID.
        /// </summary>
        NetworkSystemId,
        /// <summary>
        /// Network network ID.
        /// </summary>
        NetworkNetworkId,
        /// <summary>
        /// Network base station ID.
        /// </summary>
        NetworkBsId,
        /// <summary>
        /// Network base station latitude.
        /// </summary>
        NetworkBsLatitude,
        /// <summary>
        /// Network base station longitude.
        /// </summary>
        NetworkBsLongitude,
        /// <summary>
        /// Network VoLTE status notification.
        /// </summary>
        NetworkVolteStatus,
        /// <summary>
        /// Network EPDG status notification.
        /// </summary>
        NetworkEpdgStatus,
        /// <summary>
        /// Ss ussd receive notification.
        /// </summary>
        SsUssd,
        /// <summary>
        /// Ss release complete notification.
        /// </summary>
        SsReleaseComplete,
        /// <summary>
        /// Ss call forwarding status notification.
        /// </summary>
        SsNotifyForwarding,
        /// <summary>
        /// Ss call barring status notification.
        /// </summary>
        SsNotifyBarring,
        /// <summary>
        /// Ss call waiting status notification.
        /// </summary>
        SsNotifyWaiting,
        /// <summary>
        /// Ss information notification.
        /// </summary>
        SsNotifyInfo,
        /// <summary>
        /// Sms incoming message notification.
        /// </summary>
        SmsIncomingMsg,
        /// <summary>
        /// Sms cell broadcast message incoming notification.
        /// </summary>
        SmsIncomingCbMsg,
        /// <summary>
        /// Sms ETWS(Earthquake and Tsunami Warning System) message incoming notification.
        /// </summary>
        SmsIncomingEtwsMsg,
        /// <summary>
        /// Sms device memory status notification.
        /// </summary>
        SmsMemoryStatus,
        /// <summary>
        /// Sms ready notification.
        /// </summary>
        SmsReady,
        /// <summary>
        /// Oem data notification.
        /// </summary>
        OemData
    }

    /// <summary>
    /// Enumerations for the types of property definition.
    /// </summary>
    public enum Property
    {
        /// <summary>
        /// Modem power property.
        /// </summary>
        ModemPower,
        /// <summary>
        /// Modem dongle status property.
        /// </summary>
        ModemDongleStatus,
        /// <summary>
        /// Modem dongle login property.
        /// </summary>
        ModemDongleLogin,
        /// <summary>
        /// SIM call forward state property.
        /// </summary>
        SimCallForwardState,
        /// <summary>
        /// Network LAC (Location Area Code) property.
        /// </summary>
        NetworkLac,
        /// <summary>
        /// Network TAC (Tracking Area Code) property (for LTE network).
        /// </summary>
        NetworkTac,
        /// <summary>
        /// Network PLMN property.
        /// </summary>
        NetworkPlmn,
        /// <summary>
        /// Network cell-id property.
        /// </summary>
        NetworkCellId,
        /// <summary>
        /// Network physical cell-id property.
        /// </summary>
        NetworkPhysicalCellId,
        /// <summary>
        /// Network service type property.
        /// </summary>
        NetworkServiceType,
        /// <summary>
        /// Network access technology property.
        /// </summary>
        NetworkAct,
        /// <summary>
        /// Network ps type property.
        /// </summary>
        NetworkPsType,
        /// <summary>
        /// Network circuit status property.
        /// </summary>
        NetworkCircuitStatus,
        /// <summary>
        /// Network packet status property.
        /// </summary>
        NetworkPacketStatus,
        /// <summary>
        /// Network roaming status property.
        /// </summary>
        NetworkRoamingStatus,
        /// <summary>
        /// Network name option property.
        /// </summary>
        NetworkNameOption,
        /// <summary>
        /// Network name property.
        /// </summary>
        NetworkName,
        /// <summary>
        /// SPN name property stored in SIM card.
        /// </summary>
        NetworkSpnName,
        /// <summary>
        /// Network signal dbm property.
        /// </summary>
        NetworkSignalDbm,
        /// <summary>
        /// Network signal level property.
        /// </summary>
        NetworkSignalLevel,
        /// <summary>
        /// Network ims voice support status property.
        /// </summary>
        NetworkImsVoiceStatus,
        /// <summary>
        /// Network volte enable status notification.
        /// </summary>
        NetworkVolteEnable,
        /// <summary>
        /// Network serving LTE band property.
        /// </summary>
        NetworkLteBand
    }
}
