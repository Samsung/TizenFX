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

using System.Text;
using System.Collections.Generic;

namespace Tizen.Tapi
{
    /// <summary>
    /// A class which defines values for USSD request type. Applicable to 3GPP(GSM?UMTS/LET) only.
    /// </summary>
    public class SsUssdMsgInfo
    {
        internal SsUssdType SsType;
        internal byte SsDcs;
        internal int SsLength;
        internal string Ussd;

        internal SsUssdMsgInfo()
        {
        }

        /// <summary>
        /// USSD type.
        /// </summary>
        /// <value>Type of USSD represented in SsUssdType enum.</value>
        public SsUssdType Type
        {
            get
            {
                return SsType;
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
                return SsDcs;
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
                return SsLength;
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
                return Ussd;
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
}
