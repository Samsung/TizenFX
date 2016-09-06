/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static Interop.Telephony;

namespace Tizen.Telephony
{
    /// <summary>
    /// Enumeration for the telephony state.
    /// </summary>
    public enum State
    {
        /// <summary>
        /// Telephony state is not ready
        /// </summary>
        NotReady,
        /// <summary>
        /// Telephony state is ready
        /// </summary>
        Ready,
        /// <summary>
        /// Unavailable
        /// </summary>
        Unavailable
    };

    /// <summary>
    /// Enumeration for the preferred voice call subscription.
    /// </summary>
    public enum CallPreferredVoiceSubsubscription
    {
        /// <summary>
        /// Unknown status
        /// </summary>
        Unknown = -1,
        /// <summary>
        /// Current network
        /// </summary>
        CurrentNetwork = 0,
        /// <summary>
        /// ASK Always
        /// </summary>
        AskAlways,
        /// <summary>
        /// SIM 1
        /// </summary>
        Sim1,
        /// <summary>
        /// SIM 2
        /// </summary>
        Sim2
    };

    /// <summary>
    /// This Class provides API's to Initialize and Deinitialize the framework
    /// it also provides API's to get the SlotHandle's which can then be used to get other Network/Sim/Call/Modem Information.
    /// </summary>
    public static class Manager
    {
        /// <summary>
        /// Event Handler to be invoked when the telephony state changes.
        /// </summary>
        public static event EventHandler<StateEventArgs> StateChanged
        {
            add
            {
                if (_stateChanged == null)
                {
                    Interop.Telephony.TelephonyError error = Interop.Telephony.TelephonySetStateChangedCb(stateDelegate, IntPtr.Zero);
                    if (error != TelephonyError.None)
                    {
                        Log.Error(LogTag, "Add StateChanged Failed with Error: " + error);
                    }

                    else
                    {
                        _stateChanged += value;
                    }

                }
            }

            remove
            {
                _stateChanged -= value;
                if (_stateChanged == null)
                {
                    Interop.Telephony.TelephonyError error = Interop.Telephony.TelephonyUnsetStateChangedCb(stateDelegate);
                    if (error != TelephonyError.None)
                    {
                        Log.Error(LogTag, "Remove StateChanged Failed with Error: " + error);
                    }
                }
            }
        }

        /// <summary>
        /// Acquires the Number of available handles to use the telephony API.
        /// </summary>
        /// <returns>
        /// A List of Telephony handles.
        /// You will get 2 SlotHandles in case of dual SIM device.
        /// where,SlotHandle at Index '0' represents Primary SIM and Index '1' represents Secondary SIM.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// This Exception can will be generated in the following cases
        /// 1. System is out of memory
        /// 2. If the operation is not supported on device
        /// 3. If the Operation Failed
        /// </exception>
        public static List<SlotHandle> Init()
        {
            //DeInitialize Previous Handles if present
            if (_isInitialized)
            {
                Deinit();
            }

            TelephonyError err = Interop.Telephony.TelephonyInit(out _handleList);
            if (err != TelephonyError.None)
            {
                Exception e = ExceptionFactory.CreateException(err);
                // Check if error is Invalid Parameter then hide the error
                if (e is ArgumentException)
                {
                    e = new InvalidOperationException("Internal Error Occured");
                }

                throw e;
            }

            int offset = 0;
            for (int i = 0; i < _handleList.Count; i++)
            {
                _telephonyHandle.Add(new SlotHandle(Marshal.ReadIntPtr(_handleList.HandleArrayPointer, offset)));
                offset += Marshal.SizeOf(_handleList.HandleArrayPointer);
            }

            _isInitialized = true;
            Tizen.Log.Info(Interop.Telephony.LogTag, "Returning the number of sims " + _handleList.Count);
            return _telephonyHandle;
        }

        /// <summary>
        /// Deinitializes the telephony handles.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// This Exception can be generated in the following cases
        /// 1. If the operation is not supported on device
        /// 2. If the Operation Failed
        /// </exception>
        public static void Deinit()
        {
            TelephonyError error = Interop.Telephony.TelephonyDeinit(ref _handleList);
            if (error != TelephonyError.None)
            {
                Exception e = ExceptionFactory.CreateException(error);
                // Check if error is Invalid Parameter then hide the error
                if (e is ArgumentException)
                {
                    e = new InvalidOperationException("Internal Error Occured");
                }

                throw e;
            }

            _isInitialized = false;
            _telephonyHandle.Clear();
        }

        /// <summary>
        /// Acquires the telephony state value.
        /// </summary>
        /// <returns>
        /// The state value of telephony.
        /// </returns>
        public static State CurrentState
        {
            get
            {
                State state = State.NotReady;
                TelephonyError error = Interop.Telephony.TelephonyGetState(out state);
                if (error != TelephonyError.None)
                {
                    Tizen.Log.Error(Interop.Telephony.LogTag, "GetState Failed with Error " + error);
                    return State.Unavailable;
                }

                return state;
            }
        }

        internal static SlotHandle FindHandle(IntPtr handle)
        {
            SlotHandle temp = _telephonyHandle[0];
            foreach (SlotHandle simHandle in _telephonyHandle)
            {
                if (simHandle._handle == handle)
                {
                    temp = simHandle;
                }
            }

            return temp;
        }

        internal static List<SlotHandle> _telephonyHandle = new List<SlotHandle>();

        private static StateChangedCallback stateDelegate = delegate(State state, IntPtr userData)
        {
            StateEventArgs args = new StateEventArgs(state);
            _stateChanged?.Invoke(null, args);
        };
        private static HandleList _handleList;
        private static bool _isInitialized = false;
        private static event EventHandler<StateEventArgs> _stateChanged;
    }
}
