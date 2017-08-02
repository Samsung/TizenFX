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

namespace Tizen.Network.Bluetooth
{
    /// <summary>
    /// An extended EventArgs class which contains changed Bluetooth state.
    /// </summary>
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
        public BluetoothError Result
        {
            get
            {
                return _result;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains changed Bluetooth name.
    /// </summary>
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
        public string DeviceName
        {
            get
            {
                return _name;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains changed Bluetooth visibility mode.
    /// </summary>
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
        public BluetoothError Result
        {
            get
            {
                return _result;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains the duration until the visibility mode is changed from TimeLimitedDiscoverable to NonDiscoverable.
    /// </summary>
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
        public int Duration
        {
            get
            {
                return _duration;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains changed Bluetooth device discovery state and the discovered device information.
    /// </summary>
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
        public BluetoothDevice DeviceFound
        {
            get
            {
                return _device;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains the bonded device information.
    /// </summary>
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
        public BluetoothDevice Device
        {
            get
            {
                return _device;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains the address of the remote Bluetooth device to destroy bond with.
    /// </summary>
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
        public string DeviceAddress
        {
            get
            {
                return _address;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains the authorization state and address of the remote Bluetooth device.
    /// </summary>
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
        public string DeviceAddress
        {
            get
            {
                return _address;
            }
        }

    }

    /// <summary>
    /// An extended EventArgs class which contains the service lists found on the remote Bluetooth device.
    /// </summary>
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
        public BluetoothDeviceSdpData SdpData
        {
            get
            {
                return _sdpData;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains the connection state and connection information of the remote device.
    /// </summary>
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
        public bool IsConnected
        {
            get
            {
                return _isConnected;
            }
        }

        /// <summary>
        /// The device connection data.
        /// </summary>
        public BluetoothDeviceConnectionData ConnectionData
        {
            get
            {
                return _connectionData;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains data received information.
    /// </summary>
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
        public SocketData Data
        {
            get
            {
                return _data;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains changed connection state.
    /// </summary>
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
        public SocketConnection Connection
        {
            get
            {
                return _connection;
            }
        }
    }

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
        public IBluetoothServerSocket Server
        {
            get
            {
                return _server;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains the connection state,remote address and the type of audio profile.
    /// </summary>
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
        public BluetoothAudioProfileType ProfileType
        {
            get
            {
                return _type;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains the connection state and address of the remote Bluetooth device.
    /// </summary>
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
        public string Address
        {
            get
            {
                return _address;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains the changed equalizer state.
    /// </summary>
    public class EqualizerStateChangedEventArgs : EventArgs
    {
        private EqualizerState _state;

        internal EqualizerStateChangedEventArgs(EqualizerState state)
        {
            _state = state;
        }

        /// <summary>
        /// The state of equalizer.
        /// </summary>
        public EqualizerState State
        {
            get
            {
                return _state;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains the changed repeat mode.
    /// </summary>
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
        public RepeatMode Mode
        {
            get
            {
                return _mode;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains the changed shuffle mode.
    /// </summary>
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
        public ShuffleMode Mode
        {
            get
            {
                return _mode;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains the changed scan mode.
    /// </summary>
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
        public ScanMode Mode
        {
            get
            {
                return _mode;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains the connection state and the remote device address.
    /// </summary>
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
        public string Address
        {
            get
            {
                return _address;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains changed Bluetooth LE advertising state changed information.
    /// </summary>
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
        public IntPtr AdvertiserHandle
        {
            get
            {
                return _advertiserHandle;
            }
        }

        /// <summary>
        /// The Le advertising state.
        /// </summary>
        public BluetoothLeAdvertisingState State
        {
            get
            {
                return _state;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains changed Bluetooth LE scan result information.
    /// </summary>
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
        public BluetoothError Result
        {
            get
            {
                return _result;
            }
        }

        /// <summary>
        /// The Le device data.
        /// </summary>
        public BluetoothLeDevice DeviceData
        {
            get
            {
                return _deviceData;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains changed Bluetooth LE GATT connection state.
    /// </summary>
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
        public string RemoteAddress
        {
            get
            {
                return _remoteAddress;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains changed attribute value.
    /// </summary>
    public class ValueChangedEventArgs : EventArgs
    {
        internal ValueChangedEventArgs(byte[] value)
        {
            Value = value;
        }

        /// <summary>
        /// The attribute value.
        /// </summary>
        public byte[] Value { get; }
    }

    /// <summary>
    /// An extended EventArgs class which contains read value request data.
    /// </summary>
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
        /// The gatt server instance.
        /// </summary>
        public BluetoothGattServer Server { get; }
        /// <summary>
        /// The client address.
        /// </summary>
        public string ClientAddress { get; }
        /// <summary>
        /// The request identifier.
        /// </summary>
        public int RequestId { get; }
        /// <summary>
        /// The offset.
        /// </summary>
        public int Offset { get; }
    }

    /// <summary>
    /// An extended EventArgs class which contains read value request data.
    /// </summary>
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
        /// The gatt server instance.
        /// </summary>
        public BluetoothGattServer Server { get; }
        /// <summary>
        /// The client address.
        /// </summary>
        public string ClientAddress { get; }
        /// <summary>
        /// The request identifier.
        /// </summary>
        public int RequestId { get; }
        /// <summary>
        /// The read value.
        /// </summary>
        public byte[] Value { get; }
        /// <summary>
        /// The offset.
        /// </summary>
        public int Offset { get; }
        /// <summary>
        /// Indicates whether a response is required by the remote device.
        /// </summary>
        public bool Response_needed { get; }
    }

    /// <summary>
    /// An extended EventArgs class which contains client preference to enables or disables the Notification/Indication.
    /// </summary>
    public class NotificationStateChangedEventArg : EventArgs
    {
        internal NotificationStateChangedEventArg(BluetoothGattServer server, bool value)
        {
            Server = server;
            Value = value;
        }

        /// <summary>
        /// The gatt server instance.
        /// </summary>
        public BluetoothGattServer Server { get; }
        /// <summary>
        /// A value indicating whether the notification is enabled
        /// </summary>
        public bool Value { get; }
    }

    /// <summary>
    /// An extended EventArgs class which contains read value request data.
    /// </summary>
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
        /// The gatt server instance.
        /// </summary>
        public BluetoothGattServer Server { get; }
        /// <summary>
        /// The client address.
        /// </summary>
        public string ClientAddress { get; }
        /// <summary>
        /// The result.
        /// </summary>
        public int Result { get; }
        /// <summary>
        /// Gets a value indicating whether notification sent is completed.
        /// </summary>
        public bool Completed { get; }
    }
}
