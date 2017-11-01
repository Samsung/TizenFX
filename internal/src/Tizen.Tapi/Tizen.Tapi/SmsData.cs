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
    /// A class which defines incoming SMS message notification data.
    /// </summary>
    public class SmsIncomingMessageNoti
    {
        internal string ScaVal;
        internal int MsgLength;
        internal string Data;
        internal SmsNetType FormatType;

        internal SmsIncomingMessageNoti()
        {
        }

        /// <summary>
        /// SCA.
        /// </summary>
        /// <value>Sca value represented in string.</value>
        public string Sca
        {
            get
            {
                return ScaVal;
            }
        }

        /// <summary>
        /// Message length.
        /// </summary>
        /// <value>Length of incoming message.</value>
        public int MessageLength
        {
            get
            {
                return MsgLength;
            }
        }

        /// <summary>
        /// Data.
        /// </summary>
        /// <value>Data representing incoming message information.</value>
        public string SzData
        {
            get
            {
                return Data;
            }
        }

        /// <summary>
        /// SMS format.
        /// </summary>
        /// <value>Format of the incoming SMS.</value>
        public SmsNetType Format
        {
            get
            {
                return FormatType;
            }
        }
    }

    /// <summary>
    /// A class which defines incoming CB message notification data.
    /// </summary>
    public class SmsIncomingCbMessageNoti
    {
        internal SmsCbMsgType CbType;
        internal short Len;
        internal string Data;

        internal SmsIncomingCbMessageNoti()
        {
        }

        /// <summary>
        /// Cell Broadcast message type.
        /// </summary>
        /// <value>Type of cell broadcast message.</value>
        public SmsCbMsgType Type
        {
            get
            {
                return CbType;
            }
        }

        /// <summary>
        /// Size of MsgData (which is the actual TPDU message).
        /// </summary>
        /// <value>Length of message data.</value>
        public short Length
        {
            get
            {
                return Len;
            }
        }

        /// <summary>
        /// Cell broadcast message data.
        /// </summary>
        /// <value>Message data representing cell broadcast message.</value>
        public string SzMsgData
        {
            get
            {
                return Data;
            }
        }
    }

    /// <summary>
    /// A class which defines incoming ETWS message notification data.
    /// </summary>
    public class SmsIncomingEtwsMessageNoti
    {
        internal SmsEtwsMsgType EtwsType;
        internal short Len;
        internal string Data;

        internal SmsIncomingEtwsMessageNoti()
        {
        }

        /// <summary>
        /// ETWS message type.
        /// </summary>
        /// <value>Type of ETWS message.</value>
        public SmsEtwsMsgType Type
        {
            get
            {
                return EtwsType;
            }
        }

        /// <summary>
        /// Size of MsgData (which is the actual TPDU message).
        /// </summary>
        /// <value>Length of message data.</value>
        public short Length
        {
            get
            {
                return Len;
            }
        }

        /// <summary>
        /// ETWS message data.
        /// </summary>
        /// <value>Message data representing ETWS message.</value>
        public string SzMsgData
        {
            get
            {
                return Data;
            }
        }
    }
}
