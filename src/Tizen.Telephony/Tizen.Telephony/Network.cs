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
    /// The Network class provides API's to obtain information about the current telephony service network.
    /// </summary>
    public class Network
    {
        internal IntPtr _handle;

        /// <summary>
        /// Network Class Constructor
        /// </summary>
        /// <param name="handle">
        /// SlotHandle received in the Manager.Init API
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// This exception occurs if handle provided is null
        /// </exception>
        public Network(SlotHandle handle)
        {
            if (handle == null)
            {
                throw new ArgumentNullException();
            }

            _handle = handle._handle;
        }

        /// <summary>
        /// Enumeration for RSSI (Receive Signal Strength Indicator).
        /// Rssi6 indicates the highest strength.
        /// </summary>
        public enum Rssi
        {
            /// <summary>
            /// Strength 0
            /// </summary>
            Rssi0,
            /// <summary>
            /// Strength 1
            /// </summary>
            Rssi1,
            /// <summary>
            /// Strength 2
            /// </summary>
            Rssi2,
            /// <summary>
            /// Strength 3
            /// </summary>
            Rssi3,
            /// <summary>
            /// Strength 4
            /// </summary>
            Rssi4,
            /// <summary>
            /// Strength 5
            /// </summary>
            Rssi5,
            /// <summary>
            /// Strength 6
            /// </summary>
            Rssi6,
            /// <summary>
            /// Unavailable
            /// </summary>
            Unavailable
        }

        /// <summary>
        /// Enumeration for Network Type.
        /// </summary>
        public enum Type
        {
            /// <summary>
            /// Unknown
            /// </summary>
            Unknown,
            /// <summary>
            /// 2G GSM network type
            /// </summary>
            Gsm,
            /// <summary>
            /// 2.5G GPRS network type
            /// </summary>
            Gprs,
            /// <summary>
            /// 2.5G EDGE network type
            /// </summary>
            Edge,
            /// <summary>
            /// 3G UMTS network type
            /// </summary>
            Umts,
            /// <summary>
            /// HSDPA network type
            /// </summary>
            Hsdpa,
            /// <summary>
            /// LTE network type
            /// </summary>
            Lte,
            /// <summary>
            /// IS95A network type
            /// </summary>
            Is95a,
            /// <summary>
            /// IS95B network type
            /// </summary>
            Is95b,
            /// <summary>
            /// CDMA 1x network type
            /// </summary>
            Cdma1X,
            /// <summary>
            /// EVDO revision 0 network type
            /// </summary>
            EvdoRev0,
            /// <summary>
            /// EVDO revision A network type
            /// </summary>
            EvdoRevA,
            /// <summary>
            /// EVDO revision B network type
            /// </summary>
            EvdoRevB,
            /// <summary>
            /// EVDV network type
            /// </summary>
            Evdv,
            /// <summary>
            /// EHRPD network type
            /// </summary>
            Ehrpd
        }

        /// <summary>
        /// Enumeration for PS Type.
        /// </summary>
        public enum PsType
        {
            /// <summary>
            /// Unknown
            /// </summary>
            Unknown,
            /// <summary>
            /// HSDPA ps type
            /// </summary>
            Hsdpa,
            /// <summary>
            /// HSUPA ps type
            /// </summary>
            Hsupa,
            /// <summary>
            /// HSPA ps type
            /// </summary>
            Hspa,
            /// <summary>
            /// HSPAP ps type
            /// </summary>
            Hspap
        }

        /// <summary>
        /// Enumeration for Network Service State.
        /// </summary>
        public enum ServiceState
        {
            /// <summary>
            /// In service
            /// </summary>
            InService,
            /// <summary>
            /// Out of service
            /// </summary>
            OutOfService,
            /// <summary>
            /// Only emergency call is allowed
            /// </summary>
            EmergencyOnly,
            /// <summary>
            /// Unavailable
            /// </summary>
            Unavailable
        }

        /// <summary>
        /// Enumeration for Network Name Priority.
        /// </summary>
        public enum NameOption
        {
            /// <summary>
            /// Unknown
            /// </summary>
            Unknown,
            /// <summary>
            /// Network name displayed by SPN
            /// </summary>
            Spn,
            /// <summary>
            /// Network name displayed by Network
            /// </summary>
            Network,
            /// <summary>
            /// Network name displayed by SPN or Network
            /// </summary>
            Any
        }

        /// <summary>
        /// Enumeration for the possible 'default' Data Subscriptions for Packet Switched(PS).
        /// </summary>
        public enum DefaultDataSubscription
        {
            /// <summary>
            /// Unknown status
            /// </summary>
            Unknown = -1,
            /// <summary>
            /// SIM 1
            /// </summary>
            Sim1,
            /// <summary>
            /// SIM 2
            /// </summary>
            Sim2
        }

        /// <summary>
        /// Enumeration defines possible 'default' Subscriptions for Circuit Switched(CS).
        /// </summary>
        public enum DefaultSubscription
        {
            /// <summary>
            /// Unknown status
            /// </summary>
            Unknown = -1,
            /// <summary>
            /// SIM 1 network
            /// </summary>
            Sim1,
            /// <summary>
            /// SIM 2 network
            /// </summary>
            Sim2
        }

        /// <summary>
        /// Enumeration for network selection mode.
        /// </summary>
        public enum SelectionMode
        {
            /// <summary>
            /// Automatic mode
            /// </summary>
            Automatic,
            /// <summary>
            /// Manual mode
            /// </summary>
            Manual,
            /// <summary>
            /// Unavailable
            /// </summary>
            Unavailable
        }

        /// <summary>
        /// Gets the LAC (Location Area Code) of the current location.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/location.coarse
        /// </privilege>
        /// <remarks>
        /// This API can be used in GSM / WCDMA network.
        /// </remarks>
        /// <returns>
        /// The Location Area Code, -1 if unknown
        /// </returns>
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
        /// <privilege>
        /// http://tizen.org/privilege/location.coarse
        /// </privilege>
        /// <remarks>
        /// This API can be used in GSM / WCDMA / LTE network.
        /// </remarks>
        /// <returns>
        /// The cell identification number, -1 if unknown
        /// </returns>
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
        /// <privilege>
        /// http://tizen.org/privilege/telephony
        /// </privilege>
        /// <returns>
        /// The Received Signal Strength Indicator
        /// Higher the received number, the stronger the signal strength.
        /// </returns>
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
        /// <privilege>
        /// http://tizen.org/privilege/telephony
        /// </privilege>
        /// <returns>
        /// true if roaming, otherwise false if not roaming
        /// </returns>
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
        /// <privilege>
        /// http://tizen.org/privilege/telephony
        /// </privilege>
        /// <remarks>
        /// This API can be used in GSM / WCDMA / LTE network.
        /// </remarks>
        /// <returns>
        /// The Mobile Country Code (three digits) Mobile Country Code (MCC) identifies the country where the cell is being used.
        /// empty string if unknown.
        /// </returns>
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
        /// <privilege>
        /// http://tizen.org/privilege/telephony
        /// </privilege>
        /// <remarks>
        /// This API can be used in GSM / WCDMA / LTE network.
        /// </remarks>
        /// <returns>
        /// The Mobile Network Code (three digits) The Mobile Network Code (MNC) identifies the mobile phone operator and network provider.
        /// empty string if unknown.
        /// </returns>
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
        /// <privilege>
        /// http://tizen.org/privilege/telephony
        /// </privilege>
        /// <remarks>
        /// This API can be used in GSM / WCDMA / LTE network.
        /// </remarks>
        /// <returns>
        /// The name of the current registered network
        /// empty string if unknown.
        /// </returns>
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
        /// <privilege>
        /// http://tizen.org/privilege/telephony
        /// </privilege>
        /// <remarks>
        /// This API can be used in case network is in service.
        /// </remarks>
        /// <returns>
        /// The network service type
        /// </returns>
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
        /// <privilege>
        /// http://tizen.org/privilege/telephony
        /// </privilege>
        /// <remarks>
        /// This API can be used in HSDPA network.
        /// </remarks>
        /// <returns>
        /// The type of packet service
        /// </returns>
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
        /// <privilege>
        /// http://tizen.org/privilege/telephony
        /// </privilege>
        /// <returns>
        /// The network name display option
        /// </returns>
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
        /// <privilege>
        /// http://tizen.org/privilege/telephony
        /// </privilege>
        /// <returns>
        /// The current network state
        /// </returns>
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
        /// Gets the current default subscription for data service (Packet Switched).
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/telephony
        /// </privilege>
        /// <returnns>
        /// The current default data subscription
        /// </returnns>
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
        /// Gets the current default subscription for voice service (Circuit Switched).
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/telephony
        /// </privilege>
        /// <returnns>
        /// The current default voice subscription
        /// </returnns>
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
        /// <privilege>
        /// http://tizen.org/privilege/telephony
        /// </privilege>
        /// <returns>
        /// The network selection mode.
        /// </returns>
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
        /// <privilege>
        /// http://tizen.org/privilege/telephony
        /// </privilege>
        /// <remarks>
        /// This API can be used in LTE network.
        /// </remarks>
        /// <returns>
        /// The Tracking Area Code
        /// -1 if unknown
        /// </returns>
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
        /// <privilege>
        /// http://tizen.org/privilege/telephony
        /// </privilege>
        /// <remarks>
        /// This API can be used in CDMA network.
        /// </remarks>
        /// <returns>
        /// The system ID
        /// -1 if unknown
        /// </returns>
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
        /// <privilege>
        /// http://tizen.org/privilege/location.coarse
        /// </privilege>
        /// <remarks>
        /// This API can be used in CDMA network.
        /// </remarks>
        /// <returns>
        /// The network ID
        /// -1 if unknown
        /// </returns>
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
        /// <privilege>
        /// http://tizen.org/privilege/location.coarse
        /// </privilege>
        /// <remarks>
        /// This API can be used in CDMA network.
        /// </remarks>
        /// <returns>
        /// The base station ID
        /// -1 if unknown
        /// </returns>

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
        /// <privilege>
        /// http://tizen.org/privilege/location.coarse
        /// </privilege>
        /// <remarks>
        /// This API can be used in CDMA network.
        /// </remarks>
        /// <returns>
        /// The base station latitude
        /// 0x7FFFFFFF if unknown
        /// </returns>
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
        /// <privilege>
        /// http://tizen.org/privilege/location.coarse
        /// </privilege>
        /// <remarks>
        /// This API can be used in CDMA network.
        /// </remarks>
        /// <returns>
        /// The base station latitude
        /// 0x7FFFFFFF if unknown
        /// </returns>
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
