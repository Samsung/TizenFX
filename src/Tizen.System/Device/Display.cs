using System;
using System.Collections.Generic;
namespace Tizen.System
{
    /// <summary>
    /// Enumeration for the available display states.
    /// An application cannot put the device into the power off state or the suspend state.
    /// </summary>
    public enum DisplayState
    {
        /// <summary>
        /// Normal state
        /// </summary>
        Normal = 0,
        /// <summary>
        /// Screen dim state
        /// </summary>
        Dim,
        /// <summary>
        /// Screen off state
        /// </summary>
        Off
    }

    /// <summary>
    /// The Display class provides properties and methods to control the display status and brightness.
    /// </summary>
    public class Display
    {
        private readonly int _displayId;
        private static readonly object s_lock = new object();
        private static Lazy<IReadOnlyList<Display>> _lazyDisplays;
        private Display(int deviceNumber)
        {
            _displayId = deviceNumber;
        }

        /// <summary>
        /// The number of display devices.
        /// </summary>
        public static int NumberOfDisplays
        {
            get
            {
                int number = 0;
                DeviceError res = (DeviceError)Interop.Device.DeviceDisplayGetNumbers(out number);
                if (res != DeviceError.None)
                {
                    Log.Warn(DeviceExceptionFactory.LogTag, "unable to get number of displays.");
                }
                return number;
            }
        }
        /// <summary>
        /// Get all the avaialble Displays.
        /// </summary>
        public static IReadOnlyList<Display> Displays
        {
            get
            {
                _lazyDisplays = new Lazy<IReadOnlyList<Display>>(() => GetAllDisplayes());
                return _lazyDisplays.Value;
            }
        }


        private static IReadOnlyList<Display> GetAllDisplayes()
        {
            List<Display> displays = new List<Display>();

            for (int i = 0; i < NumberOfDisplays; i++)
            {
                displays.Add(new Display(i));
            }
            return displays;

        }
        /// <summary>
        /// The maximum brightness value that can be set.
        /// </summary>
        public int MaxBrightness
        {
            get
            {
                int max = 0;
                DeviceError res = (DeviceError) Interop.Device.DeviceDisplayGetMaxBrightness(_displayId, out max);
                if (res != DeviceError.None)
                {
                    Log.Warn(DeviceExceptionFactory.LogTag, "unable to get max brightness.");
                }
                return max;
            }
        }

        /// <summary>
        /// The display brightness value.
        /// </summary>
        public int Brightness
        {
            get
            {
                int brightness = 0;
                DeviceError res = (DeviceError) Interop.Device.DeviceDisplayGetBrightness(_displayId, out brightness);
                if (res != DeviceError.None)
                {
                    Log.Warn(DeviceExceptionFactory.LogTag, "unable to get brightness.");
                }
                return brightness;
            }
            set
            {
                //TODO: Check for maximum throw exception..
                DeviceError res = (DeviceError) Interop.Device.DeviceDisplaySetBrightness(_displayId, value);
                if (res != DeviceError.None)
                {
                    throw DeviceExceptionFactory.CreateException(res, "unable to set brightness value");
                }
            }
        }
        /// <summary>
        /// The current display state.
        /// </summary>
        public static DisplayState State
        {
            get
            {
                int state = 0;
                DeviceError res = (DeviceError) Interop.Device.DeviceDisplayGetState(out state);
                if (res != DeviceError.None)
                {
                    Log.Warn(DeviceExceptionFactory.LogTag, "unable to get Display state.");
                }
                return (DisplayState)state;
            }
        }

        private static event EventHandler<DisplayStateChangedEventArgs> s_stateChanged;
        /// <summary>
        /// StateChanged is raised when the state of the display is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">An DisplayStateChangedEventArgs object that contains the changed state</param>

        public static event EventHandler<DisplayStateChangedEventArgs> StateChanged
        {
            add
            {
                lock (s_lock)
                {
                    if (s_stateChanged == null)
                    {
                        EventListenerStart();
                    }
                    s_stateChanged += value;
                }
            }
            remove
            {
                lock (s_lock)
                {
                    s_stateChanged -= value;
                    if (s_stateChanged == null)
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
                DisplayStateChangedEventArgs e = new DisplayStateChangedEventArgs()
                {
                    State = (DisplayState)val
                };
                s_stateChanged?.Invoke(null, e);
                return true;
            };
            Interop.Device.DeviceAddCallback(EventType.DisplayState, s_handler, IntPtr.Zero);
        }

        private static void EventListenerStop()
        {
            Interop.Device.DeviceRemoveCallback(EventType.DisplayState, s_handler);
        }
    }
}
