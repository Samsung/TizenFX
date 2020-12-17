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
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Tizen.Network.Bluetooth
{
    internal class BluetoothGattServerImpl
    {
        private BluetoothGattServerHandle _handle;
        internal event EventHandler<NotificationSentEventArg> _notificationSent;
        int _requestId = 0;
        Dictionary<int, TaskCompletionSource<bool>> _sendIndicationTaskSource = new Dictionary<int, TaskCompletionSource<bool>>();
        private Interop.Bluetooth.BtGattServerNotificationSentCallback _sendIndicationCallback;
        private Interop.Bluetooth.BtGattForeachCallback _serviceForeachCallback;

        internal BluetoothGattServerImpl()
        {
            _sendIndicationCallback = SendIndicationCallback;

            int err = Interop.Bluetooth.BtGattServerInitialize();
            GattUtil.ThrowForError(err, "Failed to initialize server");

            err = Interop.Bluetooth.BtGattServerCreate(out _handle);
            GattUtil.ThrowForError(err, "Failed to create server");
        }

        internal void Start()
        {
            int err = Interop.Bluetooth.BtGattServerStart();
            GattUtil.ThrowForError(err, "Failed to start server");
        }

        internal void RegisterGattService(BluetoothGattServer server, BluetoothGattService service)
        {
            int err = Interop.Bluetooth.BtGattServerRegisterService(_handle, service.GetHandle());
            GattUtil.ThrowForError(err, "Failed to Register service");

            service.SetParent(server);
        }

        internal void UnregisterGattService(BluetoothGattService service)
        {
            int err = Interop.Bluetooth.BtGattServerUnregisterService(_handle, service.GetHandle());
            GattUtil.ThrowForError(err, "Failed to Unregister service");

            service.UnregisterService();
        }

        internal void UnregisterAllGattServices(BluetoothGattServer server)
        {
            int err = Interop.Bluetooth.BtGattServerUnregisterAllServices(_handle);
            GattUtil.ThrowForError(err, "Failed to Unregister all services");
        }

        internal BluetoothGattService GetService(BluetoothGattServer server, string uuid)
        {
            BluetoothGattAttributeHandle serviceHandle;
            int err = Interop.Bluetooth.BtGattServerGetService(_handle, uuid, out serviceHandle);
            if (err.IsFailed())
            {
                GattUtil.Error(err, string.Format("Failed to get service with UUID ({0})", uuid));
                return null;
            }

            BluetoothGattService service = new BluetoothGattService(new BluetoothGattServiceImpl(serviceHandle), uuid); ;
            service.SetParent(server);
            return service;
        }

        internal IEnumerable<BluetoothGattService> GetServices(BluetoothGattServer server)
        {
            List<BluetoothGattService> attribututeList = new List<BluetoothGattService>();
            _serviceForeachCallback = (total, index, attributeHandle, userData) =>
            {
                BluetoothGattAttributeHandle handle = new BluetoothGattAttributeHandle(attributeHandle, false);
                BluetoothGattService service = BluetoothGattServiceImpl.CreateBluetoothGattService(handle, ""); ;
                if (service != null)
                {
                    service.SetParent(server);
                    attribututeList.Add(service);
                }
                return true;
            };

            int err = Interop.Bluetooth.BtGattServerForeachServices(_handle, _serviceForeachCallback, IntPtr.Zero);
            GattUtil.Error(err, "Failed to get all services");

            return attribututeList;
        }

        internal void SendResponse(int requestId, int request_type, int status, byte[] value, int offset)
        {
            int err = Interop.Bluetooth.BtGattServerSendResponse(requestId, request_type, offset, status, value, value.Length);
            GattUtil.ThrowForError(err, string.Format("Failed to send response for request Id {0}", requestId));
        }

        void SendIndicationCallback(int result, string clientAddress, IntPtr serverHandle, IntPtr characteristicHandle, bool completed, IntPtr userData)
        {
            int requestId = (int)userData;
            if (_sendIndicationTaskSource.ContainsKey(requestId))
            {
                _notificationSent?.Invoke(this, new NotificationSentEventArg(null, clientAddress, result, completed));
                if (completed)
                {
                    _sendIndicationTaskSource[requestId].SetResult(true);
                }
                else
                {
                    _sendIndicationTaskSource[requestId].SetResult(false);
                }
                _sendIndicationTaskSource.Remove(requestId);
            }
        }

        internal Task<bool> SendIndicationAsync(BluetoothGattServer server, BluetoothGattCharacteristic characteristic, string clientAddress)
        {
            TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
            int requestId = 0;

            lock (this)
            {
                requestId = _requestId++;
                _sendIndicationTaskSource[requestId] = task;
            }

            int err = Interop.Bluetooth.BtGattServerNotify(characteristic.GetHandle(), _sendIndicationCallback, clientAddress, (IntPtr)requestId);
            if (err.IsFailed())
            {
                GattUtil.Error(err, string.Format("Failed to send value changed indication for characteristic uuid {0}", characteristic.Uuid));
                task.SetResult(false);
                _sendIndicationTaskSource.Remove(requestId);
                BluetoothErrorFactory.ThrowBluetoothException(err);
            }
            return task.Task;
        }

        internal BluetoothGattServerHandle GetHandle()
        {
            return _handle;
        }
    }

    internal class BluetoothGattClientImpl
    {
        private BluetoothGattClientHandle _handle;
        int _requestId = 0;
        Dictionary<int, TaskCompletionSource<bool>> _readValueTaskSource = new Dictionary<int, TaskCompletionSource<bool>>();
        private Interop.Bluetooth.BtGattClientRequestCompletedCallback _readValueCallback;
        Dictionary<int, TaskCompletionSource<bool>> _writeValueTaskSource = new Dictionary<int, TaskCompletionSource<bool>>();
        private Interop.Bluetooth.BtGattClientRequestCompletedCallback _writeValueCallback;
        private Interop.Bluetooth.BtGattForeachCallback _serviceForeachCallback;

        internal BluetoothGattClientImpl(string remoteAddress)
        {
            _readValueCallback = ReadValueCallback;
            _writeValueCallback = WriteValueCallback;

            if (BluetoothAdapter.IsBluetoothEnabled)
            {
                int err = Interop.Bluetooth.BtGattClientCreate(remoteAddress, out _handle);
                GattUtil.ThrowForError(err, "Failed to get native client handle");
            }
            else
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
        }

        internal void Connect(string remoteAddress, bool autoConnect)
        {
            int err = Interop.Bluetooth.GattConnect(remoteAddress, autoConnect);
            GattUtil.ThrowForError(err, "Failed to connect to remote address");
        }

        internal void Disconnect(string remoteAddress)
        {
            int err = Interop.Bluetooth.GattDisconnect(remoteAddress);
            GattUtil.ThrowForError(err, "Failed to disconnect to remote address");
        }

        internal string GetRemoteAddress()
        {
            string remoteAddress;
            int err = Interop.Bluetooth.BtGattClientGetRemoteAddress(_handle, out remoteAddress);
            GattUtil.ThrowForError(err, "Failed to get remote address for this client");

            return remoteAddress;
        }

        internal BluetoothGattService GetService(BluetoothGattClient client, string uuid)
        {
            BluetoothGattAttributeHandle serviceHandle;
            int err = Interop.Bluetooth.BtGattClientGetService(_handle, uuid, out serviceHandle);
            if (err.IsFailed())
            {
                GattUtil.Error(err, string.Format("Failed to get service with UUID ({0})", uuid));
                return null;
            }

            BluetoothGattService service = new BluetoothGattService(new BluetoothGattServiceImpl(serviceHandle), uuid); ;
            service.SetParent(client);
            return service;
        }

        internal IEnumerable<BluetoothGattService> GetServices(BluetoothGattClient client)
        {
            List<BluetoothGattService> attribututeList = new List<BluetoothGattService>();
            _serviceForeachCallback = (total, index, attributeHandle, userData) =>
            {
                BluetoothGattAttributeHandle handle = new BluetoothGattAttributeHandle(attributeHandle, false);
                BluetoothGattService service = BluetoothGattServiceImpl.CreateBluetoothGattService(handle, "");
                if (service != null)
                {
                    service.SetParent(client);
                    attribututeList.Add(service);
                }
                return true;
            };

            int err = Interop.Bluetooth.BtGattClientForeachServices(_handle, _serviceForeachCallback, IntPtr.Zero);
            GattUtil.Error(err, "Failed to get all services");

            return attribututeList;
        }

        void ReadValueCallback(int result, IntPtr requestHandle, IntPtr userData)
        {
            int requestId = (int)userData;
            if (_readValueTaskSource.ContainsKey(requestId))
            {
                if (result == (int)BluetoothError.None)
                {
                    _readValueTaskSource[requestId].SetResult(true);
                }
                else
                {
                    _readValueTaskSource[requestId].SetResult(false);
                }
            }
            _readValueTaskSource.Remove(requestId);
        }

        internal Task<bool> ReadValueAsyncTask(BluetoothGattAttributeHandle handle)
        {
            TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
            int requestId = 0;

            lock (this)
            {
                requestId = _requestId++;
                _readValueTaskSource[requestId] = task;
            }

            int err = Interop.Bluetooth.BtGattClientReadValue(handle, _readValueCallback, (IntPtr)requestId);
            if (err.IsFailed())
            {
                GattUtil.Error(err, "Failed to read value from remote device");
                task.SetResult(false);
                _readValueTaskSource.Remove(requestId);
                BluetoothErrorFactory.ThrowBluetoothException(err);
            }
            return task.Task;
        }

        void WriteValueCallback(int result, IntPtr requestHandle, IntPtr userData)
        {
            int requestId = (int)userData;
            if (_writeValueTaskSource.ContainsKey(requestId))
            {
                if (result == (int)BluetoothError.None)
                {
                    _writeValueTaskSource[requestId].SetResult(true);
                }
                else
                {
                    _writeValueTaskSource[requestId].SetResult(false);
                }
            }
            _writeValueTaskSource.Remove(requestId);
        }

        internal Task<bool> WriteValueAsyncTask(BluetoothGattAttributeHandle handle)
        {
            TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
            int requestId = 0;

            lock (this)
            {
                requestId = _requestId++;
                _writeValueTaskSource[requestId] = task;
            }

            int err = Interop.Bluetooth.BtGattClientWriteValue(handle, _writeValueCallback, (IntPtr)requestId);
            if (err.IsFailed())
            {
                GattUtil.Error(err, "Failed to write value to remote device");
                task.SetResult(false);
                _writeValueTaskSource.Remove(requestId);
                BluetoothErrorFactory.ThrowBluetoothException(err);
            }
            return task.Task;
        }

        internal BluetoothGattClientHandle GetHandle()
        {
            return _handle;
        }
    }

    internal class BluetoothGattServiceImpl : BluetoothGattAttributeImpl
    {
        private Interop.Bluetooth.BtGattForeachCallback _characteristicForeachCallback;
        private Interop.Bluetooth.BtGattForeachCallback _includedServiceForeachCallback;

        internal BluetoothGattServiceImpl(string uuid, BluetoothGattServiceType type)
        {
            int err = Interop.Bluetooth.BtGattServiceCreate(uuid, (int)type, out _handle);
            GattUtil.ThrowForError(err, "Failed to get native service handle");
        }

        internal BluetoothGattServiceImpl(BluetoothGattAttributeHandle handle)
        {
            _handle = handle;
        }

        internal static BluetoothGattService CreateBluetoothGattService(BluetoothGattAttributeHandle handle, string uuid)
        {
            if (uuid == "")
            {
                int err = Interop.Bluetooth.BtGattGetUuid(handle, out uuid);
                GattUtil.ThrowForError(err, "Failed to get UUID");
            }

            BluetoothGattServiceImpl impl = new BluetoothGattServiceImpl(handle);
            return new BluetoothGattService(impl, uuid);
        }

        internal void AddCharacteristic(BluetoothGattCharacteristic characteristic)
        {
            int err = Interop.Bluetooth.BtGattServiceAddCharacteristic(_handle, characteristic.GetHandle());
            GattUtil.ThrowForError(err, string.Format("Failed to add characteristic with UUID ({0})", characteristic.Uuid));
        }

        internal BluetoothGattCharacteristic GetCharacteristic(BluetoothGattService service, string uuid)
        {
            BluetoothGattAttributeHandle attributeHandle;
            int err = Interop.Bluetooth.BtGattServiceGetCharacteristic(_handle, uuid, out attributeHandle);
            if (err.IsFailed())
            {
                GattUtil.Error(err, string.Format("Failed to get Characteristic with UUID ({0})", uuid));
                return null;
            }

            BluetoothGattCharacteristic Characteristic = BluetoothGattCharacteristicImpl.CreateBluetoothGattGattCharacteristic(attributeHandle, uuid);
            if (Characteristic != null)
            {
                Characteristic.SetParent(service);
            }
            return Characteristic;
        }

        internal IEnumerable<BluetoothGattCharacteristic> GetCharacteristics(BluetoothGattService service)
        {
            List<BluetoothGattCharacteristic> attribututeList = new List<BluetoothGattCharacteristic>();
            _characteristicForeachCallback = (total, index, attributeHandle, userData) =>
            {
                BluetoothGattAttributeHandle handle = new BluetoothGattAttributeHandle(attributeHandle, false);
                BluetoothGattCharacteristic Characteristic = BluetoothGattCharacteristicImpl.CreateBluetoothGattGattCharacteristic(handle, "");
                if (Characteristic != null)
                {
                    Characteristic.SetParent(service);
                    attribututeList.Add(Characteristic);
                }
                return true;
            };

            int err = Interop.Bluetooth.BtGattServiceForeachCharacteristics(service.GetHandle(), _characteristicForeachCallback, IntPtr.Zero);
            GattUtil.Error(err, "Failed to get all Characteristic");

            return attribututeList;
        }

        internal void AddIncludeService(BluetoothGattService includedService)
        {
            int err = Interop.Bluetooth.BtGattServiceAddIncludedService(_handle, includedService.GetHandle());
            GattUtil.ThrowForError(err, string.Format("Failed to add service with UUID ({0})", includedService.Uuid));
        }

        internal BluetoothGattService GetIncludeService(BluetoothGattService parentService, string uuid)
        {
            BluetoothGattAttributeHandle attributeHandle;
            int err = Interop.Bluetooth.BtGattServiceGetIncludedService(_handle, uuid, out attributeHandle);
            if (err.IsFailed())
            {
                GattUtil.Error(err, string.Format("Failed to get included service with UUID ({0})", uuid));
                return null;
            }

            BluetoothGattService service = new BluetoothGattService(new BluetoothGattServiceImpl(attributeHandle), uuid);
            service.SetParent(parentService);
            return service;
        }

        internal IEnumerable<BluetoothGattService> GetIncludeServices(BluetoothGattService parentService)
        {
            List<BluetoothGattService> attribututeList = new List<BluetoothGattService>();
            _includedServiceForeachCallback = (total, index, attributeHandle, userData) =>
            {
                BluetoothGattAttributeHandle handle = new BluetoothGattAttributeHandle(attributeHandle, false);
                BluetoothGattService service = BluetoothGattServiceImpl.CreateBluetoothGattService(handle, "");
                if (service != null)
                {
                    service.SetParent(parentService);
                    attribututeList.Add(service);
                }
                return true;
            };

            int err = Interop.Bluetooth.BtGattServiceForeachIncludedServices(parentService.GetHandle(), _includedServiceForeachCallback, IntPtr.Zero);
            GattUtil.Error(err, "Failed to get all services");

            return attribututeList;
        }
    }

    internal class BluetoothGattCharacteristicImpl : BluetoothGattAttributeImpl
    {
        private Interop.Bluetooth.BtGattForeachCallback _descriptorForeachCallback;

        internal BluetoothGattCharacteristicImpl(string uuid, BluetoothGattPermission permission, BluetoothGattProperty property, byte[] value)
        {
            int err = Interop.Bluetooth.BtGattCharacteristicCreate(uuid, (int)permission, (int)property, value, value.Length, out _handle);
            GattUtil.ThrowForError(err, "Failed to get native characteristic handle");
        }

        internal BluetoothGattCharacteristicImpl(BluetoothGattAttributeHandle handle)
        {
            _handle = handle;
        }

        internal static BluetoothGattCharacteristic CreateBluetoothGattGattCharacteristic(BluetoothGattAttributeHandle handle, string uuid)
        {
            int permission;
            int err = Interop.Bluetooth.BtGattCharacteristicGetPermissions(handle, out permission);
            GattUtil.ThrowForError(err, "Failed to get permissions");

            if (uuid == "")
            {
                err = Interop.Bluetooth.BtGattGetUuid(handle, out uuid);
                GattUtil.ThrowForError(err, "Failed to get UUID");
            }

            BluetoothGattCharacteristicImpl impl = new BluetoothGattCharacteristicImpl(handle);
            return new BluetoothGattCharacteristic(impl, uuid, (BluetoothGattPermission)permission);
        }

        internal void SetCharacteristicValueChangedEvent(Interop.Bluetooth.BtClientCharacteristicValueChangedCallback callback)
        {
            int err = Interop.Bluetooth.BtGattClientSetCharacteristicValueChangedCallback(_handle, callback, IntPtr.Zero);
            GattUtil.Error(err, "Failed to set client characteristic value changed callback");
        }

        internal void UnsetCharacteristicValueChangedEvent()
        {
            int err = Interop.Bluetooth.BtGattClientUnsetCharacteristicValueChangedCallback(_handle);
            GattUtil.Error(err, "Failed to unset client characteristic value changed callback");
        }

        internal void SetNotificationStateChangedEvent(Interop.Bluetooth.BtGattServerNotificationStateChangeCallback callback)
        {
            int err = Interop.Bluetooth.BtGattServeSetNotificationStateChangeCallback(_handle, callback, IntPtr.Zero);
            GattUtil.Error(err, "Failed to set characteristic notification state changed callback");
        }

        internal BluetoothGattProperty GetProperties()
        {
            int properties = 0 ;
            int err = Interop.Bluetooth.BtGattCharacteristicGetProperties(_handle, out properties);
            GattUtil.Error(err, "Failed to get characteristic properties");
            return (BluetoothGattProperty)properties;
        }

        internal void SetProperties(BluetoothGattProperty perperties)
        {
            int err = Interop.Bluetooth.BtGattCharacteristicSetProperties(_handle, (int)perperties);
            GattUtil.Error(err, "Failed to set characteristic properties");
        }

        internal BluetoothGattWriteType GetWriteType()
        {
            int writeType;
            int err = Interop.Bluetooth.BtGattCharacteristicGetWriteType(_handle, out writeType);
            GattUtil.Error(err, "Failed to get characteristic writetype");
            return (BluetoothGattWriteType) writeType;
        }

        internal void SetWriteType(BluetoothGattWriteType writeType)
        {
            int err = Interop.Bluetooth.BtGattCharacteristicSetWriteType(_handle, (int)writeType);
            GattUtil.Error(err, "Failed to get characteristic writetype");
        }

        internal void AddDescriptor(BluetoothGattDescriptor descriptor)
        {
            int err = Interop.Bluetooth.BtGattCharacteristicAddDescriptor(_handle, descriptor.GetHandle());
            GattUtil.ThrowForError(err, string.Format("Failed to add descriptor with UUID ({0})", descriptor.Uuid));
        }

        internal BluetoothGattDescriptor GetDescriptor(BluetoothGattCharacteristic characteristic, string uuid)
        {
            BluetoothGattAttributeHandle handle;
            int err = Interop.Bluetooth.BtGattCharacteristicGetDescriptor(_handle, uuid, out handle);
            if (err.IsFailed())
            {
                GattUtil.Error(err, string.Format("Failed to get descriptor with UUID ({0})", uuid));
                return null;
            }
            BluetoothGattDescriptor descriptor = BluetoothGattDescriptorImpl.CreateBluetoothGattDescriptor(handle, uuid);
            if (descriptor != null)
            {
                descriptor.SetParent(characteristic);
            }
            return descriptor;
        }

        internal IEnumerable<BluetoothGattDescriptor> GetDescriptors(BluetoothGattCharacteristic characteristic)
        {
            List<BluetoothGattDescriptor> attribututeList = new List<BluetoothGattDescriptor>();
            _descriptorForeachCallback = (total, index, attributeHandle, userData) =>
            {
                BluetoothGattAttributeHandle handle = new BluetoothGattAttributeHandle(attributeHandle, false);
                BluetoothGattDescriptor descriptor = BluetoothGattDescriptorImpl.CreateBluetoothGattDescriptor(handle, "");
                if (descriptor != null)
                {
                    descriptor.SetParent(characteristic);
                    attribututeList.Add(descriptor);
                }
                return true;
            };

            int err = Interop.Bluetooth.BtGattCharacteristicForeachDescriptors(characteristic.GetHandle(), _descriptorForeachCallback, IntPtr.Zero);
            GattUtil.Error(err, "Failed to get all descriptor");

            return attribututeList;
        }
    }

    internal class BluetoothGattDescriptorImpl : BluetoothGattAttributeImpl
    {
        internal BluetoothGattDescriptorImpl(string uuid, BluetoothGattPermission permission, byte[] value)
        {
            int err = Interop.Bluetooth.BtGattDescriptorCreate(uuid, (int)permission, value, value.Length, out _handle);
            GattUtil.ThrowForError(err, "Failed to get native descriptor handle");
        }

        internal BluetoothGattDescriptorImpl(BluetoothGattAttributeHandle handle)
        {
            _handle = handle;
        }

        internal static BluetoothGattDescriptor CreateBluetoothGattDescriptor(BluetoothGattAttributeHandle handle, string uuid)
        {
            int permission;
            int err = Interop.Bluetooth.BtGattDescriptorGetPermissions(handle, out permission);
            GattUtil.ThrowForError(err, string.Format("Failed to get permissions with UUID ({0})", uuid));

            if (uuid == "")
            {
                int ret = Interop.Bluetooth.BtGattGetUuid(handle, out uuid);
                GattUtil.ThrowForError(ret, "Failed to get UUID");
            }

            BluetoothGattDescriptorImpl impl = new BluetoothGattDescriptorImpl(handle);
            return new BluetoothGattDescriptor(impl, uuid, (BluetoothGattPermission)permission);
        }
    }

    internal abstract class BluetoothGattAttributeImpl
    {
        protected BluetoothGattAttributeHandle _handle;

        internal string GetUuid()
        {
            string uuid;
            int err = Interop.Bluetooth.BtGattGetUuid(_handle, out uuid);
            GattUtil.Error(err, "Failed to get attribute uuid");

            return uuid;
        }

        internal byte[] GetValue()
        {
            IntPtr nativeValue;
            int nativeValueLength;
            int err = Interop.Bluetooth.BtGattGetValue(_handle, out nativeValue, out nativeValueLength);
            GattUtil.Error(err, "Failed to get attribute value");

            return GattUtil.IntPtrToByteArray(nativeValue, nativeValueLength);
        }

        internal void SetValue(byte[] value)
        {
            int err = Interop.Bluetooth.BtGattSetValue(_handle, value, value.Length);
            GattUtil.ThrowForError(err, "Failed to set attribute value");
        }

        internal string GetValue(int offset)
        {
            byte[] value = GetValue();

            int nullPos = value.Length - offset;
            for (int i = offset; i < value.Length; ++i)
            {
                if (value[i] == '\0')
                {
                    nullPos = i;
                    break;
                }
            }

            string strValue = "";
            strValue = Encoding.UTF8.GetString(value, offset, nullPos - offset);
            return strValue;
        }

        internal int GetValue(IntDataType type, int offset)
        {
            int value;
            int err = Interop.Bluetooth.BtGattGetIntValue(_handle, (int)type, offset, out value);
            GattUtil.Error(err, "Failed to get attribute int value at offset");
            return value;
        }

        internal void SetValue(IntDataType type, int value, int offset)
        {
            int err = Interop.Bluetooth.BtGattSetIntValue(_handle, (int)type, value, offset);
            GattUtil.ThrowForError(err, "Failed to set attribute int value at offset");
        }

        internal float GetValue(FloatDataType type, int offset)
        {
            float value;
            int err = Interop.Bluetooth.BtGattGetFloatValue(_handle, (int)type, offset, out value);
            GattUtil.Error(err, "Failed to get attribute float value at offset");
            return value;
        }

        internal void SetValue(FloatDataType type, int mantissa, int exponent, int offset)
        {
            int err = Interop.Bluetooth.BtGattSetFloatValue(_handle, (int)type, mantissa, exponent, offset);
            GattUtil.ThrowForError(err, "Failed to set attribute float value at offset");
        }

        internal void SetReadValueRequestedEventCallback(Interop.Bluetooth.BtGattServerReadValueRequestedCallback callback)
        {
            int err = Interop.Bluetooth.BtGattServerSetReadValueRequestedCallback(_handle, callback, IntPtr.Zero);
            GattUtil.ThrowForError(err, "Failed to set attribute read value requested callback");
        }

        internal void SetWriteValueRequestedEventCallback(Interop.Bluetooth.BtGattServerWriteValueRequestedCallback callback)
        {
            int err = Interop.Bluetooth.BtGattServerSetWriteValueRequestedCallback(_handle, callback, IntPtr.Zero);
            GattUtil.ThrowForError(err, "Failed to set attribute write value requested callback");
        }

        internal BluetoothGattAttributeHandle GetHandle()
        {
            return _handle;
        }

        internal void ReleaseHandleOwnership()
        {
            _handle.ReleaseOwnership();
        }
    }


    internal class BluetoothGattAttributeHandle : BluetoothGattHandle
    {
        public BluetoothGattAttributeHandle(IntPtr nativeHandle, bool hasOwnership) : base(nativeHandle, hasOwnership)
        {
        }

        public BluetoothGattAttributeHandle()
        {
        }

        protected override bool ReleaseHandle()
        {
            if (_hasOwnership == true)
            {
                Interop.Bluetooth.BtGattDestroy(handle);
            }
            SetHandle(IntPtr.Zero);
            return true;
        }
    }

    internal class BluetoothGattClientHandle : BluetoothGattHandle
    {
        protected override bool ReleaseHandle()
        {
            if (_hasOwnership == true)
            {
                Interop.Bluetooth.BtGattClientDestroy(handle);
            }
            SetHandle(IntPtr.Zero);
            return true;
        }
    }

    internal class BluetoothGattServerHandle : BluetoothGattHandle
    {
        protected override bool ReleaseHandle()
        {
            if (_hasOwnership == true)
            {
                int err;

                err = Interop.Bluetooth.BtGattServerDestroy(handle);
                if (err.IsFailed())
                {
                    Log.Error(Globals.LogTag, "Failed to destroy the server instance");
                    return false;
                }

                err = Interop.Bluetooth.BtGattServerDeinitialize();
                if (err.IsFailed())
                {
                    Log.Error(Globals.LogTag, "Failed to deinitialize");
                    SetHandle(IntPtr.Zero);
                    return false;
                }
            }
            SetHandle(IntPtr.Zero);
            return true;
        }
    }

    internal abstract class BluetoothGattHandle : SafeHandle
    {
        protected bool _hasOwnership;

        public BluetoothGattHandle() : base(IntPtr.Zero, true)
        {
            _hasOwnership = true;
        }

        public BluetoothGattHandle(IntPtr nativeHandle, bool hasOwnership) : base(nativeHandle, true)
        {
            _hasOwnership = hasOwnership;
        }

        public override bool IsInvalid
        {
            get { return handle == IntPtr.Zero; }
        }

        public void ReleaseOwnership()
        {
            _hasOwnership = false;
        }
    }

    internal static class GattUtil
    {
        internal static byte[] IntPtrToByteArray(IntPtr nativeValue, int lenght)
        {
            byte[] value = new byte[lenght];
            if (nativeValue != IntPtr.Zero)
            {
                Marshal.Copy(nativeValue, value, 0, lenght);
            }
            return value;
        }

        internal static void Error(int err, string message, [CallerFilePath] string file = "", [CallerMemberName] string func = "", [CallerLineNumber] int line = 0)
        {
            if (err.IsFailed())
            {
                Log.Error(Globals.LogTag, string.Format("{0}, err: {1}", message, (BluetoothError)err), file, func, line);
            }
        }

        internal static void ThrowForError(int err, string message, [CallerFilePath] string file = "", [CallerMemberName] string func = "", [CallerLineNumber] int line = 0)
        {
            if (err.IsFailed())
            {
                Log.Error(Globals.LogTag, string.Format("{0}, err: {1}", message, (BluetoothError)err), file, func, line);
                BluetoothErrorFactory.ThrowBluetoothException(err);
            }
        }

        internal static bool IsFailed(this int err)
        {
            return err != (int)BluetoothError.None;
        }
    }
}
