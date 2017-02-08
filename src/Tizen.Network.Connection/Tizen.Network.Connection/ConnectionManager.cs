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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

/// <summary>
/// The Connection API provides functions, enumerations to get the status of network and current profile and manage profiles.
/// </summary>
namespace Tizen.Network.Connection
{
    /// <summary>
    /// This class is ConnectionManager. It provides functions to manage data connections.
    /// </summary>
    public static class ConnectionManager
    {
        private static ConnectionItem _currentConnection = null;

        /// <summary>
        /// Event that is called when the type of the current connection is changed.
        /// </summary>
        public static event EventHandler ConnectionTypeChanged
        {
            add
            {
                ConnectionInternalManager.Instance.ConnectionTypeChanged += value;
            }

            remove
            {
                ConnectionInternalManager.Instance.ConnectionTypeChanged -= value;
            }
        }

        /// <summary>
        /// Event for ethernet cable is plugged [in/out] event.
        /// </summary>
        public static event EventHandler EthernetCableStateChanged
        {
            add
            {
                ConnectionInternalManager.Instance.EthernetCableStateChanged += value;
            }

            remove
            {
                ConnectionInternalManager.Instance.EthernetCableStateChanged -= value;
            }
        }

        /// <summary>
        /// Event that is called when the IP address is changed.
        /// </summary>
        public static event EventHandler IpAddressChanged
        {
            add
            {
                ConnectionInternalManager.Instance.IpAddressChanged += value;
            }

            remove
            {
                ConnectionInternalManager.Instance.IpAddressChanged -= value;
            }
        }

        /// <summary>
        /// Event that is called when the proxy address is changed.
        /// </summary>
        public static event EventHandler ProxyAddressChanged
        {
            add
            {
                ConnectionInternalManager.Instance.ProxyAddressChanged += value;
            }

            remove
            {
                ConnectionInternalManager.Instance.ProxyAddressChanged -= value;
            }
        }

        /// <summary>
        /// Gets the IP address of the current connection.
        /// </summary>
        /// <param name="family">The address family</param>
        /// <returns>IP address of the connection.</returns>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation</exception>
        public static string GetIpAddress(AddressFamily family)
        {
            return ConnectionInternalManager.Instance.GetIpAddress(family);
        }

        /// <summary>
        /// Gets the proxy address of the current connection.
        /// </summary>
        /// <param name="family">The address family</param>
        /// <returns>Proxy address of the connection.</returns>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation</exception>
        public static string GetProxy(AddressFamily family)
        {
            return ConnectionInternalManager.Instance.GetProxy(family);
        }

        /// <summary>
        /// Gets the MAC address of the Wi-Fi or ethernet.
        /// </summary>
        /// <param name="type">The type of current network connection</param>
        /// <returns>MAC address of the Wi-Fi or ethernet.</returns>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation</exception>
        public static string GetMacAddress(ConnectionType type)
        {
            return ConnectionInternalManager.Instance.GetMacAddress(type);
        }

        /// <summary>
        /// Type and state of the current profile for data connection
        /// </summary>
        public static ConnectionItem CurrentConnection
        {
            get
            {
                if (_currentConnection == null)
                {
                    _currentConnection = new ConnectionItem();
                }

                return _currentConnection;
            }
        }

        /// <summary>
        /// Creates a cellular profile handle.
        /// </summary>
        /// <param name="type">The type of profile. Cellular profile type is supported.</param>
        /// <param name="keyword">The keyword included in profile name.</param>
        /// <returns>CellularProfile object</returns>
        public static CellularProfile CreateCellularProfile(ConnectionProfileType type, string keyword)
        {
            IntPtr profileHandle = IntPtr.Zero;
            if (type == ConnectionProfileType.Cellular)
            {
                profileHandle = ConnectionInternalManager.Instance.CreateCellularProfile(type, keyword);
            }

            else
            {
                Log.Error(Globals.LogTag, "ConnectionProfile Type is not supported");
                ConnectionErrorFactory.ThrowConnectionException((int)ConnectionError.InvalidParameter);
            }

            return new CellularProfile(profileHandle);
        }

        /// <summary>
        /// The state of cellular connection.
        /// </summary>
        public static CellularState CellularState
        {
            get
            {
                return ConnectionInternalManager.Instance.CellularState;
            }
        }

        /// <summary>
        /// The state of the Wi-Fi.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        public static ConnectionState WiFiState
        {
            get
            {
                return ConnectionInternalManager.Instance.WiFiState;
            }
        }

        /// <summary>
        /// The state of the Bluetooth.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        public static ConnectionState BluetoothState
        {
            get
            {
                return ConnectionInternalManager.Instance.BluetoothState;
            }
        }

        /// <summary>
        /// The Ethernet connection state.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        public static ConnectionState EthernetState
        {
            get
            {
                return ConnectionInternalManager.Instance.EthernetState;
            }
        }

        /// <summary>
        /// Checks for ethernet cable is attached or not.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        public static EthernetCableState EthernetCableState
        {
            get
            {
                return ConnectionInternalManager.Instance.EthernetCableState;
            }
        }

    } // class ConnectionManager

    /// <summary>
    /// This class contains connection information such as connection type and state.
    /// </summary>
    public class ConnectionItem
    {
        internal ConnectionItem()
        {
        }

        /// <summary>
        /// The type of the current profile for data connection.
        /// </summary>
        public ConnectionType Type
        {
            get
            {
                return ConnectionInternalManager.Instance.ConnectionType;
            }
        }

        /// <summary>
        /// The state of the current profile for data connection.
        /// </summary>
        public ConnectionState State
        {
            get
            {
                if (ConnectionInternalManager.Instance.ConnectionType == ConnectionType.Cellular)
                {
                    if (ConnectionInternalManager.Instance.CellularState == CellularState.Connected)
                    {
                        return ConnectionState.Connected;
                    }
                    else if (ConnectionInternalManager.Instance.CellularState == CellularState.Available)
                    {
                        return ConnectionState.Disconnected;
                    }
                    else {
                        return ConnectionState.Deactivated;
                    }
                }
                else if (ConnectionInternalManager.Instance.ConnectionType == ConnectionType.Bluetooth)
                {
                    return ConnectionInternalManager.Instance.BluetoothState;
                }
                else if (ConnectionInternalManager.Instance.ConnectionType == ConnectionType.WiFi)
                {
                    return ConnectionInternalManager.Instance.WiFiState;
                }
                else if (ConnectionInternalManager.Instance.ConnectionType == ConnectionType.Ethernet)
                {
                    return ConnectionInternalManager.Instance.EthernetState;
                }
                else { // TO DO : Add Net Proxy
                    return ConnectionState.Disconnected;
                }
            }
        }
    } // class ConnectionItem

    /// <summary>
    /// An extended EventArgs class which contains changed connection type.
    /// </summary>
    public class ConnectionTypeEventArgs : EventArgs
    {
        private ConnectionType Type = ConnectionType.Disconnected;

        internal ConnectionTypeEventArgs(ConnectionType type)
        {
            Type = type;
        }

        /// <summary>
        /// The connection type.
        /// </summary>
        public ConnectionType ConnectionType
        {
            get
            {
                return Type;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains changed ethernet cable state.
    /// </summary>
    public class EthernetCableStateEventArgs : EventArgs
    {
        private EthernetCableState State;

        internal EthernetCableStateEventArgs(EthernetCableState state)
        {
            State = state;
        }

        /// <summary>
        /// The ethernet cable state.
        /// </summary>
        public EthernetCableState EthernetCableState
        {
            get
            {
                return State;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class which contains changed address.
    /// </summary>
    public class AddressEventArgs : EventArgs
    {
        private string Ipv4 = "";
        private string Ipv6 = "";

        internal AddressEventArgs(string ipv4, string ipv6)
        {
            Ipv4 = ipv4;
            Ipv6 = ipv6;
        }

        /// <summary>
        /// The  IPV4 address.
        /// </summary>
        public string Ipv4Address
        {
            get
            {
                return Ipv4;
            }
        }

        /// <summary>
        /// The  IPV6 address.
        /// </summary>
        public string Ipv6Address
        {
            get
            {
                return Ipv6;
            }
        }
    }
}
