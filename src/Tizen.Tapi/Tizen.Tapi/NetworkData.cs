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
}
