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
    /// Enumeration for the SS class type.
    /// </summary>
    public enum SsClass
    {
        /// <summary>
        /// All Teleservices.
        /// </summary>
        AllTele = 0x10,
        /// <summary>
        /// Voice (Telephony).
        /// </summary>
        Voice = 0x11,
        /// <summary>
        /// All Data Teleservices.
        /// </summary>
        AllDataTele = 0x12,
        /// <summary>
        /// Fax Service.
        /// </summary>
        Fax = 0x13,
        /// <summary>
        /// SMS Service.
        /// </summary>
        Sms = 0x16,
        /// <summary>
        /// Voice Group Call Service.
        /// </summary>
        Vgcs = 0x17,
        /// <summary>
        /// Voice Broadcast.
        /// </summary>
        Vbs = 0x18,
        /// <summary>
        /// All teleservices except SMS.
        /// </summary>
        AllTeleExceptSms = 0x19,
        /// <summary>
        /// All Bearer services.
        /// </summary>
        AllBearer = 0x20,
        /// <summary>
        /// All Async services.
        /// </summary>
        AllAsync = 0x21,
        /// <summary>
        /// All Sync services.
        /// </summary>
        AllSync = 0x22,
        /// <summary>
        /// All Circuit switched sync services.
        /// </summary>
        AllCsSync = 0x24,
        /// <summary>
        /// All Circuit switched async services.
        /// </summary>
        AllCsAsync = 0x25,
        /// <summary>
        /// All Dedicated Packet Access.
        /// </summary>
        AllDedicatedPacketAccess = 0x26,
        /// <summary>
        /// All Dedicated PAD Access.
        /// </summary>
        AllDedicatedPadAccess = 0x27,
        /// <summary>
        /// All Data CDA.
        /// </summary>
        AllDataCda = 0x28,
        /// <summary>
        /// All PLMN specific teleservices.
        /// </summary>
        PlmnTeleAll = 0x50,
        /// <summary>
        /// PLMN specific teleservice 1.
        /// </summary>
        PlmnTele1 = 0x51,
        /// <summary>
        /// PLMN specific teleservice 2.
        /// </summary>
        PlmnTele2 = 0x52,
        /// <summary>
        /// PLMN specific teleservice 3.
        /// </summary>
        PlmnTele3 = 0x53,
        /// <summary>
        /// PLMN specific teleservice 4.
        /// </summary>
        PlmnTele4 = 0x54,
        /// <summary>
        /// PLMN specific teleservice 5.
        /// </summary>
        PlmnTele5 = 0x55,
        /// <summary>
        /// PLMN specific teleservice 6.
        /// </summary>
        PlmnTele6 = 0x56,
        /// <summary>
        /// PLMN specific teleservice 7.
        /// </summary>
        PlmnTele7 = 0x57,
        /// <summary>
        /// PLMN specific teleservice 8.
        /// </summary>
        PlmnTele8 = 0x58,
        /// <summary>
        /// PLMN specific teleservice 9.
        /// </summary>
        PlmnTele9 = 0x59,
        /// <summary>
        /// PLMN specific teleservice 10.
        /// </summary>
        PlmnTeleA = 0x60,
        /// <summary>
        /// PLMN specific teleservice 11.
        /// </summary>
        PlmnTeleB = 0x61,
        /// <summary>
        /// PLMN specific teleservice 12.
        /// </summary>
        PlmnTeleC = 0x62,
        /// <summary>
        /// PLMN specific teleservice 13.
        /// </summary>
        PlmnTeleD = 0x63,
        /// <summary>
        /// PLMN specific teleservice 14.
        /// </summary>
        PlmnTeleE = 0x64,
        /// <summary>
        /// PLMN specific teleservice 15.
        /// </summary>
        PlmnTeleF = 0x65,
        /// <summary>
        /// All PLMN specific bearer services.
        /// </summary>
        PlmnBearAll = 0x70,
        /// <summary>
        /// PLMN specific bearer service 1.
        /// </summary>
        PlmnBear1 = 0x71,
        /// <summary>
        /// PLMN specific bearer service 2.
        /// </summary>
        PlmnBear2 = 0x72,
        /// <summary>
        /// PLMN specific bearer service 3.
        /// </summary>
        PlmnBear3 = 0x73,
        /// <summary>
        /// PLMN specific bearer service 4.
        /// </summary>
        PlmnBear4 = 0x74,
        /// <summary>
        /// PLMN specific bearer service 5.
        /// </summary>
        PlmnBear5 = 0x75,
        /// <summary>
        /// PLMN specific bearer service 6.
        /// </summary>
        PlmnBear6 = 0x76,
        /// <summary>
        /// PLMN specific bearer service 7.
        /// </summary>
        PlmnBear7 = 0x77,
        /// <summary>
        /// PLMN specific bearer service 8.
        /// </summary>
        PlmnBear8 = 0x78,
        /// <summary>
        /// PLMN specific bearer service 9.
        /// </summary>
        PlmnBear9 = 0x79,
        /// <summary>
        /// PLMN specific bearer service 10.
        /// </summary>
        PlmnBearA = 0x80,
        /// <summary>
        /// PLMN specific bearer service 11.
        /// </summary>
        PlmnBearB = 0x81,
        /// <summary>
        /// PLMN specific bearer service 12.
        /// </summary>
        PlmnBearC = 0x82,
        /// <summary>
        /// PLMN specific bearer service 13.
        /// </summary>
        PlmnBearD = 0x83,
        /// <summary>
        /// PLMN specific bearer service 14.
        /// </summary>
        PlmnBearE = 0x84,
        /// <summary>
        /// PLMN specific bearer service 15.
        /// </summary>
        PlmnBearF = 0x85,
        /// <summary>
        /// Auxiliary Voice (Auxiliary telephony).
        /// </summary>
        AuxVoice = 0x89,
        /// <summary>
        /// All GPRS bearer services.
        /// </summary>
        AllGprsBearer = 0x99,
        /// <summary>
        /// All tele and bearer services.
        /// </summary>
        AllTeleBearer = 0xFF
    }

    /// <summary>
    /// Enumeration for various types of call barring.
    /// </summary>
    public enum SsBarringType
    {
        /// <summary>
        /// Barring All Outgoing Calls.
        /// </summary>
        Baoc = 0x01,
        /// <summary>
        /// Barring Outgoing International Calls.
        /// </summary>
        Boic,
        /// <summary>
        /// Barring Outgoing International Calls except Home Country.
        /// </summary>
        BoicNotHc,
        /// <summary>
        /// Barring All Incoming Calls.
        /// </summary>
        Baic,
        /// <summary>
        /// Barring Incoming Calls when roaming outside the Home Country.
        /// </summary>
        BicRoam,
        /// <summary>
        /// All Barring Services.
        /// </summary>
        Ab,
        /// <summary>
        /// All Outgoing Barring Services.
        /// </summary>
        Aob,
        /// <summary>
        /// All Incoming Barring Services.
        /// </summary>
        Aib,
        /// <summary>
        /// Barring Incoming Calls which is not stored in the SIM memory.
        /// </summary>
        BicNotSim,
        /// <summary>
        /// Maximum Barring type.
        /// </summary>
        Max
    }

    /// <summary>
    /// Enumeration for the CLI service type.
    /// </summary>
    public enum SsCliType
    {
        /// <summary>
        /// Calling Line Identification Presentation.
        /// </summary>
        Clip = 0x01,
        /// <summary>
        /// Calling Line Identification Restriction.
        /// </summary>
        Clir = 0x02,
        /// <summary>
        /// Connected Line Identification Presentation. 3GPP(GSM/UMTS/LTE) Specific.
        /// </summary>
        Colp = 0x03,
        /// <summary>
        /// Connected Line Identification Restriction. 3GPP(GSM/UMTS/LTE) Specific.
        /// </summary>
        Colr = 0x04,
        /// <summary>
        /// Called Line Identification Presentation. 3GPP(GSM/UMTS/LTE) Specific.
        /// </summary>
        Cdip = 0x05,
        /// <summary>
        /// Calling Name Presentation. 3GPP(GSM/UMTS/LTE) Specific.
        /// </summary>
        Cnap = 0x06
    }

    /// <summary>
    /// Enumeration for the CLI service status.
    /// </summary>
    public enum SsCliStatus
    {
        /// <summary>
        /// Service not provided by the service provider.
        /// </summary>
        NotProvisioned = 0x01,
        /// <summary>
        /// Service is provided by the service provider.
        /// </summary>
        Provisioned,
        /// <summary>
        /// Service is activated at the network.
        /// </summary>
        Activated,
        /// <summary>
        /// Service status is unknown.
        /// </summary>
        Unknown,
        /// <summary>
        /// Service is temporarily restricted.
        /// </summary>
        TempRestricted,
        /// <summary>
        /// Service is temporarily allowed.
        /// </summary>
        TempAllowed
    }

    /// <summary>
    /// Enumeration for the call forwarding condition.
    /// </summary>
    public enum SsForwardCondition
    {
        /// <summary>
        /// Call Forwarding Unconditional.
        /// </summary>
        Unconditional = 0x01,
        /// <summary>
        /// Call Forwarding Mobile Busy.
        /// </summary>
        MobileBusy,
        /// <summary>
        /// Call Forwarding No Reply.
        /// </summary>
        NoReply,
        /// <summary>
        /// Call Forwarding Not Reachable.
        /// </summary>
        NotReachable,
        /// <summary>
        /// All Call Forwarding.
        /// </summary>
        All,
        /// <summary>
        /// All Conditional Call Forwarding.
        /// </summary>
        AllConditional,
        /// <summary>
        /// Max.
        /// </summary>
        Max
    }

    /// <summary>
    /// Enumeration for the USSD type. Applicable to 3GPP(GSM/UMTS/LTE) only.
    /// </summary>
    public enum SsUssdType
    {
        /// <summary>
        /// USSD request type - User Initiated.
        /// </summary>
        UserInit = 0x01,
        /// <summary>
        /// USSD request type - User Response.
        /// </summary>
        UserResponse,
        /// <summary>
        /// USSD request type - User Release.
        /// </summary>
        UserRelease
    }

    /// <summary>
    /// Enumeration for the status of a supplementary service feature (e.g. call forwarding or call barring).
    /// </summary>
    /// <remarks>
    /// These enumerated values should be used as masks.
    /// </remarks>
    public enum SsStatus
    {
        /// <summary>
        /// Provisioned and registered (but not active/active-quiescent).
        /// </summary>
        Registered = 0x01,
        /// <summary>
        /// Provisioned but not registered (or active/active-quiescent).
        /// </summary>
        Provisioned,
        /// <summary>
        /// Provisioned and registered and active.
        /// </summary>
        Active,
        /// <summary>
        /// Provisioned and registered and active but quiescent.
        /// </summary>
        Quiescent,
        /// <summary>
        /// Not provisioned.
        /// </summary>
        Nothing
    }

    /// <summary>
    /// Enumeration for no-reply time. Applicable to 3GPP(GSM/UMTS/LTE) only.
    /// </summary>
    public enum SsNoReplyTime
    {
        /// <summary>
        /// Timer value set to 5secs.
        /// </summary>
        Time5Secs = 5,
        /// <summary>
        /// Timer value set to 10secs.
        /// </summary>
        Time10Secs = 10,
        /// <summary>
        /// Timer value set to 15secs.
        /// </summary>
        Time15Secs = 15,
        /// <summary>
        /// Timer value set to 20secs.
        /// </summary>
        Time20Secs = 20,
        /// <summary>
        /// Timer value set to 25secs.
        /// </summary>
        Time25Secs = 25,
        /// <summary>
        /// Timer value set to 30secs.
        /// </summary>
        Time30Secs = 30
    }

    /// <summary>
    /// Enumeration for the call forwarding type of number.
    /// </summary>
    public enum SsForwardTypeOfNumber
    {
        /// <summary>
        /// Unknown.
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// International number.
        /// </summary>
        International = 1,
        /// <summary>
        /// National number.
        /// </summary>
        National = 2,
        /// <summary>
        /// Network specific number.
        /// </summary>
        NetworkSpecific = 3,
        /// <summary>
        /// Subscriber number.
        /// </summary>
        DedicatedAccess = 4,
        /// <summary>
        /// Alphanumeric, GSM 7-bit default alphabet.
        /// </summary>
        AlphaNumeric = 5,
        /// <summary>
        /// Abbreviated number.
        /// </summary>
        AbbreviatedNumber = 6,
        /// <summary>
        /// Reserved for extension.
        /// </summary>
        ReservedForExt = 7
    }

    /// <summary>
    /// Enumeration for the call forward numbering plan identity.
    /// </summary>
    public enum SsForwardNumberingPlanIdentity
    {
        /// <summary>
        /// Unknown.
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// ISDN/Telephone numbering plan.
        /// </summary>
        IsdnTel = 1,
        /// <summary>
        /// Data numbering plan.
        /// </summary>
        DataNumPlan = 3,
        /// <summary>
        /// Telex numbering plan.
        /// </summary>
        Telex = 4,
        /// <summary>
        /// Service Center Specific plan.
        /// </summary>
        ServiceCenterSpecificPlan = 5,
        /// <summary>
        /// Service Center Specific plan2.
        /// </summary>
        ServiceCenterSpecificPlan2 = 6,
        /// <summary>
        /// National numbering plan.
        /// </summary>
        National = 8,
        /// <summary>
        /// Private numbering plan.
        /// </summary>
        Private = 9,
        /// <summary>
        /// ERMES numbering plan.
        /// </summary>
        ErmesNumPlan = 10,
        /// <summary>
        /// Reserved for extension.
        /// </summary>
        ReservedForExt = 0xF
    }

    /// <summary>
    /// Enumeration for the supplementary service request results.
    /// </summary>
    public enum SsCause
    {
        /// <summary>
        /// SS operation is successful.
        /// </summary>
        Success = 0x0,
        /// <summary>
        /// SS error indicating unknown/illegal subscriber
        /// </summary>
        UnknownSubscriber = 0x01,
        /// <summary>
        /// This error is returned when illegality of the access has been established by use of an authentication procedure.
        /// </summary>
        IllegalSubscriber = 0x09,
        /// <summary>
        /// The network returns this error when it is requested to perform an operation on a supplementary service.
        /// </summary>
        BearerServiceNotProvisioned = 0x0a,
        /// <summary>
        /// The network returns this error when it is requested to perform an operation on a supplementary service.
        /// </summary>
        TeleServiceNotProvisioned = 0x0b,
        /// <summary>
        /// This error is returned when the IMEI check procedure has shown that the IMEI is blacklisted or it is not whitelisted.
        /// </summary>
        IllegalEquipment = 0x0c,
        /// <summary>
        /// This error is returned by the network to the MS when call independent subscriber control procedures are barred by the operator.
        /// </summary>
        CallBarred = 0x0d,
        /// <summary>
        /// This error is returned by the network when it is requested to perform an illegal operation which is defined as not applicable for the relevant supplementary service.
        /// </summary>
        IllegalSsOperation = 0x10,
        /// <summary>
        /// This error is returned by the network when it is requested to perform an operation which is not compatible with the current status of the relevant supplementary service.
        /// </summary>
        ErrorStatus = 0x11,
        /// <summary>
        /// SS not available in the network.
        /// </summary>
        Unavailable = 0x12,
        /// <summary>
        /// SS service subscription violation.
        /// </summary>
        SubscriptionViolation = 0x13,
        /// <summary>
        /// This error is returned by the network when it is requested for a supplementary service operation that is incompatible with the status of another supplementary service or with the teleservice or bearer service for which the operation is requested.
        /// </summary>
        Incompatibility = 0x14,
        /// <summary>
        /// SS service facility not supported.
        /// </summary>
        FacilityNotSupported = 0x15,
        /// <summary>
        /// This error is returned when the subscriber has activated the detach service or the system detects the absence condition.
        /// </summary>
        AbsentSubscriber = 0x1b,
        /// <summary>
        /// This error is returned by the network, when it cannot perform an operation because of a failure in the network.
        /// </summary>
        SystemFailure = 0x22,
        /// <summary>
        /// This error is returned by the network when an optional parameter is missing in an invoke component or an inner data structure, while it is required by the context of the request.
        /// </summary>
        DataMissing = 0x23,
        /// <summary>
        /// SS error indicating an unexpected data value on the network side.
        /// </summary>
        UnexpectedDataValue = 0x24,
        /// <summary>
        /// SS error indicating a change password failure.
        /// </summary>
        PasswordRegistrationFailure = 0x25,
        /// <summary>
        /// SS error indicating a negative password check.
        /// </summary>
        NegativePasswordCheck = 0x26,
        /// <summary>
        /// SS error indicating violation in barring password attempts.
        /// </summary>
        PasswordAttemptsViolation = 0x2b,
        /// <summary>
        /// SS error indicating unknown SS data coding of an alphabet.
        /// </summary>
        UnknownAlphabet = 0x47,
        /// <summary>
        /// SS error indicating USSD Busy(Already SS / USSD is ongoing).
        /// </summary>
        UssdBusy = 0x48,
        /// <summary>
        /// SS error indicating Dialing number is not FDN.
        /// </summary>
        FdnOnly = 0x5F,
        /// <summary>
        /// SS operation rejected by the user.
        /// </summary>
        RejectedByUser = 0x79,
        /// <summary>
        /// SS operation rejected by the network.
        /// </summary>
        RejectedByNetwork = 0x7a,
        /// <summary>
        /// This error is returned if a diversion to the served subscriber's number is requested.
        /// </summary>
        DeflectionToServedSubscriber = 0x7b,
        /// <summary>
        /// This error is returned if a diversion to a special service code is requested.
        /// </summary>
        SpecialServiceCode = 0x7c,
        /// <summary>
        /// SS error indicating invalid deflected to a number.
        /// </summary>
        InvalidDeflectedToNumber = 0x7d,
        /// <summary>
        /// SS error indicating Maximum MPTY is reached.
        /// </summary>
        MaxMptyExceeded = 0x7e,
        /// <summary>
        /// SS error indicating resources not available in the network.
        /// </summary>
        ResourceUnavailable = 0x7f,
        /// <summary>
        /// SS error indicating resources not available in the network.
        /// </summary>
        RejectedByCallControl = 0x80,
        /// <summary>
        /// SS operation timer expired on the network.
        /// </summary>
        TimerExpire,
        /// <summary>
        /// SS operation is not allowed by the network.
        /// </summary>
        NotAllowed,
        /// <summary>
        /// SS error indicating an unknown error.
        /// </summary>
        UnknownError,
        /// <summary>
        /// If OEM does not support any SS requests, then this error will be returned.
        /// </summary>
        OemNotSupported
    }

    /// <summary>
    /// Enumeration for SS info type.
    /// </summary>
    public enum SsInfoType
    {
        /// <summary>
        /// Barring.
        /// </summary>
        Barring = 0x00,
        /// <summary>
        /// Forwarding.
        /// </summary>
        Forwarding,
        /// <summary>
        /// Waiting.
        /// </summary>
        Waiting,
        /// <summary>
        /// CLI.
        /// </summary>
        Cli,
        /// <summary>
        /// Send Ussd.
        /// </summary>
        SendUssd,
        /// <summary>
        /// Max value.
        /// </summary>
        Max
    }

    /// <summary>
    /// Enumeration for the call barring operation mode.
    /// </summary>
    public enum SsBarringMode
    {
        /// <summary>
        /// Activate call barring.
        /// </summary>
        Activate,
        /// <summary>
        /// Deactivate call barring.
        /// </summary>
        Deactivate
    }

    /// <summary>
    /// Enumeration for the forward mode.
    /// </summary>
    public enum SsForwardMode
    {
        /// <summary>
        /// Deactivate call forwarding.
        /// </summary>
        Disable,
        /// <summary>
        /// Activate call forwarding.
        /// </summary>
        Enable,
        /// <summary>
        /// Register call forwarding.
        /// </summary>
        Registration,
        /// <summary>
        /// Deregister call forwarding.
        /// </summary>
        Erasure
    }

    /// <summary>
    /// Enumeration for the call waiting mode.
    /// </summary>
    public enum SsCallWaitingMode
    {
        /// <summary>
        /// Activate call waiting.
        /// </summary>
        Activate,
        /// <summary>
        /// Deactivate call waiting.
        /// </summary>
        Deactivate
    }

    /// <summary>
    /// Enumeration for the types of identity presentation / restriction services.
    /// </summary>
    public enum SsLineIdentificationType
    {
        /// <summary>
        /// Identify the party calling this phone.
        /// </summary>
        CallingLinePresentation = 0x01,
        /// <summary>
        /// Hide the identity of this phone when calling others.
        /// </summary>
        CallingLineRestriction,
        /// <summary>
        /// Identify the party to whom the calling party (this phone) is connected. 3GPP(GSM/UMTS/LTE) Specific.
        /// </summary>
        ConnectedLinePresentation,
        /// <summary>
        /// Restrict yourself from being identified by incoming calls, such as forwarded calls. 3GPP(GSM/UMTS/LTE) Specific.
        /// </summary>
        ConnectedLineRestriction,
        /// <summary>
        /// Called line identity presentation. 3GPP(GSM/UMTS/LTE) Specific.
        /// </summary>
        CalledLinePresentation,
        /// <summary>
        /// Calling Name Presentation. 3GPP(GSM/UMTS/LTE) Specific.
        /// </summary>
        CallingNamePresentation
    }

    /// <summary>
    /// Enumeration for the USSD indication type. Applicable to 3GPP(GSM/UMTS/LTE) only.
    /// </summary>
    public enum SsUssdStatus
    {
        /// <summary>
        /// Notify : to display USSD data to the user.
        /// </summary>
        Notify = 0x00,
        /// <summary>
        /// No further user action required.
        /// </summary>
        NoActionRequire = 0x01,
        /// <summary>
        /// Further user action required.
        /// </summary>
        ActionRequire = 0x02,
        /// <summary>
        /// USSD terminated by the network.
        /// </summary>
        TerminatedByNetwork = 0x03,
        /// <summary>
        /// Other local client has responded.
        /// </summary>
        OtherClient = 0x04,
        /// <summary>
        /// Operation not supported.
        /// </summary>
        NotSupport = 0x05,
        /// <summary>
        /// Time out when there is no response from the network.
        /// </summary>
        TimeOut = 0x06
    }
}
