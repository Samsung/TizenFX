using System;

namespace Tizen.System
{
    /// <summary>
    /// The Power class provides methods to control the power service.
    /// </summary>
    /// <remarks>
    /// The Power API provides the way to control the power service.
    /// It can be made to hold the specific state to avoid CPU state internally.
    /// </remarks>
    /// <previlege>
    /// http://tizen.org/privilege/display
    /// </previlege>
    public static class Power
    {
        /// <summary>
        /// Locks the CPU for a specified time.
        /// After the given timeout (in milliseconds), unlock the given lock state automatically.
        /// </summary>
        /// <remarks>
        /// If the process dies, then every lock will be removed.
        /// </remarks>
        /// <param name="timeout">
        /// The positive number in milliseconds or 0 for permanent lock
        /// So you must release the permanent lock of power state with ReleaseCpuLock() if timeout_ms is zero.
        /// </param>
        /// <exception cref="ArgumentException"> When the invalid parameter value is set.</exception>
        /// <exception cref = "UnauthorizedAccessException"> If the privilege is not set.</exception>
        /// <exception cref = "InvalidOperationException"> In case of any system error.</exception>
        /// <code>
        /// Tizen.System.Power.RequestCpuLock(2000);
        /// </code>

        public static void RequestCpuLock(int timeout)
        {
            DeviceError res = (DeviceError)Interop.Device.DevicePowerRequestLock(0, timeout);
            if (res != DeviceError.None)
            {
                throw DeviceExceptionFactory.CreateException(res, "unable to acquire power lock.");
            }
        }
        /// <summary>
        /// Releases the CPU lock state.
        /// </summary>
        /// <exception cref = "UnauthorizedAccessException"> If the privilege is not set.</exception>
        /// <exception cref = "InvalidOperationException"> In case of any system error.</exception>
        /// <code>
        /// Tizen.System.Power.ReleaseCpuLock();
        /// </code>
        public static void ReleaseCpuLock()
        {
            DeviceError res = (DeviceError)Interop.Device.DevicePowerReleaseLock(0);
            if (res != DeviceError.None)
            {
                throw DeviceExceptionFactory.CreateException(res, "unable to release power lock.");
            }
        }
    }
}
