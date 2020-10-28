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

using System;
using System.Collections.Generic;

namespace Tizen.Tapi
{
    /// <summary>
    /// A class which defines network registration status.
    /// </summary>
    public class NetworkRegistrationStatus
    {
        internal NetworkServiceLevel Cs;
        internal NetworkServiceLevel Ps;
        internal NetworkServiceType SvcType;
        internal bool Roaming;

        internal NetworkRegistrationStatus()
        {
        }

        /// <summary>
        /// Circuit Switched status.
        /// </summary>
        /// <value>Status of circuit switched data.</value>
        public NetworkServiceLevel CircuitStatus
        {
            get
            {
                return Cs;
            }
        }

        /// <summary>
        /// Packet Switched status.
        /// </summary>
        /// <value>Status of packet switched data.</value>
        public NetworkServiceLevel PacketStatus
        {
            get
            {
                return Ps;
            }
        }

        /// <summary>
        /// Registration service type.
        /// </summary>
        /// <value>Service type represented in NetworkServiceType enum.</value>
        public NetworkServiceType Type
        {
            get
            {
                return SvcType;
            }
        }

        /// <summary>
        /// Roaming status
        /// </summary>
        /// <value>Boolean value to check the roaming status.</value>
        public bool IsRoaming
        {
            get
            {
                return Roaming;
            }
        }
    }

    /// <summary>
    /// A class which defines network cell info notification.
    /// </summary>
    public class NetworkCellNoti
    {
        internal int Location;
        internal int Id;

        internal NetworkCellNoti()
        {
        }

        /// <summary>
        /// Location Area Code (In case of LTE network, it represents Tracking Area Code).
        /// </summary>
        /// <value>Location area code represented in integer.</value>
        public int Lac
        {
            get
            {
                return Location;
            }
        }

        /// <summary>
        /// Cell ID.
        /// </summary>
        /// <value>Cell id represented in integer.</value>
        public int CellId
        {
            get
            {
                return Id;
            }
        }
    }

    /// <summary>
    /// A class which defines network change notification.
    /// </summary>
    public class NetworkChangeNoti
    {
        internal NetworkSystemType Type;
        internal string NwPlmn;

        internal NetworkChangeNoti()
        {
        }

        /// <summary>
        /// Access technology.
        /// </summary>
        /// <value>Access technology represented in NetworkSystemType enum.</value>
        public NetworkSystemType Act
        {
            get
            {
                return Type;
            }
        }

        /// <summary>
        /// Network PLMN.
        /// </summary>
        /// <value>Plmn value represented as string.</value>
        public string Plmn
        {
            get
            {
                return NwPlmn;
            }
        }
    }

    /// <summary>
    /// A class which defines network time notification.
    /// </summary>
    public class NetworkTimeNoti
    {
        internal DateTime TimeInfo;
        internal int WDayInfo;
        internal int GmtOffInfo;
        internal int DstOffInfo;
        internal bool Dst;
        internal string NetworkPlmn;

        internal NetworkTimeNoti()
        {
        }

        /// <summary>
        /// Date time information.
        /// </summary>
        /// <value>An instance of DateTime representing date time information.</value>
        public DateTime Time
        {
            get
            {
                return TimeInfo;
            }
        }

        /// <summary>
        /// Wday information.
        /// </summary>
        /// <value>Wday info represented in integer.</value>
        public int WDay
        {
            get
            {
                return WDayInfo;
            }
        }

        /// <summary>
        /// GMT Off.
        /// </summary>
        /// <value>GMT off info represented in integer.</value>
        public int GmtOff
        {
            get
            {
                return GmtOffInfo;
            }
        }

        /// <summary>
        /// DST Off.
        /// </summary>
        /// <value>DST off info represented in integer.</value>
        public int DstOff
        {
            get
            {
                return DstOffInfo;
            }
        }

        /// <summary>
        /// Flag for checking if it is DST.
        /// </summary>
        /// <value>Boolean value to check if the time is DST or not.</value>
        public bool IsDst
        {
            get
            {
                return Dst;
            }
        }

        /// <summary>
        /// Network PLMN.
        /// </summary>
        /// <value>PLMN value represented in string.</value>
        public string Plmn
        {
            get
            {
                return NetworkPlmn;
            }
        }
    }

    /// <summary>
    /// A class which defines network identity notification.
    /// </summary>
    public class NetworkIdentityNoti
    {
        internal string NwPlmn;
        internal string NwShortName;
        internal string NwFullName;

        internal NetworkIdentityNoti()
        {
        }

        /// <summary>
        /// Network PLMN.
        /// </summary>
        /// <value>Plmn value represented in string.</value>
        public string Plmn
        {
            get
            {
                return NwPlmn;
            }
        }

        /// <summary>
        /// Short network name.
        /// </summary>
        /// <value>Short name of the network in string.</value>
        public string ShortName
        {
            get
            {
                return NwShortName;
            }
        }

        /// <summary>
        /// Full network name.
        /// </summary>
        /// <value>Full name of the network in string.</value>
        public string FullName
        {
            get
            {
                return NwFullName;
            }
        }
    }

    /// <summary>
    /// A class which defines network VoLTE status notification.
    /// </summary>
    public class NetworkVolteStatus
    {
        internal bool NwIsRegistered;
        internal int NwFeatureMask;
        internal VolteNetworkType NwType;

        internal NetworkVolteStatus()
        {
        }

        /// <summary>
        /// VoLTE status.
        /// </summary>
        /// <value>Boolean value to check if it is registered.</value>
        public bool IsRegistered
        {
            get
            {
                return NwIsRegistered;
            }
        }

        /// <summary>
        /// Services registered for.
        /// </summary>
        /// <value>Service mask represented in integer.</value>
        public int FeatureMask
        {
            get
            {
                return NwFeatureMask;
            }
        }

        /// <summary>
        /// Network on which VoLTE is registered.
        /// </summary>
        /// <value>Type of VoLTE network represented in VolteNetworkType enum.</value>
        public VolteNetworkType Type
        {
            get
            {
                return NwType;
            }
        }
    }

    /// <summary>
    /// A class which defines network identity.
    /// </summary>
    public class NetworkIdentity
    {
        internal string IdName;
        internal string SvcProviderName;
        internal string PlmnName;
        internal uint Id;
        internal NetworkPlmnType PlmnNwType;
        internal NetworkSystemType SysType;
        internal NetworkIdentity()
        {
        }

        /// <summary>
        /// Network name.
        /// </summary>
        public string Name
        {
            get
            {
                return IdName;
            }
        }

        /// <summary>
        /// Service provider name.
        /// </summary>
        public string ServiceProviderName
        {
            get
            {
                return SvcProviderName;
            }
        }

        /// <summary>
        /// Network plmn.
        /// </summary>
        public string Plmn
        {
            get
            {
                return PlmnName;
            }
        }

        /// <summary>
        /// Plmn Id.
        /// </summary>
        public uint PlmnId
        {
            get
            {
                return Id;
            }
        }

        /// <summary>
        /// Plmn type.
        /// </summary>
        public NetworkPlmnType PlmnType
        {
            get
            {
                return PlmnNwType;
            }
        }

        /// <summary>
        /// Access technology.
        /// </summary>
        public NetworkSystemType SystemType
        {
            get
            {
                return SysType;
            }
        }
    }

    /// <summary>
    /// A class for the network plmn list.
    /// </summary>
    public class NetworkPlmnList
    {
        internal byte NwCount;
        internal IEnumerable<NetworkIdentity> NwList;

        internal NetworkPlmnList()
        {
        }

        /// <summary>
        /// Network plmn count.
        /// </summary>
        /// <value>Count of the network plmn.</value>
        public byte NetworkCount
        {
            get
            {
                return NwCount;
            }
        }

        /// <summary>
        /// Network list.
        /// </summary>
        /// <value>List of NetworkIdentity.</value>
        public IEnumerable<NetworkIdentity> NetworkList
        {
            get
            {
                return NwList;
            }
        }
    }

    /// <summary>
    /// A class which defines the preferred plmn information.
    /// </summary>
    public class NetworkPreferredPlmnInfo
    {
        internal byte idex;
        internal string NwPlmn;
        internal string NwName;
        internal string SvcProvName;
        internal NetworkSystemType SysType;

        /// <summary>
        /// Preferred plmn list index.
        /// </summary>
        ///<value>Index of preferred plmn list.</value>
        public byte Index
        {
            get
            {
                return idex;
            }

            set
            {
                idex = value;
            }
        }

        /// <summary>
        /// Preferred plmn.
        /// </summary>
        /// <value>Plmn string.</value>
        public string Plmn
        {
            get
            {
                return NwPlmn;
            }

            set
            {
                NwPlmn = value;
            }
        }

        /// <summary>
        /// Network name.
        /// </summary>
        /// <value>Name of network.</value>
        public string NetworkName
        {
            get
            {
                return NwName;
            }

            set
            {
                NwName = value;
            }
        }

        /// <summary>
        /// Service provider name.
        /// </summary>
        /// <value>Name of service provider.</value>
        public string ServiceProviderName
        {
            get
            {
                return SvcProvName;
            }

            set
            {
                SvcProvName = value;
            }
        }

        /// <summary>
        /// System type of network.
        /// </summary>
        /// <value>System type of network.</value>
        public NetworkSystemType SystemType
        {
            get
            {
                return SysType;
            }

            set
            {
                SysType = value;
            }
        }
    }

    /// <summary>
    /// A class containing information related to a cdma system.
    /// </summary>
    public class NetworkCdmaSysInfo
    {
        internal int Car;
        internal uint SysId;
        internal uint NwId;
        internal uint BaseStnId;
        internal int BaseStnLatitude;
        internal int BaseStnLongitude;
        internal uint RegZone;
        internal uint Offset;
        internal NetworkCdmaSysInfo()
        {
        }

        /// <summary>
        /// Cdma carrier.
        /// </summary>
        /// <value>Cdma carrier.</value>
        public int Carrier
        {
            get
            {
                return Car;
            }
        }

        /// <summary>
        /// System Id.
        /// </summary>
        /// <value>System Id.</value>
        public uint SystemId
        {
            get
            {
                return SysId;
            }
        }

        /// <summary>
        /// Network Id.
        /// </summary>
        /// <value>Id of network.</value>
        public uint NetworkId
        {
            get
            {
                return NwId;
            }
        }

        /// <summary>
        /// Base station Id.
        /// </summary>
        /// <value>Id of base station.</value>
        public uint BaseStationId
        {
            get
            {
                return BaseStnId;
            }
        }

        /// <summary>
        /// Latitude of the current base station.
        /// </summary>
        /// <value>Latitude of the current base station.</value>
        public int BaseStationLatitude
        {
            get
            {
                return BaseStnLatitude;
            }
        }

        /// <summary>
        /// Longitude of the current base station.
        /// </summary>
        /// <value>Longitude of the current base station.</value>
        public int BaseStationLongitude
        {
            get
            {
                return BaseStnLongitude;
            }
        }

        /// <summary>
        /// Registration zone.
        /// </summary>
        /// <value>Registration zone.</value>
        public uint RegistrationZone
        {
            get
            {
                return RegZone;
            }
        }

        /// <summary>
        /// Pilot offset.
        /// </summary>
        /// <value>Offset of pilot.</value>
        public uint PilotOffset
        {
            get
            {
                return Offset;
            }
        }
    }

    /// <summary>
    /// A class containing information about network area.
    /// </summary>
    public class NetworkAreaInfo
    {
        internal int Code;
        internal NetworkCdmaSysInfo Cdma;
        internal NetworkAreaInfo()
        {
        }

        /// <summary>
        /// Location area code.
        /// </summary>
        /// <value>Area code of location.</value>
        public int Lac
        {
            get
            {
                return Code;
            }
        }

        /// <summary>
        /// Instance of NetworkCdmaSysInfo.
        /// </summary>
        /// <value>Instance of NetworkCdmaSysInfo.</value>
        public NetworkCdmaSysInfo CdmaInfo
        {
            get
            {
                return Cdma;
            }
        }
    }

    /// <summary>
    /// A class containing information of serving network.
    /// </summary>
    public class NetworkServing
    {
        internal NetworkSystemType Type;
        internal string NwPlmn;
        internal NetworkAreaInfo Area;
        internal NetworkServing()
        {
        }

        /// <summary>
        /// Access technology.
        /// </summary>
        /// <value>System type of network.</value>
        public NetworkSystemType SystemType
        {
            get
            {
                return Type;
            }
        }

        /// <summary>
        /// Network plmn.
        /// </summary>
        /// <value>Plmn of network.</value>
        public string Plmn
        {
            get
            {
                return NwPlmn;
            }
        }

        /// <summary>
        /// Area information of network.
        /// </summary>
        /// <value>Instance of NetworkAreaInfo.</value>
        public NetworkAreaInfo AreaInfo
        {
            get
            {
                return Area;
            }
        }
    }

    /// <summary>
    /// A class containing information of cdma cell.
    /// </summary>
    public class NetworkCdmaCell
    {
        internal uint SysId;
        internal uint NwId;
        internal uint BaseStnId;
        internal uint RefPn;
        internal int BaseStnLatitude;
        internal int BaseStnLongitude;
        internal NetworkCdmaCell()
        {
        }

        /// <summary>
        /// System Id info.
        /// </summary>
        /// <value>System Id.</value>
        public uint SystemId
        {
            get
            {
                return SysId;
            }
        }

        /// <summary>
        /// Network Id.
        /// </summary>
        /// <value>Network Id.</value>
        public uint NetworkId
        {
            get
            {
                return NwId;
            }
        }

        /// <summary>
        /// Base station Id.
        /// </summary>
        /// <value>Base station id.</value>
        public uint BaseStationId
        {
            get
            {
                return BaseStnId;
            }
        }

        /// <summary>
        /// Reference pn.
        /// </summary>
        /// <value>Reference pn.</value>
        public uint ReferencePn
        {
            get
            {
                return RefPn;
            }
        }

        /// <summary>
        /// Latitude of the current base station.
        /// </summary>
        /// <value>Latitude of the current base station.</value>
        public int BaseStationLatitude
        {
            get
            {
                return BaseStnLatitude;
            }
        }

        /// <summary>
        /// Longitude of the current base station.
        /// </summary>
        /// <value>Longitude of the current base station.</value>
        public int BaseStationLongitude
        {
            get
            {
                return BaseStnLongitude;
            }
        }
    }

    /// <summary>
    /// A class containing information of lte cell.
    /// </summary>
    public class NetworkLteCell
    {
        internal int Id;
        internal int Lc;
        internal int PId;
        internal int Erf;
        internal int Tc;
        internal int Rs;
        internal NetworkLteCell()
        {
        }

        /// <summary>
        /// Value of cell Id. -1 indicates that cell Id information is not present.
        /// </summary>
        /// <value>Cell Id.</value>
        public int CellId
        {
            get
            {
                return Id;
            }
        }

        /// <summary>
        /// Location area code. This field is ignored when CellId is not present.
        /// </summary>
        /// <value>Code of area.</value>
        public int Lac
        {
            get
            {
                return Lc;
            }
        }

        /// <summary>
        /// Physical cell id info.
        /// </summary>
        /// <value>Physical cell id.</value>
        public int PhysicalId
        {
            get
            {
                return PId;
            }
        }

        /// <summary>
        /// E-Utra absolute rf channel number.
        /// </summary>
        /// <value>E-Utra absolute rf channel number.</value>
        public int Earfcn
        {
            get
            {
                return Erf;
            }
        }

        /// <summary>
        /// Tracking area code.
        /// </summary>
        /// <value>Area code for tracking.</value>
        public int Tac
        {
            get
            {
                return Tc;
            }
        }

        /// <summary>
        /// Rssi in dBm(signed)
        /// </summary>
        /// <value>Rssi in dBm.</value>
        public int Rssi
        {
            get
            {
                return Rs;
            }
        }
    }

    /// <summary>
    /// A class containing information of umts cell.
    /// </summary>
    public class NetworkUmtsCell
    {
        internal int Id;
        internal int Lc;
        internal int Arf;
        internal int Ps;
        internal int Rsc;
        internal NetworkUmtsCell()
        {
        }

        /// <summary>
        /// Ucid. -1 indicates that cell Id information is not present.
        /// </summary>
        /// <value>RNCID + Cell ID(16 bit).</value>
        public int CellId
        {
            get
            {
                return Id;
            }
        }

        /// <summary>
        /// Location area code. This field is ignored when CellId is not present.
        /// </summary>
        /// <value>Code of area.</value>
        public int Lac
        {
            get
            {
                return Lc;
            }
        }

        /// <summary>
        /// Utra absolute rf channel number.
        /// </summary>
        /// <value>Utra absolute rf channel number.</value>
        public int Arfcn
        {
            get
            {
                return Arf;
            }
        }

        /// <summary>
        /// Primary scrambling code.
        /// </summary>
        /// <value>Primary scrambling code.</value>
        public int Psc
        {
            get
            {
                return Ps;
            }
        }

        /// <summary>
        /// Received signal code power. Valid values are (0-96, 255).
        /// </summary>
        /// <value>Power of received signal code.</value>
        public int Rscp
        {
            get
            {
                return Rsc;
            }
        }

    }

    /// <summary>
    /// A class containing information of geran cell.
    /// </summary>
    public class NetworkGeranCell
    {
        internal int Id;
        internal int Lc;
        internal int Bc;
        internal int Bs;
        internal int Rx;
        internal NetworkGeranCell()
        {
        }

        /// <summary>
        /// Value of cell Id. -1 indicates that cell Id information is not present.
        /// </summary>
        /// <value>Cell Id.</value>
        public int CellId
        {
            get
            {
                return Id;
            }
        }

        /// <summary>
        /// Location area code. This field is ignored when CellId is not present.
        /// </summary>
        /// <value>Code of area.</value>
        public int Lac
        {
            get
            {
                return Lc;
            }
        }

        /// <summary>
        /// Broadcast control channel frequency number.
        /// </summary>
        /// <value>Broadcast control channel frequency number.</value>
        public int Bcch
        {
            get
            {
                return Bc;
            }
        }

        /// <summary>
        /// Base station identification code.
        /// </summary>
        /// <value>Id code of base station.</value>
        public int Bsic
        {
            get
            {
                return Bs;
            }
        }

        /// <summary>
        /// Received signal strength level. Valid values are (0-63, 99).
        /// </summary>
        /// <value>Strength of received signal.</value>
        public int Rxlev
        {
            get
            {
                return Rx;
            }
        }
    }

    /// <summary>
    /// A class which contains geran, umts, cdma and lte cell information.
    /// </summary>
    public class Cell
    {
        internal NetworkGeranCell Geran;
        internal NetworkCdmaCell Cdma;
        internal NetworkUmtsCell Umts;
        internal NetworkLteCell Lte;
        internal Cell()
        {
        }

        /// <summary>
        /// Geran cell information.
        /// </summary>
        /// <value>Instance of NetworkGeranCell.</value>
        public NetworkGeranCell GeranCell
        {
            get
            {
                return Geran;
            }
        }

        /// <summary>
        /// Cdma cell information.
        /// </summary>
        /// <value>Instance of NetworkCdmaCell.</value>
        public NetworkCdmaCell CdmaCell
        {
            get
            {
                return Cdma;
            }
        }

        /// <summary>
        /// Umts cell information.
        /// </summary>
        /// <value>Instance of NetworkUmtsCell.</value>
        public NetworkUmtsCell UmtsCell
        {
            get
            {
                return Umts;
            }
        }

        /// <summary>
        /// Lte cell information.
        /// </summary>
        /// <value>Instance of NetworkLteCell.</value>
        public NetworkLteCell LteCell
        {
            get
            {
                return Lte;
            }
        }
    }

    /// <summary>
    /// A class which contains serving cell information.
    /// </summary>
    public class NetworkServingCell
    {
        internal NetworkSystemType SysType;
        internal int MCountryCode;
        internal int MNwCode;
        internal Cell Info;
        internal NetworkServingCell()
        {
        }

        /// <summary>
        /// Access technology.
        /// </summary>
        /// <value>Network system type.</value>
        public NetworkSystemType SystemType
        {
            get
            {
                return SysType;
            }
        }

        /// <summary>
        /// Mobile country code.
        /// </summary>
        /// <value>Country code of the mobile.</value>
        public int MobileCountryCode
        {
            get
            {
                return MCountryCode;
            }
        }

        /// <summary>
        /// Mobile network code.
        /// </summary>
        /// <value>Network code of the mobile.</value>
        public int MobileNetworkCode
        {
            get
            {
                return MNwCode;
            }
        }

        /// <summary>
        /// Information of cell.
        /// </summary>
        ///<value>Instance of Cell.</value>
        public Cell CellInfo
        {
            get
            {
                return Info;
            }
        }
    }

    /// <summary>
    /// A class which contains neighboring cell information.
    /// </summary>
    public class NetworkNeighboringCell
    {
        internal NetworkServingCell ServCell;
        internal IEnumerable<NetworkGeranCell> GrList;
        internal IEnumerable<NetworkUmtsCell> UmtList;
        internal IEnumerable<NetworkLteCell> LtList;
        internal NetworkNeighboringCell()
        {
        }

        /// <summary>
        /// Serving cell information.
        /// </summary>
        /// <value>Instance of NetworkServingCell.</value>
        public NetworkServingCell ServingCell
        {
            get
            {
                return ServCell;
            }
        }

        /// <summary>
        /// Geran cell info list.
        /// </summary>
        /// <value>List of NetworkGeranCell.</value>
        public IEnumerable<NetworkGeranCell> GeranList
        {
            get
            {
                return GrList;
            }
        }

        /// <summary>
        /// Umts cell info list.
        /// </summary>
        /// <value>List of NetworkUmtsCell.</value>
        public IEnumerable<NetworkUmtsCell> UmtsList
        {
            get
            {
                return UmtList;
            }
        }

        /// <summary>
        /// Lte cell info list.
        /// </summary>
        /// <value>List of NetworkLteCell.</value>
        public IEnumerable<NetworkLteCell> LteList
        {
            get
            {
                return LtList;
            }
        }
    }
}
