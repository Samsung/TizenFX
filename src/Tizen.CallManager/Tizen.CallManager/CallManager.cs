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

namespace Tizen.CallManager
{
    /// <summary>
    /// A class which manages the use of Call Manager APIs.
    /// </summary>
    public static class CallManager
    {
        /// <summary>
        /// Initializes the call manager.
        /// </summary>
        /// <returns>An instance of CmClientHandle class to use call manager APIs.</returns>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <exception cref="NotSupportedException">Thrown when telephony feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation.</exception>
        public static CmClientHandle InitCm()
        {
            int ret = Interop.CallManager.InitCm(out IntPtr handle);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to initialize call manager, Error: " + (CmError)ret);
                CmUtility.ThrowCmException(ret);
            }

            return new CmClientHandle(handle);
        }

        /// <summary>
        /// Deinitializes the Call Manager handle.
        /// </summary>
        /// <param name="handle">The Call Manager handle to be deinitialized.</param>
        /// <exception cref="ArgumentNullException">Thrown when CmClientHandle is passed as null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation.</exception>
        public static void DeinitCm(CmClientHandle handle)
        {
            if (handle == null)
            {
                throw new ArgumentNullException("Call manager client handle is null");
            }

            int ret = Interop.CallManager.DeinitCm(handle._handle);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to deinitialize call manager, Error: " + (CmError)ret);
                CmUtility.ThrowCmException(ret, handle._handle);
            }

            handle._handle = IntPtr.Zero;
        }

        /// <summary>
        /// Sets LCD state for the device display.
        /// </summary>
        /// <param name="state">LCD state to be set.</param>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation.</exception>
        public static void SetLcdState(LcdControlState state)
        {
            int ret = Interop.CallManager.SetLcdState(state);
            if (ret != (int)CmError.None)
            {
                Log.Error(CmUtility.LogTag, "Failed to set LCD state, Error: " + (CmError)ret);
                CmUtility.ThrowCmException(ret);
            }
        }
    }
}
