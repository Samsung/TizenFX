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
        private IntPtr _hapticHandle;
        private bool _disposedValue = false;
        private static Lazy<IReadOnlyList<Vibrator>> _lazyVibrators;
        private static int _maxcount = 0;
        private Vibrator(int id)
        {
            _vibratorId = id;
            DeviceError res = (DeviceError) Interop.Device.DeviceHapticOpen(_vibratorId, out _hapticHandle);
            if (res != DeviceError.None)
            {
                throw DeviceExceptionFactory.CreateException(res, "unable to create Vibrator for given Id");
            }
            res = (DeviceError)Interop.Device.DeviceHapticGetCount(out _maxcount);
            if (res != DeviceError.None)
            {
                Log.Warn(DeviceExceptionFactory.LogTag, "unable to get Vibrators count.");
            }

        }

        ~Vibrator()
        {
            Dispose(false);
        }
        /// <summary>
        /// Get the number of avaialble vibrators.
        /// </summary>
        public static int NumberOfVibrators
        {
            get
            {
                int count = 0;
                DeviceError res = (DeviceError)Interop.Device.DeviceHapticGetCount(out count);
                if (res != DeviceError.None)
                {
                    Log.Warn(DeviceExceptionFactory.LogTag, "unable to get Vibrators count.");
                }
                return count;
            }
        }
        /// <summary>
        /// Get all the avaialble vibrators.
        /// </summary>
        public static IReadOnlyList<Vibrator> Vibrators
        {
            get
            {
                _lazyVibrators = new Lazy<IReadOnlyList<Vibrator>>(() => GetAllVibrators());
                return _lazyVibrators.Value;
            }
        }
        private static IReadOnlyList<Vibrator> GetAllVibrators()
        {
            int count = 0;
            List< Vibrator > vibrators = new List<Vibrator>();
            DeviceError res = (DeviceError)Interop.Device.DeviceHapticGetCount(out count);
            if (res != DeviceError.None)
            {
                throw DeviceExceptionFactory.CreateException(res, "unable to get Vibrators count.");
            }
            for(int i = 0; i< NumberOfVibrators; i++)
            {
                vibrators.Add(new Vibrator(i));
            }
            return vibrators;

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
