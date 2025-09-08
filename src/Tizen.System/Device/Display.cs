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
    /// Enumeration for the available display states.
    /// An application cannot put the device into the power off state or the suspend state.
    /// </summary>
    /// <remarks>
    /// Dim may be ignored if the DIM state is disabled on the platform.
    /// </remarks>
    /// <since_tizen> 3 </since_tizen>
    public enum DisplayState
    {
        /// <summary>
        /// Normal state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Normal = Interop.Device.DisplayState.Normal,
        /// <summary>
        /// Screen dim state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Dim = Interop.Device.DisplayState.ScreenDim,
        /// <summary>
        /// Screen off state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Off = Interop.Device.DisplayState.ScreenOff,
    }

    /// <summary>
    /// The Display class provides the properties and events to control the display status and brightness.
    /// </summary>
    /// <remarks>
    /// The Display API provides the way to get the current display brightness value,
    /// the display state, and the total number of available displays.
    /// It also provides the events for an application to receive the display state change events from the device.
    /// To receive the display event, the application should register with an associated EventHandler.
    /// </remarks>
    /// <privilege>
    /// http://tizen.org/privilege/display
    /// </privilege>
    /// <example>
    /// <code>
    ///     Console.WriteLine("Display current state is: {0}", Tizen.System.Display.State);
    ///     Console.WriteLine("Total number of Displays are: {0}", Tizen.System.Display.NumberOfDisplays);
    /// </code>
    /// </example>
    /// <since_tizen> 3 </since_tizen>
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
        /// The number of available display devices connected to current device.
        /// </summary>
        /// <remarks>
        /// Retrieves the number of display devices connected to the system.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        /// <example>
        /// <code>
        /// using Tizen.System;
        /// ...
        /// Console.WriteLine("Total number of Displays are: {0}", Display.NumberOfDisplays);
        /// </code>
        /// </example>
        /// <seealso cref="Display.MaxBrightness"/>
        /// <seealso cref="Display.Brightness"/>
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
        /// Gets all the available displays.
        /// The display at the index zero is always assigned to the main display.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// The maximum brightness value that can be set for the specific display.
        /// </summary>
        /// <remarks>
        /// Retrieves the maximum brightness level of a specific display device.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        /// <example>
        /// <code>
        ///     Display display = Display.Displays[0];
        ///     Console.WriteLine("Display MaxBrightness is: {0}", display.MaxBrightness);
        /// </code>
        /// </example>
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
        /// The brightness value of the specific display device.
        /// </summary>
        /// <remarks>
        /// The brightness value should be less than or equal to the MaxBrightness value.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="ArgumentException">When an invalid parameter value is set.</exception>
        /// <exception cref="UnauthorizedAccessException">If the privilege is not set.</exception>
        /// <exception cref="InvalidOperationException">In case of any system error.</exception>
        /// <exception cref="NotSupportedException">This exception can be due to device not supported.</exception>
        /// <example>
        /// <code>
        ///     Display display = Display.Displays[0];
        ///     Console.WriteLine("Display current Brightness is: {0}", display.Brightness);
        /// </code>
        /// </example>
        /// <seealso cref="Display.MaxBrightness"/>
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
        /// The current device display state, including normal, dim, and off states.
        /// </summary>
        /// <remarks>
        /// When the display state is set, it should be checked the profile version and supported display state.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        /// <example>
        /// <code>
        /// using Tizen.System;
        /// ...
        /// DisplayState current = Display.State;
        /// Console.WriteLine("Display current state is: {0}", current);
        /// ...
        /// Display.State = DisplayState.Normal;
        /// ...
        /// </code>
        /// </example>
        /// <seealso cref="Power.RequestLock"/>
        /// <seealso cref="Power.ReleaseLock"/>
        /// <seealso cref="DisplayState"/>
        /// <seealso cref="DisplayStateChangedEventArgs"/>
        public static DisplayState State
        {
            get
            {
                Interop.Device.DisplayState state = 0;
                DeviceError res = (DeviceError)Interop.Device.DeviceDisplayGetState(out state);
                if (res != DeviceError.None)
                {
                    Log.Warn(DeviceExceptionFactory.LogTag, "Unable to get Display state.");
                }
                return (DisplayState)state;
            }
            set
            {
                DeviceError res = (DeviceError)Interop.Device.DeviceDisplayChangeState((Interop.Device.DisplayState)value);
                if (res != DeviceError.None)
                {
                    Log.Warn(DeviceExceptionFactory.LogTag, "Unable to chage display state");
                }
            }
        }

        private static event EventHandler<DisplayStateChangedEventArgs> s_stateChanged;
        /// <summary>
        ///  StateChanged is raised when the state of the display is changed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <example>
        /// <code>
        /// public static async Task DisplayEventHandler()
        /// {
        ///     EventHandler&lt;DisplayStateChangedEventArgs&gt; handler = null;
        ///     handler = (object sender, DisplayStateChangedEventArgs args) =>
        ///     {
        ///          Console.WriteLine("Display State is: {0}", args.State);
        ///     }
        ///     Display.StateChanged += handler;
        ///     await Task.Delay(20000);
        /// }
        /// </code>
        /// </example>
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
