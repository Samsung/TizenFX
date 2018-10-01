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
using System.Collections.Generic;
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

    [StructLayout(LayoutKind.Sequential)]
    internal struct NetworkIdentityStruct
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        internal string NwName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        internal string SvcName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        internal string NwPlmn;
        internal uint PlmnId;
        internal NetworkPlmnType Type;
        internal NetworkSystemType Act;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct NetworkPlmnListStruct
    {
        internal byte NwCount;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.LPStruct)]
        internal NetworkIdentityStruct[] NwList;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct NetworkPreferredPlmnListStruct
    {
        internal uint Count;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 150, ArraySubType = UnmanagedType.LPStruct)]
        internal NetworkPreferredPlmnStruct[] PlmnList;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct NetworkCdmaSysStruct
    {
        internal int Carrier;
        internal uint SysId;
        internal uint NwId;
        internal uint BaseStnId;
        internal int BaseStnLatitude;
        internal int BaseStnLongitude;
        internal uint RegZone;
        internal uint Offset;
    }

    [StructLayout(LayoutKind.Explicit)]
    internal struct NetworkAreaStruct
    {
        [FieldOffset(0)]
        internal int Lac;
        [FieldOffset(0)]
        internal NetworkCdmaSysStruct Cdma;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct NetworkServingStruct
    {
        internal NetworkSystemType SysType;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        internal string Plmn;
        internal NetworkAreaStruct Area;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct NetworkGeranCellStruct
    {
        internal int CellId;
        internal int Lac;
        internal int Bcch;
        internal int Bsic;
        internal int Rxlev;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct NetworkUmtsCellStruct
    {
        internal int CellId;
        internal int Lac;
        internal int Arfcn;
        internal int Psc;
        internal int Rscp;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct NetworkLteCellStruct
    {
        internal int CellId;
        internal int Lac;
        internal int Pcid;
        internal int Earfcn;
        internal int Tac;
        internal int Rssi;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct NetworkCdmaCellStruct
    {
        internal uint SystemId;
        internal uint NetworkId;
        internal uint BaseId;
        internal uint RefPn;
        internal int BaseStnLatitude;
        internal int BaseStnLongitude;
    }

    [StructLayout(LayoutKind.Explicit)]
    internal struct CellStruct
    {
        [FieldOffset(0)]
        internal NetworkGeranCellStruct Geran;
        [FieldOffset(0)]
        internal NetworkUmtsCellStruct Umts;
        [FieldOffset(0)]
        internal NetworkLteCellStruct Lte;
        [FieldOffset(0)]
        internal NetworkCdmaCellStruct Cdma;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct NetworkServingCellStruct
    {
        internal NetworkSystemType SystemType;
        internal int MobileCountryCode;
        internal int MobileNetworkCode;
        internal CellStruct Cell;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct NetworkNeighboringCellStruct
    {
        internal NetworkServingCellStruct ServCell;
        internal int GeranCount;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6, ArraySubType = UnmanagedType.LPStruct)]
        internal NetworkGeranCellStruct[] GeranList;
        internal int UmtsCount;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 24, ArraySubType = UnmanagedType.LPStruct)]
        internal NetworkUmtsCellStruct[] UmtsList;
        internal int LteCount;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 24, ArraySubType = UnmanagedType.LPStruct)]
        internal NetworkLteCellStruct[] LteList;
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

        internal static NetworkPlmnList ConvertNetworkPlmnListStruct(NetworkPlmnListStruct listStruct)
        {
            NetworkPlmnList plmnList = new NetworkPlmnList();
            List<NetworkIdentity> records = new List<NetworkIdentity>();

            foreach (NetworkIdentityStruct idStruct in listStruct.NwList)
            {
                NetworkIdentity identity = new NetworkIdentity();
                identity.Id = idStruct.PlmnId;
                identity.SvcProviderName = idStruct.SvcName;
                identity.IdName = idStruct.NwName;
                identity.PlmnName = idStruct.NwPlmn;
                identity.PlmnNwType = idStruct.Type;
                identity.SysType = idStruct.Act;
                records.Add(identity);
            }

            plmnList.NwCount = listStruct.NwCount;
            plmnList.NwList = records;
            return plmnList;
        }

        internal static IEnumerable<NetworkPreferredPlmnInfo> ConvertNetworkPreferredPlmnStruct(NetworkPreferredPlmnListStruct plmnStruct)
        {
            List<NetworkPreferredPlmnInfo> plmnList = new List<NetworkPreferredPlmnInfo>();

            for (int i = 0; i <= plmnStruct.Count; i++)
            {
                NetworkPreferredPlmnInfo plmnInfo = new NetworkPreferredPlmnInfo();
                plmnInfo.idex = plmnStruct.PlmnList[i].Index;
                plmnInfo.NwName = plmnStruct.PlmnList[i].NetworkName;
                plmnInfo.NwPlmn = plmnStruct.PlmnList[i].Plmn;
                plmnInfo.SvcProvName = plmnStruct.PlmnList[i].SnName;
                plmnInfo.SysType = plmnStruct.PlmnList[i].Type;
                plmnList.Add(plmnInfo);
            }

            return plmnList;
        }

        internal static NetworkCdmaSysInfo ConvertCdmaStruct(NetworkCdmaSysStruct cdmaStruct)
        {
            NetworkCdmaSysInfo cdmaInfo = new NetworkCdmaSysInfo();
            cdmaInfo.Car = cdmaStruct.Carrier;
            cdmaInfo.BaseStnId = cdmaStruct.BaseStnId;
            cdmaInfo.BaseStnLatitude = cdmaStruct.BaseStnLatitude;
            cdmaInfo.BaseStnLongitude = cdmaStruct.BaseStnLongitude;
            cdmaInfo.NwId = cdmaStruct.NwId;
            cdmaInfo.Offset = cdmaStruct.Offset;
            cdmaInfo.RegZone = cdmaStruct.RegZone;
            cdmaInfo.SysId = cdmaStruct.SysId;
            return cdmaInfo;
        }

        internal static NetworkServing ConvertNetworkServingStruct(NetworkServingStruct servStruct)
        {
            NetworkServing servingInfo = new NetworkServing();
            NetworkAreaStruct areaStruct = servStruct.Area;
            NetworkCdmaSysStruct cdmaStruct = areaStruct.Cdma;
            NetworkCdmaSysInfo cdmaInfo = ConvertCdmaStruct(cdmaStruct);

            NetworkAreaInfo areaInfo = new NetworkAreaInfo();
            areaInfo.Code = areaStruct.Lac;
            areaInfo.Cdma = cdmaInfo;

            servingInfo.NwPlmn = servStruct.Plmn;
            servingInfo.Type = servStruct.SysType;
            servingInfo.Area = areaInfo;

            return servingInfo;
        }

        internal static NetworkGeranCell ConvertGeranStruct(NetworkGeranCellStruct geranStruct)
        {
            NetworkGeranCell geranCell = new NetworkGeranCell();
            geranCell.Bc = geranStruct.Bcch;
            geranCell.Bs = geranStruct.Bsic;
            geranCell.Id = geranStruct.CellId;
            geranCell.Lc = geranStruct.Lac;
            geranCell.Rx = geranStruct.Rxlev;
            return geranCell;
        }

        internal static NetworkUmtsCell ConvertUmtsStruct(NetworkUmtsCellStruct umtsStruct)
        {
            NetworkUmtsCell umtsCell = new NetworkUmtsCell();
            umtsCell.Arf = umtsStruct.Arfcn;
            umtsCell.Id = umtsStruct.CellId;
            umtsCell.Lc = umtsStruct.Lac;
            umtsCell.Ps = umtsStruct.Psc;
            umtsCell.Rsc = umtsStruct.Rscp;
            return umtsCell;
        }

        internal static NetworkLteCell ConvertLteStruct(NetworkLteCellStruct lteStruct)
        {
            NetworkLteCell lteCell = new NetworkLteCell();
            lteCell.Id = lteStruct.CellId;
            lteCell.Erf = lteStruct.Earfcn;
            lteCell.Lc = lteStruct.Lac;
            lteCell.PId = lteStruct.Pcid;
            lteCell.Tc = lteStruct.Tac;
            lteCell.Rs = lteStruct.Rssi;
            return lteCell;
        }

        internal static NetworkNeighboringCell ConvertNeighborCellStruct(NetworkNeighboringCellStruct neighborStruct)
        {
            NetworkNeighboringCell neighborCell = new NetworkNeighboringCell();
            NetworkServingCellStruct servStruct = neighborStruct.ServCell;
            CellStruct cellStruct = servStruct.Cell;
            NetworkGeranCellStruct geranStruct = cellStruct.Geran;
            NetworkCdmaCellStruct cdmaStruct = cellStruct.Cdma;
            NetworkUmtsCellStruct umtsStruct = cellStruct.Umts;
            NetworkLteCellStruct lteStruct = cellStruct.Lte;

            NetworkGeranCell geranCell = ConvertGeranStruct(geranStruct);

            NetworkCdmaCell cdmaCell = new NetworkCdmaCell();
            cdmaCell.BaseStnId = cdmaStruct.BaseId;
            cdmaCell.BaseStnLatitude = cdmaStruct.BaseStnLatitude;
            cdmaCell.BaseStnLongitude = cdmaStruct.BaseStnLongitude;
            cdmaCell.NwId = cdmaStruct.NetworkId;
            cdmaCell.RefPn = cdmaStruct.RefPn;
            cdmaCell.SysId = cdmaStruct.SystemId;

            NetworkUmtsCell umtsCell = ConvertUmtsStruct(umtsStruct);

            NetworkLteCell lteCell = ConvertLteStruct(lteStruct);

            Cell cell = new Cell();
            cell.Geran = geranCell;
            cell.Cdma = cdmaCell;
            cell.Umts = umtsCell;
            cell.Lte = lteCell;

            NetworkServingCell servingCell = new NetworkServingCell();
            servingCell.SysType = servStruct.SystemType;
            servingCell.MCountryCode = servStruct.MobileCountryCode;
            servingCell.MNwCode = servStruct.MobileNetworkCode;
            servingCell.Info = cell;

            neighborCell.ServCell = servingCell;
            List<NetworkGeranCell> geranCellList = new List<NetworkGeranCell>();
            for(int i=0;i<neighborStruct.GeranCount;i++)
            {
                NetworkGeranCell geran = ConvertGeranStruct(neighborStruct.GeranList[i]);
                geranCellList.Add(geran);
            }

            List<NetworkUmtsCell> umtsCellList = new List<NetworkUmtsCell>();
            for (int i = 0; i < neighborStruct.UmtsCount; i++)
            {
                NetworkUmtsCell umts = ConvertUmtsStruct(neighborStruct.UmtsList[i]);
                umtsCellList.Add(umts);
            }

            List<NetworkLteCell> lteCellList = new List<NetworkLteCell>();
            for (int i = 0; i < neighborStruct.GeranCount; i++)
            {
                NetworkLteCell lte = ConvertLteStruct(neighborStruct.LteList[i]);
                lteCellList.Add(lte);
            }

            neighborCell.GrList = geranCellList;
            neighborCell.UmtList = umtsCellList;
            neighborCell.LtList = lteCellList;
            return neighborCell;

        }
    }

    internal static class NetworkClassConversions
    {
        internal static NetworkPreferredPlmnStruct ConvertNetworkPreferredPlmn(NetworkPreferredPlmnInfo plmnInfo)
        {
            NetworkPreferredPlmnStruct plmnStruct = new NetworkPreferredPlmnStruct();
            plmnStruct.Index = plmnInfo.idex;
            plmnStruct.NetworkName = plmnInfo.NwName;
            plmnStruct.Plmn = plmnInfo.NwPlmn;
            plmnStruct.SnName = plmnInfo.SvcProvName;
            plmnStruct.Type = plmnInfo.SysType;
            return plmnStruct;
        }
    }
}
