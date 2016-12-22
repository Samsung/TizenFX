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
    public class ConnectionManager : IDisposable
    {
        static internal ConnectionItem CurConnction = new ConnectionItem();
        private bool disposed = false;

        static private EventHandler _ConnectionTypeChanged = null;
        static private EventHandler _IPAddressChanged = null;
        static private EventHandler _EthernetCableStateChanged = null;
        static private EventHandler _ProxyAddressChanged = null;

        /// <summary>
        /// Event that is called when the type of the current connection is changed.
        /// </summary>
        static public event EventHandler ConnectionTypeChanged
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

        static private void ConnectionTypeChangedStart()
        {
            int ret = Interop.Connection.SetTypeChangedCallback(ConnectionInternalManager.GetHandle(), TypeChangedCallback, IntPtr.Zero);
            if ((ConnectionError)ret != ConnectionError.None)
            {
                Log.Error(Globals.LogTag, "It failed to register connection type changed callback, " + (ConnectionError)ret);
            }
        }

        static private void ConnectionTypeChangedStop()
        {
            int ret = Interop.Connection.UnsetTypeChangedCallback(ConnectionInternalManager.GetHandle());
            if ((ConnectionError)ret != ConnectionError.None)
            {
                Log.Error(Globals.LogTag, "It failed to unregister connection type changed callback, " + (ConnectionError)ret);
            }
        }

        static private void TypeChangedCallback(ConnectionType type, IntPtr user_data)
        {
            if (_ConnectionTypeChanged != null)
            {
                _ConnectionTypeChanged(null, new ConnectionTypeEventArgs(type));
            }
        }

        /// <summary>
        /// Event for ethernet cable is plugged [in/out] event.
        /// </summary>
        static public event EventHandler EthernetCableStateChanged
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
                    EthernetCableStateChangedtop();
                }
            }
        }

        static private void EthernetCableStateChangedStart()
        {
            int ret = Interop.Connection.SetEthernetCableStateChagedCallback(ConnectionInternalManager.GetHandle(), EthernetCableStateChangedCallback, IntPtr.Zero);
            if ((ConnectionError)ret != ConnectionError.None)
            {
                Log.Error(Globals.LogTag, "It failed to register ethernet cable state changed callback, " + (ConnectionError)ret);
            }
        }

        static private void EthernetCableStateChangedtop()
        {
            int ret = Interop.Connection.UnsetEthernetCableStateChagedCallback(ConnectionInternalManager.GetHandle());
            if ((ConnectionError)ret != ConnectionError.None)
            {
                Log.Error(Globals.LogTag, "It failed to unregister ethernet cable state changed callback, " + (ConnectionError)ret);
            }
        }

        static private void EthernetCableStateChangedCallback(EthernetCableState state, IntPtr user_data)
        {
            if (_EthernetCableStateChanged != null)
            {
                _EthernetCableStateChanged(null, new EthernetCableStateEventArgs(state));
            }
        }

        /// <summary>
        /// Event that is called when the IP address is changed.
        /// </summary>
        static public event EventHandler IpAddressChanged
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

        static private void IpAddressChangedStart()
        {
            int ret = Interop.Connection.SetIpAddressChangedCallback(ConnectionInternalManager.GetHandle(), IPAddressChangedCallback, IntPtr.Zero);
            if ((ConnectionError)ret != ConnectionError.None)
            {
                Log.Error(Globals.LogTag, "It failed to register callback for changing IP address, " + (ConnectionError)ret);
            }
        }

        static private void IpAddressChangedStop()
        {
            int ret = Interop.Connection.UnsetIpAddressChangedCallback(ConnectionInternalManager.GetHandle());
            if ((ConnectionError)ret != ConnectionError.None)
            {
                Log.Error(Globals.LogTag, "It failed to unregister callback for changing IP address, " + (ConnectionError)ret);
            }
        }

        static private void IPAddressChangedCallback(IntPtr Ipv4, IntPtr Ipv6, IntPtr UserData)
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
        }

        /// <summary>
        /// Event that is called when the proxy address is changed.
        /// </summary>
        static public event EventHandler ProxyAddressChanged
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

        static private void ProxyAddressChangedStart()
        {
            int ret = Interop.Connection.SetProxyAddressChangedCallback(ConnectionInternalManager.GetHandle(), IPAddressChangedCallback, IntPtr.Zero);
            if ((ConnectionError)ret != ConnectionError.None)
            {
                Log.Error(Globals.LogTag, "It failed to register callback for changing proxy address, " + (ConnectionError)ret);
            }
        }

        static private void ProxyAddressChangedStop()
        {
            int ret = Interop.Connection.UnsetProxyAddressChangedCallback(ConnectionInternalManager.GetHandle());
            if ((ConnectionError)ret != ConnectionError.None)
            {
                Log.Error(Globals.LogTag, "It failed to unregister callback for changing proxy address, " + (ConnectionError)ret);
            }
        }

        static private void ProxyAddressChangedCallback(IntPtr Ipv4, IntPtr Ipv6, IntPtr UserData)
        {
            if (_ProxyAddressChanged != null)
            {
                string ipv4 = Marshal.PtrToStringAnsi(Ipv4);
                string ipv6 = Marshal.PtrToStringAnsi(Ipv6);
                Interop.Libc.Free(Ipv4);
                Interop.Libc.Free(Ipv6);

                _ProxyAddressChanged(null, new AddressEventArgs(ipv4, ipv6));
            }
        }

        internal ConnectionManager()
        {
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
            if (disposed)
                return;

            if (disposing)
            {
                // Free managed objects.
            }
            ProxyAddressChangedStop();
            ConnectionTypeChangedStop();
            EthernetCableStateChangedtop();
            IpAddressChangedStop();
            disposed = true;
        }


        /// <summary>
        /// Gets the IP address of the current connection.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation</exception>
        static public string GetIpAddress(AddressFamily family)
        {
            return ConnectionInternalManager.GetIpAddress(family);
        }

        /// <summary>
        /// Gets the proxy address of the current connection.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation</exception>
        static public string GetProxy(AddressFamily family)
        {
            return ConnectionInternalManager.GetProxy(family);
        }

        /// <summary>
        /// Gets the MAC address of the Wi-Fi or ethernet.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation</exception>
        static public string GetMacAddress(ConnectionType type)
        {
            return ConnectionInternalManager.GetMacAddress(type);
        }

        /// <summary>
        /// Gets the type of the current profile for data connection.
        /// </summary>
        static public ConnectionItem CurrentConnection
        {
            get
            {
                return CurConnction;
            }
        }

        /// <summary>
        /// Gets the state of cellular connection.
        /// </summary>
        static public CellularState CellularState
        {
            get
            {
                return ConnectionInternalManager.CellularState;
            }
        }

        /// <summary>
        /// Gets the state of the Wi-Fi.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        static public ConnectionState WiFiState
        {
            get
            {
                return ConnectionInternalManager.WiFiState;
            }
        }

        /// <summary>
        /// The state of the Bluetooth.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        static public ConnectionState BluetoothState
        {
            get
            {
                return ConnectionInternalManager.BluetoothState;
            }
        }

        /// <summary>
        /// The Ethernet connection state.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        static public ConnectionState EthernetState
        {
            get
            {
                return ConnectionInternalManager.EthernetState;
            }
        }

        /// <summary>
        /// Checks for ethernet cable is attached or not.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        static public EthernetCableState EthernetCableState
        {
            get
            {
                return ConnectionInternalManager.EthernetCableState;
            }
        }
    }

    /// <summary>
    ///
    /// </summary>
    public class ConnectionItem
    {
        internal ConnectionItem()
        {
        }

        /// <summary>
        /// Gets the type of the current profile for data connection.
        /// </summary>
        public ConnectionType Type
        {
            get
            {
                return ConnectionInternalManager.ConnectionType;
            }
        }

        /// <summary>
        /// Gets the type of the current profile for data connection.
        /// </summary>
        public ConnectionState State
        {
            get
            {
                if (ConnectionInternalManager.ConnectionType == ConnectionType.Cellular)
                {
                    if (ConnectionInternalManager.CellularState == CellularState.Connected)
                    {
                        return ConnectionState.Connected;
                    }
                    else if (ConnectionInternalManager.CellularState == CellularState.Available)
                    {
                        return ConnectionState.Disconnected;
                    }
                    else {
                        return ConnectionState.Deactivated;
                    }
                }
                else if (ConnectionInternalManager.ConnectionType == ConnectionType.Bluetooth)
                {
                    return ConnectionInternalManager.BluetoothState;
                }
                else if (ConnectionInternalManager.ConnectionType == ConnectionType.WiFi)
                {
                    return ConnectionInternalManager.WiFiState;
                }
                else if (ConnectionInternalManager.ConnectionType == ConnectionType.Ethernet)
                {
                    return ConnectionInternalManager.EthernetState;
                }
                else { // TO DO : Add Net Proxy
                    return ConnectionState.Disconnected;
                }
            }
        }

    }

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
