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
using System.Text;
using System.Threading.Tasks;

namespace Tizen.Network.Bluetooth
{
    /// <summary>
    /// The Bluetooth GATT server.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class BluetoothGattServer : IDisposable
    {
        private static BluetoothGattServer _instance;
        private BluetoothGattServerImpl _impl;

        private BluetoothGattServer()
        {
            _impl = new BluetoothGattServerImpl();
            _impl._notificationSent += (s, e) =>
            {
                e.Server = this;
                NotificationSent?.Invoke(this, e);
            };
        }

        /// <summary>
        /// (event) This event is called when the indication acknowledgement is received for each notified client.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<NotificationSentEventArg> NotificationSent;

        /// <summary>
        /// Creates the Bluetooth GATT server.
        /// </summary>
        /// <returns>The BluetoothGattServer instance.</returns>
        /// <feature>http://tizen.org/feature/network.bluetooth.le.gatt.server</feature>
        /// <exception cref="NotSupportedException">Thrown when the BT/BTLE is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the create GATT server fails.</exception>
        /// <since_tizen> 3 </since_tizen>
        public static BluetoothGattServer CreateServer()
        {
            if (_instance == null)
            {
                BluetoothGattServer server = new BluetoothGattServer();
                if (server.IsValid())
                {
                    _instance = server;
                }
            }
            return _instance;
        }

        /// <summary>
        /// Registers the server along with the GATT services of the application it is hosting.
        /// </summary>
        /// <feature>http://tizen.org/feature/network.bluetooth.le.gatt.server</feature>
        /// <exception cref="NotSupportedException">Thrown when the BT/BTLE is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the register server application fails.</exception>
        /// <since_tizen> 3 </since_tizen>
        public void Start()
        {
            _impl.Start();
        }

        /// <summary>
        /// Registers a specified service to this server.
        /// </summary>
        /// <param name="service">The service, which needs to be registered with this server.</param>
        /// <feature>http://tizen.org/feature/network.bluetooth.le.gatt.server</feature>
        /// <exception cref="NotSupportedException">Thrown when the BT/BTLE is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the register service fails.</exception>
        /// <since_tizen> 3 </since_tizen>
        public void RegisterGattService(BluetoothGattService service)
        {
            if (service.IsRegistered())
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.InvalidParameter);
            }
            _impl.RegisterGattService(this, service);
        }

        /// <summary>
        /// Unregisters a specified service from this server.
        /// </summary>
        /// <param name="service">The service, which needs to be unregistered from this server.</param>
        /// <remarks>
        /// Once unregistered, the service object will become invalid and should not be used to access sevices or any children attribute's methods/members.
        /// </remarks>
        /// <feature>http://tizen.org/feature/network.bluetooth.le.gatt.server</feature>
        /// <exception cref="NotSupportedException">Thrown when the BT/BTLE is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the unregister service fails.</exception>
        /// <since_tizen> 3 </since_tizen>
        public void UnregisterGattService(BluetoothGattService service)
        {
            if (service.GetGattServer() != this)
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.InvalidParameter);
            }

            _impl.UnregisterGattService(service);
        }

        /// <summary>
        /// Unregisters all services from this server.
        /// </summary>
        /// <remarks>
        /// Once unregistered, servicees will become invalid and should not be used to access sevices or any children attribute's methods/members.
        /// </remarks>
        /// <feature>http://tizen.org/feature/network.bluetooth.le.gatt.server</feature>
        /// <exception cref="NotSupportedException">Thrown when the BT/BTLE is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the unregister all services fail.</exception>
        /// <since_tizen> 3 </since_tizen>
        public void UnregisterGattServices()
        {
            _impl.UnregisterAllGattServices(this);
        }

        /// <summary>
        /// Gets service with given UUID that belongs to this server.
        /// </summary>
        /// <param name="uuid">The UUID for the service to get.</param>
        /// <returns>The Service with the given UUID if it exists, null otherwise.</returns>
        /// <feature>http://tizen.org/feature/network.bluetooth.le.gatt.server</feature>
        /// <exception cref="NotSupportedException">Thrown when the BT/BTLE is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the service is not registered.</exception>
        /// <since_tizen> 3 </since_tizen>
        public BluetoothGattService GetService(string uuid)
        {
            return _impl.GetService(this, uuid);
        }

        /// <summary>
        /// Gets the list of services that belongs to this server.
        /// </summary>
        /// <returns>The list of services that belongs to this server.</returns>
        /// <feature>http://tizen.org/feature/network.bluetooth.le.gatt.server</feature>
        /// <exception cref="NotSupportedException">Thrown when the BT/BTLE is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the service is not registered.</exception>
        /// <since_tizen> 3 </since_tizen>
        public IEnumerable<BluetoothGattService> GetServices()
        {
            return _impl.GetServices(this);
        }

        /// <summary>
        /// Sends indication for the value change of the characteristic to the remote devices.
        /// </summary>
        /// <param name="characteristic">The characteristic whose the value is changed.</param>
        /// <param name="clientAddress">The remote device address to send, notify, or indicate and if set to NULL, then notify/indicate all is enabled.</param>
        /// <returns>true on success, false otherwise.</returns>
        /// <feature>http://tizen.org/feature/network.bluetooth.le.gatt.server</feature>
        /// <exception cref="NotSupportedException">Thrown when the BT/BTLE is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the BT/BTLE is not enabled
        /// or when the remote device is disconnected, or when service is not registered, or when the CCCD is not enabled.</exception>
        /// <since_tizen> 3 </since_tizen>
        public async Task<bool> SendIndicationAsync(BluetoothGattCharacteristic characteristic, string clientAddress)
        {
            return await _impl.SendIndicationAsync(this, characteristic, clientAddress);
        }

        /// <summary>
        /// Sends the notification for the value change of the characteristic to the remote devices.
        /// </summary>
        /// <param name="characteristic">The characteristic, which has a changed value.</param>
        /// <param name="clientAddress">The remote device address to send, notify, or indicate and if set to NULL, then notify/indicate all is enabled.</param>
        /// <feature>http://tizen.org/feature/network.bluetooth.le.gatt.server</feature>
        /// <exception cref="NotSupportedException">Thrown when the BT/BTLE is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the BT/BTLE is not enabled
        /// or when the remote device is disconnected, or when service is not registered, or when the CCCD is not enabled.</exception>
        /// <since_tizen> 3 </since_tizen>
        public void SendNotification(BluetoothGattCharacteristic characteristic, string clientAddress)
        {
            _ = _impl.SendIndicationAsync(this, characteristic, clientAddress);
        }

        /// <summary>
        /// Sends a response to the remote device as a result of a read/write request.
        /// </summary>
        /// <param name="requestId">The identification of a read/write request.</param>
        /// <param name="type">The request type for read/write.</param>
        /// <param name="status">The error value in case of failure, 0 for success.</param>
        /// <param name="value">The value to be sent.</param>
        /// <param name="offset">The offset from where the value is read.</param>
        /// <feature>http://tizen.org/feature/network.bluetooth.le.gatt.server</feature>
        /// <exception cref="NotSupportedException">Thrown when the BT/BTLE is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the BT/BTLE is not enabled
        /// or when the remote device is disconnected, or the send response procedure fails.</exception>
        /// <since_tizen> 3 </since_tizen>
        public void SendResponse(int requestId, BluetoothGattRequestType type, int status, byte[] value, int offset)
        {
            _impl.SendResponse(requestId, (int)type, status, value, offset);
        }

        internal bool IsValid()
        {
            return _impl.GetHandle().IsInvalid == false;
        }

        /// <summary>
        /// Destroys the current object.
        /// </summary>
        ~BluetoothGattServer()
        {
            Dispose(false);
        }

        /// <summary>
        /// Destroys the current object.
        /// </summary>
        /// <feature>http://tizen.org/feature/network.bluetooth.le.gatt.server</feature>
        /// <since_tizen> 6 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases all the resources currently used by this instance.
        /// </summary>
        /// <param name="disposing">true if the managed resources should be disposed, otherwise false.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _impl?.GetHandle()?.Dispose();
                _instance = null;
            }
        }
    }

    /// <summary>
    /// The Bluetooth GATT client.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class BluetoothGattClient : IDisposable
    {
        private BluetoothGattClientImpl _impl;
        private string _remoteAddress = string.Empty;
        private TaskCompletionSource<bool> _taskForConnection;
        private TaskCompletionSource<bool> _taskForDisconnection;
        private static event EventHandler<GattConnectionStateChangedEventArgs> s_connectionStateChanged;
        private static Interop.Bluetooth.GattConnectionStateChangedCallBack s_connectionStateChangeCallback;

        internal BluetoothGattClient(string remoteAddress)
        {
            _impl = new BluetoothGattClientImpl(remoteAddress);
            _remoteAddress = remoteAddress;
            StaticConnectionStateChanged += OnConnectionStateChanged;
        }

        /// <summary>
        /// Creates the Bluetooth GATT client.
        /// </summary>
        /// <param name="remoteAddress">The remote device address.</param>
        /// <returns>The BluetoothGattClient instance.</returns>
        /// <feature>http://tizen.org/feature/network.bluetooth.le.gatt.client</feature>
        /// <exception cref="NotSupportedException">Thrown when the BT/BTLE is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the create GATT client fails.</exception>
        /// <since_tizen> 6 </since_tizen>
        public static BluetoothGattClient CreateClient(string remoteAddress)
        {
            BluetoothGattClient client = new BluetoothGattClient(remoteAddress);
            return client.Isvalid() ? client : null;
        }

        /// <summary>
        /// The ConnectionStateChanged event is raised when the gatt connection state is changed.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler<GattConnectionStateChangedEventArgs> ConnectionStateChanged;

        private void OnConnectionStateChanged(Object s, GattConnectionStateChangedEventArgs e)
        {
            if (e.RemoteAddress == _remoteAddress)
            {
                if (_taskForConnection != null && !_taskForConnection.Task.IsCompleted)
                {
                    if (e.Result == (int)BluetoothError.None)
                    {
                        _taskForConnection.SetResult(true);
                    }
                    else
                    {
                        _taskForConnection.SetException(BluetoothErrorFactory.CreateBluetoothException((int)e.Result));
                    }
                    _taskForConnection = null;
                }

                if (_taskForDisconnection != null && !_taskForDisconnection.Task.IsCompleted)
                {
                    if (e.Result == (int)BluetoothError.None)
                    {
                        _taskForDisconnection.SetResult(true);
                    }
                    else
                    {
                        _taskForDisconnection.SetException(BluetoothErrorFactory.CreateBluetoothException(e.Result));
                    }
                    _taskForDisconnection = null;
                }

                if (e.Result == (int)BluetoothError.None)
                {
                    ConnectionStateChanged?.Invoke(this, e);
                }
            }
        }

        internal static event EventHandler<GattConnectionStateChangedEventArgs> StaticConnectionStateChanged
        {
            add
            {
                if (s_connectionStateChanged == null)
                {
                    RegisterConnectionStateChangedEvent();
                }
                s_connectionStateChanged += value;
            }
            remove
            {
                s_connectionStateChanged -= value;
                if (s_connectionStateChanged == null)
                {
                    UnregisterConnectionStateChangedEvent();
                }
            }
        }

        private static void RegisterConnectionStateChangedEvent()
        {
            s_connectionStateChangeCallback = (int result, bool connected, string remoteDeviceAddress, IntPtr userData) =>
            {
                Log.Info(Globals.LogTag, "Setting gatt connection state changed callback");
                GattConnectionStateChangedEventArgs e = new GattConnectionStateChangedEventArgs(result, connected, remoteDeviceAddress);
                s_connectionStateChanged?.Invoke(null, e);
            };

            int ret = Interop.Bluetooth.SetGattConnectionStateChangedCallback(s_connectionStateChangeCallback, IntPtr.Zero);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set gatt connection state changed callback, Error - " + (BluetoothError)ret);
            }
        }

        private static void UnregisterConnectionStateChangedEvent()
        {
            int ret = Interop.Bluetooth.UnsetGattConnectionStateChangedCallback();
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to unset gatt connection state changed callback, Error - " + (BluetoothError)ret);
            }
        }

        /// <summary>
        /// Connects to the remote GATT server asynchronously.
        /// </summary>
        /// <param name="autoConnect">The flag for reconnecting when the connection is disconnceted.</param>
        /// <returns> A task indicating whether the method is done or not.</returns>
        /// <feature>http://tizen.org/feature/network.bluetooth.le.gatt.client</feature>
        /// <privilege>http://tizen.org/privilege/bluetooth</privilege>
        /// <exception cref="NotSupportedException">Thrown when the BT/BTLE is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the create GATT client fails.</exception>
        /// <since_tizen> 6 </since_tizen>
        public Task ConnectAsync(bool autoConnect)
        {
            if (_taskForConnection != null && !_taskForConnection.Task.IsCompleted)
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NowInProgress);
            }
            _taskForConnection = new TaskCompletionSource<bool>();
            _impl.Connect(_remoteAddress, autoConnect);
            return _taskForConnection.Task;
        }

        /// <summary>
        /// Disconnects to the remote GATT server asynchronously.
        /// </summary>
        /// <returns> A task indicating whether the method is done or not.</returns>
        /// <feature>http://tizen.org/feature/network.bluetooth.le.gatt.client</feature>
        /// <privilege>http://tizen.org/privilege/bluetooth</privilege>
        /// <exception cref="NotSupportedException">Thrown when the BT/BTLE is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the create GATT client fails.</exception>
        /// <since_tizen> 6 </since_tizen>
        public Task DisconnectAsync()
        {
            if (_taskForDisconnection != null && !_taskForDisconnection.Task.IsCompleted)
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NowInProgress);
            }
            _taskForDisconnection = new TaskCompletionSource<bool>();
            _impl.Disconnect(_remoteAddress);
            return _taskForDisconnection.Task;
        }

        /// <summary>
        /// Destroy Bluetooth GATT client
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated since API level 6. Please use Dispose() method on BluetoothGattClient.")]
        public void DestroyClient()
        {
            _impl.GetHandle().Dispose();
        }

        /// <summary>
        /// The address of the remote device.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when the BT/BTLE is not enabled
        /// or when the remote device is disconnected.</exception>
        /// <since_tizen> 3 </since_tizen>
        public string RemoteAddress
        {
            get
            {
                if (string.IsNullOrEmpty(_remoteAddress))
                {
                    _remoteAddress = _impl.GetRemoteAddress();
                }
                return _remoteAddress;
            }
        }

        /// <summary>
        /// Gets the service with the given UUID that belongs to the remote device.
        /// </summary>
        /// <param name="uuid">The UUID for the service to get.</param>
        /// <returns>The service with the given UUID if it exists, null otherwise.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the BT/BTLE is not enabled
        /// or when the remote device is disconnected, or when the get service fails.</exception>
        /// <since_tizen> 3 </since_tizen>
        public BluetoothGattService GetService(string uuid)
        {
            return _impl.GetService(this, uuid);
        }

        /// <summary>
        /// Gets list of services that belongs to the remote device.
        /// </summary>
        /// <returns>The list of services that belongs to the remote device.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the BT/BTLE is not enabled
        /// or when the remote device is disconnected, or when the get service fails.</exception>
        /// <since_tizen> 3 </since_tizen>
        public IEnumerable<BluetoothGattService> GetServices()
        {
            return _impl.GetServices(this);
        }

        /// <summary>
        /// Reads the value of a given characteristic from the remote device asynchronously.
        /// </summary>
        /// <param name="characteristic">The characteristic to be read.</param>
        /// <returns>true on success, false otherwise.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the BT/BTLE is not enabled
        /// or when the remote device is disconnected, or when the read attribute value fails.</exception>
        /// <since_tizen> 3 </since_tizen>
        public async Task<bool> ReadValueAsync(BluetoothGattCharacteristic characteristic)
        {
            return await _impl.ReadValueAsyncTask(characteristic.GetHandle());
        }

        /// <summary>
        /// Reads the value of the given descriptor from the remote device asynchronously.
        /// </summary>
        /// <param name="descriptor">The descriptor to be read.</param>
        /// <returns>true on success, false otherwise.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the BT/BTLE is not enabled
        /// or when the remote device is disconnected, or when the read attribute value fails.</exception>
        /// <since_tizen> 3 </since_tizen>
        public async Task<bool> ReadValueAsync(BluetoothGattDescriptor descriptor)
        {
            return await _impl.ReadValueAsyncTask(descriptor.GetHandle());
        }

        /// <summary>
        /// Writes the value of a given characteristic to the remote device asynchronously.
        /// </summary>
        /// <param name="characteristic">The characteristic to be written.</param>
        /// <returns>true on success, false otherwise.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the BT/BTLE is not enabled
        /// or when the remote device is disconnected or when the write attribute value fails.</exception>
        /// <since_tizen> 3 </since_tizen>
        public async Task<bool> WriteValueAsync(BluetoothGattCharacteristic characteristic)
        {
            return await _impl.WriteValueAsyncTask(characteristic.GetHandle());
        }

        /// <summary>
        /// Writes the value of the given descriptor to the remote device asynchronously.
        /// </summary>
        /// <param name="descriptor">The descriptor to be written.</param>
        /// <returns>true on success, false otherwise.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the BT/BTLE is not enabled
        /// or when the remote device is disconnected, or when the write attribute value fails.</exception>
        /// <since_tizen> 3 </since_tizen>
        public async Task<bool> WriteValueAsync(BluetoothGattDescriptor descriptor)
        {
            return await _impl.WriteValueAsyncTask(descriptor.GetHandle());
        }

        internal bool Isvalid()
        {
            return _impl.GetHandle().IsInvalid == false;
        }

        /// <summary>
        /// Destroys the current object.
        /// </summary>
        ~BluetoothGattClient()
        {
            Dispose(false);
        }

        /// <summary>
        /// Destroys the current object.
        /// </summary>
        /// <feature>http://tizen.org/feature/network.bluetooth.le.gatt.client</feature>
        /// <since_tizen> 6 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases all the resources currently used by this instance.
        /// </summary>
        /// <param name="disposing">true if the managed resources should be disposed, otherwise false.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _impl?.GetHandle()?.Dispose();
                _impl = null;
                StaticConnectionStateChanged -= OnConnectionStateChanged;
            }
        }
    }

    /// <summary>
    /// The Bluetooth GATT service.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class BluetoothGattService
    {
        private BluetoothGattServiceImpl _impl;
        private BluetoothGattClient _parentClient = null;
        private BluetoothGattServer _parentServer = null;
        private BluetoothGattService _parentService = null;

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="uuid">The UUID of the service.</param>
        /// <param name="type">The type of service.</param>
        /// <exception cref="InvalidOperationException">Thrown when the create GATT service procedure fails.</exception>
        /// <since_tizen> 3 </since_tizen>
        public BluetoothGattService(string uuid, BluetoothGattServiceType type)
        {
            Uuid = uuid;
            _impl = new BluetoothGattServiceImpl(uuid, type);
        }

        internal BluetoothGattService(BluetoothGattServiceImpl impl, string uuid)
        {
            Uuid = uuid;
            _impl = impl;
        }

        /// <summary>
        /// Specification name from the UUID.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Uuid { get; }

        /// <summary>
        /// Adds a characteristic to this service.
        /// </summary>
        /// <param name="characteristic">The characteristic to be added.</param>
        /// <returns>true on success, false otherwise.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the add GATT characteristic procedure fails.</exception>
        /// <since_tizen> 3 </since_tizen>
        public void AddCharacteristic(BluetoothGattCharacteristic characteristic)
        {
            if (GetGattClient() != null)
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotSupported);
            }

            if (characteristic.GetService() != null)
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.InvalidParameter);
            }

            _impl.AddCharacteristic(characteristic);
            characteristic.SetParent(this);
        }

        /// <summary>
        /// Gets the characteristic with the given UUID that belongs to this service.
        /// </summary>
        /// <param name="uuid">The UUID for the characteristic to get.</param>
        /// <returns>The characteristic with a given UUID if it exists, null otherwise.</returns>
        /// <since_tizen> 3 </since_tizen>
        public BluetoothGattCharacteristic GetCharacteristic(string uuid)
        {
            return _impl.GetCharacteristic(this, uuid);
        }

        /// <summary>
        /// Gets list of the characteristic that belongs to this service.
        /// </summary>
        /// <returns>The list of the characteristic that belongs to this service.</returns>
        /// <since_tizen> 3 </since_tizen>
        public IEnumerable<BluetoothGattCharacteristic> GetCharacteristics()
        {
            return _impl.GetCharacteristics(this);
        }

        /// <summary>
        /// Includes a service to this service.
        /// </summary>
        /// <param name="service">The service to be included.</param>
        /// <returns>true on success, false otherwise</returns>
        /// <exception cref="InvalidOperationException">Thrown when the add GATT service procedure fails.</exception>///
        /// <since_tizen> 3 </since_tizen>
        public void AddService(BluetoothGattService service)
        {
            if (GetGattClient() != null)
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotSupported);
            }

            if (service.IsRegistered())
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.InvalidParameter);
            }

            _impl.AddIncludeService(service);
            service.SetParent(this);
        }

        /// <summary>
        /// Gets the included service.
        /// </summary>
        /// <param name="uuid">The UUID for the service to get.</param>
        /// <returns>The service with a given UUID if it exists, null otherwise.</returns>
        /// <since_tizen> 3 </since_tizen>
        public BluetoothGattService GetIncludeService(string uuid)
        {
            return _impl.GetIncludeService(this, uuid);
        }

        /// <summary>
        /// Gets the included service list of this service.
        /// </summary>
        /// <returns>The included service list of this service.</returns>
        /// <since_tizen> 3 </since_tizen>
        public IEnumerable<BluetoothGattService> GetIncludeServices()
        {
            return _impl.GetIncludeServices(this);
        }

        /// <summary>
        /// Gets the server instance which the specified service belongs to.
        /// </summary>
        /// <returns>The server instance which the specified service belongs to.</returns>
        /// <since_tizen> 3 </since_tizen>
        public BluetoothGattServer GetGattServer()
        {
            return _parentServer;
        }

        /// <summary>
        /// Gets the client instance which the specified service belongs to.
        /// </summary>
        /// <returns>The client instance which the specified service belongs to.</returns>
        /// <since_tizen> 3 </since_tizen>
        public BluetoothGattClient GetGattClient()
        {
            return _parentClient;
        }

        internal BluetoothGattAttributeHandle GetHandle()
        {
            return _impl.GetHandle();
        }

        internal void SetParent(BluetoothGattService parent)
        {
            if (!IsRegistered())
            {
                _parentService = parent;
                _impl.ReleaseHandleOwnership();
            }
        }

        internal void SetParent(BluetoothGattClient parent)
        {
            if (!IsRegistered())
            {
                _parentClient = parent;
                _impl.ReleaseHandleOwnership();
            }
        }

        internal void SetParent(BluetoothGattServer parent)
        {
            if (!IsRegistered())
            {
                _parentServer = parent;
                _impl.ReleaseHandleOwnership();
            }
        }

        internal void UnregisterService()
        {
            _parentServer = null;
            _parentClient = null;
            _parentService = null;
        }

        internal bool IsRegistered()
        {
            return _parentClient != null || _parentServer != null || _parentService != null;
        }
    }

    /// <summary>
    /// The Bluetooth GATT characteristic.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class BluetoothGattCharacteristic : BluetoothGattAttribute
    {
        private BluetoothGattCharacteristicImpl _impl;
        private BluetoothGattService _parent = null;

        private Interop.Bluetooth.BtClientCharacteristicValueChangedCallback _characteristicValueChangedCallback;
        private Interop.Bluetooth.BtGattServerNotificationStateChangeCallback _notificationStateChangedCallback;

        private EventHandler<ValueChangedEventArgs> _characteristicValueChanged;
        internal EventHandler<NotificationStateChangedEventArg> _notificationStateChanged;

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="uuid">The UUID of the characterstic.</param>
        /// <param name="permissions">Permissions for the characterstic.</param>
        /// <param name="properties">Properties set for the characterstic.</param>
        /// <param name="value">The value associated with the characterstic.</param>
        /// <remarks>throws in case of internal error.</remarks>
        /// <exception cref="InvalidOperationException">Thrown when the create GATT characteristics procedure fails.</exception>
        /// <since_tizen> 3 </since_tizen>
        public BluetoothGattCharacteristic(string uuid, BluetoothGattPermission permissions, BluetoothGattProperty properties, byte[] value) : base(uuid, permissions)
        {
            _impl = new BluetoothGattCharacteristicImpl(uuid, permissions, properties, value);
        }

        internal BluetoothGattCharacteristic(BluetoothGattCharacteristicImpl impl, string uuid, BluetoothGattPermission permission) : base(uuid, permission)
        {
            _impl = impl;
        }

        /// <summary>
        /// The CharacteristicValueChanged event is raised when the server notifies for change in this characteristic value.
        /// </summary>
        /// <remarks>
        /// Adding the event handle on characteristic on the server side will not have any effect.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<ValueChangedEventArgs> ValueChanged
        {
            add
            {
                if (Client != null)
                {
                    if (_characteristicValueChanged == null)
                    {
                        _characteristicValueChangedCallback = (gattHandle, characteristicValue, len, userData) =>
                        {
                            _characteristicValueChanged?.Invoke(this, new ValueChangedEventArgs(characteristicValue, len));
                        };

                        _impl.SetCharacteristicValueChangedEvent(_characteristicValueChangedCallback);
                    }
                    _characteristicValueChanged = value;
                }
            }
            remove
            {
                if (Client != null)
                {
                    _characteristicValueChanged = null;
                    if (_characteristicValueChanged == null)
                    {
                        _impl.UnsetCharacteristicValueChangedEvent();
                    }

                }
            }
        }

        /// <summary>
        /// The NotificationStateChanged event is called when the client enables or disables the Notification/Indication for particular characteristics.
        /// </summary>
        /// <remarks>
        /// BluetoothGattServer.RegisterGattService() should be called before adding/removing this EventHandler.
        /// Adding event handle on the characteristic on the client side will not have any effect.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<NotificationStateChangedEventArg> NotificationStateChanged
        {
            add
            {
                if (Server != null)
                {
                    if (_notificationStateChangedCallback == null)
                    {
                        _notificationStateChangedCallback = (notify, serverHandle, characteristicHandle, userData) =>
                        {
                            _notificationStateChanged?.Invoke(this, new NotificationStateChangedEventArg(Server, notify));
                        };

                        _impl.SetNotificationStateChangedEvent(_notificationStateChangedCallback);
                    }

                    _notificationStateChanged = value;
                }
            }
            remove
            {
                if (Server != null)
                {
                    _notificationStateChanged = null;
                    // CAPI does not allow unsetting ReadValueRequestedEventCallback.
                }
            }
        }

        /// <summary>
        /// The property for this characteristic.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public BluetoothGattProperty Properties
        {
            get
            {
                return _impl.GetProperties();
            }
            set
            {
                if (Server != null)
                {
                    _impl.SetProperties(value);
                }
            }
        }

        /// <summary>
        /// The write type to be used for write operations.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public BluetoothGattWriteType WriteType
        {
            get
            {
                return _impl.GetWriteType();
            }
            set
            {
                _impl.SetWriteType(value);
            }
        }

        internal override BluetoothGattClient Client
        {
            get
            {
                return _parent?.GetGattClient();
            }
        }

        internal override BluetoothGattServer Server
        {
            get
            {
                return _parent?.GetGattServer();
            }
        }

        internal override BluetoothGattAttributeImpl Impl
        {
            get
            {
                return _impl;
            }
        }

        /// <summary>
        /// Adds a descriptor to this characteristic.
        /// </summary>
        /// <param name="descriptor">The descriptor to be added.</param>
        /// <returns>true on success, false otherwise.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the add GATT descriptor procedure fails.</exception>
        /// <since_tizen> 3 </since_tizen>
        public void AddDescriptor(BluetoothGattDescriptor descriptor)
        {
            if (Client != null)
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotSupported);
            }

            if (descriptor.GetCharacteristic() != null)
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.InvalidParameter);
            }

            _impl.AddDescriptor(descriptor);
            descriptor.SetParent(this);
        }

        /// <summary>
        /// Gets the descriptor with the given UUID that belongs to this characteristic.
        /// </summary>
        /// <param name="uuid">The UUID for the descriptor to get.</param>
        /// <returns>The descriptor with a given UUID if it exists, null otherwise.</returns>
        /// <since_tizen> 3 </since_tizen>
        public BluetoothGattDescriptor GetDescriptor(string uuid)
        {
            return _impl.GetDescriptor(this, uuid);
        }

        /// <summary>
        /// Gets the list of descriptors that belongs to this characteristic.
        /// </summary>
        /// <returns>The list of descriptors that belongs to this characteristic.</returns>
        /// <since_tizen> 3 </since_tizen>
        public IEnumerable<BluetoothGattDescriptor> GetDescriptors()
        {
            return _impl.GetDescriptors(this);
        }

        /// <summary>
        /// Gets the service instance, which the specified characterstic belongs to.
        /// </summary>
        /// <returns>The characteristic instance, the specified characterstic belongs to.</returns>
        /// <since_tizen> 3 </since_tizen>
        public BluetoothGattService GetService()
        {
            return _parent;
        }

        internal void SetParent(BluetoothGattService parent)
        {
            if (_parent == null)
            {
                _parent = parent;
                ReleaseHandleOwnership();
            }
         }
    }

    /// <summary>
    /// The Bluetooth GATT descriptor.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class BluetoothGattDescriptor : BluetoothGattAttribute
    {
        private BluetoothGattCharacteristic _parent = null;
        private BluetoothGattDescriptorImpl _impl;

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="uuid">The UUID of the descriptor.</param>
        /// <param name="permisions">Permissions for the descriptor.</param>
        /// <param name="value">The value associated with the descriptor.</param>
        /// <remarks>throws in case of internal error.</remarks>
        /// <exception cref="InvalidOperationException">Thrown when the create GATT descriptor procedure fails.</exception>
        /// <since_tizen> 3 </since_tizen>
        public BluetoothGattDescriptor(string uuid, BluetoothGattPermission permisions, byte[] value) : base (uuid, permisions)
        {
            _impl = new BluetoothGattDescriptorImpl(uuid, permisions, value);
        }

        internal BluetoothGattDescriptor(BluetoothGattDescriptorImpl impl, string uuid, BluetoothGattPermission permission) : base(uuid, permission)
        {
            _impl = impl;
        }

        internal override BluetoothGattClient Client
        {
            get
            {
                return _parent?.Client;
            }
        }

        internal override BluetoothGattServer Server
        {
            get
            {
                return _parent?.Server;
            }
        }

        internal override BluetoothGattAttributeImpl Impl
        {
            get
            {
                return _impl;
            }
        }

        /// <summary>
        /// Gets the characteristic instance, which the specified descriptor belongs to.
        /// </summary>
        /// <returns>The characteristic instance, the specified descriptor belongs to.</returns>
        /// <since_tizen> 3 </since_tizen>
        public BluetoothGattCharacteristic GetCharacteristic()
        {
            return _parent;
        }

        internal void SetParent(BluetoothGattCharacteristic parent)
        {
            if (_parent == null)
            {
                _parent = parent;
                ReleaseHandleOwnership();
            }
        }
    }

    /// <summary>
    /// The Bluetooth GATT attribute.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public abstract class BluetoothGattAttribute
    {
        private Interop.Bluetooth.BtGattServerReadValueRequestedCallback _readValueRequestedCallback;
        private Interop.Bluetooth.BtGattServerWriteValueRequestedCallback _writeValueRequestedCallback;

        private EventHandler<ReadRequestedEventArgs> _readValueRequested;
        private EventHandler<WriteRequestedEventArgs> _writeValueRequested;

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="uuid">The UUID of the GATT attribute.</param>
        /// <param name="permission">Permission for the GATT attribute.</param>
        /// <since_tizen> 3 </since_tizen>
        public BluetoothGattAttribute(string uuid, BluetoothGattPermission permission)
        {
            Uuid = uuid;
            Permissions = permission;
        }

        // Events

        /// <summary>
        /// This event is called when the client request to read the value of a characteristic or a descriptor.
        /// </summary>
        /// <remarks>
        /// BluetoothGattServer.RegisterGattService() should be called before adding/removing this EventHandler.
        /// </remarks>
        /// <exception cref="InvalidOperationException">Thrown when the set read value requested callback procedure fails.</exception>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<ReadRequestedEventArgs> ReadRequested
        {
            add
            {
                if (Server == null) return;
                if (_readValueRequestedCallback == null)
                {
                    _readValueRequestedCallback = (clientAddress, requestId, serverHandle, gattHandle, offset, userData) =>
                    {
                        _readValueRequested?.Invoke(this, new ReadRequestedEventArgs(Server, clientAddress, requestId, offset));
                    };
                    Impl.SetReadValueRequestedEventCallback(_readValueRequestedCallback);
                }
                _readValueRequested = value;
            }
            remove
            {
                if (Server == null) return;
                _readValueRequested = null;
                // CAPI does not allow unsetting ReadValueRequestedEventCallback.
            }
        }

        /// <summary>
        /// This event is called when a value of a characteristic or a descriptor has been changed by a client.
        /// </summary>
        /// <remarks>
        /// BluetoothGattServer.RegisterGattService() should be called before adding/removing this EventHandler.
        /// </remarks>
        /// <exception cref="InvalidOperationException">Thrown when the set write value requested callback procedure fails.</exception>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<WriteRequestedEventArgs> WriteRequested
        {
            add
            {
                if (Server == null) return;
                if (_writeValueRequested == null)
                {
                    _writeValueRequestedCallback = (clientAddress, requestId, serverHandle, gattHandle, response_needed, offset, valueToWrite, len, userData) =>
                    {
                        byte[] writeValue = new byte[len];
                        Marshal.Copy(valueToWrite, writeValue, 0, len);
                        _writeValueRequested?.Invoke(this, new WriteRequestedEventArgs(Server, clientAddress, requestId, writeValue, offset, response_needed));
                    };
                    Impl.SetWriteValueRequestedEventCallback(_writeValueRequestedCallback);
                }
                _writeValueRequested = value;
            }
            remove
            {
                if (Server == null) return;
                _writeValueRequested = null;
                // CAPI does not allow unsetting ReadValueRequestedEventCallback.
            }
        }

        /// <summary>
        /// The attribute's UUID.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Uuid { get; }

        /// <summary>
        /// Permissions for this attribute.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public BluetoothGattPermission Permissions { get; }

        /// <summary>
        /// The value of this descriptor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public byte[] Value
        {
            get
            {
                return Impl.GetValue();
            }
            set
            {
                Impl.SetValue(value);
            }
        }

        internal abstract BluetoothGattClient Client { get; }
        internal abstract BluetoothGattServer Server { get; }
        internal abstract BluetoothGattAttributeImpl Impl { get; }

        /// <summary>
        /// Returns a string value at the specified offset.
        /// </summary>
        /// <param name="offset">An offset in the attribute value buffer.</param>
        /// <returns>The string value at specified offset.</returns>
        /// <since_tizen> 3 </since_tizen>
        public string GetValue(int offset)
        {
            return Impl.GetValue(offset);
        }

        /// <summary>
        /// Sets the string value as a specified offset.
        /// </summary>
        /// <param name="value">value to set</param>
        /// <exception cref="InvalidOperationException">Throws exception if the value is null.</exception>
        /// <since_tizen> 3 </since_tizen>
        public void SetValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                GattUtil.ThrowForError((int)BluetoothError.InvalidParameter, "value should not be null");

            byte[] val = Encoding.UTF8.GetBytes(value);
            Impl.SetValue(val);
        }

        /// <summary>
        /// Returns a value at specified offset as the int value of the specified type.
        /// </summary>
        /// <param name="type">The type of the int value.</param>
        /// <param name="offset">An offset in the attribute value buffer.</param>
        /// <returns>The int value at given offset.</returns>
        /// <exception cref="InvalidOperationException">Throws exception if (offset + size of int value) is greater than the length of the value buffer.</exception>
        /// <since_tizen> 3 </since_tizen>
        public int GetValue(IntDataType type, int offset)
        {
            return Impl.GetValue(type, offset);
        }

        /// <summary>
        /// Updates a value at the specified offset by the int value of the specified type.
        /// </summary>
        /// <param name="type">The type of the int value.</param>
        /// <param name="value">The value to set.</param>
        /// <param name="offset">An offset in the attribute value buffer.</param>
        /// <exception cref="InvalidOperationException">Throws exception if (offset + size of int value) is greater than the length of the value buffer.</exception>
        /// <since_tizen> 3 </since_tizen>
        public void SetValue(IntDataType type, int value, int offset)
        {
            Impl.SetValue(type, value, offset);
        }

        /// <summary>
        /// Returns a value at the specified offset as the float value of the specified type.
        /// </summary>
        /// <param name="type">The type of the float value.</param>
        /// <param name="offset">An offset in the attribute value buffer.</param>
        /// <returns>The float value at given offset.</returns>
        /// <exception cref="InvalidOperationException">Throws exception if (offset + size of float value) is greater than the length of the value buffer.</exception>
        /// <since_tizen> 3 </since_tizen>
        public float GetValue(FloatDataType type, int offset)
        {
            return Impl.GetValue(type, offset);
        }

        /// <summary>
        /// Updates the value at the specified offset by the float value of the specified type.
        /// </summary>
        /// <param name="type">The type of the float value.</param>
        /// <param name="mantissa">The mantissa of the float value.</param>
        /// <param name="exponent">An exponent of the float value.</param>
        /// <param name="offset">An offset in the attribute value buffer.</param>
        /// <exception cref="InvalidOperationException">Throws exception if (offset + size of float value) is greater than the length of the value buffer.</exception>
        /// <since_tizen> 3 </since_tizen>
        public void SetValue(FloatDataType type, int mantissa, int exponent, int offset)
        {
            Impl.SetValue(type, mantissa, exponent, offset);
        }

        internal void ReleaseHandleOwnership()
        {
            Impl.ReleaseHandleOwnership();
        }

        internal BluetoothGattAttributeHandle GetHandle()
        {
            return Impl.GetHandle();
        }
    }
}
