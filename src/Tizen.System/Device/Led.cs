using System;

namespace Tizen.System
{
    /// <summary>
    /// The Led class provides properties and methods to control the attached led device.
    /// </summary>
    public static class Led
    {
        /// <summary>
        /// Gets the max brightness value of a LED that is located next to the camera.
        /// </summary>
        public static int MaxBrightness
        {
            get
            {
                int max = 0;
                DeviceError res = (DeviceError) Interop.Device.DeviceFlashGetMaxBrightness(out max);
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
        public static int Brightness
        {
            get
            {
                int brightness = 0;
                DeviceError res = (DeviceError) Interop.Device.DeviceFlashGetBrightness(out brightness);
                if (res != DeviceError.None)
                {
                    Log.Warn(DeviceExceptionFactory.LogTag, "unable to get brightness value.");
                }
                return brightness;
            }
            set
            {
                Interop.Device.DeviceFlashSetBrightness(value);
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
        public static void Play(int on, int off, uint color)
        {
            //looks like only blink option is supported. So hard coded to default blink option.
            DeviceError res = (DeviceError)Interop.Device.DeviceLedPlayCustom(on, off, color, 1);
            if (res != DeviceError.None)
            {
                throw DeviceExceptionFactory.CreateException(DeviceError.InvalidParameter, "failed to play Led.");
            }
        }

        /// <summary>
        /// Stops the LED that is located to the front of a device.
        /// </summary>
        public static void Stop()
        {
            DeviceError res = (DeviceError) Interop.Device.DeviceLedStopCustom();
            if(res != DeviceError.None)
            {
                throw DeviceExceptionFactory.CreateException(DeviceError.InvalidParameter, "failed to stop Led.");
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
