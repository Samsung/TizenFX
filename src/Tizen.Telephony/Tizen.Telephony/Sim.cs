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
    /// This Class provides API's that allows you to extract information stored on a SIM card
    /// </summary>
    public class Sim
    {
        /// <summary>
        /// Enumeration for the state of SIM card.
        /// </summary>
        public enum State
        {
            /// <summary>
            /// SIM is not available on this device
            /// </summary>
            Unavailable,
            /// <summary>
            /// SIM is locked
            /// </summary>
            Locked,
            /// <summary>
            /// SIM is available on this device (SIM is not locked)
            /// </summary>
            Available,
            /// <summary>
            /// SIM is in transition between states
            /// </summary>
            Unknown
        }

        /// <summary>
        /// Enumeration for the lock state of SIM card.
        /// </summary>
        public enum LockState
        {
            /// <summary>
            /// SIM is not in lock
            /// </summary>
            Unknown,
            /// <summary>
            /// SIM is PIN(Personal Identification Number) locked
            /// </summary>
            PinRequired,
            /// <summary>
            /// SIM is PUK(Personal Unblocking Code) locked
            /// </summary>
            PukRequired,
            /// <summary>
            /// SIM is permanently blocked(All the attempts for PIN/PUK failed)
            /// </summary>
            PermLocked,
            /// <summary>
            /// SIM is NCK(Network Control Key) locked
            /// </summary>
            NckRequired
        }

        /// <summary>
        /// Enumeration for the type of SIM card.
        /// </summary>
        public enum ApplicationType
        {
            /// <summary>
            /// SIM(GSM) Application
            /// </summary>
            Sim = 0x01,
            /// <summary>
            /// USIM Application
            /// </summary>
            Usim = 0x02,
            /// <summary>
            /// CDMA Application
            /// </summary>
            Csim = 0x04,
            /// <summary>
            /// ISIM Application
            /// </summary>
            Isim = 0x08
        }

        /// <summary>
        /// Sim Class Constructor
        /// </summary>
        /// <param name="handle">
        /// SlotHandle received in the Manager.Init API
        /// </param>
        public Sim(SlotHandle handle)
        {
            _handle = handle._handle;
        }

        /// <summary>
        /// Gets the Integrated Circuit Card IDentification (ICC-ID).
        /// The Integrated Circuit Card Identification number internationally identifies SIM cards.
        /// </summary>
        /// <priviledge>
        /// http://tizen.org/privilege/telephony
        /// </priviledge>
        /// <returns>
        /// The Integrated Circuit Card Identification
        /// empty string if unable to complete the operation
        /// </returns>
        /// <precondition>
        /// The SIM state must be Available
        /// </precondition>
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
        /// <priviledge>
        /// http://tizen.org/privilege/telephony
        /// </priviledge>
        /// <returns>
        /// The SIM Operator
        /// empty string if unable to complete the operation
        /// </returns>
        /// <precondition>
        /// The SIM state must be Available
        /// </precondition>
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
        /// <priviledge>
        /// http://tizen.org/privilege/telephony
        /// </priviledge>
        /// <returns>
        /// The Mobile Subscription Identification Number
        /// empty string if unable to complete the operation
        /// </returns>
        /// <precondition>
        /// The SIM state must be Available
        /// </precondition>
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
        /// Gets Service Provider Name embedded in the SIM card.If this value is not stored in SIM card, empty string will be returned.
        /// </summary>
        /// <priviledge>
        /// http://tizen.org/privilege/telephony
        /// </priviledge>
        /// <returns>
        /// The Service Provider Name
        /// empty string if unable to complete the operation
        /// </returns>
        /// <precondition>
        /// The SIM state must be Available
        /// </precondition>
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
        /// <priviledge>
        /// http://tizen.org/privilege/telephony
        /// </priviledge>
        /// <returns>
        /// true if the current SIM card is different from the previous SIM card, otherwise false if the SIM card is not changed
        /// </returns>
        /// <precondition>
        /// The SIM state must be Available
        /// </precondition>
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
        /// <priviledge>
        /// http://tizen.org/privilege/telephony
        /// </priviledge>
        /// <returns>
        /// The current state of the SIM
        /// </returns>
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
        /// Gets the list of application on UICC.
        /// </summary>
        /// <priviledge>
        /// http://tizen.org/privilege/telephony
        /// </priviledge>
        /// <returns>
        /// The masking value for below values are provided by the enum ApplicationType
        /// 0 if unable to complete the operation
        /// </returns>
        /// <precondition>
        /// The SIM state must be Available
        /// </precondition>
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
        /// Gets subscriber number embedded in the SIM card. This value contains MSISDN related to the subscriber.
        /// If this value is not stored in SIM card, empty string will be returned.
        /// </summary>
        /// <priviledge>
        /// http://tizen.org/privilege/telephony
        /// </priviledge>
        /// <returns>
        /// The subscriber number in the SIM
        /// empty string if unable to complete the operation
        /// </returns>
        /// <precondition>
        /// The SIM state must be Available
        /// </precondition>
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
        /// Gets the Subscriber ID.
        /// </summary>
        /// <priviledge>
        /// http://tizen.org/privilege/telephony
        /// </priviledge>
        /// <returns>
        /// The subscriber ID
        /// empty string if unable to complete the operation
        /// </returns>
        /// <precondition>
        /// The SIM state must be Available
        /// </precondition>
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
        /// <priviledge>
        /// http://tizen.org/privilege/telephony
        /// </priviledge>
        /// <returns>
        /// The current lock state of the SIM
        /// </returns>
        /// <precondition>
        /// The SIM state must be Available
        /// </precondition>
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
        /// Gets Group Identifier Level 1(GID1) embedded in the SIM card.If this value is not stored in SIM card, empty string will be returned.
        /// </summary>
        /// <priviledge>
        /// http://tizen.org/privilege/telephony
        /// </priviledge>
        /// <returns>
        /// The GID1 (Group Identifier Level 1)
        /// empty string if unable to complete the operation
        /// </returns>
        /// <precondition>
        /// The SIM state must be Available
        /// </precondition>
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
        /// If the state is true, incoming call will be forwarded to the selected number.state indicates the CFU(Call Forwarding Unconditional) indicator status - Voice. (3GPP TS 31.102 4.2.64 EF CFIS)
        /// </summary>
        /// <priviledge>
        /// http://tizen.org/privilege/telephony
        /// </priviledge>
        /// <returns>
        /// The value whether incoming call will be forwarded or not. (true: forwarded, false: not forwarded)
        /// </returns>
        /// <precondition>
        /// The SIM state must be Available
        /// </precondition>
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

        internal IntPtr _handle;
    }
}
