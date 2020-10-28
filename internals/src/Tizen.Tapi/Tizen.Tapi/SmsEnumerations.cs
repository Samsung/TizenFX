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
    /// Enumeration for the type of sms network.
    /// </summary>
    public enum SmsNetType
    {
        /// <summary>
        /// Network type is 3gpp.
        /// </summary>
        Net3GPP = 0x01,
        /// <summary>
        /// Network type is 3gpp2 (CDMA).
        /// </summary>
        Net3GPP2 = 0x02
    }

    /// <summary>
    /// Enumeration for different CB message types.
    /// </summary>
    public enum SmsCbMsgType
    {
        /// <summary>
        /// GSM Cell broadcast message.
        /// </summary>
        Gsm = 1,
        /// <summary>
        /// UMTSCell broadcast message.
        /// </summary>
        Umts,
        /// <summary>
        /// CDMA broadcast message.
        /// </summary>
        Cdma
    }

    /// <summary>
    /// Enumeration for different ETWS message types.
    /// </summary>
    public enum SmsEtwsMsgType
    {
        /// <summary>
        /// Primary ETWS message.
        /// </summary>
        Primary = 0,
        /// <summary>
        /// GSM Secondary ETWS message.
        /// </summary>
        SecondaryGsm,
        /// <summary>
        /// UMTS Secondary ETWS message.
        /// </summary>
        SecondaryUmts,
        /// <summary>
        /// CDMA Seconday ETWS message.
        /// </summary>
        SecondaryCdma
    }

    /// <summary>
    /// Enumeration for memory status type.
    /// </summary>
    public enum SmsMemoryStatus
    {
        /// <summary>
        /// PDA memory is available.
        /// </summary>
        PdaAvailable = 0x01,
        /// <summary>
        /// PDA memory is full.
        /// </summary>
        PdaFull = 0x02,
        /// <summary>
        /// Phone memory is available.
        /// </summary>
        PhoneAvailable = 0x03,
        /// <summary>
        /// Phone memory is full.
        /// </summary>
        PhoneFull = 0x04
    }

    /// <summary>
    /// Enumeration for the sms ready status type.
    /// </summary>
    public enum SmsReadyStatus
    {
        /// <summary>
        /// Non Ready Status.
        /// </summary>
        StatusNone = 0x00,
        /// <summary>
        /// SMS 3GPP Ready.
        /// </summary>
        Status3GPP = 0x01,
        /// <summary>
        /// SMS 3GPP2 Ready.
        /// </summary>
        Status3GPP2 = 0x02,
        /// <summary>
        /// SMS 3GPP and 3GPP2 Ready.
        /// </summary>
        Status3GPPAnd3GPP2 = 0x03
    }

    /// <summary>
    /// Enumeration for sms status type.
    /// </summary>
    public enum SmsMessageStatus
    {
        /// <summary>
        /// MT message, stored and read.
        /// </summary>
        Read,
        /// <summary>
        /// MT message, stored and unread.
        /// </summary>
        Unread,
        /// <summary>
        /// MO message, stored and sent.
        /// </summary>
        Sent,
        /// <summary>
        /// MO message, stored but not sent.
        /// </summary>
        Unsent,
        /// <summary>
        /// Delivered at destination.
        /// </summary>
        Delivered,
        /// <summary>
        /// Service centre forwarded message but is unable to confirm delivery.
        /// </summary>
        DeliveryUnconfirmed,
        /// <summary>
        /// Message has been replaced.
        /// </summary>
        MessageReplaced,
        /// <summary>
        /// Reserved for future use.
        /// </summary>
        Reserved
    }

    /// <summary>
    /// Enumeration for different response types that come in the sent status acknowledgement/notification after sending a message to the network.
    /// </summary>
    public enum SmsResponse
    {
        /// <summary>
        /// Message sent successfully.
        /// </summary>
        Success,
        /// <summary>
        /// Message routing not available.
        /// </summary>
        NotAvailable,
        /// <summary>
        /// Invalid parameter present in TPDU
        /// </summary>
        InvalidParameter,
        /// <summary>
        /// Device failure.
        /// </summary>
        DeviceFail,
        /// <summary>
        /// Reserved Service.
        /// </summary>
        ServiceReserved,
        /// <summary>
        /// Invalid location.
        /// </summary>
        InvalidLocation,
        /// <summary>
        /// No SIM error.
        /// </summary>
        NoSim,
        /// <summary>
        /// SIM not ready error.
        /// </summary>
        SimNotReady,
        /// <summary>
        /// No response from network.
        /// </summary>
        NoNetworkResponse,
        /// <summary>
        /// Destination address restricted.
        /// </summary>
        DestinationAddressRestricted,
        /// <summary>
        /// Service center address restricted.
        /// </summary>
        SCAAddressRestricted,
        /// <summary>
        /// Resend an already done operation.
        /// </summary>
        ResendDone,
        /// <summary>
        /// SCA address not available.
        /// </summary>
        SCANotAvailable,
        /// <summary>
        /// Unassigned number.
        /// </summary>
        UnassignedNumber,
        /// <summary>
        /// Operator determined barring.
        /// </summary>
        OperatorBarring,
        /// <summary>
        /// Call barred.
        /// </summary>
        CallBarred,
        /// <summary>
        /// Message transfer rejected.
        /// </summary>
        MessageTransferRejected,
        /// <summary>
        /// Message capacity exceeded/memory full.
        /// </summary>
        MemoryCapacityExceeded,
        /// <summary>
        /// Destination number out of service.
        /// </summary>
        DestinationOutOfService,
        /// <summary>
        /// Unspecified subscriber.
        /// </summary>
        UnspecifiedSubscriber,
        /// <summary>
        /// Facility rejected.
        /// </summary>
        FacilityRejected,
        /// <summary>
        /// Unknown subscriber.
        /// </summary>
        UnknownSubscriber,
        /// <summary>
        /// Network out of order.
        /// </summary>
        NetworkOutOfOrder,
        /// <summary>
        /// Temporary failure.
        /// </summary>
        TemporaryFail,
        /// <summary>
        /// Congestion occured.
        /// </summary>
        Congestion,
        /// <summary>
        /// Resource unavilable.
        /// </summary>
        ResourceUnavailable,
        /// <summary>
        /// Facility not subscribed by the user.
        /// </summary>
        FacilityNotSubscribed,
        /// <summary>
        /// Facility not implemented.
        /// </summary>
        FacilityNotImplemented,
        /// <summary>
        /// Invalid reference value.
        /// </summary>
        InvalidReference,
        /// <summary>
        /// Invalid message.
        /// </summary>
        InvalidMessage,
        /// <summary>
        /// Invalid mandatory information.
        /// </summary>
        InvalidMandatoryInfo,
        /// <summary>
        /// Message type not implemented.
        /// </summary>
        MessageTypeNotImplemented,
        /// <summary>
        /// Message not compact protocol.
        /// </summary>
        MessageNotCompactProtocol,
        /// <summary>
        /// Information element not implemented.
        /// </summary>
        IENotImplemented,
        /// <summary>
        /// Protocol error.
        /// </summary>
        ProtocolError,
        /// <summary>
        /// Networking error.
        /// </summary>
        Interworking,
        /// <summary>
        /// Sms ME full.
        /// </summary>
        MeFull,
        /// <summary>
        /// Sms sim full.
        /// </summary>
        SimFull,
        /// <summary>
        /// Timeout error.
        /// </summary>
        Timeout
    }
}
