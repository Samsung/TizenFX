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
using System.Runtime.InteropServices;

namespace Tizen.System
{
    internal enum EventType
    {
        BatteryPercent,
        BatteryLevel,
        BatteryCharging,
        DisplayState,
        FlashBrightness
    }
}
internal static partial class Interop
{
    internal static partial class Device
    {
        // Any changes here might require changes in Tizen.System.DisplayState enum
        internal enum DisplayState
        {
            Normal = 0,
            ScreenDim = 1,
            ScreenOff = 2,
        }

        // Any changes here might require changes in Tizen.System.PowerLock enum
        internal enum PowerLock
        {
            Cpu = 0,
            DisplayNormal = 1,
            DisplayDim = 2,
        }

        internal enum PowerTransitionReason
        {
            Unknown = 0, // Unknown reason.
            ReasonPowerKey = 1, // Power key pressed.
            ReasonVolumeUpKey = 2, // Volume up key pressed.
            ReasonVolumeDownKey = 3, // Volume down key pressed.
            ReasonBatteryNormalLevel = 4, // Battery capacity reaches normal level.
            ReasonBatteryWarningLevel = 5, // Battery capacity reaches warning level.
            ReasonBatteryCriticalLevel = 6, // Battery capacity reaches critical level.
            ReasonBatteryPoweroffLevel = 7, // Battery capacity reaches poweroff level.
            ReasonDisplayOff = 8, // Display off.
            ReasonTouchKey = 9, // Touch key pressed.
            ReasonTouchScreen = 10, // Touch screen pressed.
            ReasonUsb = 11, // USB attached or detached.
            ReasonCharger = 12, // Charger attached or detached.
            ReasonHdmi = 13, // HDMI cable attached or detached.
            ReasonDisplayPort = 14, // Display port cable attached or detached.
            ReasonEmbeddedDisplayPort = 15, // Embedded display port cable attached or detached.
            ReasonWifi = 16, // WIFI event.
            ReasonBluetooth = 17, // Bluetooth event.
            ReasonNfc = 18, // NFC event.
            ReasonTelephony = 19, // Telephony event.
            ReasonZigbee = 20, // Zigbee event.
            ReasonEthernet = 21, // Ethernet event.
            ReasonAudio = 22, // Audio event.
            ReasonAlarm = 23, // Alarm event.
            ReasonSensor = 24, // Sensor event.
            ReasonRtc = 25, // RTC event.
            ReasonHeadset = 26, // Headset attached or detached or button pressed.
            ReasonExternalMemory = 27, // External memory inserted or deleted.

            ReasonCustom = 1000, // Define custom reason from here.
        }

        internal enum PowerState : uint
        {
            Start = 1 << 4, // Initial state of power module. It is especially meaningful in that
                            // this can be used to identify the first transition and implement booting UX.
            Normal = 1 << 5, // System keeps running.
            Sleep = 1 << 6, // System may be suspended at any time.
            Poweroff = 1 << 7, // Prepare for poweroff and perform `systemctl poweroff`.
            Reboot = 1 << 8, // Prepare for reboot and perform `systemctl reboot`.
            Exit = 1 << 9, // Prepare for exit and perform `systemctl exit`.
        }

        internal enum PowerTransientState : uint
        {
            ResumingEarly = 1 << 4, // The first step of transitioning from sleep to normal.
            Resuming = 1 << 5, // The second step of transitioning from sleep to normal.
            ResumingLate = 1 << 6, // The last step of transitioning from sleep to normal.
            SuspendingEarly = 1 << 7, // The first step of transitioning from normal to sleep.
            Suspending = 1 << 8, // The second step of transitioning from normal to sleep.
            SuspendingLate = 1 << 9, // The last step of transitioning from normal to sleep.
        }

        internal enum PowerLockState
        {
            Unlock = 0, // Power lock is unlocked.
            Lock = 1, // Power lock is locked.
        }

   
        // Battery
        [DllImport(Libraries.Device, EntryPoint = "device_battery_get_percent", CallingConvention = CallingConvention.Cdecl)]
        public static extern int DeviceBatteryGetPercent(out int percent);
        [DllImport(Libraries.Device, EntryPoint = "device_battery_is_charging", CallingConvention = CallingConvention.Cdecl)]
        public static extern int DeviceBatteryIsCharging(out bool charging);
        [DllImport(Libraries.Device, EntryPoint = "device_battery_get_level_status", CallingConvention = CallingConvention.Cdecl)]
        public static extern int DeviceBatteryGetLevelStatus(out int status);
        [DllImport(Libraries.Device, EntryPoint = "device_battery_get_power_source", CallingConvention = CallingConvention.Cdecl)]
        public static extern int DeviceBatteryGetPowerSource(out int power_source_type);

        // Display
        [DllImport(Libraries.Device, EntryPoint = "device_display_get_numbers", CallingConvention = CallingConvention.Cdecl)]
        public static extern int DeviceDisplayGetNumbers(out int device_number);
        [DllImport(Libraries.Device, EntryPoint = "device_display_get_max_brightness", CallingConvention = CallingConvention.Cdecl)]
        public static extern int DeviceDisplayGetMaxBrightness(int index, out int max_brightness);
        [DllImport(Libraries.Device, EntryPoint = "device_display_get_brightness", CallingConvention = CallingConvention.Cdecl)]
        public static extern int DeviceDisplayGetBrightness(int index, out int status);
        [DllImport(Libraries.Device, EntryPoint = "device_display_set_brightness", CallingConvention = CallingConvention.Cdecl)]
        public static extern int DeviceDisplaySetBrightness(int index, int brightness);
        [DllImport(Libraries.Device, EntryPoint = "device_display_get_state", CallingConvention = CallingConvention.Cdecl)]
        public static extern int DeviceDisplayGetState(out DisplayState state);
        [DllImport(Libraries.Device, EntryPoint = "device_display_change_state", CallingConvention = CallingConvention.Cdecl)]
        public static extern int DeviceDisplayChangeState(DisplayState state);

        // Haptic
        [DllImport(Libraries.Device, EntryPoint = "device_haptic_get_count", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DeviceHapticGetCount(out int device_number);
        [DllImport(Libraries.Device, EntryPoint = "device_haptic_open", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DeviceHapticOpen(int index, out IntPtr handle);
        [DllImport(Libraries.Device, EntryPoint = "device_haptic_close", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DeviceHapticClose(IntPtr handle);
        [DllImport(Libraries.Device, EntryPoint = "device_haptic_vibrate", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DeviceHapticVibrate(IntPtr handle, int duration, int feedback, out IntPtr effect);
        [DllImport(Libraries.Device, EntryPoint = "device_haptic_stop", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DeviceHapticStop(IntPtr handle, IntPtr effect);

        // Led
        [DllImport(Libraries.Device, EntryPoint = "device_flash_get_max_brightness", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DeviceFlashGetMaxBrightness(out int max_brightness);
        [DllImport(Libraries.Device, EntryPoint = "device_flash_get_brightness", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DeviceFlashGetBrightness(out int brightness);
        [DllImport(Libraries.Device, EntryPoint = "device_flash_set_brightness", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DeviceFlashSetBrightness(int brightness);
        [DllImport(Libraries.Device, EntryPoint = "device_led_play_custom", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DeviceLedPlayCustom(int on, int off, uint color, uint flags);
        [DllImport(Libraries.Device, EntryPoint = "device_led_stop_custom", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DeviceLedStopCustom();

        // Power
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void PowerStateWaitCallback(uint prev_state, uint next_state,
                                                        UInt64 wait_callback_id, uint transition_reason, IntPtr user_data);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void PowerTransientStateWaitCallback(uint transient_state, UInt64 wait_callback_id,
                                                                uint transition_reason, IntPtr user_data);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void PowerChangeStateCallback(uint state, int retval, IntPtr user_data);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void PowerLockStateChangeCallback(uint lock_type, uint lock_state, IntPtr user_data);
        [DllImport(Libraries.Device, EntryPoint = "device_power_request_lock", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DevicePowerRequestLock(PowerLock type, int timeout_ms);
        [DllImport(Libraries.Device, EntryPoint = "device_power_release_lock", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DevicePowerReleaseLock(PowerLock type);
        [DllImport(Libraries.Device, EntryPoint = "device_power_poweroff", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DevicePowerPowerOff();
        [DllImport(Libraries.Device, EntryPoint = "device_power_reboot", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DevicePowerReboot(string reason);
        [DllImport(Libraries.Device, EntryPoint = "device_power_confirm_wait_callback", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DevicePowerConfirmWaitCallback(UInt64 wait_callback_id);
        [DllImport(Libraries.Device, EntryPoint = "device_power_cancel_wait_callback", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DevicePowerCancelWaitCallback(UInt64 wait_callback_id);
        [DllImport(Libraries.Device, EntryPoint = "device_power_add_state_wait_callback", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DevicePowerAddStateWaitCallback(PowerState state_bits, PowerStateWaitCallback cb, IntPtr user_data);
        [DllImport(Libraries.Device, EntryPoint = "device_power_remove_state_wait_callback", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DevicePowerRemoveStateWaitCallback(PowerState state_bits);
        [DllImport(Libraries.Device, EntryPoint = "device_power_add_transient_state_wait_callback", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DevicePowerAddTransientStateWaitCallback(PowerTransientState transient_bits, PowerTransientStateWaitCallback cb, IntPtr user_data);
        [DllImport(Libraries.Device, EntryPoint = "device_power_remove_transient_state_wait_callback", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DevicePowerRemoveTransientStateWaitCallback(PowerTransientState transient_bits);
        [DllImport(Libraries.Device, EntryPoint = "device_power_change_state", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DevicePowerChangeState(PowerState state, int timeout_sec, PowerChangeStateCallback cb, IntPtr user_data);
        [DllImport(Libraries.Device, EntryPoint = "device_power_check_reboot_allowed", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DevicePowerCheckRebootAllowed();
        [DllImport(Libraries.Device, EntryPoint = "device_power_get_wakeup_reason", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DevicePowerGetWakeupReason(out PowerTransitionReason reason);
        [DllImport(Libraries.Device, EntryPoint = "device_power_get_lock_state", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DevicePowerGetLockState(PowerLock type, out PowerLockState lock_state);
        [DllImport(Libraries.Device, EntryPoint = "device_power_add_lock_state_change_callback", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DevicePowerAddLockStateChangeCallback(PowerLock type, PowerLockStateChangeCallback cb, IntPtr user_data);
        [DllImport(Libraries.Device, EntryPoint = "device_power_remove_lock_state_change_callback", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DevicePowerRemoveLockStateChangeCallback(PowerLock type, PowerLockStateChangeCallback cb);

        //IR
        [DllImport(Libraries.Device, EntryPoint = "device_ir_is_available", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DeviceIRIsAvailable(out bool available);
        [DllImport(Libraries.Device, EntryPoint = "device_ir_transmit", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DeviceIRTransmit(int carrierFreequency, int[] pattern, int size);

        // Callback
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool deviceCallback(int type, IntPtr value, IntPtr data);
        [DllImport(Libraries.Device, EntryPoint = "device_add_callback", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DeviceAddCallback(Tizen.System.EventType type, deviceCallback cb, IntPtr data);
        [DllImport(Libraries.Device, EntryPoint = "device_remove_callback", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DeviceRemoveCallback(Tizen.System.EventType type, deviceCallback cb);

        //PmQos
        [DllImport(Libraries.Device, EntryPoint = "device_pmqos_app_launch_home", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DevicePmQosAppLaunchHome(int timeout);
        [DllImport(Libraries.Device, EntryPoint = "device_pmqos_homescreen", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DevicePmQosHomeScreen(int timeout);
    }
}
