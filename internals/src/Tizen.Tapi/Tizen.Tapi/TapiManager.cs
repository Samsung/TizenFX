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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Tizen;

namespace Tizen.Tapi
{
    /// <summary>
    /// This class is used for initializing/deinitializing Tapi and manages the state of it.
    /// </summary>
    public static class TapiManager
    {
        private static event EventHandler<StateChangedEventArgs> s_stateChanged;
        private static Interop.Tapi.TapiStateCallback s_stateChangedCb;

        /// <summary>
        /// Gets the state value if tapi is ready.
        /// </summary>
        /// <value>The State value in integer format - 0 is False and 1 is True. Returns -1 in case of error.</value>
        public static int State
        {
            get
            {
                int state;
                int ret = Interop.Tapi.GetReadyState(out state);
                if (ret != (int)TapiError.Success)
                {
                    Log.Error(TapiUtility.LogTag, "Failed to get ready state of tapi, Error: " + (TapiError)ret);
                    return -1;
                }

                return state;
            }
        }

        /// <summary>
        /// This event is raised when Tapi ready state changes.
        /// </summary>
        public static event EventHandler<StateChangedEventArgs> StateChanged
        {
            add
            {
                if (s_stateChanged == null)
                {
                    RegisterStateChangedEvent();
                }

                s_stateChanged += value;
            }

            remove
            {
                s_stateChanged -= value;
                if (s_stateChanged == null)
                {
                    UnregisterStateChangedEvent();
                }
            }
        }

        private static void RegisterStateChangedEvent()
        {
            s_stateChangedCb = (int state, IntPtr userData) =>
            {
                s_stateChanged?.Invoke(null, new StateChangedEventArgs(state));
            };
            int ret = Interop.Tapi.RegisterReadyStateCb(s_stateChangedCb, IntPtr.Zero);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to register tapi state changed callback, Error: " + (TapiError)ret);
            }
        }

        private static void UnregisterStateChangedEvent()
        {
            int ret = Interop.Tapi.DeregisterReadyStateCb(s_stateChangedCb);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to deregister tapi state changed callback, Error: " + (TapiError)ret);
            }
        }

        /// <summary>
        /// Fetches a list of available CPs.
        /// </summary>
        /// <returns>List of available CPs in case of success. Null in case of failure.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        public static IEnumerable<string> GetCpNames()
        {
            IntPtr cpNames = Interop.Tapi.GetCpNames();
            if(cpNames == IntPtr.Zero)
            {
                return null;
            }

            else
            {
                List<string> cpList = new List<string>();
                int offset = 0;
                IntPtr cp = Marshal.ReadIntPtr(cpNames, offset);
                if(cp != IntPtr.Zero)
                {
                    do
                    {
                        string cpString = Marshal.PtrToStringAnsi(cp);
                        offset += Marshal.SizeOf(cp);
                        cpList.Add(cpString);
                    }

                    while ((cp = Marshal.ReadIntPtr(cpNames, offset)) != IntPtr.Zero);
                }

                return cpList;
            }
        }

        /// <summary>
        /// Acquires a TAPI Handle for the specified CP name.
        /// </summary>
        /// <param name="cpName">The CP Name against which a TAPI handle is required (A NULL CP Name will return a #TapiHandle bound to the first CP in the list of available CPs).</param>
        /// <returns>Instance of TapiHandle on success, null on failure.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        public static TapiHandle InitTapi(string cpName)
        {
            IntPtr handle = Interop.Tapi.InitTapi(cpName);
            if (handle == IntPtr.Zero)
            {
                return null;
            }

            return new TapiHandle(handle);
        }

        /// <summary>
        /// Deinitializes the TAPI Handle.
        /// </summary>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when it is failed due to invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when it is failed due to invalid operation.</exception>
        public static void DeinitTapi(TapiHandle handle)
        {
            int ret = Interop.Tapi.DeinitTapi(handle._handle);
            if (ret != (int)TapiError.Success)
            {
                Log.Error(TapiUtility.LogTag, "Failed to deinitialize tapi, Error: " + (TapiError)ret);
                TapiUtility.ThrowTapiException(ret, handle._handle);
            }

            handle._handle = IntPtr.Zero;
        }
    }
}
