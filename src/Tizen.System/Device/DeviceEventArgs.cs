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
using System.ComponentModel;

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

    /// <summary>
    /// PowerStateWaitEventArgs is an extended EventArgs class.
    /// This class contains event arguments for the (PowerState)StateWaitCallback event from the Power class.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class PowerStateWaitEventArgs : EventArgs
    {
        internal PowerStateWaitEventArgs() {}
        /// <summary>
        /// PrevState indicates reason power state where transition has started
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PowerState PrevState { get; internal set; }
        /// <summary>
        /// NextState indicates power state to be changed by transition
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PowerState NextState { get; internal set; }
        /// <summary>
        /// WaitCallbackId indicates unique id for each callback invocation.
        /// It is used to confirm or cancel about subscribed callback.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public UInt64 WaitCallbackId { get; internal set; }
        /// <summary>
        /// TransitionReason indicates reason for what triggered the transition
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PowerTransitionReason TransitionReason { get; internal set; }
    }

    /// <summary>
    /// PowerTransientStateWaitEventArgs is an extended EventArgs class.
    /// This class contains event arguments for the (PowerTransientState)StateWaitCallback event from the Power class.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class PowerTransientStateWaitEventArgs : EventArgs
    {
        internal PowerTransientStateWaitEventArgs() {}
        /// <summary>
        /// TransientState indicates transient state to be changed by the transition
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PowerTransientState TransientState { get; internal set; }
        /// <summary>
        /// WaitCallbackId indicates unique id for each callback invocation.
        /// It is used to confirm or cancel about subscribed callback.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public UInt64 WaitCallbackId { get; internal set; }
        /// <summary>
        /// TransitionReason indicates reason for what triggered the transition
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PowerTransitionReason TransitionReason { get; internal set; }
    }

    /// <summary>
    /// PowerLockStateChangedEventArgs is an extended EventArgs class.
    /// This class contains event arguments for the (PowerLock)StateChangedCallback event from the Power class.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class PowerLockStateChangedEventArgs : EventArgs
    {
        internal PowerLockStateChangedEventArgs() {}
        /// <summary>
        ///  PowerLockType indicates Type of power lock
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PowerLock PowerLockType { get; internal set; }
        /// <summary>
        /// PowerLockState indicates locked or unlocked about power lock type.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PowerLockState PowerLockState { get; internal set; }
    }

    /// <summary>
    /// PowerStateChangeRequestEventArgs is an extended EventArgs class.
    /// This class contains event arguments for the (PowerState)StateChangeRequestCallback event from the Power class.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class PowerStateChangeRequestEventArgs : EventArgs
    {
        internal PowerStateChangeRequestEventArgs() {}
        /// <summary>
        /// PowerState indicates state to be changed that was requested.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PowerState PowerState { get; internal set; }
        /// <summary>
        /// Retval indicates return of change state result from deviced.
        /// If Retval is negative, it means failure, 0 means success.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Retval { get; internal set; }
    }
}
