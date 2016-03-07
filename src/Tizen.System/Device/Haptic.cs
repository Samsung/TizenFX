using System;
using System.Collections.Generic;

namespace Tizen.System
{
    /// <summary>
    /// The Haptic class provides properties and methods to control a vibrator.
    /// </summary>
    public class Vibrator : IDisposable
    {
        private readonly int _vibratorId;
        private static readonly Dictionary<int, Vibrator> s_vibrators = new Dictionary<int, Vibrator>();
        private IntPtr _hapticHandle;
        private bool _disposedValue = false;
        private Vibrator(int id)
        {
            _vibratorId = id;
            DeviceError res = (DeviceError) Interop.Device.DeviceHapticOpen(_vibratorId, out _hapticHandle);
            if (res != DeviceError.None)
            {
                throw DeviceExceptionFactory.CreateException(res, "unable to create Vibrator for given Id");
            }
        }

        ~Vibrator()
        {
            Dispose(false);
        }

        /// <summary>
        /// Get the Vibrator instance for the given vibrator index.
        /// </summary>
        /// <param name="deviceId"> The index of the vibrator.
        /// It can be greater than or equal to 0 and less than the number of vibrators. </param>
        public static Vibrator GetVibrator(int deviceNumber)
        {
            if (deviceNumber < 0 || deviceNumber >= NumberOfVibrators)
            {
                throw DeviceExceptionFactory.CreateException(DeviceError.InvalidParameter, "invalid vibrator number");
            }
            if (!s_vibrators.ContainsKey(deviceNumber))
            {
                s_vibrators.Add(deviceNumber, new Vibrator(deviceNumber));
            }
            return s_vibrators[deviceNumber];
        }
        /// <summary>
        /// Gets the number of vibrators.
        /// </summary>
        public static int NumberOfVibrators
        {
            get
            {
                int count = 0;
                DeviceError res = (DeviceError) Interop.Device.DeviceHapticGetCount(out count);
                if (res != DeviceError.None)
                {
                    Log.Warn(DeviceExceptionFactory.LogTag, "unable to get Vibrators count.");
                }
                return count;
            }
        }
        /// <summary>
        /// Vibrates during the specified time with a constant intensity.
        /// This function can be used to start monotonous vibration for the specified time.
        /// </summary>
        /// <param name="duration">The play duration in milliseconds </param>
        /// <param name="feedback">The amount of the intensity variation (0 ~ 100) </param>
        public void Vibrate(int duration, int feedback)
        {
            IntPtr effect;
            DeviceError res = DeviceError.None;
            if (_hapticHandle == IntPtr.Zero)
            {
                res = (DeviceError) Interop.Device.DeviceHapticOpen(_vibratorId, out _hapticHandle);
                if (res != DeviceError.None)
                {
                    throw DeviceExceptionFactory.CreateException(res, "unable to get vibrator.");
                }
            }

            res = (DeviceError) Interop.Device.DeviceHapticVibrate(_hapticHandle, duration, feedback, out effect);
            if (res != DeviceError.None)
            {
                throw DeviceExceptionFactory.CreateException(res, "unable to vibrate the current vibrator.");
            }
        }
        /// <summary>
        /// Stops all vibration effects which are being played.
        /// This function can be used to stop all effects started by Vibrate().
        /// </summary>
        public void Stop()
        {
            if (_hapticHandle != IntPtr.Zero)
            {
                DeviceError res = (DeviceError)Interop.Device.DeviceHapticStop(_hapticHandle, IntPtr.Zero);
                if (res != DeviceError.None)
                {
                    throw DeviceExceptionFactory.CreateException(res, "unable to stop the current vibrator.");
                }
            }
        }
        /// <summary>
        /// Dispose API for closing the internal resources.
        /// This function can be used to stop all effects started by Vibrate().
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (_hapticHandle != IntPtr.Zero)
                {
                    Interop.Device.DeviceHapticClose(_hapticHandle);
                    _hapticHandle = IntPtr.Zero;
                }
                _disposedValue = true;
            }
        }
    }
}
