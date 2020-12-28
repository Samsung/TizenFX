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
using System.ComponentModel;

namespace Tizen.Network.Bluetooth
{
    /// <summary>
    /// This class is used to handle the device class types and the service.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
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
        /// <since_tizen> 3 </since_tizen>
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
        /// <since_tizen> 3 </since_tizen>
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
        /// <since_tizen> 3 </since_tizen>
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
    /// <since_tizen> 3 </since_tizen>
    public class BluetoothOobData
    {
        /// <summary>
        /// The default constructor. Initializes an object of the BluetoothOobData.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public BluetoothOobData()
        {
        }

        /// <summary>
        /// The hash value.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public byte[] HashValue
        {
            get;
            set;
        }
        /// <summary>
        /// The randomizer value.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public byte[] RandomizerValue
        {
            get;
            set;
        }
    }

    /// <summary>
    /// This class contains the information of the Bluetooth device SDP data.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
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
        /// <since_tizen> 3 </since_tizen>
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
        /// <since_tizen> 3 </since_tizen>
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
    /// <since_tizen> 3 </since_tizen>
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
        /// <since_tizen> 3 </since_tizen>
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
        /// <since_tizen> 3 </since_tizen>
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
        /// <since_tizen> 3 </since_tizen>
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
    /// <since_tizen> 3 </since_tizen>
    public class Track
    {
        /// <summary>
        /// The default constructor. Initializes an object of the track.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Track()
        {
        }

        /// <summary>
        /// The title of the track.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Title
        {
            get;
            set;
        }
        /// <summary>
        /// The artist of the track.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Artist
        {
            get;
            set;
        }
        /// <summary>
        /// The album of the track.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Album
        {
            get;
            set;
        }
        /// <summary>
        /// The genre of the track.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Genre
        {
            get;
            set;
        }
        /// <summary>
        /// The track number.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public uint TrackNum
        {
            get;
            set;
        }
        /// <summary>
        /// The number of all tracks.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public uint TotalTracks
        {
            get;
            set;
        }
        /// <summary>
        /// The duration of the track in milliseconds.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public uint Duration
        {
            get;
            set;
        }
    }

    /// <summary>
    /// This class contains the information of the manufacturer data.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class ManufacturerData
    {
        /// <summary>
        /// The default Constructor. Initializes an object of the ManufacturerData.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ManufacturerData()
        {
        }

        /// <summary>
        /// The manufacturer ID.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int Id
        {
            get;
            set;
        }
        /// <summary>
        /// The length of the manufacturer data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int DataLength
        {
            get;
            set;
        }
        /// <summary>
        /// The manufacturer data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
    /// <since_tizen> 3 </since_tizen>
    public class BluetoothServiceData
    {
        /// <summary>
        /// The default constructor. Initializes an object of the BluetoothServiceData.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public BluetoothServiceData()
        {
        }

        /// <summary>
        /// The UUID of the service.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Uuid
        {
            get;
            set;
        }
        /// <summary>
        /// The data length of the service data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int DataLength
        {
            get;
            set;
        }
        /// <summary>
        /// The service data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public byte[] Data
        {
            get;
            set;
        }
    }

    /// <summary>
    /// This class contains the service data information.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
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
        /// <since_tizen> 3 </since_tizen>
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
        /// <since_tizen> 3 </since_tizen>
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
        /// <since_tizen> 3 </since_tizen>
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
    /// <since_tizen> 3 </since_tizen>
    public class SocketData
    {
        internal string _recvData;
        internal byte[] _data;
        internal int _dataSize;
        internal int _fd;

        internal SocketData()
        {
        }

        /// <summary>
        /// The socket FD.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int SocketFd
        {
            get
            {
                return _fd;
            }
        }
        /// <summary>
        /// The length of the received data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int DataSize
        {
            get
            {
                return _dataSize;
            }
        }
        /// <summary>
        /// The received data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated since API level 7. Please use ByteData property.")]
        public string Data
        {
            get
            {
                return _recvData;
            }
        }
        /// <summary>
        /// The received data.
        /// </summary>
        /// <since_tizen> 7 </since_tizen>
        public byte[] ByteData
        {
            get
            {
                return _data;
            }
        }
    }

    /// <summary>
    /// This class contains the information of the socket connection.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class SocketConnection
    {
        internal string Uuid;
        internal string RemoteAddress;
        internal int Fd;
        internal IBluetoothServerSocket ClientSocket;

        internal SocketConnection()
        {
        }

        /// <summary>
        /// The connected socket FD.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// <since_tizen> 3 </since_tizen>
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
        /// <since_tizen> 3 </since_tizen>
        public string ServiceUuid
        {
            get
            {
                return Uuid;
            }
        }

        internal int ServerFd
        {
            get;
            set;
        }
        /// <summary>
        /// The client socket.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public IBluetoothServerSocket Client
        {
            get
            {
                return ClientSocket;
            }
        }
    }

    /// <summary>
    /// This class contains the HID mouse event information.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class BluetoothHidMouseData
    {
        /// <summary>
        /// The button values, we can combine key's values when we pressed multiple mouse buttons
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public int Buttons
        {
            get;
            set;
        }

        /// <summary>
        /// The location's x value, -128 ~127
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public int AxisX
        {
            get;
            set;
        }

        /// <summary>
        /// The location's y value, -128 ~127
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public int AxisY
        {
            get;
            set;
        }

        /// <summary>
        /// The padding value, -128 ~127
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public int Padding
        {
            get;
            set;
        }
    }

    /// <summary>
    /// This class contains the HID keyboard event information.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class BluetoothHidKeyData
    {
        /// <summary>
        /// The modifier keys : such as shift, alt
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public byte Modifier
        {
            get;
            set;
        }

        /// <summary>
        /// The key value - currently pressed keys : Max 8 at once
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public byte[] Key
        {
            get;
            set;
        }
    }

    /// <summary>
    /// This class contains the data received from the HID Host.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class BluetoothHidDeviceReceivedData
    {
        /// <summary>
        /// The default constructor. Initializes an object of the BluetoothHidReceivedData.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        internal static BluetoothHidDeviceReceivedData Create(BluetoothHidDeviceReceivedDataStruct structInfo)
        {
            BluetoothHidDeviceReceivedData receivedData = new BluetoothHidDeviceReceivedData();
            receivedData.Address = structInfo.RemoteAddress;
            receivedData.HeaderType = structInfo.headerType;
            receivedData.ParamType = structInfo.paramType;
            if (structInfo.dataSize > 0)
            {
                receivedData.Data = new byte[structInfo.dataSize];
                Marshal.Copy(structInfo.data, receivedData.Data, 0, structInfo.dataSize);
            }
            return receivedData;
        }

        /// <summary>
        /// The remote device's address
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string Address
        {
            get;
            private set;
        }

        /// <summary>
        /// The header type
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public BluetoothHidHeaderType HeaderType
        {
            get;
            private set;
        }

        /// <summary>
        /// The parameter type
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public BluetoothHidParamType ParamType
        {
            get;
            private set;
        }

        /// <summary>
        /// The received data
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public byte[] Data
        {
            get;
            private set;
        }
    }
}
