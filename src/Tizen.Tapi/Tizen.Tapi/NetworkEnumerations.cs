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
    /// Enumeration for the status of the network service.
    /// </summary>
    public enum NetworkServiceLevel
    {
        /// <summary>
        /// No service available in the network ME is camped.
        /// </summary>
        No,
        /// <summary>
        /// Only emergency service available in the network ME is camped.
        /// </summary>
        Emergency,
        /// <summary>
        /// FULL service available in the network ME is camped
        /// </summary>
        Full,
        /// <summary>
        /// Searching for service.
        /// </summary>
        Search
    }

    /// <summary>
    /// Enumeration for the service types of TAPI.
    /// </summary>
    public enum NetworkServiceType
    {
        /// <summary>
        /// Service type is Unknown.
        /// </summary>
        Unknown = 0x0,
        /// <summary>
        /// No Service available.
        /// </summary>
        NoService,
        /// <summary>
        /// Service type is Emergency.
        /// </summary>
        Emergency,
        /// <summary>
        /// Service type is Searching.
        /// </summary>
        Search,
        /// <summary>
        /// Service type is 2G. In case of CDMA, service type is set to 2G when System Type is IS95A/IS95B/CDMA_1X.
        /// </summary>
        Type2G,
        /// <summary>
        /// Service type is 2.5G.
        /// </summary>
        Type2And5G,
        /// <summary>
        /// Service type is 2.5G (EDGE).
        /// </summary>
        TypeAnd5GEdge,
        /// <summary>
        /// Service type is 3G. In case of CDMA, service type is set to 3G when System Type is EVDO_REV_0/REV_A/REV_B/EHRPD.
        /// </summary>
        Type3G,
        /// <summary>
        /// Service type is HSDPA.
        /// </summary>
        Hsdpa,
        /// <summary>
        /// Service type is LTE.
        /// </summary>
        Lte
    }

    /// <summary>
    /// Enumeration for the system types of network.
    /// </summary>
    public enum NetworkSystemType
    {
        /// <summary>
        /// No Service available.
        /// </summary>
        NoService = 0x01,
        /// <summary>
        /// Available service is GSM.
        /// </summary>
        Gsm,
        /// <summary>
        /// Available service is GPRS.
        /// </summary>
        Gprs,
        /// <summary>
        /// Available service is EGPRS.
        /// </summary>
        EGprs,
        /// <summary>
        /// Available service is PCS1900 band.
        /// </summary>
        Pcs1900,
        /// <summary>
        /// Available service is UMTS.
        /// </summary>
        Umts,
        /// <summary>
        /// Both GSM and UMTS systems available.
        /// </summary>
        GsmandUmts,
        /// <summary>
        /// Available service is HSDPA.
        /// </summary>
        Hsdpa,
        /// <summary>
        /// Available service is IS95A.
        /// </summary>
        Is95A,
        /// <summary>
        /// Available service is IS95B.
        /// </summary>
        Is95B,
        /// <summary>
        /// Available service is CDMA 1X.
        /// </summary>
        Cdma1x,
        /// <summary>
        /// Available service is EV-DO rev0.
        /// </summary>
        EvdoRev0,
        /// <summary>
        /// Available service is 1X and EV-DO rev0.
        /// </summary>
        Hybrid1xandEvdoRev0,
        /// <summary>
        /// Available service is EV-DO revA.
        /// </summary>
        EvdoRevA,
        /// <summary>
        /// Available service is 1X and EV-DO revA.
        /// </summary>
        Hybrid1xandEvdoRevA,
        /// <summary>
        /// Available service is EV-DO revB.
        /// </summary>
        EvdoRevB,
        /// <summary>
        /// Available service is 1X and EV-DO revB.
        /// </summary>
        Hybrid1xandEvdoRevB,
        /// <summary>
        /// Available service is EV-DV.
        /// </summary>
        Evdv,
        /// <summary>
        /// Available service is EHRPD.
        /// </summary>
        Ehrpd,
        /// <summary>
        /// Available service is LTE.
        /// </summary>
        Lte
    }

    /// <summary>
    /// Enumeration for the network emergency callback mode states (3GPP2 specific enum).
    /// </summary>
    public enum NetworkEmergencyCallbackMode
    {
        /// <summary>
        /// Enter emergency callback mode.
        /// </summary>
        Enter,
        /// <summary>
        /// Exit emergency callback mode.
        /// </summary>
        Exit
    }

    /// <summary>
    /// Enumeration for the possible default Data Subscriptions.
    /// </summary>
    public enum NetworkDefaultDataSubscription
    {
        /// <summary>
        /// Unknown status.
        /// </summary>
        Unknown = -1,
        /// <summary>
        /// SIM 1.
        /// </summary>
        Sim1 = 0,
        /// <summary>
        /// SIM 2.
        /// </summary>
        Sim2
    }

    /// <summary>
    /// Enumeration for the possible default Subscriptions for CS (Voice).
    /// </summary>
    public enum NetworkDefaultSubscription
    {
        /// <summary>
        /// Unknown status.
        /// </summary>
        Unknown = -1,
        /// <summary>
        /// SIM 1 network.
        /// </summary>
        Sim1 = 0,
        /// <summary>
        /// SIM 2 network.
        /// </summary>
        Sim2
    }

    /// <summary>
    /// Enumeration for type of network on which VoLTE is registered.
    /// </summary>
    public enum VolteNetworkType
    {
        /// <summary>
        /// Unknown.
        /// </summary>
        Unknown,
        /// <summary>
        /// Mobile.
        /// </summary>
        Mobile,
        /// <summary>
        /// WiFi.
        /// </summary>
        Wifi
    }

    /// <summary>
    /// Enumeration for the packet service protocol type.
    /// </summary>
    public enum NetworkPsType
    {
        /// <summary>
        /// Unknown PS type.
        /// </summary>
        Unknown,
        /// <summary>
        /// HSDPA.
        /// </summary>
        Hsdpa,
        /// <summary>
        /// HSUPA.
        /// </summary>
        Hsupa,
        /// <summary>
        /// HSPA.
        /// </summary>
        Hspa,
        /// <summary>
        /// HSPAP.
        /// </summary>
        Hspap
    }

    /// <summary>
    /// Enumeration for the network name display condition type.
    /// </summary>
    public enum NetworkNameDisplayCondition
    {
        /// <summary>
        /// Invalid Display Condition.
        /// </summary>
        Invalid = 0x00,
        /// <summary>
        /// Display Condition is SPN.
        /// </summary>
        Spn = 0x01,
        /// <summary>
        /// Display Condition is PLMN.
        /// </summary>
        Plmn = 0x02,
        /// <summary>
        /// Display Condition is SPN or PLMN.
        /// </summary>
        SpnOrPlmn = 0x03
    }

    /// <summary>
    /// Enumeration for the different serving network LTE  band type.
    /// </summary>
    public enum NetworkLteBandType
    {
        /// <summary>
        /// Unknown.
        /// </summary>
        Unknown = 0x00,
        /// <summary>
        /// FDD.
        /// </summary>
        Fdd,
        /// <summary>
        /// TDD.
        /// </summary>
        Tdd
    }

    /// <summary>
    /// Enumeration for the operation that can be done on a preferred PLMN.
    /// </summary>
    public enum NetworkPreferredPlmnOp
    {
        /// <summary>
        /// Addition to the Network Preferred PLMN list.
        /// </summary>
        Add = 0x01,
        /// <summary>
        /// Edit the network Preferred PLMN list.
        /// </summary>
        Edit,
        /// <summary>
        /// Delete the entry to the network Preferred PLMN list.
        /// </summary>
        Delete
    }

    /// <summary>
    /// Enumeration for the CDMA Preferred Network Type(CDMA only).
    /// </summary>
    public enum NetworkPreferred
    {
        /// <summary>
        /// Home only.
        /// </summary>
        HomeOnly,
        /// <summary>
        /// Affiliated.
        /// </summary>
        Affiliated,
        /// <summary>
        /// Automatic.
        /// </summary>
        Automatic,
        /// <summary>
        /// Automatic-A.
        /// </summary>
        AutomaticA,
        /// <summary>
        /// Automatic-B.
        /// </summary>
        AutomaticB,
        /// <summary>
        /// Roam domestic.
        /// </summary>
        RoamDomestic,
        /// <summary>
        /// Roam international.
        /// </summary>
        RoamInternational,
        /// <summary>
        /// Roam dual.
        /// </summary>
        RoamDual,
        /// <summary>
        /// Blank.
        /// </summary>
        Blank
    }

    /// <summary>
    /// Enumeration for the different network operation causes.
    /// </summary>
    public enum NetworkOperationCause
    {
        /// <summary>
        /// No error for any operation.
        /// </summary>
        NoError,
        /// <summary>
        /// Aborted.
        /// </summary>
        Aborted,
        /// <summary>
        /// Error.
        /// </summary>
        Failed,
        /// <summary>
        /// Phone is in use(eg: Voice / Data call in progress).
        /// </summary>
        PhoneInUse,
        /// <summary>
        /// Phone is in offline mode.
        /// </summary>
        Offline,
        /// <summary>
        /// Modem is unable to process the config settings information.
        /// </summary>
        ConfigSettingsFailure,
        /// <summary>
        /// Internal failure.
        /// </summary>
        InternalFailure,
        /// <summary>
        /// Memory is full.
        /// </summary>
        MemoryFull
    }

    /// <summary>
    /// Enumeration for the network plmn type.
    /// </summary>
    public enum NetworkPlmnType
    {
        /// <summary>
        /// Unknown.
        /// </summary>
        Unknown,
        /// <summary>
        /// Home plmn.
        /// </summary>
        Home,
        /// <summary>
        /// Available.
        /// </summary>
        Available,
        /// <summary>
        /// Forbidden.
        /// </summary>
        Forbidden
    }

    /// <summary>
    /// Enumeration for the network selection mode.
    /// </summary>
    public enum NetworkSelectionMode
    {
        /// <summary>
        /// Automatic selection mode.
        /// </summary>
        Auto,
        /// <summary>
        /// Manual selection mode (Not applicable to CDMA).
        /// </summary>
        Manual
    }

    /// <summary>
    /// Enumeration for the different network modes.
    /// </summary>
    public enum NetworkMode
    {
        /// <summary>
        /// Auto.
        /// </summary>
        Auto = 0x00,
        /// <summary>
        /// Gsm.
        /// </summary>
        Gsm = 0x01,
        /// <summary>
        /// Wcdma.
        /// </summary>
        Wcdma = 0x02,
        /// <summary>
        /// Rtt1x.
        /// </summary>
        Rtt1x = 0x04,
        /// <summary>
        /// Lte.
        /// </summary>
        Lte = 0x08,
        /// <summary>
        /// Evdo.
        /// </summary>
        Evdo = 0x10,
        /// <summary>
        /// Cdma.
        /// </summary>
        Cdma = 0x14
    }
}
