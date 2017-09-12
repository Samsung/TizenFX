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

namespace Tizen.System
{
    /// <summary>
    /// Enumeration for the battery levels.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum BatteryLevelStatus
    {
        /// <summary>
        /// The battery goes empty.
        /// Prepare for the safe termination of the application,
        /// because the device starts a shutdown process soon
        /// after entering this level.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Empty = 0,
        /// <summary>
        /// The battery charge is at a critical state.
        /// You may have to stop using the multimedia features,
        /// because they are not guaranteed to work correctly
        /// with this battery status.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Critical,
        /// <summary>
        /// The battery has little charge left.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Low,
        /// <summary>
        /// The battery status is not to be careful.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        High,
        /// <summary>
        /// The battery status is fully charged.
        /// It means no more charge.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Full
    }

    /// <summary>
    /// The Battery class provides the properties and events for the device battery.
    /// </summary>
    /// <remarks>
    /// The Battery API provides the way to get the current battery capacity value (Percent),
    /// the battery state, and the charging state. It also provides the events for an application
    /// to receive the battery status change events from the device.
    /// To receive the battery event, the application should register with the respective EventHandler.
    /// </remarks>
    /// <code>
    ///     Console.WriteLine("battery Charging state is: {0}", Tizen.System.Battery.IsCharging);
    ///     Console.WriteLine("battery Percent is: {0}", Tizen.System.Battery.Percent);
    /// </code>
    public static class Battery
    {
        private static readonly object s_lock = new object();
        /// <summary>
        /// Gets the battery charge percentage.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>It returns an integer value from 0 to 100 that indicates the remaining
        /// battery charge as a percentage of the maximum level.</value>
        public static int Percent
        {
            get
            {
                int percent = 0;
                DeviceError res = (DeviceError)Interop.Device.DeviceBatteryGetPercent(out percent);
                if (res != DeviceError.None)
                {
                    Log.Warn(DeviceExceptionFactory.LogTag, "unable to get battery percentage.");
                }
                return percent;
            }
        }
        /// <summary>
        /// Gets the current battery level.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static BatteryLevelStatus Level
        {
            get
            {
                int level = 0;
                DeviceError res = (DeviceError)Interop.Device.DeviceBatteryGetLevelStatus(out level);
                if (res != DeviceError.None)
                {
                    Log.Warn(DeviceExceptionFactory.LogTag, "unable to get battery status.");
                }
                return (BatteryLevelStatus)level;
            }
        }
        /// <summary>
        /// Gets the current charging state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static bool IsCharging
        {
            get
            {
                bool charging;
                DeviceError res = (DeviceError)Interop.Device.DeviceBatteryIsCharging(out charging);
                if (res != DeviceError.None)
                {
                    Log.Warn(DeviceExceptionFactory.LogTag, "unable to get battery charging state.");
                }
                return charging;
            }
        }

        private static EventHandler<BatteryPercentChangedEventArgs> s_capacityChanged;
        /// <summary>
        /// CapacityChanged is triggered when the battery charge percentage is changed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <code>
        /// public static async Task BatteryEventHandler()
        /// {
        ///     EventHandler<BatteryPercentChangedEventArgs> handler = null;
        ///     handler = (object sender, BatteryChargingStateChangedEventArgs args) =>
        ///     {
        ///          Console.WriteLine("battery Percent is: {0}", args.Percent);
        ///     }
        ///     Battery.PercentChanged += handler;
        ///     await Task.Delay(20000);
        ///  }
        /// </code>
        public static event EventHandler<BatteryPercentChangedEventArgs> PercentChanged
        {
            add
            {
                lock (s_lock)
                {
                    if (s_capacityChanged == null)
                    {
                        EventListenerStart(EventType.BatteryPercent);
                    }
                    s_capacityChanged += value;
                }
            }
            remove
            {
                lock (s_lock)
                {
                    s_capacityChanged -= value;
                    if (s_capacityChanged == null)
                    {
                        EventListenerStop(EventType.BatteryPercent);
                    }
                }
            }
        }

        private static event EventHandler<BatteryLevelChangedEventArgs> s_levelChanged;

        /// <summary>
        /// LevelChanged is triggered when the battery level is changed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <code>
        /// public static async Task BatteryEventHandler()
        /// {
        ///     EventHandler<BatteryLevelChangedEventArgs> handler = null;
        ///     handler = (object sender, BatteryLevelChangedEventArgs args) =>
        ///     {
        ///          Console.WriteLine("battery Level is: {0}", args.Level);
        ///     }
        ///     Battery.LevelChanged += handler;
        ///     await Task.Delay(20000);
        ///  }
        /// </code>
        public static event EventHandler<BatteryLevelChangedEventArgs> LevelChanged
        {
            add
            {
                lock (s_lock)
                {
                    if (s_levelChanged == null)
                    {
                        EventListenerStart(EventType.BatteryLevel);
                    }
                    s_levelChanged += value;
                }
            }
            remove
            {
                lock (s_lock)
                {
                    s_levelChanged -= value;
                    if (s_levelChanged == null)
                    {
                        EventListenerStop(EventType.BatteryLevel);
                    }
                }
            }
        }

        private static event EventHandler<BatteryChargingStateChangedEventArgs> s_chargingStateChanged;
        /// <summary>
        /// ChargingStatusChanged is triggered when the battery charging status is changed.
        /// This event is triggered when the charger is connected/disconnected.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <code>
        /// public static async Task BatteryEventHandler()
        /// {
        ///     EventHandler<BatteryChargingStateChangedEventArgs> handler = null;
        ///     handler = (object sender, BatteryChargingStateChangedEventArgs args) =>
        ///     {
        ///          Console.WriteLine("battery Level is: {0}", args.IsCharging);
        ///     }
        ///     Battery.ChargingStateChanged += handler;
        ///     await Task.Delay(20000);
        ///  }
        /// </code>
        public static event EventHandler<BatteryChargingStateChangedEventArgs> ChargingStateChanged
        {
            add
            {
                lock (s_lock)
                {
                    if (s_chargingStateChanged == null)
                    {
                        EventListenerStart(EventType.BatteryCharging);
                    }
                    s_chargingStateChanged += value;
                }
            }
            remove
            {
                lock (s_lock)
                {
                    s_chargingStateChanged -= value;
                    if (s_chargingStateChanged == null)
                    {
                        EventListenerStop(EventType.BatteryCharging);
                    }
                }
            }
        }

        private static Interop.Device.deviceCallback s_cpacityHandler;
        private static Interop.Device.deviceCallback s_levelHandler;
        private static Interop.Device.deviceCallback s_chargingHandler;

        private static void EventListenerStart(EventType eventType)
        {
            switch (eventType)
            {
                case EventType.BatteryPercent:
                    s_cpacityHandler = (int type, IntPtr value, IntPtr data) =>
                    {
                        int val = value.ToInt32();
                        BatteryPercentChangedEventArgs e = new BatteryPercentChangedEventArgs()
                        {
                            Percent = val
                        };
                        s_capacityChanged?.Invoke(null, e);
                        return true;
                    };

                    Interop.Device.DeviceAddCallback(eventType, s_cpacityHandler, IntPtr.Zero);
                    break;

                case EventType.BatteryLevel:
                    s_levelHandler = (int type, IntPtr value, IntPtr data) =>
                    {
                        int val = value.ToInt32();
                        BatteryLevelChangedEventArgs e = new BatteryLevelChangedEventArgs()
                        {
                            Level = (BatteryLevelStatus)val
                        };
                        s_levelChanged?.Invoke(null, e);
                        return true;
                    };

                    Interop.Device.DeviceAddCallback(eventType, s_levelHandler, IntPtr.Zero);
                    break;

                case EventType.BatteryCharging:
                    s_chargingHandler = (int type, IntPtr value, IntPtr data) =>
                    {
                        bool val = (value.ToInt32() == 1);
                        BatteryChargingStateChangedEventArgs e = new BatteryChargingStateChangedEventArgs()
                        {
                            IsCharging = val
                        };
                        s_chargingStateChanged?.Invoke(null, e);
                        return true;
                    };
                    Interop.Device.DeviceAddCallback(eventType, s_chargingHandler, IntPtr.Zero);
                    break;
            }
        }

        private static void EventListenerStop(EventType eventType)
        {
            switch (eventType)
            {
                case EventType.BatteryPercent:
                    Interop.Device.DeviceRemoveCallback(eventType, s_cpacityHandler);
                    break;

                case EventType.BatteryLevel:
                    Interop.Device.DeviceRemoveCallback(eventType, s_levelHandler);
                    break;

                case EventType.BatteryCharging:
                    Interop.Device.DeviceRemoveCallback(eventType, s_chargingHandler);
                    break;
            }
        }
    }
}
