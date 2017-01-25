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
    /// This class is ConnectionManager
    /// </summary>
    public partial class ConnectionManager : IDisposable
    {
        private ConnectionInternalManager _internalManager = null;
        private ConnectionItem _currentConnection = null;
        private bool disposed = false;

        private EventHandler _ConnectionTypeChanged = null;
        private EventHandler _IPAddressChanged = null;
        private EventHandler _EthernetCableStateChanged = null;
        private EventHandler _ProxyAddressChanged = null;

        private Interop.Connection.ConnectionAddressChangedCallback _connectionAddressChangedCallback;
        private Interop.Connection.ConnectionTypeChangedCallback _connectionTypeChangedCallback;
        private Interop.Connection.ConnectionAddressChangedCallback _proxyAddressChangedCallback;

        public ConnectionManager()
        {
            _internalManager = new ConnectionInternalManager();
            _currentConnection = new ConnectionItem(_internalManager);
        }

        ~ConnectionManager()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            Log.Debug(Globals.LogTag, ">>> ConnectionManager Dispose with disposing " + disposing + ", disposed " + disposed);
            if (disposed)
                return;

            if (disposing)
            {
                // Free managed objects.
                UnregisterEvents();
                _internalManager.Dispose();
            }
            disposed = true;
        }

        /// <summary>
        /// Event that is called when the type of the current connection is changed.
        /// </summary>
        public event EventHandler ConnectionTypeChanged
        {
            add
            {
                if (_ConnectionTypeChanged == null)
                {
                    ConnectionTypeChangedStart();
                }
                _ConnectionTypeChanged += value;
            }
            remove
            {
                _ConnectionTypeChanged -= value;
                if (_ConnectionTypeChanged == null)
                {
                    ConnectionTypeChangedStop();
                }
            }
        }

        private void ConnectionTypeChangedStart()
        {
            _connectionTypeChangedCallback = (ConnectionType type, IntPtr user_data) =>
            {
                if (_ConnectionTypeChanged != null)
                {
                    _ConnectionTypeChanged(null, new ConnectionTypeEventArgs(type));
                }
            };
            int ret = Interop.Connection.SetTypeChangedCallback(_internalManager.GetHandle(), _connectionTypeChangedCallback, IntPtr.Zero);
            if ((ConnectionError)ret != ConnectionError.None)
            {
                Log.Error(Globals.LogTag, "It failed to register connection type changed callback, " + (ConnectionError)ret);
                ConnectionErrorFactory.ThrowConnectionException(ret);
            }
        }

        private void ConnectionTypeChangedStop()
        {
            int ret = Interop.Connection.UnsetTypeChangedCallback(_internalManager.GetHandle());
            if ((ConnectionError)ret != ConnectionError.None)
            {
                Log.Error(Globals.LogTag, "It failed to unregister connection type changed callback, " + (ConnectionError)ret);
                ConnectionErrorFactory.ThrowConnectionException(ret);
            }
        }

        /// <summary>
        /// Event for ethernet cable is plugged [in/out] event.
        /// </summary>
        public event EventHandler EthernetCableStateChanged
        {
            add
            {
                if (_EthernetCableStateChanged == null)
                {
                    EthernetCableStateChangedStart();
                }
                _EthernetCableStateChanged += value;
            }
            remove
            {
                _EthernetCableStateChanged -= value;
                if (_EthernetCableStateChanged == null)
                {
                    EthernetCableStateChangedStop();
                }
            }
        }

        private void EthernetCableStateChangedStart()
        {
            int ret = Interop.Connection.SetEthernetCableStateChagedCallback(_internalManager.GetHandle(), EthernetCableStateChangedCallback, IntPtr.Zero);
            if ((ConnectionError)ret != ConnectionError.None)
            {
                Log.Error(Globals.LogTag, "It failed to register ethernet cable state changed callback, " + (ConnectionError)ret);
                ConnectionErrorFactory.ThrowConnectionException(ret);
            }
        }

        private void EthernetCableStateChangedStop()
        {
            int ret = Interop.Connection.UnsetEthernetCableStateChagedCallback(_internalManager.GetHandle());
            if ((ConnectionError)ret != ConnectionError.None)
            {
                Log.Error(Globals.LogTag, "It failed to unregister ethernet cable state changed callback, " + (ConnectionError)ret);
                ConnectionErrorFactory.ThrowConnectionException(ret);
            }
        }

        private void EthernetCableStateChangedCallback(EthernetCableState state, IntPtr user_data)
        {
            if (_EthernetCableStateChanged != null)
            {
                _EthernetCableStateChanged(null, new EthernetCableStateEventArgs(state));
            }
        }

        /// <summary>
        /// Event that is called when the IP address is changed.
        /// </summary>
        public event EventHandler IpAddressChanged
        {
            add
            {
                if (_IPAddressChanged == null)
                {
                    IpAddressChangedStart();
                }
                _IPAddressChanged += value;
            }
            remove
            {
                _IPAddressChanged -= value;
                if (_IPAddressChanged == null)
                {
                    IpAddressChangedStop();
                }
            }
        }

        private void IpAddressChangedStart()
        {
            _connectionAddressChangedCallback = (IntPtr Ipv4, IntPtr Ipv6, IntPtr UserData) =>
            {
                if (_IPAddressChanged != null)
                {
                    string ipv4 = Marshal.PtrToStringAnsi(Ipv4);
                    string ipv6 = Marshal.PtrToStringAnsi(Ipv6);

                    if ((string.IsNullOrEmpty(ipv4) == false) || (string.IsNullOrEmpty(ipv6) == false))
                    {
                        _IPAddressChanged(null, new AddressEventArgs(ipv4, ipv6));
                    }
                }
            };
            Log.Debug(Globals.LogTag, "Handle: " + _internalManager.GetHandle());
            int ret = Interop.Connection.SetIpAddressChangedCallback(_internalManager.GetHandle(), _connectionAddressChangedCallback, IntPtr.Zero);
            if ((ConnectionError)ret != ConnectionError.None)
            {
                Log.Error(Globals.LogTag, "It failed to register callback for changing IP address, " + (ConnectionError)ret);
            }
        }

        private void IpAddressChangedStop()
        {
            int ret = Interop.Connection.UnsetIpAddressChangedCallback(_internalManager.GetHandle());
            if ((ConnectionError)ret != ConnectionError.None)
            {
                Log.Error(Globals.LogTag, "It failed to unregister callback for changing IP address, " + (ConnectionError)ret);
            }
        }

        /// <summary>
        /// Event that is called when the proxy address is changed.
        /// </summary>
        public event EventHandler ProxyAddressChanged
        {
            add
            {
                //Console.WriteLine("ProxyAddressChanged Add **");
                if (_ProxyAddressChanged == null)
                {
                    ProxyAddressChangedStart();
                }
                _ProxyAddressChanged += value;
            }
            remove
            {
                //Console.WriteLine("ProxyAddressChanged Remove");
                _ProxyAddressChanged -= value;
                if (_ProxyAddressChanged == null)
                {
                    ProxyAddressChangedStop();
                }
            }
        }

        private void ProxyAddressChangedStart()
        {
            _proxyAddressChangedCallback = (IntPtr Ipv4, IntPtr Ipv6, IntPtr UserData) =>
            {
                if (_ProxyAddressChanged != null)
                {
                    string ipv4 = Marshal.PtrToStringAnsi(Ipv4);
                    string ipv6 = Marshal.PtrToStringAnsi(Ipv6);

                    if ((string.IsNullOrEmpty(ipv4) == false) || (string.IsNullOrEmpty(ipv6) == false))
                    {
                        _ProxyAddressChanged(null, new AddressEventArgs(ipv4, ipv6));
                    }
                }
            };
            int ret = Interop.Connection.SetProxyAddressChangedCallback(_internalManager.GetHandle(), _proxyAddressChangedCallback, IntPtr.Zero);
            if ((ConnectionError)ret != ConnectionError.None)
            {
                Log.Error(Globals.LogTag, "It failed to register callback for changing proxy address, " + (ConnectionError)ret);
            }
        }

        private void ProxyAddressChangedStop()
        {
            int ret = Interop.Connection.UnsetProxyAddressChangedCallback(_internalManager.GetHandle());
            if ((ConnectionError)ret != ConnectionError.None)
            {
                Log.Error(Globals.LogTag, "It failed to unregister callback for changing proxy address, " + (ConnectionError)ret);
            }
        }

        private void UnregisterEvents()
        {
            if (_ConnectionTypeChanged != null)
            {
                ConnectionTypeChangedStop();
            }
            if (_IPAddressChanged != null)
            {
                IpAddressChangedStop();
            }
            if (_EthernetCableStateChanged != null)
            {
                EthernetCableStateChangedStop();
            }
            if (_ProxyAddressChanged != null)
            {
                ProxyAddressChangedStop();
            }
        }

        /// <summary>
        /// Gets the IP address of the current connection.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation</exception>
        public string GetIpAddress(AddressFamily family)
        {
            return _internalManager.GetIpAddress(family);
        }

        /// <summary>
        /// Gets the proxy address of the current connection.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation</exception>
        public string GetProxy(AddressFamily family)
        {
            return _internalManager.GetProxy(family);
        }

        /// <summary>
        /// Gets the MAC address of the Wi-Fi or ethernet.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation</exception>
        public string GetMacAddress(ConnectionType type)
        {
            return _internalManager.GetMacAddress(type);
        }

        /// <summary>
        /// Gets type and state of the current profile for data connection
        /// </summary>
        public ConnectionItem CurrentConnection
        {
            get
            {
                return _currentConnection;
            }
        }

        public RequestProfile CreateRequestProfile(ConnectionProfileType type, string keyword)
        {
            IntPtr ProfileHandle = ConnectionInternalManager.CreateRequestProfile(type, keyword);
            if (type == ConnectionProfileType.WiFi)
            {
                return new RequestWiFiProfile(ProfileHandle);
            }
            else if (type == ConnectionProfileType.Cellular)
            {
                return new RequestCellularProfile(ProfileHandle);
            }
            else
            {
                Log.Error(Globals.LogTag, "Nut supported profile type");
                ConnectionErrorFactory.ThrowConnectionException((int)ConnectionError.InvalidParameter);
            }
            return null;
        }

        /// <summary>
        /// Gets the state of cellular connection.
        /// </summary>
        public CellularState CellularState
        {
            get
            {
                return _internalManager.CellularState;
            }
        }

        /// <summary>
        /// Gets the state of the Wi-Fi.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        public ConnectionState WiFiState
        {
            get
            {
                return _internalManager.WiFiState;
            }
        }

        /// <summary>
        /// The state of the Bluetooth.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        public ConnectionState BluetoothState
        {
            get
            {
                return _internalManager.BluetoothState;
            }
        }

        /// <summary>
        /// The Ethernet connection state.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        public ConnectionState EthernetState
        {
            get
            {
                return _internalManager.EthernetState;
            }
        }

        /// <summary>
        /// Checks for ethernet cable is attached or not.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        public EthernetCableState EthernetCableState
        {
            get
            {
                return _internalManager.EthernetCableState;
            }
        }

    } // class ConnectionManager

    /// <summary>
    /// class which contains connection information such as connection type and state
    /// </summary>
    public class ConnectionItem
    {
        ConnectionInternalManager _internalManager = null;
        internal ConnectionItem(ConnectionInternalManager manager)
        {
            _internalManager = manager;
        }

        /// <summary>
        /// Gets the type of the current profile for data connection.
        /// </summary>
        public ConnectionType Type
        {
            get
            {
                return _internalManager.ConnectionType;
            }
        }

        /// <summary>
        /// Gets the state of the current profile for data connection.
        /// </summary>
        public ConnectionState State
        {
            get
            {
                if (_internalManager.ConnectionType == ConnectionType.Cellular)
                {
                    if (_internalManager.CellularState == CellularState.Connected)
                    {
                        return ConnectionState.Connected;
                    }
                    else if (_internalManager.CellularState == CellularState.Available)
                    {
                        return ConnectionState.Disconnected;
                    }
                    else {
                        return ConnectionState.Deactivated;
                    }
                }
                else if (_internalManager.ConnectionType == ConnectionType.Bluetooth)
                {
                    return _internalManager.BluetoothState;
                }
                else if (_internalManager.ConnectionType == ConnectionType.WiFi)
                {
                    return _internalManager.WiFiState;
                }
                else if (_internalManager.ConnectionType == ConnectionType.Ethernet)
                {
                    return _internalManager.EthernetState;
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
