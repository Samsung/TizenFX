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
    /// This class provides APIs that allow you to extract the information stored on a SIM card.
    /// It includes properties such as IccId, which allows users to retrieve the Integrated
    //  Circuit Card Identification (ICCID) of the SIM card. By leveraging these features,
    /// developers can gather valuable information about the SIM card and incorporate it into their applications effectively.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Obsolete("Deprecated since API13, will be removed in API15.")]
    public class Sim
    {
        internal IntPtr _handle;

        /// <summary>
        /// The SIM class constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="handle">
        /// SlotHandle received in the Manager.Init API.
        /// </param>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="ArgumentNullException">
        /// This exception occurs if the handle provided is null.
        /// </exception>
        [Obsolete("Deprecated since API13, will be removed in API15.")]
        public Sim(SlotHandle handle)
        {
            if (handle == null)
            {
                throw new ArgumentNullException();
            }

            _handle = handle._handle;
        }

        /// <summary>
        /// Enumeration for the state of the SIM card.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated since API13, will be removed in API15.")]
        public enum State
        {
            /// <summary>
            /// The SIM is not available on this device.
            /// </summary>
            Unavailable,
            /// <summary>
            /// The SIM is locked.
            /// </summary>
            Locked,
            /// <summary>
            /// The SIM is available on this device (SIM is not locked).
            /// </summary>
            Available,
            /// <summary>
            /// The SIM is in transition between states.
            /// </summary>
            Unknown
        }

        /// <summary>
        /// Enumeration for the lock state of the SIM card.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated since API13, will be removed in API15.")]
        public enum LockState
        {
            /// <summary>
            /// The SIM is not in lock.
            /// </summary>
            Unknown,
            /// <summary>
            /// The SIM is PIN (Personal Identification Number) locked.
            /// </summary>
            PinRequired,
            /// <summary>
            /// The SIM is PUK (Personal Unblocking Code) locked.
            /// </summary>
            PukRequired,
            /// <summary>
            /// The SIM is permanently blocked (All the attempts for PIN/PUK failed).
            /// </summary>
            PermLocked,
            /// <summary>
            /// The SIM is NCK (Network Control Key) locked.
            /// </summary>
            NckRequired
        }

        /// <summary>
        /// Enumeration for the type of the SIM card.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated since API13, will be removed in API15.")]
        public enum ApplicationType
        {
            /// <summary>
            /// SIM (GSM) application.
            /// </summary>
            Sim = 0x01,
            /// <summary>
            /// USIM application.
            /// </summary>
            Usim = 0x02,
            /// <summary>
            /// CDMA application.
            /// </summary>
            Csim = 0x04,
            /// <summary>
            /// ISIM application.
            /// </summary>
            Isim = 0x08
        }

        /// <summary>
        /// Gets the Integrated Circuit Card IDentification (ICC-ID).
        /// The Integrated Circuit Card Identification number internationally identifies SIM cards.
        /// </summary>
        /// <remarks>
        /// To avoid the unexpected behavior of old version applications that have http://tizen.org/privilege/telephony privilege. There is an exceptional handling in case of permission denied.
        /// For an application with API version 6 or higher, if an application doesn't have http://tizen.org/privilege/securesysteminfo privilege, it sets with empty string.
        /// For an application with API version lower than 6. if an application has http://tizen.org/privilege/telephony privilege, it sets with a pseudo value.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/securesysteminfo</privilege>
        /// <privlevel>partner</privlevel>
        /// <value>
        /// The Integrated Circuit Card Identification.
        /// Empty string if unable to complete the operation.
        /// </value>
        /// <precondition>
        /// The SIM state must be Available.
        /// </precondition>
        [Obsolete("Deprecated since API13, will be removed in API15.")]
        public string IccId
        {
            get
            {
                string iccId;
                TelephonyError error = Interop.Sim.GetIccId(_handle, out iccId);
                if (error != TelephonyError.None)
                {
                    Tizen.Log.Error(Interop.Telephony.LogTag, "GetIccId Failed with error " + error);
                    return "";
                }

                return iccId;
            }
        }

        /// <summary>
        /// Gets the SIM Operator (MCC [3 digits] + MNC [2~3 digits]).
        /// The Operator is embedded in the SIM card.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <value>
        /// The SIM Operator.
        /// Empty string if unable to complete the operation.
        /// </value>
        /// <precondition>
        /// The SIM state must be Available.
        /// </precondition>
        [Obsolete("Deprecated since API13, will be removed in API15.")]
        public string Operator
        {
            get
            {
                string simOperator;
                TelephonyError error = Interop.Sim.GetOperator(_handle, out simOperator);
                if (error != TelephonyError.None)
                {
                    Tizen.Log.Error(Interop.Telephony.LogTag, "GetOperator Failed with error " + error);
                    return "";
                }

                return simOperator;
            }
        }

        /// <summary>
        /// Gets the Mobile Subscription Identification Number (MSIN [9~10 digits]) of the SIM provider.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <value>
        /// The Mobile Subscription Identification Number.
        /// Empty string if unable to complete the operation.
        /// </value>
        /// <precondition>
        /// The SIM state must be Available.
        /// </precondition>
        [Obsolete("Deprecated since API13, will be removed in API15.")]
        public string Msin
        {
            get
            {
                string msin;
                TelephonyError error = Interop.Sim.GetMsin(_handle, out msin);
                if (error != TelephonyError.None)
                {
                    Tizen.Log.Error(Interop.Telephony.LogTag, "GetMsin Failed with error " + error);
                    return "";
                }

                return msin;
            }
        }

        /// <summary>
        /// Gets the Service Provider Name (SPN) of the SIM card.
        /// Gets Service Provider Name embedded in the SIM card. If this value is not stored in the SIM card, an empty string will be returned.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <value>
        /// The Service Provider Name.
        /// Empty string if unable to complete the operation.
        /// </value>
        /// <precondition>
        /// The SIM state must be Available.
        /// </precondition>
        [Obsolete("Deprecated since API13, will be removed in API15.")]
        public string Spn
        {
            get
            {
                string spn;
                TelephonyError error = Interop.Sim.GetSpn(_handle, out spn);
                if (error != TelephonyError.None)
                {
                    Tizen.Log.Error(Interop.Telephony.LogTag, "GetSpn Failed with error " + error);
                    return "";
                }

                return spn;
            }
        }

        /// <summary>
        /// Checks whether the current SIM card is different from the previous SIM card.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <value>
        /// true if the current SIM card is different from the previous SIM card, otherwise false if the SIM card is not changed.
        /// </value>
        /// <precondition>
        /// The SIM state must be Available.
        /// </precondition>
        [Obsolete("Deprecated since API13, will be removed in API15.")]
        public bool IsChanged
        {
            get
            {
                int ischanged;
                bool isChanged = false; ;
                TelephonyError error = Interop.Sim.IsChanged(_handle, out ischanged);
                if (error != TelephonyError.None)
                {
                    Tizen.Log.Error(Interop.Telephony.LogTag, "IsChanged Failed with error " + error);
                    return false;
                }

                if (ischanged > 0)
                {
                    isChanged = true;
                }

                return isChanged;
            }
        }

        /// <summary>
        /// Gets the state of the SIM.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <value>
        /// The current state of the SIM.
        /// </value>
        [Obsolete("Deprecated since API13, will be removed in API15.")]
        public State CurrentState
        {
            get
            {
                State currentState;
                TelephonyError error = Interop.Sim.GetState(_handle, out currentState);
                if (error != TelephonyError.None)
                {
                    Tizen.Log.Error(Interop.Telephony.LogTag, "GetState Failed with error " + error);
                    return State.Unavailable;
                }

                return currentState;
            }
        }

        /// <summary>
        /// Gets the count of an application on the UICC.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <value>
        /// The masking value for below values are provided by the enumeration ApplicationType.
        /// 0 if unable to complete the operation.
        /// </value>
        /// <precondition>
        /// The SIM state must be Available.
        /// </precondition>
        [Obsolete("Deprecated since API13, will be removed in API15.")]
        public uint ApplicationList
        {
            get
            {
                uint appList;
                TelephonyError error = Interop.Sim.GetApplicationList(_handle, out appList);
                if (error != TelephonyError.None)
                {
                    Tizen.Log.Error(Interop.Telephony.LogTag, "GetApplicationList Failed with error " + error);
                    return 0;
                }

                return appList;
            }
        }

        /// <summary>
        /// Gets the subscriber number embedded in the SIM card. This value contains the MSISDN related to the subscriber.
        /// If this value is not stored in SIM card, an empty string will be returned.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <value>
        /// The subscriber number in the SIM.
        /// Empty string if unable to complete the operation.
        /// </value>
        /// <precondition>
        /// The SIM state must be Available.
        /// </precondition>
        [Obsolete("Deprecated since API13, will be removed in API15.")]
        public string SubscriberNumber
        {
            get
            {
                string subscriberNumber;
                TelephonyError error = Interop.Sim.GetSubscriberNumber(_handle, out subscriberNumber);
                if (error != TelephonyError.None)
                {
                    Tizen.Log.Error(Interop.Telephony.LogTag, "GetSubscriberNumber Failed with error " + error);
                    return "";
                }

                return subscriberNumber;
            }
        }

        /// <summary>
        /// Gets the subscriber ID.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <value>
        /// The subscriber ID.
        /// Empty string if unable to complete the operation.
        /// </value>
        /// <precondition>
        /// The SIM state must be Available.
        /// </precondition>
        [Obsolete("Deprecated since API13, will be removed in API15.")]
        public string SubscriberId
        {
            get
            {
                string subscriberId;
                TelephonyError error = Interop.Sim.GetSubscriberId(_handle, out subscriberId);
                if (error != TelephonyError.None)
                {
                    Tizen.Log.Error(Interop.Telephony.LogTag, "GetSubscriberId Failed with error " + error);
                    return "";
                }

                return subscriberId;
            }
        }

        /// <summary>
        /// Gets the lock state of the SIM.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <value>
        /// The current lock state of the SIM.
        /// </value>
        /// <precondition>
        /// The SIM state must be Available.
        /// </precondition>
        [Obsolete("Deprecated since API13, will be removed in API15.")]
        public LockState CurrentLockState
        {
            get
            {
                LockState currentLockState;
                TelephonyError error = Interop.Sim.GetLockState(_handle, out currentLockState);
                if (error != TelephonyError.None)
                {
                    Tizen.Log.Error(Interop.Telephony.LogTag, "GetLockState Failed with error " + error);
                    return LockState.Unknown;
                }

                return currentLockState;
            }
        }

        /// <summary>
        /// Gets the GID1 (Group Identifier Level 1).
        /// Gets Group Identifier Level 1 (GID1) embedded in the SIM card. If this value is not stored in SIM card, an empty string will be returned.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <value>
        /// The GID1 (Group Identifier Level 1).
        /// Empty string if unable to complete the operation.
        /// </value>
        /// <precondition>
        /// The SIM state must be Available.
        /// </precondition>
        [Obsolete("Deprecated since API13, will be removed in API15.")]
        public string GroupId1
        {
            get
            {
                string groupId1;
                TelephonyError error = Interop.Sim.GetGroupId1(_handle, out groupId1);
                if (error != TelephonyError.None)
                {
                    Tizen.Log.Error(Interop.Telephony.LogTag, "GetGroupId1 Failed with error " + error);
                    return "";
                }

                return groupId1;
            }
        }

        /// <summary>
        /// Gets the call forwarding indicator state of the SIM.
        /// If the state is true, the incoming call will be forwarded to the selected number. State indicates the CFU (Call Forwarding Unconditional) indicator status - Voice (3GPP TS 31.102 4.2.64 EF CFIS).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/telephony</privilege>
        /// <value>
        /// The value whether the incoming call will be forwarded or not (true: forwarded, false: not forwarded).
        /// </value>
        /// <precondition>
        /// The SIM state must be Available.
        /// </precondition>
        [Obsolete("Deprecated since API13, will be removed in API15.")]
        public bool CallForwardingIndicatorState
        {
            get
            {
                bool callForwardingIndicatorState;
                TelephonyError error = Interop.Sim.GetCallForwardingIndicatorState(_handle, out callForwardingIndicatorState);
                if (error != TelephonyError.None)
                {
                    Tizen.Log.Error(Interop.Telephony.LogTag, "GetCallForwardingIndicatorState Failed with error " + error);
                    return false;
                }

                return callForwardingIndicatorState;
            }
        }
    }
}
