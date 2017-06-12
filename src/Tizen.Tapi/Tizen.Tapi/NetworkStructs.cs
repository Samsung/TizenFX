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
using System.Runtime.InteropServices;

namespace Tizen.Tapi
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct NetworkRegistrationStatusStruct
    {
        internal NetworkServiceLevel Cs;
        internal NetworkServiceLevel Ps;
        internal NetworkServiceType Type;
        internal int IsRoaming;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct NetworkCellNotiStruct
    {
        internal int Lac;
        internal int CellId;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct NetworkChangeNotiStruct
    {
        internal NetworkSystemType Act;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        internal string Plmn;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct NetworkTimeNotiStruct
    {
        internal int Year;
        internal int Month;
        internal int Day;
        internal int Hour;
        internal int Minute;
        internal int Second;
        internal int WDay;
        internal int GmtOff;
        internal int DstOff;
        internal int IsDst;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        internal string Plmn;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct NetworkIdentityNotiStruct
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        internal string Plmn;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 17)]
        internal string ShortName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        internal string FullName;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct NetworkVolteStatusStruct
    {
        internal int IsRegistered;
        internal int FeatureMask;
        internal VolteNetworkType NetworkType;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct NetworkPreferredPlmnStruct
    {
        internal byte Index;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst=7)]
        internal string Plmn;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst=41)]
        internal string NetworkName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst=41)]
        internal string SnName;
        internal NetworkSystemType Type;
    }

    internal static class NetworkStructConversions
    {
        internal static NetworkRegistrationStatus ConvertNetworkRegistrationStruct(NetworkRegistrationStatusStruct statusStruct)
        {
            NetworkRegistrationStatus status = new NetworkRegistrationStatus();
            status.Cs = statusStruct.Cs;
            status.Ps = statusStruct.Ps;
            status.SvcType = statusStruct.Type;
            if (statusStruct.IsRoaming == 1)
            {
                status.Roaming = true;
            }

            else if (statusStruct.IsRoaming == 0)
            {
                status.Roaming = false;
            }

            return status;
        }

        internal static NetworkCellNoti ConvertNetworkCellNotiStruct(NetworkCellNotiStruct notiStruct)
        {
            NetworkCellNoti noti = new NetworkCellNoti();
            noti.Location = notiStruct.Lac;
            noti.Id = notiStruct.CellId;
            return noti;
        }

        internal static NetworkChangeNoti ConvertNetworkChangeStruct(NetworkChangeNotiStruct changeStruct)
        {
            NetworkChangeNoti changeNoti = new NetworkChangeNoti();
            changeNoti.Type = changeStruct.Act;
            changeNoti.NwPlmn = changeStruct.Plmn;
            return changeNoti;
        }

        internal static NetworkTimeNoti ConvertNetworkTimeNotiStruct(NetworkTimeNotiStruct notiStruct)
        {
            NetworkTimeNoti time = new NetworkTimeNoti();
            time.TimeInfo = new DateTime(notiStruct.Year, notiStruct.Month, notiStruct.Day, notiStruct.Hour, notiStruct.Minute, notiStruct.Second);
            time.WDayInfo = notiStruct.WDay;
            time.GmtOffInfo = notiStruct.GmtOff;
            time.DstOffInfo = notiStruct.DstOff;
            if (notiStruct.IsDst == 1)
            {
                time.Dst = true;
            }

            else if (notiStruct.IsDst == 0)
            {
                time.Dst = false;
            }

            time.NetworkPlmn = notiStruct.Plmn;
            return time;
        }

        internal static NetworkIdentityNoti ConvertNetworkIdentityStruct(NetworkIdentityNotiStruct notiStruct)
        {
            NetworkIdentityNoti identity = new NetworkIdentityNoti();
            identity.NwPlmn = notiStruct.Plmn;
            identity.NwShortName = notiStruct.ShortName;
            identity.NwFullName = notiStruct.FullName;
            return identity;
        }

        internal static NetworkVolteStatus ConvertNetworkVolteStruct(NetworkVolteStatusStruct notiStruct)
        {
            NetworkVolteStatus volteStatus = new NetworkVolteStatus();
            if (notiStruct.IsRegistered == 1)
            {
                volteStatus.NwIsRegistered = true;
            }

            else if (notiStruct.IsRegistered == 0)
            {
                volteStatus.NwIsRegistered = false;
            }

            volteStatus.NwFeatureMask = notiStruct.FeatureMask;
            volteStatus.NwType = notiStruct.NetworkType;
            return volteStatus;
        }
    }
}
