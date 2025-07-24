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

using System;
using static Interop.Telephony;
namespace Tizen.Telephony
{
    /// <summary>
    /// The Network class provides APIs to obtain information about the current telephony service network.
    /// It offers properties such as Lac, which allows users to retrieve the Location Area Code (LAC) of
    /// the current location. Another property, CellId, enables users to obtain the cell identification number.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    /// [Obsolete("Deprecated since API13, will be removed in API15.")]
    public class Network
    {
        internal IntPtr _handle;

        /// <summary>
        /// The Network class constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="handle">
        /// SlotHandle received in the Manager.Init API.
        /// </param>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="ArgumentNullException">
        /// This exception occurs if the handle provided is null.
        /// </exception>
        /// [Obsolete("Deprecated since API13, will be removed in API15.")]
        public Network(SlotHandle handle)
        {
            if (handle == null)
            {
                throw new ArgumentNullException();
            }

            _handle = handle._handle;
        }

        /// <summary>
        /// Enumeration for the RSSI (Receive Signal Strength Indicator).
        /// Rssi6 indicates the highest strength.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// [Obsolete("Deprecated since API13, will be removed in API15.")]
        public enum Rssi
        {
            /// <summary>
            /// Strength 0.
            /// </summary>
            Rssi0,
            /// <summary>
            /// Strength 1.
            /// </summary>
            Rssi1,
            /// <summary>
            /// Strength 2.
            /// </summary>
            Rssi2,
            /// <summary>
            /// Strength 3.
            /// </summary>
            Rssi3,
            /// <summary>
            /// Strength 4.
            /// </summary>
            Rssi4,
            /// <summary>
            /// Strength 5.
            /// </summary>
            Rssi5,
            /// <summary>
            /// Strength 6.
            /// </summary>
            Rssi6,
            /// <summary>
            /// Unavailable.
            /// </summary>
            Unavailable
        }

        /// <summary>
        /// Enumeration for the network types.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// [Obsolete("Deprecated since API13, will be removed in API15.")]
        public enum Type
        {
            /// <summary>
            /// Unknown.
            /// </summary>
            Unknown,
            /// <summary>
            /// 2G GSM network type.
            /// </summary>
            Gsm,
            /// <summary>
            /// 2.5G GPRS network type.
            /// </summary>
            Gprs,
            /// <summary>
            /// 2.5G EDGE network type.
            /// </summary>
            Edge,
            /// <summary>
            /// 3G UMTS network type.
            /// </summary>
            Umts,
            /// <summary>
            /// HSDPA network type.
            /// </summary>
            Hsdpa,
            /// <summary>
            /// LTE network type.
            /// </summary>
            Lte,
            /// <summary>
            /// IS95A network type.
            /// </summary>
            Is95a,
            /// <summary>
            /// IS95B network type.
            /// </summary>
            Is95b,
            /// <summary>
            /// CDMA 1x network type.
            /// </summary>
            Cdma1X,
            /// <summary>
            /// EVDO revision 0 network type.
            /// </summary>
            EvdoRev0,
            /// <summary>
            /// EVDO revision A network type.
            /// </summary>
            EvdoRevA,
            /// <summary>
            /// EVDO revision B network type.
            /// </summary>
            EvdoRevB,
            /// <summary>
            /// EVDV network type.
            /// </summary>
            Evdv,
            /// <summary>
            /// EHRPD network type.
            /// </summary>
            Ehrpd
        }

        /// <summary>
        /// Enumeration for the PS types.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// [Obsolete("Deprecated since API13, will be removed in API15.")]
        public enum PsType
        {
            /// <summary>
            /// Unknown.
            /// </summary>
            Unknown,
            /// <summary>
            /// HSDPA PS type.
            /// </summary>
            Hsdpa,
            /// <summary>
            /// HSUPA PS type.
            /// </summary>
            Hsupa,
            /// <summary>
            /// HSPA PS type.
            /// </summary>
            Hspa,
            /// <summary>
            /// HSPAP PS type.
            /// </summary>
            Hspap
        }

        /// <summary>
        /// Enumeration for the network service states.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// [Obsolete("Deprecated since API13, will be removed in API15.")]
        public enum ServiceState
        {
            /// <summary>
            /// In service.
            /// </summary>
            InService,
            /// <summary>
            /// Out of service.
            /// </summary>
            OutOfService,
            /// <summary>
            /// Only emergency call is allowed.
            /// </summary>
            EmergencyOnly,
            /// <summary>
            /// Unavailable.
            /// </summary>
            Unavailable
        }

        /// <summary>
        /// Enumeration for the network name priority.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// [Obsolete("Deprecated since API13, will be removed in API15.")]
        public enum NameOption
        {
            /// <summary>
            /// Unknown.
            /// </summary>
            Unknown,
            /// <summary>
            /// The network name displayed by the SPN.
            /// </summary>
            Spn,
            /// <summary>
            /// The network name displayed by the Network.
            /// </summary>
            Network,
            /// <summary>
            /// The network name displayed by the SPN or the Network.
            /// </summary>
            Any
        }

        /// <summary>
        /// Enumeration for the possible 'default' Data Subscriptions for the Packet Switched(PS).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// [Obsolete("Deprecated since API13, will be removed in API15.")]
        public enum DefaultDataSubscription
        {
            /// <summary>
            /// Unknown status.
            /// </summary>
            Unknown = -1,
            /// <summary>
            /// SIM 1.
            /// </summary>
            Sim1,
            /// <summary>
            /// SIM 2.
            /// </summary>
            Sim2
        }

        /// <summary>
        /// Enumeration for defining the possible 'default' Subscriptions for the Circuit Switched(CS).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// [Obsolete("Deprecated since API13, will be removed in API15.")]
        public enum DefaultSubscription
        {
            /// <summary>
            /// Unknown status.
            /// </summary>
            Unknown = -1,
            /// <summary>
            /// SIM 1 network.
            /// </summary>
            Sim1,
            /// <summary>
            /// SIM 2 network.
            /// </summary>
            Sim2
        }

        /// <summary>
        /// Enumeration for the network selection modes.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// [Obsolete("Deprecated since API13, will be removed in API15.")]
        public enum SelectionMode
        {
            /// <summary>
            /// Automatic mode.
            /// </summary>
            Automatic,
            /// <summary>
            /// Manual mode.
            /// </summary>
            Manual,
            /// <summary>
            /// Unavailable.
            /// </summary>
            Unavailable
        }

        /// <summary>
        /// Gets the LAC (Location Area Code) of the current location.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/location.coarse</privilege>
        /// <remarks>
        /// This API can be used in the GSM/WCDMA network.
        /// </remarks>
        /// <value>
        /// The Location Area Code, -1 if unknown.
        /// </value>
        /// [Obsolete("Deprecated since API13, will be removed in API15.")]
        public int Lac
        {
            get
            {
                int lac;
                TelephonyError error = Interop.Network.GetLac(_handle, out lac);
                if (error != TelephonyError.None)
                {
                    Tizen.Log.Error(Interop.Telephony.LogTag, "GetLac Failed with error " + error);
                    return -1;
                }

                Log.Info(Interop.Telephony.LogTag, "Lac Value " + lac);
                return lac;
            }

        }

        /// <summary>
        /// Gets the cell ID of the current location.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/location.coarse</privilege>
        /// <remarks>
        /// This API can be used in the GSM/WCDMA/LTE network.
        /// </remarks>
        /// <value>
        /// The cell identification number, -1 if unknown.
        /// </value>
        /// [Obsolete("Deprecated since API13, will be removed in API15.")]
        public int CellId
        {
            get
            {
                int cellId;
                TelephonyError error = Interop.Network.GetCellId(_handle, out cellId);
                if (error != TelephonyError.None)
                {
                    Tizen.Log.Error(Interop.Telephony.LogTag, "GetCellId Failed with error " + error);
                    return -1;
                }

                Log.Info(Interop.Telephony.LogTag, "CellId Value " + cellId);
                return cellId;
            }
        }

        /// <summary>
        /// Gets the RSSI (Received Signal Strength Indicator).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <value>
        /// The Received Signal Strength Indicator.
        /// Higher the received number, the stronger the signal strength.
        /// </value>
        /// [Obsolete("Deprecated since API13, will be removed in API15.")]
        public Rssi CurrentRssi
        {
            get
            {
                Rssi currentRssi;
                TelephonyError error = Interop.Network.GetRssi(_handle, out currentRssi);
                if (error != TelephonyError.None)
                {
                    Tizen.Log.Error(Interop.Telephony.LogTag, "GetRssi Failed with error " + error);
                    return Rssi.Unavailable;
                }

                Log.Info(Interop.Telephony.LogTag, "CurrentRssi Value " + currentRssi);
                return currentRssi;
            }
        }

        /// <summary>
        /// Gets the roaming state of the current registered network.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <value>
        /// true if roaming, otherwise false if not roaming.
        /// </value>
        /// [Obsolete("Deprecated since API13, will be removed in API15.")]
        public bool RoamingStatus
        {
            get
            {
                bool roamingStatus;
                TelephonyError error = Interop.Network.GetRoamingStatus(_handle, out roamingStatus);
                if (error != TelephonyError.None)
                {
                    Tizen.Log.Error(Interop.Telephony.LogTag, "GetRoamingStatus Failed with error " + error);
                    return false;
                }

                return roamingStatus;
            }
        }

        /// <summary>
        /// Gets the MCC (Mobile Country Code) of the current registered network.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <remarks>
        /// This API can be used in the GSM/WCDMA/LTE network.
        /// </remarks>
        /// <value>
        /// The Mobile Country Code (three digits). The Mobile Country Code (MCC) identifies the country where the cell is being used.
        /// Empty string if unknown.
        /// </value>
        /// [Obsolete("Deprecated since API13, will be removed in API15.")]
        public string Mcc
        {
            get
            {
                string mcc;
                TelephonyError error = Interop.Network.GetMcc(_handle, out mcc);
                if (error != TelephonyError.None)
                {
                    Tizen.Log.Error(Interop.Telephony.LogTag, "GetMcc Failed with error " + error);
                    return "";
                }

                return mcc;
            }
        }

        /// <summary>
        /// Gets the MNC (Mobile Network Code) of the current registered network.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <remarks>
        /// This API can be used in the GSM/WCDMA/LTE network.
        /// </remarks>
        /// <value>
        /// The Mobile Network Code (three digits). The Mobile Network Code (MNC) identifies the mobile phone operator and the network provider.
        /// Empty string if unknown.
        /// </value>
        /// [Obsolete("Deprecated since API13, will be removed in API15.")]
        public string Mnc
        {
            get
            {
                string mnc;
                TelephonyError error = Interop.Network.GetMnc(_handle, out mnc);
                if (error != TelephonyError.None)
                {
                    Tizen.Log.Error(Interop.Telephony.LogTag, "GetMnc Failed with error " + error);
                    return "";
                }

                return mnc;
            }
        }

        /// <summary>
        /// Gets the name of the current registered network.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <remarks>
        /// This API can be used in the GSM/WCDMA/LTE network.
        /// </remarks>
        /// <value>
        /// The name of the current registered network.
        /// Empty string if unknown.
        /// </value>
        /// [Obsolete("Deprecated since API13, will be removed in API15.")]
        public string NetworkName
        {
            get
            {
                string networkName;
                TelephonyError error = Interop.Network.GetNetworkName(_handle, out networkName);
                if (error != TelephonyError.None)
                {
                    Tizen.Log.Error(Interop.Telephony.LogTag, "GetNetworkName Failed with error " + error);
                    return "";
                }

                return networkName;
            }
        }

        /// <summary>
        /// Gets the network service type of the current registered network.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <remarks>
        /// This API can be used in case the network is in service.
        /// </remarks>
        /// <value>
        /// The network service type.
        /// </value>
        /// [Obsolete("Deprecated since API13, will be removed in API15.")]
        public Type NetworkType
        {
            get
            {
                Type networkType;
                TelephonyError error = Interop.Network.GetType(_handle, out networkType);
                if (error != TelephonyError.None)
                {
                    Tizen.Log.Error(Interop.Telephony.LogTag, "GetType Failed with error " + error);
                    return Type.Unknown;
                }

                return networkType;
            }
        }

        /// <summary>
        /// Gets the packet service type of the current registered network.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <remarks>
        /// This API can be used in the HSDPA network.
        /// </remarks>
        /// <value>
        /// The type of the packet service.
        /// </value>
        /// [Obsolete("Deprecated since API13, will be removed in API15.")]
        public PsType NetworkPsType
        {
            get
            {
                PsType networkPsType;
                TelephonyError error = Interop.Network.GetPsType(_handle, out networkPsType);
                if (error != TelephonyError.None)
                {
                    Tizen.Log.Error(Interop.Telephony.LogTag, "GetPsType Failed with error " + error);
                    return PsType.Unknown;
                }

                return networkPsType;
            }

        }

        /// <summary>
        /// Gets the network name option of the current registered network.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <value>
        /// The network name display option.
        /// </value>
        /// [Obsolete("Deprecated since API13, will be removed in API15.")]
        public NameOption NetworkNameOption
        {
            get
            {
                NameOption networkNameOption;
                TelephonyError error = Interop.Network.GetNetworkNameOption(_handle, out networkNameOption);
                if (error != TelephonyError.None)
                {
                    Tizen.Log.Error(Interop.Telephony.LogTag, "GetNetworkNameOption Failed with error " + error);
                    return NameOption.Unknown;
                }

                return networkNameOption;
            }

        }

        /// <summary>
        /// Gets the current network state of the telephony service.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <value>
        /// The current network state.
        /// </value>
        /// [Obsolete("Deprecated since API13, will be removed in API15.")]
        public ServiceState NetworkServiceState
        {
            get
            {
                ServiceState networkServiceState;
                TelephonyError error = Interop.Network.GetServiceState(_handle, out networkServiceState);
                if (error != TelephonyError.None)
                {
                    Tizen.Log.Error(Interop.Telephony.LogTag, "GetServiceState Failed with error " + error);
                    return ServiceState.Unavailable;
                }

                return networkServiceState;
            }

        }

        /// <summary>
        /// Gets the current default subscription for the data service (Packet Switched).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <value>
        /// The current default data subscription.
        /// </value>
        /// [Obsolete("Deprecated since API13, will be removed in API15.")]
        public DefaultDataSubscription NetworkDefaultDataSubscription
        {
            get
            {
                DefaultDataSubscription networkDefaultDataSubs;
                TelephonyError error = Interop.Network.GetDefaultDataSubscription(_handle, out networkDefaultDataSubs);
                if (error != TelephonyError.None)
                {
                    Tizen.Log.Error(Interop.Telephony.LogTag, "GetDefaultDataSubscription Failed with error " + error);
                    return DefaultDataSubscription.Unknown;
                }

                return networkDefaultDataSubs;
            }

        }

        /// <summary>
        /// Gets the current default subscription for the voice service (Circuit Switched).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <value>
        /// The current default voice subscription.
        /// </value>
        /// [Obsolete("Deprecated since API13, will be removed in API15.")]
        public DefaultSubscription NetworkDefaultSubscription
        {
            get
            {
                DefaultSubscription networkDefaultSubscription;
                TelephonyError error = Interop.Network.GetDefaultSubscription(_handle, out networkDefaultSubscription);
                if (error != TelephonyError.None)
                {
                    Tizen.Log.Error(Interop.Telephony.LogTag, "GetDefaultSubscription Failed with error " + error);
                    return DefaultSubscription.Unknown;
                }

                return networkDefaultSubscription;
            }

        }

        /// <summary>
        /// Gets the network selection mode.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <value>
        /// The network selection mode.
        /// </value>
        /// [Obsolete("Deprecated since API13, will be removed in API15.")]
        public SelectionMode NetworkSelectionMode
        {
            get
            {
                SelectionMode networkSelectionMode;
                TelephonyError error = Interop.Network.GetSelectionMode(_handle, out networkSelectionMode);
                if (error != TelephonyError.None)
                {
                    Tizen.Log.Error(Interop.Telephony.LogTag, "GetSelectionMode Failed with error " + error);
                    return SelectionMode.Unavailable;
                }

                return networkSelectionMode;
            }

        }

        /// <summary>
        /// Gets the TAC (Tracking Area Code) of the current location.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/location.coarse</privilege>
        /// <remarks>
        /// This API can be used in the LTE network.
        /// </remarks>
        /// <value>
        /// The Tracking Area Code.
        /// -1 if unknown.
        /// </value>
        /// [Obsolete("Deprecated since API13, will be removed in API15.")]
        public int Tac
        {
            get
            {
                int tac;
                TelephonyError error = Interop.Network.GetTac(_handle, out tac);
                if (error != TelephonyError.None)
                {
                    Tizen.Log.Error(Interop.Telephony.LogTag, "GetTac Failed with error " + error);
                    return -1;
                }

                return tac;
            }

        }

        /// <summary>
        /// Gets the system ID of the current location.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/location.coarse</privilege>
        /// <remarks>
        /// This API can be used in the CDMA network.
        /// </remarks>
        /// <value>
        /// The system ID.
        /// -1 if unknown.
        /// </value>
        /// [Obsolete("Deprecated since API13, will be removed in API15.")]
        public int SystemId
        {
            get
            {
                int systemId;
                TelephonyError error = Interop.Network.GetSystemId(_handle, out systemId);
                if (error != TelephonyError.None)
                {
                    Tizen.Log.Error(Interop.Telephony.LogTag, "GetSystemId Failed with error " + error);
                    return -1;
                }

                return systemId;
            }

        }

        /// <summary>
        /// Gets the network ID of the current location.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/location.coarse</privilege>
        /// <remarks>
        /// This API can be used in the CDMA network.
        /// </remarks>
        /// <value>
        /// The network ID.
        /// -1 if unknown.
        /// </value>
        /// [Obsolete("Deprecated since API13, will be removed in API15.")]
        public int NetworkId
        {
            get
            {
                int networkId;
                TelephonyError error = Interop.Network.GetNetworkId(_handle, out networkId);
                if (error != TelephonyError.None)
                {
                    Tizen.Log.Error(Interop.Telephony.LogTag, "GetNetworkId Failed with error " + error);
                    return -1;
                }

                return networkId;
            }

        }

        /// <summary>
        /// Gets the base station ID of the current location.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/location.coarse</privilege>>
        /// <remarks>
        /// This API can be used in the CDMA network.
        /// </remarks>
        /// <value>
        /// The base station ID.
        /// -1 if unknown.
        /// </value>
        /// [Obsolete("Deprecated since API13, will be removed in API15.")]
        public int BaseStationId
        {
            get
            {
                int baseStationId;
                TelephonyError error = Interop.Network.GetBaseStationId(_handle, out baseStationId);
                if (error != TelephonyError.None)
                {
                    Tizen.Log.Error(Interop.Telephony.LogTag, "GetBaseStationId Failed with error " + error);
                    return -1;
                }

                return baseStationId;
            }

        }

        /// <summary>
        /// Gets the base station latitude of the current location.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/location.coarse</privilege>
        /// <remarks>
        /// This API can be used in the CDMA network.
        /// </remarks>
        /// <value>
        /// The base station latitude.
        /// 0x7FFFFFFF if unknown.
        /// </value>
        /// [Obsolete("Deprecated since API13, will be removed in API15.")]
        public int BaseStationLatitude
        {
            get
            {
                int baseStationLatitude;
                TelephonyError error = Interop.Network.GetBaseStationLatitude(_handle, out baseStationLatitude);
                if (error != TelephonyError.None)
                {
                    Tizen.Log.Error(Interop.Telephony.LogTag, "GetBaseStationLatitude Failed with error " + error);
                    return 0x7FFFFFFF;
                }

                return baseStationLatitude;
            }
        }

        /// <summary>
        /// Gets the base station longitude of the current location.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/location.coarse</privilege>
        /// <remarks>
        /// This API can be used in the CDMA network.
        /// </remarks>
        /// <value>
        /// The base station latitude.
        /// 0x7FFFFFFF if unknown.
        /// </value>
        /// [Obsolete("Deprecated since API13, will be removed in API15.")]
        public int BaseStationLongitude
        {
            get
            {
                int baseStationLongitude;
                TelephonyError error = Interop.Network.GetBaseStationLongitude(_handle, out baseStationLongitude);
                if (error != TelephonyError.None)
                {
                    Tizen.Log.Error(Interop.Telephony.LogTag, "GetBaseStationLongitude Failed with error " + error);
                    return 0x7FFFFFFF;
                }

                return baseStationLongitude;
            }
        }
    }
}
