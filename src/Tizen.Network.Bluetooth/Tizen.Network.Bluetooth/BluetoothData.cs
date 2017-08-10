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
    /// This class is used to handle the device class types and the service.
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
        /// The type of the major device class.
        /// </summary>
        public BluetoothMajorDeviceClassType MajorDeviceClassType
        {
            get
            {
                return MajorType;
            }
        }
        /// <summary>
        /// The type of the minor device class.
        /// </summary>
        public BluetoothMinorDeviceClassType MinorDeviceClassType
        {
            get
            {
                return MinorType;
            }
        }
        /// <summary>
        /// The major service class mask.
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
    /// This class contains the information of the Bluetooth OOB data.
    /// </summary>
    public class BluetoothOobData
    {
        /// <summary>
        /// The default constructor. Initializes an object of the BluetoothOobData.
        /// </summary>
        public BluetoothOobData()
        {
        }

        /// <summary>
        /// The hash value.
        /// </summary>
        public byte[] HashValue
        {
            get;
            set;
        }
        /// <summary>
        /// The randomizer value.
        /// </summary>
        public byte[] RandomizerValue
        {
            get;
            set;
        }
    }

    /// <summary>
    /// This class contains the information of the Bluetooth device SDP data.
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
    /// This class contains the information of the Bluetooth device connection data.
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
    /// This class contains the information of the track data.
    /// </summary>
    public class Track
    {
        /// <summary>
        /// The default constructor. Initializes an object of the track.
        /// </summary>
        public Track()
        {
        }

        /// <summary>
        /// The title of the track.
        /// </summary>
        public string Title
        {
            get;
            set;
        }
        /// <summary>
        /// The artist of the track.
        /// </summary>
        public string Artist
        {
            get;
            set;
        }
        /// <summary>
        /// The album of the track.
        /// </summary>
        public string Album
        {
            get;
            set;
        }
        /// <summary>
        /// The genre of the track.
        /// </summary>
        public string Genre
        {
            get;
            set;
        }
        /// <summary>
        /// The track number.
        /// </summary>
        public uint TrackNum
        {
            get;
            set;
        }
        /// <summary>
        /// The number of all tracks.
        /// </summary>
        public uint TotalTracks
        {
            get;
            set;
        }
        /// <summary>
        /// The duration of the track in milliseconds.
        /// </summary>
        public uint Duration
        {
            get;
            set;
        }
    }

    /// <summary>
    /// This class contains the information of the manufacturer data.
    /// </summary>
    public class ManufacturerData
    {
        /// <summary>
        /// The default Constructor. Initializes an object of the ManufacturerData.
        /// </summary>
        public ManufacturerData()
        {
        }

        /// <summary>
        /// The manufacturer ID.
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
    /// This class contains the information of the Bluetooth service data.
    /// </summary>
    public class BluetoothServiceData
    {
        /// <summary>
        /// The default constructor. Initializes an object of the BluetoothServiceData.
        /// </summary>
        public BluetoothServiceData()
        {
        }

        /// <summary>
        /// The UUID of the service.
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
    /// This class contains the service data information.
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
        /// The Bluetooth LE service UUID.
        /// </summary>
        public string ServiceUuid
        {
            get
            {
                return Uuid;
            }
        }
        /// <summary>
        /// The Bluetooth LE service data.
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
    /// This class contains the information of the socket data.
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
        /// The socket FD.
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
    /// This class contains the information of the socket connection.
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
        /// The connected socket FD.
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
        /// The service UUID.
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
