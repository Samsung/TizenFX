/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.


using System;
using System.Runtime.InteropServices;

namespace Tizen.System
{
    internal enum EventType
    {
        BatteryCapacity,
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
        // Battery
        [DllImport("libcapi-system-device.so.0", EntryPoint = "device_battery_get_percent", CallingConvention = CallingConvention.Cdecl)]
        public static extern int DeviceBatteryGetPercent(out int percent);
        [DllImport("libcapi-system-device.so.0", EntryPoint = "device_battery_is_charging", CallingConvention = CallingConvention.Cdecl)]
        public static extern int DeviceBatteryIsCharging(out bool charging);
        [DllImport("libcapi-system-device.so.0", EntryPoint = "device_battery_get_level_status", CallingConvention = CallingConvention.Cdecl)]
        public static extern int DeviceBatteryGetLevelStatus(out int status);

        // Display
        [DllImport("libcapi-system-device.so.0", EntryPoint = "device_display_get_numbers", CallingConvention = CallingConvention.Cdecl)]
        public static extern int DeviceDisplayGetNumbers(out int device_number);
        [DllImport("libcapi-system-device.so.0", EntryPoint = "device_display_get_max_brightness", CallingConvention = CallingConvention.Cdecl)]
        public static extern int DeviceDisplayGetMaxBrightness(int index, out int max_brightness);
        [DllImport("libcapi-system-device.so.0", EntryPoint = "device_display_get_brightness", CallingConvention = CallingConvention.Cdecl)]
        public static extern int DeviceDisplayGetBrightness(int index, out int status);
        [DllImport("libcapi-system-device.so.0", EntryPoint = "device_display_set_brightness", CallingConvention = CallingConvention.Cdecl)]
        public static extern int DeviceDisplaySetBrightness(int index, int brightness);
        [DllImport("libcapi-system-device.so.0", EntryPoint = "device_display_get_state", CallingConvention = CallingConvention.Cdecl)]
        public static extern int DeviceDisplayGetState(out int state);
        [DllImport("libcapi-system-device.so.0", EntryPoint = "device_display_change_state", CallingConvention = CallingConvention.Cdecl)]
        public static extern int DeviceDisplayChangeState(int state);

        // Haptic
        [DllImport("libcapi-system-device.so.0", EntryPoint = "device_haptic_get_count", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DeviceHapticGetCount(out int device_number);
        [DllImport("libcapi-system-device.so.0", EntryPoint = "device_haptic_open", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DeviceHapticOpen(int index, out IntPtr handle);
        [DllImport("libcapi-system-device.so.0", EntryPoint = "device_haptic_close", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DeviceHapticClose(IntPtr handle);
        [DllImport("libcapi-system-device.so.0", EntryPoint = "device_haptic_vibrate", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DeviceHapticVibrate(IntPtr handle, int duration, int feedback, out IntPtr effect);
        [DllImport("libcapi-system-device.so.0", EntryPoint = "device_haptic_stop", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DeviceHapticStop(IntPtr handle, IntPtr effect);

        // Led
        [DllImport("libcapi-system-device.so.0", EntryPoint = "device_flash_get_max_brightness", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DeviceFlashGetMaxBrightness(out int max_brightness);
        [DllImport("libcapi-system-device.so.0", EntryPoint = "device_flash_get_brightness", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DeviceFlashGetBrightness(out int brightness);
        [DllImport("libcapi-system-device.so.0", EntryPoint = "device_flash_set_brightness", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DeviceFlashSetBrightness(int brightness);
        [DllImport("libcapi-system-device.so.0", EntryPoint = "device_led_play_custom", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DeviceLedPlayCustom(int on, int off, uint color, uint flags);
        [DllImport("libcapi-system-device.so.0", EntryPoint = "device_led_stop_custom", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DeviceLedStopCustom();

        // Power
        [DllImport("libcapi-system-device.so.0", EntryPoint = "device_power_request_lock", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DevicePowerRequestLock(int type, int timeout_ms);
        [DllImport("libcapi-system-device.so.0", EntryPoint = "device_power_release_lock", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DevicePowerReleaseLock(int type);

        //IR
        [DllImport("libcapi-system-device.so.0", EntryPoint = "device_ir_is_available", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DeviceIRIsAvailable(out bool available);
        [DllImport("libcapi-system-device.so.0", EntryPoint = "device_ir_transmit", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DeviceIRTransmit(int carrierFreequency, int[] pattern, int size);

        // Callback
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool deviceCallback(int type, IntPtr value, IntPtr data);
        [DllImport("libcapi-system-device.so.0", EntryPoint = "device_add_callback", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DeviceAddCallback(Tizen.System.EventType type, deviceCallback cb, IntPtr data);
        [DllImport("libcapi-system-device.so.0", EntryPoint = "device_remove_callback", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DeviceRemoveCallback(Tizen.System.EventType type, deviceCallback cb);
    }
}
