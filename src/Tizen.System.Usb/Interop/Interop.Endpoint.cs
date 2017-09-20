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
    internal enum EndpointDirection
    {
        In, // USB_HOST_DIRECTION_IN
        Out, // USB_HOST_DIRECTION_OUT
        InOut,
    }

    internal enum TransferType
    {
        Control, // USB_HOST_TRANSFER_TYPE_CONTROL
        Isochronous, // USB_HOST_TRANSFER_TYPE_ISOCHRONOUS
        Bulk, // USB_HOST_TRANSFER_TYPE_BULK
        Interrupt, // USB_HOST_TRANSFER_TYPE_INTERRUPT
    }

    internal enum SynchronizationType
    {
        None, // USB_HOST_ISO_SYNC_TYPE_NONE
        Async, // USB_HOST_ISO_SYNC_TYPE_ASYNC
        Adaptive, // USB_HOST_ISO_SYNC_TYPE_ADAPTIVE
        Sync, // USB_HOST_ISO_SYNC_TYPE_SYNC
    }

    internal enum UsageType
    {
        Data, // USB_HOST_USAGE_TYPE_DATA
        Feedback, // USB_HOST_USAGE_TYPE_FEEDBACK
        Implicit, // USB_HOST_USAGE_TYPE_IMPLICIT
    }

    [DllImport(Libraries.Usb, EntryPoint = "usb_host_endpoint_get_number")]
    internal static extern ErrorCode GetNumber(this UsbEndpointHandle /* usb_host_endpoint_h */ ep, out int number);

    [DllImport(Libraries.Usb, EntryPoint = "usb_host_endpoint_get_direction")]
    internal static extern ErrorCode GetDirection(this UsbEndpointHandle /* usb_host_endpoint_h */ ep, out EndpointDirection /* usb_host_endpoint_direction_e */ direction);

    [DllImport(Libraries.Usb, EntryPoint = "usb_host_endpoint_get_transfer_type")]
    internal static extern ErrorCode GetTransferType(this UsbEndpointHandle /* usb_host_endpoint_h */ ep, out TransferType /* usb_host_transfer_type_e */ transferType);

    [DllImport(Libraries.Usb, EntryPoint = "usb_host_endpoint_get_synch_type")]
    internal static extern ErrorCode GetSynchType(this UsbEndpointHandle /* usb_host_endpoint_h */ ep, out SynchronizationType /* usb_host_iso_sync_type_e */ synchType);

    [DllImport(Libraries.Usb, EntryPoint = "usb_host_endpoint_get_usage_type")]
    internal static extern ErrorCode GetUsageType(this UsbEndpointHandle /* usb_host_endpoint_h */ ep, out UsageType /* usb_host_usage_type_e */ usageType);

    [DllImport(Libraries.Usb, EntryPoint = "usb_host_endpoint_get_max_packet_size")]
    internal static extern ErrorCode GetMaxPacketSize(this UsbEndpointHandle /* usb_host_endpoint_h */ ep, out int maxPacketSize);

    [DllImport(Libraries.Usb, EntryPoint = "usb_host_endpoint_get_interval")]
    internal static extern ErrorCode GetInterval(this UsbEndpointHandle /* usb_host_endpoint_h */ ep, out int interval);

    [DllImport(Libraries.Usb, EntryPoint = "usb_host_transfer")]
    internal static extern ErrorCode Transfer(this UsbEndpointHandle /* usb_host_endpoint_h */ ep, byte[] data, int length, out int transferred, uint timeout);

    internal class UsbEndpointHandle
    {
        private IntPtr _handle;
        public UsbEndpointHandle(IntPtr handle){ _handle = handle; }
    }
}