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
using System.Collections;
using System.Threading;

namespace Tizen.Network.Connection
{
    class HandleHolder : IDisposable
    {
        private IntPtr Handle;
        private bool disposed = false;

        public HandleHolder()
        {
            Log.Debug(Globals.LogTag, "Handle: " + Handle);
            int ret = Interop.Connection.Create(out Handle);
            if(ret != (int)ConnectionError.None)
            {
                ConnectionErrorFactory.CheckFeatureUnsupportedException(ret, "http://tizen.org/feature/network.telephony " + "http://tizen.org/feature/network.wifi " + "http://tizen.org/feature/network.tethering.bluetooth " + "http://tizen.org/feature/network.ethernet");
                ConnectionErrorFactory.CheckPermissionDeniedException(ret, "(http://tizen.org/privilege/network.get)");
                ConnectionErrorFactory.ThrowConnectionException(ret);
            }
        }

        ~HandleHolder()
        {
            Dispose(false);
        }

        internal IntPtr GetHandle()
        {
            Log.Debug(Globals.LogTag, "handleholder handle = " + Handle);
            return Handle;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            Log.Debug(Globals.LogTag, ">>> HandleHolder Dispose with " + disposing);
            Log.Debug(Globals.LogTag, ">>> Handle: " + Handle);
            if (disposed)
                return;

            if (disposing)
            {
                // Free managed objects.
                Destroy();
            }
            disposed = true;
        }

        private void Destroy()
        {
            Interop.Connection.Destroy(Handle);
            if (Handle != IntPtr.Zero)
            {
                Handle = IntPtr.Zero;
            }
        }
    }

    internal class ConnectionInternalManager
    {
        private bool disposed = false;
        private static ConnectionInternalManager s_instance = null;

        private EventHandler _ConnectionTypeChanged = null;
        private EventHandler _IPAddressChanged = null;
        private EventHandler _EthernetCableStateChanged = null;
        private EventHandler _ProxyAddressChanged = null;

        private Interop.Connection.ConnectionAddressChangedCallback _connectionAddressChangedCallback;
        private Interop.Connection.ConnectionTypeChangedCallback _connectionTypeChangedCallback;
        private Interop.Connection.ConnectionAddressChangedCallback _proxyAddressChangedCallback;

        internal static ConnectionInternalManager Instance
        {
            get
            {
                if (s_instance == null)
                {
                    s_instance = new ConnectionInternalManager();
                }

                return s_instance;
            }
        }

        private static ThreadLocal<HandleHolder> s_threadName = new ThreadLocal<HandleHolder>(() =>
        {
            Log.Info(Globals.LogTag, "In threadlocal delegate");
            return new HandleHolder();
        });

        private ConnectionInternalManager()
        {

        }

        ~ConnectionInternalManager()
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
            Log.Debug(Globals.LogTag, ">>> ConnectionInternalManager Dispose with disposing " + disposing + ", disposed " + disposed);
            Log.Debug(Globals.LogTag, ">>> Handle: " + GetHandle());
            if (disposed)
                return;

            if (disposing)
            {
                // Free managed objects.
            }

            UnregisterEvents();
            disposed = true;
        }

        internal IntPtr GetHandle()
        {
            Log.Debug(Globals.LogTag, "GetHandle, Thread Id = " + Thread.CurrentThread.ManagedThreadId);
            return s_threadName.Value.GetHandle();
        }

        internal event EventHandler ConnectionTypeChanged
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

            int ret = Interop.Connection.SetTypeChangedCallback(GetHandle(), _connectionTypeChangedCallback, IntPtr.Zero);
            if ((ConnectionError)ret != ConnectionError.None)
            {
                Log.Error(Globals.LogTag, "It failed to register connection type changed callback, " + (ConnectionError)ret);
                ConnectionErrorFactory.ThrowConnectionException(ret);
            }
        }

        private void ConnectionTypeChangedStop()
        {
            int ret = Interop.Connection.UnsetTypeChangedCallback(GetHandle());
            if ((ConnectionError)ret != ConnectionError.None)
            {
                Log.Error(Globals.LogTag, "It failed to unregister connection type changed callback, " + (ConnectionError)ret);
                ConnectionErrorFactory.ThrowConnectionException(ret);
            }
        }

        internal event EventHandler EthernetCableStateChanged
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
            int ret = Interop.Connection.SetEthernetCableStateChagedCallback(GetHandle(), EthernetCableStateChangedCallback, IntPtr.Zero);
            if ((ConnectionError)ret != ConnectionError.None)
            {
                Log.Error(Globals.LogTag, "It failed to register ethernet cable state changed callback, " + (ConnectionError)ret);
                ConnectionErrorFactory.ThrowConnectionException(ret);
            }
        }

        private void EthernetCableStateChangedStop()
        {
            int ret = Interop.Connection.UnsetEthernetCableStateChagedCallback(GetHandle());
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

        internal event EventHandler IPAddressChanged
        {
            add
            {
                if (_IPAddressChanged == null)
                {
                    IPAddressChangedStart();
                }
                _IPAddressChanged += value;
            }

            remove
            {
                _IPAddressChanged -= value;
                if (_IPAddressChanged == null)
                {
                    IPAddressChangedStop();
                }
            }
        }

        private void IPAddressChangedStart()
        {
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
            int ret = Interop.Connection.UnsetIPAddressChangedCallback(GetHandle());
            if ((ConnectionError)ret != ConnectionError.None)
            {
                Log.Error(Globals.LogTag, "It failed to unregister callback for changing IP address, " + (ConnectionError)ret);
            }
        }

        internal event EventHandler ProxyAddressChanged
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

        internal string GetIPAddress(AddressFamily family)
        {
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
            return result;
        }

        internal string GetProxy(AddressFamily family)
        {
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
            IntPtr ip;
            int ret = Interop.Connection.GetMacAddress(GetHandle(), (int)type, out ip);
            if ((ConnectionError)ret != ConnectionError.None)
            {
                Log.Error(Globals.LogTag, "It failed to get mac address, " + (ConnectionError)ret);
                ConnectionErrorFactory.CheckFeatureUnsupportedException(ret, "http://tizen.org/feature/network.wifi " + "http://tizen.org/feature/network.ethernet");
                ConnectionErrorFactory.CheckHandleNullException(ret, (GetHandle() == IntPtr.Zero), "Connection Handle may have been disposed or released");
                ConnectionErrorFactory.ThrowConnectionException(ret);
            }
            string result = Marshal.PtrToStringAnsi(ip);
            Interop.Libc.Free(ip);
            return result;
        }

        internal ConnectionType ConnectionType
        {
            get
            {
                int type = 0;
                Log.Debug(Globals.LogTag, "Handle: " + GetHandle());
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
                int type = 0;
                Log.Debug(Globals.LogTag, "CellularState Handle: " + GetHandle());
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
            Log.Debug(Globals.LogTag, "UpdateProfile");
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
            IntPtr ProfileHandle;
            int ret = Interop.Connection.GetCurrentProfile(GetHandle(), out ProfileHandle);
            if ((ConnectionError)ret != ConnectionError.None)
            {
                Log.Error(Globals.LogTag, "It failed to get current profile, " + (ConnectionError)ret);
                ConnectionErrorFactory.CheckFeatureUnsupportedException(ret, "http://tizen.org/feature/network.telephony " + "http://tizen.org/feature/network.wifi " + "http://tizen.org/feature/network.tethering.bluetooth " + "http://tizen.org/feature/network.ethernet");
                ConnectionErrorFactory.CheckPermissionDeniedException(ret, "(http://tizen.org/privilege/network.get)");
                ConnectionErrorFactory.CheckHandleNullException(ret, (GetHandle() == IntPtr.Zero), "Connection Handle may have been disposed or released");
                ConnectionErrorFactory.ThrowConnectionException(ret);
            }

            ConnectionProfile Profile = new ConnectionProfile(ProfileHandle);
            return Profile;
        }

        internal ConnectionProfile GetDefaultCellularProfile(CellularServiceType type)
        {
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
            Log.Debug(Globals.LogTag, "SetDefaultCellularProfile");
            if (profile != null)
            {
                TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
                Interop.Connection.ConnectionCallback Callback = (ConnectionError Result, IntPtr Data) =>
                {
                    if (Result != ConnectionError.None)
                    {
                        Log.Error(Globals.LogTag, "Error occurs during set default cellular profile, " + Result);
                        task.SetException(new InvalidOperationException("Error occurs during set default cellular profile, " + Result));
                    }

                    task.SetResult(true);
                };

                int ret = Interop.Connection.SetDefaultCellularServiceProfileAsync(GetHandle(), (int)type, profile.ProfileHandle, Callback, (IntPtr)0);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to set default cellular profile, " + (ConnectionError)ret);
                    ConnectionErrorFactory.CheckFeatureUnsupportedException(ret, "http://tizen.org/feature/network.telephony");
                    ConnectionErrorFactory.CheckHandleNullException(ret, (GetHandle() == IntPtr.Zero || profile.ProfileHandle == IntPtr.Zero), "Connection or Profile Handle may have been disposed or released");
                    ConnectionErrorFactory.ThrowConnectionException(ret);
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
            Log.Debug(Globals.LogTag, "OpenProfileAsync");
            if (profile != null)
            {
                Log.Debug(Globals.LogTag, "OpenProfileAsync " + profile.Name);
                TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
                Interop.Connection.ConnectionCallback Callback = (ConnectionError Result, IntPtr Data) =>
                {
                    Log.Debug(Globals.LogTag, "Connected " + profile.Name);
                    if (Result != ConnectionError.None)
                    {
                        Log.Error(Globals.LogTag, "Error occurs during connecting profile, " + Result);
                        task.SetException(new InvalidOperationException("Error occurs during connecting profile, " + Result));
                    }

                    task.SetResult(true);
                };

                int ret = Interop.Connection.OpenProfile(GetHandle(), profile.ProfileHandle, Callback, IntPtr.Zero);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to connect profile, " + (ConnectionError)ret);
                    ConnectionErrorFactory.CheckFeatureUnsupportedException(ret, "http://tizen.org/feature/network.telephony " + "http://tizen.org/feature/network.wifi " + "http://tizen.org/feature/network.tethering.bluetooth");
                    ConnectionErrorFactory.CheckHandleNullException(ret, (GetHandle() == IntPtr.Zero || profile.ProfileHandle == IntPtr.Zero), "Connection or Profile Handle may have been disposed or released");
                    ConnectionErrorFactory.ThrowConnectionException(ret);
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
            Log.Debug(Globals.LogTag, "CloseProfileAsync");
            if (profile != null)
            {
                Log.Debug(Globals.LogTag, "CloseProfileAsync " + profile.Name);
                TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
                Interop.Connection.ConnectionCallback Callback = (ConnectionError Result, IntPtr Data) =>
                {
                    if (Result != ConnectionError.None)
                    {
                        Log.Error(Globals.LogTag, "Error occurs during disconnecting profile, " + Result);
                        task.SetException(new InvalidOperationException("Error occurs during disconnecting profile, " + Result));
                    }

                    task.SetResult(true);
                };

                int ret = Interop.Connection.CloseProfile(GetHandle(), profile.ProfileHandle, Callback, IntPtr.Zero);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to disconnect profile, " + (ConnectionError)ret);
                    ConnectionErrorFactory.CheckFeatureUnsupportedException(ret, "http://tizen.org/feature/network.telephony " + "http://tizen.org/feature/network.wifi " + "http://tizen.org/feature/network.tethering.bluetooth");
                    ConnectionErrorFactory.CheckPermissionDeniedException(ret, "(http://tizen.org/privilege/network.set)");
                    ConnectionErrorFactory.CheckHandleNullException(ret, (GetHandle() == IntPtr.Zero || profile.ProfileHandle == IntPtr.Zero), "Connection or Profile Handle may have been disposed or released");
                    ConnectionErrorFactory.ThrowConnectionException(ret);
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
