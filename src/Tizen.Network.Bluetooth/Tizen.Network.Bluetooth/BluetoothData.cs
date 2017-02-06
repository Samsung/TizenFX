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
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Tizen.Network.Bluetooth
{
    /// <summary>
    /// A class to handle device class type and service.
    /// </summary>
    public class BluetoothClass
    {
        internal BluetoothMajorDeviceClassType MajorType;
        internal BluetoothMinorDeviceClassType MinorType;
        internal int Mask;

        internal BluetoothClass()
        {
        }

        /// <summary>
        /// Type of the major device class.
        /// </summary>
        public BluetoothMajorDeviceClassType MajorDeviceClassType
        {
            get
            {
                return MajorType;
            }
        }
        /// <summary>
        /// Type of the minor device class.
        /// </summary>
        public BluetoothMinorDeviceClassType MinorDeviceClassType
        {
            get
            {
                return MinorType;
            }
        }
        /// <summary>
        /// Major service class mask.
        /// </summary>
        public int MajorServiceClassMask
        {
            get
            {
                return Mask;
            }
        }
    }

    /// <summary>
    /// A class containing the information of Bluetooth oob data.
    /// </summary>
    public class BluetoothOobData
    {
        /// <summary>
        /// Default Constructor.Initializes an object of BluetoothOobData
        /// </summary>
        public BluetoothOobData()
        {
        }

        /// <summary>
        /// Hash value.
        /// </summary>
        public byte[] HashValue
        {
            get;
            set;
        }
        /// <summary>
        /// Randomizer value.
        /// </summary>
        public byte[] RandomizerValue
        {
            get;
            set;
        }
    }

    /// <summary>
    /// A class containing the information of Bluetooth device sdp data.
    /// </summary>
    public class BluetoothDeviceSdpData
    {
        internal string Address;
        internal Collection<string> Uuid;

        internal BluetoothDeviceSdpData()
        {
        }

        /// <summary>
        /// The device address.
        /// </summary>
        public string DeviceAddress
        {
            get
            {
                return Address;
            }
        }
        /// <summary>
        /// The service UUID.
        /// </summary>
        public IEnumerable<string> ServiceUuid
        {
            get
            {
                return Uuid;
            }
        }
    }

    /// <summary>
    /// A class containing the information of Bluetooth device connection data.
    /// </summary>
    public class BluetoothDeviceConnectionData
    {
        internal string RemoteAddress;
        internal BluetoothConnectionLinkType Link;
        internal BluetoothDisconnectReason Reason;

        internal BluetoothDeviceConnectionData()
        {
        }

        /// <summary>
        /// The device address.
        /// </summary>
        public string Address
        {
            get
            {
                return RemoteAddress;
            }
        }
        /// <summary>
        /// The type of the connection link.
        /// </summary>
        public BluetoothConnectionLinkType LinkType
        {
            get
            {
                return Link;
            }
        }
        /// <summary>
        /// The disconnect reason.
        /// </summary>
        public BluetoothDisconnectReason DisconnectReason
        {
            get
            {
                return Reason;
            }
        }
    }

    /// <summary>
    /// A class containing the information of track data.
    /// </summary>
    public class Track
    {
        /// <summary>
        /// Default Constructor.Initializes an object of Track
        /// </summary>
        public Track()
        {
        }

        /// <summary>
        /// Title of track.
        /// </summary>
        public string Title
        {
            get;
            set;
        }
        /// <summary>
        /// Artist of track.
        /// </summary>
        public string Artist
        {
            get;
            set;
        }
        /// <summary>
        /// Album of track.
        /// </summary>
        public string Album
        {
            get;
            set;
        }
        /// <summary>
        /// Genre of track.
        /// </summary>
        public string Genre
        {
            get;
            set;
        }
        /// <summary>
        /// Track number.
        /// </summary>
        public uint TrackNum
        {
            get;
            set;
        }
        /// <summary>
        /// Number of all tracks.
        /// </summary>
        public uint TotalTracks
        {
            get;
            set;
        }
        /// <summary>
        /// Duration of track in milliseconds.
        /// </summary>
        public uint Duration
        {
            get;
            set;
        }
    }

    /// <summary>
    /// A class containing the information of Manufacturer data.
    /// </summary>
    public class ManufacturerData
    {
        /// <summary>
        /// Default Constructor.Initializes an object of ManufacturerData
        /// </summary>
        public ManufacturerData()
        {
        }

        /// <summary>
        /// The manufacturer id.
        /// </summary>
        public int Id
        {
            get;
            set;
        }
        /// <summary>
        /// The length of the manufacturer data.
        /// </summary>
        public int DataLength
        {
            get;
            set;
        }
        /// <summary>
        /// The manufacturer data.
        /// </summary>
        public byte[] Data
        {
            get;
            set;
        }
    }

    internal class BluetoothLeScanData
    {
        internal string RemoteAddress
        {
            get;
            set;
        }
        internal BluetoothLeDeviceAddressType AddressType
        {
            get;
            set;
        }
        internal int Rssi
        {
            get;
            set;
        }
        internal int AdvDataLength
        {
            get;
            set;
        }
        internal byte[] AdvData
        {
            get;
            set;
        }
        internal int ScanDataLength
        {
            get;
            set;
        }
        internal byte[] ScanData
        {
            get;
            set;
        }
    }

    /// <summary>
    /// A class containing the information of Bluetooth service data.
    /// </summary>
    public class BluetoothServiceData
    {
        /// <summary>
        /// Default Constructor.Initializes an object of BluetoothServiceData
        /// </summary>
        public BluetoothServiceData()
        {
        }

        /// <summary>
        /// The Uuid of service.
        /// </summary>
        public string Uuid
        {
            get;
            set;
        }
        /// <summary>
        /// The data length of the service data.
        /// </summary>
        public int DataLength
        {
            get;
            set;
        }
        /// <summary>
        /// The service data.
        /// </summary>
        public byte[] Data
        {
            get;
            set;
        }
    }

    /// <summary>
    /// A class containing the service data information.
    /// </summary>
    public class BluetoothLeServiceData
    {
        internal string Uuid;
        internal byte[] Data;
        internal int Length;

        internal BluetoothLeServiceData()
        {
        }

        /// <summary>
        /// Bluetooth Le service uuid.
        /// </summary>
        public string ServiceUuid
        {
            get
            {
                return Uuid;
            }
        }
        /// <summary>
        /// Bluetooth Le service data
        /// </summary>
        public byte[] ServiceData
        {
            get
            {
                return Data;
            }
        }
        /// <summary>
        /// The length of the service data.
        /// </summary>
        public int ServiceDataLength
        {
            get
            {
                return Length;
            }
        }
    }

    /// <summary>
    /// A class containing the information of Socket data.
    /// </summary>
    public class SocketData
    {
        internal string RecvData;
        internal int Size;
        internal int Fd;

        internal SocketData()
        {
        }

        /// <summary>
        /// The socket fd.
        /// </summary>
        public int SocketFd
        {
            get
            {
                return Fd;
            }
        }
        /// <summary>
        /// The length of the received data.
        /// </summary>
        public int DataSize
        {
            get
            {
                return Size;
            }
        }
        /// <summary>
        /// The received data.
        /// </summary>
        public string Data
        {
            get
            {
                return RecvData;
            }
        }
    }

    /// <summary>
    /// A class containing the information of Socket connection.
    /// </summary>
    public class SocketConnection
    {
        internal string Uuid;
        internal string RemoteAddress;
        internal int Fd;

        internal SocketConnection()
        {
        }

        /// <summary>
        /// The connected socket fd.
        /// </summary>
        public int SocketFd
        {
            get
            {
                return Fd;
            }
        }
        /// <summary>
        /// The remote device address.
        /// </summary>
        public string Address
        {
            get
            {
                return RemoteAddress;
            }
        }
        /// <summary>
        /// The service Uuid.
        /// </summary>
        public string ServiceUuid
        {
            get
            {
                return Uuid;
            }
        }
    }
}
