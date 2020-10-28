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
    /// A class which defines values for USSD request type. Applicable to 3GPP(GSM/UMTS/LET) only.
    /// </summary>
    public class SsUssdMsgInfo
    {
        private SsUssdType _type;
        private byte _dcs;
        private int _length;
        private string _ussdString;

        /// <summary>
        /// USSD type.
        /// </summary>
        /// <value>Type of USSD represented in SsUssdType enum.</value>
        public SsUssdType Type
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value;
            }
        }

        /// <summary>
        /// DCS.
        /// </summary>
        /// <value>Dcs value represented in byte.</value>
        public byte Dcs
        {
            get
            {
                return _dcs;
            }

            set
            {
                _dcs = value;
            }
        }

        /// <summary>
        /// USSD string length.
        /// </summary>
        /// <value>Length of USSD string in integer.</value>
        public int Length
        {
            get
            {
                return _length;
            }

            set
            {
                _length = value;
            }
        }

        /// <summary>
        /// USSD string.
        /// </summary>
        /// <value>Ussd string represented in string.</value>
        public string UssdString
        {
            get
            {
                return _ussdString;
            }

            set
            {
                _ussdString = value;
            }
        }
    }

    /// <summary>
    /// A class which defines release complete message notification type.
    /// </summary>
    public class SsReleaseCompleteMsgInfo
    {
        internal byte Length;
        internal byte[] Msg;

        internal SsReleaseCompleteMsgInfo()
        {
        }

        /// <summary>
        /// Specifies the Release complete messageg length.
        /// </summary>
        /// <value>Length of release complete message in byte.</value>
        public byte MsgLength
        {
            get
            {
                return Length;
            }
        }

        /// <summary>
        /// Specifies the release complete message.
        /// </summary>
        /// <value>Release complete message represented in byte array.</value>
        public byte[] Message
        {
            get
            {
                return Msg;
            }
        }
    }

    /// <summary>
    /// A class which defines SS forward record information.
    /// </summary>
    public class SsForwardRecord
    {
        internal SsClass SsClass;
        internal SsStatus SsStatus;
        internal SsForwardCondition Condition;
        internal bool IsNumPresent;
        internal SsNoReplyTime NoReply;
        internal SsForwardTypeOfNumber Type;
        internal SsForwardNumberingPlanIdentity NumIdPlan;
        internal string ForwardNum;

        internal SsForwardRecord()
        {
        }

        /// <summary>
        /// SS class
        /// </summary>
        /// <value>SS class type.</value>
        public SsClass Class
        {
            get
            {
                return SsClass;
            }
        }

        /// <summary>
        /// Call forwarding SS status.
        /// </summary>
        /// <value>Status of SS call forwarding.</value>
        public SsStatus Status
        {
            get
            {
                return SsStatus;
            }
        }

        /// <summary>
        /// Call forward types providing various conditions when a call can be forwarded.
        /// </summary>
        /// <value>Forwarding condition of SS call forward.</value>
        public SsForwardCondition ForwardCondition
        {
            get
            {
                return Condition;
            }
        }

        /// <summary>
        /// Flag that indicates whether call forwarding number is present.
        /// </summary>
        /// <value>Boolean value to check the presence of call forwarding number.</value>
        public bool IsForwardingNumberPresent
        {
            get
            {
                return IsNumPresent;
            }
        }

        /// <summary>
        /// No reply time.
        /// </summary>
        /// <value>Waiting time when there is no reply.</value>
        public SsNoReplyTime NoReplyTime
        {
            get
            {
                return NoReply;
            }
        }

        /// <summary>
        /// Type of number.
        /// </summary>
        /// <value>SS call forward type of number.</value>
        public SsForwardTypeOfNumber Ton
        {
            get
            {
                return Type;
            }
        }

        /// <summary>
        /// Numbering Plan Identity.
        /// </summary>
        /// <value>SS call forward numbering plan identity.</value>
        public SsForwardNumberingPlanIdentity Npi
        {
            get
            {
                return NumIdPlan;
            }
        }

        /// <summary>
        /// Forwarded number.
        /// </summary>
        /// <value>Call forwarding number.</value>
        public string ForwardingNumber
        {
            get
            {
                return ForwardNum;
            }
        }
    }

    /// <summary>
    /// A class which defines values for SS call forwarding record. Applicable to 3GPP(GSM/UMTS/LTE) only.
    /// </summary>
    public class SsForwardResponse
    {
        internal int RecordNum;
        internal IEnumerable<SsForwardRecord> RecordList;

        internal SsForwardResponse()
        {
        }

        /// <summary>
        /// Record number.
        /// </summary>
        /// <value>Record value represented in integer.</value>
        public int RecordNumber
        {
            get
            {
                return RecordNum;
            }
        }

        /// <summary>
        /// Specifies the maximum of SS forward records.
        /// </summary>
        /// <value>A list of instances of SsForwardRecord.</value>
        public IEnumerable<SsForwardRecord> Record
        {
            get
            {
                return RecordList;
            }
        }
    }

    /// <summary>
    /// A class which defines SS call barring record information.
    /// </summary>
    public class SsBarringRecord
    {
        internal SsClass SsClass;
        internal SsStatus SsStatus;
        internal SsBarringType SsType;

        internal SsBarringRecord()
        {
        }

        /// <summary>
        /// SS class
        /// </summary>
        /// <value>SS class type.</value>
        public SsClass Class
        {
            get
            {
                return SsClass;
            }
        }

        /// <summary>
        /// SS status.
        /// </summary>
        /// <value>Status of SS call barring.</value>
        public SsStatus Status
        {
            get
            {
                return SsStatus;
            }
        }

        /// <summary>
        /// Call barring types providing various barring conditions on which calls are barred.
        /// </summary>
        /// <value>Type of SS call barring.</value>
        public SsBarringType BarringType
        {
            get
            {
                return SsType;
            }
        }
    }

    /// <summary>
    /// A class which defines values for SS call barring record. Applicable to 3GPP(GSM/UMTS/LTE) only.
    /// </summary>
    public class SsBarringResponse
    {
        internal int RecordNum;
        internal IEnumerable<SsBarringRecord> RecordList;

        internal SsBarringResponse()
        {
        }

        /// <summary>
        /// Record number.
        /// </summary>
        /// <value>Record value represented in integer.</value>
        public int RecordNumber
        {
            get
            {
                return RecordNum;
            }
        }

        /// <summary>
        /// Specifies the maximum of SS barring records.
        /// </summary>
        /// <value>A list of instances of SsBarringRecord.</value>
        public IEnumerable<SsBarringRecord> Record
        {
            get
            {
                return RecordList;
            }
        }
    }

    /// <summary>
    /// A class which defines SS waiting record information.
    /// </summary>
    public class SsWaitingRecord
    {
        internal SsClass SsClass;
        internal SsStatus SsStatus;

        internal SsWaitingRecord()
        {
        }

        /// <summary>
        /// SS class
        /// </summary>
        /// <value>SS class type.</value>
        public SsClass Class
        {
            get
            {
                return SsClass;
            }
        }

        /// <summary>
        /// SS status.
        /// </summary>
        /// <value>Status of SS call waiting.</value>
        public SsStatus Status
        {
            get
            {
                return SsStatus;
            }
        }
    }

    /// <summary>
    /// A class which defines values for SS call waiting record. Applicable to 3GPP(GSM/UMTS/LTE) only.
    /// </summary>
    public class SsWaitingResponse
    {
        internal int RecordNum;
        internal IEnumerable<SsWaitingRecord> RecordList;

        internal SsWaitingResponse()
        {
        }

        /// <summary>
        /// Record number.
        /// </summary>
        /// <value>Record value represented in integer.</value>
        public int RecordNumber
        {
            get
            {
                return RecordNum;
            }
        }

        /// <summary>
        /// Specifies the maximum of SS waiting records.
        /// </summary>
        /// <value>A list of instances of SsWaitingRecord.</value>
        public IEnumerable<SsWaitingRecord> Record
        {
            get
            {
                return RecordList;
            }
        }
    }

    /// <summary>
    /// A class which defines SUPS information message notification type.
    /// </summary>
    public class SsInfo
    {
        internal SsCause Cse;
        internal SsInfoType Type;

        internal SsInfo()
        {
        }

        /// <summary>
        /// SS error cause.
        /// </summary>
        /// <value>Ss request result.</value>
        public SsCause Cause
        {
            get
            {
                return Cse;
            }
        }

        /// <summary>
        /// SUPS information.
        /// </summary>
        /// <value>Ss information type.</value>
        public SsInfoType SsType
        {
            get
            {
                return Type;
            }
        }
    }

    /// <summary>
    /// A class which defines parameters related to call barring.
    /// </summary>
    public class SsBarringInfo
    {
        private SsClass _class;
        private SsBarringMode _mode;
        private SsBarringType _type;
        private string _password;
        private SsBarringInfo()
        {
        }

        /// <summary>
        /// A constructor for instantiating SsBarringInfo class with the necessary parameters.
        /// </summary>
        /// <param name="classType">Call type.</param>
        /// <param name="mode">Barring mode.</param>
        /// <param name="type">Barring type.</param>
        /// <param name="password">Password (3GPP(GSM/UMTS/LTE) Specific).</param>
        public SsBarringInfo(SsClass classType, SsBarringMode mode, SsBarringType type, string password)
        {
            _class = classType;
            _mode = mode;
            _type = type;
            _password = password;
        }

        internal SsClass Class
        {
            get
            {
                return _class;
            }
        }

        internal SsBarringMode Mode
        {
            get
            {
                return _mode;
            }
        }

        internal SsBarringType Type
        {
            get
            {
                return _type;
            }
        }

        internal string Password
        {
            get
            {
                return _password;
            }
        }
    }

    /// <summary>
    /// A class which defines the parameters related to forward info.
    /// </summary>
    public class SsForwardInfo
    {
        private SsClass _class;
        private SsForwardMode _mode;
        private SsForwardCondition _condition;
        private SsNoReplyTime _noReplyTimer;
        private SsForwardTypeOfNumber _ton;
        private SsForwardNumberingPlanIdentity _npi;
        private string _phoneNumber;
        private SsForwardInfo()
        {
        }

        /// <summary>
        /// A constructor for instantiating SsForwardInfo class with the necessary parameters.
        /// </summary>
        /// <param name="classType">SS Class.</param>
        /// <param name="mode">Forward Mode.</param>
        /// <param name="condition">Forward Condition.</param>
        /// <param name="time">No reply wait time 5-30 secs in intervals of 5(3GPP(GSM/UMTS/LTE) Specific).</param>
        /// <param name="ton">Type of number.</param>
        /// <param name="npi">Numbering plan identity.</param>
        /// <param name="number">Phone number.</param>
        public SsForwardInfo(SsClass classType, SsForwardMode mode, SsForwardCondition condition, SsNoReplyTime time, SsForwardTypeOfNumber ton, SsForwardNumberingPlanIdentity npi, string number)
        {
            _class = classType;
            _mode = mode;
            _condition = condition;
            _noReplyTimer = time;
            _ton = ton;
            _npi = npi;
            _phoneNumber = number;
        }

        internal SsClass Class
        {
            get
            {
                return _class;
            }
        }

        internal SsForwardMode Mode
        {
            get
            {
                return _mode;
            }
        }

        internal SsForwardCondition Condition
        {
            get
            {
                return _condition;
            }
        }

        internal SsNoReplyTime NoReplyTimer
        {
            get
            {
                return _noReplyTimer;
            }
        }

        internal SsForwardTypeOfNumber Ton
        {
            get
            {
                return _ton;
            }
        }

        internal SsForwardNumberingPlanIdentity Npi
        {
            get
            {
                return _npi;
            }
        }

        internal string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
        }
    }

    /// <summary>
    /// A class which defines parameters related to call waiting.
    /// </summary>
    public class SsWaitingInfo
    {
        private SsClass _class;
        private SsCallWaitingMode _mode;
        private SsWaitingInfo()
        {
        }

        /// <summary>
        /// A constructor for instantiating SsWaitingInfo class with necessary parameters.
        /// </summary>
        /// <param name="ssClass">Call type.</param>
        /// <param name="mode">Call waiting mode.</param>
        public SsWaitingInfo(SsClass ssClass, SsCallWaitingMode mode)
        {
            _class = ssClass;
            _mode = mode;
        }

        internal SsClass Class
        {
            get
            {
                return _class;
            }
        }

        internal SsCallWaitingMode Mode
        {
            get
            {
                return _mode;
            }
        }
    }

    /// <summary>
    /// A class which defines values for calling line identity service. Applicable to 3GPP(GSM/UMTS/LTE) only.
    /// </summary>
    public class SsCliResponse
    {
        internal SsLineIdentificationType LineType;
        internal SsCliStatus CliStatus;
        internal SsCliResponse()
        {
        }

        /// <summary>
        /// Various line identification types.
        /// </summary>
        public SsLineIdentificationType Type
        {
            get
            {
                return LineType;
            }
        }

        /// <summary>
        /// Line identification status from the network.
        /// </summary>
        public SsCliStatus Status
        {
            get
            {
                return CliStatus;
            }
        }
    }

    /// <summary>
    /// A class which defines USSD response data. Applicable to 3GPP(GSM/UMTS/LTE) only.
    /// </summary>
    public class SsUssdResponse
    {
        internal SsUssdType UssdType;
        internal SsUssdStatus UssdStatus;
        internal byte DcsInfo;
        internal int UssdLength;
        internal string UssdInfo;
        internal SsUssdResponse()
        {
        }

        /// <summary>
        /// USSD Type.
        /// </summary>
        public SsUssdType Type
        {
            get
            {
                return UssdType;
            }
        }

        /// <summary>
        /// USSD Status.
        /// </summary>
        public SsUssdStatus Status
        {
            get
            {
                return UssdStatus;
            }
        }

        /// <summary>
        /// DCS.
        /// </summary>
        public byte Dcs
        {
            get
            {
                return DcsInfo;
            }
        }

        /// <summary>
        /// USSD string length.
        /// </summary>
        public int Length
        {
            get
            {
                return UssdLength;
            }
        }

        /// <summary>
        /// USSD String.
        /// </summary>
        public string UssdString
        {
            get
            {
                return UssdInfo;
            }
        }
    }
}
