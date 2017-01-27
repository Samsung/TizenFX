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
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.InteropServices;

namespace Tizen.Network.Bluetooth
{
    /// <summary>
    /// Structure of device class type and service.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct BluetoothClassStruct
    {
        /// <summary>
        /// Type of the major device class.
        /// </summary>
        internal BluetoothMajorDeviceClassType MajorDeviceClassType;
        /// <summary>
        /// Type of the minor device class.
        /// </summary>
        internal BluetoothMinorDeviceClassType MinorDeviceClassType;
        /// <summary>
        /// Major service class mask.
        /// </summary>
        internal int MajorServiceClassMask;
    }

    /// <summary>
    /// Structure containing the information of Bluetooth device.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct BluetoothDeviceStruct
    {
        /// <summary>
        /// Address of device.
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.LPStr)]
        internal string Address;

        /// <summary>
        /// Name of device.
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.LPStr)]
        internal string Name;

        /// <summary>
        /// Class of device.
        /// </summary>
        internal BluetoothClassStruct Class;

        /// <summary>
        /// Service UUID list of device.
        /// </summary>
        internal IntPtr ServiceUuidList;

        /// <summary>
        /// Service count of device.
        /// </summary>
        internal int ServiceCount;

        /// <summary>
        /// The paired state of device.
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.I1)]
        internal bool IsPaired;

        /// <summary>
        /// The connection state of device.
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.I1)]
        internal bool IsConnected;

        /// <summary>
        /// The authorization state of device.
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.I1)]
        internal bool IsAuthorized;

        /// <summary>
        /// The length of the manufacturer data.
        /// </summary>
        internal int ManufacturerDataLength;

        /// <summary>
        /// The manufacturer data.
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.LPStr)]
        internal string ManufacturerData;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct BluetoothDiscoveredDeviceStruct
    {
        [MarshalAsAttribute(UnmanagedType.LPStr)]
        internal string Address;

        [MarshalAsAttribute(UnmanagedType.LPStr)]
        internal string Name;

        internal BluetoothClassStruct Class;

        internal int Rssi;

        [MarshalAsAttribute(UnmanagedType.I1)]
        internal bool IsPaired;

        internal IntPtr ServiceUuidList;

        internal int ServiceCount;

        internal BluetoothAppearanceType AppearanceType;

        internal int ManufacturerDataLength;

        [MarshalAsAttribute(UnmanagedType.LPStr)]
        internal string ManufacturerData;
    }

    internal struct BluetoothDeviceSdpStruct
    {
        [MarshalAsAttribute(UnmanagedType.LPStr)]
        internal string DeviceAddress;
        internal IntPtr ServiceUuid;
        internal int ServiceCount;
    }

    internal struct BluetoothDeviceConnectionStruct
    {
        internal string Address;
        internal BluetoothConnectionLinkType LinkType;
        internal BluetoothDisconnectReason DisconnectReason;
    }

    internal struct SocketDataStruct
    {
        internal int SocketFd;
        internal int DataSize;
        internal IntPtr Data;
    }

    internal struct SocketConnectionStruct
    {
        internal int SocketFd;
        internal int ServerFd;
        internal BluetoothSocketRole LocalRole;
        internal string Address;
        internal string ServiceUuid;
    }

    internal static class BluetoothUtils
    {
        internal static BluetoothDevice ConvertStructToDeviceClass(BluetoothDeviceStruct device)
        {
            BluetoothDevice resultDevice = new BluetoothDevice();
            Collection<string> uuidList = null;

            if (device.ServiceCount > 0)
            {
                IntPtr[] extensionList = new IntPtr[device.ServiceCount];
                Marshal.Copy (device.ServiceUuidList, extensionList, 0, device.ServiceCount);
                uuidList = new Collection<string> ();
                foreach (IntPtr extension in extensionList) {
                    string uuid = Marshal.PtrToStringAnsi (extension);
                    uuidList.Add (uuid);
                }
            }

            resultDevice.RemoteDeviceAddress = device.Address;
            resultDevice.RemoteDeviceName = device.Name;
            resultDevice.RemoteDeviceClass = new BluetoothClass();
            resultDevice.Class.MajorType = device.Class.MajorDeviceClassType;
            resultDevice.Class.MinorType = device.Class.MinorDeviceClassType;
            resultDevice.Class.Mask = device.Class.MajorServiceClassMask;
            resultDevice.RemotePaired = device.IsPaired;
            resultDevice.RemoteConnected = device.IsConnected;
            resultDevice.RemoteAuthorized = device.IsAuthorized;
            resultDevice.RemoteDeviceService = uuidList;
            resultDevice.RemoteDeviceCount = device.ServiceCount;
            resultDevice.RemoteManufLength = device.ManufacturerDataLength;
            resultDevice.RemoteManufData = device.ManufacturerData;

            return resultDevice;
        }

        internal static BluetoothDevice ConvertStructToDiscoveredDevice(BluetoothDiscoveredDeviceStruct structDevice)
        {
            BluetoothDevice resultDevice = new BluetoothDevice();
            Collection<string> uuidList = null;

            if (structDevice.ServiceCount > 0) {
                IntPtr[] extensionList = new IntPtr[structDevice.ServiceCount];
                Marshal.Copy (structDevice.ServiceUuidList, extensionList, 0, structDevice.ServiceCount);
                uuidList = new Collection<string> ();
                foreach (IntPtr extension in extensionList) {
                    string uuid = Marshal.PtrToStringAnsi (extension);
                    uuidList.Add (uuid);
                }
            }

            resultDevice.RemoteDeviceAddress = structDevice.Address;
            resultDevice.RemoteDeviceName = structDevice.Name;

            resultDevice.RemoteDeviceClass = new BluetoothClass();
            resultDevice.Class.MajorType = structDevice.Class.MajorDeviceClassType;
            resultDevice.Class.MinorType = structDevice.Class.MinorDeviceClassType;
            resultDevice.Class.Mask = structDevice.Class.MajorServiceClassMask;

            resultDevice.RemoteDeviceRssi = structDevice.Rssi;
            resultDevice.RemoteAppearance = structDevice.AppearanceType;

            if (structDevice.ServiceCount > 0) {
                resultDevice.RemoteDeviceService = uuidList;
                resultDevice.RemoteDeviceCount = structDevice.ServiceCount;
            }

            resultDevice.RemotePaired = structDevice.IsPaired;
            resultDevice.RemoteManufData = structDevice.ManufacturerData;
            resultDevice.RemoteManufLength = structDevice.ManufacturerDataLength;
            return resultDevice;
        }

        internal static BluetoothDeviceSdpData ConvertStructToSdpData(BluetoothDeviceSdpStruct structData)
        {
            BluetoothDeviceSdpData resultData = new BluetoothDeviceSdpData();
            Collection<string> uuidList = null;

            if (structData.ServiceCount > 0) {
                IntPtr[] extensionList = new IntPtr[structData.ServiceCount];
                Marshal.Copy (structData.ServiceUuid, extensionList, 0, structData.ServiceCount);
                uuidList = new Collection<string> ();
                foreach (IntPtr extension in extensionList) {
                    string uuid = Marshal.PtrToStringAnsi (extension);
                    uuidList.Add (uuid);
                }
            }

            resultData.Uuid = uuidList;
            resultData.Address = structData.DeviceAddress;

            return resultData;
        }

        internal static BluetoothDeviceConnectionData ConvertStructToConnectionData(BluetoothDeviceConnectionStruct structInfo)
        {
            BluetoothDeviceConnectionData resultData = new BluetoothDeviceConnectionData();
            resultData.RemoteAddress = structInfo.Address;
            resultData.Link = structInfo.LinkType;
            resultData.Reason = structInfo.DisconnectReason;
            return resultData;
        }

        internal static BluetoothLeScanData ConvertStructToLeScanData(BluetoothLeScanDataStruct structScanData)
        {
            BluetoothLeScanData scanData = new BluetoothLeScanData();

            scanData.RemoteAddress = structScanData.RemoteAddress;
            scanData.AddressType = structScanData.AddressType;
            scanData.Rssi = structScanData.Rssi;

            if (structScanData.AdvDataLength > 0)
            {
                scanData.AdvDataLength = structScanData.AdvDataLength;
                scanData.AdvData = new byte[scanData.AdvDataLength];
                Marshal.Copy (structScanData.AdvData, scanData.AdvData, 0, scanData.AdvDataLength);
            }

            if (structScanData.ScanDataLength > 0)
            {
                scanData.ScanDataLength = structScanData.ScanDataLength;
                scanData.ScanData = new byte[scanData.ScanDataLength];
                Marshal.Copy (structScanData.ScanData, scanData.ScanData, 0, scanData.ScanDataLength);
            }
            return scanData;
        }

        internal static BluetoothLeScanDataStruct ConvertLeScanDataToStruct(BluetoothLeScanData scanData)
        {
            BluetoothLeScanDataStruct scanDataStruct = new BluetoothLeScanDataStruct();

            scanDataStruct.RemoteAddress = scanData.RemoteAddress;
            scanDataStruct.AddressType = scanData.AddressType;
            scanDataStruct.Rssi = scanData.Rssi;

            if (scanData.AdvDataLength > 0)
            {
                scanDataStruct.AdvDataLength = scanData.AdvDataLength;
                scanDataStruct.AdvData = Marshal.AllocHGlobal(scanData.AdvDataLength);
                Marshal.Copy (scanData.AdvData, 0, scanDataStruct.AdvData, scanData.AdvDataLength);
            }

            if (scanData.ScanDataLength > 0)
            {
                scanDataStruct.ScanDataLength = scanData.ScanDataLength;
                scanDataStruct.ScanData = Marshal.AllocHGlobal(scanData.ScanDataLength);
                Marshal.Copy (scanData.ScanData, 0, scanDataStruct.ScanData, scanData.ScanDataLength);
            }

            return scanDataStruct;
        }

        internal static BluetoothLeServiceData ConvertStructToLeServiceData(BluetoothLeServiceDataStruct structServiceData)
        {
            BluetoothLeServiceData serviceData = new BluetoothLeServiceData();
            if (structServiceData.ServiceDataLength > 0)
            {
                serviceData.Uuid = structServiceData.ServiceUuid;
                serviceData.Length = structServiceData.ServiceDataLength;
                serviceData.Data = structServiceData.ServiceData;
            }
            return serviceData;
        }

        internal static SocketData ConvertStructToSocketData(SocketDataStruct structInfo)
        {
            SocketData data = new SocketData();
            data.Fd = structInfo.SocketFd;
            data.Size = structInfo.DataSize;
            data.RecvData = Marshal.PtrToStringAnsi(structInfo.Data);
            return data;
        }

        internal static SocketConnection ConvertStructToSocketConnection(SocketConnectionStruct structInfo)
        {
            SocketConnection connectionInfo = new SocketConnection();
            connectionInfo.Fd = structInfo.SocketFd;
            connectionInfo.RemoteAddress = structInfo.Address;
            connectionInfo.Uuid = structInfo.ServiceUuid;
            return connectionInfo;
        }
    }
}

