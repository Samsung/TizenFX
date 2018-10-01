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
    /// Enumeration for the SIM card status.
    /// </summary>
    public enum SimCardStatus
    {
        /// <summary>
        /// Bad card / On the fly SIM gone bad.
        /// </summary>
        Error = 0x00,
        /// <summary>
        /// Card not present.
        /// </summary>
        NotPresent = 0x01,
        /// <summary>
        /// SIM is in the Initializing state.
        /// </summary>
        Initializing = 0x02,
        /// <summary>
        /// SIM Initialization ok.
        /// </summary>
        InitCompleted = 0x03,
        /// <summary>
        /// PIN  required state.
        /// </summary>
        PinRequired = 0x04,
        /// <summary>
        /// PUK required state.
        /// </summary>
        PukRequired = 0x05,
        /// <summary>
        /// PIN/PUK blocked(permanently blocked- All the attempts for PIN/PUK failed).
        /// </summary>
        Blocked = 0x06,
        /// <summary>
        /// Network Control Key required state.
        /// </summary>
        NckRequired = 0x07,
        /// <summary>
        /// Network Subset Control Key required state.
        /// </summary>
        NsckRequired = 0x08,
        /// <summary>
        /// Service Provider Control Key required state.
        /// </summary>
        SpckRequired = 0x09,
        /// <summary>
        /// Corporate Control Key required state.
        /// </summary>
        CckRequired = 0x0a,
        /// <summary>
        /// Card removed.
        /// </summary>
        Removed = 0x0b,
        /// <summary>
        /// PH-SIM (phone-SIM) locked state.
        /// </summary>
        LockRequired = 0x0c,
        /// <summary>
        /// Runtime SIM card error.
        /// </summary>
        Crashed = 0x0d,
        /// <summary>
        /// SIM card Powered OFF.
        /// </summary>
        PowerOff = 0x0e,
        /// <summary>
        /// Unknown status. It can be the initial status.
        /// </summary>
        Unknown = 0xff
    }

    /// <summary>
    /// Enumeration for the SIM card type.
    /// </summary>
    public enum SimCardType
    {
        /// <summary>
        /// Unknown card.
        /// </summary>
        Unknown,
        /// <summary>
        /// SIM(GSM) card.
        /// </summary>
        Gsm,
        /// <summary>
        /// USIM card.
        /// </summary>
        Usim,
        /// <summary>
        /// CDMA card.
        /// </summary>
        Ruim,
        /// <summary>
        /// CDMA NV SIM.
        /// </summary>
        Nvsim,
        /// <summary>
        /// IMS card.
        /// </summary>
        Ims
    }

    /// <summary>
    /// Enumeration for the language preference code.
    /// </summary>
    public enum SimLanguagePreference
    {
        /// <summary>
        /// German.
        /// </summary>
        German = 0x00,
        /// <summary>
        /// English.
        /// </summary>
        English = 0x01,
        /// <summary>
        /// Italian.
        /// </summary>
        Italian = 0x02,
        /// <summary>
        /// French.
        /// </summary>
        French = 0x03,
        /// <summary>
        /// Spanish.
        /// </summary>
        Spanish = 0x04,
        /// <summary>
        /// Dutch.
        /// </summary>
        Dutch = 0x05,
        /// <summary>
        /// Swedish.
        /// </summary>
        Swedish = 0x06,
        /// <summary>
        /// Danish.
        /// </summary>
        Danish = 0x07,
        /// <summary>
        /// Portuguese.
        /// </summary>
        Portuguese = 0x08,
        /// <summary>
        /// Finnish.
        /// </summary>
        Finnish = 0x09,
        /// <summary>
        /// Norwegian.
        /// </summary>
        Norwegian = 0x0A,
        /// <summary>
        /// Greek.
        /// </summary>
        Greek = 0x0B,
        /// <summary>
        /// Turkish.
        /// </summary>
        Turkish = 0x0C,
        /// <summary>
        /// Hungarian.
        /// </summary>
        Hungarian = 0x0D,
        /// <summary>
        /// Polish.
        /// </summary>
        Polish = 0x0E,
        /// <summary>
        /// Korean.
        /// </summary>
        Korean = 0x0F,
        /// <summary>
        /// Chinese.
        /// </summary>
        Chinese = 0x10,
        /// <summary>
        /// Russian.
        /// </summary>
        Russian = 0x11,
        /// <summary>
        /// Japanese.
        /// </summary>
        Japanese = 0x12,
        /// <summary>
        /// Unspecified.
        /// </summary>
        Unspecified = 0xFF
    }

    /// <summary>
    /// Enumeration for the security lock type.
    /// </summary>
    public enum SimLockType
    {
        /// <summary>
        /// PH-SIM (phone-SIM) locked. Lock Phone to SIM/UICC card.
        /// </summary>
        PS = 0x01,
        /// <summary>
        /// PH-FSIM (phone-first-SIM) Lock Phone to the very first inserted SIM/UICC card.
        /// </summary>
        PF,
        /// <summary>
        /// SIM Lock (PIN, PIN2, PUK, PUK2) Lock SIM/UICC card.
        /// </summary>
        SC,
        /// <summary>
        /// FDN - SIM card or active application in the UICC (GSM or USIM).
        /// </summary>
        FD,
        /// <summary>
        /// Network Personalization.
        /// </summary>
        PN,
        /// <summary>
        /// Network subset Personalization.
        /// </summary>
        PU,
        /// <summary>
        /// Service Provider Personalization.
        /// </summary>
        PP,
        /// <summary>
        /// Corporate Personalization.
        /// </summary>
        PC
    }

    /// <summary>
    /// Enumeration for the power state of the SIM.
    /// </summary>
    public enum SimPowerState
    {
        /// <summary>
        /// Off state.
        /// </summary>
        Off = 0x00,
        /// <summary>
        /// On state.
        /// </summary>
        On = 0x01,
        /// <summary>
        /// Unspecified state.
        /// </summary>
        Unspecified = 0xFF
    }
    /// <summary>
    /// Enumeration for the file ID.
    /// </summary>
    public enum SimFileId
    {
        /// <summary>
        /// Root Directory for the USIM.
        /// </summary>
        Dir = 0x2F00,
        /// <summary>
        /// The ICC Identification file.
        /// </summary>
        IccId = 0x2FE2,
        /// <summary>
        /// The IMSI file.
        /// </summary>
        Imsi = 0x6F07,
        /// <summary>
        /// The SIM Service Table file.
        /// </summary>
        Sst = 0x6F38,
        /// <summary>
        /// The Enabled Service Table file.
        /// </summary>
        Est = 0x6F56,
        /// <summary>
        /// The OPLMN List file.
        /// </summary>
        OplmnAct = 0x6F61,
        /// <summary>
        /// The Group Identifier Level 1.
        /// </summary>
        Gid1 = 0x6F3E,
        /// <summary>
        /// The Group Identifier Level 2.
        /// </summary>
        Gid2 = 0x6F3F,
        /// <summary>
        /// The Extended Language Preference file.
        /// </summary>
        Elp = 0x2F05,
        /// <summary>
        /// SIM: Language preference.
        /// </summary>
        Lp = 0x6F05,
        /// <summary>
        /// The Emergency Call Codes.
        /// </summary>
        Ecc = 0x6FB7,
        /// <summary>
        /// The Service Provider Name.
        /// </summary>
        Spn = 0x6F46,
        /// <summary>
        /// The Service provider display information.
        /// </summary>
        Spdi = 0x6FCD,
        /// <summary>
        /// The PLMN Network Name File.
        /// </summary>
        Pnn = 0x6FC5,
        /// <summary>
        /// The Operator PLMN List File.
        /// </summary>
        Opl = 0x6FC6,
        /// <summary>
        /// MSISDN.
        /// </summary>
        Msisdn = 0x6F40,
        /// <summary>
        /// Short Messages file.
        /// </summary>
        Sms = 0x6F3C,
        /// <summary>
        /// SMS Parameter.
        /// </summary>
        Smsp = 0x6F42,
        /// <summary>
        /// SMS Status.
        /// </summary>
        Smss = 0x6F43,
        /// <summary>
        /// Cell Broadcast Message Identifier.
        /// </summary>
        Cbmi = 0x6F45,
        /// <summary>
        /// SIM Mail Box Dialing Number file.
        /// </summary>
        Mbdn = 0x6FC7,
        /// <summary>
        /// Mailbox Identifier - linear fixed.
        /// </summary>
        UsimMbi = 0x6FC9,
        /// <summary>
        /// Message Waiting Indication Status - linear fixed.
        /// </summary>
        UsimMwis = 0x6FCA,
        /// <summary>
        /// Call forward indication status - linear fixed.
        /// </summary>
        UsimCfis = 0x6FCB,
        /// <summary>
        /// CPHS voice MSG waiting indication.
        /// </summary>
        CphsVoiceMsgWaiting = 0x6F11,
        /// <summary>
        /// CPHS service string table.
        /// </summary>
        CphsServiceStringTable = 0x6F12,
        /// <summary>
        /// CPHS call forward flags.
        /// </summary>
        CphsCallForwardFlags = 0x6F13,
        /// <summary>
        /// CPHS operator name string.
        /// </summary>
        CphsOperatorNameString = 0x6F14,
        /// <summary>
        /// CPHS customer service profile.
        /// </summary>
        CphsCustomerServiceProfile = 0x6F15,
        /// <summary>
        /// CPHS information.
        /// </summary>
        CphsInfo = 0x6F16,
        /// <summary>
        /// CPHS mail box numbers.
        /// </summary>
        CphsMailboxNumbers = 0x6F17,
        /// <summary>
        /// CPHS operator name short form string.
        /// </summary>
        CphsOperatorNameShortFormString = 0x6F18,
        /// <summary>
        /// CPHS information numbers.
        /// </summary>
        CphsInformationNumbers = 0x6F19,
        /// <summary>
        /// CPHS Dynamics flags.
        /// </summary>
        CphsDynamicFlags = 0x6F9F,
        /// <summary>
        /// CPHS Dynamics2 flags.
        /// </summary>
        CphsDynamic2Flag = 0x6F92,
        /// <summary>
        /// CPHS CSP2.
        /// </summary>
        CphsCustomerServiceProfileLine2 = 0x6F98,
        /// <summary>
        /// Invalid file.
        /// </summary>
        Invalid = 0xFFFF,
        /// <summary>
        /// Element to indicate an unknown file.
        /// </summary>
        Others
    }

    /// <summary>
    /// Enumeration for the SIM number type.
    /// </summary>
    public enum SimTypeOfNumber
    {
        /// <summary>
        /// Unknown.
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// International number.
        /// </summary>
        International,
        /// <summary>
        /// National number.
        /// </summary>
        National,
        /// <summary>
        /// Network specific number.
        /// </summary>
        NetworkSpecific,
        /// <summary>
        /// Subscriber number.
        /// </summary>
        DedicatedAccess,
        /// <summary>
        /// Alphanumeric, GSM 7-bit default alphabet.
        /// </summary>
        AlphaNumeric,
        /// <summary>
        /// Abbreviated number
        /// </summary>
        AbbreviatedNumber,
        /// <summary>
        /// Reserved for extension.
        /// </summary>
        ReservedForExt
    }

    /// <summary>
    /// Enumeration for the numbering plan identifier.
    /// </summary>
    public enum SimNumberPlanIdentity
    {
        /// <summary>
        /// Unknown.
        /// </summary>
        Unknown,
        /// <summary>
        /// ISDN/Telephone numbering plan.
        /// </summary>
        IsdnTelephone,
        /// <summary>
        /// Data numbering plan
        /// </summary>
        Data,
        /// <summary>
        /// Telex numbering plan
        /// </summary>
        Telex,
        /// <summary>
        /// Service Center Specific plan.
        /// </summary>
        ServiceCenterSpecific,
        /// <summary>
        /// Service Center Specific plan 2.
        /// </summary>
        ServiceCenterSpecific2,
        /// <summary>
        /// National numbering plan.
        /// </summary>
        National,
        /// <summary>
        /// Private numbering plan.
        /// </summary>
        Private,
        /// <summary>
        /// ERMES numbering plan.
        /// </summary>
        Ermes,
        /// <summary>
        /// Reserved for extension.
        /// </summary>
        ReservedForExt
    }

    /// <summary>
    /// Enumeration for the emergency service type.
    /// </summary>
    public enum SimEccEmergencyServiceType
    {
        /// <summary>
        /// Police.
        /// </summary>
        Police = 0x01,
        /// <summary>
        /// Ambulance.
        /// </summary>
        Ambulance = 0x02,
        /// <summary>
        /// Fire brigade.
        /// </summary>
        FireBrigade = 0x04,
        /// <summary>
        /// Marine guard.
        /// </summary>
        MarineGuard = 0x08,
        /// <summary>
        /// Mountain rescue.
        /// </summary>
        MountainRescue = 0x10,
        /// <summary>
        /// Spare.
        /// </summary>
        Spare = 0x00
    }

    /// <summary>
    /// Enumeration for the SIM app type.
    /// </summary>
    public enum SimAppType
    {
        /// <summary>
        /// SIM application.
        /// </summary>
        Sim = 0x01,
        /// <summary>
        /// USIM application.
        /// </summary>
        Usim = 0x02,
        /// <summary>
        /// CSIM application.
        /// </summary>
        Csim = 0x04,
        /// <summary>
        /// ISIM application.
        /// </summary>
        Isim = 0x08
    }

    /// <summary>
    /// Enumeration for the SIM access result from the lower layers.
    /// </summary>
    public enum SimAccessResult
    {
        /// <summary>
        /// Access to file is successful.
        /// </summary>
        Success,
        /// <summary>
        /// SIM card error.
        /// </summary>
        CardError,
        /// <summary>
        /// File not found.
        /// </summary>
        FileNotFound,
        /// <summary>
        /// Access condition is not fulfilled.
        /// </summary>
        ConditionNotSatisfied,
        /// <summary>
        /// Access failed.
        /// </summary>
        Failed
    }

    /// <summary>
    /// Enumeration for the mailbox type.
    /// </summary>
    public enum SimMailboxType
    {
        /// <summary>
        /// Voicemail.
        /// </summary>
        Voice = 0x01,
        /// <summary>
        /// Fax.
        /// </summary>
        Fax = 0x02,
        /// <summary>
        /// Email.
        /// </summary>
        Email = 0x03,
        /// <summary>
        /// Other.
        /// </summary>
        Other = 0x04,
        /// <summary>
        /// Videomail.
        /// </summary>
        Video = 0x05,
        /// <summary>
        /// Data.
        /// </summary>
        Data = 0x06
    }

    /// <summary>
    /// Enumeration for the current CPHS phase of the SIM card.
    /// </summary>
    public enum SimCphsPhaseType
    {
        /// <summary>
        /// Phase 1.
        /// </summary>
        Phase1 = 0x01,
        /// <summary>
        /// Phase 2.
        /// </summary>
        Phase2 = 0x02,
        /// <summary>
        /// RFU.
        /// </summary>
        Rfu = 0xff
    }

    /// <summary>
    /// Enumeration for CDMA service table.
    /// </summary>
    public enum SimCdmaServiceTable
    {
        /// <summary>
        /// CDMA service table.
        /// </summary>
        Cdma = 0,
        /// <summary>
        /// CSIM service table.
        /// </summary>
        Csim,
        /// <summary>
        /// MAX value.
        /// </summary>
        Max
    }

    /// <summary>
    /// Enumeration for the SIM Authentication type.
    /// </summary>
    public enum SimAuthenticationType
    {
        /// <summary>
        /// IMS Authentication.
        /// </summary>
        Ims = 0x00,
        /// <summary>
        /// GSM Authentication.
        /// </summary>
        Gsm,
        /// <summary>
        /// 3G Authentication.
        /// </summary>
        Auth3G,
        /// <summary>
        /// CDMA CAVE Authentication.
        /// </summary>
        RuimCave,
        /// <summary>
        /// CDMA CHAP Authentication.
        /// </summary>
        RuimChap,
        /// <summary>
        /// CDMA MNHA Authentication.
        /// </summary>
        RuimMnha,
        /// <summary>
        /// CDMA MIPRRQ Authentication.
        /// </summary>
        RuimMiprrq,
        /// <summary>
        /// CDMA MNAAA Authentication.
        /// </summary>
        RuimMnaaa,
        /// <summary>
        /// CDMA HRPD Authentication.
        /// </summary>
        RuimHrpd,
        /// <summary>
        /// MAX value.
        /// </summary>
        Max
    }

    /// <summary>
    /// Enumeration for the SIM Authentication result.
    /// </summary>
    public enum SimAuthenticationResult
    {
        /// <summary>
        /// Status - no error.
        /// </summary>
        NoError = 0x00,
        /// <summary>
        /// Status - can't perform authentication.
        /// </summary>
        CannotPerform,
        /// <summary>
        /// Status - skip authentication response.
        /// </summary>
        SkipResponse,
        /// <summary>
        /// Status - MAK(Multiple Activation Key) code failure.
        /// </summary>
        MakCodeFailure,
        /// <summary>
        /// Status - SQN(SeQuenceNumber) failure.
        /// </summary>
        SqnFailure,
        /// <summary>
        /// Status - synch failure.
        /// </summary>
        SynchFailure,
        /// <summary>
        /// Status - unsupported context.
        /// </summary>
        UnsupportedContext,
        /// <summary>
        /// Status - default error.
        /// </summary>
        Error,
        /// <summary>
        /// MAX value.
        /// </summary>
        Max
    }

    /// <summary>
    /// Enumeration for the PIN type.
    /// </summary>
    public enum SimPinType
    {
        /// <summary>
        /// PIN 1 code.
        /// </summary>
        Pin1 = 0x00,
        /// <summary>
        /// PIN 2 code.
        /// </summary>
        Pin2 = 0x01,
        /// <summary>
        /// PUK 1 code.
        /// </summary>
        Puk1 = 0x02,
        /// <summary>
        /// PUK 2 code.
        /// </summary>
        Puk2 = 0x03,
        /// <summary>
        /// Universal PIN - Unused now.
        /// </summary>
        Upin = 0x04,
        /// <summary>
        /// Administrator - Unused now.
        /// </summary>
        Adm = 0x05,
        /// <summary>
        /// SIM Lock code.
        /// </summary>
        Sim = 0x06
    }

    /// <summary>
    /// Enumeration for the PIN status.
    /// </summary>
    public enum SimFacilityStatus
    {
        /// <summary>
        /// Facility disabled.
        /// </summary>
        Disabled = 0x00,
        /// <summary>
        /// Facility enabled.
        /// </summary>
        Enabled = 0x01,
        /// <summary>
        /// Facility unknown.
        /// </summary>
        Unknown = 0xFF
    }

    /// <summary>
    /// Enumeration for the security lock key information.
    /// </summary>
    public enum SimLockStatus
    {
        /// <summary>
        /// Key not needed.
        /// </summary>
        NotNeeded = 0x00,
        /// <summary>
        /// PIN required.
        /// </summary>
        Pin = 0x01,
        /// <summary>
        /// PUK required.
        /// </summary>
        Puk = 0x02,
        /// <summary>
        /// PIN2 required.
        /// </summary>
        Pin2 = 0x03,
        /// <summary>
        /// PUK2 required.
        /// </summary>
        Puk2 = 0x04,
        /// <summary>
        /// Permanent block SIM.
        /// </summary>
        PermanentBlocked = 0x05
    }

    /// <summary>
    /// Enumeration for P-CSCF type.
    /// </summary>
    public enum SimPcscfType
    {
        /// <summary>
        /// Fully Qualified Domain Name.
        /// </summary>
        Fqdn,
        /// <summary>
        /// IPv4.
        /// </summary>
        IPv4,
        /// <summary>
        /// IPv6.
        /// </summary>
        IPv6
    }

    /// <summary>
    /// Enumeration for the SIM power set result from the lower layers.
    /// </summary>
    public enum SimPowerSetResult
    {
        /// <summary>
        /// Power Set is successful.
        /// </summary>
        Success,
        /// <summary>
        /// Power Set failure.
        /// </summary>
        Failure
    }

    /// <summary>
    /// Enumeration for the list of IST services in the ISIM Service Table (ISIM).
    /// </summary>
    public enum SimIsimService
    {
        /// <summary>
        /// P-CSCF address.
        /// </summary>
        PcscfAddr = 0,
        /// <summary>
        /// Generic Bootstrapping Architecture.
        /// </summary>
        Gba,
        /// <summary>
        /// HTTP Digest.
        /// </summary>
        HttpDigest,
        /// <summary>
        /// GBA-based Local Key Establishment Mechanism.
        /// </summary>
        GbaLocalKey,
        /// <summary>
        /// Support of P-CSCF discovery for IMS Local Break Out.
        /// </summary>
        PcscfLocalBreakOut,
        /// <summary>
        /// Short Message Storage.
        /// </summary>
        Sms,
        /// <summary>
        /// Short Message Status Reports.
        /// </summary>
        Smsr,
        /// <summary>
        /// Support for SM-over-IP including data download via SMS-PP as defined in TS 31.111 [31]
        /// </summary>
        SmOverIP,
        /// <summary>
        /// Communication Control for IMS by ISIM.
        /// </summary>
        CommunicationControl = 8,
        /// <summary>
        /// Support of UICC access to IMS.
        /// </summary>
        AccessToIms,
        /// <summary>
        /// URI support by UICC.
        /// </summary>
        UriSupport
    }

    /// <summary>
    /// Enumeration for the list of SST services in the SIM Service Table (GSM).
    /// </summary>
    public enum SimSstService
    {
        /// <summary>
        /// CHV1 disable function.
        /// </summary>
        Chv1DisableFunc = 0,
        /// <summary>
        /// Abbreviated Dialing number.
        /// </summary>
        Adn,
        /// <summary>
        /// Fixed Dialing number.
        /// </summary>
        Fdn,
        /// <summary>
        /// Short message storage.
        /// </summary>
        Sms,
        /// <summary>
        /// Advice of charge.
        /// </summary>
        Aoc,
        /// <summary>
        /// Capability configuration parameters.
        /// </summary>
        Ccp,
        /// <summary>
        /// PLMN selector.
        /// </summary>
        PlmnSelector,
        /// <summary>
        /// RFU.
        /// </summary>
        Rfu1,
        /// <summary>
        /// MSISDN.
        /// </summary>
        Msisdn = 8,
        /// <summary>
        /// Extension 1.
        /// </summary>
        Ext1,
        /// <summary>
        /// Extension 2.
        /// </summary>
        Ext2,
        /// <summary>
        /// SMS parameters.
        /// </summary>
        SmsParams,
        /// <summary>
        /// Last number dialed.
        /// </summary>
        Lnd,
        /// <summary>
        /// Cell broadcast message identifier.
        /// </summary>
        CellBroadcastMsgId,
        /// <summary>
        /// Group identifier level 1.
        /// </summary>
        GidLv1,
        /// <summary>
        /// Group identifier level 2.
        /// </summary>
        GidLv2,
        /// <summary>
        /// Service provider name.
        /// </summary>
        Spn = 16,
        /// <summary>
        /// Service Dialing number.
        /// </summary>
        Sdn,
        /// <summary>
        /// Extension3.
        /// </summary>
        Ext3,
        /// <summary>
        /// RFU.
        /// </summary>
        RFu2,
        /// <summary>
        /// VGCS group identifier (EF-VGCS, EF-VGCSS).
        /// </summary>
        VgcsGidList,
        /// <summary>
        /// VBS group identifier (EF-VBS, EF-VBSS).
        /// </summary>
        VbsGidList,
        /// <summary>
        /// Enhanced multi-level precedence and pre-emption service.
        /// </summary>
        EnhancedMultiLvPrecedencePreemptionSrvc,
        /// <summary>
        /// Automatic answer for EMLPP.
        /// </summary>
        AutoAnswerForEmlpp,
        /// <summary>
        /// Data download via SMS-CB.
        /// </summary>
        DataDownloadViaSmsCb = 24,
        /// <summary>
        /// Data download via SMS-PP.
        /// </summary>
        DataDownloadViaSmsPp,
        /// <summary>
        /// Menu selection.
        /// </summary>
        MenuSelection,
        /// <summary>
        /// Call control.
        /// </summary>
        CallCtrl,
        /// <summary>
        /// Proactive SIM command.
        /// </summary>
        ProactiveSim,
        /// <summary>
        /// Cell broadcast message identifier ranges.
        /// </summary>
        CellBroadcastMsgIdRanges,
        /// <summary>
        /// Barred Dialing numbers.
        /// </summary>
        Bdn,
        /// <summary>
        /// Extension 4.
        /// </summary>
        Ext4,
        /// <summary>
        /// De-personalization control keys.
        /// </summary>
        DepersonalizationCtrlKeys = 32,
        /// <summary>
        /// Co-operative network list.
        /// </summary>
        CooperativeNetworkList,
        /// <summary>
        /// Short message status reports.
        /// </summary>
        SmsStatusReports,
        /// <summary>
        /// Network's indication of alerting in the MS (NIA).
        /// </summary>
        Nia,
        /// <summary>
        /// Mobile-originated short message control by SIM.
        /// </summary>
        MoSmsCtrlBySim,
        /// <summary>
        /// GPRS.
        /// </summary>
        Gprs,
        /// <summary>
        /// Image.
        /// </summary>
        Img,
        /// <summary>
        /// Support of local service area.
        /// </summary>
        Solsa,
        /// <summary>
        /// USSD string data object supported in call control.
        /// </summary>
        UssdStrDataObjectSupportedInCallCtrl = 40,
        /// <summary>
        /// Run at COMMAND command.
        /// </summary>
        RunAtCmdCmd,
        /// <summary>
        /// User controlled PLMN selector with Access technology.
        /// </summary>
        UserCtrledPlmnSelectorWact,
        /// <summary>
        /// Operator controlled PLMN selector with Access technology.
        /// </summary>
        OperatorCtrledPlmnSelectorWact,
        /// <summary>
        /// HPLMN selector with access technology.
        /// </summary>
        HplmnSelectorWact,
        /// <summary>
        /// CPBCCH information.
        /// </summary>
        CpbcchInfo,
        /// <summary>
        /// Investigation scan.
        /// </summary>
        InvestigationScan,
        /// <summary>
        /// Extended capability configuration parameters.
        /// </summary>
        ExtendedCapaConfParams,
        /// <summary>
        /// MExE.
        /// </summary>
        Mexe = 48,
        /// <summary>
        /// RPLMN last used access technology.
        /// </summary>
        RplmnLastUsedAccessTech,
        /// <summary>
        /// PLMN Network Name.
        /// </summary>
        PlmnNetworkName,
        /// <summary>
        /// Operator PLMN List.
        /// </summary>
        OperatorPlmnList,
        /// <summary>
        /// Mailbox Dialling Numbers.
        /// </summary>
        Mbdn,
        /// <summary>
        /// Message Waiting Indication Status.
        /// </summary>
        Mwis,
        /// <summary>
        /// Call Forwarding Indication Status.
        /// </summary>
        Cfis,
        /// <summary>
        /// Service Provider Display Information.
        /// </summary>
        Spdi
    }

    /// <summary>
    /// Enumeration for the list of UST services in the SIM Service Table (USIM).
    /// </summary>
    public enum SimUstService
    {
        /// <summary>
        /// Local phone book.
        /// </summary>
        LocalPb = 0,
        /// <summary>
        /// Fixed Dialing number.
        /// </summary>
        Fdn,
        /// <summary>
        /// Extension 2.
        /// </summary>
        Ext2,
        /// <summary>
        /// Service Dialing number.
        /// </summary>
        Sdn,
        /// <summary>
        /// Extension 3.
        /// </summary>
        Ext3,
        /// <summary>
        /// Barred Dialing numbers.
        /// </summary>
        Bdn,
        /// <summary>
        /// Extension 4.
        /// </summary>
        Ext4,
        /// <summary>
        /// Outgoing call information.
        /// </summary>
        OutgoingCallInfo,
        /// <summary>
        /// Incoming call information.
        /// </summary>
        IncomingCallInfo = 8,
        /// <summary>
        /// Short message storage.
        /// </summary>
        Sms,
        /// <summary>
        /// Short message status reports.
        /// </summary>
        SmsStatusReports,
        /// <summary>
        /// SMS parameters.
        /// </summary>
        SmsParams,
        /// <summary>
        /// Advice of charge.
        /// </summary>
        Aoc,
        /// <summary>
        /// Capability configuration parameters.
        /// </summary>
        Ccp,
        /// <summary>
        /// Cell broadcast message identifier.
        /// </summary>
        CellBroadcastMsgId,
        /// <summary>
        /// Cell broadcast message identifier ranges.
        /// </summary>
        CellBroadcastMsgIdRanges,
        /// <summary>
        /// Group identifier level 1.
        /// </summary>
        GidLv1 = 16,
        /// <summary>
        /// Group identifier level 2.
        /// </summary>
        GidLv2,
        /// <summary>
        /// Service provider name.
        /// </summary>
        Spn,
        /// <summary>
        /// User controlled PLMN selector with Access technology.
        /// </summary>
        UserCtrledPlmnSelectorWact,
        /// <summary>
        /// MSISDN.
        /// </summary>
        Msisdn,
        /// <summary>
        /// Image.
        /// </summary>
        Img,
        /// <summary>
        /// Support of local service area.
        /// </summary>
        Solsa,
        /// <summary>
        /// Enhanced multi-level precedence and pre-emption service.
        /// </summary>
        EnhancedMultiLvPrecedencePreemptionSrvc,
        /// <summary>
        /// Automatic answer for EMLPP.
        /// </summary>
        AutoAnswerForEmlpp = 24,
        /// <summary>
        /// RFU.
        /// </summary>
        Rfu1,
        /// <summary>
        /// GSM access.
        /// </summary>
        GsmAccess,
        /// <summary>
        /// Data download via SMS-PP.
        /// </summary>
        DataDownloadViaSmsPp,
        /// <summary>
        /// Data download via SMS-CB.
        /// </summary>
        DataDownloadViaSmsCb,
        /// <summary>
        /// Call control by USIM.
        /// </summary>
        CallCtrl,
        /// <summary>
        /// Mobile-originated short message control by USIM.
        /// </summary>
        MoSmsCtrl,
        /// <summary>
        /// Run at COMMAND command.
        /// </summary>
        RunAtCmdCmd,
        /// <summary>
        /// Shall be set to 1.
        /// </summary>
        ShallBeSetToOne = 32,
        /// <summary>
        /// Enabled service table.
        /// </summary>
        EnabledSrvcTable,
        /// <summary>
        /// APN control list.
        /// </summary>
        Acl,
        /// <summary>
        /// De-personalization control keys.
        /// </summary>
        DepersonalizationCtrlKeys,
        /// <summary>
        /// Co-operative network list.
        /// </summary>
        CooperativeNetworkList,
        /// <summary>
        /// GSM security context.
        /// </summary>
        GsmSecContext,
        /// <summary>
        /// CPBCCH information.
        /// </summary>
        CpbcchInfo,
        /// <summary>
        /// Investigation scan.
        /// </summary>
        InvestigationScan,
        /// <summary>
        /// MExE.
        /// </summary>
        Mexe = 40,
        /// <summary>
        /// Operator controlled PLMN selector with Access technology.
        /// </summary>
        OperatorCtrledPlmnSelectorWact,
        /// <summary>
        /// HPLMN selector with access technology.
        /// </summary>
        HplmnSelectorWact,
        /// <summary>
        /// Extension 5.
        /// </summary>
        Ext5,
        /// <summary>
        /// PLMN Network Name.
        /// </summary>
        PlmnNetworkName,
        /// <summary>
        /// Operator PLMN List.
        /// </summary>
        OperatorPlmnList,
        /// <summary>
        /// Mailbox Dialling Numbers.
        /// </summary>
        Mbdn,
        /// <summary>
        /// Message Waiting Indication Status.
        /// </summary>
        Mwis,
        /// <summary>
        /// Call Forwarding Indication Status.
        /// </summary>
        Cfis = 48,
        /// <summary>
        /// RPLMN last used access technology.
        /// </summary>
        RplmnLastUsedAccessTech,
        /// <summary>
        /// Service Provider Display Information.
        /// </summary>
        Spdi,
        /// <summary>
        /// Multi media messaging service.
        /// </summary>
        Mms,
        /// <summary>
        /// Extension 8.
        /// </summary>
        Ext8,
        /// <summary>
        /// Call control on GPRS by USIM.
        /// </summary>
        CallCtrlOnGprs,
        /// <summary>
        /// MMS user connectivity parameters.
        /// </summary>
        MmsUserConnectivityParams,
        /// <summary>
        /// Network's indication of alerting in the MS (NIA).
        /// </summary>
        Nia,
        /// <summary>
        /// VGCS group identifier List (EF-VGCS, EF-VGCSS).
        /// </summary>
        VgcsGidList = 56,
        /// <summary>
        /// VBS group identifier List (EF-VBS, EF-VBSS).
        /// </summary>
        VbsGidList,
        /// <summary>
        /// Pseudonym.
        /// </summary>
        Pseudonym,
        /// <summary>
        /// User controlled PLMN selector for I-WLAN access.
        /// </summary>
        UserCtrledPlmnSelectorIwlan,
        /// <summary>
        /// Operator controlled PLMN selector for I-WLAN access.
        /// </summary>
        OperatorCtrledPlmnSelectorIwlan,
        /// <summary>
        /// User controlled WSID list.
        /// </summary>
        UserCtrledWsidList,
        /// <summary>
        /// Opertor controlled Wsid list.
        /// </summary>
        OperatorCtrledWsidList,
        /// <summary>
        /// VGCS security.
        /// </summary>
        VgcsSec
    }

    /// <summary>
    /// Enumeration for the list of CST services in the CDMA Service Table.
    /// </summary>
    public enum SimCdmaService
    {
        /// <summary>
        /// CHV Disable Option.
        /// </summary>
        ChvDisable = 0,
        /// <summary>
        /// Abbreviated Dialing number.
        /// </summary>
        Adn,
        /// <summary>
        /// Fixed Dialing number.
        /// </summary>
        Fdn,
        /// <summary>
        /// Short message storage.
        /// </summary>
        Sms,
        /// <summary>
        /// HRPD.
        /// </summary>
        Hrpd,
        /// <summary>
        /// Enhanced Phone Book.
        /// </summary>
        Epb,
        /// <summary>
        /// Multimedia domain.
        /// </summary>
        Mmd,
        /// <summary>
        /// SF_EUIMID- based EUIMID.
        /// </summary>
        Euimid,
        /// <summary>
        /// MEID.
        /// </summary>
        Meid = 8,
        /// <summary>
        /// Extension 1.
        /// </summary>
        Ext1,
        /// <summary>
        /// Extension 2.
        /// </summary>
        Ext2,
        /// <summary>
        /// SMS parameters.
        /// </summary>
        Smsp,
        /// <summary>
        /// Last number dialled.
        /// </summary>
        Lnd,
        /// <summary>
        /// Service Category Program for BC-SMS.
        /// </summary>
        Scp,
        /// <summary>
        /// RFU.
        /// </summary>
        Rfu1,
        /// <summary>
        /// RFU.
        /// </summary>
        Rfu2,
        /// <summary>
        /// CDMA Home Service Provider Name.
        /// </summary>
        Hspn = 16,
        /// <summary>
        /// Service Dialing number.
        /// </summary>
        Sdn,
        /// <summary>
        /// Extension 3.
        /// </summary>
        Ext3,
        /// <summary>
        /// 3GPD-SIP.
        /// </summary>
        St3GpdSip,
        /// <summary>
        /// RFU.
        /// </summary>
        Rfu3,
        /// <summary>
        /// RFU.
        /// </summary>
        Rfu4,
        /// <summary>
        /// RFU.
        /// </summary>
        Rfu5,
        /// <summary>
        /// RFU.
        /// </summary>
        Rfu6,
        /// <summary>
        /// Data download by SMS broadcast.
        /// </summary>
        Ddsmsb = 24,
        /// <summary>
        /// Data download by SMS PP.
        /// </summary>
        Ddsmspp,
        /// <summary>
        /// Menu Selection.
        /// </summary>
        Menu,
        /// <summary>
        /// Call Control.
        /// </summary>
        Callc,
        /// <summary>
        /// Proactive RUIM.
        /// </summary>
        Proactive,
        /// <summary>
        /// AKA.
        /// </summary>
        Aka,
        /// <summary>
        /// RFU.
        /// </summary>
        Rfu7,
        /// <summary>
        /// RFU.
        /// </summary>
        Rfu8,
        /// <summary>
        /// RFU.
        /// </summary>
        Rfu9 = 32,
        /// <summary>
        /// RFU.
        /// </summary>
        Rfu10,
        /// <summary>
        /// RFU.
        /// </summary>
        Rfu11,
        /// <summary>
        /// RFU.
        /// </summary>
        Rfu12,
        /// <summary>
        /// RFU.
        /// </summary>
        Rfu13,
        /// <summary>
        /// 3GPD- MIP.
        /// </summary>
        St3GpdMip,
        /// <summary>
        /// BCMCS.
        /// </summary>
        Bcmcs,
        /// <summary>
        /// Multimedia messaging service.
        /// </summary>
        Mms,
        /// <summary>
        /// Extension 8.
        /// </summary>
        Ext8 = 40,
        /// <summary>
        /// MMS User Connectivity Parameters.
        /// </summary>
        Mmsucp,
        /// <summary>
        /// Application Authentication.
        /// </summary>
        Aa,
        /// <summary>
        /// Group Identifier Level 1.
        /// </summary>
        Gil1,
        /// <summary>
        /// Group Identifier Level 2.
        /// </summary>
        Gil2,
        /// <summary>
        /// Depersonalisation control keys.
        /// </summary>
        Deperso,
        /// <summary>
        /// Co-operative Network List.
        /// </summary>
        Cnl
    }

    /// <summary>
    /// Enumeration for the list of CST services in the CSIM Service Table (CSIM).
    /// </summary>
    public enum SimCsimService
    {
        /// <summary>
        /// Local Phone book.
        /// </summary>
        LocalPhonebook = 0,
        /// <summary>
        /// Fixed Dialing Numbers (FDN).
        /// </summary>
        Fdn,
        /// <summary>
        /// Extension 2.
        /// </summary>
        Ext2,
        /// <summary>
        /// Service Dialing Numbers (SDN).
        /// </summary>
        Sdn,
        /// <summary>
        /// Extension 3.
        /// </summary>
        Ext3,
        /// <summary>
        /// Short Message Storage (SMS).
        /// </summary>
        Sms,
        /// <summary>
        /// Short Message Parameters.
        /// </summary>
        Smsp,
        /// <summary>
        /// HRPD.
        /// </summary>
        Hrpd,
        /// <summary>
        /// Service Category Program for BC-SMS.
        /// </summary>
        Scp = 8,
        /// <summary>
        /// CDMA Home Service Provider Name.
        /// </summary>
        Hspn,
        /// <summary>
        /// Data Download via SMS Broadcast.
        /// </summary>
        DdSmsb,
        /// <summary>
        /// Data Download via SMS-PP.
        /// </summary>
        DdSmsPp,
        /// <summary>
        /// Call Control.
        /// </summary>
        Callc,
        /// <summary>
        /// 3GPD-SIP.
        /// </summary>
        St3GpdSip,
        /// <summary>
        /// 3GPD-MIP.
        /// </summary>
        St3GpdMip,
        /// <summary>
        /// AKA.
        /// </summary>
        Aka,
        /// <summary>
        /// IP-based Location Services (LCS).
        /// </summary>
        IPLcs = 16,
        /// <summary>
        /// BCMCS.
        /// </summary>
        Bcmcs,
        /// <summary>
        /// Multimedia Messaging Service (MMS).
        /// </summary>
        Mms,
        /// <summary>
        /// Extension 8.
        /// </summary>
        Ext8,
        /// <summary>
        /// MMS User Connectivity Parameters.
        /// </summary>
        Mmsucp,
        /// <summary>
        /// Application Authentication.
        /// </summary>
        Aa,
        /// <summary>
        /// Group Identifier Level 1.
        /// </summary>
        Gil1,
        /// <summary>
        /// Group Identifier Level 2.
        /// </summary>
        Gil2,
        /// <summary>
        /// De-Personalization Control Keys.
        /// </summary>
        Deperso = 24,
        /// <summary>
        /// Cooperative Network List.
        /// </summary>
        Cnl,
        /// <summary>
        /// Outgoing Call Information (OCI).
        /// </summary>
        Oci,
        /// <summary>
        /// Incoming Call Information (ICI).
        /// </summary>
        Ici,
        /// <summary>
        /// Extension 5.
        /// </summary>
        Ext5,
        /// <summary>
        /// Multimedia Storage.
        /// </summary>
        MmStorage,
        /// <summary>
        /// Image (EFIMG).
        /// </summary>
        Img,
        /// <summary>
        /// Enabled Services Table.
        /// </summary>
        Est,
        /// <summary>
        /// Capability Configuration Parameters (CCP).
        /// </summary>
        Ccp = 32,
        /// <summary>
        /// SF_EUIMID-based EUIMID.
        /// </summary>
        Euimidl,
        /// <summary>
        /// Messaging and 3GPD Extensions.
        /// </summary>
        St3GpdExt,
        /// <summary>
        /// Root Certificates.
        /// </summary>
        RootCerti,
        /// <summary>
        /// WAP Browser.
        /// </summary>
        Wap,
        /// <summary>
        /// Java.
        /// </summary>
        Java,
        /// <summary>
        /// Reserved for CDG.
        /// </summary>
        RsvdCdg1,
        /// <summary>
        /// Reserved for CDG.
        /// </summary>
        RsvdCdg2,
        /// <summary>
        /// IPv6.
        /// </summary>
        IPv6 = 40
    }
}
