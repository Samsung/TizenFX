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
using System.Runtime.InteropServices;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Tizen.Network.Bluetooth
{
    /// <summary>
    /// A class which is used to handle the connection with other devices and set authorization of other devices.<br>
    /// The BluetoothDevice class is used to search for services available on remote devices.
    /// </summary>
    /// <privilege> http://tizen.org/privilege/bluetooth </privilege>
    public class BluetoothDevice
    {
        private event EventHandler<BondCreatedEventArgs> _bondCreated;
        private event EventHandler<BondDestroyedEventArgs> _bondDestroyed;
        private event EventHandler<AuthorizationChangedEventArgs> _authorizationChanged;
        private event EventHandler<ServiceSearchedEventArgs> _serviceSearched;
        private event EventHandler<DeviceConnectionStateChangedEventArgs> _connectionChanged;

        private Interop.Bluetooth.BondCreatedCallback _bondCreatedCallback;
        private Interop.Bluetooth.BondDestroyedCallback _bondDestroyedCallback;
        private Interop.Bluetooth.AuthorizationChangedCallback _authorizationChangedCallback;
        private Interop.Bluetooth.ServiceSearchedCallback _serviceSearchedCallback;
        private Interop.Bluetooth.DeviceConnectionStateChangedCallback _connectionChangedCallback;

        internal string RemoteDeviceAddress;
        internal string RemoteDeviceName;
        internal int RemoteDeviceRssi;
        internal BluetoothClass RemoteDeviceClass;
        internal Collection<string> RemoteDeviceService;
        internal int RemoteDeviceCount;
        internal bool RemotePaired;
        internal bool RemoteAuthorized;
        internal bool RemoteConnected;
        internal BluetoothAppearanceType RemoteAppearance;
        internal int RemoteManufLength;
        internal string RemoteManufData;

        internal BluetoothDevice()
        {
        }

        /// <summary>
        /// Address of device.
        /// </summary>
        public string Address
        {
            get
            {
                return RemoteDeviceAddress;
            }
        }
        /// <summary>
        /// Name of device.
        /// </summary>
        public string Name
        {
            get
            {
                return RemoteDeviceName;
            }
        }
        /// <summary>
        /// Strength indicator of received signal of device.
        /// </summary>
        public int Rssi
        {
            get
            {
                return RemoteDeviceRssi;
            }
        }
        /// <summary>
        /// Class of device.
        /// </summary>
        public BluetoothClass Class
        {
            get
            {
                return RemoteDeviceClass;
            }
        }
        /// <summary>
        /// Service UUID list of device.
        /// </summary>
        public IEnumerable<string> ServiceUuidList
        {
            get
            {
                return RemoteDeviceService;
            }
        }
        /// <summary>
        /// The number of services.
        /// </summary>
        public int ServiceCount
        {
            get
            {
                return RemoteDeviceCount;
            }
        }
        /// <summary>
        /// The paired state of device.
        /// </summary>
        public bool IsPaired
        {
            get
            {
                return RemotePaired;
            }
        }
        /// <summary>
        /// The connection state of device.
        /// </summary>
        public bool IsConnected
        {
            get
            {
                return RemoteConnected;
            }
        }
        /// <summary>
        /// The authorization state of device.
        /// </summary>
        public bool IsAuthorized
        {
            get
            {
                return RemoteAuthorized;
            }
        }
        /// <summary>
        /// Bluetooth Appearance.
        /// </summary>
        public BluetoothAppearanceType AppearanceType
        {
            get
            {
                return RemoteAppearance;
            }
        }

        /// <summary>
        /// The length of manufacturer data.
        /// </summary>
        public int ManufacturerDataLength
        {
            get
            {
                return RemoteManufLength;
            }
        }
        /// <summary>
        /// The manufacturer data.
        /// </summary>
        public string ManufacturerData
        {
            get
            {
                return RemoteManufData;
            }
        }

        /// <summary>
        /// (event) BondCreated is raised when process of creating bond is finished.
        /// </summary>
        public event EventHandler<BondCreatedEventArgs> BondCreated
        {
            add
            {
                if (_bondCreated == null)
                {
                    RegisterBondCreatedEvent();
                }
                _bondCreated += value;
            }
            remove
            {
                _bondCreated -= value;
                if (_bondCreated == null)
                {
                    UnregisterBondCreatedEvent();
                }
            }
        }

        /// <summary>
        /// (event) BondDestroyed is raised when the bond is destroyed.
        /// </summary>
        public event EventHandler<BondDestroyedEventArgs> BondDestroyed
        {
            add
            {
                if (_bondDestroyed == null)
                {
                    RegisterBondDestroyedEvent();
                }
                _bondDestroyed += value;
            }
            remove
            {
                _bondDestroyed -= value;
                if (_bondDestroyed == null)
                {
                    UnregisterBondDestroyedEvent();
                }
            }
        }

        /// <summary>
        /// (event) AuthorizationChanged is raised when the authorization of device is changed.
        /// </summary>
        public event EventHandler<AuthorizationChangedEventArgs> AuthorizationChanged
        {
            add
            {
                if (_authorizationChanged == null)
                {
                    RegisterAuthorizationChangedEvent();
                }
                _authorizationChanged += value;
            }
            remove
            {
                _authorizationChanged -= value;
                if (_authorizationChanged == null)
                {
                    UnregisterAuthorizationChangedEvent();
                }
            }
        }

        /// <summary>
        /// (event) ServiceSearched is raised when the process of service searched is finished.
        /// </summary>
        public event EventHandler<ServiceSearchedEventArgs> ServiceSearched
        {
            add
            {
                if (_serviceSearched == null)
                {
                    RegisterServiceSearchedEvent();
                }
                _serviceSearched += value;
            }
            remove
            {
                _serviceSearched -= value;
                if (_serviceSearched == null)
                {
                    UnregisterServiceSearchedEvent();
                }
            }
        }

        /// <summary>
        /// (event) ConnectionStateChanged is raised when the connection state is changed.
        /// </summary>
        public event EventHandler<DeviceConnectionStateChangedEventArgs> ConnectionStateChanged
        {
            add
            {
                if (_connectionChanged == null)
                {
                    RegisterConnectionChangedEvent();
                }
                _connectionChanged += value;
            }
            remove
            {
                _connectionChanged -= value;
                if (_connectionChanged == null)
                {
                    UnregisterConnectionChangedEvent();
                }
            }
        }

        private void RegisterBondCreatedEvent()
        {
            _bondCreatedCallback = (int result, ref BluetoothDeviceStruct device, IntPtr userData) =>
            {
                if (_bondCreated != null)
                {
                    BluetoothError res = (BluetoothError)result;
                    _bondCreated(null, new BondCreatedEventArgs(res, BluetoothUtils.ConvertStructToDeviceClass(device)));
                }
            };
            int ret = Interop.Bluetooth.SetBondCreatedCallback(_bondCreatedCallback, IntPtr.Zero);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set bond created callback, Error - " + (BluetoothError)ret);
            }
        }

        private void UnregisterBondCreatedEvent()
        {
            int ret = Interop.Bluetooth.UnsetBondCreatedCallback();
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to unset bond created callback, Error - " + (BluetoothError)ret);
            }
        }

        private void RegisterBondDestroyedEvent()
        {
            _bondDestroyedCallback = (int result, string deviceAddress, IntPtr userData) =>
            {
                if (_bondDestroyed != null)
                {
                    BluetoothError res = (BluetoothError)result;
                    _bondDestroyed(null, new BondDestroyedEventArgs(res, deviceAddress));
                }
            };
            int ret = Interop.Bluetooth.SetBondDestroyedCallback(_bondDestroyedCallback, IntPtr.Zero);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set bond destroyed callback, Error - " + (BluetoothError)ret);
            }
        }

        private void UnregisterBondDestroyedEvent()
        {
            int ret = Interop.Bluetooth.UnsetBondDestroyedCallback();
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to unset bond destroyed callback, Error - " + (BluetoothError)ret);
            }
        }

        private void RegisterServiceSearchedEvent()
        {
            _serviceSearchedCallback = (int result, ref BluetoothDeviceSdpStruct sdp, IntPtr userData) =>
            {
                Log.Info(Globals.LogTag, "Servicesearched cb is called");
                if (_serviceSearched != null)
                {
                    BluetoothError res = (BluetoothError)result;
                    _serviceSearched(null, new ServiceSearchedEventArgs(res, BluetoothUtils.ConvertStructToSdpData(sdp)));
                }
            };
            int ret = Interop.Bluetooth.SetServiceSearchedCallback(_serviceSearchedCallback, IntPtr.Zero);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set service searched callback, Error - " + (BluetoothError)ret);
            }
        }

        private void UnregisterServiceSearchedEvent()
        {
            int ret = Interop.Bluetooth.UnsetServiceSearchedCallback();
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to unset service searched callback, Error - " + (BluetoothError)ret);
            }
        }

        private void RegisterAuthorizationChangedEvent()
        {
            _authorizationChangedCallback = (int authorization, string deviceAddress, IntPtr userData) =>
            {
                Log.Info(Globals.LogTag, "Authorization changed cb is called");
                if (_authorizationChanged != null)
                {
                    BluetoothAuthorizationType auth = (BluetoothAuthorizationType)authorization;
                    _authorizationChanged(null, new AuthorizationChangedEventArgs(auth, deviceAddress));
                }
            };
            int ret = Interop.Bluetooth.SetAuthorizationChangedCallback(_authorizationChangedCallback, IntPtr.Zero);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set authroization changed callback, Error - " + (BluetoothError)ret);
            }
        }

        private void UnregisterAuthorizationChangedEvent()
        {
            int ret = Interop.Bluetooth.UnsetAuthorizationChangedCallback();
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to unset authroization changed callback, Error - " + (BluetoothError)ret);
            }
        }

        private void RegisterConnectionChangedEvent()
        {
            _connectionChangedCallback = (bool connected, ref BluetoothDeviceConnectionStruct device, IntPtr userData) =>
            {
                Log.Info(Globals.LogTag, "Connection state changed cb is called");
                if (_connectionChanged != null)
                {
                    _connectionChanged(null, new DeviceConnectionStateChangedEventArgs(connected, BluetoothUtils.ConvertStructToConnectionData(device)));
                }
            };

            int ret = Interop.Bluetooth.SetConnectionStateChangedCallback(_connectionChangedCallback, IntPtr.Zero);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set connection state changed callback, Error - " + (BluetoothError)ret);
            }
        }

        private void UnregisterConnectionChangedEvent()
        {
            int ret = Interop.Bluetooth.UnsetConnectionStateChangedCallback();
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to unset connection state changed callback, Error - " + (BluetoothError)ret);
            }
        }

        /// <summary>
        /// Creates a bond with remote Bluetooth device.
        /// </summary>
        /// <remarks>
        /// The Bluetooth must be enabled and remote device must be discoverable by StartDiscovery().The bond can be destroyed by DestroyBond().
        /// The bonding request can be cancelled by CancelBonding().If this succeeds, BondCreated event will be invoked.
        /// </remarks>
        public void CreateBond()
        {
            if (BluetoothAdapter.IsBluetoothEnabled)
            {
                int ret = Interop.Bluetooth.CreateBond(RemoteDeviceAddress);
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to create bond, Error - " + (BluetoothError)ret);
                    BluetoothErrorFactory.ThrowBluetoothException(ret);
                }
            }
        }

        /// <summary>
        /// Cancels the bonding process.
        /// </summary>
        /// <remarks>
        /// Bonding must be in progress by CreateBond().
        /// </remarks>
        public void CancelBonding()
        {
            int ret = Interop.Bluetooth.CancelBonding();
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to cancel bonding process, Error - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
        }

        /// <summary>
        /// Destroys the bond.
        /// </summary>
        /// <remarks>
        /// The Bluetooth must be enabled and the bond must be created by CreateBond().
        /// If this succeeds, BondDestroyed event will be invoked.
        /// </remarks>
        public void DestroyBond()
        {
            if (BluetoothAdapter.IsBluetoothEnabled)
            {
                int ret = Interop.Bluetooth.DestroyBond(RemoteDeviceAddress);
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to destroy bond, Error - " + (BluetoothError)ret);
                    BluetoothErrorFactory.ThrowBluetoothException(ret);
                }
            }
        }

        /// <summary>
        /// Sets an alias for the bonded device.
        /// </summary>
        /// <remarks>
        /// The Bluetooth must be enabled and the bond must be created by CreateBond().
        /// </remarks>
        /// <param name="aliasName">Alias name of remote device.</param>
        public void SetAlias(string aliasName)
        {
            if (BluetoothAdapter.IsBluetoothEnabled)
            {
                int ret = Interop.Bluetooth.SetAlias(RemoteDeviceAddress, aliasName);
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set alias name, Error - " + (BluetoothError)ret);
                    BluetoothErrorFactory.ThrowBluetoothException(ret);
                }
            }
        }

        /// <summary>
        /// Sets the authorization of a bonded device.
        /// </summary>
        /// <remarks>
        /// The Bluetooth must be enabled and the bond must be created by CreateBond().
        /// If this succeeds, AuthorizationChanged event will be invoked.
        /// </remarks>
        /// <param name="authorizationState">Authorization state.</param>
        public void SetAuthorization(BluetoothAuthorizationType authorizationState)
        {
            if (BluetoothAdapter.IsBluetoothEnabled)
            {
                int ret = Interop.Bluetooth.SetAuthorization(RemoteDeviceAddress, (int)authorizationState);
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set authroization state, Error - " + (BluetoothError)ret);
                    BluetoothErrorFactory.ThrowBluetoothException(ret);
                }
            }
        }

        /// <summary>
        /// Gets the mask from UUID.
        /// </summary>
        /// <returns>The service mask list converted from the given UUID list.</returns>
        /// <param name="uuids">Uuid list of the device.</param>
        public BluetoothServiceClassType GetMaskFromUuid(string[] uuids)
        {
            BluetoothServiceClassType serviceMask;

            int ret = Interop.Bluetooth.GetMaskFromUuid(uuids, uuids.Length, out serviceMask);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get service mask, Error - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
            return serviceMask;
        }

        /// <summary>
        /// Starts the search for services supported by the specified device.
        /// </summary>
        /// <remarks>
        /// The Bluetooth must be enabled and remote device must be discoverable by StartDiscovery().The bond must be created by CreateBond().
        /// If this succeeds, ServiceSearched will be invoked.
        /// </remarks>
        public void StartServiceSearch()
        {
            Log.Info(Globals.LogTag, "startservicesearch entry");
            if (BluetoothAdapter.IsBluetoothEnabled)
            {
                int ret = Interop.Bluetooth.StartServiceSearch(RemoteDeviceAddress);
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to start service search, Error - " + (BluetoothError)ret);
                    BluetoothErrorFactory.ThrowBluetoothException(ret);
                }
            }
        }

        /// <summary>
        /// Gets the connected profiles.
        /// </summary>
        /// <remarks>
        /// The Bluetooth must be enabled.
        /// </remarks>
        /// <returns>The connected Bluetooth profiles.</returns>
        public IEnumerable<BluetoothProfileType> GetConnectedProfiles()
        {
            if (BluetoothAdapter.IsBluetoothEnabled)
            {
                List<BluetoothProfileType> profileList = new List<BluetoothProfileType>();
                Interop.Bluetooth.ConnectedProfileCallback callback = (int profile, IntPtr userData) =>
                {
                    if (!profile.Equals(null))
                    {
                        profileList.Add((BluetoothProfileType)profile);
                    }
                    return true;
                };
                int ret = Interop.Bluetooth.GetConnectedProfiles(RemoteDeviceAddress, callback, IntPtr.Zero);
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get connected profiles, Error - " + (BluetoothError)ret);
                    BluetoothErrorFactory.ThrowBluetoothException(ret);
                }
                return profileList;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Determines if profile is connected to the specified remote device.
        /// </summary>
        /// <remarks>
        /// The Bluetooth must be enabled.
        /// </remarks>
        /// <returns><c>true</c> if profile is connected; otherwise, <c>false</c>.</returns>
        /// <param name="profileType">Bluetooth Profile type.</param>
        public bool IsProfileConnected(BluetoothProfileType profileType)
        {
            if (BluetoothAdapter.IsBluetoothEnabled)
            {
                bool isConnected;
                int ret = Interop.Bluetooth.IsProfileConnected(RemoteDeviceAddress, (int)profileType, out isConnected);
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get profile connected state, Error - " + (BluetoothError)ret);
                }
                return isConnected;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Returns the instance of Bluetooth profile type.
        /// </summary>
        /// <remarks>
        /// The Bluetooth must be enabled.
        /// </remarks>
        public T GetProfile<T>() where T : BluetoothProfile
        {
            /*
             * FIXME: Find a proper way for dynamic allocation.
             */
            T profile = null;
            String type = typeof(T).ToString();
            if (type.Equals("Tizen.Network.Bluetooth.BluetoothAudio"))
            {
                BluetoothAudio audio = new BluetoothAudio();
                profile = (audio as T);
            }
            else if (type.Equals("Tizen.Network.Bluetooth.BluetoothAvrcp"))
            {
                BluetoothAvrcp avrcp = new BluetoothAvrcp();
                profile = (avrcp as T);
            }
            else if (type.Equals("Tizen.Network.Bluetooth.BluetoothHid"))
            {
                BluetoothHid hid = new BluetoothHid();
                profile = (hid as T);
            }
            profile.RemoteAddress = RemoteDeviceAddress;
            return profile;
        }

        /// <summary>
        /// Creates the client socket.
        /// </summary>
        /// <returns>The IBluetoothClientSocket instance.</returns>
        /// <param name="serviceUuid">The UUID of service.</param>
        public IBluetoothClientSocket CreateSocket(string serviceUuid)
        {
            BluetoothSocket clientSocket = new BluetoothSocket();
            clientSocket.remoteAddress = this.Address;
            clientSocket.serviceUuid = serviceUuid;
            return (IBluetoothClientSocket)clientSocket;
        }
    }
}
