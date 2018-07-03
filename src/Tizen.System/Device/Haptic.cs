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
using System.Collections.Generic;
namespace Tizen.System
{
    /// <summary>
    /// The Vibrator class provides the properties and methods to control a vibrator.
    /// </summary>
    /// <remarks>
    /// The Vibrator API provides the way to access the vibrators in the device.
    /// It allows the management of the device's vibrator parameters, such as the vibration count and level.
    /// It provides the methods to vibrate and stop the vibration.
    /// </remarks>
    /// <privilege>
    /// http://tizen.org/privilege/haptic
    /// </privilege>
    /// <feature>
    /// http://tizen.org/feature/feedback.vibration
    /// </feature>
    /// <exception cref="ArgumentException"> When an invalid parameter value is set.</exception>
    /// <exception cref="UnauthorizedAccessException">If the privilege is not set.</exception>
    /// <exception cref="InvalidOperationException">In case of any system error.</exception>
    /// <exception creg="NotSupportedException">The required feature is not supported</exception>
    /// <example>
    /// <code>
    ///     Console.WriteLine("Total number of Vibrators are: {0}", Tizen.System.Vibrator.NumberOfVibrators);
    /// </code>
    /// </example>
    /// <since_tizen> 3 </since_tizen>
    public class Vibrator : IDisposable
    {
        private readonly int _vibratorId;
        private IntPtr _hapticHandle = IntPtr.Zero;
        private bool _disposedValue = false;
        private static Lazy<IReadOnlyList<Vibrator>> _lazyVibrators;
        private static int _maxcount = 0;
        private Vibrator(int id)
        {
            _vibratorId = id;
            DeviceError res = (DeviceError)Interop.Device.DeviceHapticOpen(_vibratorId, out _hapticHandle);
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

        /// <summary>
        /// Finalizes an instance of the Vibrator class.
        /// </summary>
        ~Vibrator()
        {
            Dispose(false);
        }
        /// <summary>
        /// Gets the number of the available vibrators.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Gets all the available vibrators.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
            List<Vibrator> vibrators = new List<Vibrator>();
            DeviceError res = (DeviceError)Interop.Device.DeviceHapticGetCount(out count);
            if (res != DeviceError.None)
            {
                throw DeviceExceptionFactory.CreateException(res, "unable to get Vibrators count.");
            }
            for (int i = 0; i < NumberOfVibrators; i++)
            {
                vibrators.Add(new Vibrator(i));
            }
            return vibrators;

        }
        /// <summary>
        /// Vibrates during the specified time with a constant intensity.
        /// This function can be used to start monotonous vibration for the specified time.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="duration">The play duration in milliseconds.</param>
        /// <param name="feedback">The amount of the intensity variation (0 ~ 100).</param>
        /// <feature>
        /// http://tizen.org/feature/feedback.vibration
        /// </feature>
        /// <exception cref="ArgumentException"> When an invalid parameter value is set.</exception>
        /// <exception cref="UnauthorizedAccessException">If the privilege is not set.</exception>
        /// <exception cref="InvalidOperationException">In case of any system error.</exception>
        /// <exception cref="NotSupportedException">In case the device does not support this behavior.</exception>
        /// <example>
        /// <code>
        ///     Vibrator vibrator = Vibrator.Vibrators[0];
        ///     try
        ///     {
        ///         vibrator.Vibrate(2000, 70);
        ///     }
        ///     Catch(Exception e)
        ///     {
        ///     }
        /// </code>
        /// </example>

        public void Vibrate(int duration, int feedback)
        {
            IntPtr effect;
            DeviceError res = DeviceError.None;
            if (_hapticHandle == IntPtr.Zero)
            {
                res = (DeviceError)Interop.Device.DeviceHapticOpen(_vibratorId, out _hapticHandle);
                if (res != DeviceError.None)
                {
                    throw DeviceExceptionFactory.CreateException(res, "unable to get vibrator.");
                }
            }

            res = (DeviceError)Interop.Device.DeviceHapticVibrate(_hapticHandle, duration, feedback, out effect);
            if (res != DeviceError.None)
            {
                throw DeviceExceptionFactory.CreateException(res, "unable to vibrate the current vibrator.");
            }
        }
        /// <summary>
        /// Stops all the vibration effects which are being played.
        /// This function can be used to stop all the effects started by Vibrate().
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <feature>
        /// http://tizen.org/feature/feedback.vibration
        /// </feature>
        /// <exception cref="ArgumentException"> In case an invalid vibrator instance is used.</exception>
        /// <exception cref="UnauthorizedAccessException">If the privilege is not set.</exception>
        /// <exception cref="InvalidOperationException">In case of any system error.</exception>
        /// <exception cref="NotSupportedException">In case the device does not support this behavior.</exception>
        /// <example>
        /// <code>
        ///     Vibrator vibrator = Vibrator.Vibrators[0];
        ///     try
        ///     {
        ///         vibrator.Stop();
        ///     }
        ///     Catch(Exception e)
        ///     {
        ///     }
        /// </code>
        /// </example>
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
        /// This function can be used to stop all the effects started by Vibrate().
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose API for closing the internal resources.
        /// This function can be used to stop all the effects started by Vibrate().
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
