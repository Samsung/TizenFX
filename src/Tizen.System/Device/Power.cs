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

namespace Tizen.System
{
    /// <summary>
    /// Enumeration for power lock type.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public enum PowerLock
    {
        /// <summary>
        /// CPU lock.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Cpu = Interop.Device.PowerLock.Cpu,
        /// <summary>
        /// Display normal lock
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        DisplayNormal = Interop.Device.PowerLock.DisplayNormal,
        /// <summary>
        /// Display dim lock
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        DisplayDim = Interop.Device.PowerLock.DisplayDim,
    }

    /// <summary>
    /// The Power class provides methods to control the power service.
    /// </summary>
    /// <remarks>
    /// The Power API provides the way to control the power service.
    /// It can be made to hold the specific state to avoid the CPU state internally.
    /// </remarks>
    /// <privilege>
    /// http://tizen.org/privilege/display
    /// </privilege>
    /// <since_tizen> 3 </since_tizen>
    public static class Power
    {
        /// <summary>
        /// Locks the CPU for a specified time.
        /// After the given timeout (in milliseconds), unlock the given lock state automatically.
        /// </summary>
        /// <remarks>
        /// If the process dies, then every lock will be removed.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="timeout">
        /// The positive number in milliseconds or 0 for the permanent lock.
        /// So you must release the permanent lock of the power state with ReleaseCpuLock() if timeout_ms is zero.
        /// </param>
        /// <exception cref="ArgumentException">When an invalid parameter value is set.</exception>
        /// <exception cref="UnauthorizedAccessException">If the privilege is not set.</exception>
        /// <exception cref="InvalidOperationException">In case of any system error.</exception>
        [Obsolete("Please do not use! this will be deprecated! Please use RequestLock instead!")]
        public static void RequestCpuLock(int timeout)
        {
            DeviceError res = (DeviceError)Interop.Device.DevicePowerRequestLock(Interop.Device.PowerLock.Cpu, timeout);
            if (res != DeviceError.None)
            {
                throw DeviceExceptionFactory.CreateException(res, "unable to acquire power lock.");
            }
        }
        /// <summary>
        /// Release the CPU lock state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="UnauthorizedAccessException">If the privilege is not set.</exception>
        /// <exception cref="InvalidOperationException">In case of any system error.</exception>
        [Obsolete("Please do not use! this will be deprecated! Please use ReleaseLock instead!")]
        public static void ReleaseCpuLock()
        {
            DeviceError res = (DeviceError)Interop.Device.DevicePowerReleaseLock(Interop.Device.PowerLock.Cpu);
            if (res != DeviceError.None)
            {
                throw DeviceExceptionFactory.CreateException(res, "unable to release power lock.");
            }
        }

        /// <summary>
        /// Locks the given lock state for a specified time.
        /// After the given timeout (in milliseconds), unlock the given lock state automatically.
        /// </summary>
        /// <remarks>
        /// If the process dies, then every lock will be removed.
        /// </remarks>
        /// <since_tizen> 5 </since_tizen>
        /// <param name="type">
        /// The power type to request lock
        /// </param>
        /// <param name="timeout">
        /// The positive number in milliseconds or 0 for the permanent lock.
        /// So you must release the permanent lock of the power state with ReleaseLock() if timeout_ms is zero.
        /// </param>
        /// <exception cref="ArgumentException">When an invalid parameter value is set.</exception>
        /// <exception cref="UnauthorizedAccessException">If the privilege is not set.</exception>
        /// <exception cref="NotSupportedException">If power lock is not supported.</exception>
        /// <exception cref="InvalidOperationException">In case of any system error.</exception>
        /// <example>
        /// <code>
        /// Tizen.System.Power.RequestLock(Tizen.System.Power.PowerLock.Cpu, 2000);
        /// </code>
        /// </example>
        public static void RequestLock(PowerLock type, int timeout)
        {
            DeviceError res = (DeviceError)Interop.Device.DevicePowerRequestLock((Interop.Device.PowerLock)type, timeout);
            if (res != DeviceError.None)
            {
                throw DeviceExceptionFactory.CreateException(res, "unable to acquire power lock.");
            }
        }
        /// <summary>
        /// Releases the lock state.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        /// <param name="type">
        /// The power type to request lock
        /// </param>
        /// <exception cref="ArgumentException">When an invalid parameter value is set.</exception>
        /// <exception cref="UnauthorizedAccessException">If the privilege is not set.</exception>
        /// <exception cref="NotSupportedException">If power lock is not supported.</exception>
        /// <exception cref="InvalidOperationException">In case of any system error.</exception>
        /// <example>
        /// <code>
        /// Tizen.System.Power.ReleaseLock(Tizen.System.Power.PowerLock.Cpu);
        /// </code>
        /// </example>
        public static void ReleaseLock(PowerLock type)
        {
            DeviceError res = (DeviceError)Interop.Device.DevicePowerReleaseLock((Interop.Device.PowerLock)type);
            if (res != DeviceError.None)
            {
                throw DeviceExceptionFactory.CreateException(res, "unable to release power lock.");
            }
        }
    }
}
