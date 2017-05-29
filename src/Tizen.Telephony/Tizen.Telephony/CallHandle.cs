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
    /// This Class provides API's to get the information about calls.
    /// </summary>
    public class CallHandle
    {
        private IntPtr _callHandle;

        /// <summary>
        /// Enumeration for the call status.
        /// </summary>
        public enum CallStatus
        {
            /// <summary>
            /// Idle status
            /// </summary>
            Idle,
            /// <summary>
            /// Active status
            /// </summary>
            Active,
            /// <summary>
            /// Held status
            /// </summary>
            Held,
            /// <summary>
            /// Dialing status
            /// </summary>
            Dialing,
            /// <summary>
            /// Alerting status
            /// </summary>
            Alerting,
            /// <summary>
            /// Incoming status
            /// </summary>
            Incoming,
            /// <summary>
            /// Unavailable
            /// </summary>
            Unavailable
        };

        /// <summary>
        /// Enumeration for the call type.
        /// </summary>
        public enum CallType
        {
            /// <summary>
            /// Voice call
            /// </summary>
            Voice,
            /// <summary>
            /// Video call
            /// </summary>
            Video,
            /// <summary>
            /// Emergency call
            /// </summary>
            E911,
            /// <summary>
            /// Unavailable
            /// </summary>
            Unavailable
        };

        /// <summary>
        /// Enumeration for the call direction.
        /// </summary>
        public enum CallDirection
        {
            /// <summary>
            /// MO(Mobile Originated) call
            /// </summary>
            Mo,
            /// <summary>
            /// MT(Mobile Terminated) call
            /// </summary>
            Mt,
            /// <summary>
            /// Unavailable
            /// </summary>
            Unavailable
        };

        /// <summary>
        /// Gets the call handle ID.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>
        /// The id of the call handle
        /// 0 if unable to complete the operation
        /// </value>
        public uint HandleId
        {
            get
            {
                uint handleId;
                TelephonyError error = Interop.Call.GetHandleId(_callHandle, out handleId);
                if (error != TelephonyError.None)
                {
                    Tizen.Log.Error(Interop.Telephony.LogTag, "GetHandleId Failed with Error " + error);
                    return 0;
                }

                return handleId;
            }
        }

        /// <summary>
        /// Gets the call number.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>
        /// The number of the call
        /// empty string if unable to complete the operation
        /// </value>
        public string Number
        {
            get
            {
                string number;
                TelephonyError error = Interop.Call.GetNumber(_callHandle, out number);
                if (error != TelephonyError.None)
                {
                    Tizen.Log.Error(Interop.Telephony.LogTag, "GetNumber Failed with Error " + error);
                    return "";
                }

                return number;
            }
        }

        /// <summary>
        /// Gets the call type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>
        /// The type of the call
        /// </value>
        public CallType Type
        {
            get
            {
                CallType callType;
                TelephonyError error = Interop.Call.GetType(_callHandle, out callType);
                if (error != TelephonyError.None)
                {
                    Tizen.Log.Error(Interop.Telephony.LogTag, "GetType Failed with Error " + error);
                    return CallType.Unavailable;
                }

                return callType;
            }
        }

        /// <summary>
        /// Gets the call status.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>
        /// The status of the call
        /// </value>
        public CallStatus Status
        {
            get
            {
                CallStatus callStatus;
                TelephonyError error = Interop.Call.GetStatus(_callHandle, out callStatus);
                if (error != TelephonyError.None)
                {
                    Tizen.Log.Error(Interop.Telephony.LogTag, "GetStatus Failed with Error " + error);
                    return CallStatus.Unavailable;
                }

                return callStatus;
            }
        }

        /// <summary>
        /// Gets whether the call is MO(Mobile Originated) call or MT(Mobile Terminated).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>
        /// The direction of the call
        /// </value>
        /// <exception cref="InvalidOperationException">
        /// This Exception can occur due to:
        /// 1. Operation Not Supported
        /// </exception>
        public CallDirection Direction
        {
            get
            {
                CallDirection callDirection;
                TelephonyError error = Interop.Call.GetDirection(_callHandle, out callDirection);
                if (error != TelephonyError.None)
                {
                    Tizen.Log.Error(Interop.Telephony.LogTag, "GetDirection Failed with Error " + error);
                    return CallDirection.Unavailable;
                }

                return callDirection;
            }

        }

        /// <summary>
        /// Gets whether the call is conference call or not.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>
        /// The value whether the call is conference call or not. (true: Conference call, false: Single call)
        /// </value>
        public bool ConferenceStatus
        {
            get
            {
                bool callConfStatus;
                TelephonyError error = Interop.Call.GetConferenceStatus(_callHandle, out callConfStatus);
                if (error != TelephonyError.None)
                {
                    Tizen.Log.Error(Interop.Telephony.LogTag, "GetConferenceStatus Failed with Error " + error);
                    return false;
                }

                return callConfStatus;
            }

        }

        internal CallHandle(IntPtr handle)
        {
            _callHandle = handle;
        }
    }
}
