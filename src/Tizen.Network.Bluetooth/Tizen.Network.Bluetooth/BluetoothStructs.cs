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

using Tizen.Internals;

namespace Tizen.Network.Bluetooth
{
    /// <summary>
    /// The structure of the device class type and service.
    /// </summary>
    [NativeStruct("bt_class_s", Include="bluetooth_type.h", PkgConfig="capi-network-bluetooth")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct BluetoothClassStruct
    {
        /// <summary>
        /// The type of the major device class.
        /// </summary>
        internal BluetoothMajorDeviceClassType MajorDeviceClassType;
        /// <summary>
        /// The type of the minor device class.
        /// </summary>
        internal BluetoothMinorDeviceClassType MinorDeviceClassType;
        /// <summary>
        /// The major service class mask.
        /// </summary>
        internal int MajorServiceClassMask;
    }

    /// <summary>
    /// This structure contains the information of the Bluetooth device.
    /// </summary>
    [NativeStruct("bt_device_info_s", Include="bluetooth_type.h", PkgConfig="capi-network-bluetooth")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct BluetoothDeviceStruct
    {
        /// <summary>
        /// The address of the device.
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.LPStr)]
        internal string Address;

        /// <summary>
        /// The name of the device.
        /// </summary>
        internal IntPtr Name;

        /// <summary>
        /// The class of the device.
        /// </summary>
        internal BluetoothClassStruct Class;

        /// <summary>
        /// The service UUID list of the device.
        /// </summary>
        internal IntPtr ServiceUuidList;

        /// <summary>
        /// The service count of the device.
        /// </summary>
        internal int ServiceCount;

        /// <summary>
        /// The paired state of the device.
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.I1)]
        internal bool IsPaired;

        /// <summary>
        /// The connection state of the device.
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.I1)]
        internal bool IsConnected;

        /// <summary>
        /// The authorization state of the device.
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.I1)]
        internal bool IsAuthorized;

        /// <summary>
        /// The length of the manufacturer the data.
        /// </summary>
        internal int ManufacturerDataLength;

        /// <summary>
        /// The manufacturer data.
        /// </summary>
        internal IntPtr ManufacturerData;
    }
    [NativeStruct("bt_adapter_device_discovery_info_s", Include="bluetooth_type.h", PkgConfig="capi-network-bluetooth")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct BluetoothDiscoveredDeviceStruct
    {
        [MarshalAsAttribute(UnmanagedType.LPStr)]
        internal string Address;

        internal IntPtr Name;

        internal BluetoothClassStruct Class;

        internal int Rssi;

        [MarshalAsAttribute(UnmanagedType.I1)]
        internal bool IsPaired;

        internal IntPtr ServiceUuidList;

        internal int ServiceCount;

        internal BluetoothAppearanceType AppearanceType;

        internal int ManufacturerDataLength;

        internal IntPtr ManufacturerData;
    }

    [NativeStruct("bt_device_sdp_info_s", Include="bluetooth_type.h", PkgConfig="capi-network-bluetooth")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct BluetoothDeviceSdpStruct
    {
        [MarshalAsAttribute(UnmanagedType.LPStr)]
        internal string DeviceAddress;
        internal IntPtr ServiceUuid;
        internal int ServiceCount;
    }

    [NativeStruct("bt_device_connection_info_s", Include="bluetooth_type.h", PkgConfig="capi-network-bluetooth")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct BluetoothDeviceConnectionStruct
    {
        internal string Address;
        internal BluetoothConnectionLinkType LinkType;
        internal BluetoothDisconnectReason DisconnectReason;
    }

    [NativeStruct("bt_socket_received_data_s", Include="bluetooth_type.h", PkgConfig="capi-network-bluetooth")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct SocketDataStruct
    {
        internal int SocketFd;
        internal int DataSize;
        internal IntPtr Data;
    }

    [NativeStruct("bt_socket_connection_s", Include="bluetooth_type.h", PkgConfig="capi-network-bluetooth")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct SocketConnectionStruct
    {
        internal int SocketFd;
        internal int ServerFd;
        internal BluetoothSocketRole LocalRole;
        internal string Address;
        internal string ServiceUuid;
    }

    [NativeStruct("bt_adapter_le_device_scan_result_info_s", Include="bluetooth_type.h", PkgConfig="capi-network-bluetooth")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct BluetoothLeScanDataStruct
    {
        [MarshalAsAttribute(UnmanagedType.LPStr)]
        internal string RemoteAddress;

        internal BluetoothLeDeviceAddressType AddressType;

        internal int Rssi;

        internal int AdvDataLength;

        internal IntPtr AdvData;

        internal int ScanDataLength;

        internal IntPtr ScanData;
    }

    [NativeStruct("bt_adapter_le_service_data_s", Include="bluetooth_type.h", PkgConfig="capi-network-bluetooth")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct BluetoothLeServiceDataStruct
    {
        /// <summary>
        /// The Bluetooth LE service UUID.
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        internal string ServiceUuid;
        /// <summary>
        /// The Bluetooth LE service data.
        /// </summary>
        internal IntPtr ServiceData;

        internal int ServiceDataLength;
    }

    [NativeStruct("bt_hid_device_received_data_s", Include="bluetooth_type.h", PkgConfig="capi-network-bluetooth")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct BluetoothHidDeviceReceivedDataStruct
    {
        [MarshalAsAttribute(UnmanagedType.LPStr)]
        internal string RemoteAddress;
        internal BluetoothHidHeaderType headerType;
        internal BluetoothHidParamType paramType;
        internal int dataSize;
        internal IntPtr data;
    }

    [NativeStruct("bt_avrcp_metadata_attributes_info_s", Include="bluetooth_type.h", PkgConfig="capi-network-bluetooth")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct TrackInfoStruct
    {
        internal IntPtr Title;
        internal IntPtr Artist;
        internal IntPtr Album;
        internal IntPtr Genre;
        internal uint total_tracks;
        internal uint number;
        internal uint duration;
    }
    internal static class BluetoothUtils
    {
        internal static BluetoothDevice ConvertStructToDeviceClass(BluetoothDeviceStruct device)
        {
            const int DeviceNameLengthMax = 248;
            const int UuidLengthMax = 50;

            BluetoothDevice resultDevice = new BluetoothDevice();
            Collection<string> uuidList = null;

            if (device.ServiceCount > 0)
            {
                IntPtr[] extensionList = new IntPtr[device.ServiceCount];
                Marshal.Copy (device.ServiceUuidList, extensionList, 0, device.ServiceCount);
                uuidList = new Collection<string> ();
                foreach (IntPtr extension in extensionList) {
                    if (extension != IntPtr.Zero)
                    {
                        string uuid = Marshal.PtrToStringAnsi (extension, UuidLengthMax);
                        uuidList.Add (uuid);
                    }
                }
            }

            resultDevice.RemoteDeviceAddress = device.Address;
            resultDevice.RemoteDeviceName = Marshal.PtrToStringAnsi(device.Name, DeviceNameLengthMax);
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

            if (device.ManufacturerData != IntPtr.Zero)
                resultDevice.RemoteManufData = Marshal.PtrToStringAnsi(device.ManufacturerData, device.ManufacturerDataLength);

            return resultDevice;
        }

        internal static BluetoothDevice ConvertStructToDiscoveredDevice(BluetoothDiscoveredDeviceStruct structDevice)
        {
            BluetoothDevice resultDevice = new BluetoothDevice();
            Collection<string> uuidList = null;
            const int DeviceNameLengthMax = 248;
            const int UuidLengthMax = 50;

            if (structDevice.ServiceCount > 0) {
                IntPtr[] extensionList = new IntPtr[structDevice.ServiceCount];
                Marshal.Copy (structDevice.ServiceUuidList, extensionList, 0, structDevice.ServiceCount);
                uuidList = new Collection<string> ();
                foreach (IntPtr extension in extensionList) {
                    if (extension != IntPtr.Zero)
                    {
                        string uuid = Marshal.PtrToStringAnsi(extension, UuidLengthMax);
                        uuidList.Add(uuid);
                    }
                }
            }

            resultDevice.RemoteDeviceAddress = structDevice.Address;
            resultDevice.RemoteDeviceName = Marshal.PtrToStringAnsi(structDevice.Name, DeviceNameLengthMax);

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
            resultDevice.RemoteManufLength = structDevice.ManufacturerDataLength;

            if (structDevice.ManufacturerData != IntPtr.Zero)
                resultDevice.RemoteManufData = Marshal.PtrToStringAnsi(structDevice.ManufacturerData, structDevice.ManufacturerDataLength);

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
            Log.Info(Globals.LogTag, "ServiceDataLength" + structServiceData.ServiceDataLength);

            if (structServiceData.ServiceDataLength > 0)
            {
                serviceData.Uuid = structServiceData.ServiceUuid;
                serviceData.Length = structServiceData.ServiceDataLength;
                serviceData.Data = new byte[serviceData.Length];
                Marshal.Copy(structServiceData.ServiceData, serviceData.Data, 0, serviceData.Length);
            }
            return serviceData;
        }

        internal static SocketData ConvertStructToSocketData(SocketDataStruct structInfo)
        {
            SocketData data = new SocketData();
            Log.Info(Globals.LogTag, "SocketDataLength" + structInfo.DataSize);

            data._fd = structInfo.SocketFd;
            if (structInfo.DataSize > 0)
            {
                data._dataSize = structInfo.DataSize;
                data._data = new byte[data._dataSize];
                Marshal.Copy(structInfo.Data, data._data, 0, data._dataSize);
                data._recvData = Marshal.PtrToStringAnsi(structInfo.Data, structInfo.DataSize);
            }
            return data;
        }

        internal static SocketConnection ConvertStructToSocketConnection(SocketConnectionStruct structInfo)
        {
            SocketConnection connectionInfo = new SocketConnection();
            connectionInfo.Fd = structInfo.SocketFd;
            connectionInfo.RemoteAddress = structInfo.Address;
            connectionInfo.Uuid = structInfo.ServiceUuid;
            connectionInfo.ServerFd = structInfo.ServerFd;

            BluetoothSocket clientSocket = new BluetoothSocket();
            clientSocket.connectedSocket = structInfo.SocketFd;
            clientSocket.remoteAddress = structInfo.Address;
            clientSocket.serviceUuid = structInfo.ServiceUuid;
            connectionInfo.ClientSocket = (IBluetoothServerSocket)clientSocket;

            return connectionInfo;
        }
    }
}

