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
    /// The PerformanceController class provides the methods to control the system resources.
    /// </summary>
    /// <remarks>
    /// It supports to control cpu clock within input timeout.
    /// </remarks>
    /// <privilege>
    /// </privilege>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class PerformanceController
    {
        private delegate int PerformanceControlFunc(int timeout);
        private static readonly Dictionary<PerformanceControlType, PerformanceControlFunc> PerformanceControlFunctions = new Dictionary<PerformanceControlType, PerformanceControlFunc>
        {
            {PerformanceControlType.AppLaunchHome, Interop.Device.DevicePmQosAppLaunchHome},
            {PerformanceControlType.HomeScreen, Interop.Device.DevicePmQosHomeScreen},
            /* Add Here */
        };

        /// <summary>
        /// Increase the cpu clock within timeout.
        /// </summary>
        /// <remarks>
        /// The timeout parameter specifies the duration of the CPU boost in milliseconds.
        /// If the timeout value exceeds 3000 milliseconds, it will automatically be set to 3000 milliseconds.
        /// </remarks>
        /// <param name="type">Performance Control Type</param>
        /// <param name="timeout">Cpu clock increasing duration in milliseconds.</param>
        /// <exception cref="ArgumentException">When an invalid parameter value is set.</exception>
        /// <exception cref="InvalidOperationException">In case of any system error.</exception>
        /// <exception cref="NotSupportedException">In case the device does not support this behavior.</exception>
        /// <example>
        /// <code>
        ///     try
        ///     {
        ///         PerformanceController.Request(PerformanceControlType.AppLaunchHome, 100);
        ///     }
        ///     Catch(Exception e)
        ///     {
        ///     }
        /// </code>
        /// </example>
        public static void Request(PerformanceControlType type, int timeout) {
            PerformanceControlFunc func = null;

            if (!PerformanceControlFunctions.TryGetValue(type, out func))
                throw new ArgumentException("Invalid Arguments");

            DeviceError res = (DeviceError)func(timeout);

            if (res != DeviceError.None) {
                throw DeviceExceptionFactory.CreateException(res, "unable to transmit PmQos command.");
            }
        }
    }
}
