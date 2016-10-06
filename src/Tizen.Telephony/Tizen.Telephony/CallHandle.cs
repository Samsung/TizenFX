/// Copyright 2016 by Samsung Electronics, Inc.
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.

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
        /// <returns>
        /// The id of the call handle
        /// 0 if unable to complete the operation
        /// </returns>
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
        /// <returns>
        /// The number of the call
        /// empty string if unable to complete the operation
        /// </returns>
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
        /// <returns>
        /// The type of the call
        /// </returns>
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
        /// <returns>
        /// The status of the call
        /// </returns>
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
        /// <returns>
        /// The direction of the call
        /// </returns>
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
        /// <returns>
        /// The value whether the call is conference call or not. (true: Conference call, false: Single call)
        /// </returns>
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
