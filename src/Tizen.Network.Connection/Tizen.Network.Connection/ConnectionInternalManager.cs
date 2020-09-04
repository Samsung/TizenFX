/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Collections;
using System.Threading;
using Tizen.Applications;

namespace Tizen.Network.Connection
{
    class HandleHolder
    {
        private IntPtr Handle;
        private int _tid;

        public HandleHolder()
        {
            _tid = Thread.CurrentThread.ManagedThreadId;
            Log.Info(Globals.LogTag, "PInvoke connection_create for Thread " + _tid);
            int ret = Interop.Connection.Create(out Handle);
            Log.Info(Globals.LogTag, "Handle: " + Handle);
            if(ret != (int)ConnectionError.None)
            {
                ConnectionErrorFactory.CheckFeatureUnsupportedException(ret, "http://tizen.org/feature/network.telephony " + "http://tizen.org/feature/network.wifi " + "http://tizen.org/feature/network.tethering.bluetooth " + "http://tizen.org/feature/network.ethernet");
                ConnectionErrorFactory.CheckPermissionDeniedException(ret, "(http://tizen.org/privilege/network.get)");
                ConnectionErrorFactory.ThrowConnectionException(ret);
            }
        }

        ~HandleHolder()
        {
            Destroy();
        }

        internal IntPtr GetHandle()
        {
            Log.Debug(Globals.LogTag, "handleholder handle = " + Handle);
            return Handle;
        }

        private void Destroy()
        {

            Log.Info(Globals.LogTag, "PInvoke connection_destroy for Thread " + _tid);
            Interop.Connection.Destroy(Handle);
            if (Handle != IntPtr.Zero)
            {
                Handle = IntPtr.Zero;
            }
        }
    }

    internal class ConnectionInternalManager
    {
        private static readonly Lazy<ConnectionInternalManager> s_instance =
            new Lazy<ConnectionInternalManager>(() => new ConnectionInternalManager());

        private EventHandler<ConnectionTypeEventArgs> _ConnectionTypeChanged = null;
        private EventHandler<AddressEventArgs> _IPAddressChanged = null;
        private EventHandler<EthernetCableStateEventArgs> _EthernetCableStateChanged = null;
        private EventHandler<AddressEventArgs> _ProxyAddressChanged = null;

        private Interop.Connection.ConnectionAddressChangedCallback _connectionAddressChangedCallback;
        private Interop.Connection.ConnectionTypeChangedCallback _connectionTypeChangedCallback;
        private Interop.Connection.ConnectionAddressChangedCallback _proxyAddressChangedCallback;
        private Interop.Connection.EthernetCableStateChangedCallback _ethernetCableStateChangedCallback;

        private Dictionary<IntPtr, Interop.Connection.ConnectionCallback> _callback_map =
            new Dictionary<IntPtr, Interop.Connection.ConnectionCallback>();
        private int _requestId = 0;

        internal static ConnectionInternalManager Instance
        {
            get
            {
                Log.Info(Globals.LogTag, "ConnectionInternalManager.Instance");
                return s_instance.Value;
            }
        }

        private HandleHolder _handleHolder;

        private ConnectionInternalManager()
        {
            Log.Info(Globals.LogTag, "ConnectionInternalManager constructor");
            _handleHolder = new HandleHolder();
            Log.Info(Globals.LogTag, "Success to get handle");
        }

        ~ConnectionInternalManager()
        {
            UnregisterEvents();
        }

        internal IntPtr GetHandle()
        {
            return _handleHolder.GetHandle();
        }

        internal event EventHandler<ConnectionTypeEventArgs> ConnectionTypeChanged
        {
            add
            {
                if (_ConnectionTypeChanged == null)
                {
                    try
                    {
                        ConnectionTypeChangedStart();
                    }
                    catch (Exception e)
                    {
                        Log.Error(Globals.LogTag, "Exception on adding ConnectionTypeChanged\n" + e.ToString());
                        return;
                    }
                }
                _ConnectionTypeChanged += value;
            }
            remove
            {
                _ConnectionTypeChanged -= value;
                if (_ConnectionTypeChanged == null)
                {
                    try
                    {
                        ConnectionTypeChangedStop();
                    }
                    catch (Exception e)
                    {
                        Log.Error(Globals.LogTag, "Exception on removing ConnectionTypeChanged\n" + e.ToString());
                    }
                }
            }
        }

        private void ConnectionTypeChangedStart()
        {
            Log.Info(Globals.LogTag, "Register ConnectionTypeChanged");
            _connectionTypeChangedCallback = (ConnectionType type, IntPtr user_data) =>
            {
                if (_ConnectionTypeChanged != null)
                {
                    _ConnectionTypeChanged(null, new ConnectionTypeEventArgs(type));
                }
            };

            int ret = Interop.Connection.SetTypeChangedCallback(GetHandle(), _connectionTypeChangedCallback, IntPtr.Zero);
            if ((ConnectionError)ret != ConnectionError.None)
            {
                Log.Error(Globals.LogTag, "It failed to register connection type changed callback, " + (ConnectionError)ret);
                ConnectionErrorFactory.ThrowConnectionException(ret);
            }
        }

        private void ConnectionTypeChangedStop()
        {
            Log.Info(Globals.LogTag, "Unregister ConnectionTypeChanged");
            int ret = Interop.Connection.UnsetTypeChangedCallback(GetHandle());
            if ((ConnectionError)ret != ConnectionError.None)
            {
                Log.Error(Globals.LogTag, "It failed to unregister connection type changed callback, " + (ConnectionError)ret);
                ConnectionErrorFactory.ThrowConnectionException(ret);
            }
        }

        internal event EventHandler<EthernetCableStateEventArgs> EthernetCableStateChanged
        {
            add
            {
                if (_EthernetCableStateChanged == null)
                {
                    try
                    {
                        EthernetCableStateChangedStart();
                    }
                    catch (Exception e)
                    {
                        Log.Error(Globals.LogTag, "Exception on adding EthernetCableStateChanged\n" + e.ToString());
                        return;
                    }
                }
                _EthernetCableStateChanged += value;
            }
            remove
            {
                _EthernetCableStateChanged -= value;
                if (_EthernetCableStateChanged == null)
                {
                    try
                    {
                        EthernetCableStateChangedStop();
                    }
                    catch (Exception e)
                    {
                        Log.Error(Globals.LogTag, "Exception on removing EthernetCableStateChanged\n" + e.ToString());
                    }
                }
            }
        }

        private void EthernetCableStateChangedStart()
        {
            Log.Info(Globals.LogTag, "Register EthernetCableStateChanged");
            _ethernetCableStateChangedCallback = (EthernetCableState state, IntPtr user_data) =>
            {
                if (_EthernetCableStateChanged != null)
                {
                    _EthernetCableStateChanged(null, new EthernetCableStateEventArgs(state));
                }
            };
            int ret = Interop.Connection.SetEthernetCableStateChagedCallback(GetHandle(),
                    _ethernetCableStateChangedCallback, IntPtr.Zero);
            if ((ConnectionError)ret != ConnectionError.None)
            {
                Log.Error(Globals.LogTag,
                        "It failed to register ethernet cable state changed callback, " +
                        (ConnectionError)ret);
                ConnectionErrorFactory.ThrowConnectionException(ret);
            }
        }

        private void EthernetCableStateChangedStop()
        {
            Log.Info(Globals.LogTag, "Unregister EthernetCableStateChanged");
            int ret = Interop.Connection.UnsetEthernetCableStateChagedCallback(GetHandle());
            if ((ConnectionError)ret != ConnectionError.None)
            {
                Log.Error(Globals.LogTag,
                        "It failed to unregister ethernet cable state changed callback, " + 
                        (ConnectionError)ret);
                ConnectionErrorFactory.ThrowConnectionException(ret);
            }
        }

        internal event EventHandler<AddressEventArgs> IPAddressChanged
        {
            add
            {
                if (_IPAddressChanged == null)
                {
                    try
                    {
                        IPAddressChangedStart();
                    }
                    catch (Exception e)
                    {
                        Log.Error(Globals.LogTag, "Exception on adding IPAddressChanged\n" + e.ToString());
                        return;
                    }
                }
                _IPAddressChanged += value;
            }

            remove
            {
                _IPAddressChanged -= value;
                if (_IPAddressChanged == null)
                {
                    try
                    {
                        IPAddressChangedStop();
                    }
                    catch (Exception e)
                    {
                        Log.Error(Globals.LogTag, "Exception on removing IPAddressChanged\n" + e.ToString());
                    }
                }
            }
        }

        private void IPAddressChangedStart()
        {
            Log.Info(Globals.LogTag, "Register IPAddressChanged");
            _connectionAddressChangedCallback = (IntPtr IPv4, IntPtr IPv6, IntPtr UserData) =>
            {
                if (_IPAddressChanged != null)
                {
                    string ipv4 = Marshal.PtrToStringAnsi(IPv4);
                    string ipv6 = Marshal.PtrToStringAnsi(IPv6);

                    if ((string.IsNullOrEmpty(ipv4) == false) || (string.IsNullOrEmpty(ipv6) == false))
                    {
                        _IPAddressChanged(null, new AddressEventArgs(ipv4, ipv6));
                    }
                }
            };

            int ret = Interop.Connection.SetIPAddressChangedCallback(GetHandle(), _connectionAddressChangedCallback, IntPtr.Zero);
            if ((ConnectionError)ret != ConnectionError.None)
            {
                Log.Error(Globals.LogTag, "It failed to register callback for changing IP address, " + (ConnectionError)ret);
            }
        }

        private void IPAddressChangedStop()
        {
            Log.Info(Globals.LogTag, "Unregister IPAddressChanged");
            int ret = Interop.Connection.UnsetIPAddressChangedCallback(GetHandle());
            if ((ConnectionError)ret != ConnectionError.None)
            {
                Log.Error(Globals.LogTag, "It failed to unregister callback for changing IP address, " + (ConnectionError)ret);
            }
        }

        internal event EventHandler<AddressEventArgs> ProxyAddressChanged
        {
            add
            {
                if (_ProxyAddressChanged == null)
                {
                    try
                    {
                        ProxyAddressChangedStart();
                    }
                    catch (Exception e)
                    {
                        Log.Error(Globals.LogTag, "Exception on adding ProxyAddressChanged\n" + e.ToString());
                        return;
                    }
                }
                _ProxyAddressChanged += value;
            }
            remove
            {
                _ProxyAddressChanged -= value;
                if (_ProxyAddressChanged == null)
                {
                    try
                    {
                        ProxyAddressChangedStop();
                    }
                    catch (Exception e)
                    {
                        Log.Error(Globals.LogTag, "Exception on removing ProxyAddressChanged\n" + e.ToString());
                    }
                }
            }
        }

        private void ProxyAddressChangedStart()
        {
            Log.Info(Globals.LogTag, "Register ProxyAddressChanged");
            _proxyAddressChangedCallback = (IntPtr IPv4, IntPtr IPv6, IntPtr UserData) =>
            {
                if (_ProxyAddressChanged != null)
                {
                    string ipv4 = Marshal.PtrToStringAnsi(IPv4);
                    string ipv6 = Marshal.PtrToStringAnsi(IPv6);

                    if ((string.IsNullOrEmpty(ipv4) == false) || (string.IsNullOrEmpty(ipv6) == false))
                    {
                        _ProxyAddressChanged(null, new AddressEventArgs(ipv4, ipv6));
                    }
                }
            };

            int ret = Interop.Connection.SetProxyAddressChangedCallback(GetHandle(), _proxyAddressChangedCallback, IntPtr.Zero);
            if ((ConnectionError)ret != ConnectionError.None)
            {
                Log.Error(Globals.LogTag, "It failed to register callback for changing proxy address, " + (ConnectionError)ret);
            }
        }

        private void ProxyAddressChangedStop()
        {
            Log.Info(Globals.LogTag, "Unregister ProxyAddressChanged");
            int ret = Interop.Connection.UnsetProxyAddressChangedCallback(GetHandle());
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
                IPAddressChangedStop();
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

        internal int GetProfileIterator(ProfileListType type, out IntPtr iterator)
        {
            return Interop.Connection.GetProfileIterator(GetHandle(), (int)type, out iterator);
        }

        internal bool HasNext(IntPtr iterator)
        {
            return Interop.Connection.HasNextProfileIterator(iterator);
        }

        internal int NextProfileIterator(IntPtr iterator, out IntPtr profileHandle)
        {
            return Interop.Connection.GetNextProfileIterator(iterator, out profileHandle);
        }

        internal int DestoryProfileIterator(IntPtr iterator)
        {
            return Interop.Connection.DestroyProfileIterator(iterator);
        }

        internal System.Net.IPAddress GetIPAddress(AddressFamily family)
        {
            Log.Info(Globals.LogTag, "GetIPAddress " + family);
            IntPtr ip;
            int ret = Interop.Connection.GetIPAddress(GetHandle(), (int)family, out ip);
            if ((ConnectionError)ret != ConnectionError.None)
            {
                Log.Error(Globals.LogTag, "It failed to get IP address, " + (ConnectionError)ret);
                ConnectionErrorFactory.CheckFeatureUnsupportedException(ret, "http://tizen.org/feature/network.telephony " + "http://tizen.org/feature/network.wifi " + "http://tizen.org/feature/network.tethering.bluetooth " + "http://tizen.org/feature/network.ethernet");
                ConnectionErrorFactory.CheckHandleNullException(ret, (GetHandle() == IntPtr.Zero), "Connection Handle may have been disposed or released");
                ConnectionErrorFactory.ThrowConnectionException(ret);
            }

            string result = Marshal.PtrToStringAnsi(ip);
            Interop.Libc.Free(ip);
            Log.Info(Globals.LogTag, "IPAddress " + result + " (" + result.Length + ")");
            if (result.Length == 0)
            {
                if (family == AddressFamily.IPv4)
                    return System.Net.IPAddress.Parse("0.0.0.0");
                else
                    return System.Net.IPAddress.Parse("::");
            }
            return System.Net.IPAddress.Parse(result);
        }

        internal IEnumerable<System.Net.IPAddress> GetAllIPv6Addresses(ConnectionType type)
        {
            Log.Debug(Globals.LogTag, "GetAllIPv6Addresses");
            List<System.Net.IPAddress> ipList = new List<System.Net.IPAddress>();
            Interop.Connection.IPv6AddressCallback callback = (IntPtr ipv6Address, IntPtr userData) =>
            {
                if (ipv6Address != IntPtr.Zero)
                {
                    string ipv6 = Marshal.PtrToStringAnsi(ipv6Address);
                    if (ipv6.Length == 0)
                        ipList.Add(System.Net.IPAddress.Parse("::"));
                    else
                        ipList.Add(System.Net.IPAddress.Parse(ipv6));
                    return true;
                }
                return false;
            };

            int ret = Interop.Connection.GetAllIPv6Addresses(GetHandle(), (int)type, callback, IntPtr.Zero);
            if (ret != (int)ConnectionError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get all IPv6 addresses, Error - " + (ConnectionError)ret);
                ConnectionErrorFactory.CheckFeatureUnsupportedException(ret, "http://tizen.org/feature/network.telephony " + "http://tizen.org/feature/network.wifi " + "http://tizen.org/feature/network.tethering.bluetooth " + "http://tizen.org/feature/network.ethernet");
                ConnectionErrorFactory.CheckHandleNullException(ret, (GetHandle() == IntPtr.Zero), "Connection Handle may have been disposed or released");
                ConnectionErrorFactory.ThrowConnectionException(ret);
            }

            return ipList;
        }

        internal string GetProxy(AddressFamily family)
        {
            Log.Debug(Globals.LogTag, "GetProxy " + family);
            IntPtr ip;
            int ret = Interop.Connection.GetProxy(GetHandle(), (int)family, out ip);
            if ((ConnectionError)ret != ConnectionError.None)
            {
                Log.Error(Globals.LogTag, "It failed to get proxy, " + (ConnectionError)ret);
                ConnectionErrorFactory.CheckFeatureUnsupportedException(ret, "http://tizen.org/feature/network.telephony " + "http://tizen.org/feature/network.wifi " + "http://tizen.org/feature/network.tethering.bluetooth " + "http://tizen.org/feature/network.ethernet");
                ConnectionErrorFactory.CheckHandleNullException(ret, (GetHandle() == IntPtr.Zero), "Connection Handle may have been disposed or released");
                ConnectionErrorFactory.ThrowConnectionException(ret);
            }

            string result = Marshal.PtrToStringAnsi(ip);
            Interop.Libc.Free(ip);
            return result;
        }

        internal string GetMacAddress(ConnectionType type)
        {
            Log.Info(Globals.LogTag, "GetMacAddress " + type);
            IntPtr mac;
            int ret = Interop.Connection.GetMacAddress(GetHandle(), (int)type, out mac);
            if ((ConnectionError)ret != ConnectionError.None)
            {
                Log.Error(Globals.LogTag, "It failed to get mac address, " + (ConnectionError)ret);
                ConnectionErrorFactory.CheckFeatureUnsupportedException(ret, "http://tizen.org/feature/network.wifi " + "http://tizen.org/feature/network.ethernet");
                ConnectionErrorFactory.CheckHandleNullException(ret, (GetHandle() == IntPtr.Zero), "Connection Handle may have been disposed or released");
                ConnectionErrorFactory.ThrowConnectionException(ret);
            }

            string result = Marshal.PtrToStringAnsi(mac);
            Interop.Libc.Free(mac);
            return result;
        }

        internal long GetStatistics(ConnectionType connectionType, StatisticsType statisticsType)
        {
            Log.Debug(Globals.LogTag, "GetStatistics " + connectionType + ", " + statisticsType);
            long size;
            int ret = Interop.Connection.GetStatistics(GetHandle(), (int)connectionType,
                    (int)statisticsType, out size);
            if ((ConnectionError)ret != ConnectionError.None)
            {
                Log.Error(Globals.LogTag, "It failed to get statistics, " + (ConnectionError)ret);
                ConnectionErrorFactory.CheckFeatureUnsupportedException(ret, "http://tizen.org/feature/network.wifi " + "http://tizen.org/feature/network.telephony");
                ConnectionErrorFactory.CheckPermissionDeniedException(ret, "(http://tizen.org/privilege/network.get)");
                ConnectionErrorFactory.CheckHandleNullException(ret, (GetHandle() == IntPtr.Zero), "Connection Handle may have been disposed or released");
                ConnectionErrorFactory.ThrowConnectionException(ret);
            }
            return size;
        }

        internal void ResetStatistics(ConnectionType connectionType, StatisticsType statisticsType)
        {
            Log.Debug(Globals.LogTag, "ResetStatistics " + connectionType + ", " + statisticsType);
            int ret = Interop.Connection.ResetStatistics(GetHandle(), (int)connectionType,
                    (int)statisticsType);
            if ((ConnectionError)ret != ConnectionError.None)
            {
                Log.Error(Globals.LogTag, "It failed to reset statistics, " + (ConnectionError)ret);
                ConnectionErrorFactory.CheckFeatureUnsupportedException(ret, "http://tizen.org/feature/network.wifi " + "http://tizen.org/feature/network.telephony");
                ConnectionErrorFactory.CheckPermissionDeniedException(ret, "(http://tizen.org/privilege/network.set)");
                ConnectionErrorFactory.CheckHandleNullException(ret, (GetHandle() == IntPtr.Zero), "Connection Handle may have been disposed or released");
                ConnectionErrorFactory.ThrowConnectionException(ret);
            }
        }

        internal void AddRoute(AddressFamily family, string interfaceName, System.Net.IPAddress address, System.Net.IPAddress gateway)
        {
            if (interfaceName != null && address != null && gateway != null)
            {
                Log.Debug(Globals.LogTag, "AddRoute " + family + ", " + interfaceName + ", " + address + ", " + gateway);
                int ret = Interop.Connection.AddRoute(GetHandle(), family, interfaceName, address.ToString(), gateway.ToString());
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to add route to the routing table, " + (ConnectionError)ret);
                    ConnectionErrorFactory.CheckFeatureUnsupportedException(ret, "http://tizen.org/feature/network.telephony " + "http://tizen.org/feature/network.wifi " + "http://tizen.org/feature/network.tethering.bluetooth " + "http://tizen.org/feature/network.ethernet");
                    ConnectionErrorFactory.CheckPermissionDeniedException(ret, "(http://tizen.org/privilege/network.route)");
                    ConnectionErrorFactory.CheckHandleNullException(ret, (GetHandle() == IntPtr.Zero), "Connection Handle may have been disposed or released");
                    ConnectionErrorFactory.ThrowConnectionException(ret);
                }
            }

            else
            {
                throw new ArgumentNullException("Arguments are null");
            }
        }

        internal void RemoveRoute(AddressFamily family, string interfaceName, System.Net.IPAddress address, System.Net.IPAddress gateway)
        {
            if (interfaceName != null && address != null && gateway != null)
            {
                Log.Debug(Globals.LogTag, "RemoveRoute " + family + ", " + interfaceName + ", " + address + ", " + gateway);
                int ret = Interop.Connection.RemoveRoute(GetHandle(), family, interfaceName, address.ToString(), gateway.ToString());
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to remove route from the routing table, " + (ConnectionError)ret);
                    ConnectionErrorFactory.CheckFeatureUnsupportedException(ret, "http://tizen.org/feature/network.telephony " + "http://tizen.org/feature/network.wifi " + "http://tizen.org/feature/network.tethering.bluetooth " + "http://tizen.org/feature/network.ethernet");
                    ConnectionErrorFactory.CheckPermissionDeniedException(ret, "(http://tizen.org/privilege/network.route)");
                    ConnectionErrorFactory.CheckHandleNullException(ret, (GetHandle() == IntPtr.Zero), "Connection Handle may have been disposed or released");
                    ConnectionErrorFactory.ThrowConnectionException(ret);
                }
            }

            else
            {
                throw new ArgumentNullException("Arguments are null");
            }
        }

        internal ConnectionType ConnectionType
        {
            get
            {
                Log.Info(Globals.LogTag, "get ConnectionType");
                int type = 0;
                int ret = Interop.Connection.GetType(GetHandle(), out type);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get connection type, " + (ConnectionError)ret);
                    ConnectionErrorFactory.ThrowConnectionException(ret);
                }
                return (ConnectionType)type;
            }
        }

        internal CellularState CellularState
        {
            get
            {
                Log.Info(Globals.LogTag, "get CellularState");
                int type = 0;
                int ret = Interop.Connection.GetCellularState(GetHandle(), out type);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get cellular state, " + (ConnectionError)ret);
                    ConnectionErrorFactory.ThrowConnectionException(ret);
                }
                return (CellularState)type;
            }
        }

        internal ConnectionState WiFiState
        {
            get
            {
                Log.Info(Globals.LogTag, "get WiFiState");
                int type = 0;
                int ret = Interop.Connection.GetWiFiState(GetHandle(), out type);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get wifi state, " + (ConnectionError)ret);
                    ConnectionErrorFactory.ThrowConnectionException(ret);
                }
                return (ConnectionState)type;
            }
        }

        internal ConnectionState BluetoothState
        {
            get
            {
                Log.Info(Globals.LogTag, "get BluetoothState");
                int type = 0;
                int ret = Interop.Connection.GetBtState(GetHandle(), out type);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get bluetooth state, " + (ConnectionError)ret);
                    ConnectionErrorFactory.ThrowConnectionException(ret);
                }
                return (ConnectionState)type;
            }
        }

        internal ConnectionState EthernetState
        {
            get
            {
                Log.Info(Globals.LogTag, "get ConnectionType");
                int type = 0;
                int ret = Interop.Connection.GetEthernetState(GetHandle(), out type);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get ethernet state, " + (ConnectionError)ret);
                    ConnectionErrorFactory.ThrowConnectionException(ret);
                }
                return (ConnectionState)type;
            }
        }

        internal EthernetCableState EthernetCableState
        {
            get
            {
                Log.Info(Globals.LogTag, "get EthernetCableState");
                int type = 0;
                int ret = Interop.Connection.GetEthernetCableState(GetHandle(), out type);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get ethernet cable state, " + (ConnectionError)ret);
                    ConnectionErrorFactory.ThrowConnectionException(ret);
                }
                return (EthernetCableState)type;
            }
        }

        internal IntPtr CreateCellularProfile(ConnectionProfileType type, string keyword)
        {
            Log.Debug(Globals.LogTag, "CreateCellularProfile, " + type + ", " + keyword);
            if (keyword != null)
            {
                IntPtr handle = IntPtr.Zero;
                int ret = Interop.ConnectionProfile.Create((int)type, keyword, out handle);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to Create profile, " + (ConnectionError)ret);
                    ConnectionErrorFactory.CheckFeatureUnsupportedException(ret, "http://tizen.org/feature/network.wifi " + "http://tizen.org/feature/network.telephony");
                    ConnectionErrorFactory.CheckPermissionDeniedException(ret, "(http://tizen.org/privilege/network.get)");
                    ConnectionErrorFactory.ThrowConnectionException(ret);
                }

                return handle;
            }

            else
            {
                throw new ArgumentNullException("Keyword is null");
            }
        }

        internal void AddCellularProfile(CellularProfile profile)
        {

            Log.Debug(Globals.LogTag, "AddCellularProfile");
            if (profile != null)
            {
                if (profile.Type == ConnectionProfileType.Cellular)
                {
                    int ret = Interop.Connection.AddProfile(GetHandle(), profile.ProfileHandle);
                    if ((ConnectionError)ret != ConnectionError.None)
                    {
                        Log.Error(Globals.LogTag, "Failed to add cellular profile, " + (ConnectionError)ret);
                        ConnectionErrorFactory.CheckFeatureUnsupportedException(ret, "http://tizen.org/feature/network.telephony");
                        ConnectionErrorFactory.CheckPermissionDeniedException(ret, "(http://tizen.org/privilege/network.profile)");
                        ConnectionErrorFactory.CheckHandleNullException(ret, (GetHandle() == IntPtr.Zero || profile.ProfileHandle == IntPtr.Zero), "Connection or Profile Handle may have been disposed or released");
                        ConnectionErrorFactory.ThrowConnectionException(ret);
                    }
                }

                else
                {
                    throw new ArgumentException("Profile type is not cellular");
                }
            }

            else
            {
                throw new ArgumentNullException("Profile is null");
            }
        }

        internal void RemoveProfile(ConnectionProfile profile)
        {
            Log.Debug(Globals.LogTag, "RemoveProfile");
            if (profile != null)
            {
                int ret = Interop.Connection.RemoveProfile(GetHandle(), profile.ProfileHandle);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to remove profile, " + (ConnectionError)ret);
                    ConnectionErrorFactory.CheckFeatureUnsupportedException(ret, "http://tizen.org/feature/network.wifi " + "http://tizen.org/feature/network.telephony");
                    ConnectionErrorFactory.CheckHandleNullException(ret, (GetHandle() == IntPtr.Zero || profile.ProfileHandle == IntPtr.Zero), "Connection or Profile Handle may have been disposed or released");
                    ConnectionErrorFactory.ThrowConnectionException(ret);
                }
            }

            else
            {
                throw new ArgumentNullException("Profile is null");
            }
        }

        internal void UpdateProfile(ConnectionProfile profile)
        {
            Log.Info(Globals.LogTag, "UpdateProfile");
            if (profile != null)
            {
                int ret = Interop.Connection.UpdateProfile(GetHandle(), profile.ProfileHandle);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to update profile, " + (ConnectionError)ret);
                    ConnectionErrorFactory.CheckFeatureUnsupportedException(ret, "http://tizen.org/feature/network.telephony " + "http://tizen.org/feature/network.wifi " + "http://tizen.org/feature/network.ethernet");
                    ConnectionErrorFactory.CheckHandleNullException(ret, (GetHandle() == IntPtr.Zero || profile.ProfileHandle == IntPtr.Zero), "Connection or Profile Handle may have been disposed or released");
                    ConnectionErrorFactory.ThrowConnectionException(ret);
                }
            }

            else
            {
                throw new ArgumentNullException("Profile is null");
            }
        }

        internal ConnectionProfile GetCurrentProfile()
        {
            Log.Info(Globals.LogTag, "GetCurrentProfile");
            IntPtr ProfileHandle;
            int ret = Interop.Connection.GetCurrentProfile(GetHandle(), out ProfileHandle);
            if ((ConnectionError)ret != ConnectionError.None)
            {
                if ((ConnectionError)ret == ConnectionError.NoConnection)
                {
                    Log.Error(Globals.LogTag, "No connection " + (ConnectionError)ret);
                    return null;
                }
                else if ((ConnectionError)ret == ConnectionError.InvalidParameter)
                {
                    throw new InvalidOperationException("Invalid handle");
                }
                else
                {
                    Log.Error(Globals.LogTag, "It failed to get current profile, " + (ConnectionError)ret);
                    ConnectionErrorFactory.CheckFeatureUnsupportedException(ret, "http://tizen.org/feature/network.telephony " + "http://tizen.org/feature/network.wifi " + "http://tizen.org/feature/network.tethering.bluetooth " + "http://tizen.org/feature/network.ethernet");
                    ConnectionErrorFactory.CheckPermissionDeniedException(ret, "(http://tizen.org/privilege/network.get)");
                    ConnectionErrorFactory.CheckHandleNullException(ret, (GetHandle() == IntPtr.Zero), "Connection Handle may have been disposed or released");
                    ConnectionErrorFactory.ThrowConnectionException(ret);
                }
            }

            ConnectionProfile Profile = new ConnectionProfile(ProfileHandle);
            return Profile;
        }

        internal ConnectionProfile GetDefaultCellularProfile(CellularServiceType type)
        {
            Log.Debug(Globals.LogTag, "GetDefaultCellularProfile");
            IntPtr ProfileHandle;
            int ret = Interop.Connection.GetDefaultCellularServiceProfile(GetHandle(), (int)type, out ProfileHandle);
            if ((ConnectionError)ret != ConnectionError.None)
            {
                Log.Error(Globals.LogTag, "Error: " + ret);
                Log.Error(Globals.LogTag, "It failed to get default cellular profile, " + (ConnectionError)ret);
                ConnectionErrorFactory.CheckFeatureUnsupportedException(ret, "http://tizen.org/feature/network.telephony");
                ConnectionErrorFactory.CheckPermissionDeniedException(ret, "(http://tizen.org/privilege/network.get)");
                ConnectionErrorFactory.CheckHandleNullException(ret, (GetHandle() == IntPtr.Zero), "Connection Handle may have been disposed or released");
                ConnectionErrorFactory.ThrowConnectionException(ret);
            }

            CellularProfile Profile = new CellularProfile(ProfileHandle);
            return Profile;
        }

        internal Task SetDefaultCellularProfile(CellularServiceType type, ConnectionProfile profile)
        {
            Log.Info(Globals.LogTag, "SetDefaultCellularProfile");
            if (profile != null)
            {
                TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
                IntPtr id;
                lock (_callback_map)
                {
                    id = (IntPtr)_requestId++;
                    _callback_map[id] = (error, key) =>
                    {
                        Log.Info(Globals.LogTag, "SetDefaultCellularProfile done " + profile.Name);
                        if (error != ConnectionError.None)
                        {
                            Log.Error(Globals.LogTag, "Error occurs during set default cellular profile, " + error);
                            task.SetException(new InvalidOperationException("Error occurs during set default cellular profile, " + error));
                        }
                        else
                        {
                            task.SetResult(true);
                        }
                        lock (_callback_map)
                        {
                            _callback_map.Remove(key);
                        }
                    };
                }

                Log.Info(Globals.LogTag, "Interop.Connection.SetDefaultCellularServiceProfileAsync " + profile.Name);
                try
                {
                    int ret = Interop.Connection.SetDefaultCellularServiceProfileAsync(GetHandle(), (int)type, profile.ProfileHandle, _callback_map[id], id);

                    if ((ConnectionError)ret != ConnectionError.None)
                    {
                        Log.Error(Globals.LogTag, "It failed to set default cellular profile, " + (ConnectionError)ret);
                        ConnectionErrorFactory.CheckFeatureUnsupportedException(ret, "http://tizen.org/feature/network.telephony");
                        ConnectionErrorFactory.CheckHandleNullException(ret, (GetHandle() == IntPtr.Zero || profile.ProfileHandle == IntPtr.Zero), "Connection or Profile Handle may have been disposed or released");
                        ConnectionErrorFactory.ThrowConnectionException(ret);
                    }
                } catch (Exception e)
                {
                    Log.Error(Globals.LogTag, "Exception on SetDefaultCellularServiceProfileAsync\n" + e.ToString());
                    task.SetException(e);
                }

                return task.Task;
            }
            else
            {
                throw new ArgumentNullException("Profile is null");
            }
        }


        internal Task<IEnumerable<ConnectionProfile>> GetProfileListAsync(ProfileListType type)
        {
            Log.Debug(Globals.LogTag, "GetProfileListAsync");
            var task = new TaskCompletionSource<IEnumerable<ConnectionProfile>>();

            List<ConnectionProfile> Result = new List<ConnectionProfile>();
            IntPtr iterator;
            int ret = Interop.Connection.GetProfileIterator(GetHandle(), (int)type, out iterator);
            if ((ConnectionError)ret != ConnectionError.None)
            {
                Log.Error(Globals.LogTag, "It failed to get profile iterator, " + (ConnectionError)ret);
                ConnectionErrorFactory.CheckFeatureUnsupportedException(ret, "http://tizen.org/feature/network.telephony " + "http://tizen.org/feature/network.wifi " + "http://tizen.org/feature/network.tethering.bluetooth " + "http://tizen.org/feature/network.ethernet");
                ConnectionErrorFactory.CheckPermissionDeniedException(ret, "(http://tizen.org/privilege/network.get)");
                ConnectionErrorFactory.CheckHandleNullException(ret, (GetHandle() == IntPtr.Zero), "Connection Handle may have been disposed or released");
                ConnectionErrorFactory.ThrowConnectionException(ret);
            }

            while (Interop.Connection.HasNextProfileIterator(iterator))
            {
                IntPtr nextH;
                IntPtr profileH;
                Interop.Connection.GetNextProfileIterator(iterator, out nextH);
                Interop.ConnectionProfile.Clone(out profileH, nextH);

                int profileType;
                Interop.ConnectionProfile.GetType(profileH, out profileType);

                if ((ConnectionProfileType)profileType == ConnectionProfileType.WiFi)
                {
                    WiFiProfile cur = new WiFiProfile(profileH);
                    Result.Add(cur);
                }
                else if ((ConnectionProfileType)profileType == ConnectionProfileType.Cellular)
                {
                    CellularProfile cur = new CellularProfile(profileH);
                    Result.Add(cur);
                }
                else {
                    ConnectionProfile cur = new ConnectionProfile(profileH);
                    Result.Add(cur);
                }
            }
            Interop.Connection.DestroyProfileIterator(iterator);
            task.SetResult(Result);
            return task.Task;
        }

        internal Task OpenProfileAsync(ConnectionProfile profile)
        {
            Log.Info(Globals.LogTag, "OpenProfileAsync");
            if (profile != null)
            {
                Log.Debug(Globals.LogTag, "OpenProfileAsync " + profile.Name);
                TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
                IntPtr id;
                lock (_callback_map)
                {
                    id = (IntPtr)_requestId++;
                    _callback_map[id] = (error, key) =>
                    {
                        Log.Info(Globals.LogTag, "OpenProfileAsync done " + profile.Name);
                        if (error != ConnectionError.None)
                        {
                            Log.Error(Globals.LogTag, "Error occurs during connecting profile, " + error);
                            task.SetException(new InvalidOperationException("Error occurs during connecting profile, " + error));
                        }
                        else
                        {
                            task.SetResult(true);
                        }
                        lock (_callback_map)
                        {
                            _callback_map.Remove(key);
                        }
                    };
                }

                Log.Info(Globals.LogTag, "Interop.Connection.OpenProfile " + profile.Name);
                try
                {
                    int ret = Interop.Connection.OpenProfile(GetHandle(), profile.ProfileHandle, _callback_map[id], id);
                    if ((ConnectionError)ret != ConnectionError.None)
                    {
                        Log.Error(Globals.LogTag, "It failed to connect profile, " + (ConnectionError)ret);
                        ConnectionErrorFactory.CheckFeatureUnsupportedException(ret, "http://tizen.org/feature/network.telephony " + "http://tizen.org/feature/network.wifi " + "http://tizen.org/feature/network.tethering.bluetooth");
                        ConnectionErrorFactory.CheckHandleNullException(ret, (GetHandle() == IntPtr.Zero || profile.ProfileHandle == IntPtr.Zero), "Connection or Profile Handle may have been disposed or released");
                        ConnectionErrorFactory.ThrowConnectionException(ret);
                    }
                }
                catch (Exception e)
                {
                    Log.Error(Globals.LogTag, "Exception on OpenProfile\n" + e.ToString());
                    task.SetException(e);
                }

                return task.Task;
            }

            else
            {
                throw new ArgumentNullException("Profile is null");
            }
        }

        internal Task CloseProfileAsync(ConnectionProfile profile)
        {
            Log.Info(Globals.LogTag, "CloseProfileAsync");
            if (profile != null)
            {
                Log.Info(Globals.LogTag, "CloseProfileAsync " + profile.Name);
                TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
                IntPtr id;
                lock (_callback_map)
                {
                    id = (IntPtr)_requestId++;
                    _callback_map[id] = (error, key) =>
                    {
                        Log.Info(Globals.LogTag, "CloseProfileAsync done " + profile.Name);
                        if (error!= ConnectionError.None)
                        {
                            Log.Error(Globals.LogTag, "Error occurs during disconnecting profile, " + error);
                            task.SetException(new InvalidOperationException("Error occurs during disconnecting profile, " + error));
                        }
                        else
                        {
                            task.SetResult(true);
                        }
                        lock (_callback_map)
                        {
                            _callback_map.Remove(key);
                        }
                    };
                }

                Log.Info(Globals.LogTag, "Interop.Connection.CloseProfile " + profile.Name);
                try
                {
                    int ret = Interop.Connection.CloseProfile(GetHandle(), profile.ProfileHandle, _callback_map[id], id);
                    if ((ConnectionError)ret != ConnectionError.None)
                    {
                        Log.Error(Globals.LogTag, "It failed to disconnect profile, " + (ConnectionError)ret);
                        ConnectionErrorFactory.CheckFeatureUnsupportedException(ret, "http://tizen.org/feature/network.telephony " + "http://tizen.org/feature/network.wifi " + "http://tizen.org/feature/network.tethering.bluetooth");
                        ConnectionErrorFactory.CheckPermissionDeniedException(ret, "(http://tizen.org/privilege/network.set)");
                        ConnectionErrorFactory.CheckHandleNullException(ret, (GetHandle() == IntPtr.Zero || profile.ProfileHandle == IntPtr.Zero), "Connection or Profile Handle may have been disposed or released");
                        ConnectionErrorFactory.ThrowConnectionException(ret);
                    }
                }
                catch (Exception e)
                {
                    Log.Error(Globals.LogTag, "Exception on CloseProfile\n" + e.ToString());
                    task.SetException(e);
                }

                return task.Task;
            }

            else
            {
                throw new ArgumentNullException("Profile is null");
            }
        }
    }
}
