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
using System.ComponentModel;

namespace Tizen.Network.Bluetooth
{
    /// <summary>
    /// An extended EventArgs class contains the changed Bluetooth state.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class StateChangedEventArgs : EventArgs
    {
        private BluetoothState _type;
        private BluetoothError _result;

        internal StateChangedEventArgs(BluetoothError result, BluetoothState type)
        {
            _type = type;
            _result = result;
        }

        /// <summary>
        /// The state of Bluetooth.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public BluetoothState BTState
        {
            get
            {
                return _type;
            }
        }

        /// <summary>
        /// The BluetoothError result.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public BluetoothError Result
        {
            get
            {
                return _result;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class contains the changed Bluetooth name.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class NameChangedEventArgs : EventArgs
    {
        private string _name;

        internal NameChangedEventArgs(string name)
        {
            _name = name;
        }

        /// <summary>
        /// The name of the device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string DeviceName
        {
            get
            {
                return _name;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class contains the changed Bluetooth visibility mode.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class VisibilityModeChangedEventArgs : EventArgs
    {
        private VisibilityMode _mode;
        private BluetoothError _result;

        internal VisibilityModeChangedEventArgs(BluetoothError result, VisibilityMode mode)
        {
            _result = result;
            _mode = mode;
        }

        /// <summary>
        /// The visibility mode.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public VisibilityMode Visibility
        {
            get
            {
                return _mode;
            }
        }

        /// <summary>
        /// The BluetoothError result.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public BluetoothError Result
        {
            get
            {
                return _result;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class contains the duration until the visibility mode is changed from TimeLimitedDiscoverable to NonDiscoverable.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class VisibilityDurationChangedEventArgs : EventArgs
    {
        private int _duration;

        internal VisibilityDurationChangedEventArgs(int duration)
        {
            _duration = duration;
        }

        /// <summary>
        /// The duration.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int Duration
        {
            get
            {
                return _duration;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class contains the changed Bluetooth device discovery state and the discovered device information.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class DiscoveryStateChangedEventArgs : EventArgs
    {
        private BluetoothError _result;
        private BluetoothDeviceDiscoveryState _state;
        private BluetoothDevice _device;

        internal DiscoveryStateChangedEventArgs(BluetoothError result, BluetoothDeviceDiscoveryState state)
        {
            _result = result;
            _state = state;
        }

        internal DiscoveryStateChangedEventArgs(BluetoothError result, BluetoothDeviceDiscoveryState state, BluetoothDevice device)
        {
            _result = result;
            _state = state;
            _device = device;
        }

        /// <summary>
        /// The BluetoothError result.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public BluetoothError Result
        {
            get
            {
                return _result;
            }
        }

        /// <summary>
        /// The state of the discovery.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public BluetoothDeviceDiscoveryState DiscoveryState
        {
            get
            {
                return _state;
            }
        }

        /// <summary>
        /// The remote device found.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public BluetoothDevice DeviceFound
        {
            get
            {
                return _device;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class contains the bonded device information.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class BondCreatedEventArgs : EventArgs
    {
        private BluetoothError _result;
        private BluetoothDevice _device;

        internal BondCreatedEventArgs(BluetoothError result, BluetoothDevice device)
        {
            _result = result;
            _device = device;
        }

        /// <summary>
        /// The BluetoothError result.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public BluetoothError Result
        {
            get
            {
                return _result;
            }
        }

        /// <summary>
        /// The remote device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public BluetoothDevice Device
        {
            get
            {
                return _device;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class contains the address of the remote Bluetooth device to destroy bond with.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class BondDestroyedEventArgs : EventArgs
    {
        private BluetoothError _result;
        private string _address;

        internal BondDestroyedEventArgs(BluetoothError result, string address)
        {
            _result = result;
            _address = address;
        }

        /// <summary>
        /// The BluetoothError result.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public BluetoothError Result
        {
            get
            {
                return _result;
            }
        }

        /// <summary>
        /// The remote device address.
        /// </summary>
        /// <value>The device address.</value>
        /// <since_tizen> 3 </since_tizen>
        public string DeviceAddress
        {
            get
            {
                return _address;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class contains the authorization state and the address of the remote Bluetooth device.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class AuthorizationChangedEventArgs : EventArgs
    {
        private BluetoothAuthorizationType _authType;
        private string _address;

        internal AuthorizationChangedEventArgs(BluetoothAuthorizationType authType, string address)
        {
            _authType = authType;
            _address = address;
        }

        /// <summary>
        /// The authorization.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public BluetoothAuthorizationType Authorization
        {
            get
            {
                return _authType;
            }
        }

        /// <summary>
        /// The device address.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string DeviceAddress
        {
            get
            {
                return _address;
            }
        }

    }

    /// <summary>
    /// An extended EventArgs class contains the service lists found on the remote Bluetooth device.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class ServiceSearchedEventArgs : EventArgs
    {
        private BluetoothDeviceSdpData _sdpData;
        private BluetoothError _result;

        internal ServiceSearchedEventArgs(BluetoothError result, BluetoothDeviceSdpData sdpData)
        {
            _result = result;
            _sdpData = sdpData;
        }

        /// <summary>
        /// The BluetoothError result.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public BluetoothError Result
        {
            get
            {
                return _result;
            }
        }
        /// <summary>
        /// The sdp data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public BluetoothDeviceSdpData SdpData
        {
            get
            {
                return _sdpData;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class contains the connection state and the connection information of the remote device.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class DeviceConnectionStateChangedEventArgs : EventArgs
    {
        private bool _isConnected;
        private BluetoothDeviceConnectionData _connectionData;

        internal DeviceConnectionStateChangedEventArgs(bool isConnected, BluetoothDeviceConnectionData connectionData)
        {
            _isConnected = isConnected;
            _connectionData = connectionData;
        }

        /// <summary>
        /// A value indicating whether the device is connected.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool IsConnected => _isConnected;

        /// <summary>
        /// The device connection data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public BluetoothDeviceConnectionData ConnectionData
        {
            get
            {
                return _connectionData;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class contains the data received information.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class SocketDataReceivedEventArgs : EventArgs
    {
        private SocketData _data;

        internal SocketDataReceivedEventArgs(SocketData data)
        {
            _data = data;
        }

        /// <summary>
        /// The socket data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public SocketData Data
        {
            get
            {
                return _data;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class contains the changed connection state.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class SocketConnectionStateChangedEventArgs : EventArgs
    {
        private BluetoothError _result;
        private BluetoothSocketState _state;
        private SocketConnection _connection;

        internal SocketConnectionStateChangedEventArgs(BluetoothError result, BluetoothSocketState state, SocketConnection connection)
        {
            _result = result;
            _state = state;
            _connection = connection;
        }

        /// <summary>
        /// The BluetoothError result.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public BluetoothError Result
        {
            get
            {
                return _result;
            }
        }

        /// <summary>
        /// The socket state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public BluetoothSocketState State
        {
            get
            {
                return _state;
            }
        }

        /// <summary>
        /// The socket connection.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public SocketConnection Connection
        {
            get
            {
                return _connection;
            }
        }
    }

    /// <summary>
    /// The AcceptStateChanged event is raised when the socket connection state is changed.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class AcceptStateChangedEventArgs : EventArgs
    {
        private BluetoothError _result;
        private BluetoothSocketState _state;
        private SocketConnection _connection;
        private IBluetoothServerSocket _server;

        internal AcceptStateChangedEventArgs(BluetoothError result, BluetoothSocketState state, SocketConnection connection, BluetoothSocket server)
        {
            _result = result;
            _state = state;
            _connection = connection;
            _server = (IBluetoothServerSocket)server;
        }

        /// <summary>
        /// The BluetoothError result.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public BluetoothError Result
        {
            get
            {
                return _result;
            }
        }

        /// <summary>
        /// The socket state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public BluetoothSocketState State
        {
            get
            {
                return _state;
            }
        }

        /// <summary>
        /// The socket connection.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public SocketConnection Connection
        {
            get
            {
                return _connection;
            }
        }

        /// <summary>
        /// The server socket instance.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated since API level 6. Please use the 'Client' in the SocketConnection.")]
        public IBluetoothServerSocket Server
        {
            get
            {
                return _server;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class contains the socket connection requested.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class SocketConnectionRequestedEventArgs : EventArgs
    {
        internal SocketConnectionRequestedEventArgs(int socketFd, string remoteAddress)
        {
            SocketFd = socketFd;
            RemoteAddress = remoteAddress;
        }

        /// <summary>
        /// The socket fd.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        internal int SocketFd
        {
            get;
            private set;
        }

        /// <summary>
        /// The remote address.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string RemoteAddress
        {
            get;
            private set;
        }
    }

    /// <summary>
    /// An extended EventArgs class contains the connection state, remote address, and the type of audio profile.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class AudioConnectionStateChangedEventArgs : EventArgs
    {
        private int _result;
        private bool _isConnected;
        private string _address;
        private BluetoothAudioProfileType _type;

        internal AudioConnectionStateChangedEventArgs(int result, bool isConnected, string address, BluetoothAudioProfileType type)
        {
            _result = result;
            _type = type;
            _isConnected = isConnected;
            _address = address;
        }

        /// <summary>
        /// The result.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int Result
        {
            get
            {
                return _result;
            }
        }

        /// <summary>
        /// A value indicating whether this instance is connected.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool IsConnected
        {
            get
            {
                return _isConnected;
            }
        }

        /// <summary>
        /// The address.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Address
        {
            get
            {
                return _address;
            }
        }

        /// <summary>
        /// The type of the audio profile.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public BluetoothAudioProfileType ProfileType
        {
            get
            {
                return _type;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class contains the connection state and the address of the remote Bluetooth device.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class AgScoStateChangedEventArgs : EventArgs
    {
        internal AgScoStateChangedEventArgs(bool isOpened)
        {
            IsOpened = isOpened;
        }

        /// <summary>
        /// A value indicating whether the state is connected.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public bool IsOpened
        {
            get;
            private set;
        }
    }

    /// <summary>
    /// An extended EventArgs class contains the connection state and the address of the remote Bluetooth device.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class HidConnectionStateChangedEventArgs : EventArgs
    {
        private int _result;
        private bool _isConnected;
        private string _address;

        internal HidConnectionStateChangedEventArgs(int result, bool isConnected, string address)
        {
            _result = result;
            _isConnected = isConnected;
            _address = address;
        }

        /// <summary>
        /// The result.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int Result
        {
            get
            {
                return _result;
            }
        }

        /// <summary>
        /// A value indicating whether this instance is connected.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool IsConnected
        {
            get
            {
                return _isConnected;
            }
        }

        /// <summary>
        /// The address.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Address
        {
            get
            {
                return _address;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class contains the connection state and the address of the remote Bluetooth device.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class HidDeviceConnectionStateChangedEventArgs : EventArgs
    {
        internal HidDeviceConnectionStateChangedEventArgs(bool isConnected, string address)
        {
            IsConnected = isConnected;
            Address = address;
        }

        internal HidDeviceConnectionStateChangedEventArgs(int result, bool isConnected, string address)
        {
            Result = result;
            IsConnected = isConnected;
            Address = address;
        }

        internal int Result
        {
            get;
            private set;
        }

        /// <summary>
        /// A value indicating whether this instance is connected.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public bool IsConnected
        {
            get;
            private set;
        }

        /// <summary>
        /// The address.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string Address
        {
            get;
            private set;
        }
    }

    /// <summary>
    /// An extended EventArgs class contains the connection state and the address of the remote Bluetooth device.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class HidDeviceDataReceivedEventArgs : EventArgs
    {
        internal HidDeviceDataReceivedEventArgs(BluetoothHidDeviceReceivedData receivedData)
        {
            ReceivedData = receivedData;
        }

        /// <summary>
        /// The result.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public BluetoothHidDeviceReceivedData ReceivedData
        {
            get;
            private set;
        }
    }

    /// <summary>
    /// An extended EventArgs class contains the changed equalizer state.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class EqualizerStateChangedEventArgs : EventArgs
    {
        private EqualizerState _state;

        internal EqualizerStateChangedEventArgs(EqualizerState state)
        {
            _state = state;
        }

        /// <summary>
        /// The state of the equalizer.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public EqualizerState State
        {
            get
            {
                return _state;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class contains the changed repeat mode.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class RepeatModeChangedEventArgs : EventArgs
    {
        private RepeatMode _mode;

        internal RepeatModeChangedEventArgs(RepeatMode mode)
        {
            _mode = mode;
        }

        /// <summary>
        /// The repeat mode.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public RepeatMode Mode
        {
            get
            {
                return _mode;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class contains the changed shuffle mode.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class ShuffleModeChangedeventArgs : EventArgs
    {
        private ShuffleMode _mode;

        internal ShuffleModeChangedeventArgs(ShuffleMode mode)
        {
            _mode = mode;
        }

        /// <summary>
        /// The shuffle mode.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ShuffleMode Mode
        {
            get
            {
                return _mode;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class contains the changed scan mode.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class ScanModeChangedEventArgs : EventArgs
    {
        private ScanMode _mode;

        internal ScanModeChangedEventArgs(ScanMode mode)
        {
            _mode = mode;
        }

        /// <summary>
        /// The scan mode.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ScanMode Mode
        {
            get
            {
                return _mode;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class contains the connection state and the remote device address.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class TargetConnectionStateChangedEventArgs : EventArgs
    {
        private bool _isConnected;
        private string _address;

        internal TargetConnectionStateChangedEventArgs(bool isConnected, string address)
        {
            _isConnected = isConnected;
            _address = address;
        }

        /// <summary>
        /// A value indicating whether this instance is connected.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool IsConnected
        {
            get
            {
                return _isConnected;
            }
        }

        /// <summary>
        /// The address.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Address
        {
            get
            {
                return _address;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class contains the connection state and the remote device address.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    public class AvrcpControlConnectionChangedEventArgs : EventArgs
    {
        private bool _isConnected;
        string _remoteAddress;
        // Setting Values when Event is invoked
        internal AvrcpControlConnectionChangedEventArgs(bool conn, string address)
        {
            _isConnected = conn;
            _remoteAddress = address;
        }

        /// <summary>
        /// A value indicating whether this instance is connected.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public bool IsConnected
        {
            get
            {
                return _isConnected;
            }
        }

        /// <summary>
        /// The remote address.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public string RemoteAddress
        {
            get
            {
                return _remoteAddress;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class contains the position.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    public class PositionChangedEventArgs : EventArgs
    {
        private uint _pos;
        internal PositionChangedEventArgs(uint pos)
        {
            _pos = pos;
        }

        /// <summary>
        /// The current position in milliseconds.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public uint Position
        {
            get
            {
                return _pos;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class contains the play state.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    public class PlayStateChangedEventArgs : EventArgs
    {
        private PlayerState _playState;
        internal PlayStateChangedEventArgs(PlayerState playState)
        {
            _playState = playState;
        }

        /// <summary>
        /// The current play state.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public PlayerState PlayState
        {
            get
            {
                return _playState;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class contains the play state.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    public class TrackInfoChangedEventArgs : EventArgs
    {
        private Track _track;
        internal TrackInfoChangedEventArgs(Track Data)
        {
            _track = Data;
        }

        /// <summary>
        /// The current track data
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public Track TrackData
        {
            get
            {
                return _track;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class contains the changed Bluetooth LE advertising state changed information.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class AdvertisingStateChangedEventArgs : EventArgs
    {
        private BluetoothLeAdvertisingState _state;
        private int _result;
        private IntPtr _advertiserHandle;

		//TODO : Add conversion code from IntPtr to BluetoothLeAdvertiser class later
        internal AdvertisingStateChangedEventArgs(int result, IntPtr advertiserHandle,
            BluetoothLeAdvertisingState state)
        {
            _result = result;
            _advertiserHandle = advertiserHandle;
            _state = state;
        }

        /// <summary>
        /// The result.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int Result
        {
            get
            {
                return _result;
            }
        }

        /// <summary>
        /// The advertiser handle.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public IntPtr AdvertiserHandle
        {
            get
            {
                return _advertiserHandle;
            }
        }

        /// <summary>
        /// The LE advertising state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public BluetoothLeAdvertisingState State
        {
            get
            {
                return _state;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class contains the changed Bluetooth LE scan result information.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class AdapterLeScanResultChangedEventArgs : EventArgs
    {
        private BluetoothLeDevice _deviceData;
        private BluetoothError _result;

        internal AdapterLeScanResultChangedEventArgs(BluetoothError result, BluetoothLeDevice deviceData)
        {
            _deviceData = deviceData;
            _result = result;
        }

        /// <summary>
        /// The result.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public BluetoothError Result
        {
            get
            {
                return _result;
            }
        }

        /// <summary>
        /// The LE device data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public BluetoothLeDevice DeviceData
        {
            get
            {
                return _deviceData;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class contains the changed Bluetooth LE GATT connection state.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class GattConnectionStateChangedEventArgs : EventArgs
    {
        private bool _isConnected;
        private int _result;
        private string _remoteAddress;

        internal GattConnectionStateChangedEventArgs(int result, bool connected, string remoteAddress)
        {
            _isConnected = connected;
            _result = result;
            _remoteAddress = remoteAddress;
        }

        /// <summary>
        /// The result.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int Result
        {
            get
            {
                return _result;
            }
        }

        /// <summary>
        /// A value indicating whether this instance is connected.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool IsConnected
        {
            get
            {
                return _isConnected;
            }
        }

        /// <summary>
        /// The remote address.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string RemoteAddress
        {
            get
            {
                return _remoteAddress;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class contains the changed attribute value.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class ValueChangedEventArgs : EventArgs
    {
        internal ValueChangedEventArgs(IntPtr value, int len)
        {
            Value = new byte[len];
            unsafe
            {
                for (int i = 0; i < len; i++)
                {
                    Value[i] = *((byte*)value.ToPointer() + i);
                }
            }
        }

        /// <summary>
        /// The attribute value.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public byte[] Value { get; }
    }

    /// <summary>
    /// An extended EventArgs class contains the read value request data.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class ReadRequestedEventArgs : EventArgs
    {
        internal ReadRequestedEventArgs(BluetoothGattServer server, string clientAddress, int requestId, int offset)
        {
            Server = server;
            ClientAddress = clientAddress;
            RequestId = requestId;
            Offset = offset;
        }

        /// <summary>
        /// The GATT server instance.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public BluetoothGattServer Server { get; }
        /// <summary>
        /// The client address.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string ClientAddress { get; }
        /// <summary>
        /// The request identifier.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int RequestId { get; }
        /// <summary>
        /// The offset.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int Offset { get; }
    }

    /// <summary>
    /// An extended EventArgs class contains the read value request data.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class WriteRequestedEventArgs : EventArgs
    {
        internal WriteRequestedEventArgs(BluetoothGattServer server, string clientAddress, int requestId, byte[] value, int offset, bool response_needed)
        {
            Server = server;
            ClientAddress = clientAddress;
            RequestId = requestId;
            Value = value;
            Offset = offset;
            Response_needed = response_needed;
        }

        /// <summary>
        /// The GATT server instance.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public BluetoothGattServer Server { get; }
        /// <summary>
        /// The client address.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string ClientAddress { get; }
        /// <summary>
        /// The request identifier.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int RequestId { get; }
        /// <summary>
        /// The read value.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public byte[] Value { get; }
        /// <summary>
        /// The offset.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int Offset { get; }
        /// <summary>
        /// Indicates whether a response is required by the remote device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool Response_needed { get; }
    }

    /// <summary>
    /// An extended EventArgs class contains the client preference to enable or disable the Notification/Indication.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class NotificationStateChangedEventArg : EventArgs
    {
        internal NotificationStateChangedEventArg(BluetoothGattServer server, bool value)
        {
            Server = server;
            Value = value;
        }

        /// <summary>
        /// The GATT server instance.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public BluetoothGattServer Server { get; }
        /// <summary>
        /// A value indicating whether the notification is enabled.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool Value { get; }
    }

    /// <summary>
    /// An extended EventArgs class contains the read value request data.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class NotificationSentEventArg : EventArgs
    {
        internal NotificationSentEventArg(BluetoothGattServer server, string clientAddress, int result, bool completed)
        {
            Result = result;
            ClientAddress = clientAddress;
            Server = server;
            Completed = completed;
        }

        /// <summary>
        /// The GATT server instance.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public BluetoothGattServer Server { get; internal set; }
        /// <summary>
        /// The client address.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string ClientAddress { get; }
        /// <summary>
        /// The result.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int Result { get; }
        /// <summary>
        /// Gets a value indicating whether the notification sent is completed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool Completed { get; }
    }

    /// <summary>
    /// An extended EventArgs class which contains the connection state and address of the remote Bluetooth device.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class ConnectionRequestedEventArgs : EventArgs
    {
        private string _address;

        internal ConnectionRequestedEventArgs(string address)
        {
            _address = address;
        }

        /// <summary>
        /// The address.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string Address
        {
            get
            {
                return _address;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains the file transfer progress state, file transfer progress by percent.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class TransferProgressEventArgs : EventArgs
    {
        private string _file;
        private long _size;
        private int _percent;

        internal TransferProgressEventArgs(string file, long size, int percent)
        {
            _file = file;
            _size = size;
            _percent = percent;
        }

        /// <summary>
        /// The File name.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string File
        {
            get
            {
                return _file;
            }
        }

        /// <summary>
        /// The File size.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public long Size
        {
            get
            {
                return _size;
            }
        }

        /// <summary>
        /// The File transfer percent.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public int Percent
        {
            get
            {
                return _percent;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains the file transfer finished state and file state.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class TransferFinishedEventArgs : EventArgs
    {
        private string _file;
        private long _size;
        private int _result;

        internal TransferFinishedEventArgs(int result, string file, long size)
        {
            _file = file;
            _size = size;
            _result = result;
        }

        /// <summary>
        /// The File name.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string File
        {
            get
            {
                return _file;
            }
        }

        /// <summary>
        /// The File size.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public long Size
        {
            get
            {
                return _size;
            }
        }

        /// <summary>
        /// The return value.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public int Result
        {
            get
            {
                return _result;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains the Push Request respond state
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class PushRespondedEventArgs : EventArgs
    {
        int _result;
        string _address;

        internal PushRespondedEventArgs(int result, string address)
        {
            _address = address;
            _result = result;
        }

        /// <summary>
        /// The return value.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public int Result
        {
            get
            {
                return _result;
            }
        }

        /// <summary>
        /// The address.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string Address
        {
            get
            {
                return _address;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains the file push progress state, push progress by percent.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class PushProgressEventArgs : EventArgs
    {
        private string _file;
        private long _size;
        private int _percent;

        internal PushProgressEventArgs(string file, long size, int percent)
        {
            _file = file;
            _size = size;
            _percent = percent;
        }

        /// <summary>
        /// The File name.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string File
        {
            get
            {
                return _file;
            }
        }

        /// <summary>
        /// The File size.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public long Size
        {
            get
            {
                return _size;
            }
        }

        /// <summary>
        /// The File transfer percent.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public int Percent
        {
            get
            {
                return _percent;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains the Push Request respond state
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class PushFinishedEventArgs : EventArgs
    {
        int _result;
        string _address;

        internal PushFinishedEventArgs(int result, string address)
        {
            _address = address;
            _result = result;
        }

        /// <summary>
        /// The return value.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public int Result
        {
            get
            {
                return _result;
            }
        }

        /// <summary>
        /// The address.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string Address
        {
            get
            {
                return _address;
            }
        }
    }
}
