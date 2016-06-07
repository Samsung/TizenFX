using System;

namespace Tizen.System
{
    /// <summary>
    /// Enumeration for the battery level.
    /// </summary>
    public enum BatteryLevelStatus
    {
        /// <summary>
        /// The battery goes empty.
        /// Prepare for the safe termination of the application,
        /// because the device starts a shutdown process soon
        /// after entering this level.
        /// </summary>
        Empty = 0,
        /// <summary>
        /// The battery charge is at a critical state.
        /// You may have to stop using multimedia features,
        /// because they are not guaranteed to work correctly
        /// at this battery status.
        /// </summary>
        Critical,
        /// <summary>
        /// The battery has little charge left.
        /// </summary>
        Low,
        /// <summary>
        /// The battery status is not to be careful.
        /// </summary>
        High,
        /// <summary>
        /// The battery status is full.
        /// </summary>
        Full
    }

    /// <summary>
    /// The Battery API provides functions to get information about the battery.
    /// </summary>
    /// <remarks>
    /// The Battery API provides the way to get the current battery capacity value,
    /// battery state and charging state. It also supports the API for an application
    /// to receive the battery events from the system. To receive the battery event
    /// it should be described by the callback function.
    /// </remarks>
    public static class Battery
    {
        private static readonly object s_lock = new object();
        /// <summary>
        /// Gets the battery charge percentage.
        /// </summary>
        /// <value>It returns an integer value from 0 to 100 that indicates remaining
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
        /// Gets the battery level.
        /// </summary>
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
        /// Gets the charging state.
        /// </summary>
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
        /// CapacityChanged is triggered when the battery charge percentage is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">A BatteryCapacityChangedEventArgs object that contains changed battery capacity</param>

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
        /// LevelChanged is triggered when the battery level is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">A BatteryLevelChangedEventArgs object that contains changed battery level </param>
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
        /// ChargingStatusChanged is triggered when the battery charging status is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">A BatteryChargingStateChangedEventArgs object that contains changed battery charging state</param>

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
