using System;

namespace Tizen.System
{
    /// <summary>
    /// BatteryPercentChangedEventArgs is an extended EventArgs class. This class contains event arguments for BatteryPercentChanged event from Battery class.
    /// </summary>
    public class BatteryPercentChangedEventArgs : EventArgs
    {
        internal BatteryPercentChangedEventArgs(){}
        /// <summary>
        /// The current capacity of the battery.
        /// Capacity is an integer value from 0 to 100, that indicates remaining battery charge as a percentage of the maximum level.
        /// </summary>
        public int Percent { get; internal set; }
    }

    /// <summary>
    /// BatteryLevelChangedEventArgs is an extended EventArgs class. This class contains event arguments for BatteryLevelChanged event from Battery class.
    /// </summary>
    public class BatteryLevelChangedEventArgs : EventArgs
    {
        internal BatteryLevelChangedEventArgs(){}
        /// <summary>
        /// Level indicates the Current battery level status which is of type BatteryLevelStatus.
        /// </summary>
        public BatteryLevelStatus Level { get; internal set; }
    }

    /// <summary>
    /// BatteryChargingStateChangedEventArgs is an extended EventArgs class. This class contains event arguments for BatteryChargingStateChanged event from Battery class.
    /// </summary>
    public class BatteryChargingStateChangedEventArgs : EventArgs
    {
        internal BatteryChargingStateChangedEventArgs() {}
        /// <summary>
        /// The charging state of the battery. Charging is of type boolean which indicates true/false based on currrent charging status.
        /// </summary>
        public bool IsCharging { get; internal set; }
    }

    /// <summary>
    /// DisplayStateChangedEventArgs is an extended EventArgs class. This class contains event arguments for DisplayStateChanged event from Display class.
    /// </summary>
    public class DisplayStateChangedEventArgs : EventArgs
    {
        internal DisplayStateChangedEventArgs() {}
        /// <summary>
        /// State indicates the current display state of the device which is an enum of type DisplayState.
        /// </summary>
        public DisplayState State { get; internal set; }
    }

    /// <summary>
    /// LedBrightnessChangedEventArgs is an extended EventArgs class. This class contains event arguments for LedBrightnessChanged event from Led class.
    /// </summary>
    public class LedBrightnessChangedEventArgs : EventArgs
    {
        internal LedBrightnessChangedEventArgs() {}
        /// <summary>
        /// Brightness indicates the current brightness level of the display as an integer.
        /// </summary>
        public int Brightness { get; internal set; }
    }
}
