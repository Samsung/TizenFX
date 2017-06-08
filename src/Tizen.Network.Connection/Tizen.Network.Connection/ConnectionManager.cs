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
    /// This class manages the connection handle resources.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public sealed class SafeConnectionHandle : SafeHandle
    {
        internal SafeConnectionHandle(IntPtr handle) : base(handle, true)
        {
        }

        /// <summary>
        /// Checks whether the handle value is valid or not.
        /// </summary>
        /// <value>True if the handle is invalid, otherwise false.</value>
        public override bool IsInvalid
        {
            get
            {
                return this.handle == IntPtr.Zero;
            }
        }

        /// <summary>
        /// Frees the handle.
        /// </summary>
        /// <returns>True if the handle is released successfully, otherwise false.</returns>
        protected override bool ReleaseHandle()
        {
            this.SetHandle(IntPtr.Zero);
            return true;
        }
    }

    /// <summary>
    /// This class is ConnectionManager. It provides functions to manage data connections.
    /// </summary>
    public static class ConnectionManager
    {
        private static ConnectionItem _currentConnection = null;

        /// <summary>
        /// Event that is called when the type of the current connection is changed.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <feature>http://tizen.org/feature/network.ethernet</feature>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <feature>http://tizen.org/feature/network.tethering.bluetooth</feature>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
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
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <feature>http://tizen.org/feature/network.ethernet</feature>
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
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <feature>http://tizen.org/feature/network.ethernet</feature>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <feature>http://tizen.org/feature/network.tethering.bluetooth</feature>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
        public static event EventHandler IPAddressChanged
        {
            add
            {
                ConnectionInternalManager.Instance.IPAddressChanged += value;
            }

            remove
            {
                ConnectionInternalManager.Instance.IPAddressChanged -= value;
            }
        }

        /// <summary>
        /// Event that is called when the proxy address is changed.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <feature>http://tizen.org/feature/network.ethernet</feature>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <feature>http://tizen.org/feature/network.tethering.bluetooth</feature>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
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
        /// Gets the connection handle.
        /// </summary>
        /// <returns>Instance of SafeConnectionHandle</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SafeConnectionHandle GetConnectionHandle()
        {
            IntPtr handle = ConnectionInternalManager.Instance.GetHandle();
            return new SafeConnectionHandle(handle);
        }

        /// <summary>
        /// Gets the IP address of the current connection.
        /// </summary>
        /// <param name="family">The address family</param>
        /// <returns>IP address of the connection (global address in case of IPv6).</returns>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <feature>http://tizen.org/feature/network.ethernet</feature>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <feature>http://tizen.org/feature/network.tethering.bluetooth</feature>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when permission is denied.</exception>
        /// <exception cref="System.ArgumentException">Thrown when value is invalid parameter.</exception>
        /// <exception cref="System.OutOfMemoryException">Thrown when memory is not enough to continue execution.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when connection instance is invalid or when method failed due to invalid operation.</exception>
        public static System.Net.IPAddress GetIPAddress(AddressFamily family)
        {
            return ConnectionInternalManager.Instance.GetIPAddress(family);
        }

        /// <summary>
        /// Gets the all IPv6 addresses of the current connection.
        /// </summary>
        /// <param name="type">The type of current network connection</param>
        /// <returns>A list of IPv6 addresses of the connection.</returns>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <feature>http://tizen.org/feature/network.ethernet</feature>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <feature>http://tizen.org/feature/network.tethering.bluetooth</feature>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when permission is denied.</exception>
        /// <exception cref="System.ArgumentException">Thrown when value is invalid parameter.</exception>
        /// <exception cref="System.OutOfMemoryException">Thrown when memory is not enough to continue execution.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when connection instance is invalid or when method failed due to invalid operation.</exception>
        public static IEnumerable<System.Net.IPAddress> GetAllIPv6Addresses(ConnectionType type)
        {
            return ConnectionInternalManager.Instance.GetAllIPv6Addresses(type);
        }

        /// <summary>
        /// Gets the proxy address of the current connection.
        /// </summary>
        /// <param name="family">The address family</param>
        /// <returns>Proxy address of the connection.</returns>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <feature>http://tizen.org/feature/network.ethernet</feature>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <feature>http://tizen.org/feature/network.tethering.bluetooth</feature>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when permission is denied.</exception>
        /// <exception cref="System.ArgumentException">Thrown when value is invalid parameter.</exception>
        /// <exception cref="System.OutOfMemoryException">Thrown when memory is not enough to continue execution.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when connection instance is invalid or when method failed due to invalid operation.</exception>
        public static string GetProxy(AddressFamily family)
        {
            return ConnectionInternalManager.Instance.GetProxy(family);
        }

        /// <summary>
        /// Gets the MAC address of the Wi-Fi or ethernet.
        /// </summary>
        /// <param name="type">The type of current network connection</param>
        /// <returns>MAC address of the Wi-Fi or ethernet.</returns>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <feature>http://tizen.org/feature/network.ethernet</feature>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <feature>http://tizen.org/feature/network.tethering.bluetooth</feature>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when permission is denied.</exception>
        /// <exception cref="System.ArgumentException">Thrown when value is invalid parameter.</exception>
        /// <exception cref="System.OutOfMemoryException">Thrown when memory is not enough to continue execution.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when connection instance is invalid or when method failed due to invalid operation.</exception>
        public static string GetMacAddress(ConnectionType type)
        {
            return ConnectionInternalManager.Instance.GetMacAddress(type);
        }

        /// <summary>
        /// Gets the statistics information.
        /// </summary>
        /// <param name="connectionType">The type of connection (only WiFi and Cellular are supported)</param>
        /// <param name="statisticsType">The type of statistics</param>
        /// <returns>The statistics information associated with statisticsType</returns>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <feature>http://tizen.org/feature/network.ethernet</feature>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <feature>http://tizen.org/feature/network.tethering.bluetooth</feature>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when permission is denied.</exception>
        /// <exception cref="System.ArgumentException">Thrown when value is invalid parameter.</exception>
        /// <exception cref="System.OutOfMemoryException">Thrown when memory is not enough to continue execution.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when connection instance is invalid or when method failed due to invalid operation.</exception>
        public static long GetStatistics(ConnectionType connectionType, StatisticsType statisticsType)
        {
            return ConnectionInternalManager.Instance.GetStatistics(connectionType, statisticsType);
        }

        /// <summary>
        /// Resets the statistics information.
        /// </summary>
        /// <param name="connectionType">The type of connection (only WiFi and Cellular are supported)</param>
        /// <param name="statisticsType">The type of statistics</param>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <privilege>http://tizen.org/privilege/network.set</privilege>
        /// <feature>http://tizen.org/feature/network.ethernet</feature>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <feature>http://tizen.org/feature/network.tethering.bluetooth</feature>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when permission is denied.</exception>
        /// <exception cref="System.ArgumentException">Thrown when value is invalid parameter.</exception>
        /// <exception cref="System.OutOfMemoryException">Thrown when memory is not enough to continue execution.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when connection instance is invalid or when method failed due to invalid operation.</exception>
        public static void ResetStatistics(ConnectionType connectionType, StatisticsType statisticsType)
        {
            ConnectionInternalManager.Instance.ResetStatistics(connectionType, statisticsType);
        }

        /// <summary>
        /// Type and state of the current profile for data connection
        /// </summary>
        /// <value>Instance of ConnectionItem</value>
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
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
        /// <exception cref="System.NotSupportedException">Thrown when feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when permission is denied.</exception>
        /// <exception cref="System.ArgumentException">Thrown when value is invalid parameter.</exception>
        /// <exception cref="System.ArgumentNullException">Thrown when keyword value is null.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when method failed due to invalid operation.</exception>
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
        /// <value>Cellular network state.</value>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
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
        /// <value>WiFi connection state.</value>
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
        /// <value>Bluetooth connection state.</value>
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
        /// <value>Ethernet connection state.</value>
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
        /// <value>Ethernet cable state.</value>
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
        /// <value>Data connection current profile.</value>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
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
        /// <value>Connection state of the current connection type.</value>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
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
        /// <value>Type of the connection.</value>
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
        /// <value>Attached or detached state of the ethernet cable.</value>
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
        private string IPv4 = "";
        private string IPv6 = "";

        internal AddressEventArgs(string ipv4, string ipv6)
        {
            IPv4 = ipv4;
            IPv6 = ipv6;
        }

        /// <summary>
        /// The  IPV4 address.
        /// </summary>
        /// <value>IP address in the format of IPV4 syntax.</value>
        public string IPv4Address
        {
            get
            {
                return IPv4;
            }
        }

        /// <summary>
        /// The  IPV6 address.
        /// </summary>
        /// <value>IP address in the format of IPV6 syntax.</value>
        public string IPv6Address
        {
            get
            {
                return IPv6;
            }
        }
    }
}
