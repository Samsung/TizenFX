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
    /// Enumeration for call end cause.
    /// </summary>
    public enum CallEndCause
    {
        /// <summary>
        /// No Cause.
        /// </summary>
        None = 0x00,
        /// <summary>
        /// Unassigned Number.
        /// </summary>
        UnassignedNumber,
        /// <summary>
        /// No Route to Destination.
        /// </summary>
        NoRouteToDestination,
        /// <summary>
        /// Channel Unacceptable.
        /// </summary>
        ChannelUnaccept,
        /// <summary>
        /// Operator Determined Barring.
        /// </summary>
        OperatorBarring,
        /// <summary>
        /// Normal Call Clearing.
        /// </summary>
        NormalCallClearing,
        /// <summary>
        /// User Busy.
        /// </summary>
        UserBusy,
        /// <summary>
        /// No user responding.
        /// </summary>
        NoUserRespond,
        /// <summary>
        /// User Alerting no Answer.
        /// </summary>
        UserAlertNoAnswer,
        /// <summary>
        /// Call Rejected.
        /// </summary>
        CallRejected,
        /// <summary>
        /// Number Changed.
        /// </summary>
        NumberChanged,
        /// <summary>
        /// Non Selected User Clearing.
        /// </summary>
        NonSelectUserClearing,
        /// <summary>
        /// Destination out of Order.
        /// </summary>
        DestinationOutOfOrder,
        /// <summary>
        /// Invalid Number Format.
        /// </summary>
        InvalidNumberFormat,
        /// <summary>
        /// Facility Rejected.
        /// </summary>
        FacilityRejected,
        /// <summary>
        /// Response to Status Enquiry.
        /// </summary>
        ResponseStatusEnquiry,
        /// <summary>
        /// Normal Unspecified.
        /// </summary>
        NormalUnspecified,
        /// <summary>
        /// No Circuit Channel Available.
        /// </summary>
        NoAvailableChannel,
        /// <summary>
        /// Network out of Order.
        /// </summary>
        NetworkOutOfOrder,
        /// <summary>
        /// Temporary Failure.
        /// </summary>
        TemporaryFailure,
        /// <summary>
        /// Switching Equipment Congestion.
        /// </summary>
        SwitchEquipmentCongestion,
        /// <summary>
        /// Access Information Discarded.
        /// </summary>
        AccessInfoDiscarded,
        /// <summary>
        /// Requested Circuit channel not available.
        /// </summary>
        NotAvailableRequestedChannel,
        /// <summary>
        /// Resources unavailable and unspecified.
        /// </summary>
        ResourceUnavailableUnspecified,
        /// <summary>
        /// Quality of service unavailable.
        /// </summary>
        ServiceQualityUnavailable,
        /// <summary>
        /// Requested facility not subscribed.
        /// </summary>
        NotSubscribedRequestedFacility,
        /// <summary>
        /// Incoming call barred within CUG.
        /// </summary>
        IncomingCallBarredWithinCug,
        /// <summary>
        /// Bearer capability not Authorised.
        /// </summary>
        BearerCapabilityUnauthorised,
        /// <summary>
        /// Bearer capability not presently Available.
        /// </summary>
        BearerCapabilityNotAvailable,
        /// <summary>
        /// Service or Option not available.
        /// </summary>
        ServiceOptionNotAvailable,
        /// <summary>
        /// Service not implemented.
        /// </summary>
        BearerServiceNotImplemented,
        /// <summary>
        /// ACM GEQ ACMAX.
        /// </summary>
        AcmGeqAcmax,
        /// <summary>
        /// Requested facility not implemented.
        /// </summary>
        RequestedFacilityNotImplemented,
        /// <summary>
        /// Restricted digital info BC not available
        /// </summary>
        OnlyRestrictedDigitalBcInfoAvailable,
        /// <summary>
        /// Service or Option not Implemented.
        /// </summary>
        ServiceOptionNotImplemented,
        /// <summary>
        /// Transaction ID value.
        /// </summary>
        TransactionIdValue,
        /// <summary>
        /// Not a member of CUG.
        /// </summary>
        UserNotCugMember,
        /// <summary>
        /// Incompatible Destination.
        /// </summary>
        IncompatibleDestination,
        /// <summary>
        /// Transit Network selection.
        /// </summary>
        TransitNetworkSelect,
        /// <summary>
        /// Semantically Incorrect message.
        /// </summary>
        SemanticIncorrectMessage,
        /// <summary>
        /// Invalid Mandatory Message.
        /// </summary>
        InvalidMandatoryInfo,
        /// <summary>
        /// Message Type Non Existent.
        /// </summary>
        MessageTypeNotExist,
        /// <summary>
        /// Message type not compatible with Prot state.
        /// </summary>
        MessageTypeNotCompatibleWithProtState,
        /// <summary>
        /// IE non exitent or not implemented.
        /// </summary>
        IeNotExistOrNotImplemented,
        /// <summary>
        /// Conditional IE error.
        /// </summary>
        ConditionalIeError,
        /// <summary>
        /// Not Compatible with protocol state.
        /// </summary>
        NotCompatibleWithProtocolState,
        /// <summary>
        /// Recovery on timer expiry.
        /// </summary>
        RecoveryOnTimeExpiry,
        /// <summary>
        /// Protocol error unspecified.
        /// </summary>
        ProtocolErrorUnspecified,
        /// <summary>
        /// Interworking unspecified.
        /// </summary>
        InterworkingUnspecified,
        /// <summary>
        /// Reorder.
        /// </summary>
        Reorder,
        /// <summary>
        /// End unspecified.
        /// </summary>
        EndUnspecified = 128,
        /// <summary>
        /// IMSI unknown in HLR.
        /// </summary>
        RejectCauseImsiUnknownInHlr,
        /// <summary>
        /// Illegal MS.
        /// </summary>
        RejectCauseIllegalMs,
        /// <summary>
        /// IMSI unknown in VLR.
        /// </summary>
        RejectCauseImsiUnknownInVlr,
        /// <summary>
        /// IMEI not accepted.
        /// </summary>
        RejectCauseImeiNotAccepted,
        /// <summary>
        /// Illegal ME.
        /// </summary>
        RejectCauseIllegalMe,
        /// <summary>
        /// GPRS service not allowed.
        /// </summary>
        RejectCauseGprsServiceNotAllowed,
        /// <summary>
        /// GPRS services and Non-GPRS services not allowed.
        /// </summary>
        RejectCauseGprsAndNonGprsServiceNotAllowed,
        /// <summary>
        /// MS device cannot be derived by the network.
        /// </summary>
        RejectCauseMsIdentityNotDerivedByNetwork,
        /// <summary>
        /// Implicitly detached.
        /// </summary>
        RejectCauseImplicitlyDetached,
        /// <summary>
        /// PLMN not allowed.
        /// </summary>
        RejectCausePlmnNotAllowed,
        /// <summary>
        /// LA not allowed.
        /// </summary>
        RejectCauseLaNotAllowed,
        /// <summary>
        /// National roaming not allowed.
        /// </summary>
        RejectCauseNationalRoamingNotAllowed,
        /// <summary>
        /// GPRS services not allowed in this PLMN.
        /// </summary>
        RejectCauseGprsServiceNotAllowedInPlmn,
        /// <summary>
        /// No suitable cells in the LA.
        /// </summary>
        RejectCauseNoSuitableCellsInLa,
        /// <summary>
        /// MSC temporarily not reachable.
        /// </summary>
        RejectCauseMscTempNotReachable,
        /// <summary>
        /// Network unavailable.
        /// </summary>
        RejectCauseNetworkFailure,
        /// <summary>
        /// MAC failure.
        /// </summary>
        RejectCauseMacFailure,
        /// <summary>
        /// SYNCH failure.
        /// </summary>
        RejectCauseSynchFailure,
        /// <summary>
        /// Congestion.
        /// </summary>
        RejectCauseCongestion,
        /// <summary>
        /// GSM Auth unaccepted.
        /// </summary>
        RejectCauseGsmAuthUnaccepted,
        /// <summary>
        /// Service option not supported.
        /// </summary>
        RejectCauseServiceOptionNotSupported,
        /// <summary>
        /// REQ_SERV option not suscribed.
        /// </summary>
        RejectCauseReqServOptionNotSubscribed,
        /// <summary>
        /// Service OPT out of order.
        /// </summary>
        RejectCauseServiceOptOutOfOrder,
        /// <summary>
        /// Call cannot be identified.
        /// </summary>
        RejectCauseCallUnidentified,
        /// <summary>
        /// No PDP context Activated.
        /// </summary>
        RejectCauseNoPdpContextActivated,
        /// <summary>
        /// Retry upon entry into a new call min value.
        /// </summary>
        RejectCauseRetryUponEntryToNewCallMinValue,
        /// <summary>
        /// Retry upon entry into a new call max value.
        /// </summary>
        RejectCauseRetryUponEntryToNewCallMaxValue,
        /// <summary>
        /// Semantically incorret message.
        /// </summary>
        RejectCauseSemanticIncorrectMessage,
        /// <summary>
        /// Invalid mandatory information.
        /// </summary>
        RejectCauseInvalidMandatoryInfo,
        /// <summary>
        /// Message type non-existant.
        /// </summary>
        RejectCauseMessageTypeNotExist,
        /// <summary>
        /// Message type not COMP PRT ST.
        /// </summary>
        RejectCauseMessageTypeNotCompPrtSt,
        /// <summary>
        /// IE non existent.
        /// </summary>
        RejectCauseIeNotExist,
        /// <summary>
        /// MSG not compatible protocol state.
        /// </summary>
        RejectCauseMessageNotCompatibleProtocolState,
        /// <summary>
        /// REJ unspecified.
        /// </summary>
        RejectCauseUnspecified,
        /// <summary>
        /// RR release indication.
        /// </summary>
        RejectCauseRrReleaseInd,
        /// <summary>
        /// Random Access Failure.
        /// </summary>
        RejectCauseRandomAccessFailure,
        /// <summary>
        /// RRC release indication.
        /// </summary>
        RejectCauseRrcReleaseInd,
        /// <summary>
        /// RRC close session indication.
        /// </summary>
        RejectCasueRrcCloseInd,
        /// <summary>
        /// RRC open session failure.
        /// </summary>
        RejectCauseRrcOpenSessionFailure,
        /// <summary>
        /// Low level failure.
        /// </summary>
        RejectCauseLowLevelFail,
        /// <summary>
        /// Low level failure redial not alowed.
        /// </summary>
        RejectCauseLowLevelFailRedialNotAllowed,
        /// <summary>
        /// Low level immediate retry.
        /// </summary>
        RejectCauseLowLevelRetry,
        /// <summary>
        /// Invalid SIM.
        /// </summary>
        RejectCauseInvalidSim,
        /// <summary>
        /// No service.
        /// </summary>
        RejectCauseNoService,
        /// <summary>
        /// Timer T3230 expiry.
        /// </summary>
        RejectCauseTimerT3230Expiry,
        /// <summary>
        /// No cell available.
        /// </summary>
        RejectCauseNoCellAvailable,
        /// <summary>
        /// Wrong state.
        /// </summary>
        RejectCauseWrongState,
        /// <summary>
        /// Access class blocked.
        /// </summary>
        RejectCauseAccessClassBlocked,
        /// <summary>
        /// Abort Message received.
        /// </summary>
        RejectCauseAbortMessageReceived,
        /// <summary>
        /// Other cause.
        /// </summary>
        OtherCause,
        /// <summary>
        /// Timer T303 expiry.
        /// </summary>
        RejectCauseTimerT303Expiry,
        /// <summary>
        /// Rejected due to unavailibilty of resources.
        /// </summary>
        RejectCauseNoResources,
        /// <summary>
        /// MM release pending.
        /// </summary>
        RejectCauseMmReleasePending,
        /// <summary>
        /// Invalid user data.
        /// </summary>
        RejectCauseInvalidUserData,
        /// <summary>
        /// Maximum End Cause limit for GSM/WCDMA.
        /// </summary>
        EndCauseMax = 255,
        /// <summary>
        /// Call Released by User.
        /// </summary>
        CdmaEndCauseReleasedByUser = 0x1001,
        /// <summary>
        /// Call Released by Network.
        /// </summary>
        CdmaEndCauseReleasedByNet,
        /// <summary>
        /// Call Released because the network is busy.
        /// </summary>
        CdmaEndCauseNetworkBusy,
        /// <summary>
        /// Call Released because of No Service area.
        /// </summary>
        CdmaEndCauseNoService,
        /// <summary>
        /// Call Released because of Fading.
        /// </summary>
        CdmaEndCauseFading,
        /// <summary>
        /// Call Released because of reorder.
        /// </summary>
        CdmaEndCauseReleaseByReorder,
        /// <summary>
        /// Call Released because of intercept.
        /// </summary>
        CdmaEndCauseReleaseByIntercept,
        /// <summary>
        /// Call Released because of silent zone retry.
        /// </summary>
        CdmaEndCauseSilentZoneRetry,
        /// <summary>
        /// Call Released because of OTA call failure.
        /// </summary>
        CdmaEndCauseOtaCallFail,
        /// <summary>
        /// Call Released because phone is offline.
        /// </summary>
        CdmaEndCausePhoneOffline,
        /// <summary>
        /// Call Released because CDMA is locked.
        /// </summary>
        CdmaEndCauseCdmaLocked,
        /// <summary>
        /// Call Released because of the flash-is-in-progress error.
        /// </summary>
        CdmaEndCauseFlashInProgressError,
        /// <summary>
        /// Call Released because of the e911 mode.
        /// </summary>
        CdmaEndCauseE911ModeError,
        /// <summary>
        /// Call Released by Others.
        /// </summary>
        CdmaEndCauseOthers,
        /// <summary>
        /// Maximum End Cause limit for CDMA.
        /// </summary>
        CdmaEndCauseMax
    }

    /// <summary>
    /// Enumeration for call type to be used by applications.
    /// </summary>
    public enum CallType
    {
        /// <summary>
        /// Voice call type.
        /// </summary>
        Voice,
        /// <summary>
        /// Data call type - (for modem, fax, packet, and other such calls).
        /// </summary>
        Data,
        /// <summary>
        /// Emergency call type.
        /// </summary>
        Emergency
    }

    /// <summary>
    /// Enumeration for the call name mode.
    /// </summary>
    public enum CallNameMode
    {
        /// <summary>
        /// This identifier refers to presenting the calling party's name identity to the called party.
        /// </summary>
        Available = 0,
        /// <summary>
        /// This identifier refers to restricting the name identity of the calling party from being presented to the called party.
        /// </summary>
        Restricted = 1,
        /// <summary>
        /// This identifier refers to the unavailability of the calling party's name identity from being offered to the called party.
        /// </summary>
        Unavailable = 2,
        /// <summary>
        /// This identifier refers to offering the calling party's name identity to the called party with which the presentation restriction is overridden.
        /// </summary>
        AvailRestricted = 3
    }

    /// <summary>
    /// Enumeration for the "Cli mode" value.
    /// </summary>
    public enum CallCliMode
    {
        /// <summary>
        /// Presentation Allowed.
        /// </summary>
        PresentationAvailable,
        /// <summary>
        /// Presentation Restricted.
        /// </summary>
        PresentationRestricted,
        /// <summary>
        /// Number not available.
        /// </summary>
        NumberUnavailable,
        /// <summary>
        /// Presentation default.
        /// </summary>
        PresentationDefault
    }

    /// <summary>
    /// Enumeration for "No Cli cause" value.
    /// </summary>
    public enum CallNoCliCause
    {
        /// <summary>
        /// None.
        /// </summary>
        None = -1,
        /// <summary>
        /// Unavailable.
        /// </summary>
        Unavailable = 0x00,
        /// <summary>
        /// Rejected by user.
        /// </summary>
        RejectByUser = 0x01,
        /// <summary>
        /// Other services.
        /// </summary>
        InteractionOtherServices = 0x02,
        /// <summary>
        /// Coin line phone.
        /// </summary>
        CoinLinePayPhone = 0x03
    }

    /// <summary>
    /// Enumeration for call active line(IN GSM ONLY: call identification number).
    /// </summary>
    public enum CallActiveLine
    {
        /// <summary>
        /// Line 1.
        /// </summary>
        Line1,
        /// <summary>
        /// Line 2.
        /// </summary>
        Line2
    }

    /// <summary>
    /// Enumeration for the call record info type.
    /// </summary>
    public enum CallRecordType
    {
        /// <summary>
        /// Name type.
        /// </summary>
        Name,
        /// <summary>
        /// Number type.
        /// </summary>
        Number,
        /// <summary>
        /// Line control type.
        /// </summary>
        LineControl
    }

    /// <summary>
    /// Enumeration for the voice privacy option mode. (CDMA only).
    /// </summary>
    public enum CallPrivacyMode
    {
        /// <summary>
        /// Standard mode.
        /// </summary>
        Standard = 0x00,
        /// <summary>
        /// Enhanced mode.
        /// </summary>
        Enhanced
    }

    /// <summary>
    /// Enumeration for the OTASP Status. (CDMA only)
    /// </summary>
    public enum CallOtaspStatus
    {
        /// <summary>
        /// SPL unlocked ok.
        /// </summary>
        SplUnlockedOk = 0x01,
        /// <summary>
        /// A-Key excess ok.
        /// </summary>
        AKeyExcessOk,
        /// <summary>
        /// SSD update ok.
        /// </summary>
        SsdUpdateOk,
        /// <summary>
        /// NAM download ok.
        /// </summary>
        NamDownloadOk,
        /// <summary>
        /// MDN download ok.
        /// </summary>
        MdnDownloadOk,
        /// <summary>
        /// IMSI download ok.
        /// </summary>
        ImsiDownloadOk,
        /// <summary>
        /// PRL download ok.
        /// </summary>
        PrlDownloadOk,
        /// <summary>
        /// Commit ok.
        /// </summary>
        CommitOk,
        /// <summary>
        /// Programming ok.
        /// </summary>
        ProgrammingOk,
        /// <summary>
        /// Success.
        /// </summary>
        Success,
        /// <summary>
        /// Unsuccess.
        /// </summary>
        Unsuccess,
        /// <summary>
        /// OTAPA verify ok.
        /// </summary>
        OtapaVerifyOk,
        /// <summary>
        /// Progress.
        /// </summary>
        Progress,
        /// <summary>
        /// SPC excess failure.
        /// </summary>
        SpcExcessFailure,
        /// <summary>
        /// Lock code password set.
        /// </summary>
        LockCodePasswordSet
    }

    /// <summary>
    /// Enumeration for the OTAPA status. (CDMA only)
    /// </summary>
    public enum CallOtapaStatus
    {
        /// <summary>
        /// Stop.
        /// </summary>
        Stop = 0x00,
        /// <summary>
        /// Start.
        /// </summary>
        Start
    }

    /// <summary>
    /// Enumeration for call sound path.
    /// </summary>
    public enum SoundPath
    {
        /// <summary>
        /// Audio path is handset.
        /// </summary>
        Handset = 0x01,
        /// <summary>
        /// Audio path is handset.
        /// </summary>
        Headset = 0x02,
        /// <summary>
        /// Audio path is Handsfree.
        /// </summary>
        Handsfree = 0x03,
        /// <summary>
        /// Audio path is bluetooth.
        /// </summary>
        Bluetooth = 0x04,
        /// <summary>
        /// Audio path is stereo bluetooth.
        /// </summary>
        StereoBluetooth = 0x05,
        /// <summary>
        /// Audio path is speaker phone.
        /// </summary>
        SpeakerPhone = 0x06,
        /// <summary>
        /// Audio path is headset_3_5PI.
        /// </summary>
        Headset35Pi = 0x07,
        /// <summary>
        /// Audio path Bluetooth NSEC is off.
        /// </summary>
        BluetoothNsecOff = 0x08,
        /// <summary>
        /// Audio path Mic one.
        /// </summary>
        Mic1 = 0x09,
        /// <summary>
        /// Audio path Bluetooth Mic two.
        /// </summary>
        Mic2 = 0x0A,
        /// <summary>
        /// Audio path is Bluetooth WB.
        /// </summary>
        BluetoothWb = 0x0B,
        /// <summary>
        /// Audio path is BT nsec off WB.
        /// </summary>
        BluetoothNsecOffWb = 0x0C,
        /// <summary>
        /// Audio path is headset HAC.
        /// </summary>
        HeadsetHac = 0x0D,
        /// <summary>
        /// Audio path is Bikemode Near.
        /// </summary>
        BikemodeNear = 0x17,
        /// <summary>
        /// Audio path is Bikemode Far.
        /// </summary>
        BikemodeFar = 0x18,
        /// <summary>
        /// Audio path is VoLTE handset.
        /// </summary>
        VolteHandset = 0x1F,
        /// <summary>
        /// Audio path is VoLTE headset.
        /// </summary>
        VolteHeadset = 0x20,
        /// <summary>
        /// Audio path is VoLTE Handsfree.
        /// </summary>
        VolteSpeaker = 0x21,
        /// <summary>
        /// Audio path is VoLTE bluetooth.
        /// </summary>
        VolteBluetooth = 0x22,
        /// <summary>
        /// Audio path is VoLTE stereo bluetooth.
        /// </summary>
        VolteStereoBluetooth = 0x23,
        /// <summary>
        /// Audio path is VoLTE speaker phone.
        /// </summary>
        VolteHeadPhone = 0x24,
        /// <summary>
        /// Audio path is VoLTE headset_3_5PI.
        /// </summary>
        VolteHeadset35Pi = 0x25,
        /// <summary>
        /// Audio path VoLTE Bluetooth NSEC is off.
        /// </summary>
        VolteBluetoothNsecOff = 0x26,
        /// <summary>
        /// Audio path is VoLTE Bluetooth WB.
        /// </summary>
        VolteBluetoothWb = 0x27,
        /// <summary>
        /// Audio path is VoLTE BT nsec off WB.
        /// </summary>
        VolteBluetoothNsecOffWb = 0x28,
        /// <summary>
        /// Audio path is VoLTE handset HAC.
        /// </summary>
        VolteHandsetHac = 0x29,
        /// <summary>
        /// Audio path is call forwarding.
        /// </summary>
        CallForward = 0x32,
        /// <summary>
        /// Audio path is Loopback Mic1+Ear.
        /// </summary>
        HeadsetMic1 = 0x33,
        /// <summary>
        /// Audio path is Loopback Mic2+Ear.
        /// </summary>
        HeadsetMic2 = 0x34,
        /// <summary>
        /// Audio path is Loopback Mic3+Ear.
        /// </summary>
        HeadsetMic3 = 0x35
    }

    /// <summary>
    /// Enumeration for the Alert Signal Type. (CDMA only)
    /// </summary>
    public enum CallAlertSignal
    {
        /// <summary>
        /// Tone.
        /// </summary>
        Tone = 0x00,
        /// <summary>
        /// ISDN Alerting.
        /// </summary>
        IsdnAlert,
        /// <summary>
        /// IS54B Alerting.
        /// </summary>
        Is54bAlert,
        /// <summary>
        /// Reserved.
        /// </summary>
        Reserved
    }

    /// <summary>
    /// Enumeration for the Alert Pitch Type. (CDMA only)
    /// </summary>
    public enum CallAlertPitch
    {
        /// <summary>
        /// Alert Pitch Medium.
        /// </summary>
        Medium = 0x00,
        /// <summary>
        /// Alert Pitch High.
        /// </summary>
        High,
        /// <summary>
        /// Alert Pitch Low.
        /// </summary>
        Low,
        /// <summary>
        /// Reserved.
        /// </summary>
        Reserved
    }

    /// <summary>
    /// Enumeration for the signals specific to the alert signal type. (CDMA only)
    /// </summary>
    public enum CallToneSignal
    {
        /// <summary>
        /// Dial.
        /// </summary>
        Dial = 0x00,
        /// <summary>
        /// Ringback Tone ON.
        /// </summary>
        RingbackToneOn,
        /// <summary>
        /// Intercept Tone ON.
        /// </summary>
        InterceptToneOn,
        /// <summary>
        /// Abbreviation Tone.
        /// </summary>
        AbbreviationTone,
        /// <summary>
        /// Network Congestion Tone ON.
        /// </summary>
        NetworkCongestionToneOn,
        /// <summary>
        /// Abbreviation Network Congestion.
        /// </summary>
        AbbreviationNetworkCongestion,
        /// <summary>
        /// Busy Tone ON>
        /// </summary>
        BusyToneOn,
        /// <summary>
        /// CFRM Tone ON.
        /// </summary>
        CfrmToneOn,
        /// <summary>
        /// Answer Tone ON.
        /// </summary>
        AnswerToneOn,
        /// <summary>
        /// Call Waiting Tone ON.
        /// </summary>
        CallWaitingToneOn,
        /// <summary>
        /// Pipe Tone ON.
        /// </summary>
        PipeToneOn,
        /// <summary>
        /// Tone OFF.
        /// </summary>
        Off
    }

    /// <summary>
    /// Enumeration for the call ISDN Alert signal. (CDMA only)
    /// </summary>
    public enum CallIsdnAlertSignal
    {
        /// <summary>
        /// Normal.
        /// </summary>
        Normal = 0x00,
        /// <summary>
        /// Inter group.
        /// </summary>
        InterGroup,
        /// <summary>
        /// Special Priority.
        /// </summary>
        SpecialPriority,
        /// <summary>
        /// ISDN Reserved1.
        /// </summary>
        IsdnReserved1,
        /// <summary>
        /// Ping Ring.
        /// </summary>
        PingRing,
        /// <summary>
        /// ISDN Reserved2.
        /// </summary>
        IsdnReserved2,
        /// <summary>
        /// ISDN Reserved3.
        /// </summary>
        IsdnReserved3,
        /// <summary>
        /// ISDN Reserved4.
        /// </summary>
        IsdnReserved4,
        /// <summary>
        /// Alert OFF.
        /// </summary>
        Off
    }

    /// <summary>
    /// Enumeration for the call IS54B Alert signal types.
    /// </summary>
    public enum CallIs54bAlertSignal
    {
        /// <summary>
        /// No Tone.
        /// </summary>
        NoTone = 0x00,
        /// <summary>
        /// Long.
        /// </summary>
        Long,
        /// <summary>
        /// Short Short.
        /// </summary>
        ShortShort,
        /// <summary>
        /// Short Short Long.
        /// </summary>
        ShortShortLong,
        /// <summary>
        /// Short Short 2.
        /// </summary>
        ShortShort2,
        /// <summary>
        /// Short Long Short.
        /// </summary>
        ShortLongShort,
        /// <summary>
        /// Short Short Short Short.
        /// </summary>
        ShortShortShortShort,
        /// <summary>
        /// PBX Long.
        /// </summary>
        PbxLong,
        /// <summary>
        /// PBX(Private Branch Exchange) Short Short.
        /// </summary>
        PbxShortShort,
        /// <summary>
        /// PBX Short Short Long.
        /// </summary>
        PbxShortShortLong,
        /// <summary>
        /// PBX Short Long Short.
        /// </summary>
        PbxShortLongShort,
        /// <summary>
        /// PBX Short Short Short Short.
        /// </summary>
        PbxShortShortShortShort,
        /// <summary>
        /// PIP PIP PIP PIP.
        /// </summary>
        PipPipPipPip
    }

    /// <summary>
    /// Enumeration for call sound ringback tone notification data.
    /// </summary>
    public enum CallSoundRingbackNoti
    {
        /// <summary>
        /// Ringback Tone End.
        /// </summary>
        End,
        /// <summary>
        /// Ringback Tone Start.
        /// </summary>
        Start
    }

    /// <summary>
    /// Enumeration for call sound WBAMR notification data.
    /// </summary>
    public enum CallSoundWbamrNoti
    {
        /// <summary>
        /// Status OFF.
        /// </summary>
        Off,
        /// <summary>
        /// Status ON.
        /// </summary>
        On,
        /// <summary>
        /// Status OFF 16k.
        /// </summary>
        Off16k,
        /// <summary>
        /// Status ON 8k.
        /// </summary>
        On8k
    }

    /// <summary>
    /// Enumeration for call sound noise reduction.
    /// </summary>
    public enum CallSoundNoiseReduction
    {
        /// <summary>
        /// Sound noise reduction off.
        /// </summary>
        Off,
        /// <summary>
        /// Sound noise reduction on.
        /// </summary>
        On
    }

    /// <summary>
    /// Enumeration for call preferred voice subscription.
    /// </summary>
    public enum CallPreferredVoiceSubscription
    {
        /// <summary>
        /// Unknown status.
        /// </summary>
        Unknown = -1,
        /// <summary>
        /// Current network.
        /// </summary>
        CurrentNetwork = 0,
        /// <summary>
        /// Ask Always.
        /// </summary>
        AskAlways,
        /// <summary>
        /// Sim 1.
        /// </summary>
        Sim1,
        /// <summary>
        /// Sim 2.
        /// </summary>
        Sim2
    }

    /// <summary>
    /// Enumeration for specifying type for call upgrade/downgrade.
    /// </summary>
    public enum CallConfigType
    {
        /// <summary>
        /// Call type is invalid.
        /// </summary>
        Invalid = -1,
        /// <summary>
        /// Call type is Audio.
        /// </summary>
        Audio = 2,
        /// <summary>
        /// Call type is Video Share TX.
        /// </summary>
        VideoShareTx = 3,
        /// <summary>
        /// Call type is Video Share RX.
        /// </summary>
        VideoShareRx = 4,
        /// <summary>
        /// Call type is Inbound Video Call.
        /// </summary>
        InboundVideoCall = 5,
        /// <summary>
        /// Call type is HD Video.
        /// </summary>
        HdVideo = 6,
        /// <summary>
        /// Call type is Video Conference.
        /// </summary>
        VideoConference = 7,
        /// <summary>
        /// Call type is QCIF Video Conference.
        /// </summary>
        QcifVideoConference = 8,
        /// <summary>
        /// Call type is QVGA.
        /// </summary>
        QvgaVideo = 9,
        /// <summary>
        /// Call type is QCIF Video.
        /// </summary>
        QcifVideo = 10,
        /// <summary>
        /// Call type is tty Full.
        /// </summary>
        TtyFull = 11,
        /// <summary>
        /// Call type is tty HCO.
        /// </summary>
        TtyHco = 12,
        /// <summary>
        /// Call type is tty VCO.
        /// </summary>
        TtyVco = 13,
        /// <summary>
        /// Call type USSD.
        /// </summary>
        Ussd = 14,
        /// <summary>
        /// Call type is HDVideo Land.
        /// </summary>
        HdVideoLand = 15,
        /// <summary>
        /// Call type is E911 - Emergency Call.
        /// </summary>
        E911 = 20,
        /// <summary>
        /// Call type is Audio conference.
        /// </summary>
        AudioConference = 21,
        /// <summary>
        /// Call type is E911 Emergency video call.
        /// </summary>
        E911Video = 22,
        /// <summary>
        /// Call type is E911 Emergency video call HD.
        /// </summary>
        E911VideoHd = 23,
        /// <summary>
        /// Call type is E911 Emergency video call HD Land.
        /// </summary>
        E911VideoHdLand = 24,
        /// <summary>
        /// Call type is E911 Emergency video call Land.
        /// </summary>
        E911VideoLand = 25,
        /// <summary>
        /// Call type is E911 Emergency video call HD QVGA Land.
        /// </summary>
        E911VideoHdQvgaLand = 26,
        /// <summary>
        /// Call type is CIF Video Call.
        /// </summary>
        CifVideo = 27,
        /// <summary>
        /// Call type is HD 720 video call.
        /// </summary>
        Hd720Video = 28,
        /// <summary>
        /// Call type is E911 video hold call.
        /// </summary>
        VideoHold = 29,
        /// <summary>
        /// Call type is switch VOIP to VT call.
        /// </summary>
        VoipToVtInProgress = 30
    }

    /// <summary>
    /// Enumeration for the emergency call category type.
    /// </summary>
    public enum EmergencyType
    {
        /// <summary>
        /// Default case
        /// </summary>
        Default = 0x00,
        /// <summary>
        /// Police emergency
        /// </summary>
        Police = 0x01,
        /// <summary>
        /// Ambulance emergency
        /// </summary>
        Ambulance = 0x02,
        /// <summary>
        /// Firebrigade emergency
        /// </summary>
        FireBrigade = 0x04,
        /// <summary>
        /// Marineguard emergency
        /// </summary>
        MarineGuard = 0x08,
        /// <summary>
        /// Mountain rescue emergency
        /// </summary>
        MountainRescue = 0x10,
        /// <summary>
        /// Manual emergency call
        /// </summary>
        ManualECall = 0x20,
        /// <summary>
        /// Automatic emergency call
        /// </summary>
        AutoECall = 0x40,
        /// <summary>
        /// Unspecified emergency
        /// </summary>
        None = 0xff
    }

    /// <summary>
    /// Enumeration for the call answer type.
    /// </summary>
    public enum CallAnswerType
    {
        /// <summary>
        /// Answer an incoming call when there are no current active calls.
        /// </summary>
        Accept,
        /// <summary>
        /// Reject the incoming call.
        /// </summary>
        Reject,
        /// <summary>
        /// Release current active call and accept the waiting call.
        /// </summary>
        Replace,
        /// <summary>
        /// Hold the current active call, and accept the waiting call.
        /// </summary>
        HoldAndAccept
    }

    /// <summary>
    /// Enumeration for the call end type.
    /// </summary>
    public enum CallEndType
    {
        /// <summary>
        /// End specific call.
        /// </summary>
        End,
        /// <summary>
        /// End all calls.
        /// </summary>
        EndAll,
        /// <summary>
        /// End all active calls.
        /// </summary>
        ActiveAll,
        /// <summary>
        /// End all held calls.
        /// </summary>
        HoldAll
    }

    /// <summary>
    /// Enumeration for the onlength to send DTMF.
    /// </summary>
    public enum CallDtmfPulseWidth
    {
        /// <summary>
        /// 95 ms.
        /// </summary>
        OnLength95ms,
        /// <summary>
        /// 150 ms.
        /// </summary>
        OnLength150ms,
        /// <summary>
        /// 200 ms.
        /// </summary>
        OnLength200ms,
        /// <summary>
        /// 250 ms.
        /// </summary>
        OnLength250ms,
        /// <summary>
        /// 300 ms.
        /// </summary>
        OnLength300ms,
        /// <summary>
        /// 350 ms.
        /// </summary>
        OnLength350ms,
        /// <summary>
        /// Sms.
        /// </summary>
        OnLengthSms
    }

    /// <summary>
    /// Enumeration for the offlength to send DTMF.
    /// </summary>
    public enum CallDtmfDigitInterval
    {
        /// <summary>
        /// 60 ms.
        /// </summary>
        OffLength60ms,
        /// <summary>
        /// 100 ms.
        /// </summary>
        OffLength100ms,
        /// <summary>
        /// 150 ms.
        /// </summary>
        OffLength150ms,
        /// <summary>
        /// 200 ms.
        /// </summary>
        OffLength200ms
    }

    /// <summary>
    /// Enumeration for call states.
    /// </summary>
    public enum CallState
    {
        /// <summary>
        /// Idle state - i.e. no call.
        /// </summary>
        Idle,
        /// <summary>
        /// Connected and conversation state.
        /// </summary>
        Active,
        /// <summary>
        /// Held State.
        /// </summary>
        Held,
        /// <summary>
        /// Dialing state.
        /// </summary>
        Dialing,
        /// <summary>
        /// Alerting state.
        /// </summary>
        Alert,
        /// <summary>
        /// Incoming state.
        /// </summary>
        Incoming,
        /// <summary>
        /// Answered state, and waiting for connected indication event.
        /// </summary>
        Waiting,
        /// <summary>
        /// Unknown state.
        /// </summary>
        Unknown
    }

    /// <summary>
    /// Enumeration for call sound device type.
    /// </summary>
    public enum SoundDevice
    {
        /// <summary>
        /// Device type receiver.
        /// </summary>
        Receiver,
        /// <summary>
        /// Device type speaker.
        /// </summary>
        Speaker,
        /// <summary>
        /// Device type handsfree.
        /// </summary>
        HandsFree,
        /// <summary>
        /// Device type headset.
        /// </summary>
        Headset,
        /// <summary>
        /// Device type bluetooth.
        /// </summary>
        Bluetooth,
        /// <summary>
        /// Device type external.
        /// </summary>
        External
    }

    /// <summary>
    /// Enumeration for call sound type.
    /// </summary>
    public enum SoundType
    {
        /// <summary>
        /// Sound type voice.
        /// </summary>
        Voice,
        /// <summary>
        /// Sound type keytone.
        /// </summary>
        Keytone,
        /// <summary>
        /// Sound type bell.
        /// </summary>
        Bell,
        /// <summary>
        /// Sound type message
        /// </summary>
        Message,
        /// <summary>
        /// Sound type alarm
        /// </summary>
        Alarm,
        /// <summary>
        /// Sound type PDA miscellaneous.
        /// </summary>
        PDAMisc
    }

    /// <summary>
    /// Enumeration for call sound volume level.
    /// </summary>
    public enum SoundVolume
    {
        /// <summary>
        /// Sound is mute.
        /// </summary>
        Mute = 0x00,
        /// <summary>
        /// Volume level is 1.
        /// </summary>
        Level1 = 0x01,
        /// <summary>
        /// Volume level is 2.
        /// </summary>
        Level2 = 0x02,
        /// <summary>
        /// Volume level is 3.
        /// </summary>
        Level3 = 0x03,
        /// <summary>
        /// Volume level is 4.
        /// </summary>
        Level4 = 0x04,
        /// <summary>
        /// Volume level is 5.
        /// </summary>
        Level5 = 0x05,
        /// <summary>
        /// Volume level is 6.
        /// </summary>
        Level6 = 0x06,
        /// <summary>
        /// Volume level is 7.
        /// </summary>
        Level7 = 0x07,
        /// <summary>
        /// Volume level is 8.
        /// </summary>
        Level8 = 0x08,
        /// <summary>
        /// Volume level is 9.
        /// </summary>
        Level9 = 0x09
    }

    /// <summary>
    /// Enumeration for call extra volume.
    /// </summary>
    public enum ExtraVolume
    {
        /// <summary>
        /// Off.
        /// </summary>
        Off,
        /// <summary>
        /// On.
        /// </summary>
        On
    }

    /// <summary>
    /// Enumeration for call sound mute status.
    /// </summary>
    public enum SoundMuteStatus
    {
        /// <summary>
        /// Off.
        /// </summary>
        MuteOff,
        /// <summary>
        /// On.
        /// </summary>
        MuteOn
    }

    /// <summary>
    /// Enumeration for call sound mute path.
    /// </summary>
    public enum SoundMutePath
    {
        /// <summary>
        /// Transmit.
        /// </summary>
        TX,
        /// <summary>
        /// Receiver.
        /// </summary>
        RX,
        /// <summary>
        /// All.
        /// </summary>
        All
    }
}
