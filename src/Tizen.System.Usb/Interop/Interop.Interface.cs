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

    [DllImport(Libraries.Usb, EntryPoint = "usb_host_claim_interface")]
    internal static extern ErrorCode ClaimInterface(this UsbInterfaceHandle /* usb_host_interface_h */ usbInterface, bool force);

    [DllImport(Libraries.Usb, EntryPoint = "usb_host_release_interface")]
    internal static extern ErrorCode ReleaseInterface(this UsbInterfaceHandle /* usb_host_interface_h */ usbInterface);

    [DllImport(Libraries.Usb, EntryPoint = "usb_host_interface_get_number")]
    internal static extern ErrorCode GetNumber(this UsbInterfaceHandle /* usb_host_interface_h */ usbInterface, out int number);

    [DllImport(Libraries.Usb, EntryPoint = "usb_host_interface_get_num_endpoints")]
    internal static extern ErrorCode GetNumEndpoints(this UsbInterfaceHandle /* usb_host_interface_h */ usbInterface, out int numEndpoints);

    [DllImport(Libraries.Usb, EntryPoint = "usb_host_interface_get_endpoint")]
    internal static extern ErrorCode GetEndpoint(this UsbInterfaceHandle /* usb_host_interface_h */ usbInterface, int epIndex, out IntPtr /* usb_host_endpoint_h */ ep);

    [DllImport(Libraries.Usb, EntryPoint = "usb_host_interface_set_altsetting")]
    internal static extern ErrorCode SetAltsetting(this UsbInterfaceHandle /* usb_host_interface_h */ usbInterface, int altsetting);

    [DllImport(Libraries.Usb, EntryPoint = "usb_host_interface_get_str")]
    internal static extern ErrorCode GetStr(this UsbInterfaceHandle /* usb_host_interface_h */ usbInterface, ref int length, byte[] data);


    internal class UsbInterfaceHandle : SafeUsbHandle
    {
        public UsbInterfaceHandle(IntPtr handle) : base(handle) { }
        public override void Destroy() { }
    }
}