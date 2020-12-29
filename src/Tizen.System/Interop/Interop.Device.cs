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
   
        // Battery
        [DllImport(Libraries.Device, EntryPoint = "device_battery_get_percent", CallingConvention = CallingConvention.Cdecl)]
        public static extern int DeviceBatteryGetPercent(out int percent);
        [DllImport(Libraries.Device, EntryPoint = "device_battery_is_charging", CallingConvention = CallingConvention.Cdecl)]
        public static extern int DeviceBatteryIsCharging(out bool charging);
        [DllImport(Libraries.Device, EntryPoint = "device_battery_get_level_status", CallingConvention = CallingConvention.Cdecl)]
        public static extern int DeviceBatteryGetLevelStatus(out int status);

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
        [DllImport(Libraries.Device, EntryPoint = "device_power_request_lock", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DevicePowerRequestLock(PowerLock type, int timeout_ms);
        [DllImport(Libraries.Device, EntryPoint = "device_power_release_lock", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DevicePowerReleaseLock(PowerLock type);
        [DllImport(Libraries.Device, EntryPoint = "device_power_poweroff", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DevicePowerPowerOff();
        [DllImport(Libraries.Device, EntryPoint = "device_power_reboot", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DevicePowerReboot(string reason);

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
