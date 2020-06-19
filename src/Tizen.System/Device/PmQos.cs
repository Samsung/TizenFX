/*
* Copyright (c) 2020 Samsung Electronics Co., Ltd All Rights Reserved
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

using Tizen.Common;
using System.Collections.Generic;
using System.ComponentModel;

namespace Tizen.System
{
    /// <summary>
    /// The PmQos class provides the methods to control the PmQos.
    /// </summary>
    /// <remarks>
    /// The PmQos API provides the way to control the PmQos. It supports to increase cpu clock within input timeout.
    /// </remarks>
    /// <privilege>
    /// </privilege>
    /// <since_tizen> 8 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class PmQos
    {
        private delegate int PmQosFunc(int timeout);
        private static readonly Dictionary<PmQosType, PmQosFunc> PmQosFunctions = new Dictionary<PmQosType, PmQosFunc>
        {
            {PmQosType.AppLaunchHome, Interop.Device.DevicePmQosAppLaunchHome},
            {PmQosType.HomeScreen, Interop.Device.DevicePmQosHomeScreen},
            /* Add Here */
        };

        /// <summary>
        /// Increase the cpu clock within timeout.
        /// </summary>
        /// <param name="type">PmQos Name</param>
        /// <param name="timeout">Cpu clock increasing duration in milliseconds.</param>
        /// <exception cref="ArgumentException">When an invalid parameter value is set.</exception>
        /// <exception cref="InvalidOperationException">In case of any system error.</exception>
        /// <exception cref="NotSupportedException">In case the device does not support this behavior.</exception>
        /// <example>
        /// <code>
        ///     try
        ///     {
        ///         PmQos.IncreaseCPUClock(PmQosType.AppLaunchHome, 100);
        ///     }
        ///     Catch(Exception e)
        ///     {
        ///     }
        /// </code>
        /// </example>
        public static void IncreaseCPUClock(PmQosType type, int timeout) {
            PmQosFunc func = null;

            if (!PmQosFunctions.TryGetValue(type, out func))
                throw new ArgumentException("Invalid Arguments");

            DeviceError res = (DeviceError)func(timeout);

            if (res != DeviceError.None) {
                throw DeviceExceptionFactory.CreateException(res, "unable to transmit PmQos command.");
            }
        }
    }
}
