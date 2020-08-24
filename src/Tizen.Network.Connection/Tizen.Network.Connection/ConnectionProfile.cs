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
using System.Runtime.InteropServices;
using Tizen.Applications;

namespace Tizen.Network.Connection
{
    /// <summary>
    /// This is the ConnectionProfile class. It provides event and properties of the connection profile.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class ConnectionProfile : IDisposable
    {
        internal IntPtr ProfileHandle = IntPtr.Zero;
        private IAddressInformation IPv4;
        private IAddressInformation IPv6;
        private bool disposed = false;
        private EventHandler<ProfileStateEventArgs> _ProfileStateChanged = null;

        private Interop.ConnectionProfile.ProfileStateChangedCallback _profileChangedCallback;

        internal IntPtr GetHandle()
        {
            return ProfileHandle;
        }

        /// <summary>
        /// The event is called when the state of profile is changed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <feature>http://tizen.org/feature/network.ethernet</feature>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <feature>http://tizen.org/feature/network.tethering.bluetooth</feature>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
        /// <exception cref="System.NotSupportedException">Thrown when a feature is not supported.</exception>
        public event EventHandler<ProfileStateEventArgs> ProfileStateChanged
        {
            add
            {
                Log.Debug(Globals.LogTag, "ProfileStateChanged add");
                if (_ProfileStateChanged == null)
                {
                    try
                    {
                        ProfileStateChangedStart();
                    } catch (Exception e)
                    {
                        Log.Error(Globals.LogTag, "Exception on adding ProfileStateChanged\n" + e.ToString());
                        return;
                    }
                }
                _ProfileStateChanged += value;
            }
            remove
            {
                Log.Debug(Globals.LogTag, "ProfileStateChanged remove");
                _ProfileStateChanged -= value;
                if (_ProfileStateChanged == null)
                {
                    try
                    {
                        ProfileStateChangedStop();
                    }
                    catch (Exception e)
                    {
                        Log.Error(Globals.LogTag, "Exception on removing ProfileStateChanged\n" + e.ToString());
                    }
                }
            }
        }

        private void ProfileStateChangedStart()
        {
            _profileChangedCallback = (ProfileState state, IntPtr userData) =>
            {
                if (_ProfileStateChanged != null)
                {
                    _ProfileStateChanged(null, new ProfileStateEventArgs(state));
                }
            };

            Log.Debug(Globals.LogTag, "ProfileStateChangedStart");
            int ret = Interop.ConnectionProfile.SetStateChangeCallback(ProfileHandle, _profileChangedCallback, IntPtr.Zero);
            if ((ConnectionError)ret != ConnectionError.None)
            {
                Log.Error(Globals.LogTag, "It failed to register callback for changing profile state, " + (ConnectionError)ret);
                ConnectionErrorFactory.ThrowConnectionException(ret);
            }
        }

        private void ProfileStateChangedStop()
        {
            Log.Debug(Globals.LogTag, "ProfileStateChangedStop");
            int ret = Interop.ConnectionProfile.UnsetStateChangeCallback(ProfileHandle);
            if ((ConnectionError)ret != ConnectionError.None)
            {
                Log.Error(Globals.LogTag, "It failed to unregister callback for changing profile state, " + (ConnectionError)ret);
                ConnectionErrorFactory.ThrowConnectionException(ret);
            }
        }

        internal ConnectionProfile(IntPtr handle)
        {
            ProfileHandle = handle;
            IPv4 = new ConnectionAddressInformation(ProfileHandle, AddressFamily.IPv4);
            IPv6 = new ConnectionAddressInformation(ProfileHandle, AddressFamily.IPv6);
        }

        /// <summary>
        /// Destroy the ConnectionProfile object
        /// </summary>
        ~ConnectionProfile()
        {
            Dispose(false);
        }

        /// <summary>
        /// Disposes the memory allocated to unmanaged resources.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            Log.Debug(Globals.LogTag, ">>> ConnectionProfile Dispose with " + disposing);
            if (disposed)
                return;

            // Free unmanaged objects
            UnregisterEvents();
            Destroy();
            disposed = true;
        }

        private void UnregisterEvents()
        {
            if (_ProfileStateChanged != null)
            {
                ProfileStateChangedStop();
            }
        }

        private void Destroy()
        {
            int ret = Interop.ConnectionProfile.Destroy(ProfileHandle);
            if ((ConnectionError)ret == ConnectionError.None)
            {
                ProfileHandle = IntPtr.Zero;
            }
            
        }

        internal void CheckDisposed()
        {
            if (disposed)
            {
                throw new ObjectDisposedException(GetType().FullName);
            }
        }

        /// <summary>
        /// The profile ID.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>Unique ID of the profile.</value>
        public string Id
        {
            get
            {
                IntPtr Value;
                int ret = Interop.ConnectionProfile.GetId(ProfileHandle, out Value);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get id of connection profile, " + (ConnectionError)ret);
                }
                string result = Marshal.PtrToStringAnsi(Value);
                Interop.Libc.Free(Value);
                return result;
            }
        }

        /// <summary>
        /// The profile name.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>User friendly name of the profile.</value>
        public string Name
        {
            get
            {
                IntPtr Value;
                int ret = Interop.ConnectionProfile.GetName(ProfileHandle, out Value);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get name of connection profile, " + (ConnectionError)ret);
                }
                string result = Marshal.PtrToStringAnsi(Value);
                Interop.Libc.Free(Value);
                return result;
            }
        }

        /// <summary>
        /// The network type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>Profile type of the network connection.</value>
        public ConnectionProfileType Type
        {
            get
            {
                int Value;
                int ret = Interop.ConnectionProfile.GetType(ProfileHandle, out Value);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get type of connection profile, " + (ConnectionError)ret);
                }
                return (ConnectionProfileType)Value;
            }
        }

        /// <summary>
        /// The name of the network interface.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>Network interface name, for example, eth0 and pdp0.</value>
        public string InterfaceName
        {
            get
            {
                IntPtr Value;
                int ret = Interop.ConnectionProfile.GetNetworkInterfaceName(ProfileHandle, out Value);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get network interface name, " + (ConnectionError)ret);
                }
                string result = Marshal.PtrToStringAnsi(Value);
                Interop.Libc.Free(Value);
                return result;
            }
        }

        /// <summary>
        /// Refreshes the profile information.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <feature>http://tizen.org/feature/network.ethernet</feature>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <feature>http://tizen.org/feature/network.tethering.bluetooth</feature>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
        /// <exception cref="System.NotSupportedException">Thrown when a feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when a permission is denied.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when a profile instance is invalid or when a method fails due to an invalid operation.</exception>
        /// <exception cref="System.ObjectDisposedException">Thrown when an operation is performed on a disposed object.</exception>
        public void Refresh()
        {
            CheckDisposed();
            int ret = Interop.ConnectionProfile.Refresh(ProfileHandle);
            if ((ConnectionError)ret != ConnectionError.None)
            {
                Log.Error(Globals.LogTag, "It failed to get network interface name, " + (ConnectionError)ret);
                if ((ConnectionError)ret == ConnectionError.InvalidParameter)
                {
                    throw new InvalidOperationException("Invalid handle");
                }
                ConnectionErrorFactory.CheckFeatureUnsupportedException(ret, "http://tizen.org/feature/network.telephony " + "http://tizen.org/feature/network.wifi " + "http://tizen.org/feature/network.tethering.bluetooth " + "http://tizen.org/feature/network.ethernet");
                ConnectionErrorFactory.CheckPermissionDeniedException(ret, "(http://tizen.org/privilege/network.get)");
                ConnectionErrorFactory.CheckHandleNullException(ret, (ProfileHandle == IntPtr.Zero), "ProfileHandle may have been disposed or released");
                ConnectionErrorFactory.ThrowConnectionException(ret);
            }
        }

        /// <summary>
        /// Gets the network state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="family">The address family.</param>
        /// <returns>The network state.</returns>
        /// <feature>http://tizen.org/feature/network.ethernet</feature>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <feature>http://tizen.org/feature/network.tethering.bluetooth</feature>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
        /// <exception cref="System.NotSupportedException">Thrown when a feature is not supported.</exception>
        /// <exception cref="System.ArgumentException">Thrown when a value is an invalid parameter.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when a profile instance is invalid or when a method fails due to an invalid operation.</exception>
        /// <exception cref="System.ObjectDisposedException">Thrown when an operation is performed on a disposed object.</exception>
        public ProfileState GetState(AddressFamily family)
        {
            CheckDisposed();
            int Value;
            int ret = (int)ConnectionError.None;
            if (family == AddressFamily.IPv4)
            {
                ret = Interop.ConnectionProfile.GetState(ProfileHandle, out Value);
            }

            else
            {
                ret = Interop.ConnectionProfile.GetIPv6State(ProfileHandle, out Value);
            }

            if ((ConnectionError)ret != ConnectionError.None)
            {
                Log.Error(Globals.LogTag, "It failed to get profile state, " + (ConnectionError)ret);
                ConnectionErrorFactory.CheckFeatureUnsupportedException(ret, "http://tizen.org/feature/network.telephony " + "http://tizen.org/feature/network.wifi " + "http://tizen.org/feature/network.tethering.bluetooth " + "http://tizen.org/feature/network.ethernet");
                ConnectionErrorFactory.CheckHandleNullException(ret, (ProfileHandle == IntPtr.Zero), "ProfileHandle may have been disposed or released");
                ConnectionErrorFactory.ThrowConnectionException(ret);
            }

            return (ProfileState)Value;
        }

        /// <summary>
        /// The Proxy type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>Proxy type of the connection.</value>
        /// <exception cref="System.NotSupportedException">Thrown during set when a feature is not supported.</exception>
        /// <exception cref="System.ArgumentException">Thrown during set when a value is an invalid parameter.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown during set when a profile instance is invalid or when a method fails due to an invalid operation.</exception>
        /// <exception cref="System.ObjectDisposedException">Thrown during set when a operation is performed on a disposed object.</exception>
        public ProxyType ProxyType
        {
            get
            {
                int Value;
                int ret = Interop.ConnectionProfile.GetProxyType(ProfileHandle, out Value);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get proxy type, " + (ConnectionError)ret);
                }
                return (ProxyType)Value;

            }

            set
            {
                CheckDisposed();
                int ret = Interop.ConnectionProfile.SetProxyType(ProfileHandle, (int)value);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to set proxy type, " + (ConnectionError)ret);
                    ConnectionErrorFactory.CheckFeatureUnsupportedException(ret, "http://tizen.org/feature/network.telephony " + "http://tizen.org/feature/network.wifi " + "http://tizen.org/feature/network.tethering.bluetooth " + "http://tizen.org/feature/network.ethernet");
                    ConnectionErrorFactory.CheckHandleNullException(ret, (ProfileHandle == IntPtr.Zero), "ProfileHandle may have been disposed or released");
                    ConnectionErrorFactory.ThrowConnectionException(ret);
                }
            }
        }

        /// <summary>
        /// The proxy address.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>Proxy address of the connection.</value>
        /// <exception cref="System.NotSupportedException">Thrown during set when a feature is not supported.</exception>
        /// <exception cref="System.ArgumentException">Thrown during set when a value is an invalid parameter.</exception>
        /// <exception cref="System.ArgumentNullException">Thrown during set when a value is null.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown during set when a profile instance is invalid or when a method fails due to an invalid operation.</exception>
        /// <exception cref="System.ObjectDisposedException">Thrown when an operation is performed on a disposed object.</exception>
        public string ProxyAddress
        {
            get
            {
                IntPtr Value;
                int ret = Interop.ConnectionProfile.GetProxyAddress(ProfileHandle, (int)AddressFamily.IPv4, out Value);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get proxy address, " + (ConnectionError)ret);
                }
                string result = Marshal.PtrToStringAnsi(Value);
                Interop.Libc.Free(Value);
                return result;

            }

            set
            {
                CheckDisposed();
                if (value != null)
                {
                    int ret = Interop.ConnectionProfile.SetProxyAddress(ProfileHandle, (int)AddressFamily.IPv4, value);
                    if ((ConnectionError)ret != ConnectionError.None)
                    {
                        Log.Error(Globals.LogTag, "It failed to set proxy address, " + (ConnectionError)ret);
                        ConnectionErrorFactory.CheckFeatureUnsupportedException(ret, "http://tizen.org/feature/network.telephony " + "http://tizen.org/feature/network.wifi " + "http://tizen.org/feature/network.tethering.bluetooth " + "http://tizen.org/feature/network.ethernet");
                        ConnectionErrorFactory.CheckHandleNullException(ret, (ProfileHandle == IntPtr.Zero), "ProfileHandle may have been disposed or released");
                        ConnectionErrorFactory.ThrowConnectionException(ret);
                    }
                }

                else
                {
                    throw new ArgumentNullException("ProxyAddress is null");
                }
            }
        }

        /// <summary>
        /// The address information (IPv4).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>Instance of IAddressInformation with IPV4 address.</value>
        public IAddressInformation IPv4Settings
        {
            get
            {
                return IPv4;

            }
        }

        /// <summary>
        /// The address information (IPv6).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>Instance of IAddressInformation with IPV6 address.</value>
        public IAddressInformation IPv6Settings
        {
            get
            {
                return IPv6;
            }
        }
    }

    /// <summary>
    /// An extended EventArgs class, which contains changed profile state.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class ProfileStateEventArgs : EventArgs
    {
        private ProfileState _State = ProfileState.Disconnected;

        internal ProfileStateEventArgs(ProfileState state)
        {
            _State = state;
        }

        /// <summary>
        /// The profile state.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>State type of the connection profile.</value>
        public ProfileState State
        {
            get
            {
                return _State;
            }
        }
    }
}
