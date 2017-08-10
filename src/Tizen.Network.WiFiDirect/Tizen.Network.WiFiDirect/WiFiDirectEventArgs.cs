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

namespace Tizen.Network.WiFiDirect
{
    /// <summary>
    /// An extended EventArgs class which contains changed connection state during connecting or disconnecting peer device.
    /// </summary>
    public class ConnectionStateChangedEventArgs : EventArgs
    {
        private WiFiDirectError _error;
        private WiFiDirectConnectionState _state;
        private string _macAddress;

        internal ConnectionStateChangedEventArgs(WiFiDirectError error, WiFiDirectConnectionState state, string macAddress)
        {
            _error = error;
            _state = state;
            _macAddress = macAddress;
        }

        /// <summary>
        /// Wi-Fi Direct result.
        /// </summary>
        public WiFiDirectError Error
        {
            get
            {
                return _error;
            }
        }

        /// <summary>
        /// Wi-Fi Direct connection state of peer.
        /// </summary>
        public WiFiDirectConnectionState State
        {
            get
            {
                return _state;
            }
        }

        /// <summary>
        /// MacAddress of peer.
        /// </summary>
        public string MacAddress
        {
            get
            {
                return _macAddress;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains address properties of the peer when it connects to a group owner.
    /// </summary>
    public class IpAddressAssignedEventArgs : EventArgs
    {
        private string _macAddress;
        private string _ipAddress;
        private string _interfaceAddress;

        internal IpAddressAssignedEventArgs(string macAddress, string ipAddress, string interfaceAddress)
        {
            _macAddress = macAddress;
            _ipAddress = ipAddress;
            _interfaceAddress = interfaceAddress;
        }

        /// <summary>
        /// MacAddress of connected peer.
        /// </summary>
        public string MacAddress
        {
            get
            {
                return _macAddress;
            }
        }

        /// <summary>
        /// IpAddress of connected peer.
        /// </summary>
        public string IpAddress
        {
            get
            {
                return _ipAddress;
            }
        }

        /// <summary>
        /// InterfaceAddress of connected peer.
        /// </summary>
        public string InterfaceAddress
        {
            get
            {
                return _interfaceAddress;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains changed Wi-Fi Direct state of local device.
    /// </summary>
    public class StateChangedEventArgs : EventArgs
    {
        private WiFiDirectState _state;

        internal StateChangedEventArgs(WiFiDirectState state)
        {
            _state = state;
        }

        /// <summary>
        /// Wi-Fi Direct state.
        /// </summary>
        public WiFiDirectState State
        {
            get
            {
                return _state;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains changed Wi-Fi Direct discovery state during Wi-Fi Direct scan operation.
    /// </summary>
    public class DiscoveryStateChangedEventArgs : EventArgs
    {
        private WiFiDirectError _error;
        private WiFiDirectDiscoveryState _state;

        internal DiscoveryStateChangedEventArgs(WiFiDirectError error, WiFiDirectDiscoveryState state)
        {
            _error = error;
            _state = state;
        }

        /// <summary>
        /// Wi-Fi Direct result.
        /// </summary>
        public WiFiDirectError Error
        {
            get
            {
                return _error;
            }
        }

        /// <summary>
        /// Wi-Fi Direct Discovery state.
        /// </summary>
        public WiFiDirectDiscoveryState DiscoveryState
        {
            get
            {
                return _state;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains found peer information during Wi-Fi Direct scan operation.
    /// </summary>
    public class PeerFoundEventArgs : EventArgs
    {
        private WiFiDirectError _error;
        private WiFiDirectDiscoveryState _state;
        private WiFiDirectPeer _peer;

        internal PeerFoundEventArgs(WiFiDirectError error, WiFiDirectDiscoveryState state, WiFiDirectPeer peer)
        {
            _error = error;
            _state = state;
            _peer = peer;
        }

        /// <summary>
        /// Wi-Fi Direct result.
        /// </summary>
        public WiFiDirectError Error
        {
            get
            {
                return _error;
            }
        }

        /// <summary>
        /// Wi-Fi Direct Discovery state.
        /// </summary>
        public WiFiDirectDiscoveryState DiscoveryState
        {
            get
            {
                return _state;
            }
        }

        /// <summary>
        /// Found peer.
        /// </summary>
        public WiFiDirectPeer Peer
        {
            get
            {
                return _peer;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains changed device state during activation or deactivation.
    /// </summary>
    public class DeviceStateChangedEventArgs : EventArgs
    {
        private WiFiDirectError _error;
        private WiFiDirectDeviceState  _state;

        internal DeviceStateChangedEventArgs(WiFiDirectError error, WiFiDirectDeviceState state)
        {
            _error = error;
            _state = state;
        }

        /// <summary>
        /// Wi-Fi Direct result.
        /// </summary>
        public WiFiDirectError Error
        {
            get
            {
                return _error;
            }
        }

        /// <summary>
        /// State of the device.
        /// </summary>
        public WiFiDirectDeviceState DeviceState
        {
            get
            {
                return _state;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains changed service information during service discovery.
    /// </summary>
    public class ServiceStateChangedEventArgs : EventArgs
    {
        private WiFiDirectError _error;
        private WiFiDirectServiceDiscoveryState _state;
        private WiFiDirectServiceType _type;
        private string _response;
        private WiFiDirectPeer _peer;

        internal ServiceStateChangedEventArgs(WiFiDirectError error, WiFiDirectServiceDiscoveryState state, WiFiDirectServiceType type, string response, WiFiDirectPeer peer)
        {
            _error = error;
            _state = state;
            _type = type;
            _response = response;
            _peer = peer;
        }

        /// <summary>
        /// Wi-Fi Direct result.
        /// </summary>
        public WiFiDirectError Error
        {
            get
            {
                return _error;
            }
        }

        /// <summary>
        /// Service discovery state.
        /// </summary>
        public WiFiDirectServiceDiscoveryState ServiceDiscoveryState
        {
            get
            {
                return _state;
            }
        }

        /// <summary>
        /// Types of service.
        /// </summary>
        public WiFiDirectServiceType ServiceType
        {
            get
            {
                return _type;
            }
        }

        /// <summary>
        /// Received response.
        /// </summary>
        public string Response
        {
            get
            {
                return _response;
            }
        }

        /// <summary>
        /// Peer servicing device.
        /// </summary>
        public WiFiDirectPeer Peer
        {
            get
            {
                return _peer;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains changed connection state during disconnect all peers or group related operations.
    /// </summary>
    public class ConnectionStatusChangedEventArgs : EventArgs
    {
        private WiFiDirectError _error;
        private WiFiDirectConnectionState _state;

        internal ConnectionStatusChangedEventArgs(WiFiDirectError error, WiFiDirectConnectionState state)
        {
            _error = error;
            _state = state;
        }

        /// <summary>
        /// Wi-Fi Direct result.
        /// </summary>
        public WiFiDirectError Error
        {
            get
            {
                return _error;
            }
        }

        /// <summary>
        /// Connection state.
        /// </summary>
        public WiFiDirectConnectionState ConnectionState
        {
            get
            {
                return _state;
            }
        }
    }
}
