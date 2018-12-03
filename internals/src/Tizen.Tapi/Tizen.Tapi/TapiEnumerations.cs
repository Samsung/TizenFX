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
        /// <remarks>Instance of CallIdleStatusNotificationData will be stored in Data property of NotificationChangedEventArgs.</remarks>
        IdleVoiceCall,
        /// <summary>
        /// Voice call active status notification.
        /// </summary>
        /// <remarks>Active call Id will be stored in Data property of NotificationChangedEventArgs.</remarks>
        ActiveVoiceCall,
        /// <summary>
        /// Voice call held status notification.
        /// </summary>
        /// <remarks>Held call Id will be stored in Data property of NotificationChangedEventArgs.</remarks>
        HeldVoiceCall,
        /// <summary>
        /// Voice call dialing status notification.
        /// </summary>
        /// <remarks>Dialing call Id will be stored in Data property of NotificationChangedEventArgs.</remarks>
        DialingVoiceCall,
        /// <summary>
        /// Voice call alerting status notification.
        /// </summary>
        /// <remarks>Alert call Id will be stored in Data property of NotificationChangedEventArgs.</remarks>
        AlertVoiceCall,
        /// <summary>
        /// Voice call incoming status notification.
        /// </summary>
        /// <remarks>Instance of CallIncomingInfo will be stored in Data property of NotificationChangedEventArgs.</remarks>
        IncomingVoiceCall,
        /// <summary>
        /// Video call idle status notification.
        /// </summary>
        /// <remarks>Instance of CallIdleStatusNotificationData will be stored in Data property of NotificationChangedEventArgs.</remarks>
        IdleVideoCall,
        /// <summary>
        /// Video call active status notification.
        /// </summary>
        /// <remarks>Active call Id will be stored in Data property of NotificationChangedEventArgs.</remarks>
        ActiveVideoCall,
        /// <summary>
        /// Video call dialing status notification.
        /// </summary>
        /// <remarks>Dialing call Id will be stored in Data property of NotificationChangedEventArgs.</remarks>
        DialingVideoCall,
        /// <summary>
        /// Video call alerting status notification.
        /// </summary>
        /// <remarks>Alert call Id will be stored in Data property of NotificationChangedEventArgs.</remarks>
        AlertVideoCall,
        /// <summary>
        /// Video call incoming status notification.
        /// </summary>
        /// <remarks>Instance of CallIncomingInfo will be stored in Data property of NotificationChangedEventArgs.</remarks>
        IncomingVideoCall,
        /// <summary>
        /// Outgoing call waiting nofificaiton.
        /// </summary>
        /// <remarks>Waiting call Id will be stored in Data property of NotificationChangedEventArgs.</remarks>
        WaitingCallInfo,
        /// <summary>
        /// Outgoing call forwarded notification.
        /// </summary>
        /// <remarks>Forward call Id will be stored in Data property of NotificationChangedEventArgs.</remarks>
        ForwardCallInfo,
        /// <summary>
        /// Incoming call barred notification.
        /// </summary>
        /// <remarks>Barred incoming call Id will be stored in Data property of NotificationChangedEventArgs.</remarks>
        BarredIncomingCallInfo,
        /// <summary>
        /// Outgoing call barred notification.
        /// </summary>
        /// <remarks>Barred outgoing call Id will be stored in Data property of NotificationChangedEventArgs.</remarks>
        BarredOutgoingCallInfo,
        /// <summary>
        /// Mo call deflected notification.
        /// </summary>
        /// <remarks>Nothing is stored in Data property of NotificationChangedEventArgs.</remarks>
        DeflectCallInfo,
        /// <summary>
        /// CLIR suppression reject notification.
        /// </summary>
        /// <remarks>Nothing is stored in Data property of NotificationChangedEventArgs.</remarks>
        ClirCallInfo,
        /// <summary>
        /// Unconditional call forward active notification.
        /// </summary>
        /// <remarks>Unconditional forward call Id will be stored in Data property of NotificationChangedEventArgs.</remarks>
        ForwardUnconditionalCallInfo,
        /// <summary>
        /// Conditional call forward active notification.
        /// </summary>
        /// <remarks>Conditional forward call Id will be stored in Data property of NotificationChangedEventArgs.</remarks>
        ForwardConditionalCallInfo,
        /// <summary>
        /// Incoming call forwarded notification.
        /// </summary>
        /// <remarks>Forward call Id will be stored in Data property of NotificationChangedEventArgs.</remarks>
        ForwardedCallInfo,
        /// <summary>
        /// MT deflected call notification.
        /// </summary>
        /// <remarks>Nothing is stored in Data property of NotificationChangedEventArgs.</remarks>
        DeflectedCallInfo,
        /// <summary>
        /// MT transferred call notification.
        /// </summary>
        /// <remarks>Nothing is stored in Data property of NotificationChangedEventArgs.</remarks>
        TransferredCallInfo,
        /// <summary>
        /// Call is in held notification.
        /// </summary>
        /// <remarks>Held call Id will be stored in Data property of NotificationChangedEventArgs.</remarks>
        HeldCallInfo,
        /// <summary>
        /// Call is in retrieved notificaiton.
        /// </summary>
        /// <remarks>Active call Id will be stored in Data property of NotificationChangedEventArgs.</remarks>
        ActiveCallInfo,
        /// <summary>
        /// Call in in multiparty notificaiton.
        /// </summary>
        /// <remarks>Joined call Id will be stored in Data property of NotificationChangedEventArgs.</remarks>
        JoinedCallInfo,
        /// <summary>
        /// Call transfer alerting notificaiton.
        /// </summary>
        /// <remarks>Nothing is stored in Data property of NotificationChangedEventArgs.</remarks>
        TransferAlertCallInfo,
        /// <summary>
        /// Call forward check message notification.
        /// </summary>
        /// <remarks>Nothing is stored in Data property of NotificationChangedEventArgs.</remarks>
        CfCheckMessageCallInfo,
        /// <summary>
        /// New call information notification (CDMA only).
        /// </summary>
        /// <remarks>Instance of CallRecord will be stored in Data property of NotificationChangedEventArgs.</remarks>
        RecCallInfo,
        /// <summary>
        /// Call info fallback notification.
        /// </summary>
        /// <remarks>Nothing is stored in Data property of NotificationChangedEventArgs.</remarks>
        FallbackCallInfo,
        /// <summary>
        /// Voice privacy mode change notification (CDMA only).
        /// </summary>
        /// <remarks>CallPrivacyMode will be stored in Data property of NotificationChangedEventArgs.</remarks>
        PrivacyModeCall,
        /// <summary>
        /// OTASP(Over The Air Service Provisioning) status notification (CDMA only).
        /// </summary>
        /// <remarks>CallOtaspStatus will be stored in Data property of NotificationChangedEventArgs.</remarks>
        OtaspCall,
        /// <summary>
        /// OTAPA(Over The Air Parameter Administration) status notification (CDMA only).
        /// </summary>
        /// <remarks>CallOtapaStatus will be stored in Data property of NotificationChangedEventArgs.</remarks>
        OtapaCall,
        /// <summary>
        /// Call signal information notification (CDMA only).
        /// </summary>
        /// <remarks>Instance of CallSignalNotification will be stored in Data property of NotificationChangedEventArgs.</remarks>
        CallSignalInfo,
        /// <summary>
        /// Call sound patch change notification.
        /// </summary>
        /// <remarks>SoundPath will be stored in Data property of NotificationChangedEventArgs.</remarks>
        CallSoundPath,
        /// <summary>
        /// Call ringback tone sound patch change notification.
        /// </summary>
        /// <remarks>CallSoundRingbackNoti will be stored in Data property of NotificationChangedEventArgs.</remarks>
        CallSoundRingbackTone,
        /// <summary>
        /// Call sound WB-AMR(Wide Band Adaptive Multi-Rate) status notification.
        /// </summary>
        /// <remarks>CallSoundWbamrNoti will be stored in Data property of NotificationChangedEventArgs.</remarks>
        CallSoundWbamr,
        /// <summary>
        /// Call sound noise reduction notification.
        /// </summary>
        /// <remarks>CallSoundNoiseReduction will be stored in Data property of NotificationChangedEventArgs.</remarks>
        CallSoundNoiceReduction,
        /// <summary>
        /// Call sound clock status notification.
        /// </summary>
        /// <remarks>Boolean status value will be stored in Data property of NotificationChangedEventArgs.</remarks>
        CallSoundClock,
        /// <summary>
        /// Preferred voice subscription notification.
        /// </summary>
        /// <remarks>CallPreferredVoiceSubscription will be stored in Data property of NotificationChangedEventArgs.</remarks>
        CallPreferredVoiceSubscription,
        /// <summary>
        /// VoLTE call which can provide upgrade/downgrade - caller/callee are all in VoLTE call.
        /// </summary>
        /// <remarks>Nothing is stored in Data property of NotificationChangedEventArgs.</remarks>
        CallModifiableInfo,
        /// <summary>
        /// VoLTE call for which upgrade call request is initiated from MT.
        /// </summary>
        /// <remarks>CallUpgradeDowngradeRequestNoti will be stored in Data property of NotificationChangedEventArgs.</remarks>
        CallupgradeRequested,
        /// <summary>
        /// VoLTE call for which downgrade call request is initiated from MT.
        /// </summary>
        /// <remarks>CallUpgradeDowngradeRequestNoti will be stored in Data property of NotificationChangedEventArgs.</remarks>
        CallDowngraded,
        /// <summary>
        /// Modem power notification.
        /// </summary>
        /// <remarks>PhonePowerStatus will be stored in Data property of NotificationChangedEventArgs.</remarks>
        ModemPower,
        /// <summary>
        /// SIM status notification.
        /// </summary>
        /// <remarks>SimCardStatus will be stored in Data property of NotificationChangedEventArgs.</remarks>
        SimStatus,
        /// <summary>
        /// SIM refresh notification.
        /// </summary>
        /// <remarks>SatCmdQualiRefresh will be stored in Data property of NotificationChangedEventArgs.</remarks>
        SimRefreshed,
        /// <summary>
        /// Sap card status notification.
        /// </summary>
        /// <remarks>SatCmdQualiRefresh will be stored in Data property of NotificationChangedEventArgs.</remarks>
        SapStatus,
        /// <summary>
        /// Sap disconnect type notification.
        /// </summary>
        SapDisconnect,
        /// <summary>
        /// Sat setup menu notification.
        /// </summary>
        /// <remarks>Instance of SatMainMenuInfo will be stored in Data property of NotificationChangedEventArgs.</remarks>
        SatSetupMenu,
        /// <summary>
        /// Sat display text notification.
        /// </summary>
        /// <remarks>Instance of SatDisplayTextData will be stored in Data property of NotificationChangedEventArgs.</remarks>
        SatDisplayText,
        /// <summary>
        /// Sat select item notification.
        /// </summary>
        /// <remarks>Instance of SatSelectItemData will be stored in Data property of NotificationChangedEventArgs.</remarks>
        SatSelectItem,
        /// <summary>
        /// Sat get inkey notification.
        /// </summary>
        /// <remarks>Instance of SatGetInKeyData will be stored in Data property of NotificationChangedEventArgs.</remarks>
        SatGetInKey,
        /// <summary>
        /// Sat get input notification.
        /// </summary>
        /// <remarks>Instance of SatGetInputData will be stored in Data property of NotificationChangedEventArgs.</remarks>
        SatGetInput,
        /// <summary>
        /// Sat refresh notification.
        /// </summary>
        /// <remarks>Instance of SatRefreshData will be stored in Data property of NotificationChangedEventArgs.</remarks>
        SatRefresh,
        /// <summary>
        /// Sat send sms notification.
        /// </summary>
        /// <remarks>Instance of SatSendSmsData will be stored in Data property of NotificationChangedEventArgs.</remarks>
        SatSendSms,
        /// <summary>
        /// Sat setup event list notification.
        /// </summary>
        /// <remarks>Instance of SatEventListData will be stored in Data property of NotificationChangedEventArgs.</remarks>
        SatSetupEventList,
        /// <summary>
        /// Sat send dtmf notification.
        /// </summary>
        /// <remarks>Instance of SatSendDtmfData will be stored in Data property of NotificationChangedEventArgs.</remarks>
        SatSendDtmf,
        /// <summary>
        /// Sat end proactive session notification.
        /// </summary>
        /// <remarks>SatCommandType will be stored in Data property of NotificationChangedEventArgs.</remarks>
        SatEndProactiveSession,
        /// <summary>
        /// Sat call control result notification.
        /// </summary>
        /// <remarks>Instance of SatCallCtrlConfirmData will be stored in Data property of NotificationChangedEventArgs.</remarks>
        SatCallControlResult,
        /// <summary>
        /// Sat mo sms control result notification.
        /// </summary>
        /// <remarks>Instance of SatMoSmsCtrlData will be stored in Data property of NotificationChangedEventArgs.</remarks>
        SatMoSmControlResult,
        /// <summary>
        /// Sat setup call notification.
        /// </summary>
        /// <remarks>Instance of SatSetupCallData will be stored in Data property of NotificationChangedEventArgs.</remarks>
        SatSetupCall,
        /// <summary>
        /// Sat send SS notification.
        /// </summary>
        /// <remarks>Instance of SatSendSsData will be stored in Data property of NotificationChangedEventArgs.</remarks>
        SatSendSs,
        /// <summary>
        /// Sat setup USSD notification.
        /// </summary>
        /// <remarks>Instance of SatSetupUssdData will be stored in Data property of NotificationChangedEventArgs.</remarks>
        SatSetupUssd,
        /// <summary>
        /// Phonebook status notification.
        /// </summary>
        /// <remarks>Instance of SimPhonebookStatus will be stored in Data property of NotificationChangedEventArgs.</remarks>
        PhonebookStatus,
        /// <summary>
        /// Phonebook change notification.
        /// </summary>
        /// <remarks>Instance of PhonebookContactChangeInfo will be stored in Data property of NotificationChangedEventArgs.</remarks>
        PhonebookContactChange,
        /// <summary>
        /// Network registration status notification.
        /// </summary>
        /// <remarks>Instance of NetworkRegistrationStatus will be stored in Data property of NotificationChangedEventArgs.</remarks>
        NetworkRegistrationStatus,
        /// <summary>
        /// Network cell information notification.
        /// </summary>
        /// <remarks>Instance of NetworkCellNoti will be stored in Data property of NotificationChangedEventArgs.</remarks>
        NetworkCellInfo,
        /// <summary>
        /// Network change notification.
        /// </summary>
        /// <remarks>Instance of NetworkChangeNoti will be stored in Data property of NotificationChangedEventArgs.</remarks>
        NetworkChange,
        /// <summary>
        /// Network time information notification.
        /// </summary>
        /// <remarks>Instance of NetworkTimeNoti will be stored in Data property of NotificationChangedEventArgs.</remarks>
        NetworkTimeInfo,
        /// <summary>
        /// Network identity notification.
        /// </summary>
        /// <remarks>Instance of NetworkIdentityNoti will be stored in Data property of NotificationChangedEventArgs.</remarks>
        NetworkIdentity,
        /// <summary>
        /// Network signal strength notification.
        /// </summary>
        /// <remarks>Signal Strength in dBm will be stored in Data property of NotificationChangedEventArgs.</remarks>
        NetworkSignalStrength,
        /// <summary>
        /// Network emergency callback mode notification.
        /// </summary>
        /// <remarks>NetworkEmergencyCallbackMode will be stored in Data property of NotificationChangedEventArgs.</remarks>
        NetworkEmergencyCallbackMode,
        /// <summary>
        /// Network default data subscription notification.
        /// </summary>
        /// <remarks>NetworkDefaultDataSubscription will be stored in Data property of NotificationChangedEventArgs.</remarks>
        NetworkDefaultDataSubscription,
        /// <summary>
        /// Network default subscription notification.
        /// </summary>
        /// <remarks>NetworkDefaultSubscription will be stored in Data property of NotificationChangedEventArgs.</remarks>
        NetworkDefaultSubscription,
        /// <summary>
        /// Network cell ID.
        /// </summary>
        /// <remarks>Int value will be stored in Data property of NotificationChangedEventArgs.</remarks>
        NetworkCellId,
        /// <summary>
        /// Network LAC (Location Area Code).
        /// </summary>
        /// <remarks>Int value will be stored in Data property of NotificationChangedEventArgs.</remarks>
        NetworkLac,
        /// <summary>
        /// Network TAC (Tracking Area Code).
        /// </summary>
        /// <remarks>Int value will be stored in Data property of NotificationChangedEventArgs.</remarks>
        NetworkTac,
        /// <summary>
        /// Network system ID.
        /// </summary>
        /// <remarks>Int value will be stored in Data property of NotificationChangedEventArgs.</remarks>
        NetworkSystemId,
        /// <summary>
        /// Network network ID.
        /// </summary>
        /// <remarks>Int value will be stored in Data property of NotificationChangedEventArgs.</remarks>
        NetworkNetworkId,
        /// <summary>
        /// Network base station ID.
        /// </summary>
        /// <remarks>Int value will be stored in Data property of NotificationChangedEventArgs.</remarks>
        NetworkBsId,
        /// <summary>
        /// Network base station latitude.
        /// </summary>
        /// <remarks>Int value will be stored in Data property of NotificationChangedEventArgs.</remarks>
        NetworkBsLatitude,
        /// <summary>
        /// Network base station longitude.
        /// </summary>
        /// <remarks>Int value will be stored in Data property of NotificationChangedEventArgs.</remarks>
        NetworkBsLongitude,
        /// <summary>
        /// Network VoLTE status notification.
        /// </summary>
        /// <remarks>Instance of NetworkVolteStatus will be stored in Data property of NotificationChangedEventArgs.</remarks>
        NetworkVolteStatus,
        /// <summary>
        /// Network EPDG status notification.
        /// </summary>
        /// <remarks>Boolean value will be stored in Data property of NotificationChangedEventArgs.</remarks>
        NetworkEpdgStatus,
        /// <summary>
        /// Ss ussd receive notification.
        /// </summary>
        /// <remarks>Instance of SsUssdMsgInfo will be stored in Data property of NotificationChangedEventArgs.</remarks>
        SsUssd,
        /// <summary>
        /// Ss release complete notification.
        /// </summary>
        /// <remarks>Instance of SsReleaseCompleteMsgInfo will be stored in Data property of NotificationChangedEventArgs.</remarks>
        SsReleaseComplete,
        /// <summary>
        /// Ss call forwarding status notification.
        /// </summary>
        /// <remarks>Instance of SsForwardResponse will be stored in Data property of NotificationChangedEventArgs.</remarks>
        SsNotifyForwarding,
        /// <summary>
        /// Ss call barring status notification.
        /// </summary>
        /// <remarks>Instance of SsBarringResponse will be stored in Data property of NotificationChangedEventArgs.</remarks>
        SsNotifyBarring,
        /// <summary>
        /// Ss call waiting status notification.
        /// </summary>
        /// <remarks>Instance of SsWaitingResponse will be stored in Data property of NotificationChangedEventArgs.</remarks>
        SsNotifyWaiting,
        /// <summary>
        /// Ss information notification.
        /// </summary>
        /// <remarks>Instance of SsInfo will be stored in Data property of NotificationChangedEventArgs.</remarks>
        SsNotifyInfo,
        /// <summary>
        /// Sms incoming message notification.
        /// </summary>
        /// <remarks>Instance of SmsIncomingMessageNoti will be stored in Data property of NotificationChangedEventArgs.</remarks>
        SmsIncomingMsg,
        /// <summary>
        /// Sms cell broadcast message incoming notification.
        /// </summary>
        /// <remarks>Instance of SmsIncomingCbMessageNoti will be stored in Data property of NotificationChangedEventArgs.</remarks>
        SmsIncomingCbMsg,
        /// <summary>
        /// Sms ETWS(Earthquake and Tsunami Warning System) message incoming notification.
        /// </summary>
        /// <remarks>Instance of SmsIncomingEtwsMessageNoti will be stored in Data property of NotificationChangedEventArgs.</remarks>
        SmsIncomingEtwsMsg,
        /// <summary>
        /// Sms device memory status notification.
        /// </summary>
        /// <remarks>SmsMemoryStatus will be stored in Data property of NotificationChangedEventArgs.</remarks>
        SmsMemoryStatus,
        /// <summary>
        /// Sms ready notification.
        /// </summary>
        /// <remarks>SmsReadyStatus will be stored in Data property of NotificationChangedEventArgs.</remarks>
        SmsReady,
        /// <summary>
        /// Oem data notification.
        /// </summary>
        /// <remarks>Instance of OemData will be stored in Data property of NotificationChangedEventArgs.</remarks>
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
        /// <remarks>PhonePowerStatus will be stored in Property property of PropertyChangedEventArgs.</remarks>
        ModemPower,
        /// <summary>
        /// Modem dongle status property.
        /// </summary>
        /// <remarks>Boolean value will be stored in Property property of PropertyChangedEventArgs.</remarks>
        ModemDongleStatus,
        /// <summary>
        /// Modem dongle login property.
        /// </summary>
        /// <remarks>Boolean value will be stored in Property property of PropertyChangedEventArgs.</remarks>
        ModemDongleLogin,
        /// <summary>
        /// SIM call forward state property.
        /// </summary>
        /// <remarks>Boolean value will be stored in Property property of PropertyChangedEventArgs.</remarks>
        SimCallForwardState,
        /// <summary>
        /// Network LAC (Location Area Code) property.
        /// </summary>
        /// <remarks>Unsigned int value will be stored in Property property of PropertyChangedEventArgs.</remarks>
        NetworkLac,
        /// <summary>
        /// Network TAC (Tracking Area Code) property (for LTE network).
        /// </summary>
        /// <remarks>Unsigned int value will be stored in Property property of PropertyChangedEventArgs.</remarks>
        NetworkTac,
        /// <summary>
        /// Network PLMN property.
        /// </summary>
        /// <remarks>String value will be stored in Property property of PropertyChangedEventArgs.</remarks>
        NetworkPlmn,
        /// <summary>
        /// Network cell-id property.
        /// </summary>
        /// <remarks>Unsigned int value will be stored in Property property of PropertyChangedEventArgs.</remarks>
        NetworkCellId,
        /// <summary>
        /// Network physical cell-id property.
        /// </summary>
        /// <remarks>Unsigned int value will be stored in Property property of PropertyChangedEventArgs.</remarks>
        NetworkPhysicalCellId,
        /// <summary>
        /// Network service type property.
        /// </summary>
        /// <remarks>NetworkServiceType will be stored in Property property of PropertyChangedEventArgs.</remarks>
        NetworkServiceType,
        /// <summary>
        /// Network access technology property.
        /// </summary>
        /// <remarks>NetworkSystemType will be stored in Property property of PropertyChangedEventArgs.</remarks>
        NetworkAct,
        /// <summary>
        /// Network ps type property.
        /// </summary>
        /// <remarks>NetworkPsType will be stored in Property property of PropertyChangedEventArgs.</remarks>
        NetworkPsType,
        /// <summary>
        /// Network circuit status property.
        /// </summary>
        /// <remarks>NetworkServiceLevel will be stored in Property property of PropertyChangedEventArgs.</remarks>
        NetworkCircuitStatus,
        /// <summary>
        /// Network packet status property.
        /// </summary>
        /// <remarks>NetworkServiceLevel will be stored in Property property of PropertyChangedEventArgs.</remarks>
        NetworkPacketStatus,
        /// <summary>
        /// Network roaming status property.
        /// </summary>
        /// <remarks>Boolean value will be stored in Property property of PropertyChangedEventArgs.</remarks>
        NetworkRoamingStatus,
        /// <summary>
        /// Network name option property.
        /// </summary>
        /// <remarks>NetworkNameDisplayCondition will be stored in Property property of PropertyChangedEventArgs.</remarks>
        NetworkNameOption,
        /// <summary>
        /// Network name property.
        /// </summary>
        /// <remarks>String value will be stored in Property property of PropertyChangedEventArgs.</remarks>
        NetworkName,
        /// <summary>
        /// SPN name property stored in SIM card.
        /// </summary>
        /// <remarks>String value will be stored in Property property of PropertyChangedEventArgs.</remarks>
        NetworkSpnName,
        /// <summary>
        /// Network signal dbm property.
        /// </summary>
        /// <remarks>Int value will be stored in Property property of PropertyChangedEventArgs.</remarks>
        NetworkSignalDbm,
        /// <summary>
        /// Network signal level property.
        /// </summary>
        /// <remarks>Int value will be stored in Property property of PropertyChangedEventArgs.</remarks>
        NetworkSignalLevel,
        /// <summary>
        /// Network ims voice support status property.
        /// </summary>
        /// <remarks>Boolean value will be stored in Property property of PropertyChangedEventArgs.</remarks>
        NetworkImsVoiceStatus,
        /// <summary>
        /// Network volte enable status notification.
        /// </summary>
        /// <remarks>VolteNetworkType will be stored in Property property of PropertyChangedEventArgs.</remarks>
        NetworkVolteEnable,
        /// <summary>
        /// Network serving LTE band property.
        /// </summary>
        /// <remarks>NetworkLteBandType will be stored in Property property of PropertyChangedEventArgs.</remarks>
        NetworkLteBand
    }
}
