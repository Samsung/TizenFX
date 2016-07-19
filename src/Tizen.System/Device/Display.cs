using System;
using System.Collections.Generic;
namespace Tizen.System
{
    /// <summary>
    /// Enumeration for the available Display states.
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
    /// The Display class provides Properties and Events to control the display status and brightness.
    /// </summary>
    /// <remarks>
    /// The Display API provides the way to get the current Display brightness value,
    /// display state and toal number of available displayes.
    /// It also provides Events for an application to receive the Display state change events from the device.
    /// To receive the Display event, application should register with assocated EventHandler.
    /// </remarks>
    /// <previlege>
    /// http://tizen.org/privilege/display
    /// </previlege>
    /// <code>
    ///     Console.WriteLine("Display current state is: {0}", Tizen.System.Display.State);
    ///     Console.WriteLine("Total number of Displays are: {0}", Tizen.System.Display.NumberOfDisplays);
    /// </code>
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
        /// The number of available display devices.
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
        /// The Display at index zero is always assigned to the main display.
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
        /// The maximum brightness value that can be set for the specific Display.
        /// </summary>
        /// <code>
        ///     Display display = Display.Displays[0];
        ///     Console.WriteLine("Display MaxBrightness is: {0}", display.MaxBrightness);
        /// </code>
        public int MaxBrightness
        {
            get
            {
                int max = 0;
                DeviceError res = (DeviceError)Interop.Device.DeviceDisplayGetMaxBrightness(_displayId, out max);
                if (res != DeviceError.None)
                {
                    Log.Warn(DeviceExceptionFactory.LogTag, "unable to get max brightness.");
                }
                return max;
            }
        }

        /// <summary>
        /// The display brightness valu of the Display.
        /// </summary>
        /// <remarks>
        /// Brightness value should be less than are equal to MaxBrightness value.
        /// </remarks>
        /// <exception cref="ArgumentException"> When the invalid parameter value is set.</exception>
        /// <exception cref = "UnauthorizedAccessException"> If the privilege is not set.</exception>
        /// <code>
        ///     Display display = Display.Displays[0];
        ///     Console.WriteLine("Display current Brightness is: {0}", display.Brightness);
        /// </code>
        public int Brightness
        {
            get
            {
                int brightness = 0;
                DeviceError res = (DeviceError)Interop.Device.DeviceDisplayGetBrightness(_displayId, out brightness);
                if (res != DeviceError.None)
                {
                    Log.Warn(DeviceExceptionFactory.LogTag, "unable to get brightness.");
                }
                return brightness;
            }
            set
            {
                //TODO: Check for maximum throw exception..
                DeviceError res = (DeviceError)Interop.Device.DeviceDisplaySetBrightness(_displayId, value);
                if (res != DeviceError.None)
                {
                    throw DeviceExceptionFactory.CreateException(res, "unable to set brightness value");
                }
            }
        }
        /// <summary>
        /// The current device display state.
        /// </summary>
        public static DisplayState State
        {
            get
            {
                int state = 0;
                DeviceError res = (DeviceError)Interop.Device.DeviceDisplayGetState(out state);
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
        /// <code>
        /// public static async Task DisplayEventHandler()
        /// {
        ///     EventHandler<DisplayStateChangedEventArgs> handler = null;
        ///     handler = (object sender, DisplayStateChangedEventArgs args) =>
        ///     {
        ///          Console.WriteLine("Display State is: {0}", args.State);
        ///     }
        ///     Battery.StateChanged += handler;
        ///     await Task.Delay(20000);
        ///  }
        /// </code>
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
