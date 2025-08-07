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
    /// Enumeration for power lock type.
    /// </summary>
    /// <remarks>
    /// DisplayDim may be ignored if the DIM state is disabled on the platform.
    /// </remarks>
    /// <since_tizen> 5 </since_tizen>
    public enum PowerLock
    {
        /// <summary>
        /// CPU lock.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Cpu = Interop.Device.PowerLock.Cpu,
        /// <summary>
        /// Display the normal lock.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        DisplayNormal = Interop.Device.PowerLock.DisplayNormal,
        /// <summary>
        /// Display the dim lock.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        DisplayDim = Interop.Device.PowerLock.DisplayDim,
    }

    /// <summary>
    /// Enumeration for power transition reason.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum PowerTransitionReason
    {
        /// <summary>
        /// Unknown reason.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        Unknown = Interop.Device.PowerTransitionReason.Unknown,
        /// <summary>
        /// Power key pressed.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        ReasonPowerKey = Interop.Device.PowerTransitionReason.ReasonPowerKey,
        /// <summary>
        /// Volume up key pressed.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        ReasonVolumeUpKey = Interop.Device.PowerTransitionReason.ReasonVolumeUpKey,
        /// <summary>
        /// Volume down key pressed.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        ReasonVolumeDownKey = Interop.Device.PowerTransitionReason.ReasonVolumeDownKey,
        /// <summary>
        /// Battery capacity reaches normal level.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        ReasonBatteryNormalLevel = Interop.Device.PowerTransitionReason.ReasonBatteryNormalLevel,
        /// <summary>
        /// Battery capacity reaches warning level.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        ReasonBatteryWarningLevel = Interop.Device.PowerTransitionReason.ReasonBatteryWarningLevel,
        /// <summary>
        /// Battery capacity reaches critical level.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        ReasonBatteryCriticalLevel = Interop.Device.PowerTransitionReason.ReasonBatteryCriticalLevel,
        /// <summary>
        /// Battery capacity reaches poweroff level.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        ReasonBatteryPoweroffLevel = Interop.Device.PowerTransitionReason.ReasonBatteryPoweroffLevel,
        /// <summary>
        /// Display off.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        ReasonDisplayOff = Interop.Device.PowerTransitionReason.ReasonDisplayOff,
        /// <summary>
        /// Touch key pressed.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        ReasonTouchKey = Interop.Device.PowerTransitionReason.ReasonTouchKey,
        /// <summary>
        /// Touch screen pressed.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        ReasonTouchScreen = Interop.Device.PowerTransitionReason.ReasonTouchScreen,
        /// <summary>
        /// USB attached or detached.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        ReasonUsb = Interop.Device.PowerTransitionReason.ReasonUsb,
        /// <summary>
        /// Charger attached or detached.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        ReasonCharger = Interop.Device.PowerTransitionReason.ReasonCharger,
        /// <summary>
        /// HDMI cable attached or detached.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        ReasonHdmi = Interop.Device.PowerTransitionReason.ReasonHdmi,
        /// <summary>
        /// Display port cable attached or detached.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        ReasonDisplayPort = Interop.Device.PowerTransitionReason.ReasonDisplayPort,
        /// <summary>
        /// Embedded display port cable attached or detached.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        ReasonEmbeddedDisplayPort = Interop.Device.PowerTransitionReason.ReasonEmbeddedDisplayPort,
        /// <summary>
        /// WIFI event.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        ReasonWifi = Interop.Device.PowerTransitionReason.ReasonWifi,
        /// <summary>
        /// Bluetooth event.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        ReasonBluetooth = Interop.Device.PowerTransitionReason.ReasonBluetooth,
        /// <summary>
        /// NFC event.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        ReasonNfc = Interop.Device.PowerTransitionReason.ReasonNfc,
        /// <summary>
        /// Telephony event.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        ReasonTelephony = Interop.Device.PowerTransitionReason.ReasonTelephony,
        /// <summary>
        /// Zigbee event.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        ReasonZigbee = Interop.Device.PowerTransitionReason.ReasonZigbee,
        /// <summary>
        /// Ethernet event.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        ReasonEthernet = Interop.Device.PowerTransitionReason.ReasonEthernet,
        /// <summary>
        /// Audio event.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        ReasonAudio = Interop.Device.PowerTransitionReason.ReasonAudio,
        /// <summary>
        /// Alarm event.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        ReasonAlarm = Interop.Device.PowerTransitionReason.ReasonAlarm,
        /// <summary>
        /// Sensor event.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        ReasonSensor = Interop.Device.PowerTransitionReason.ReasonSensor,
        /// <summary>
        /// RTC event.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        ReasonRtc = Interop.Device.PowerTransitionReason.ReasonRtc,
        /// <summary>
        /// Headset attached or detached or button pressed.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        ReasonHeadset = Interop.Device.PowerTransitionReason.ReasonHeadset,
        /// <summary>
        /// External memory inserted or deleted.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        ReasonExternalMemory = Interop.Device.PowerTransitionReason.ReasonExternalMemory,
        /// <summary>
        /// Define custom reason from here.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        ReasonCustom = Interop.Device.PowerTransitionReason.ReasonCustom,
    }

    /// <summary>
    /// Enumeration for power state.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum PowerState : uint
    {
        /// <summary>
        /// Initial state of power module. It is especially meaningful in that
        /// this can be used to identify the first transition and implement booting UX.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        Start = Interop.Device.PowerState.Start,
        /// <summary>
        /// System keeps running.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        Normal = Interop.Device.PowerState.Normal,
        /// <summary>
        /// System may be suspended at any time.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        Sleep = Interop.Device.PowerState.Sleep,
        /// <summary>
        /// Prepare for poweroff and perform `systemctl poweroff`.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        Poweroff = Interop.Device.PowerState.Poweroff,
        /// <summary>
        /// Prepare for reboot and perform `systemctl reboot`.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        Reboot = Interop.Device.PowerState.Reboot,
        /// <summary>
        /// Prepare for exit and perform `systemctl exit`.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        Exit = Interop.Device.PowerState.Exit,
    }

    /// <summary>
    /// Enumeration for power transient state.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum PowerTransientState : uint
    {
        /// <summary>
        /// The first step of transitioning from sleep to normal.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        ResumingEarly = Interop.Device.PowerTransientState.ResumingEarly,
        /// <summary>
        /// The second step of transitioning from sleep to normal.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        Resuming = Interop.Device.PowerTransientState.Resuming,
        /// <summary>
        /// The last step of transitioning from sleep to normal.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        ResumingLate = Interop.Device.PowerTransientState.ResumingLate,
        /// <summary>
        /// The first step of transitioning from normal to sleep.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        SuspendingEarly = Interop.Device.PowerTransientState.SuspendingEarly,
        /// <summary>
        /// The second step of transitioning from normal to sleep.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        Suspending = Interop.Device.PowerTransientState.Suspending,
        /// <summary>
        /// The last step of transitioning from normal to sleep.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        SuspendingLate = Interop.Device.PowerTransientState.SuspendingLate,
    }

    /// <summary>
    /// Enumeration for power lock state.
    /// </summary>
    /// <since_tizen> 10 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum PowerLockState
    {
        /// <summary>
        /// Power lock is unlocked.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        Unlock = Interop.Device.PowerLockState.Unlock,
        /// <summary>
        /// Power lock is locked.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        Lock = Interop.Device.PowerLockState.Lock,
    }

    /// <summary>
    /// The Power class provides methods to control the power service.
    /// </summary>
    /// <remarks>
    /// The Power API provides the way to control the power service.
    /// It can be made to hold the specific state to avoid the CPU state internally.
    /// </remarks>
    /// <privilege>
    /// http://tizen.org/privilege/display
    /// </privilege>
    /// <since_tizen> 3 </since_tizen>
    public static class Power
    {
        private static readonly object s_lock = new object();

        /// <summary>
        /// [Obsolete("Please do not use! this will be deprecated")]
        /// </summary>
        /// <remarks>
        /// If the process dies, then every lock will be removed.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="timeout">
        /// The positive number in milliseconds or 0 for the permanent lock.
        /// So you must release the permanent lock of the power state with ReleaseCpuLock() if timeout_ms is zero.
        /// </param>
        /// <exception cref="ArgumentException">When an invalid parameter value is set.</exception>
        /// <exception cref="UnauthorizedAccessException">If the privilege is not set.</exception>
        /// <exception cref="InvalidOperationException">In case of any system error.</exception>
        /// Please do not use! This will be deprecated!
        /// Please use RequestLock instead!
        [Obsolete("Please do not use! This will be deprecated! Please use RequestLock instead!")]
        public static void RequestCpuLock(int timeout)
        {
            DeviceError res = (DeviceError)Interop.Device.DevicePowerRequestLock(Interop.Device.PowerLock.Cpu, timeout);
            if (res != DeviceError.None)
            {
                throw DeviceExceptionFactory.CreateException(res, "unable to acquire power lock.");
            }
        }
        /// <summary>
        /// [Obsolete("Please do not use! this will be deprecated")]
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="UnauthorizedAccessException">If the privilege is not set.</exception>
        /// <exception cref="InvalidOperationException">In case of any system error.</exception>
        /// Please do not use! This will be deprecated!
        /// Please use ReleaseLock instead!
        [Obsolete("Please do not use! This will be deprecated! Please use ReleaseLock instead!")]
        public static void ReleaseCpuLock()
        {
            DeviceError res = (DeviceError)Interop.Device.DevicePowerReleaseLock(Interop.Device.PowerLock.Cpu);
            if (res != DeviceError.None)
            {
                throw DeviceExceptionFactory.CreateException(res, "unable to release power lock.");
            }
        }

        /// <summary>
        /// Locks the given lock state for a specified time.
        /// After the given timeout (in milliseconds), unlock the given lock state automatically.
        /// </summary>
        /// <remarks>
        /// If the process dies, then every lock will be removed.
        /// </remarks>
        /// <privilege>
        /// http://tizen.org/privilege/display.state
        /// </privilege>
        /// <since_tizen> 5 </since_tizen>
        /// <param name="type">
        /// The power type to request lock.
        /// </param>
        /// <param name="timeout">
        /// The positive number in milliseconds or 0 for the permanent lock.
        /// So you must release the permanent lock of the power state with ReleaseLock() if timeout_ms is zero.
        /// </param>
        /// <exception cref="ArgumentException">When an invalid parameter value is set.</exception>
        /// <exception cref="UnauthorizedAccessException">If the privilege is not set.</exception>
        /// <exception cref="InvalidOperationException">In case of any system error.</exception>
        /// <example>
        /// <code>
        /// Tizen.System.Power.RequestLock(Tizen.System.Power.PowerLock.Cpu, 2000);
        /// </code>
        /// </example>
        /// <seealso cref="Power.ReleaseLock(PowerLock)"/>
        /// <seealso cref="PowerLock"/>
        public static void RequestLock(PowerLock type, int timeout)
        {
            DeviceError res = (DeviceError)Interop.Device.DevicePowerRequestLock((Interop.Device.PowerLock)type, timeout);
            if (res != DeviceError.None)
            {
                throw DeviceExceptionFactory.CreateException(res, "unable to acquire power lock.");
            }
        }
        /// <summary>
        /// Releases the given specific power lock type which was locked before.
        /// </summary>
        /// <remarks>
        /// Releases the lock of specific power lock type that was previously acquired using Power.RequestLock(PowerLock,int).
        /// </remarks>
        /// <privilege>
        /// http://tizen.org/privilege/display.state
        /// </privilege>
        /// <since_tizen> 5 </since_tizen>
        /// <param name="type">
        /// The power type to request lock.
        /// </param>
        /// <exception cref="ArgumentException">When an invalid parameter value is set.</exception>
        /// <exception cref="UnauthorizedAccessException">If the privilege is not set.</exception>
        /// <exception cref="InvalidOperationException">In case of any system error.</exception>
        /// <example>
        /// <code>
        /// Tizen.System.Power.ReleaseLock(Tizen.System.Power.PowerLock.Cpu);
        /// </code>
        /// </example>
        /// <seealso cref="Power.RequestLock(PowerLock,int)"/>
        /// <seealso cref="PowerLock"/>
        public static void ReleaseLock(PowerLock type)
        {
            DeviceError res = (DeviceError)Interop.Device.DevicePowerReleaseLock((Interop.Device.PowerLock)type);
            if (res != DeviceError.None)
            {
                throw DeviceExceptionFactory.CreateException(res, "unable to release power lock.");
            }
        }
        /// <summary>
        /// Requests the current device's power state change to be changed to powered off.
        /// </summary>
        /// <remarks>
        /// It operates synchronously and powers off the current device.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/reboot</privilege>
        /// <privlevel>platform</privlevel>
        /// <exception cref="UnauthorizedAccessException">If the privilege is not set.</exception>
        /// <exception cref="InvalidOperationException">In case of any system error.</exception>
        /// <example>
        /// <code>
        /// Tizen.System.Power.PowerOff();
        /// </code>
        /// </example>
        /// <since_tizen> 9 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void PowerOff()
        {
            DeviceError res = (DeviceError)Interop.Device.DevicePowerPowerOff();
            if (res != DeviceError.None)
            {
                throw DeviceExceptionFactory.CreateException(res, "unable to power off the device.");
            }
        }
        /// <summary>
        /// Sends a request to the deviced Rebooting the current device.
        /// </summary>
        /// <remarks>
        /// It operates asynchronously.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/reboot</privilege>
        /// <privlevel>platform</privlevel>
        /// <exception cref="UnauthorizedAccessException">If the privilege is not set.</exception>
        /// <exception cref="InvalidOperationException">In case of any system error.</exception>
        /// <example>
        /// <code>
        /// Tizen.System.Power.Reboot(null);
        /// </code>
        /// </example>
        /// <seealso cref="Power.CheckRebootAllowed()"/> 
        /// <since_tizen> 9 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void Reboot(string reason)
        {
            DeviceError res = (DeviceError)Interop.Device.DevicePowerReboot(reason);
            if (res != DeviceError.None)
            {
                throw DeviceExceptionFactory.CreateException(res, "unable to reboot the device.");
            }
        }

        /// <summary>
        /// Notify the deviced that it is ready for the actual action.
        /// </summary>
        /// <remarks>
        /// Notify the deviced that it is ok to take an actual action of change state.
        /// This function only works on the id received from device_power_state_wait_callback() and device_power_transient_state_wait_callback().
        /// Above functions are mapped to (PowerState)StateWaitCallback/(PowerTransientState)StateWaitCallback Event handler.
        /// </remarks>
        /// <since_tizen> 10 </since_tizen>
        /// <param name="wait_callback_id"> Wait callback id to confirm. </param>
        /// <exception cref="InvalidOperationException">In case of any system error.</exception>
        /// <example>
        /// <code>
        /// public static void MyPowerCallback(object sender, PowerStateWaitEventArgs args)
        /// {
        ///     Do Something...
        ///     Power.ConfirmWaitCallback(args.WaitCallbackId);
        /// }
        /// </code>
        /// </example>
        /// <seealso cref="PowerStateWaitEventArgs"/>
        /// <seealso cref="PowerTransientStateWaitEventArgs"/>
        /// <seealso cref="Power.CancelWaitCallback(UInt64)"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void ConfirmWaitCallback(UInt64 wait_callback_id)
        {
            DeviceError res = (DeviceError)Interop.Device.DevicePowerConfirmWaitCallback(wait_callback_id);
            if (res != DeviceError.None)
            {
                switch (res)
                {
                    case DeviceError.OperationFailed:
                        throw DeviceExceptionFactory.CreateException(res, "Failed to power confirm wait callback");
                    default:
                        throw DeviceExceptionFactory.CreateException(res, "Unable to call power confirm wait callback");
                }
            }
        }

        /// <summary>
        /// Notify the deviced that it needs undoing the current transition.
        /// </summary>
        /// <remarks>
        /// Notify the deviced that the current transition should be rewinded.
        /// This function only works on the id received from device_power_state_wait_callback() and device_power_transient_state_wait_callback().
        /// Above functions are mapped to (PowerState)StateWaitCallback/(PowerTransientState)StateWaitCallback Event handler.
        /// </remarks>
        /// <since_tizen> 10 </since_tizen>
        /// <param name="wait_callback_id"> Wait callback id to cancel. </param>
        /// <exception cref="InvalidOperationException">In case of any system error.</exception>
        /// <example>
        /// <code>
        /// public static void MyPowerCallback(object sender, PowerStateWaitEventArgs args)
        /// {
        ///     Do something with args...
        ///     Power.CancelWaitCallback(args.WaitCallbackId);
        /// }
        /// </code>
        /// </example>
        /// <seealso cref="PowerStateWaitEventArgs"/>
        /// <seealso cref="PowerTransientStateWaitEventArgs"/>
        /// <seealso cref="Power.ConfirmWaitCallback(UInt64)"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void CancelWaitCallback(UInt64 wait_callback_id)
        {
            DeviceError res = (DeviceError)Interop.Device.DevicePowerCancelWaitCallback(wait_callback_id);
            if (res != DeviceError.None)
            {
                switch (res)
                {
                    case DeviceError.OperationFailed:
                        throw DeviceExceptionFactory.CreateException(res, "Failed to power cancel wait callback");
                    default:
                        throw DeviceExceptionFactory.CreateException(res, "Unable to call power cancel wait callback");
                }
            }
        }

        /// <summary>
        /// Send request for changing power state asynchronously.
        /// </summary>
        /// <remarks>
        /// If it is need to get result callback event, then follow below description.
        /// However, if it is not necessary, skip add callback event.
        /// After change state request, callback event is called only once per change request.
        /// 1. Add callback event to power state request callback that you want to change.
        /// 2. This callback event will be invoked later by timeout or success/failure.
        /// 3. After callback event is called, it is better to clean up that subscribed callback events.
        /// </remarks>
        /// <since_tizen> 10 </since_tizen>
        /// <param name="state">  Target state. </param>
        /// <param name="timeout_sec"> Timeout for the async reply in second, maximum of 10 seconds.
        ///                             If you put 0, then it will be set 10 sec automatically. </param>
        /// <exception cref="InvalidOperationException">In case of any system error.</exception>
        /// <example>
        /// <code>
        /// public static void PowerStateChangedCallback(Object sender, PowerStateChangeRequestEventArgs args)
        /// {
        ///     args.Retval // If this value is negative, this means that the request failed.
        ///     Do something with args...
        /// }
        /// Power.SleepStateChangeRequestCallback += PowerStateChangedCallback;
        /// Power.ChangeState(PowerState.Sleep, 5);
        ///
        /// or just use like below
        /// Power.ChangeState(PowerState.Normal, 10);
        ///
        /// </code>
        /// </example>
        /// <seealso cref="PowerStateChangeRequestEventArgs"/>
        /// <seealso cref="PowerState"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void ChangeState(PowerState state, int timeout_sec)
        {
            PowerStateChangeRequestEventTrigger(state, timeout_sec);
        }

        /// <summary>
        /// Check if reboot is possible on the current device state.
        /// </summary>
        /// <remarks>
        /// The return value will be 0(not possible) or 1(possible).
        /// </remarks>
        /// <since_tizen> 10 </since_tizen>
        /// <example>
        /// <code>
        /// int retval = 0;
        /// retval = Power.CheckRebootAllowed();
        /// </code>
        /// </example>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static int CheckRebootAllowed()
        {
            int retval = 0;

            retval = Interop.Device.DevicePowerCheckRebootAllowed();
            if (retval < 0)
            {
                throw DeviceExceptionFactory.CreateException((DeviceError)retval, "Unable to call power check reboot allowed");
            }

            return retval;
        }

        #if !PROFILE_TV
        /// <summary>
        /// Gets the reason for the last device wakeup based on the scenario.
        /// </summary>
        /// <remarks>
        /// This api is not supported at TV profile.
        /// </remarks>
        /// <since_tizen> 10 </since_tizen>
        /// <exception cref="ArgumentException">When an invalid parameter value is set.</exception>
        /// <exception cref="InvalidOperationException">In case of any system error.</exception>
        /// <example>
        /// <code>
        /// PowerTransitionReason transition_reason = Power.GetWakeupReason();
        /// </code>
        /// </example>
        /// <seealso cref="PowerTransitionReason"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PowerTransitionReason GetWakeupReason()
        {
            Interop.Device.PowerTransitionReason reason = 0;

            DeviceError res = (DeviceError)Interop.Device.DevicePowerGetWakeupReason(out reason);
            if (res != DeviceError.None)
            {
                switch (res)
                {
                    case DeviceError.InvalidParameter:
                        throw DeviceExceptionFactory.CreateException(res, "Invalid Arguments");
                    case DeviceError.OperationFailed:
                        throw DeviceExceptionFactory.CreateException(res, "Failed to call power get wakeup reason");
                    default:
                        throw DeviceExceptionFactory.CreateException(res, "Unable to call power get wakeup reason");
                }
            }

            return (PowerTransitionReason)reason;
        }
        #endif

        /// <summary>
        /// Gets the status of power lock is locked or not based on specific power lock type.
        /// </summary>
        /// <remarks>
        /// Retrieves the status of a power lock.
        /// </remarks>
        /// <since_tizen> 10 </since_tizen>
        /// <param name="type"> Type of power lock. </param>
        /// <exception cref="ArgumentException">When an invalid parameter value is set.</exception>
        /// <exception cref="InvalidOperationException">In case of any system error.</exception>
        /// <example>
        /// <code>
        /// PowerLockState lock_state = Power.GetLockState(PowerLock.Cpu);
        /// </code>
        /// </example>
        /// <seealso cref="PowerLock"/>
        /// <seealso cref="PowerLockState"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PowerLockState GetLockState(PowerLock type)
        {
            Interop.Device.PowerLockState lock_state;

            DeviceError res = (DeviceError)Interop.Device.DevicePowerGetLockState((Interop.Device.PowerLock)type, out lock_state);
            if (res != DeviceError.None)
            {
                switch (res)
                {
                    case DeviceError.InvalidParameter:
                        throw DeviceExceptionFactory.CreateException(res, "Invalid Arguments");
                    default:
                        throw DeviceExceptionFactory.CreateException(res, "Unable to call power get lock state");
                }
            }
            return (PowerLockState)lock_state;
        }

        private static event EventHandler<PowerStateChangeRequestEventArgs> s_powerStateStartChangeRequestCallback;
        /// <summary>
        /// StartStateChangeRequestCallback is triggered when the request to change to Start power state is handled from deviced.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <example>
        /// <code>
        /// public static void PowerStateChangeRequestCallback(object sender, PowerStateChangeRequestEventArgs args)
        /// {
        ///     PowerState power_state = args.PowerState;
        ///     int retval = args.Retval;
        /// }
        /// Power.StartStateChangeRequestCallback += PowerStateChangeRequestCallback;
        /// </code>
        /// </example>
        /// <seealso cref="PowerStateChangeRequestEventArgs"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static event EventHandler<PowerStateChangeRequestEventArgs> StartStateChangeRequestCallback
        {
            add
            {
                lock (s_lock)
                {
                    s_powerStateStartChangeRequestCallback += value;
                }
            }
            remove
            {
                lock (s_lock)
                {
                    s_powerStateStartChangeRequestCallback -= value;
                }
            }
        }
        private static event EventHandler<PowerStateChangeRequestEventArgs> s_powerStateNormalChangeRequestCallback;
        /// <summary>
        /// NormalStateChangeRequestCallback is triggered when the request to change to Normal power state is handled from deviced.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <example>
        /// <code>
        /// public static void PowerStateChangeRequestCallback(object sender, PowerStateChangeRequestEventArgs args)
        /// {
        ///     PowerState power_state = args.PowerState;
        ///     int retval = args.Retval;
        /// }
        /// Power.NormalStateChangeRequestCallback += PowerStateChangeRequestCallback;
        /// </code>
        /// </example>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static event EventHandler<PowerStateChangeRequestEventArgs> NormalStateChangeRequestCallback
        {
            add
            {
                lock (s_lock)
                {
                    s_powerStateNormalChangeRequestCallback += value;
                }
            }
            remove
            {
                lock (s_lock)
                {
                    s_powerStateNormalChangeRequestCallback -= value;
                }
            }
        }
        private static event EventHandler<PowerStateChangeRequestEventArgs> s_powerStateSleepChangeRequestCallback;
        /// <summary>
        /// SleepStateChangeRequestCallback is triggered when the request to change to Sleep power state is handled from deviced.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <example>
        /// <code>
        /// public static void PowerStateChangeRequestCallback(object sender, PowerStateChangeRequestEventArgs args)
        /// {
        ///     PowerState power_state = args.PowerState;
        ///     int retval = args.Retval;
        /// }
        /// Power.SleepStateChangeRequestCallback += PowerStateChangeRequestCallback;
        /// </code>
        /// </example>
        /// <seealso cref="PowerStateChangeRequestEventArgs"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static event EventHandler<PowerStateChangeRequestEventArgs> SleepStateChangeRequestCallback
        {
            add
            {
                lock (s_lock)
                {
                    s_powerStateSleepChangeRequestCallback += value;
                }
            }
            remove
            {
                lock (s_lock)
                {
                    s_powerStateSleepChangeRequestCallback -= value;
                }
            }
        }

        private static event EventHandler<PowerStateChangeRequestEventArgs> s_powerStatePoweroffChangeRequestCallback;
        /// <summary>
        /// PoweroffStateChangeRequestCallback is triggered when the request to change to Poweroff power state is handled from deviced.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <example>
        /// <code>
        /// public static void PowerStateChangeRequestCallback(object sender, PowerStateChangeRequestEventArgs args)
        /// {
        ///     PowerState power_state = args.PowerState;
        ///     int retval = args.Retval;
        /// }
        /// Power.PoweroffStateChangeRequestCallback += PowerStateChangeRequestCallback;
        /// </code>
        /// </example>
        /// <seealso cref="PowerStateChangeRequestEventArgs"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static event EventHandler<PowerStateChangeRequestEventArgs> PoweroffStateChangeRequestCallback
        {
            add
            {
                lock (s_lock)
                {
                    s_powerStatePoweroffChangeRequestCallback += value;
                }
            }
            remove
            {
                lock (s_lock)
                {
                    s_powerStatePoweroffChangeRequestCallback -= value;
                }
            }
        }
        private static event EventHandler<PowerStateChangeRequestEventArgs> s_powerStateRebootChangeRequestCallback;
        /// <summary>
        /// RebootStateChangeRequestCallback is triggered when the request to change to Reboot power state is handled from deviced.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <example>
        /// <code>
        /// public static void PowerStateChangeRequestCallback(object sender, PowerStateChangeRequestEventArgs args)
        /// {
        ///     PowerState power_state = args.PowerState;
        ///     int retval = args.Retval;
        /// }
        /// Power.RebootStateChangeRequestCallback += PowerStateChangeRequestCallback;
        /// </code>
        /// </example>
        /// <seealso cref="PowerStateChangeRequestEventArgs"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static event EventHandler<PowerStateChangeRequestEventArgs> RebootStateChangeRequestCallback
        {
            add
            {
                lock (s_lock)
                {
                    s_powerStateRebootChangeRequestCallback += value;
                }
            }
            remove
            {
                lock (s_lock)
                {
                    s_powerStateRebootChangeRequestCallback -= value;
                }
            }
        }
        private static event EventHandler<PowerStateChangeRequestEventArgs> s_powerStateExitChangeRequestCallback;
        /// <summary>
        /// ExitStateChangeRequestCallback is triggered when the request to change to Exit power state is handled from deviced.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <example>
        /// <code>
        /// public static void PowerStateChangeRequestCallback(object sender, PowerStateChangeRequestEventArgs args)
        /// {
        ///     PowerState power_state = args.PowerState;
        ///     int retval = args.Retval;
        /// }
        /// Power.ExitStateChangeRequestCallback += PowerStateChangeRequestCallback;
        /// </code>
        /// </example>
        /// <seealso cref="PowerStateChangeRequestEventArgs"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static event EventHandler<PowerStateChangeRequestEventArgs> ExitStateChangeRequestCallback
        {
            add
            {
                lock (s_lock)
                {
                    s_powerStateExitChangeRequestCallback += value;
                }
            }
            remove
            {
                lock (s_lock)
                {
                    s_powerStateExitChangeRequestCallback -= value;
                }
            }
        }

        private static void StartChangeRequestHandlerCallback(uint state, int retval, IntPtr user_data)
        {
            PowerStateChangeRequestEventArgs args = new PowerStateChangeRequestEventArgs()
            {
                PowerState = (PowerState)state,
                Retval = retval,
            };
            s_powerStateStartChangeRequestCallback?.Invoke(null, args);
        }

        private static void NormalChangeRequestHandlerCallback(uint state, int retval, IntPtr user_data)
        {
            PowerStateChangeRequestEventArgs args = new PowerStateChangeRequestEventArgs()
            {
                PowerState = (PowerState)state,
                Retval = retval,
            };
            s_powerStateNormalChangeRequestCallback?.Invoke(null, args);
        }

        private static void SleepChangeRequestHandlerCallback(uint state, int retval, IntPtr user_data)
        {
            PowerStateChangeRequestEventArgs args = new PowerStateChangeRequestEventArgs()
            {
                PowerState = (PowerState)state,
                Retval = retval,
            };
            s_powerStateSleepChangeRequestCallback?.Invoke(null, args);
        }

        private static void PoweroffChangeRequestHandlerCallback(uint state, int retval, IntPtr user_data)
        {
            PowerStateChangeRequestEventArgs args = new PowerStateChangeRequestEventArgs()
            {
                PowerState = (PowerState)state,
                Retval = retval,
            };
            s_powerStatePoweroffChangeRequestCallback?.Invoke(null, args);
        }

        private static void RebootChangeRequestHandlerCallback(uint state, int retval, IntPtr user_data)
        {
            PowerStateChangeRequestEventArgs args = new PowerStateChangeRequestEventArgs()
            {
                PowerState = (PowerState)state,
                Retval = retval,
            };
            s_powerStateRebootChangeRequestCallback?.Invoke(null, args);
        }

        private static void ExitChangeRequestHandlerCallback(uint state, int retval, IntPtr user_data)
        {
            PowerStateChangeRequestEventArgs args = new PowerStateChangeRequestEventArgs()
            {
                PowerState = (PowerState)state,
                Retval = retval,
            };
            s_powerStateExitChangeRequestCallback?.Invoke(null, args);
        }

        private static Interop.Device.PowerChangeStateCallback s_powerStateStartChangeRequestHandler = StartChangeRequestHandlerCallback;
        private static Interop.Device.PowerChangeStateCallback s_powerStateNormalChangeRequestHandler = NormalChangeRequestHandlerCallback;
        private static Interop.Device.PowerChangeStateCallback s_powerStateSleepChangeRequestHandler = SleepChangeRequestHandlerCallback;
        private static Interop.Device.PowerChangeStateCallback s_powerStatePoweroffChangeRequestHandler = PoweroffChangeRequestHandlerCallback;
        private static Interop.Device.PowerChangeStateCallback s_powerStateRebootChangeRequestHandler = RebootChangeRequestHandlerCallback;
        private static Interop.Device.PowerChangeStateCallback s_powerStateExitChangeRequestHandler = ExitChangeRequestHandlerCallback;
        private static void PowerStateChangeRequestEventTrigger(PowerState power_state, int timeout_sec)
        {
            DeviceError res = DeviceError.None;
            switch (power_state)
            {
                case PowerState.Start:
                    res = (DeviceError)Interop.Device.DevicePowerChangeState((Interop.Device.PowerState)power_state, timeout_sec, s_powerStateStartChangeRequestHandler, IntPtr.Zero);
                    break;
                case PowerState.Normal:
                    res = (DeviceError)Interop.Device.DevicePowerChangeState((Interop.Device.PowerState)power_state, timeout_sec, s_powerStateNormalChangeRequestHandler, IntPtr.Zero);
                    break;
                case PowerState.Sleep:
                    res = (DeviceError)Interop.Device.DevicePowerChangeState((Interop.Device.PowerState)power_state, timeout_sec, s_powerStateSleepChangeRequestHandler, IntPtr.Zero);
                    break;
                case PowerState.Poweroff:
                    res = (DeviceError)Interop.Device.DevicePowerChangeState((Interop.Device.PowerState)power_state, timeout_sec, s_powerStatePoweroffChangeRequestHandler, IntPtr.Zero);
                    break;
                case PowerState.Reboot:
                    res = (DeviceError)Interop.Device.DevicePowerChangeState((Interop.Device.PowerState)power_state, timeout_sec, s_powerStateRebootChangeRequestHandler, IntPtr.Zero);
                    break;
                case PowerState.Exit:
                    res = (DeviceError)Interop.Device.DevicePowerChangeState((Interop.Device.PowerState)power_state, timeout_sec, s_powerStateExitChangeRequestHandler, IntPtr.Zero);
                    break;
            }

            if (res != DeviceError.None)
            {
                switch (res)
                {
                    case DeviceError.OperationFailed:
                        throw DeviceExceptionFactory.CreateException(res, "Failed to request power change state");
                    default:
                        throw DeviceExceptionFactory.CreateException(res, "Unable to request power change state");
                }
            }
        }

        private static event EventHandler<PowerStateWaitEventArgs> s_powerStateStartWaitCallback;
        /// <summary>
        /// StartStateWaitCallback is triggered when the Power state changes to Start.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <example>
        /// <code>
        /// public static void PowerStateWaitCallback(object sender, PowerStateWaitEventArgs args)
        /// {
        ///     PowerState prev_state = args.PrevState;
        ///     PowerState next_state = args.NextState;
        ///     ulong wait_callback_id = args.WaitCallbackId;
        ///     PowerTransitionReason transition_reason = args.TransitionReason;
        /// }
        /// Power.StartStateWaitCallback += PowerStateWaitCallback;
        /// </code>
        /// </example>
        /// <seealso cref="PowerStateWaitEventArgs"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static event EventHandler<PowerStateWaitEventArgs> StartStateWaitCallback
        {
            add
            {
                lock (s_lock)
                {
                    if (s_powerStateStartWaitCallback == null)
                    {
                        PowerStateChangeEventListenerStart(PowerState.Start);
                    }
                    s_powerStateStartWaitCallback += value;
                }
            }
            remove
            {
                lock (s_lock)
                {
                    s_powerStateStartWaitCallback -= value;
                    if (s_powerStateStartWaitCallback == null)
                    {
                        PowerStateChangeEventListenerStop(PowerState.Start);
                    }
                }
            }
        }
        private static event EventHandler<PowerStateWaitEventArgs> s_powerStateNormalWaitCallback;
        /// <summary>
        /// NormalStateWaitCallback is triggered when the Power state changes to Normal.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <example>
        /// <code>
        /// public static void PowerStateWaitCallback(object sender, PowerStateWaitEventArgs args)
        /// {
        ///     PowerState prev_state = args.PrevState;
        ///     PowerState next_state = args.NextState;
        ///     ulong wait_callback_id = args.WaitCallbackId;
        ///     PowerTransitionReason transition_reason = args.TransitionReason;
        /// }
        /// Power.NormalStateWaitCallback += PowerStateWaitCallback;
        /// </code>
        /// </example>
        /// <seealso cref="PowerStateWaitEventArgs"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static event EventHandler<PowerStateWaitEventArgs> NormalStateWaitCallback
        {
            add
            {
                lock (s_lock)
                {
                    if (s_powerStateNormalWaitCallback == null)
                    {
                        PowerStateChangeEventListenerStart(PowerState.Normal);
                    }
                    s_powerStateNormalWaitCallback += value;
                }
            }
            remove
            {
                lock (s_lock)
                {
                    s_powerStateNormalWaitCallback -= value;
                    if (s_powerStateNormalWaitCallback == null)
                    {
                        PowerStateChangeEventListenerStop(PowerState.Normal);
                    }
                }
            }
        }
        private static event EventHandler<PowerStateWaitEventArgs> s_powerStateSleepWaitCallback;
        /// <summary>
        /// SleepStateWaitCallback is triggered when the Power state changes to Sleep.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <example>
        /// <code>
        /// public static void PowerStateWaitCallback(object sender, PowerStateWaitEventArgs args)
        /// {
        ///     PowerState prev_state = args.PrevState;
        ///     PowerState next_state = args.NextState;
        ///     ulong wait_callback_id = args.WaitCallbackId;
        ///     PowerTransitionReason transition_reason = args.TransitionReason;
        /// }
        /// Power.SleepStateWaitCallback += PowerStateWaitCallback;
        /// </code>
        /// </example>
        /// <seealso cref="PowerStateWaitEventArgs"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static event EventHandler<PowerStateWaitEventArgs> SleepStateWaitCallback
        {
            add
            {
                lock (s_lock)
                {
                    if (s_powerStateSleepWaitCallback == null)
                    {
                        PowerStateChangeEventListenerStart(PowerState.Sleep);
                    }
                    s_powerStateSleepWaitCallback += value;
                }
            }
            remove
            {
                lock (s_lock)
                {
                    s_powerStateSleepWaitCallback -= value;
                    if (s_powerStateSleepWaitCallback == null)
                    {
                        PowerStateChangeEventListenerStop(PowerState.Sleep);
                    }
                }
            }
        }

        private static event EventHandler<PowerStateWaitEventArgs> s_powerStatePoweroffWaitCallback;
        /// <summary>
        /// PoweroffStateWaitCallback is triggered when the Power state changes to Poweroff.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <example>
        /// <code>
        /// public static void PowerStateWaitCallback(object sender, PowerStateWaitEventArgs args)
        /// {
        ///     PowerState prev_state = args.PrevState;
        ///     PowerState next_state = args.NextState;
        ///     ulong wait_callback_id = args.WaitCallbackId;
        ///     PowerTransitionReason transition_reason = args.TransitionReason;
        /// }
        /// Power.PoweroffStateWaitCallback += PowerStateWaitCallback;
        /// </code>
        /// </example>
        /// <seealso cref="PowerStateWaitEventArgs"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static event EventHandler<PowerStateWaitEventArgs> PoweroffStateWaitCallback
        {
            add
            {
                lock (s_lock)
                {
                    if (s_powerStatePoweroffWaitCallback == null)
                    {
                        PowerStateChangeEventListenerStart(PowerState.Poweroff);
                    }
                    s_powerStatePoweroffWaitCallback += value;
                }
            }
            remove
            {
                lock (s_lock)
                {
                    s_powerStatePoweroffWaitCallback -= value;
                    if (s_powerStatePoweroffWaitCallback == null)
                    {
                        PowerStateChangeEventListenerStop(PowerState.Poweroff);
                    }
                }
            }
        }
        private static event EventHandler<PowerStateWaitEventArgs> s_powerStateRebootWaitCallback;
        /// <summary>
        /// RebootStateWaitCallback is triggered when the Power state changes to Reboot.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <example>
        /// <code>
        /// public static void PowerStateWaitCallback(object sender, PowerStateWaitEventArgs args)
        /// {
        ///     PowerState prev_state = args.PrevState;
        ///     PowerState next_state = args.NextState;
        ///     ulong wait_callback_id = args.WaitCallbackId;
        ///     PowerTransitionReason transition_reason = args.TransitionReason;
        /// }
        /// Power.RebootStateWaitCallback += PowerStateWaitCallback;
        /// </code>
        /// </example>
        /// <seealso cref="PowerStateWaitEventArgs"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static event EventHandler<PowerStateWaitEventArgs> RebootStateWaitCallback
        {
            add
            {
                lock (s_lock)
                {
                    if (s_powerStateRebootWaitCallback == null)
                    {
                        PowerStateChangeEventListenerStart(PowerState.Reboot);
                    }
                    s_powerStateRebootWaitCallback += value;
                }
            }
            remove
            {
                lock (s_lock)
                {
                    s_powerStateRebootWaitCallback -= value;
                    if (s_powerStateRebootWaitCallback == null)
                    {
                        PowerStateChangeEventListenerStop(PowerState.Reboot);
                    }
                }
            }
        }
        private static event EventHandler<PowerStateWaitEventArgs> s_powerStateExitWaitCallback;
        /// <summary>
        /// ExitStateWaitCallback is triggered when the Power state changes to Exit.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <example>
        /// <code>
        /// public static void PowerStateWaitCallback(object sender, PowerStateWaitEventArgs args)
        /// {
        ///     PowerState prev_state = args.PrevState;
        ///     PowerState next_state = args.NextState;
        ///     ulong wait_callback_id = args.WaitCallbackId;
        ///     PowerTransitionReason transition_reason = args.TransitionReason;
        /// }
        /// Power.ExitStateWaitCallback += PowerStateWaitCallback;
        /// </code>
        /// </example>
        /// <seealso cref="PowerStateWaitEventArgs"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static event EventHandler<PowerStateWaitEventArgs> ExitStateWaitCallback
        {
            add
            {
                lock (s_lock)
                {
                    if (s_powerStateExitWaitCallback == null)
                    {
                        PowerStateChangeEventListenerStart(PowerState.Exit);
                    }
                    s_powerStateExitWaitCallback += value;
                }
            }
            remove
            {
                lock (s_lock)
                {
                    s_powerStateExitWaitCallback -= value;
                    if (s_powerStateExitWaitCallback == null)
                    {
                        PowerStateChangeEventListenerStop(PowerState.Exit);
                    }
                }
            }
        }

        private static Interop.Device.PowerStateWaitCallback s_powerStateStartHandler;
        private static Interop.Device.PowerStateWaitCallback s_powerStateNormalHandler;
        private static Interop.Device.PowerStateWaitCallback s_powerStateSleepHandler;
        private static Interop.Device.PowerStateWaitCallback s_powerStatePoweroffHandler;
        private static Interop.Device.PowerStateWaitCallback s_powerStateRebootHandler;
        private static Interop.Device.PowerStateWaitCallback s_powerStateExitHandler;

        private static void PowerStateChangeEventListenerStart(PowerState state)
        {
            switch (state)
            {
                case PowerState.Start:
                    s_powerStateStartHandler = (uint prev_state, uint next_state,
                                                    UInt64 wait_callback_id, uint transition_reason, IntPtr user_data) =>
                    {
                        PowerStateWaitEventArgs args = new PowerStateWaitEventArgs()
                        {
                            PrevState = (PowerState)prev_state,
                            NextState = (PowerState)next_state,
                            WaitCallbackId = wait_callback_id,
                            TransitionReason = (PowerTransitionReason)transition_reason
                        };
                        s_powerStateStartWaitCallback?.Invoke(null, args);
                    };
                    Interop.Device.DevicePowerAddStateWaitCallback((Interop.Device.PowerState)state, s_powerStateStartHandler, IntPtr.Zero);
                    break;
                case PowerState.Normal:
                    s_powerStateNormalHandler = (uint prev_state, uint next_state,
                                                    UInt64 wait_callback_id, uint transition_reason, IntPtr user_data) =>
                    {
                        PowerStateWaitEventArgs args = new PowerStateWaitEventArgs()
                        {
                            PrevState = (PowerState)prev_state,
                            NextState = (PowerState)next_state,
                            WaitCallbackId = wait_callback_id,
                            TransitionReason = (PowerTransitionReason)transition_reason
                        };
                        s_powerStateNormalWaitCallback?.Invoke(null, args);
                    };
                    Interop.Device.DevicePowerAddStateWaitCallback((Interop.Device.PowerState)state, s_powerStateNormalHandler, IntPtr.Zero);
                    break;
                case PowerState.Sleep:
                    s_powerStateSleepHandler = (uint prev_state, uint next_state,
                                                    UInt64 wait_callback_id, uint transition_reason, IntPtr user_data) =>
                    {
                        PowerStateWaitEventArgs args = new PowerStateWaitEventArgs()
                        {
                            PrevState = (PowerState)prev_state,
                            NextState = (PowerState)next_state,
                            WaitCallbackId = wait_callback_id,
                            TransitionReason = (PowerTransitionReason)transition_reason
                        };
                        s_powerStateSleepWaitCallback?.Invoke(null, args);
                    };
                    Interop.Device.DevicePowerAddStateWaitCallback((Interop.Device.PowerState)state, s_powerStateSleepHandler, IntPtr.Zero);
                    break;
                case PowerState.Poweroff:
                    s_powerStatePoweroffHandler = (uint prev_state, uint next_state,
                                                    UInt64 wait_callback_id, uint transition_reason, IntPtr user_data) =>
                    {
                        PowerStateWaitEventArgs args = new PowerStateWaitEventArgs()
                        {
                            PrevState = (PowerState)prev_state,
                            NextState = (PowerState)next_state,
                            WaitCallbackId = wait_callback_id,
                            TransitionReason = (PowerTransitionReason)transition_reason
                        };
                        s_powerStatePoweroffWaitCallback?.Invoke(null, args);
                    };
                    Interop.Device.DevicePowerAddStateWaitCallback((Interop.Device.PowerState)state, s_powerStatePoweroffHandler, IntPtr.Zero);
                    break;
                case PowerState.Reboot:
                    s_powerStateRebootHandler = (uint prev_state, uint next_state,
                                                    UInt64 wait_callback_id, uint transition_reason, IntPtr user_data) =>
                    {
                        PowerStateWaitEventArgs args = new PowerStateWaitEventArgs()
                        {
                            PrevState = (PowerState)prev_state,
                            NextState = (PowerState)next_state,
                            WaitCallbackId = wait_callback_id,
                            TransitionReason = (PowerTransitionReason)transition_reason
                        };
                        s_powerStateRebootWaitCallback?.Invoke(null, args);
                    };
                    Interop.Device.DevicePowerAddStateWaitCallback((Interop.Device.PowerState)state, s_powerStateRebootHandler, IntPtr.Zero);
                    break;
                case PowerState.Exit:
                    s_powerStateExitHandler = (uint prev_state, uint next_state,
                                                UInt64 wait_callback_id, uint transition_reason, IntPtr user_data) =>
                    {
                        PowerStateWaitEventArgs args = new PowerStateWaitEventArgs()
                        {
                            PrevState = (PowerState)prev_state,
                            NextState = (PowerState)next_state,
                            WaitCallbackId = wait_callback_id,
                            TransitionReason = (PowerTransitionReason)transition_reason
                        };
                        s_powerStateExitWaitCallback?.Invoke(null, args);
                    };
                    Interop.Device.DevicePowerAddStateWaitCallback((Interop.Device.PowerState)state, s_powerStateExitHandler, IntPtr.Zero);
                    break;
            }
        }

        private static void PowerStateChangeEventListenerStop(PowerState state)
        {
            Interop.Device.DevicePowerRemoveStateWaitCallback((Interop.Device.PowerState)state);

            switch (state)
            {
                case PowerState.Start:
                    s_powerStateStartHandler = null;
                    break;
                case PowerState.Normal:
                    s_powerStateNormalHandler = null;
                    break;
                case PowerState.Sleep:
                    s_powerStateSleepHandler = null;
                    break;
                case PowerState.Poweroff:
                    s_powerStatePoweroffHandler = null;
                    break;
                case PowerState.Reboot:
                    s_powerStateRebootHandler = null;
                    break;
                case PowerState.Exit:
                    s_powerStateExitHandler = null;
                    break;
            }
        }

        private static event EventHandler<PowerTransientStateWaitEventArgs> s_powerTransientStateResumingEarlyWaitCallback;
        /// <summary>
        /// TransientResumingEarlyStateWaitCallback is triggered when the Power transient state changes to ResumingEarly.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <example>
        /// <code>
        /// public static void PowerTransientStateWaitCallback(object sender, PowerTransientStateWaitEventArgs args)
        /// {
        ///     PowerTransientState transient_state = args.TransientState;
        ///     ulong wait_callback_id = args.WaitCallbackId;
        ///     PowerTransitionReason transition_reason = args.TransitionReason;
        /// }
        /// Power.TransientResumingEarlyStateWaitCallback += PowerTransientStateWaitCallback;
        /// </code>
        /// </example>
        /// <seealso cref="PowerTransientStateWaitEventArgs"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static event EventHandler<PowerTransientStateWaitEventArgs> TransientResumingEarlyStateWaitCallback
        {
            add
            {
                lock (s_lock)
                {
                    if (s_powerTransientStateResumingEarlyWaitCallback == null)
                    {
                        PowerTransientStateChangeEventListenerStart(PowerTransientState.ResumingEarly);
                    }
                    s_powerTransientStateResumingEarlyWaitCallback += value;
                }
            }
            remove
            {
                lock (s_lock)
                {
                    s_powerTransientStateResumingEarlyWaitCallback -= value;
                    if (s_powerTransientStateResumingEarlyWaitCallback == null)
                    {
                        PowerTransientStateChangeEventListenerStop(PowerTransientState.ResumingEarly);
                    }
                }
            }
        }
        private static event EventHandler<PowerTransientStateWaitEventArgs> s_powerTransientStateResumingWaitCallback;
        /// <summary>
        /// TransientResumingStateWaitCallback is triggered when the Power transient state changes to Resuming.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <example>
        /// <code>
        /// public static void PowerTransientStateWaitCallback(object sender, PowerTransientStateWaitEventArgs args)
        /// {
        ///     PowerTransientState transient_state = args.TransientState;
        ///     ulong wait_callback_id = args.WaitCallbackId;
        ///     PowerTransitionReason transition_reason = args.TransitionReason;
        /// }
        /// Power.TransientResumingStateWaitCallback += PowerTransientStateWaitCallback;
        /// </code>
        /// </example>
        /// <seealso cref="PowerTransientStateWaitEventArgs"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static event EventHandler<PowerTransientStateWaitEventArgs> TransientResumingStateWaitCallback
        {
            add
            {
                lock (s_lock)
                {
                    if (s_powerTransientStateResumingWaitCallback == null)
                    {
                        PowerTransientStateChangeEventListenerStart(PowerTransientState.Resuming);
                    }
                    s_powerTransientStateResumingWaitCallback += value;
                }
            }
            remove
            {
                lock (s_lock)
                {
                    s_powerTransientStateResumingWaitCallback -= value;
                    if (s_powerTransientStateResumingWaitCallback == null)
                    {
                        PowerTransientStateChangeEventListenerStop(PowerTransientState.Resuming);
                    }
                }
            }
        }
        private static event EventHandler<PowerTransientStateWaitEventArgs> s_powerTransientStateResumingLateWaitCallback;
        /// <summary>
        /// TransientResumingLateStateWaitCallback is triggered when the Power transient state changes to ResumingLate.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <example>
        /// <code>
        /// public static void PowerTransientStateWaitCallback(object sender, PowerTransientStateWaitEventArgs args)
        /// {
        ///     PowerTransientState transient_state = args.TransientState;
        ///     ulong wait_callback_id = args.WaitCallbackId;
        ///     PowerTransitionReason transition_reason = args.TransitionReason;
        /// }
        /// Power.TransientResumingLateStateWaitCallback += PowerTransientStateWaitCallback;
        /// </code>
        /// </example>
        /// <seealso cref="PowerTransientStateWaitEventArgs"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static event EventHandler<PowerTransientStateWaitEventArgs> TransientResumingLateStateWaitCallback
        {
            add
            {
                lock (s_lock)
                {
                    if (s_powerTransientStateResumingLateWaitCallback == null)
                    {
                        PowerTransientStateChangeEventListenerStart(PowerTransientState.ResumingLate);
                    }
                    s_powerTransientStateResumingLateWaitCallback += value;
                }
            }
            remove
            {
                lock (s_lock)
                {
                    s_powerTransientStateResumingLateWaitCallback -= value;
                    if (s_powerTransientStateResumingLateWaitCallback == null)
                    {
                        PowerTransientStateChangeEventListenerStop(PowerTransientState.ResumingLate);
                    }
                }
            }
        }
        private static event EventHandler<PowerTransientStateWaitEventArgs> s_powerTransientStateSuspendingEarlyWaitCallback;
        /// <summary>
        /// TransientSuspendingEarlyStateWaitCallback is triggered when the Power transient state changes to SuspendingEarly.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <example>
        /// <code>
        /// public static void PowerTransientStateWaitCallback(object sender, PowerTransientStateWaitEventArgs args)
        /// {
        ///     PowerTransientState transient_state = args.TransientState;
        ///     ulong wait_callback_id = args.WaitCallbackId;
        ///     PowerTransitionReason transition_reason = args.TransitionReason;
        /// }
        /// Power.TransientSuspendingEarlyStateWaitCallback += PowerTransientStateWaitCallback;
        /// </code>
        /// </example>
        /// <seealso cref="PowerTransientStateWaitEventArgs"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static event EventHandler<PowerTransientStateWaitEventArgs> TransientSuspendingEarlyStateWaitCallback
        {
            add
            {
                lock (s_lock)
                {
                    if (s_powerTransientStateSuspendingEarlyWaitCallback == null)
                    {
                        PowerTransientStateChangeEventListenerStart(PowerTransientState.SuspendingEarly);
                    }
                    s_powerTransientStateSuspendingEarlyWaitCallback += value;
                }
            }
            remove
            {
                lock (s_lock)
                {
                    s_powerTransientStateSuspendingEarlyWaitCallback -= value;
                    if (s_powerTransientStateSuspendingEarlyWaitCallback == null)
                    {
                        PowerTransientStateChangeEventListenerStop(PowerTransientState.SuspendingEarly);
                    }
                }
            }
        }
        private static event EventHandler<PowerTransientStateWaitEventArgs> s_powerTransientStateSuspendingWaitCallback;
        /// <summary>
        /// TransientSuspendingStateWaitCallback is triggered when the Power transient state changes to Suspending.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <example>
        /// <code>
        /// public static void PowerTransientStateWaitCallback(object sender, PowerTransientStateWaitEventArgs args)
        /// {
        ///     PowerTransientState transient_state = args.TransientState;
        ///     ulong wait_callback_id = args.WaitCallbackId;
        ///     PowerTransitionReason transition_reason = args.TransitionReason;
        /// }
        /// Power.TransientSuspendingStateWaitCallback += PowerTransientStateWaitCallback;
        /// </code>
        /// </example>
        /// <seealso cref="PowerTransientStateWaitEventArgs"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static event EventHandler<PowerTransientStateWaitEventArgs> TransientSuspendingStateWaitCallback
        {
            add
            {
                lock (s_lock)
                {
                    if (s_powerTransientStateSuspendingWaitCallback == null)
                    {
                        PowerTransientStateChangeEventListenerStart(PowerTransientState.Suspending);
                    }
                    s_powerTransientStateSuspendingWaitCallback += value;
                }
            }
            remove
            {
                lock (s_lock)
                {
                    s_powerTransientStateSuspendingWaitCallback -= value;
                    if (s_powerTransientStateSuspendingWaitCallback == null)
                    {
                        PowerTransientStateChangeEventListenerStop(PowerTransientState.Suspending);
                    }
                }
            }
        }
        private static event EventHandler<PowerTransientStateWaitEventArgs> s_powerTransientStateSuspendingLateWaitCallback;
        /// <summary>
        /// TransientSuspendingLateStateWaitCallback is triggered when the Power transient state changes to SuspendingLate.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <example>
        /// <code>
        /// public static void PowerTransientStateWaitCallback(object sender, PowerTransientStateWaitEventArgs args)
        /// {
        ///     PowerTransientState transient_state = args.TransientState;
        ///     ulong wait_callback_id = args.WaitCallbackId;
        ///     PowerTransitionReason transition_reason = args.TransitionReason;
        /// }
        /// Power.TransientSuspendingLateStateWaitCallback += PowerTransientStateWaitCallback;
        /// </code>
        /// </example>
        /// <seealso cref="PowerTransientStateWaitEventArgs"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static event EventHandler<PowerTransientStateWaitEventArgs> TransientSuspendingLateStateWaitCallback
        {
            add
            {
                lock (s_lock)
                {
                    if (s_powerTransientStateSuspendingLateWaitCallback == null)
                    {
                        PowerTransientStateChangeEventListenerStart(PowerTransientState.SuspendingLate);
                    }
                    s_powerTransientStateSuspendingLateWaitCallback += value;
                }
            }
            remove
            {
                lock (s_lock)
                {
                    s_powerTransientStateSuspendingLateWaitCallback -= value;
                    if (s_powerTransientStateSuspendingLateWaitCallback == null)
                    {
                        PowerTransientStateChangeEventListenerStop(PowerTransientState.SuspendingLate);
                    }
                }
            }
        }

        private static Interop.Device.PowerTransientStateWaitCallback s_powerTransientStateResumingEarlyHandler;
        private static Interop.Device.PowerTransientStateWaitCallback s_powerTransientStateResumingHandler;
        private static Interop.Device.PowerTransientStateWaitCallback s_powerTransientStateResumingLateHandler;
        private static Interop.Device.PowerTransientStateWaitCallback s_powerTransientStateSuspendingEarlyHandler;
        private static Interop.Device.PowerTransientStateWaitCallback s_powerTransientStateSuspendingHandler;
        private static Interop.Device.PowerTransientStateWaitCallback s_powerTransientStateSuspendingLateHandler;

        private static void PowerTransientStateChangeEventListenerStart(PowerTransientState transient_bits)
        {
            switch (transient_bits)
            {
                case PowerTransientState.ResumingEarly:
                    s_powerTransientStateResumingEarlyHandler = (uint transient_state, UInt64 wait_callback_id,
                                                                    uint transition_reason, IntPtr user_data) =>
                    {
                        PowerTransientStateWaitEventArgs args = new PowerTransientStateWaitEventArgs()
                        {
                            TransientState = (PowerTransientState)transient_state,
                            WaitCallbackId = wait_callback_id,
                            TransitionReason = (PowerTransitionReason)transition_reason
                        };
                        s_powerTransientStateResumingEarlyWaitCallback?.Invoke(null, args);
                    };
                    Interop.Device.DevicePowerAddTransientStateWaitCallback((Interop.Device.PowerTransientState)transient_bits, s_powerTransientStateResumingEarlyHandler, IntPtr.Zero);
                    break;
                case PowerTransientState.Resuming:
                    s_powerTransientStateResumingHandler = (uint transient_state, UInt64 wait_callback_id,
                                                                uint transition_reason, IntPtr user_data) =>
                    {
                        PowerTransientStateWaitEventArgs args = new PowerTransientStateWaitEventArgs()
                        {
                            TransientState = (PowerTransientState)transient_state,
                            WaitCallbackId = wait_callback_id,
                            TransitionReason = (PowerTransitionReason)transition_reason
                        };
                        s_powerTransientStateResumingWaitCallback?.Invoke(null, args);
                    };
                    Interop.Device.DevicePowerAddTransientStateWaitCallback((Interop.Device.PowerTransientState)transient_bits, s_powerTransientStateResumingHandler, IntPtr.Zero);
                    break;
                case PowerTransientState.ResumingLate:
                    s_powerTransientStateResumingLateHandler = (uint transient_state, UInt64 wait_callback_id,
                                                                    uint transition_reason, IntPtr user_data) =>
                    {
                        PowerTransientStateWaitEventArgs args = new PowerTransientStateWaitEventArgs()
                        {
                            TransientState = (PowerTransientState)transient_state,
                            WaitCallbackId = wait_callback_id,
                            TransitionReason = (PowerTransitionReason)transition_reason
                        };
                        s_powerTransientStateResumingLateWaitCallback?.Invoke(null, args);
                    };
                    Interop.Device.DevicePowerAddTransientStateWaitCallback((Interop.Device.PowerTransientState)transient_bits, s_powerTransientStateResumingLateHandler, IntPtr.Zero);
                    break;
                case PowerTransientState.SuspendingEarly:
                    s_powerTransientStateSuspendingEarlyHandler = (uint transient_state, UInt64 wait_callback_id,
                                                                    uint transition_reason, IntPtr user_data) =>
                    {
                        PowerTransientStateWaitEventArgs args = new PowerTransientStateWaitEventArgs()
                        {
                            TransientState = (PowerTransientState)transient_state,
                            WaitCallbackId = wait_callback_id,
                            TransitionReason = (PowerTransitionReason)transition_reason
                        };
                        s_powerTransientStateSuspendingEarlyWaitCallback?.Invoke(null, args);
                    };
                    Interop.Device.DevicePowerAddTransientStateWaitCallback((Interop.Device.PowerTransientState)transient_bits, s_powerTransientStateSuspendingEarlyHandler, IntPtr.Zero);
                    break;
                case PowerTransientState.Suspending:
                    s_powerTransientStateSuspendingHandler = (uint transient_state, UInt64 wait_callback_id,
                                                                    uint transition_reason, IntPtr user_data) =>
                    {
                        PowerTransientStateWaitEventArgs args = new PowerTransientStateWaitEventArgs()
                        {
                            TransientState = (PowerTransientState)transient_state,
                            WaitCallbackId = wait_callback_id,
                            TransitionReason = (PowerTransitionReason)transition_reason
                        };
                        s_powerTransientStateSuspendingWaitCallback?.Invoke(null, args);
                    };
                    Interop.Device.DevicePowerAddTransientStateWaitCallback((Interop.Device.PowerTransientState)transient_bits, s_powerTransientStateSuspendingHandler, IntPtr.Zero);
                    break;
                case PowerTransientState.SuspendingLate:
                    s_powerTransientStateSuspendingLateHandler = (uint transient_state, UInt64 wait_callback_id,
                                                                    uint transition_reason, IntPtr user_data) =>
                    {
                        PowerTransientStateWaitEventArgs args = new PowerTransientStateWaitEventArgs()
                        {
                            TransientState = (PowerTransientState)transient_state,
                            WaitCallbackId = wait_callback_id,
                            TransitionReason = (PowerTransitionReason)transition_reason
                        };
                        s_powerTransientStateSuspendingLateWaitCallback?.Invoke(null, args);
                    };
                    Interop.Device.DevicePowerAddTransientStateWaitCallback((Interop.Device.PowerTransientState)transient_bits, s_powerTransientStateSuspendingLateHandler, IntPtr.Zero);
                    break;
            }
        }

        private static void PowerTransientStateChangeEventListenerStop(PowerTransientState transient_bits)
        {
            Interop.Device.DevicePowerRemoveTransientStateWaitCallback((Interop.Device.PowerTransientState)transient_bits);

            switch (transient_bits)
            {
                case PowerTransientState.ResumingEarly:
                    s_powerTransientStateResumingEarlyHandler = null;
                    break;
                case PowerTransientState.Resuming:
                    s_powerTransientStateResumingHandler = null;
                    break;
                case PowerTransientState.ResumingLate:
                    s_powerTransientStateResumingLateHandler = null;
                    break;
                case PowerTransientState.SuspendingEarly:
                    s_powerTransientStateSuspendingEarlyHandler = null;
                    break;
                case PowerTransientState.Suspending:
                    s_powerTransientStateSuspendingHandler = null;
                    break;
                case PowerTransientState.SuspendingLate:
                    s_powerTransientStateSuspendingLateHandler = null;
                    break;
            }
        }

        private static event EventHandler<PowerLockStateChangedEventArgs> s_powerLockCpuStateChanged;
        /// <summary>
        /// CpuLockStateChangedCallback is triggered when the PowerLock.Cpu status is changed to Lock or Unlock
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <example>
        /// <code>
        /// public static void PowerLockStateChangeCallback(object sender, PowerLockStateChangedEventArgs args)
        /// {
        ///     PowerLock lock_type = args.PowerLockType;
        ///     PowerLockState lock_state = args.PowerLockState;
        /// }
        /// Power.CpuLockStateChangedCallback += PowerLockStateChangeCallback;
        /// </code>
        /// </example>
        /// <seealso cref="PowerLockStateChangedEventArgs"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static event EventHandler<PowerLockStateChangedEventArgs> CpuLockStateChangedCallback
        {
            add
            {
                lock (s_lock)
                {
                    if (s_powerLockCpuStateChanged == null)
                    {
                        PowerLockStateChangeEventListenerStart(PowerLock.Cpu);
                    }
                    s_powerLockCpuStateChanged += value;
                }
            }
            remove
            {
                lock (s_lock)
                {
                    s_powerLockCpuStateChanged -= value;
                    if (s_powerLockCpuStateChanged == null)
                    {
                        PowerLockStateChangeEventListenerStop(PowerLock.Cpu);
                    }
                }
            }
        }
        private static event EventHandler<PowerLockStateChangedEventArgs> s_powerLockDisplayNormalStateChanged;
        /// <summary>
        /// DisplayNormalLockStateChangedCallback is triggered when the PowerLock.DisplayNormal status is changed to Lock or Unlock
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <example>
        /// <code>
        /// public static void PowerLockStateChangeCallback(object sender, PowerLockStateChangedEventArgs args)
        /// {
        ///     PowerLock lock_type = args.PowerLockType;
        ///     PowerLockState lock_state = args.PowerLockState;
        /// }
        /// Power.DisplayNormalLockStateChangedCallback += PowerLockStateChangeCallback;
        /// </code>
        /// </example>
        /// <seealso cref="PowerLockStateChangedEventArgs"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static event EventHandler<PowerLockStateChangedEventArgs> DisplayNormalLockStateChangedCallback
        {
            add
            {
                lock (s_lock)
                {
                    if (s_powerLockDisplayNormalStateChanged == null)
                    {
                        PowerLockStateChangeEventListenerStart(PowerLock.DisplayNormal);
                    }
                    s_powerLockDisplayNormalStateChanged += value;
                }
            }
            remove
            {
                lock (s_lock)
                {
                    s_powerLockDisplayNormalStateChanged -= value;
                    if (s_powerLockDisplayNormalStateChanged == null)
                    {
                        PowerLockStateChangeEventListenerStop(PowerLock.DisplayNormal);
                    }
                }
            }
        }
        private static event EventHandler<PowerLockStateChangedEventArgs> s_powerLockDisplayDimStateChanged;
        /// <summary>
        /// DisplayDimLockStateChangedCallback is triggered when the PowerLock.DisplayDim status is changed to Lock or Unlock
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        /// <example>
        /// <code>
        /// public static void PowerLockStateChangeCallback(object sender, PowerLockStateChangedEventArgs args)
        /// {
        ///     PowerLock lock_type = args.PowerLockType;
        ///     PowerLockState lock_state = args.PowerLockState;
        /// }
        /// Power.DisplayDimLockStateChangedCallback += PowerLockStateChangeCallback;
        /// </code>
        /// </example>
        /// <seealso cref="PowerLockStateChangedEventArgs"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static event EventHandler<PowerLockStateChangedEventArgs> DisplayDimLockStateChangedCallback
        {
            add
            {
                lock (s_lock)
                {
                    if (s_powerLockDisplayDimStateChanged == null)
                    {
                        PowerLockStateChangeEventListenerStart(PowerLock.DisplayDim);
                    }
                    s_powerLockDisplayDimStateChanged += value;
                }
            }
            remove
            {
                lock (s_lock)
                {
                    s_powerLockDisplayDimStateChanged -= value;
                    if (s_powerLockDisplayDimStateChanged == null)
                    {
                        PowerLockStateChangeEventListenerStop(PowerLock.DisplayDim);
                    }
                }
            }
        }

        private static Interop.Device.PowerLockStateChangeCallback s_powerLockCpuStateHandler;
        private static Interop.Device.PowerLockStateChangeCallback s_powerLockDisplayNormalStateHandler;
        private static Interop.Device.PowerLockStateChangeCallback s_powerLockDisplayDimStateHandler;

        private static void PowerLockStateChangeEventListenerStart(PowerLock type)
        {
            switch (type)
            {
                case PowerLock.Cpu:
                    s_powerLockCpuStateHandler = (uint lock_type, uint lock_state, IntPtr user_data) =>
                    {
                        PowerLockStateChangedEventArgs args = new PowerLockStateChangedEventArgs()
                        {
                            PowerLockType = (PowerLock)lock_type,
                            PowerLockState = (PowerLockState)lock_state
                        };
                        s_powerLockCpuStateChanged?.Invoke(null, args);
                    };
                    Interop.Device.DevicePowerAddLockStateChangeCallback((Interop.Device.PowerLock)type, s_powerLockCpuStateHandler, IntPtr.Zero);
                    break;
                case PowerLock.DisplayNormal:
                    s_powerLockDisplayNormalStateHandler = (uint lock_type, uint lock_state, IntPtr user_data) =>
                    {
                        PowerLockStateChangedEventArgs args = new PowerLockStateChangedEventArgs()
                        {
                            PowerLockType = (PowerLock)lock_type,
                            PowerLockState = (PowerLockState)lock_state
                        };
                        s_powerLockDisplayNormalStateChanged?.Invoke(null, args);
                    };
                    Interop.Device.DevicePowerAddLockStateChangeCallback((Interop.Device.PowerLock)type, s_powerLockDisplayNormalStateHandler, IntPtr.Zero);
                    break;
                case PowerLock.DisplayDim:
                    s_powerLockDisplayDimStateHandler = (uint lock_type, uint lock_state, IntPtr user_data) =>
                    {
                        PowerLockStateChangedEventArgs args = new PowerLockStateChangedEventArgs()
                        {
                            PowerLockType = (PowerLock)lock_type,
                            PowerLockState = (PowerLockState)lock_state
                        };
                        s_powerLockDisplayDimStateChanged?.Invoke(null, args);
                    };
                    Interop.Device.DevicePowerAddLockStateChangeCallback((Interop.Device.PowerLock)type, s_powerLockDisplayDimStateHandler, IntPtr.Zero);
                    break;
            }
        }
        private static void PowerLockStateChangeEventListenerStop(PowerLock type)
        {
            switch (type)
            {
                case PowerLock.Cpu:
                    Interop.Device.DevicePowerRemoveLockStateChangeCallback((Interop.Device.PowerLock)type, s_powerLockCpuStateHandler);
                    s_powerLockCpuStateHandler = null;
                    break;
                case PowerLock.DisplayNormal:
                    Interop.Device.DevicePowerRemoveLockStateChangeCallback((Interop.Device.PowerLock)type, s_powerLockDisplayNormalStateHandler);
                    s_powerLockDisplayNormalStateHandler = null;
                    break;
                case PowerLock.DisplayDim:
                    Interop.Device.DevicePowerRemoveLockStateChangeCallback((Interop.Device.PowerLock)type, s_powerLockDisplayDimStateHandler);
                    s_powerLockDisplayDimStateHandler = null;
                    break;
            }
        }
    }
}
