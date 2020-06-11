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
    public static class PmQos
    {
        /// <summary>
        /// Increase the cpu clock for AppLaunchHome within timeout.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <param name="timeout">Cpu clock increasing duration in milliseconds.</param>
        /// <exception cref="ArgumentException">When an invalid parameter value is set.</exception>
        /// <exception cref="InvalidOperationException">In case of any system error.</exception>
        /// <exception cref="NotSupportedException">In case the device does not support this behavior.</exception>
        /// <example>
        /// <code>
        ///     try
        ///     {
        ///         PmQos.AppLaunchHome(100);
        ///     }
        ///     Catch(Exception e)
        ///     {
        ///     }
        /// </code>
        /// </example>
        public static void AppLaunchHome(int timeout) {
            DeviceError res = (DeviceError)Interop.Device.DevicePmQosAppLaunchHome(timeout);
            if (res != DeviceError.None) {
                throw DeviceExceptionFactory.CreateException(res, "unable to trasmit PmQos command.");
            }
        }

        /// <summary>
        /// Increase the cpu clock for HomeScreen within timeout.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <param name="timeout">Cpu clock increasing duration in milliseconds.</param>
        /// <exception cref="ArgumentException">When an invalid parameter value is set.</exception>
        /// <exception cref="InvalidOperationException">In case of any system error.</exception>
        /// <exception cref="NotSupportedException">In case the device does not support this behavior.</exception>
        /// <example>
        /// <code>
        ///     try
        ///     {
        ///         PmQos.HomeScreen(100);
        ///     }
        ///     Catch(Exception e)
        ///     {
        ///     }
        /// </code>
        /// </example>
        public static void HomeScreen(int timeout) {
            DeviceError res = (DeviceError)Interop.Device.DevicePmQosHomeScreen(timeout);
            if (res != DeviceError.None) {
                throw DeviceExceptionFactory.CreateException(res, "unable to trasmit PmQos command.");
            }
        }
    }
}
