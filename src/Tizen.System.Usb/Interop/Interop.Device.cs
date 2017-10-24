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
    [DllImport(Libraries.Usb, EntryPoint = "usb_host_ref_device")]
    internal static extern ErrorCode RefDevice(this HostDeviceHandle /* usb_host_device_h */ dev);

    [DllImport(Libraries.Usb, EntryPoint = "usb_host_unref_device")]
    internal static extern ErrorCode UnrefDevice(this HostDeviceHandle /* usb_host_device_h */ dev);

    [DllImport(Libraries.Usb, EntryPoint = "usb_host_device_open")]
    internal static extern ErrorCode Open(this HostDeviceHandle /* usb_host_device_h */ dev);

    [DllImport(Libraries.Usb, EntryPoint = "usb_host_device_close")]
    internal static extern ErrorCode CloseHandle(this HostDeviceHandle /* usb_host_device_h */ dev);

    [DllImport(Libraries.Usb, EntryPoint = "usb_host_device_get_bus_number")]
    internal static extern ErrorCode GetBusNumber(this HostDeviceHandle /* usb_host_device_h */ dev, out int busNumber);

    [DllImport(Libraries.Usb, EntryPoint = "usb_host_device_get_address")]
    internal static extern ErrorCode GetAddress(this HostDeviceHandle /* usb_host_device_h */ dev, out int deviceAddress);

    [DllImport(Libraries.Usb, EntryPoint = "usb_host_device_get_port_numbers")]
    internal static extern ErrorCode GetPortNumbers(this HostDeviceHandle /* usb_host_device_h */ dev, [MarshalAs(UnmanagedType.SysInt, SizeParamIndex = 2)] [In, Out] int[] portNumbers, int portNumbersLen, out int portsCount);

    [DllImport(Libraries.Usb, EntryPoint = "usb_host_device_get_config")]
    internal static extern ErrorCode GetConfig(this HostDeviceHandle /* usb_host_device_h */ dev, int configIndex, out UsbConfigHandle /* usb_host_config_h */ config);

    [DllImport(Libraries.Usb, EntryPoint = "usb_host_get_active_config")]
    internal static extern ErrorCode GetActiveConfig(this HostDeviceHandle /* usb_host_device_h */ dev, out UsbConfigHandle /* usb_host_config_h */ config);

    [DllImport(Libraries.Usb, EntryPoint = "usb_host_device_get_bcd_usb")]
    internal static extern ErrorCode GetBcdUsb(this HostDeviceHandle /* usb_host_device_h */ dev, out int bcdUsb);

    [DllImport(Libraries.Usb, EntryPoint = "usb_host_device_get_class")]
    internal static extern ErrorCode GetClass(this HostDeviceHandle /* usb_host_device_h */ dev, out int deviceClass);

    [DllImport(Libraries.Usb, EntryPoint = "usb_host_device_get_sub_class")]
    internal static extern ErrorCode GetSubClass(this HostDeviceHandle /* usb_host_device_h */ dev, out int subclass);

    [DllImport(Libraries.Usb, EntryPoint = "usb_host_device_get_protocol")]
    internal static extern ErrorCode GetProtocol(this HostDeviceHandle /* usb_host_device_h */ dev, out int protocol);

    [DllImport(Libraries.Usb, EntryPoint = "usb_host_device_get_max_packet_size_0")]
    internal static extern ErrorCode GetMaxPacketSize0(this HostDeviceHandle /* usb_host_device_h */ dev, out int maxPacketSize);

    [DllImport(Libraries.Usb, EntryPoint = "usb_host_device_get_id_vendor")]
    internal static extern ErrorCode GetIdVendor(this HostDeviceHandle /* usb_host_device_h */ dev, out int vendorId);

    [DllImport(Libraries.Usb, EntryPoint = "usb_host_device_get_id_product")]
    internal static extern ErrorCode GetIdProduct(this HostDeviceHandle /* usb_host_device_h */ dev, out int productId);

    [DllImport(Libraries.Usb, EntryPoint = "usb_host_device_get_bcd_device")]
    internal static extern ErrorCode GetBcdDevice(this HostDeviceHandle /* usb_host_device_h */ dev, out int deviceBcd);

    [DllImport(Libraries.Usb, EntryPoint = "usb_host_device_get_num_configurations")]
    internal static extern ErrorCode GetNumConfigurations(this HostDeviceHandle /* usb_host_device_h */ dev, out int numConfigurations);

    [DllImport(Libraries.Usb, EntryPoint = "usb_host_is_device_opened")]
    internal static extern ErrorCode IsOpened(this HostDeviceHandle /* usb_host_device_h */ dev, out bool isOpened);

    [DllImport(Libraries.Usb, EntryPoint = "usb_host_device_get_manufacturer_str")]
    internal static extern ErrorCode GetManufacturerStr(this HostDeviceHandle /* usb_host_device_h */ dev, ref int length, byte[] data);

    [DllImport(Libraries.Usb, EntryPoint = "usb_host_device_get_product_str")]
    internal static extern ErrorCode GetProductStr(this HostDeviceHandle /* usb_host_device_h */ dev, ref int length, byte[] data);

    [DllImport(Libraries.Usb, EntryPoint = "usb_host_device_get_serial_number_str")]
    internal static extern ErrorCode GetSerialNumberStr(this HostDeviceHandle /* usb_host_device_h */ dev, ref int length, byte[] data);

    [DllImport(Libraries.Usb, EntryPoint = "usb_host_control_transfer")]
    internal static extern ErrorCode ControlTransfer(this HostDeviceHandle /* usb_host_device_h */ dev, byte requestType, byte request, ushort value, ushort index, byte[] data, ushort length, uint timeout, out int transferred);

    internal class HostDeviceHandle : SafeUsbHandle
    {
        internal HostDeviceHandle(IntPtr handle) : base(handle) { }

        public override void Destroy()
        {
            //this.UnrefDevice();
        }

        internal IEnumerable<int> Ports()
        {
            int actualPortsCount;
            int[] portList = new int[MaxPortNumberCount];
            var err = this.GetPortNumbers(portList, portList.Length, out actualPortsCount);
            err.ThrowIfFailed("Failed to get device port list");
            return portList.Take(actualPortsCount);
        }
    }
}
