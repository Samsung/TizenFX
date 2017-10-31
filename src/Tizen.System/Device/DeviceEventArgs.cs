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
    /// BatteryPercentChangedEventArgs is an extended EventArgs class. This class contains event arguments for the BatteryPercentChanged event from the battery class.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class BatteryPercentChangedEventArgs : EventArgs
    {
        internal BatteryPercentChangedEventArgs(){}
        /// <summary>
        /// The current capacity of the battery.
        /// Capacity is an integer value from 0 to 100 that indicates the remaining battery charge as a percentage of the maximum level.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int Percent { get; internal set; }
    }

    /// <summary>
    /// BatteryLevelChangedEventArgs is an extended EventArgs class. This class contains event arguments for the BatteryLevelChanged event from the battery class.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class BatteryLevelChangedEventArgs : EventArgs
    {
        internal BatteryLevelChangedEventArgs(){}
        /// <summary>
        ///  The level indicates the current battery level status which is a type of the BatteryLevelStatus.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public BatteryLevelStatus Level { get; internal set; }
    }

    /// <summary>
    /// BatteryChargingStateChangedEventArgs is an extended EventArgs class. This class contains event arguments for the BatteryChargingStateChanged event from the battery class.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class BatteryChargingStateChangedEventArgs : EventArgs
    {
        internal BatteryChargingStateChangedEventArgs() {}
        /// <summary>
        /// The charging state of the battery. Charging is a type of a boolean which indicates true/false based on the current charging status.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool IsCharging { get; internal set; }
    }

    /// <summary>
    /// DisplayStateChangedEventArgs is an extended EventArgs class. This class contains event arguments for the DisplayStateChanged event from the display class.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class DisplayStateChangedEventArgs : EventArgs
    {
        internal DisplayStateChangedEventArgs() {}
        /// <summary>
        /// The state indicates the current display state of the device which is an enumeration of the type DisplayState.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public DisplayState State { get; internal set; }
    }

    /// <summary>
    /// LedBrightnessChangedEventArgs is an extended EventArgs class. This class contains event arguments for the LedBrightnessChanged event from the LED class.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class LedBrightnessChangedEventArgs : EventArgs
    {
        internal LedBrightnessChangedEventArgs() {}
        /// <summary>
        /// Brightness indicates the current brightness level of the display as an integer.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int Brightness { get; internal set; }
    }
}
