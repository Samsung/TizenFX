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

using Tizen.Common;

namespace Tizen.System
{
    /// <summary>
    /// The Led class provides properties and methods to control the attached led device.
    /// </summary>
    /// <remarks>
    /// The Led API provides the way to control the attached LED device such as the camera flash and service LED.It supports to turn on the camera flash and set the pattern to the service LED which is located to the front of a device.
    /// Related Features
    ///    http://tizen.org/feature/led
    ///    http://tizen.org/feature/camera.back.flash
    /// It is recommended to design feature related codes in your application for reliability.
    /// You can check if a device supports the related features for this API by using System Information, thereby controlling the procedure of your application.
    /// </remarks>
    /// <privilege>
    ///  http://tizen.org/privilege/led
    /// </privilege>
    /// <code>
    ///     Console.WriteLine("Led MaxBrightness is: {0}", Tizen.System.Led.MaxBrightness);
    ///     Console.WriteLine("Led current Brightness is: {0}", Tizen.System.Led.Brightness);
    /// </code>
    public static class Led
    {
        /// <summary>
        /// Gets the max brightness value of a LED that is located next to the camera.
        /// <exception cref="ArgumentException"> When the invalid parameter value is set.</exception>
        /// <exception cref = "UnauthorizedAccessException"> If the privilege is not set.</exception>
        /// <exception cref = "NotSupportedException"> In case of device does not support this behavior.</exception>
        /// </summary>
        public static int MaxBrightness
        {
            get
            {
                int max = 0;
                DeviceError res = (DeviceError)Interop.Device.DeviceFlashGetMaxBrightness(out max);
                if (res != DeviceError.None)
                {
                    Log.Warn(DeviceExceptionFactory.LogTag, "unable to get max brightness value.");
                }
                return max;
            }
        }

        private static readonly object s_lock = new object();

        /// <summary>
        /// Gets the brightness value of a LED that is located next to the camera.
        /// </summary>
        /// <remarks>The brightness value range of LED is 0 to Tizen.System.Led.MaxBrightness value.
        /// Changing the brightness value will invoke the registered EventHandler for led BrightnessChanged (If any).
        /// </remarks>
        /// <exception cref="ArgumentException"> When the invalid parameter value is set.</exception>
        /// <exception cref = "UnauthorizedAccessException"> If the privilege is not set.</exception>
        /// <exception cref = "NotSupportedException"> In case of device does not support this behavior.</exception>
        /// <code>
        ///     Console.WriteLine("Led current Brightness is: {0}", Tizen.System.Led.Brightness);
        ///     Tizen.System.Led.Brightness = 50;
        ///     Console.WriteLine("Led current Brightness is: {0}", Tizen.System.Led.Brightness);
        /// </code>

        public static int Brightness
        {
            get
            {
                int brightness = 0;
                DeviceError res = (DeviceError)Interop.Device.DeviceFlashGetBrightness(out brightness);
                if (res != DeviceError.None)
                {
                    Log.Warn(DeviceExceptionFactory.LogTag, "unable to get brightness value.");
                }
                return brightness;
            }
            set
            {
                DeviceError res = (DeviceError) Interop.Device.DeviceFlashSetBrightness(value);
                if (res != DeviceError.None)
                {
                    throw DeviceExceptionFactory.CreateException(res, "unable to set brightness value");
                }
            }
        }

        /// <summary>
        /// Plays the LED that is located to the front of a device.
        /// </summary>
        /// <param name="on">Turn on time in milliseconds </param>
        /// <param name="off">Turn off time in milliseconds </param>
        /// <param name="color">
        /// The Color value
        /// The first byte means opaque and the other 3 bytes are RGB values.
        /// </param>
        /// <exception cref="ArgumentException"> When the invalid parameter value is set.</exception>
        /// <exception cref = "UnauthorizedAccessException"> If the privilege is not set.</exception>
        /// <exception cref = "InvalidOperationException"> In case of any system error.</exception>
        /// <exception cref = "NotSupportedException"> In case of device does not support this behavior.</exception>
        /// <code>
        ///     try
        ///     {
        ///         Led.Play(500, 200, Color.FromRgba(255, 255, 255, 1));
        ///     }
        ///     Catch(Exception e)
        ///     {
        ///     }
        /// </code>
        public static void Play(int on, int off, Color color)
        {
            //looks like only blink option is supported. So hard coded to default blink option.
            DeviceError res = (DeviceError)Interop.Device.DeviceLedPlayCustom(on, off, Convert.ToUInt32(color.GetArgb()), 1);
            if (res != DeviceError.None)
            {
                throw DeviceExceptionFactory.CreateException(res, "failed to play Led.");
            }
        }

        /// <summary>
        /// Stops the LED that is located to the front of a device.
        /// </summary>
        /// <exception cref = "UnauthorizedAccessException"> If the privilege is not set.</exception>
        /// <exception cref = "InvalidOperationException"> In case of any system error.</exception>
        /// <exception cref = "NotSupportedException"> In case of device does not support this behavior.</exception>
        /// <code>
        ///     try
        ///     {
        ///         Led.Play(500, 200, Color.FromRgba(255, 255, 255, 1));
        ///         //wait for a while and stop...
        ///         Led.Stop();
        ///     }
        ///     Catch(Exception e)
        ///     {
        ///     }
        /// </code>

        public static void Stop()
        {
            DeviceError res = (DeviceError)Interop.Device.DeviceLedStopCustom();
            if (res != DeviceError.None)
            {
                throw DeviceExceptionFactory.CreateException(res, "failed to stop Led.");
            }
        }


        private static EventHandler<LedBrightnessChangedEventArgs> s_brightnessChanged;
        /// <summary>
        /// StateChanged is raised when the LED state is changed
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An LedBrightnessChangedEventArgs object that contains the changed brightness.</param>
        public static event EventHandler<LedBrightnessChangedEventArgs> BrightnessChanged
        {
            add
            {
                lock (s_lock)
                {
                    if (s_brightnessChanged == null)
                    {
                        EventListenerStart();
                    }
                    s_brightnessChanged += value;
                }
            }
            remove
            {
                lock (s_lock)
                {
                    s_brightnessChanged -= value;
                    if (s_brightnessChanged == null)
                    {
                        EventListenerStop();
                    }
                }
            }
        }

        private static Interop.Device.deviceCallback s_handler;
        private static void EventListenerStart()
        {
            s_handler = (int type, IntPtr value, IntPtr data) =>
            {
                int val = value.ToInt32();
                LedBrightnessChangedEventArgs e = new LedBrightnessChangedEventArgs()
                {
                    Brightness = val
                };
                s_brightnessChanged?.Invoke(null, e);
                return true;
            };
            Interop.Device.DeviceAddCallback(EventType.FlashBrightness, s_handler, IntPtr.Zero);
        }

        private static void EventListenerStop()
        {
            Interop.Device.DeviceRemoveCallback(EventType.FlashBrightness, s_handler);
        }
    }
}
