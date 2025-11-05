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
    /// This event is triggered when the connection state with a specific peer device changes.
    /// </summary>
    /// <remarks>
    /// This event is raised by the <see cref="WiFiDirectPeer.ConnectionStateChanged"/> event.
    /// Use this event to monitor connection progress and handle connection state changes such as:
    /// - Connection request initiated
    /// - WPS (Wi-Fi Protected Setup) in progress
    /// - Connection established
    /// - Disconnection initiated or completed
    /// - Group creation/destruction events
    ///
    /// Example usage:
    /// <code>
    /// peer.ConnectionStateChanged += (sender, e) =>
    /// {
    ///     if (e.Error == WiFiDirectError.None)
    ///     {
    ///         switch (e.State)
    ///         {
    ///             case WiFiDirectConnectionState.ConnectionRsp:
    ///                 Console.WriteLine($"Connected to peer: {e.MacAddress}");
    ///                 break;
    ///             case WiFiDirectConnectionState.DisconnectRsp:
    ///                 Console.WriteLine($"Disconnected from peer: {e.MacAddress}");
    ///                 break;
    ///         }
    ///     }
    ///     else
    ///     {
    ///         Console.WriteLine($"Connection error: {e.Error}");
    ///     }
    /// };
    /// </code>
    /// </remarks>
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
        /// The Wi-Fi Direct operation result.
        /// Indicates whether the state change was successful or if an error occurred.
        /// </summary>
        /// <value>
        /// <see cref="WiFiDirectError.None"/> if successful, otherwise the specific error code.
        /// </value>
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
        /// Represents the current state in the connection lifecycle.
        /// </summary>
        /// <value>
        /// A <see cref="WiFiDirectConnectionState"/> enum value indicating the current connection state.
        /// </value>
        /// <since_tizen> 3 </since_tizen>
        public WiFiDirectConnectionState State
        {
            get
            {
                return _state;
            }
        }

        /// <summary>
        /// The MAC address of the peer device whose connection state changed.
        /// This uniquely identifies the peer device in the connection event.
        /// </summary>
        /// <value>
        /// The MAC address string of the peer device (e.g., "AA:BB:CC:DD:EE:FF").
        /// </value>
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
    /// This event is triggered when a peer device successfully connects to a Wi-Fi Direct group and receives IP address assignment.
    /// </summary>
    /// <remarks>
    /// This event is raised by the <see cref="WiFiDirectPeer.IpAddressAssigned"/> event.
    /// Use this event to get network configuration information when a peer joins the group:
    /// - MAC address for device identification
    /// - Assigned IP address for network communication
    /// - Network interface address for routing
    ///
    /// Example usage:
    /// <code>
    /// peer.IpAddressAssigned += (sender, e) =>
    /// {
    ///     Console.WriteLine($"Peer {e.MacAddress} assigned IP: {e.IpAddress}");
    ///     Console.WriteLine($"Interface: {e.InterfaceAddress}");
    ///
    ///     // Now you can establish network communication with the peer
    ///     // using the assigned IP address
    /// };
    /// </code>
    /// </remarks>
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
        /// The MAC address of the connected peer device.
        /// This uniquely identifies the peer device that received the IP assignment.
        /// </summary>
        /// <value>
        /// The MAC address string of the peer device (e.g., "AA:BB:CC:DD:EE:FF").
        /// </value>
        /// <since_tizen> 3 </since_tizen>
        public string MacAddress
        {
            get
            {
                return _macAddress;
            }
        }

        /// <summary>
        /// The IP address assigned to the connected peer device.
        /// This is the network address that can be used for socket communication with the peer.
        /// </summary>
        /// <value>
        /// The IP address string (e.g., "192.168.49.2").
        /// </value>
        /// <since_tizen> 3 </since_tizen>
        public string IpAddress
        {
            get
            {
                return _ipAddress;
            }
        }

        /// <summary>
        /// The network interface address of the connected peer device.
        /// This is the network interface identifier used for routing and network configuration.
        /// </summary>
        /// <value>
        /// The network interface address string (e.g., "AA:BB:CC:DD:EE:FF").
        /// </value>
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
    /// This event is triggered when a new Wi-Fi Direct peer device is discovered during the scanning process.
    /// </summary>
    /// <remarks>
    /// This event is raised by the <see cref="WiFiDirectManager.PeerFound"/> event.
    /// Use this event to get information about newly discovered peer devices and decide whether to connect to them:
    /// - Peer device information (name, MAC address, device type)
    /// - Discovery state indicating the phase of discovery
    /// - Error status for the discovery operation
    ///
    /// Example usage:
    /// <code>
    /// WiFiDirectManager.PeerFound += (sender, e) =>
    /// {
    ///     if (e.Error == WiFiDirectError.None && e.DiscoveryState == WiFiDirectDiscoveryState.Found)
    ///     {
    ///         Console.WriteLine($"Found peer: {e.Peer.Name}");
    ///         Console.WriteLine($"MAC: {e.Peer.MacAddress}");
    ///         Console.WriteLine($"Device type: {e.Peer.PrimaryType}");
    ///
    ///         // Optionally connect to the peer
    ///         if (ShouldConnectToPeer(e.Peer))
    ///         {
    ///             e.Peer.Connect();
    ///         }
    ///     }
    /// };
    /// </code>
    /// </remarks>
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
        /// The Wi-Fi Direct discovery operation result.
        /// Indicates whether the peer discovery was successful or if an error occurred.
        /// </summary>
        /// <value>
        /// <see cref="WiFiDirectError.None"/> if successful, otherwise the specific error code.
        /// </value>
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
        /// Indicates the current phase of the discovery process when this peer was found.
        /// </summary>
        /// <value>
        /// A <see cref="WiFiDirectDiscoveryState"/> enum value indicating the discovery state.
        /// </value>
        /// <since_tizen> 3 </since_tizen>
        public WiFiDirectDiscoveryState DiscoveryState
        {
            get
            {
                return _state;
            }
        }

        /// <summary>
        /// The discovered peer device object.
        /// Contains detailed information about the found peer including name, MAC address, device capabilities, and connection methods.
        /// </summary>
        /// <value>
        /// A <see cref="WiFiDirectPeer"/> object representing the discovered device.
        /// </value>
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
    /// This event is triggered for global connection status changes that affect the entire Wi-Fi Direct group or all connected peers.
    /// </summary>
    /// <remarks>
    /// This event is raised by the <see cref="WiFiDirectManager.ConnectionStatusChanged"/> event.
    /// Use this event to monitor global connection status changes such as:
    /// - Group creation and destruction
    /// - Disconnection of all peers
    /// - Group owner changes
    /// - Auto-group removal events
    ///
    /// Example usage:
    /// <code>
    /// WiFiDirectManager.ConnectionStatusChanged += (sender, e) =>
    /// {
    ///     if (e.Error == WiFiDirectError.None)
    ///     {
    ///         switch (e.ConnectionState)
    ///         {
    ///             case WiFiDirectConnectionState.GroupCreated:
    ///                 Console.WriteLine("Wi-Fi Direct group created successfully");
    ///                 break;
    ///             case WiFiDirectConnectionState.GroupDestroyed:
    ///                 Console.WriteLine("Wi-Fi Direct group destroyed");
    ///                 break;
    ///             case WiFiDirectConnectionState.DisconnectionInd:
    ///                 Console.WriteLine("All peers disconnected");
    ///                 break;
    ///         }
    ///     }
    ///     else
    ///     {
    ///         Console.WriteLine($"Connection status error: {e.Error}");
    ///     }
    /// };
    /// </code>
    /// </remarks>
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
        /// The Wi-Fi Direct operation result.
        /// Indicates whether the connection status change was successful or if an error occurred.
        /// </summary>
        /// <value>
        /// <see cref="WiFiDirectError.None"/> if successful, otherwise the specific error code.
        /// </value>
        /// <since_tizen> 3 </since_tizen>
        public WiFiDirectError Error
        {
            get
            {
                return _error;
            }
        }

        /// <summary>
        /// The global connection state.
        /// Represents the overall connection status affecting the Wi-Fi Direct group or all peers.
        /// </summary>
        /// <value>
        /// A <see cref="WiFiDirectConnectionState"/> enum value indicating the global connection state.
        /// </value>
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
