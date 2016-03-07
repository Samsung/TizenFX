using System;

namespace Tizen.System
{
    /// <summary>
    /// The Power class provides methods to control the power service.
    /// </summary>
    public static class Power
    {
        /// <summary>
        /// Locks the CPU for a specified time.
        /// After the given timeout (in milliseconds), unlock the given lock state automatically.
        /// </summary>
        /// <param name="timeout">
        /// The positive number in milliseconds or 0 for permanent lock
        /// So you must release the permanent lock of power state with ReleaseCpuLock() if timeout_ms is zero.
        /// </param>
        public static void RequestCpuLock(int timeout)
        {
            DeviceError res = (DeviceError) Interop.Device.DevicePowerRequestLock(0, timeout);
            if (res != DeviceError.None)
            {
                throw DeviceExceptionFactory.CreateException(res, "unable to acquire power lock.");
            }
        }

        /// <summary>
        /// Releases the CPU lock state.
        /// </summary>
        public static void ReleaseCpuLock()
        {
            DeviceError res = (DeviceError) Interop.Device.DevicePowerReleaseLock(0);
            if (res != DeviceError.None)
            {
                throw DeviceExceptionFactory.CreateException(res, "unable to release power lock.");
            }
        }
    }
}
