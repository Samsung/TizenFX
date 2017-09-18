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
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal enum HotplugEventType
    {
        Attach, // USB_HOST_HOTPLUG_EVENT_ATTACH
        Detach, // USB_HOST_HOTPLUG_EVENT_DETACH
        Any, // USB_HOST_HOTPLUG_EVENT_ANY
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void HostHotplugCallback(IntPtr /* usb_host_device_h */ dev, IntPtr /* void */ userData);

    [DllImport(Libraries.Usb, EntryPoint = "usb_host_set_hotplug_cb")]
    internal static extern ErrorCode SetHotplugCb(this UsbContextHandle /* usb_host_context_h */ ctx, HostHotplugCallback cb, HotplugEventType /* usb_host_hotplug_event_e */ hostEvent, IntPtr /* void */ userData, out HostHotplugHandle /* usb_host_hotplug_h */ handle);

    [DllImport(Libraries.Usb, EntryPoint = "usb_host_unset_hotplug_cb")]
    internal static extern ErrorCode UnsetHotplugCb(this HostHotplugHandle /* usb_host_hotplug_h */ handle);

    [DllImport(Libraries.Usb, EntryPoint = "usb_host_get_device_list")]
    internal static extern ErrorCode GetDeviceList(this UsbContextHandle /* usb_host_context_h */ ctx, out IntPtr /* usb_host_device_h */ devs, out int length);

    [DllImport(Libraries.Usb, EntryPoint = "usb_host_device_open_with_vid_pid")]
    internal static extern ErrorCode OpenWithVidPid(this UsbContextHandle /* usb_host_context_h */ ctx, int vendorId, int productId, out HostDeviceHandle /* usb_host_device_h */ deviceHandle);

    internal class UsbContextHandle : SafeUsbHandle
    {
        private IntPtr nativeDevListPtr = IntPtr.Zero;

        [DllImport(Libraries.Usb, EntryPoint = "usb_host_create")]
        internal static extern ErrorCode Create(out IntPtr /* usb_host_context_h */ ctx);

        [DllImport(Libraries.Usb, EntryPoint = "usb_host_destroy")]
        internal static extern ErrorCode Destroy(UsbContextHandle /* usb_host_context_h */ ctx);

        [DllImport(Libraries.Usb, EntryPoint = "usb_host_free_device_list")]
        internal static extern ErrorCode FreeDeviceList(IntPtr deviceList, bool unrefDevices);

        internal UsbContextHandle()
        {
            Create(out handle).ThrowIfFailed("Failed to create native context handle");
        }

        public override void Destroy()
        {
            if (nativeDevListPtr != IntPtr.Zero)
            {
                FreeDeviceList(nativeDevListPtr, true).ThrowIfFailed("Failed to free native device list");
                nativeDevListPtr = IntPtr.Zero;
            }
            Destroy(this).ThrowIfFailed("Failed to destroy native context handle");
        }

        internal List<HostDeviceHandle> GetDeviceList()
        {
            if (nativeDevListPtr != IntPtr.Zero)
            {
                FreeDeviceList(nativeDevListPtr, true).ThrowIfFailed("Failed to free native device list");
                nativeDevListPtr = IntPtr.Zero;
            }

            int length;
            ErrorCode err = this.GetDeviceList(out nativeDevListPtr, out length);
            err.ThrowIfFailed("Failed to get device list for the context");

            List<HostDeviceHandle> deviceList = new List<HostDeviceHandle>();
            IntPtr[] nativeDevList = new IntPtr[length];
            Marshal.Copy(nativeDevListPtr, nativeDevList, 0, length);

            foreach (var devHandle in nativeDevList)
            {
                deviceList.Add(new HostDeviceHandle(devHandle));
            }

            return deviceList;
        }
    }

    internal class HostHotplugHandle
    {
        private IntPtr _handle;
        public HostHotplugHandle(IntPtr handle) { _handle = handle; }
    }
}
