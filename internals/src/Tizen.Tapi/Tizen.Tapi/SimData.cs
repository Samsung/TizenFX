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

using System.Collections.Generic;

namespace Tizen.Tapi
{
    /// <summary>
    /// A class which defines SIM card initialization information.
    /// </summary>
    public class SimInitInfo
    {
        internal SimCardStatus SimStatus;
        internal bool IsChanged;
        internal SimInitInfo()
        {
        }

        /// <summary>
        /// The SIM initialization status from the Telephony server boot up time.
        /// </summary>
        public SimCardStatus Status
        {
            get
            {
                return SimStatus;
            }
        }

        /// <summary>
        /// The SIM card identification value. It will be true when the current inserted SIM card differs from the previous SIM. False otherwise.
        /// </summary>
        public bool IsCardChanged
        {
            get
            {
                return IsChanged;
            }
        }
    }

    /// <summary>
    /// A class which defines data for IMSI information.
    /// </summary>
    public class SimImsiInfo
    {
        internal string CountryCode;
        internal string NetworkCode;
        internal string StationId;
        internal SimImsiInfo()
        {
        }

        /// <summary>
        /// Mobile Country Code.
        /// </summary>
        public string Mcc
        {
            get
            {
                return CountryCode;
            }
        }

        /// <summary>
        /// Mobile Network Code.
        /// </summary>
        public string Mnc
        {
            get
            {
                return NetworkCode;
            }
        }

        /// <summary>
        /// Mobile Station Identification Number.
        /// </summary>
        public string Msin
        {
            get
            {
                return StationId;
            }
        }
    }

    /// <summary>
    /// A class which defines data for ECC information of GSM/USIM/CDMA SIM.
    /// </summary>
    public class SimEccInfo
    {
        internal string NameInfo;
        internal string NumberInfo;
        internal SimEccEmergencyServiceType TypeInfo;
        internal SimEccInfo()
        {
        }

        /// <summary>
        /// Name. Applicable only for USIM(3G) SIM.
        /// </summary>
        public string Name
        {
            get
            {
                return NameInfo;
            }
        }

        /// <summary>
        /// Number.
        /// </summary>
        public string Number
        {
            get
            {
                return NumberInfo;
            }
        }

        /// <summary>
        /// Emergency service type. Applicable only for USIM(3G) SIM.
        /// </summary>
        public SimEccEmergencyServiceType Category
        {
            get
            {
                return TypeInfo;
            }
        }
    }

    /// <summary>
    /// A class which defines ECC information list.
    /// </summary>
    public class SimEccInfoList
    {
        internal int EccCount;
        internal IEnumerable<SimEccInfo> List;
        internal SimEccInfoList()
        {
        }

        /// <summary>
        /// ECC count.
        /// </summary>
        public int Count
        {
            get
            {
                return EccCount;
            }
        }

        /// <summary>
        /// List of ECC.
        /// </summary>
        public IEnumerable<SimEccInfo> EccList
        {
            get
            {
                return List;
            }
        }
    }

    /// <summary>
    /// A class which defines ICCID(Integrated Circuit Card Identifier).
    /// </summary>
    public class SimIccIdInfo
    {
        internal int Length;
        internal string Number;
        internal SimIccIdInfo()
        {
        }

        /// <summary>
        /// Integrated Circuit Card number length.
        /// </summary>
        public int IccLength
        {
            get
            {
                return Length;
            }
        }

        /// <summary>
        /// Integrated Circuit Card number.
        /// </summary>
        public string IccNumber
        {
            get
            {
                return Number;
            }
        }
    }

    /// <summary>
    /// A class which defines call forwarding indication status data.
    /// </summary>
    public class SimCfis
    {
        private int _recIndex;
        private byte _mspNum;
        private byte _cfuStatus;
        private SimTypeOfNumber _ton;
        private SimNumberPlanIdentity _npi;
        private string _cfuNum;
        private byte _cc2Id;
        private byte _ext7Id;

        /// <summary>
        /// Record index.
        /// </summary>
        public int RecIndex
        {
            get
            {
                return _recIndex;
            }

            set
            {
                _recIndex = value;
            }
        }

        /// <summary>
        /// MSP number.
        /// </summary>
        public byte MspNum
        {
            get
            {
                return _mspNum;
            }

            set
            {
                _mspNum = value;
            }
        }

        /// <summary>
        /// Call forwarding unconditional indication status.
        /// </summary>
        public byte CfuStatus
        {
            get
            {
                return _cfuStatus;
            }

            set
            {
                _cfuStatus = value;
            }
        }

        /// <summary>
        /// SIM Type of number.
        /// </summary>
        public SimTypeOfNumber Ton
        {
            get
            {
                return _ton;
            }

            set
            {
                _ton = value;
            }
        }

        /// <summary>
        /// SIM numbering plan identity.
        /// </summary>
        public SimNumberPlanIdentity Npi
        {
            get
            {
                return _npi;
            }

            set
            {
                _npi = value;
            }
        }

        /// <summary>
        /// Dialing Number/SSC String.
        /// </summary>
        public string CfuNum
        {
            get
            {
                return _cfuNum;
            }

            set
            {
                _cfuNum = value;
            }
        }

        /// <summary>
        /// Capability/Configuration 2 Record Identifier.
        /// </summary>
        public byte Cc2Id
        {
            get
            {
                return _cc2Id;
            }

            set
            {
                _cc2Id = value;
            }
        }

        /// <summary>
        /// Extension 7 Record Identifier.
        /// </summary>
        public byte Ext7Id
        {
            get
            {
                return _ext7Id;
            }

            set
            {
                _ext7Id = value;
            }
        }
    }

    /// <summary>
    /// A class which defines call forwarding indication status list.
    /// </summary>
    public class SimCfisList
    {
        internal int Count;
        internal IEnumerable<SimCfis> List;
        internal SimCfisList()
        {
        }

        /// <summary>
        /// Profile count.
        /// </summary>
        public int ProfileCount
        {
            get
            {
                return Count;
            }
        }

        /// <summary>
        /// List of CFIS.
        /// </summary>
        public IEnumerable<SimCfis> CfisList
        {
            get
            {
                return List;
            }
        }
    }

    /// <summary>
    /// A class which defines CPHS call forwarding status data.
    /// </summary>
    public class SimCphsCf
    {
        private int _line1;
        private int _line2;
        private int _fax;
        private int _data;

        /// <summary>
        /// CallForwardUnconditionalLine 1.
        /// </summary>
        public int Line1
        {
            get
            {
                return _line1;
            }

            set
            {
                _line1 = value;
            }
        }

        /// <summary>
        /// CallForwardUnconditionalLine 2.
        /// </summary>
        public int Line2
        {
            get
            {
                return _line2;
            }

            set
            {
                _line2 = value;
            }
        }

        /// <summary>
        /// CallForwardUnconditional Fax.
        /// </summary>
        public int Fax
        {
            get
            {
                return _fax;
            }

            set
            {
                _fax = value;
            }
        }

        /// <summary>
        /// CallForwardUnconditional data.
        /// </summary>
        public int Data
        {
            get
            {
                return _data;
            }

            set
            {
                _data = value;
            }
        }
    }

    /// <summary>
    /// A class which defines call forwarding response.
    /// </summary>
    public class SimCallForwardResponse
    {
        internal bool IsCphsCf;
        internal SimCfisList List;
        internal SimCphsCf CphsCfInfo;
        internal SimCallForwardResponse()
        {
        }

        /// <summary>
        /// CPHS or not.
        /// </summary>
        public bool IsCphs
        {
            get
            {
                return IsCphsCf;
            }
        }

        /// <summary>
        /// List of CFIS.
        /// </summary>
        public SimCfisList CfList
        {
            get
            {
                return List;
            }
        }

        /// <summary>
        /// CPHS CF.
        /// </summary>
        public SimCphsCf CphsCf
        {
            get
            {
                return CphsCfInfo;
            }
        }
    }

    /// <summary>
    /// A class which defines call forwarding request.
    /// </summary>
    public class SimCallForwardRequest
    {
        private bool _isCphs;
        private SimCfis _cfis;
        private SimCphsCf _cphsCf;

        /// <summary>
        /// CPHS or not.
        /// </summary>
        public bool IsCphs
        {
            get
            {
                return _isCphs;
            }

            set
            {
                _isCphs = value;
            }
        }

        /// <summary>
        /// CFIS.
        /// </summary>
        /// <remarks>
        /// This should be filled only if IsCphs is false.
        /// </remarks>
        public SimCfis Cfis
        {
            get
            {
                return _cfis;
            }

            set
            {
                _cfis = value;
            }
        }

        /// <summary>
        /// CPHS CF.
        /// </summary>
        /// <remarks>
        /// This should be filled only if IsCphs is true.
        /// </remarks>
        public SimCphsCf CphsCf
        {
            get
            {
                return _cphsCf;
            }

            set
            {
                _cphsCf = value;
            }
        }
    }

    /// <summary>
    /// A class which defines message waiting indication status data.
    /// </summary>
    public class SimMwis
    {
        private int _recIndex;
        private byte _indicatorStatus;
        private int _voiceCount;
        private int _faxCount;
        private int _emailCount;
        private int _otherCount;
        private int _videoCount;

        /// <summary>
        /// Record index.
        /// </summary>
        public int RecIndex
        {
            get
            {
                return _recIndex;
            }

            set
            {
                _recIndex = value;
            }
        }

        /// <summary>
        /// Indicator type.
        /// </summary>
        public byte IndicatorStatus
        {
            get
            {
                return _indicatorStatus;
            }

            set
            {
                _indicatorStatus = value;
            }
        }

        /// <summary>
        /// VoiceMail count.
        /// </summary>
        public int VoiceCount
        {
            get
            {
                return _voiceCount;
            }

            set
            {
                _voiceCount = value;
            }
        }

        /// <summary>
        /// Fax count.
        /// </summary>
        public int FaxCount
        {
            get
            {
                return _faxCount;
            }

            set
            {
                _faxCount = value;
            }
        }

        /// <summary>
        /// Email count.
        /// </summary>
        public int EmailCount
        {
            get
            {
                return _emailCount;
            }

            set
            {
                _emailCount = value;
            }
        }

        /// <summary>
        /// Other count.
        /// </summary>
        public int OtherCount
        {
            get
            {
                return _otherCount;
            }

            set
            {
                _otherCount = value;
            }
        }

        /// <summary>
        /// VideoMail count.
        /// </summary>
        public int VideoCount
        {
            get
            {
                return _videoCount;
            }

            set
            {
                _videoCount = value;
            }
        }
    }

    /// <summary>
    /// A class which defines message waiting indication status list.
    /// </summary>
    public class SimMwisList
    {
        internal int Count;
        internal IEnumerable<SimMwis> List;
        internal SimMwisList()
        {
        }

        /// <summary>
        /// Profile count.
        /// </summary>
        public int ProfileCount
        {
            get
            {
                return Count;
            }
        }

        /// <summary>
        /// List of MWIS.
        /// </summary>
        public IEnumerable<SimMwis> MwList
        {
            get
            {
                return List;
            }
        }
    }

    /// <summary>
    /// A class which defines CPHS message waiting status data.
    /// </summary>
    public class SimCphsMw
    {
        private bool _isVoice1;
        private bool _isVoice2;
        private bool _isFax;
        private bool _isData;

        /// <summary>
        /// VoiceMsgLine1 message waiting flag.
        /// </summary>
        public bool IsVoice1
        {
            get
            {
                return _isVoice1;
            }

            set
            {
                _isVoice1 = value;
            }
        }

        /// <summary>
        /// VoiceMsgLine2 message waiting flag.
        /// </summary>
        public bool IsVoice2
        {
            get
            {
                return _isVoice2;
            }

            set
            {
                _isVoice2 = value;
            }
        }

        /// <summary>
        /// FAX message waiting flag.
        /// </summary>
        public bool IsFax
        {
            get
            {
                return _isFax;
            }

            set
            {
                _isFax = value;
            }
        }

        /// <summary>
        /// Data message waiting flag.
        /// </summary>
        public bool IsData
        {
            get
            {
                return _isData;
            }

            set
            {
                _isData = value;
            }
        }
    }

    /// <summary>
    /// A class which defines message waiting reponse.
    /// </summary>
    public class SimMessageWaitingResponse
    {
        internal bool IsCphsMw;
        internal SimMwisList List;
        internal SimCphsMw CphsMwInfo;
        internal SimMessageWaitingResponse()
        {
        }

        /// <summary>
        /// CPHS or not.
        /// </summary>
        public bool IsCphs
        {
            get
            {
                return IsCphsMw;
            }
        }

        /// <summary>
        /// List of MWIS.
        /// </summary>
        public SimMwisList MwList
        {
            get
            {
                return List;
            }
        }

        /// <summary>
        /// CPHS MW.
        /// </summary>
        public SimCphsMw CphsMw
        {
            get
            {
                return CphsMwInfo;
            }
        }
    }

    /// <summary>
    /// A class which defines message waiting request.
    /// </summary>
    public class SimMessageWaitingRequest
    {
        private bool _isCphs;
        private SimMwis _mwis;
        private SimCphsMw _cphsMw;

        /// <summary>
        /// CPHS or not.
        /// </summary>
        public bool IsCphs
        {
            get
            {
                return _isCphs;
            }

            set
            {
                _isCphs = value;
            }
        }

        /// <summary>
        /// MWIS.
        /// </summary>
        /// <remarks>
        /// This should be filled only if IsCphs is false.
        /// </remarks>
        public SimMwis Mwis
        {
            get
            {
                return _mwis;
            }

            set
            {
                _mwis = value;
            }
        }

        /// <summary>
        /// CPHS MW.
        /// </summary>
        /// <remarks>
        /// This should be filled only if IsCphs is true.
        /// </remarks>
        public SimCphsMw CphsMw
        {
            get
            {
                return _cphsMw;
            }

            set
            {
                _cphsMw = value;
            }
        }
    }

    /// <summary>
    /// A class which defines mailbox dialing number data.
    /// </summary>
    public class SimMailboxNumber
    {
        private bool _isCphs;
        private int _recIndex;
        private int _profileNumber;
        private SimMailboxType _mbType;
        private int _alphaMaxLength;
        private string _alphaId;
        private SimTypeOfNumber _ton;
        private SimNumberPlanIdentity _npi;
        private string _number;
        private byte _ccId;
        private byte _ext1Id;

        /// <summary>
        /// CPHS or not.
        /// </summary>
        public bool IsCphs
        {
            get
            {
                return _isCphs;
            }

            set
            {
                _isCphs = value;
            }
        }

        /// <summary>
        /// Index which stands for the location where the record is saved in SIM.
        /// </summary>
        public int RecIndex
        {
            get
            {
                return _recIndex;
            }

            set
            {
                _recIndex = value;
            }
        }

        /// <summary>
        /// SIM profile index.
        /// </summary>
        public int ProfileNumber
        {
            get
            {
                return _profileNumber;
            }

            set
            {
                _profileNumber = value;
            }
        }

        /// <summary>
        /// Mailbox type.
        /// </summary>
        public SimMailboxType MbType
        {
            get
            {
                return _mbType;
            }

            set
            {
                _mbType = value;
            }
        }

        /// <summary>
        /// Alpha max length in SIM.
        /// </summary>
        public int AlphaMaxLength
        {
            get
            {
                return _alphaMaxLength;
            }

            set
            {
                _alphaMaxLength = value;
            }
        }

        /// <summary>
        /// Alpha Identifier.
        /// </summary>
        public string AlphaId
        {
            get
            {
                return _alphaId;
            }

            set
            {
                _alphaId = value;
            }
        }

        /// <summary>
        /// Type Of Number.
        /// </summary>
        public SimTypeOfNumber Ton
        {
            get
            {
                return _ton;
            }

            set
            {
                _ton = value;
            }
        }

        /// <summary>
        /// Number Plan Identity.
        /// </summary>
        public SimNumberPlanIdentity Npi
        {
            get
            {
                return _npi;
            }

            set
            {
                _npi = value;
            }
        }

        /// <summary>
        /// Dialing Number/SSC String.
        /// </summary>
        public string Number
        {
            get
            {
                return _number;
            }

            set
            {
                _number = value;
            }
        }

        /// <summary>
        /// Capability/Configuration Identifier.
        /// </summary>
        public byte CcId
        {
            get
            {
                return _ccId;
            }

            set
            {
                _ccId = value;
            }
        }

        /// <summary>
        /// Extension 1 Record Identifier.
        /// </summary>
        public byte Ext1Id
        {
            get
            {
                return _ext1Id;
            }

            set
            {
                _ext1Id = value;
            }
        }
    }

    /// <summary>
    /// A class which defines mailbox dialing number list.
    /// </summary>
    public class SimMailboxList
    {
        internal int MbCount;
        internal IEnumerable<SimMailboxNumber> MbList;
        internal SimMailboxList()
        {
        }

        /// <summary>
        /// Mailbox count.
        /// </summary>
        public int Count
        {
            get
            {
                return MbCount;
            }
        }

        /// <summary>
        /// List of mailbox.
        /// </summary>
        public IEnumerable<SimMailboxNumber> List
        {
            get
            {
                return MbList;
            }
        }
    }

    /// <summary>
    /// A class which defines available optional CPHS SIM files.
    /// </summary>
    public class SimCphsServiceTable
    {
        internal int CustomerSvcProfile;
        internal int SvcStringTable;
        internal int MbNumbers;
        internal int OperatorNameShort;
        internal int InformationNum;
        internal SimCphsServiceTable()
        {
        }

        /// <summary>
        /// Customer Service Profile (CSP).
        /// </summary>
        public int CustomerServiceProfile
        {
            get
            {
                return CustomerSvcProfile;
            }
        }

        /// <summary>
        /// Service String Table (SST).
        /// </summary>
        public int ServiceStringTable
        {
            get
            {
                return SvcStringTable;
            }
        }

        /// <summary>
        /// MailBoxNumbers.
        /// </summary>
        public int MailboxNumbers
        {
            get
            {
                return MbNumbers;
            }
        }

        /// <summary>
        /// Short form of operator name.
        /// </summary>
        public int OperatorNameShortForm
        {
            get
            {
                return OperatorNameShort;
            }
        }

        /// <summary>
        /// Information numbers.
        /// </summary>
        public int InformationNumbers
        {
            get
            {
                return InformationNum;
            }
        }
    }

    /// <summary>
    /// A class which defines CPHS information data.
    /// </summary>
    public class SimCphsInfo
    {
        internal SimCphsPhaseType Phase;
        internal SimCphsServiceTable CphsSvcTable;
        internal SimCphsInfo()
        {
        }

        /// <summary>
        /// CPHS phase type.
        /// </summary>
        public SimCphsPhaseType CphsPhase
        {
            get
            {
                return Phase;
            }
        }

        /// <summary>
        /// CPHS service table.
        /// </summary>
        public SimCphsServiceTable CphsServiceTable
        {
            get
            {
                return CphsSvcTable;
            }
        }
    }

    /// <summary>
    /// A class which defines CSIM service table.
    /// </summary>
    public class SimCst
    {
        internal SimCdmaServiceTable CdmaSvc;
        internal byte[] Cdma;
        internal byte[] Csim;
        internal SimCst()
        {
        }

        /// <summary>
        /// Cdma service table;
        /// </summary>
        public SimCdmaServiceTable CdmaSvcTable
        {
            get
            {
                return CdmaSvc;
            }
        }

        /// <summary>
        /// Cdma service. Gives mask value of SimCdmaService enum.
        /// </summary>
        /// <remarks>
        /// This will be filled only if CdmaSvcTable is Cdma.
        /// </remarks>
        public byte[] CdmaService
        {
            get
            {
                return Cdma;
            }
        }

        /// <summary>
        /// Csim service. Gives mask value of SimCsimService enum.
        /// </summary>
        /// <remarks>
        /// This will be filled only if CdmaSvcTable is Csim.
        /// </remarks>
        public byte[] CsimService
        {
            get
            {
                return Csim;
            }
        }
    }

    /// <summary>
    /// A class which defines SIM service table.
    /// </summary>
    public class SimServiceTable
    {
        internal SimCardType Type;
        internal byte[] Sst;
        internal byte[] Ust;
        internal SimCst Cst;
        internal SimServiceTable()
        {
        }

        /// <summary>
        /// SIM card type.
        /// </summary>
        public SimCardType SimType
        {
            get
            {
                return Type;
            }
        }

        /// <summary>
        /// SIM service table. Gives mask value of SimSstService enum.
        /// </summary>
        /// <remarks>
        /// This will be filled only if SimType is Gsm.
        /// </remarks>
        public byte[] SstService
        {
            get
            {
                return Sst;
            }
        }

        /// <summary>
        /// USIM service table. Gives mask value of SimUstService enum.
        /// </summary>
        /// <remarks>
        /// This will be filled only if SimType is Usim.
        /// </remarks>
        public byte[] UstService
        {
            get
            {
                return Ust;
            }
        }

        /// <summary>
        /// CSIM service table.
        /// </summary>
        /// <remarks>
        /// This will be filled only if SimType is Ruim.
        /// </remarks>
        public SimCst CstService
        {
            get
            {
                return Cst;
            }
        }
    }

    /// <summary>
    /// A class which defines MSISDN information of the GSM/CDMA SIM.
    /// </summary>
    public class SimSubscriberInfo
    {
        internal string MsisdnNum;
        internal string MsisdnName;
        internal SimSubscriberInfo()
        {
        }

        /// <summary>
        /// MSISDN number. If it does not exist, a null string will be returned
        /// </summary>
        public string Number
        {
            get
            {
                return MsisdnNum;
            }
        }

        /// <summary>
        /// MSISDN name. If it does not exist, a null string will be returned. Not applicable for CDMA.
        /// </summary>
        public string Name
        {
            get
            {
                return MsisdnName;
            }
        }
    }

    /// <summary>
    /// A class which defines MSISDN list.
    /// </summary>
    public class SimMsisdnList
    {
        internal int MsisdnCount;
        internal IEnumerable<SimSubscriberInfo> SubscriberList;
        internal SimMsisdnList()
        {
        }

        /// <summary>
        /// Count.
        /// </summary>
        public int Count
        {
            get
            {
                return MsisdnCount;
            }
        }

        /// <summary>
        /// List of subscriber info.
        /// </summary>
        public IEnumerable<SimSubscriberInfo> List
        {
            get
            {
                return SubscriberList;
            }
        }
    }

    /// <summary>
    /// A class which defines OPLMNwACT data.
    /// </summary>
    public class SimOplmnwact
    {
        internal string PlmnString;
        internal bool UmtsFlag;
        internal bool GsmFlag;
        internal SimOplmnwact()
        {
        }

        /// <summary>
        /// PLMN.
        /// </summary>
        public string Plmn
        {
            get
            {
                return PlmnString;
            }
        }

        /// <summary>
        /// UMTS or not.
        /// </summary>
        public bool IsUmts
        {
            get
            {
                return UmtsFlag;
            }
        }

        /// <summary>
        /// GSM or not.
        /// </summary>
        public bool IsGsm
        {
            get
            {
                return GsmFlag;
            }
        }
    }

    /// <summary>
    /// A class which defines OPLMNwACT list.
    /// </summary>
    public class SimOplmnwactList
    {
        internal int OplmnCount;
        internal IEnumerable<SimOplmnwact> OplmnList;
        internal SimOplmnwactList()
        {
        }

        /// <summary>
        /// Count.
        /// </summary>
        public int Count
        {
            get
            {
                return OplmnCount;
            }
        }

        /// <summary>
        /// List of OPLMNWACT.
        /// </summary>
        public IEnumerable<SimOplmnwact> List
        {
            get
            {
                return OplmnList;
            }
        }
    }

    /// <summary>
    /// A class which defines SPN(Service Provider Name).
    /// </summary>
    public class SimSpn
    {
        internal byte Condition;
        internal string SpName;
        internal SimSpn()
        {
        }

        /// <summary>
        /// Display condition.
        /// </summary>
        public byte DisplayCondition
        {
            get
            {
                return Condition;
            }
        }

        /// <summary>
        /// Service Provider Name.
        /// </summary>
        public string Spn
        {
            get
            {
                return SpName;
            }
        }
    }

    /// <summary>
    /// A class which defines CPHS network name.
    /// </summary>
    public class SimCphsNetName
    {
        internal string Full;
        internal string Short;
        internal SimCphsNetName()
        {
        }

        /// <summary>
        /// Full name.
        /// </summary>
        public string FullName
        {
            get
            {
                return Full;
            }
        }

        /// <summary>
        /// Short name.
        /// </summary>
        public string ShortName
        {
            get
            {
                return Short;
            }
        }
    }

    /// <summary>
    /// A class which defines authentication request data.
    /// </summary>
    public class SimAuthenticationData
    {
        private SimAuthenticationType _authType;
        private int _randLength;
        private int _autnLength;
        private byte[] _randData;
        private byte[] _autnData;
        private SimAuthenticationData()
        {
        }

        /// <summary>
        /// A constructor to instantiate SimAuthenticationData class with necessary parameters.
        /// </summary>
        /// <param name="authType">Authentication type.</param>
        /// <param name="randLength">The length of RAND.</param>
        /// <param name="autnLength">The length of AUTN. It is not used in case of GSM AUTH.</param>
        /// <param name="randData">RAND data.</param>
        /// <param name="autnData">AUTN data. It is not used in case of GSM AUTH.</param>
        public SimAuthenticationData(SimAuthenticationType authType, int randLength, int autnLength, byte[] randData, byte[] autnData)
        {
            _authType = authType;
            _randLength = randLength;
            _autnLength = autnLength;
            _randData = randData;
            _autnData = autnData;
        }

        internal SimAuthenticationType AuthType
        {
            get
            {
                return _authType;
            }
        }

        internal int RandLength
        {
            get
            {
                return _randLength;
            }
        }

        internal int AutnLength
        {
            get
            {
                return _autnLength;
            }
        }

        internal byte[] RandData
        {
            get
            {
                return _randData;
            }
        }

        internal byte[] AutnData
        {
            get
            {
                return _autnData;
            }
        }
    }

    /// <summary>
    /// A class which defines authentication result data.
    /// </summary>
    public class SimAuthenticationResponse
    {
        internal SimAuthenticationType Type;
        internal SimAuthenticationResult Result;
        internal int RespLength;
        internal string RespData;
        internal int AuthKeyLen;
        internal string Key;
        internal int CipherLen;
        internal string Cipher;
        internal int IntegrityLen;
        internal string Integrity;
        internal SimAuthenticationResponse()
        {
        }

        /// <summary>
        /// Authentication type.
        /// </summary>
        public SimAuthenticationType AuthType
        {
            get
            {
                return Type;
            }
        }

        /// <summary>
        /// Authentication result.
        /// </summary>
        public SimAuthenticationResult AuthResult
        {
            get
            {
                return Result;
            }
        }

        /// <summary>
        /// Response length.
        /// </summary>
        public int ResponseLength
        {
            get
            {
                return RespLength;
            }
        }

        /// <summary>
        /// Response data.
        /// </summary>
        public string ResponseData
        {
            get
            {
                return RespData;
            }
        }

        /// <summary>
        /// The length of the authentication key.
        /// </summary>
        public int AuthKeyLength
        {
            get
            {
                return AuthKeyLen;
            }
        }

        /// <summary>
        /// The data of the authentication key.
        /// </summary>
        public string AuthKey
        {
            get
            {
                return Key;
            }
        }

        /// <summary>
        /// The length of the cipher key.
        /// </summary>
        public int CipherLength
        {
            get
            {
                return CipherLen;
            }
        }

        /// <summary>
        /// Cipher key.
        /// </summary>
        public string CipherData
        {
            get
            {
                return Cipher;
            }
        }

        /// <summary>
        /// The length of the integrity key.
        /// </summary>
        public int IntegrityLength
        {
            get
            {
                return IntegrityLen;
            }
        }

        /// <summary>
        /// Integrity key.
        /// </summary>
        public string IntegrityData
        {
            get
            {
                return Integrity;
            }
        }
    }

    /// <summary>
    /// A class which defines information about SIM PIN data.
    /// </summary>
    public class SimPinData
    {
        private SimPinType _type;
        private string _pin;
        private uint _pinLength;
        private SimPinData()
        {
        }

        /// <summary>
        /// A constructor to instantiate SimPinData class which necessary parameters.
        /// </summary>
        /// <param name="type">PIN type.</param>
        /// <param name="pin">PIN code.</param>
        /// <param name="pinLength">PIN code length.</param>
        public SimPinData(SimPinType type, string pin, uint pinLength)
        {
            _type = type;
            _pin = pin;
            _pinLength = pinLength;
        }

        internal SimPinType Type
        {
            get
            {
                return _type;
            }
        }

        internal string Pin
        {
            get
            {
                return _pin;
            }
        }

        internal uint PinLength
        {
            get
            {
                return _pinLength;
            }
        }
    }

    /// <summary>
    /// A class which defines PIN information.
    /// </summary>
    public class SimPinResult
    {
        internal SimPinType PinType;
        internal int Retry;
        internal SimPinResult()
        {
        }

        /// <summary>
        /// Specifies the PIN or PUK type.
        /// </summary>
        public SimPinType Type
        {
            get
            {
                return PinType;
            }
        }

        /// <summary>
        /// Number of attempts remaining for PIN/PUK verification.
        /// </summary>
        public int RetryCount
        {
            get
            {
                return Retry;
            }
        }
    }

    /// <summary>
    /// A class which is used to used to enable/disable facility.
    /// </summary>
    public class SimFacility
    {
        private SimLockType _lockType;
        private string _password;
        private int _passwordLength;
        private SimFacility()
        {
        }

        /// <summary>
        /// A constructor to instantiate SimFacility class with necessary parameters.
        /// </summary>
        /// <param name="lockType">Facility type.</param>
        /// <param name="password">Password.</param>
        /// <param name="passwordLength">Password length.</param>
        public SimFacility(SimLockType lockType, string password, int passwordLength)
        {
            _lockType = lockType;
            _password = password;
            _passwordLength = passwordLength;
        }

        internal SimLockType LockType
        {
            get
            {
                return _lockType;
            }
        }

        internal string Password
        {
            get
            {
                return _password;
            }
        }

        internal int PasswordLength
        {
            get
            {
                return _passwordLength;
            }
        }
    }

    /// <summary>
    /// A class which defines facility result data.
    /// </summary>
    public class SimFacilityResult
    {
        internal SimLockType LockType;
        internal int Count;
        internal SimFacilityResult()
        {
        }

        /// <summary>
        /// Specifies the PIN or PUK type.
        /// </summary>
        public SimLockType Type
        {
            get
            {
                return LockType;
            }
        }

        /// <summary>
        /// Number of attempts remaining for PIN/PUK verification.
        /// </summary>
        public int RetryCount
        {
            get
            {
                return Count;
            }
        }
    }

    /// <summary>
    /// A class which defines facility info data.
    /// </summary>
    public class SimFacilityInfo
    {
        internal SimLockType LockType;
        internal SimFacilityStatus FacilityStatus;
        internal SimFacilityInfo()
        {
        }

        /// <summary>
        /// Lock type.
        /// </summary>
        public SimLockType Type
        {
            get
            {
                return LockType;
            }
        }

        /// <summary>
        /// Facility status.
        /// </summary>
        public SimFacilityStatus Status
        {
            get
            {
                return FacilityStatus;
            }
        }
    }

    /// <summary>
    /// A class which defines information about lock type.
    /// </summary>
    public class SimLockInfo
    {
        internal SimLockType LockType;
        internal SimLockStatus LockStatus;
        internal int Count;
        internal SimLockInfo()
        {
        }

        /// <summary>
        /// Lock type.
        /// </summary>
        public SimLockType Type
        {
            get
            {
                return LockType;
            }
        }

        /// <summary>
        /// Lock status.
        /// </summary>
        public SimLockStatus Status
        {
            get
            {
                return LockStatus;
            }
        }

        /// <summary>
        /// Retry counts.
        /// </summary>
        public int RetryCount
        {
            get
            {
                return Count;
            }
        }
    }

    /// <summary>
    /// A class which defines APDU information.
    /// </summary>
    public class SimApdu
    {
        private byte[] _apdu;
        private SimApdu()
        {
        }

        /// <summary>
        /// A constructor to instantiate SimApdu class with necessary parameters.
        /// </summary>
        /// <param name="apdu">APDU.</param>
        public SimApdu(byte[] apdu)
        {
            _apdu = apdu;
        }

        internal byte[] Apdu
        {
            get
            {
                return _apdu;
            }
        }
    }

    /// <summary>
    /// A class which defines the response of sending APDU.
    /// </summary>
    public class SimApduResponse
    {
        internal ushort ApduLen;
        internal byte[] ApduResp;
        internal SimApduResponse()
        {
        }

        /// <summary>
        /// Length of response APDU.
        /// </summary>
        public ushort ApduLength
        {
            get
            {
                return ApduLen;
            }
        }

        /// <summary>
        /// Response APDU.
        /// </summary>
        public byte[] ApduResponse
        {
            get
            {
                return ApduResp;
            }
        }
    }

    /// <summary>
    /// A class which defines the response of sending ATR.
    /// </summary>
    public class SimAtrResponse
    {
        internal ushort AtrRespLen;
        internal byte[] AtrResp;
        internal SimAtrResponse()
        {
        }

        /// <summary>
        /// Length of response ATR.
        /// </summary>
        public ushort AtrRespLength
        {
            get
            {
                return AtrRespLen;
            }
        }

        /// <summary>
        /// Response ATR.
        /// </summary>
        public byte[] AtrResponse
        {
            get
            {
                return AtrResp;
            }
        }
    }

    /// <summary>
    /// A class which defines ISIM IMPU list data.
    /// </summary>
    public class SimImpuList
    {
        internal uint DataCount;
        internal IEnumerable<string> ImpuList;
        internal SimImpuList()
        {
        }

        /// <summary>
        /// ISIM IMPU data count.
        /// </summary>
        public uint Count
        {
            get
            {
                return DataCount;
            }
        }

        /// <summary>
        /// ISIM IMPU list.
        /// </summary>
        public IEnumerable<string> List
        {
            get
            {
                return ImpuList;
            }
        }
    }

    /// <summary>
    /// A class which defines ISIM P-CSCF data.
    /// </summary>
    public class SimPcscf
    {
        internal SimPcscfType PcscfType;
        internal string PcscfData;
        internal SimPcscf()
        {
        }

        /// <summary>
        /// ISIM P-CSCF type.
        /// </summary>
        public SimPcscfType Type
        {
            get
            {
                return PcscfType;
            }
        }

        /// <summary>
        /// ISIM P-CSCF data.
        /// </summary>
        public string Pcscf
        {
            get
            {
                return PcscfData;
            }
        }
    }

    /// <summary>
    /// A class which defines ISIM P-CSCF list data.
    /// </summary>
    public class SimPcscfList
    {
        internal uint DataCount;
        internal IEnumerable<SimPcscf> PcscfList;
        internal SimPcscfList()
        {
        }

        /// <summary>
        /// ISIM P-CSCF data count.
        /// </summary>
        public uint Count
        {
            get
            {
                return DataCount;
            }
        }

        /// <summary>
        /// ISIM P-CSCF list.
        /// </summary>
        public IEnumerable<SimPcscf> List
        {
            get
            {
                return PcscfList;
            }
        }
    }
}
