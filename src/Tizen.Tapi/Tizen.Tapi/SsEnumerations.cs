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
}
