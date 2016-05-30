using System;

namespace Tizen.System
{
    // Battery
    public class BatteryCapacityChangedEventArgs : EventArgs
    {
        /// <summary>
        /// The current capacity of the battery.
        /// Capacity is an integer value from 0 to 100, that indicates remaining battery charge as a percentage of the maximum level.
        /// </summary>
        public int Capacity { get; internal set; }
    }

    public class BatteryLevelChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Level indicates the Current battery level status which is of type BatteryLevelStatus.
        /// </summary>
        public BatteryLevelStatus Level { get; internal set; }
    }

    public class BatteryChargingStateChangedEventArgs : EventArgs
    {
        /// <summary>
        /// The charging state of the battery. Charging is of type boolean which indicates true/false based on currrent charging status.
        /// </summary>
        public bool IsCharging { get; internal set; }
    }

    // Display
    public class DisplayStateChangedEventArgs : EventArgs
    {
        /// <summary>
        /// State indicates the current display state of the device which is an enum of type DisplayState.
        /// </summary>
        public DisplayState State { get; internal set; }
    }

    // Led
    public class LedBrightnessChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Brightness indicates the current brightness level of the display as an integer.
        /// </summary>
        public int Brightness { get; internal set; }
    }
}
