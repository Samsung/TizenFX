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
using System.Collections.Generic;
using System.Runtime.InteropServices;
using static Interop.Telephony;

namespace Tizen.Telephony
{
    /// <summary>
    /// Enumeration for the telephony states.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    /// [Obsolete("Deprecated since API13, will be removed in API15.")]
    public enum State
    {
        /// <summary>
        /// The telephony state is not ready.
        /// </summary>
        NotReady,
        /// <summary>
        /// The telephony state is ready.
        /// </summary>
        Ready,
        /// <summary>
        /// Unavailable.
        /// </summary>
        Unavailable
    };

    /// <summary>
    /// Enumeration for the preferred voice call subscription.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    /// [Obsolete("Deprecated since API13, will be removed in API15.")]
    public enum CallPreferredVoiceSubscription
    {
        /// <summary>
        /// Unknown status.
        /// </summary>
        Unknown = -1,
        /// <summary>
        /// Current network.
        /// </summary>
        CurrentNetwork = 0,
        /// <summary>
        /// Ask Always.
        /// </summary>
        AskAlways,
        /// <summary>
        /// SIM 1.
        /// </summary>
        Sim1,
        /// <summary>
        /// SIM 2.
        /// </summary>
        Sim2
    };

    /// <summary>
    /// This class provides APIs to initialize and deinitialize the framework.
    /// It also provides APIs to get the SlotHandles, which can then be used to get other Network/Sim/Call/Modem information.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    /// [Obsolete("Deprecated since API13, will be removed in API15.")]
    public static class Manager
    {
        internal static List<SlotHandle> _telephonyHandle = new List<SlotHandle>();
        private static HandleList _handleList;
        private static bool _isInitialized = false;
        private static event EventHandler<StateEventArgs> _stateChanged;
        private static StateChangedCallback stateDelegate = delegate(State state, IntPtr userData)
        {
            StateEventArgs args = new StateEventArgs(state);
            _stateChanged?.Invoke(null, args);
        };

        /// <summary>
        /// The event handler to be invoked when the telephony state changes.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// [Obsolete("Deprecated since API13, will be removed in API15.")]
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
        /// Acquires the telephony state value.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>
        /// The state value of telephony.
        /// </value>
        /// [Obsolete("Deprecated since API13, will be removed in API15.")]
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

        /// <summary>
        /// Acquires the number of available handles to use the telephony API.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>
        /// A list of telephony handles.
        /// You will get 2 SlotHandles in case of the dual SIM device.
        /// Where, SlotHandle at Index '0' represents the primary SIM and Index '1' represents the secondary SIM.
        /// </returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">
        /// This exception will be generated in the following cases:
        /// 1. The system is out of memory.
        /// 2. If the operation is not supported on the device.
        /// 3. If the operation failed.
        /// </exception>
        /// [Obsolete("Deprecated since API13, will be removed in API15.")]
        public static IEnumerable<SlotHandle> Init()
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
            //Tizen.Log.Info(Interop.Telephony.LogTag, "Returning the number of sims " + _handleList.Count);
            return _telephonyHandle;
        }

        /// <summary>
        /// Deinitializes the telephony handles.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">
        /// This exception can be generated in the following cases:
        /// 1. If the operation is not supported on the device.
        /// 2. If the operation failed.
        /// </exception>
        /// [Obsolete("Deprecated since API13, will be removed in API15.")]
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
    }
}
