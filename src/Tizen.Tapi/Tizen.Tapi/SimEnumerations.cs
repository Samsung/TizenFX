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
    public enum SimType
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
    /// Enumeration for the sim number type.
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
}
