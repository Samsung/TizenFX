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

internal static partial class Interop
{
    [DllImport(Libraries.Usb, EntryPoint = "usb_host_set_config")]
    internal static extern ErrorCode SetAsActive(this UsbConfigHandle /* usb_host_config_h */ configuration);

    [DllImport(Libraries.Usb, EntryPoint = "usb_host_config_get_num_interfaces")]
    internal static extern ErrorCode GetNumInterfaces(this UsbConfigHandle /* usb_host_config_h */ config, out int numInterfaces);

    [DllImport(Libraries.Usb, EntryPoint = "usb_host_config_is_self_powered")]
    internal static extern ErrorCode IsSelfPowered(this UsbConfigHandle /* usb_host_config_h */ config, out bool selfPowered);

    [DllImport(Libraries.Usb, EntryPoint = "usb_host_config_support_remote_wakeup")]
    internal static extern ErrorCode SupportRemoteWakeup(this UsbConfigHandle /* usb_host_config_h */ config, out bool remoteWakeup);

    [DllImport(Libraries.Usb, EntryPoint = "usb_host_config_get_max_power")]
    internal static extern ErrorCode GetMaxPower(this UsbConfigHandle /* usb_host_config_h */ config, out int maxPower);

    [DllImport(Libraries.Usb, EntryPoint = "usb_host_device_get_config_str")]
    internal static extern ErrorCode GetConfigStr(this UsbConfigHandle /* usb_host_config_h */ config, ref int length, byte[] data);

    [DllImport(Libraries.Usb, EntryPoint = "usb_host_config_get_interface")]
    internal static extern ErrorCode GetInterface(this UsbConfigHandle /* usb_host_config_h */ config, int interfaceIndex, out UsbInterfaceHandle /* usb_host_interface_h */ usbInterface);

    internal class UsbConfigHandle : SafeUsbHandle
    {
        [DllImport(Libraries.Usb, EntryPoint = "usb_host_config_destroy")]
        internal static extern ErrorCode ConfigDestroy(IntPtr /* usb_host_config_h */ config);

        public UsbConfigHandle(IntPtr handle) : base(handle) { }
        public override void Destroy()
        {
            ConfigDestroy(handle).ThrowIfFailed("Failed to destroy native HostConfig handle");
        }
    }
}