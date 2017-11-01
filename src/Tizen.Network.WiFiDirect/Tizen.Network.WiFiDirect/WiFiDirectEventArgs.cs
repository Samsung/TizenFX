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
    /// An extended EventArgs class which contains the changed connection state during connecting or disconnecting the peer device.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
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
        /// The Wi-Fi Direct result.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public WiFiDirectError Error
        {
            get
            {
                return _error;
            }
        }

        /// <summary>
        /// The Wi-Fi Direct connection state of the peer.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public WiFiDirectConnectionState State
        {
            get
            {
                return _state;
            }
        }

        /// <summary>
        /// The MacAddress of the peer.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
    /// <since_tizen> 3 </since_tizen>
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
        /// The MacAddress of the connected peer.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string MacAddress
        {
            get
            {
                return _macAddress;
            }
        }

        /// <summary>
        /// The IpAddress of the connected peer.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string IpAddress
        {
            get
            {
                return _ipAddress;
            }
        }

        /// <summary>
        /// The InterfaceAddress of the connected peer.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string InterfaceAddress
        {
            get
            {
                return _interfaceAddress;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains the changed Wi-Fi Direct state of the local device.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class StateChangedEventArgs : EventArgs
    {
        private WiFiDirectState _state;

        internal StateChangedEventArgs(WiFiDirectState state)
        {
            _state = state;
        }

        /// <summary>
        /// The Wi-Fi Direct state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public WiFiDirectState State
        {
            get
            {
                return _state;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains the changed Wi-Fi Direct discovery state during the Wi-Fi Direct scan operation.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
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
        /// The Wi-Fi Direct result.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public WiFiDirectError Error
        {
            get
            {
                return _error;
            }
        }

        /// <summary>
        /// The Wi-Fi Direct discovery state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public WiFiDirectDiscoveryState DiscoveryState
        {
            get
            {
                return _state;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains the found peer information during the Wi-Fi Direct scan operation.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
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
        /// The Wi-Fi Direct result.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public WiFiDirectError Error
        {
            get
            {
                return _error;
            }
        }

        /// <summary>
        /// The Wi-Fi Direct discovery state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public WiFiDirectDiscoveryState DiscoveryState
        {
            get
            {
                return _state;
            }
        }

        /// <summary>
        /// The found peer.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public WiFiDirectPeer Peer
        {
            get
            {
                return _peer;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains the changed device state during activation or deactivation.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
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
        /// The Wi-Fi Direct result.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public WiFiDirectError Error
        {
            get
            {
                return _error;
            }
        }

        /// <summary>
        /// The state of the device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public WiFiDirectDeviceState DeviceState
        {
            get
            {
                return _state;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains the changed service information during the service discovery.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
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
        /// The Wi-Fi Direct result.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public WiFiDirectError Error
        {
            get
            {
                return _error;
            }
        }

        /// <summary>
        /// The service discovery state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public WiFiDirectServiceDiscoveryState ServiceDiscoveryState
        {
            get
            {
                return _state;
            }
        }

        /// <summary>
        /// The types of service.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public WiFiDirectServiceType ServiceType
        {
            get
            {
                return _type;
            }
        }

        /// <summary>
        /// The received response.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Response
        {
            get
            {
                return _response;
            }
        }

        /// <summary>
        /// The peer servicing device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public WiFiDirectPeer Peer
        {
            get
            {
                return _peer;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains the changed connection state during disconnecting of all peers or grouping related operations.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
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
        /// The Wi-Fi Direct result.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public WiFiDirectError Error
        {
            get
            {
                return _error;
            }
        }

        /// <summary>
        /// The connection state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public WiFiDirectConnectionState ConnectionState
        {
            get
            {
                return _state;
            }
        }
    }
}
