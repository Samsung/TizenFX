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
    /// Bluetooth GATT server
    /// </summary>
    public class BluetoothGattServer
    {
        private static BluetoothGattServer _instance;
        private BluetoothGattServerImpl _impl;
        private BluetoothGattServer()
        {
            _impl = new BluetoothGattServerImpl();
        }

        /// <summary>
        /// (event) called when indication acknowledgement received, once for each notified client
        /// </summary>
        public event EventHandler<NotificationSentEventArg> NotificationSent
        {
            add
            {
                _impl._notificationSent += value;
            }
            remove
            {
                _impl._notificationSent -= value;
            }
        }

        /// <summary>
        /// Creates bluetooth gatt server
        /// </summary>
        /// <returns></returns>
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
        /// Registers the server along with the GATT services of the application it is hosting
        /// </summary>
        public void Start()
        {
            _impl.Start();
        }

        /// <summary>
        /// Registers a specified service to this server
        /// </summary>
        /// <param name="service">service, which needs to be registered with this server</param>
        public void RegisterGattService(BluetoothGattService service)
        {
            if (service.IsRegistered())
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.InvalidParameter);
            }
            _impl.RegisterGattService(this, service);
        }

        /// <summary>
        /// Unregisters a specified service from this server
        /// </summary>
        /// <param name="service">service, which needs to be unregistered from this server</param>
        /// <remarks>
        /// Once unregistered, service object will become invalid and should not be used to access sevices's or any children attribute's methods/ members.
        /// </remarks>
        public void UnregisterGattService(BluetoothGattService service)
        {
            if (service.GetGattServer() != this)
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.InvalidParameter);
            }

            _impl.UnregisterGattService(service);
        }

        /// <summary>
        /// Unregisters all services from this server
        /// </summary>
        /// <remarks>
        /// Once unregistered, servicees will become invalid and should not be used to access sevices's or any children attribute's methods/ members.
        /// </remarks>
        public void UnregisterGattServices()
        {
            _impl.UnregisterAllGattServices(this);
        }

        /// <summary>
        /// Gets service with given UUID that belongs to this server.
        /// </summary>
        /// <param name="uuid">UUID for the service to get</param>
        /// <returns>service with given uuid if it exists, null otherwise</returns>
        public BluetoothGattService GetService(string uuid)
        {
            return _impl.GetService(this, uuid);
        }

        /// <summary>
        /// Gets list of services that belongs to this server.
        /// </summary>
        /// <returns>list of services that belongs to this server</returns>
        public IEnumerable<BluetoothGattService> GetServices()
        {
            return _impl.GetServices(this);
        }

        /// <summary>
        /// Send indication for value change of the characteristic to the remote devices
        /// </summary>
        /// <param name="characteristic">characteristic whose value is changes</param>
        /// <param name="clientAddress">Remote device address to send notify or indicate and if set to NULL then notify/indicate all is enabled.</param>
        public async Task<bool> SendIndicationAsync(BluetoothGattCharacteristic characteristic, string clientAddress)
        {
            return await _impl.SendIndicationAsync(this, characteristic, clientAddress);
        }

        /// <summary>
        /// Send notification for value change of the characteristic to the remote devices
        /// </summary>
        /// <param name="characteristic">characteristic The characteristic which has a changed value</param>
        /// <param name="clientAddress">Remote device address to send notify or indicate and if set to NULL then notify/indicate all is enabled.</param>
        public void SendNotification(BluetoothGattCharacteristic characteristic, string clientAddress)
        {
            _impl.SendNotification(characteristic, clientAddress);
        }

        /// <summary>
        /// Sends a response to the remote device as a result of a read/ write request
        /// </summary>
        /// <param name="requestId">The identification of a read/ write request</param>
        /// <param name="type">The request type for read/write</param>
        /// <param name="status">error value in case of failure, 0 for success</param>
        /// <param name="value">Value to be sent</param>
        /// <param name="offset">Fffset from where the value is read</param>
        public void SendResponse(int requestId, BluetoothGattRequestType type, int status, byte[] value, int offset)
        {
            _impl.SendResponse(requestId, (int)type, status, value, offset);
        }

        internal bool IsValid()
        {
            return _impl.GetHandle().IsInvalid == false;
        }
    }

    /// <summary>
    /// Bluetooth GATT client
    /// </summary>
    public class BluetoothGattClient
    {
        private BluetoothGattClientImpl _impl;
        private string _remoteAddress = string.Empty;

        internal BluetoothGattClient(string remoteAddress)
        {
            _impl = new BluetoothGattClientImpl(remoteAddress);
            _remoteAddress = remoteAddress;
        }

        internal static BluetoothGattClient CreateClient(string remoteAddress)
        {
            BluetoothGattClient client = new BluetoothGattClient(remoteAddress);
            return client.Isvalid() ? client : null;
        }

        public void DestroyClient()
        {
            _impl.GetHandle().Dispose();
        }

        /// <summary>
        /// Address of remote device.
        /// </summary>
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
        /// Gets service with given UUID that belongs to the remote device.
        /// </summary>
        /// <param name="uuid">UUID for the service to get</param>
        /// <returns>service with given uuid if it exists, null otherwise</returns>
        public BluetoothGattService GetService(string uuid)
        {
            return _impl.GetService(this, uuid);
        }

        /// <summary>
        /// Gets list of services that belongs to the remote device.
        /// </summary>
        /// <returns>list of services that belongs to the remote device</returns>
        public IEnumerable<BluetoothGattService> GetServices()
        {
            return _impl.GetServices(this);
        }

        /// <summary>
        /// Reads the value of given characteristic from the remote device asynchronously.
        /// </summary>
        /// <param name="characteristic">characteristic to be read</param>
        /// <returns>true on success, false otherwise</returns>
        public async Task<bool> ReadValueAsync(BluetoothGattCharacteristic characteristic)
        {
            return await _impl.ReadValueAsyncTask(characteristic.GetHandle());
        }

        /// <summary>
        /// Reads the value of given descriptor from the remote device asynchronously.
        /// </summary>
        /// <param name="descriptor">descriptor to be read</param>
        /// <returns>true on success, false otherwise</returns>
        public async Task<bool> ReadValueAsync(BluetoothGattDescriptor descriptor)
        {
            return await _impl.ReadValueAsyncTask(descriptor.GetHandle());
        }

        /// <summary>
        /// Write value of given characteristic to remote device asynchronously.
        /// </summary>
        /// <param name="characteristic">characteristic to be written</param>
        /// <returns>true on success, false otherwise</returns>
        public async Task<bool> WriteValueAsync(BluetoothGattCharacteristic characteristic)
        {
            return await _impl.WriteValueAsyncTask(characteristic.GetHandle());
        }

        /// <summary>
        /// Write value of given descriptor to remote device asynchronously.
        /// </summary>
        /// <param name="descriptor">descriptor to be written</param>
        /// <returns>true on success, false otherwise</returns>
        public async Task<bool> WriteValueAsync(BluetoothGattDescriptor descriptor)
        {
            return await _impl.WriteValueAsyncTask(descriptor.GetHandle());
        }

        internal bool Isvalid()
        {
            return _impl.GetHandle().IsInvalid == false;
        }
    }

    /// <summary>
    /// Bluetooth GATT service
    /// </summary>
    public class BluetoothGattService
    {
        private BluetoothGattServiceImpl _impl;
        private BluetoothGattClient _parentClient = null;
        private BluetoothGattServer _parentServer = null;
        private BluetoothGattService _parentService = null;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="uuid">UUID of the service</param>
        /// <param name="type">type of service</param>
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
        /// Specification name from the UUID
        /// </summary>
        public string Uuid { get; }

        /// <summary>
        /// Adds a characteristic to this service
        /// </summary>
        /// <param name="characteristic">characteristic to be added</param>
        /// <returns>true on success, false otherwise</returns>
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
        /// Gets characteristic with given UUID that belongs to this service.
        /// </summary>
        /// <param name="uuid">UUID for the characteristic to get</param>
        /// <returns>characteristic with given uuid if it exists, null otherwise</returns>
        public BluetoothGattCharacteristic GetCharacteristic(string uuid)
        {
            return _impl.GetCharacteristic(this, uuid);
        }

        /// <summary>
        /// Gets list of characteristic that belongs to this service.
        /// </summary>
        /// <returns>list of characteristic that belongs to this service</returns>
        public IEnumerable<BluetoothGattCharacteristic> GetCharacteristics()
        {
            return _impl.GetCharacteristics(this);
        }

        /// <summary>
        /// Includes a service to this service
        /// </summary>
        /// <param name="service">service to be included</param>
        /// <returns>true on success, false otherwise</returns>
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
        /// Gets included service
        /// </summary>
        /// <param name="uuid">UUID for the service to get</param>
        /// <returns>service with given uuid if it exists, null otherwise</returns>
        public BluetoothGattService GetIncludeService(string uuid)
        {
            return _impl.GetIncludeService(this, uuid);
        }

        /// <summary>
        /// Gets included service list of this service.
        /// </summary>
        /// <returns>included service list of this service</returns>
        public IEnumerable<BluetoothGattService> GetIncludeServices()
        {
            return _impl.GetIncludeServices(this);
        }

        /// <summary>
        /// Gets the server instance which the specified service belongs to.
        /// </summary>
        /// <returns>server instance which the specified service belongs to</returns>
        public BluetoothGattServer GetGattServer()
        {
            return _parentServer;
        }

        /// <summary>
        /// Gets the client instance which the specified service belongs to.
        /// </summary>
        /// <returns>client instance which the specified service belongs to</returns>
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
    /// Bluetooth GATT characteristic
    /// </summary>
    public class BluetoothGattCharacteristic : BluetoothGattAttribute
    {
        private BluetoothGattCharacteristicImpl _impl;
        private BluetoothGattService _parent = null;

        private Interop.Bluetooth.BtClientCharacteristicValueChangedCallback _characteristicValueChangedCallback;
        private Interop.Bluetooth.BtGattServerNotificationStateChangeCallback _notificationStateChangedCallback;

        private EventHandler<ValueChangedEventArgs> _characteristicValueChanged;
        internal EventHandler<NotificationStateChangedEventArg> _notificationStateChanged;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="uuid">UUID of the characterstic</param>
        /// <param name="permissions">Permissions for the characterstic</param>
        /// <param name="properties">Properties set for the characterstic</param>
        /// <param name="value">Value associated with the characterstic</param>
        /// <remarks>throws in case of internal error</remarks>
        public BluetoothGattCharacteristic(string uuid, BluetoothGattPermission permissions, BluetoothGattProperty properties, byte[] value) : base(uuid, permissions)
        {
            _impl = new BluetoothGattCharacteristicImpl(uuid, permissions, properties, value);
        }

        internal BluetoothGattCharacteristic(BluetoothGattCharacteristicImpl impl, string uuid, BluetoothGattPermission permission) : base(uuid, permission)
        {
            _impl = impl;
        }

        /// <summary>
        /// (event) CharacteristicValueChanged is raised when server notifies for change in this characteristic value
        /// </summary>
        /// <remarks>
        /// Adding event handle on charateristic on server side will not have any effect
        /// </remarks>
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
                            _characteristicValueChanged?.Invoke(this, new ValueChangedEventArgs(characteristicValue));
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
        /// (event) NotificationStateChanged is called when client enables or disables the Notification/Indication for particular characteristics.
        /// </summary>
        /// <remarks>
        /// Adding event handle on charateristic on client side will not have any effect
        /// </remarks>
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
        /// Property for this characteristic
        /// </summary>
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
        /// Write type to be used for write operations
        /// </summary>
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
        /// Adds a descriptor to this characteristic
        /// </summary>
        /// <param name="descriptor">descriptor to be added</param>
        /// <returns>true on success, false otherwise</returns>
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
        /// Gets descriptor with given UUID that belongs to this characteristic.
        /// </summary>
        /// <param name="uuid">UUID for the descriptor to get</param>
        /// <returns>descriptor with given uuid if it exists, null otherwise</returns>
        public BluetoothGattDescriptor GetDescriptor(string uuid)
        {
            return _impl.GetDescriptor(this, uuid);
        }

        /// <summary>
        /// Gets list of descriptors that belongs to this characteristic.
        /// </summary>
        /// <returns>list of descriptors that belongs to this characteristic</returns>
        public IEnumerable<BluetoothGattDescriptor> GetDescriptors()
        {
            return _impl.GetDescriptors(this);
        }

        /// <summary>
        /// Gets the service instance which the specified characterstic belongs to.
        /// </summary>
        /// <returns>characteristic instance, the specified characterstic belongs to.</returns>
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
    /// Bluetooth GATT descriptor
    /// </summary>
    public class BluetoothGattDescriptor : BluetoothGattAttribute
    {
        private BluetoothGattCharacteristic _parent = null;
        private BluetoothGattDescriptorImpl _impl;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="uuid">UUID of the descriptor</param>
        /// <param name="permisions">Permissions for the descriptor</param>
        /// <param name="value">Value associated with the descriptor</param>
        /// <remarks>throws in case of internal error</remarks>
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
        /// Gets the characteristic instance which the specified descriptor belongs to.
        /// </summary>
        /// <returns>characteristic instance, the specified descriptor belongs to.</returns>
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
    /// Bluetooth GATT attribute
    /// </summary>
    public abstract class BluetoothGattAttribute
    {
        private Interop.Bluetooth.BtGattServerReadValueRequestedCallback _readValueRequestedCallback;
        private Interop.Bluetooth.BtGattServerWriteValueRequestedCallback _writeValueRequestedCallback;

        private EventHandler<ReadRequestedEventArgs> _readValueRequested;
        private EventHandler<WriteRequestedEventArgs> _writeValueRequested;

        public BluetoothGattAttribute(string uuid, BluetoothGattPermission permission)
        {
            Uuid = uuid;
            Permissions = permission;
        }

        // Events

        /// <summary>
        /// Event called when client request to read value of a characteristic or descriptor
        /// </summary>
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
        /// Event called when a value of a characteristic or descriptor has been changed by a client
        /// </summary>
        public event EventHandler<WriteRequestedEventArgs> WriteRequested
        {
            add
            {
                if (Server == null) return;
                if (_writeValueRequested == null)
                {
                    _writeValueRequestedCallback = (clientAddress, requestId, serverHandle, gattHandle, offset, response_needed, valueToWrite, len, userData) =>
                    {
                        _writeValueRequested?.Invoke(this, new WriteRequestedEventArgs(Server, clientAddress, requestId, valueToWrite, offset, response_needed));
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
        /// Attribute's UUID
        /// </summary>
        public string Uuid { get; }

        /// <summary>
        /// Permissions for this attribute
        /// </summary>
        public BluetoothGattPermission Permissions { get; }

        /// <summary>
        /// Value of this descriptor
        /// </summary>
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
        /// Returns string value at specified offset
        /// </summary>
        /// <param name="offset"></param>
        /// <returns>string value at specified offset</returns>
        public string GetValue(int offset)
        {
            return Impl.GetValue(offset);
        }

        /// <summary>
        /// Sets string value as specified offset
        /// </summary>
        /// <param name="value">value to set</param>
        /// <exception cref="InvalidOperationException">Throws excetion if value is null</exception>
        public void SetValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                GattUtil.ThrowForError((int)BluetoothError.InvalidParameter, "value should not be null");

            byte[] val = Encoding.UTF8.GetBytes(value);
            Impl.SetValue(val);
        }

        /// <summary>
        /// Returns value at specified offset as int value of specified type
        /// </summary>
        /// <param name="type">type of int value</param>
        /// <param name="offset">offset in the attribute value buffer</param>
        /// <returns>int value at given offset</returns>
        /// <exception cref="InvalidOperationException">Throws excetion if (offset + size of int value) is greater then length of value buffer</exception>
        public int GetValue(IntDataType type, int offset)
        {
            return Impl.GetValue(type, offset);
        }

        /// <summary>
        /// Update Value at specified offset by int value of specified type
        /// </summary>
        /// <param name="type">type of int value</param>
        /// <param name="value">value to set</param>
        /// <param name="offset">offset in the attribute value buffer</param>
        /// <exception cref="InvalidOperationException">Throws excetion if (offset + size of int value) is greater then length of value buffer</exception>
        public void SetValue(IntDataType type, int value, int offset)
        {
            Impl.SetValue(type, value, offset);
        }

        /// <summary>
        /// Returns value at specified offset as float value of specified type
        /// </summary>
        /// <param name="type">type of float value</param>
        /// <param name="offset">offset in the attribute value buffer</param>
        /// <returns>float value at given offset</returns>
        /// <exception cref="InvalidOperationException">Throws excetion if (offset + size of float value) is greater then length of value buffer</exception>
        public float GetValue(FloatDataType type, int offset)
        {
            return Impl.GetValue(type, offset);
        }

        /// <summary>
        /// Update Value at specified offset by float value of specified type
        /// </summary>
        /// <param name="type">type of float value</param>
        /// <param name="mantissa">mantissa of float value</param>
        /// <param name="exponent">exponent of float value</param>
        /// <param name="offset">offset in the attribute value buffer</param>
        /// <exception cref="InvalidOperationException">Throws excetion if (offset + size of float value) is greater then length of value buffer</exception>
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
