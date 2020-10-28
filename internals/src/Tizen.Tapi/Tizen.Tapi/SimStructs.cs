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
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Text;

namespace Tizen.Tapi
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct SimImsiInfoStruct
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        internal string Mcc;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        internal string Mnc;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        internal string Msin;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SimEccInfoStruct
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        internal string Name;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        internal string Number;
        internal SimEccEmergencyServiceType Type;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SimEccInfoListStruct
    {
        internal int Count;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 15, ArraySubType = UnmanagedType.LPStruct)]
        internal SimEccInfoStruct[] ListInfo;
    }

    [StructLayout(LayoutKind.Explicit)]
    internal struct CfDataStruct
    {
        [FieldOffset(0)]
        internal SimCfisStruct Cfis;
        [FieldOffset(0)]
        internal SimCphsCfStruct CphsCf;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SimCallForwardRequestStruct
    {
        internal int IsCphs;
        internal CfDataStruct CfData;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SimCfisStruct
    {
        internal int RecIndex;
        internal byte MspNum;
        internal byte CfuStatus;
        internal SimTypeOfNumber Ton;
        internal SimNumberPlanIdentity Npi;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        internal string CfuNum;
        internal byte Cc2Id;
        internal byte Ext7Id;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SimCfisListStruct
    {
        internal int ProfileCount;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.LPStruct)]
        internal SimCfisStruct[] CfisList;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SimCphsCfStruct
    {
        internal int Line1;
        internal int Line2;
        internal int Fax;
        internal int Data;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SimCallForwardResponseStruct
    {
        internal int IsCphs;
        internal SimCfisListStruct CfList;
        internal SimCphsCfStruct CphsCf;
    }

    [StructLayout(LayoutKind.Explicit)]
    internal struct MwData
    {
        [FieldOffset(0)]
        internal SimMwisStruct Mwis;
        [FieldOffset(0)]
        internal SimCphsMwStruct CphsMw;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SimMessageWaitingRequestStruct
    {
        internal int IsCphs;
        internal MwData Mw;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SimMwisStruct
    {
        internal int RecIndex;
        internal byte IndicatorStatus;
        internal int VoiceCount;
        internal int FaxCount;
        internal int EmailCount;
        internal int OtherCount;
        internal int VideoCount;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SimMwisListStruct
    {
        internal int ProfileCount;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.LPStruct)]
        internal SimMwisStruct[] MwList;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SimCphsMwStruct
    {
        internal int Voice1;
        internal int Voice2;
        internal int Fax;
        internal int Data;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SimMessageWaitingResponseStruct
    {
        internal int IsCphs;
        internal SimMwisListStruct MwList;
        internal SimCphsMwStruct CphsMw;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SimMailboxNumberStruct
    {
        internal int IsCphs;
        internal int RecIndex;
        internal int ProfileNum;
        internal SimMailboxType MbType;
        internal int AlphaMaxLen;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        internal string AlphaId;
        internal SimTypeOfNumber Ton;
        internal SimNumberPlanIdentity Npi;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        internal string Number;
        internal byte CcId;
        internal byte Ext1Id;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SimMailboxListStruct
    {
        internal int Count;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10, ArraySubType = UnmanagedType.LPStruct)]
        internal SimMailboxNumberStruct[] List;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SimAuthenticationDataStruct
    {
        internal SimAuthenticationType AuthType;
        internal int RandLength;
        internal int AutnLength;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        internal string RandData;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        internal string AutnData;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SimAuthenticationResponseStruct
    {
        internal SimAuthenticationType AuthType;
        internal SimAuthenticationResult AuthResult;
        internal int RespLength;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        internal string RespData;
        internal int AuthKeyLength;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        internal string AuthKey;
        internal int CipherLength;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        internal string CipherData;
        internal int IntegrityLength;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        internal string IntegrityData;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SimPinDataStruct
    {
        internal SimPinType Type;
        [MarshalAs(UnmanagedType.LPStr)]
        internal string Pin;
        internal uint PinLength;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SimFacilityStruct
    {
        internal SimLockType LockType;
        [MarshalAs(UnmanagedType.LPStr)]
        internal string Password;
        internal int PasswordLength;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SimFacilityResultStruct
    {
        internal SimLockType Type;
        internal int RetryCount;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SimFacilityInfoStruct
    {
        internal SimLockType Type;
        internal SimFacilityStatus Status;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SimApduStruct
    {
        internal ushort ApduLen;
        [MarshalAs(UnmanagedType.LPStr)]
        internal string Apdu;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SimApduResponseStruct
    {
        internal ushort RespLen;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5120)]
        internal byte[] ApduResp;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SimIccIdInfoStruct
    {
        internal int IccLength;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
        internal string IccNumber;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SimCphsServiceTableStruct
    {
        internal int CustomerServiceProfile;
        internal int ServiceStringTable;
        internal int MailboxNumbers;
        internal int OperatorNameShortForm;
        internal int InformationNumbers;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SimCphsInfoStruct
    {
        internal SimCphsPhaseType CphsPhase;
        internal SimCphsServiceTableStruct CphsServiceTable;
    }

    [StructLayout(LayoutKind.Explicit)]
    internal struct CstServiceStrct
    {
        [FieldOffset(0)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 47)]
        internal string CdmaService;
        [FieldOffset(0)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        internal string CsimService;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SimCstStrct
    {
        internal SimCdmaServiceTable CdmaSvcTable;
        internal CstServiceStrct Cst;
    }

    [StructLayout(LayoutKind.Explicit)]
    internal struct ServiceTable
    {
        [FieldOffset(0)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 56)]
        internal string SimSstService;
        [FieldOffset(0)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        internal string SimUstService;
        [FieldOffset(0)]
        internal SimCstStrct Cst;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SimServiceTableStruct
    {
        internal SimCardType SimType;
        internal ServiceTable Table;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SimSubscriberInfoStruct
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 27)]
        internal string Number;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
        internal string Name;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SimMsisdnListStruct
    {
        internal int Count;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.LPStruct)]
        internal SimSubscriberInfoStruct[] List;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SimOplmnwactStruct
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
        internal string Plmn;
        internal int IsUmts;
        internal int IsGsm;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SimOplmnwactListStruct
    {
        internal int Count;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 100, ArraySubType = UnmanagedType.LPStruct)]
        internal SimOplmnwactStruct[] List;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SimSpnStruct
    {
        internal byte DisplayCondition;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        internal string Spn;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SimCphsNetNameStruct
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 41)]
        internal string FullName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
        internal string ShortName;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SimPinResultStruct
    {
        internal SimPinType Type;
        internal int RetryCount;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SimLockInfoStruct
    {
        internal SimLockType Type;
        internal SimLockStatus Status;
        internal int RetryCount;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SimAtrResponseStruct
    {
        internal ushort AtrRespLen;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5120)]
        internal byte[] AtrResp;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SimImpuListStruct
    {
        internal uint Count;
        internal IntPtr List;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SimPcscfStruct
    {
        internal SimPcscfType Type;
        [MarshalAs(UnmanagedType.LPStr)]
        internal string Pcscf;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct SimPcscfListStruct
    {
        internal uint Count;
        internal IntPtr List;
    }

    internal static class SimStructConversions
    {
        internal static SimImsiInfo ConvertSimImsiInfoStruct(SimImsiInfoStruct imsiStruct)
        {
            SimImsiInfo imsi = new SimImsiInfo();
            imsi.CountryCode = imsiStruct.Mcc;
            imsi.NetworkCode = imsiStruct.Mnc;
            imsi.StationId = imsiStruct.Msin;
            return imsi;
        }

        internal static SimEccInfo ConvertSimEccInfoStruct(SimEccInfoStruct eccStruct)
        {
            SimEccInfo ecc = new SimEccInfo();
            ecc.NameInfo = eccStruct.Name;
            ecc.NumberInfo = eccStruct.Number;
            ecc.TypeInfo = eccStruct.Type;
            return ecc;
        }

        internal static SimEccInfoList ConvertSimEccInfoListStruct(SimEccInfoListStruct listStruct)
        {
            SimEccInfoList eccList = new SimEccInfoList();
            eccList.EccCount = listStruct.Count;
            List<SimEccInfo> eccInfoList = new List<SimEccInfo>();
            foreach (SimEccInfoStruct info in listStruct.ListInfo)
            {
                eccInfoList.Add(ConvertSimEccInfoStruct(info));
            }

            eccList.List = eccInfoList;
            return eccList;
        }

        internal static SimIccIdInfo ConvertSimIccIdInfoStruct(SimIccIdInfoStruct iccStruct)
        {
            SimIccIdInfo iccId = new SimIccIdInfo();
            iccId.Length = iccStruct.IccLength;
            iccId.Number = iccStruct.IccNumber;
            return iccId;
        }

        internal static SimCfis ConvertSimCfisStruct(SimCfisStruct cfisStruct)
        {
            SimCfis cfis = new SimCfis();
            cfis.RecIndex = cfisStruct.RecIndex;
            cfis.MspNum = cfisStruct.MspNum;
            cfis.CfuStatus = cfisStruct.CfuStatus;
            cfis.Ton = cfisStruct.Ton;
            cfis.Npi = cfisStruct.Npi;
            cfis.CfuNum = cfisStruct.CfuNum;
            cfis.Cc2Id = cfisStruct.Cc2Id;
            cfis.Ext7Id = cfisStruct.Ext7Id;
            return cfis;
        }

        internal static SimCfisList ConvertSimCfisListStruct(SimCfisListStruct listStruct)
        {
            SimCfisList cfisList = new SimCfisList();
            cfisList.Count = listStruct.ProfileCount;
            List<SimCfis> cfis = new List<SimCfis>();
            foreach (SimCfisStruct cfStruct in listStruct.CfisList)
            {
                cfis.Add(ConvertSimCfisStruct(cfStruct));
            }

            cfisList.List = cfis;
            return cfisList;
        }

        internal static SimCphsCf ConvertSimCphsCfStruct(SimCphsCfStruct cphsCfStruct)
        {
            SimCphsCf cphs = new SimCphsCf();
            cphs.Line1 = cphsCfStruct.Line1;
            cphs.Line2 = cphsCfStruct.Line2;
            cphs.Fax = cphsCfStruct.Fax;
            cphs.Data = cphsCfStruct.Data;
            return cphs;
        }

        internal static SimCallForwardResponse ConvertSimCallForwardResponseStruct(SimCallForwardResponseStruct respStruct)
        {
            SimCallForwardResponse resp = new SimCallForwardResponse();
            if (respStruct.IsCphs == 1)
            {
                resp.IsCphsCf = true;
            }

            else if (respStruct.IsCphs == 0)
            {
                resp.IsCphsCf = false;
            }

            resp.List = ConvertSimCfisListStruct(respStruct.CfList);
            resp.CphsCfInfo = ConvertSimCphsCfStruct(respStruct.CphsCf);
            return resp;
        }

        internal static SimMwis ConvertSimMwisStruct(SimMwisStruct mwisStruct)
        {
            SimMwis mwis = new SimMwis();
            mwis.RecIndex = mwisStruct.RecIndex;
            mwis.IndicatorStatus = mwisStruct.IndicatorStatus;
            mwis.VoiceCount = mwisStruct.VoiceCount;
            mwis.FaxCount = mwisStruct.FaxCount;
            mwis.EmailCount = mwisStruct.EmailCount;
            mwis.OtherCount = mwisStruct.OtherCount;
            mwis.VideoCount = mwisStruct.VideoCount;
            return mwis;
        }

        internal static SimMwisList ConvertSimMwisListStruct(SimMwisListStruct mwStruct)
        {
            SimMwisList mwList = new SimMwisList();
            mwList.Count = mwStruct.ProfileCount;
            List<SimMwis> mwisList = new List<SimMwis>();
            foreach (SimMwisStruct mwisStruct in mwStruct.MwList)
            {
                mwisList.Add(ConvertSimMwisStruct(mwisStruct));
            }

            mwList.List = mwisList;
            return mwList;
        }

        internal static SimCphsMw ConvertSimCphsMwStruct(SimCphsMwStruct cphsStruct)
        {
            SimCphsMw cphsMw = new SimCphsMw();
            if (cphsStruct.Voice1 == 1)
            {
                cphsMw.IsVoice1 = true;
            }

            else
            {
                cphsMw.IsVoice1 = false;
            }

            if (cphsStruct.Voice2 == 1)
            {
                cphsMw.IsVoice2 = true;
            }

            else
            {
                cphsMw.IsVoice2 = false;
            }

            if (cphsStruct.Fax == 1)
            {
                cphsMw.IsFax = true;
            }

            else
            {
                cphsMw.IsFax = false;
            }

            if (cphsStruct.Data == 1)
            {
                cphsMw.IsData = true;
            }

            else
            {
                cphsMw.IsData = false;
            }

            return cphsMw;
        }

        internal static SimMessageWaitingResponse ConvertSimMessageWaitingRespStruct(SimMessageWaitingResponseStruct responseStruct)
        {
            SimMessageWaitingResponse waitingResp = new SimMessageWaitingResponse();
            if (responseStruct.IsCphs == 1)
            {
                waitingResp.IsCphsMw = true;
            }

            else
            {
                waitingResp.IsCphsMw = false;
            }

            waitingResp.List = ConvertSimMwisListStruct(responseStruct.MwList);
            waitingResp.CphsMwInfo = ConvertSimCphsMwStruct(responseStruct.CphsMw);
            return waitingResp;
        }

        internal static SimMailboxNumber ConvertSimMailboxNumberStruct(SimMailboxNumberStruct mbStruct)
        {
            SimMailboxNumber mbNumber = new SimMailboxNumber();
            if (mbStruct.IsCphs == 1)
            {
                mbNumber.IsCphs = true;
            }

            else if (mbStruct.IsCphs == 0)
            {
                mbNumber.IsCphs = false;
            }

            mbNumber.RecIndex = mbStruct.RecIndex;
            mbNumber.ProfileNumber = mbStruct.ProfileNum;
            mbNumber.MbType = mbStruct.MbType;
            mbNumber.AlphaMaxLength = mbStruct.AlphaMaxLen;
            mbNumber.AlphaId = mbStruct.AlphaId;
            mbNumber.Ton = mbStruct.Ton;
            mbNumber.Npi = mbStruct.Npi;
            mbNumber.Number = mbStruct.Number;
            mbNumber.CcId = mbStruct.CcId;
            mbNumber.Ext1Id = mbStruct.Ext1Id;
            return mbNumber;
        }

        internal static SimMailboxList ConvertSimMailboxListStruct(SimMailboxListStruct mbListStruct)
        {
            SimMailboxList mbList = new SimMailboxList();
            mbList.MbCount = mbListStruct.Count;
            List<SimMailboxNumber> mbNumList = new List<SimMailboxNumber>();
            foreach (SimMailboxNumberStruct mbStruct in mbListStruct.List)
            {
                mbNumList.Add(ConvertSimMailboxNumberStruct(mbStruct));
            }

            mbList.MbList = mbNumList;
            return mbList;
        }

        internal static SimCphsServiceTable ConvertSimCphsServiceTableStruct(SimCphsServiceTableStruct svcStruct)
        {
            SimCphsServiceTable svcTable = new SimCphsServiceTable();
            svcTable.CustomerSvcProfile = svcStruct.CustomerServiceProfile;
            svcTable.SvcStringTable = svcStruct.ServiceStringTable;
            svcTable.MbNumbers = svcStruct.MailboxNumbers;
            svcTable.OperatorNameShort = svcStruct.OperatorNameShortForm;
            svcTable.InformationNum = svcStruct.InformationNumbers;
            return svcTable;
        }

        internal static SimCphsInfo ConvertSimCphsInfoStruct(SimCphsInfoStruct cphsStruct)
        {
            SimCphsInfo cphsInfo = new SimCphsInfo();
            cphsInfo.Phase = cphsStruct.CphsPhase;
            cphsInfo.CphsSvcTable = ConvertSimCphsServiceTableStruct(cphsStruct.CphsServiceTable);
            return cphsInfo;
        }

        internal static SimCst ConvertSimCstStruct(SimCstStrct cstStruct)
        {
            SimCst cst = new SimCst();
            cst.CdmaSvc = cstStruct.CdmaSvcTable;
            if (cstStruct.CdmaSvcTable == SimCdmaServiceTable.Cdma)
            {
                cst.Cdma = Encoding.ASCII.GetBytes(cstStruct.Cst.CdmaService);
            }

            else if (cstStruct.CdmaSvcTable == SimCdmaServiceTable.Csim)
            {
                cst.Csim = Encoding.ASCII.GetBytes(cstStruct.Cst.CsimService);
            }

            return cst;
        }

        internal static SimServiceTable ConvertSimServiceTableStruct(SimServiceTableStruct svcTableStruct)
        {
            SimServiceTable svcTable = new SimServiceTable();
            svcTable.Type = svcTableStruct.SimType;
            if (svcTableStruct.SimType == SimCardType.Gsm)
            {
                svcTable.Sst = Encoding.ASCII.GetBytes(svcTableStruct.Table.SimSstService);
            }

            else if (svcTableStruct.SimType == SimCardType.Usim)
            {
                svcTable.Ust = Encoding.ASCII.GetBytes(svcTableStruct.Table.SimUstService);
            }

            else if (svcTableStruct.SimType == SimCardType.Ruim)
            {
                svcTable.Cst = ConvertSimCstStruct(svcTableStruct.Table.Cst);
            }

            return svcTable;
        }

        internal static SimSubscriberInfo ConvertSimSubscriberInfoStruct(SimSubscriberInfoStruct infoStruct)
        {
            SimSubscriberInfo subscriber = new SimSubscriberInfo();
            subscriber.MsisdnNum = infoStruct.Number;
            subscriber.MsisdnName = infoStruct.Name;
            return subscriber;
        }

        internal static SimMsisdnList ConvertSimMsisdnListStruct(SimMsisdnListStruct msisdnStruct)
        {
            SimMsisdnList list = new SimMsisdnList();
            list.MsisdnCount = msisdnStruct.Count;
            List<SimSubscriberInfo> subsList = new List<SimSubscriberInfo>();
            foreach (SimSubscriberInfoStruct subsStruct in msisdnStruct.List)
            {
                subsList.Add(ConvertSimSubscriberInfoStruct(subsStruct));
            }

            list.SubscriberList = subsList;
            return list;
        }

        internal static SimOplmnwact ConvertSimOplmnwactStruct(SimOplmnwactStruct oplmnStruct)
        {
            SimOplmnwact oplmn = new SimOplmnwact();
            oplmn.PlmnString = oplmnStruct.Plmn;
            if (oplmnStruct.IsUmts == 1)
            {
                oplmn.UmtsFlag = true;
            }

            else if (oplmnStruct.IsUmts == 0)
            {
                oplmn.UmtsFlag = false;
            }

            if (oplmnStruct.IsGsm == 1)
            {
                oplmn.GsmFlag = true;
            }

            else if (oplmnStruct.IsGsm == 0)
            {
                oplmn.GsmFlag = false;
            }

            return oplmn;
        }

        internal static SimOplmnwactList ConvertSimOplmnwactListStruct(SimOplmnwactListStruct listStruct)
        {
            SimOplmnwactList oplmnList = new SimOplmnwactList();
            oplmnList.OplmnCount = listStruct.Count;
            List<SimOplmnwact> wactList = new List<SimOplmnwact>();
            foreach (SimOplmnwactStruct wactStruct in listStruct.List)
            {
                wactList.Add(ConvertSimOplmnwactStruct(wactStruct));
            }

            oplmnList.OplmnList = wactList;
            return oplmnList;
        }

        internal static SimSpn ConvertSimSpnStruct(SimSpnStruct spnStruct)
        {
            SimSpn spn = new SimSpn();
            spn.Condition = spnStruct.DisplayCondition;
            spn.SpName = spnStruct.Spn;
            return spn;
        }

        internal static SimCphsNetName ConvertSimCphsNetNameStruct(SimCphsNetNameStruct cphsStruct)
        {
            SimCphsNetName cphsName = new SimCphsNetName();
            cphsName.Full = cphsStruct.FullName;
            cphsName.Short = cphsStruct.ShortName;
            return cphsName;
        }

        internal static SimAuthenticationResponse ConvertSimAuthenticationResponseStruct(SimAuthenticationResponseStruct respStruct)
        {
            SimAuthenticationResponse response = new SimAuthenticationResponse();
            response.Type = respStruct.AuthType;
            response.Result = respStruct.AuthResult;
            response.RespLength = respStruct.RespLength;
            response.RespData = respStruct.RespData;
            response.AuthKeyLen = respStruct.AuthKeyLength;
            response.Key = respStruct.AuthKey;
            response.CipherLen = respStruct.CipherLength;
            response.Cipher = respStruct.CipherData;
            response.IntegrityLen = respStruct.IntegrityLength;
            response.Integrity = respStruct.IntegrityData;
            return response;
        }

        internal static SimPinResult ConvertSimPinResultStruct(SimPinResultStruct resultStruct)
        {
            SimPinResult pinResult = new SimPinResult();
            pinResult.PinType = resultStruct.Type;
            pinResult.Retry = resultStruct.RetryCount;
            return pinResult;
        }

        internal static SimFacilityResult ConvertSimFacilityResultStruct(SimFacilityResultStruct resultStruct)
        {
            SimFacilityResult facilityResult = new SimFacilityResult();
            facilityResult.LockType = resultStruct.Type;
            facilityResult.Count = resultStruct.RetryCount;
            return facilityResult;
        }

        internal static SimFacilityInfo ConvertSimFacilityInfoStruct(SimFacilityInfoStruct infoStruct)
        {
            SimFacilityInfo facilityInfo = new SimFacilityInfo();
            facilityInfo.LockType = infoStruct.Type;
            facilityInfo.FacilityStatus = infoStruct.Status;
            return facilityInfo;
        }

        internal static SimLockInfo ConvertSimLockInfoStruct(SimLockInfoStruct infoStruct)
        {
            SimLockInfo lockInfo = new SimLockInfo();
            lockInfo.LockType = infoStruct.Type;
            lockInfo.LockStatus = infoStruct.Status;
            lockInfo.Count = infoStruct.RetryCount;
            return lockInfo;
        }

        internal static SimApduResponse ConvertSimApduResponseStruct(SimApduResponseStruct respStruct)
        {
            SimApduResponse response = new SimApduResponse();
            response.ApduLen = respStruct.RespLen;
            response.ApduResp = respStruct.ApduResp;
            return response;
        }

        internal static SimAtrResponse ConvertSimAtrResponseStruct(SimAtrResponseStruct respStruct)
        {
            SimAtrResponse atrResp = new SimAtrResponse();
            atrResp.AtrRespLen = respStruct.AtrRespLen;
            atrResp.AtrResp = respStruct.AtrResp;
            return atrResp;
        }

        internal static SimImpuList ConvertSimImpuListStruct(SimImpuListStruct listStruct)
        {
            SimImpuList impuList = new SimImpuList();
            impuList.DataCount = listStruct.Count;
            IntPtr[] ptrList = new IntPtr[listStruct.Count];
            Marshal.Copy(listStruct.List, ptrList, 0, (int)listStruct.Count);
            List<string> list = new List<string>();
            for (int i = 0; i < listStruct.Count; i++)
            {
                list.Add(Marshal.PtrToStringAnsi(ptrList[i]));
            }

            impuList.ImpuList = list;
            return impuList;
        }

        internal static SimPcscf ConvertSimPcscfStruct(SimPcscfStruct pcscfStruct)
        {
            SimPcscf pcscf = new SimPcscf();
            pcscf.PcscfType = pcscfStruct.Type;
            pcscf.PcscfData = pcscfStruct.Pcscf;
            return pcscf;
        }

        internal static SimPcscfList ConvertSimPcscfListStruct(SimPcscfListStruct listStruct)
        {
            SimPcscfList pcscfList = new SimPcscfList();
            pcscfList.DataCount = listStruct.Count;
            IntPtr[] ptrList = new IntPtr[listStruct.Count];
            Marshal.Copy(listStruct.List, ptrList, 0, (int)listStruct.Count);
            List<SimPcscf> list = new List<SimPcscf>();
            for (int i = 0; i < listStruct.Count; i++)
            {
                list.Add(ConvertSimPcscfStruct(Marshal.PtrToStructure<SimPcscfStruct>(ptrList[i])));
            }

            pcscfList.PcscfList = list;
            return pcscfList;
        }
    }

    internal static class SimClassConversions
    {
        internal static SimCallForwardRequestStruct ConvertSimCallForwardRequest(SimCallForwardRequest request)
        {
            SimCallForwardRequestStruct cfStruct = new SimCallForwardRequestStruct();
            if (request.IsCphs == true)
            {
                cfStruct.IsCphs = 1;
            }

            else if (request.IsCphs == false)
            {
                cfStruct.IsCphs = 0;
            }

            if (request.IsCphs == true)
            {
                cfStruct.CfData.CphsCf.Line1 = request.CphsCf.Line1;
                cfStruct.CfData.CphsCf.Line2 = request.CphsCf.Line2;
                cfStruct.CfData.CphsCf.Fax = request.CphsCf.Fax;
                cfStruct.CfData.CphsCf.Data = request.CphsCf.Data;
            }

            else
            {
                cfStruct.CfData.Cfis.RecIndex = request.Cfis.RecIndex;
                cfStruct.CfData.Cfis.MspNum = request.Cfis.MspNum;
                cfStruct.CfData.Cfis.CfuStatus = request.Cfis.CfuStatus;
                cfStruct.CfData.Cfis.Ton = request.Cfis.Ton;
                cfStruct.CfData.Cfis.Npi = request.Cfis.Npi;
                cfStruct.CfData.Cfis.CfuNum = request.Cfis.CfuNum;
                cfStruct.CfData.Cfis.Cc2Id = request.Cfis.Cc2Id;
                cfStruct.CfData.Cfis.Ext7Id = request.Cfis.Ext7Id;
            }

            return cfStruct;
        }

        internal static SimMwisStruct ConvertSimMwis(SimMwis mwis)
        {
            SimMwisStruct mwisStruct = new SimMwisStruct();
            mwisStruct.RecIndex = mwis.RecIndex;
            mwisStruct.IndicatorStatus = mwis.IndicatorStatus;
            mwisStruct.VoiceCount = mwis.VoiceCount;
            mwisStruct.FaxCount = mwis.FaxCount;
            mwisStruct.EmailCount = mwis.EmailCount;
            mwisStruct.OtherCount = mwis.OtherCount;
            mwisStruct.VideoCount = mwis.VideoCount;
            return mwisStruct;
        }

        internal static SimCphsMwStruct ConvertSimCphsMw(SimCphsMw cphsMw)
        {
            SimCphsMwStruct cphsStruct = new SimCphsMwStruct();
            if (cphsMw.IsVoice1 == true)
            {
                cphsStruct.Voice1 = 1;
            }

            else
            {
                cphsStruct.Voice1 = 0;
            }

            if (cphsMw.IsVoice2 == true)
            {
                cphsStruct.Voice2 = 1;
            }

            else
            {
                cphsStruct.Voice2 = 0;
            }

            if (cphsMw.IsFax == true)
            {
                cphsStruct.Fax = 1;
            }

            else
            {
                cphsStruct.Fax = 0;
            }

            if (cphsMw.IsData == true)
            {
                cphsStruct.Data = 1;
            }

            else
            {
                cphsStruct.Data = 0;
            }

            return cphsStruct;
        }

        internal static SimMessageWaitingRequestStruct ConvertSimMessageWaitingRequest(SimMessageWaitingRequest request)
        {
            SimMessageWaitingRequestStruct requestStruct = new SimMessageWaitingRequestStruct();
            if (request.IsCphs == true)
            {
                requestStruct.IsCphs = 1;
            }

            else
            {
                requestStruct.IsCphs = 0;
            }

            if (request.IsCphs == true)
            {
                requestStruct.Mw.CphsMw = ConvertSimCphsMw(request.CphsMw);
            }

            else
            {
                requestStruct.Mw.Mwis = ConvertSimMwis(request.Mwis);
            }

            return requestStruct;
        }

        internal static SimMailboxNumberStruct ConvertSimMailboxNumber(SimMailboxNumber mbNumber)
        {
            SimMailboxNumberStruct mbStruct = new SimMailboxNumberStruct();
            if (mbNumber.IsCphs)
            {
                mbStruct.IsCphs = 1;
            }

            else
            {
                mbStruct.IsCphs = 0;
            }

            mbStruct.RecIndex = mbNumber.RecIndex;
            mbStruct.ProfileNum = mbNumber.ProfileNumber;
            mbStruct.MbType = mbNumber.MbType;
            mbStruct.AlphaMaxLen = mbNumber.AlphaMaxLength;
            mbStruct.AlphaId = mbNumber.AlphaId;
            mbStruct.Ton = mbNumber.Ton;
            mbStruct.Npi = mbNumber.Npi;
            mbStruct.Number = mbNumber.Number;
            mbStruct.CcId = mbNumber.CcId;
            mbStruct.Ext1Id = mbNumber.Ext1Id;
            return mbStruct;
        }

        internal static SimPinDataStruct ConvertSimPinData(SimPinData data)
        {
            SimPinDataStruct pinStruct = new SimPinDataStruct();
            pinStruct.Type = data.Type;
            pinStruct.Pin = data.Pin;
            pinStruct.PinLength = data.PinLength;
            return pinStruct;
        }

        internal static SimFacilityStruct ConvertSimFacility(SimFacility facility)
        {
            SimFacilityStruct facilityStruct = new SimFacilityStruct();
            facilityStruct.LockType = facility.LockType;
            facilityStruct.Password = facility.Password;
            facilityStruct.PasswordLength = facility.PasswordLength;
            return facilityStruct;
        }

        internal static SimApduStruct ConvertSimApdu(SimApdu apdu)
        {
            SimApduStruct apduStruct = new SimApduStruct();
            apduStruct.ApduLen = (ushort)apdu.Apdu.Length;
            apduStruct.Apdu = Encoding.UTF8.GetString(apdu.Apdu);
            return apduStruct;
        }

        internal static SimAuthenticationDataStruct ConvertSimAuthenticationDataStruct(SimAuthenticationData authData)
        {
            SimAuthenticationDataStruct authStruct = new SimAuthenticationDataStruct();
            authStruct.AuthType = authData.AuthType;
            authStruct.RandLength = authData.RandLength;
            authStruct.AutnLength = authData.AutnLength;
            authStruct.RandData = Encoding.UTF8.GetString(authData.RandData);
            authStruct.AutnData = Encoding.UTF8.GetString(authData.AutnData);
            return authStruct;
        }
    }
}
