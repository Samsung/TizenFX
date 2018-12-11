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
using System.Threading.Tasks;

namespace Tizen.Network.Bluetooth
{
    internal class BluetoothHidDeviceImpl : IDisposable
    {
        private event EventHandler<HidDeviceConnectionStateChangedEventArgs> _hidDeviceConnectionStateChanged;
        private event EventHandler<HidDeviceDataReceivedEventArgs> _hidDeviceDataReceived;

        private TaskCompletionSource<BluetoothError> _taskForConnection;
        private TaskCompletionSource<BluetoothError> _taskForDisconnection;

        private static readonly BluetoothHidDeviceImpl _instance = new BluetoothHidDeviceImpl();
        private bool disposed = false;

        internal event EventHandler<HidDeviceConnectionStateChangedEventArgs> ConnectionStateChanged
        {
            add
            {
                _hidDeviceConnectionStateChanged += value;
            }
            remove
            {
                _hidDeviceConnectionStateChanged -= value;
            }
        }

        internal Task<BluetoothError> ConnectHidDeviceAsync(string deviceAddress)
        {
            _taskForConnection = new TaskCompletionSource<BluetoothError>();
            if (_taskForConnection != null && !_taskForConnection.Task.IsCompleted)
            {
                throw new InvalidOperationException("Connection is in progress");
            }

            int ret = Interop.Bluetooth.ConnectHidDevice(deviceAddress);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to connect to the remote device, Error - " + (BluetoothError)ret);
                _taskForConnection.SetException(new InvalidOperationException("Failed to connect to the remote device, Error - " + (BluetoothError)ret));
            }
            return _taskForConnection.Task;
        }

        internal Task<BluetoothError> DisconnectHidDeviceAsync(string deviceAddress)
        {
            _taskForDisconnection = new TaskCompletionSource<BluetoothError>();
            if (_taskForDisconnection != null && !_taskForDisconnection.Task.IsCompleted)
            {
                throw new InvalidOperationException("Disconnection is in progress");
            }

            int ret = Interop.Bluetooth.DisconnectHidDevice(deviceAddress);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to disconnect to the remote device, Error - " + (BluetoothError)ret);
                _taskForDisconnection.SetException(new InvalidOperationException("Failed to disconnect to the remote device, Error - " + (BluetoothError)ret));
            }
            return _taskForDisconnection.Task;
        }

        internal void SendHidDeviceMouseEvent(string deviceAddress, BluetoothHidMouseData mouseData)
        {
            int ret = Interop.Bluetooth.SendHidDeviceMouseEvent(deviceAddress, mouseData);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to send mouse event to the remote device, Error - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
        }

        internal void SendHidDeviceKeyEvent(string deviceAddress, BluetoothHidKeyData keyData)
        {
            int ret = Interop.Bluetooth.SendHidDeviceKeyEvent(deviceAddress, keyData);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to send key event to the remote device, Error - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
        }

        internal event EventHandler<HidDeviceDataReceivedEventArgs> DataReceived
        {
            add
            {
                if (_hidDeviceDataReceived == null)
                {
                    RegisterHidDataReceivedEvent();
                }
                _hidDeviceDataReceived += value;
            }
            remove
            {
                _hidDeviceDataReceived -= value;
                if (_hidDeviceDataReceived == null)
                {
                    UnregisterHidDataReceivedEvent();
                }
            }
        }

        private void RegisterHidDataReceivedEvent()
        {
            Interop.Bluetooth.HidDeviceDataReceivedCallback _hidDeviceDataReceivedCallback = (ref BluetoothHidDeviceReceivedDataStruct receivedData, IntPtr userData) =>
            {
                _hidDeviceDataReceived?.Invoke(null, new HidDeviceDataReceivedEventArgs(BluetoothHidDeviceReceivedData.Create(receivedData)));
            };

            int ret = Interop.Bluetooth.SetHidDeviceDataReceivedCallback(_hidDeviceDataReceivedCallback, IntPtr.Zero);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set data received callback, Error - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
        }

        private void UnregisterHidDataReceivedEvent()
        {
            int ret = Interop.Bluetooth.UnsetHidDeviceDataReceivedCallback();
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to unset data received callback, Error - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
        }

        internal void ReplyToReportHidDevice(string deviceAddress, BluetoothHidHeaderType headerType, BluetoothHidParamType paramType, byte[] data)
        {
            int ret = Interop.Bluetooth.ReplyToReportHidDevice(deviceAddress, headerType, paramType, data, data.Length, IntPtr.Zero);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to reply to report from hid host, Error - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
        }

        internal static BluetoothHidDeviceImpl Instance
        {
            get
            {
                return _instance;
            }
        }
        private BluetoothHidDeviceImpl()
        {
            Initialize();
        }
        ~BluetoothHidDeviceImpl()
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
            //Free unmanaged objects
            Deinitialize();
            disposed = true;
        }

        private void Initialize()
        {
            if (Globals.IsInitialize)
            {
                Interop.Bluetooth.HidDeviceConnectionStateChangedCallback _hidDeviceConnectionStateChangedCallback = (int result, bool isConnected, string address, IntPtr userData) =>
                {
                    if (_taskForConnection != null && !_taskForConnection.Task.IsCompleted)
                    {
                        _taskForConnection.SetResult((BluetoothError)result);
                    }

                    if (_taskForDisconnection != null && _taskForDisconnection.Task.IsCompleted)
                    {
                        _taskForDisconnection.SetResult((BluetoothError)result);
                    }

                    if (result == (int)BluetoothError.None)
                    {
                        _hidDeviceConnectionStateChanged?.Invoke(null, new HidDeviceConnectionStateChangedEventArgs(isConnected, address));
                    }
                };

                int ret = Interop.Bluetooth.ActivateHidDevice(_hidDeviceConnectionStateChangedCallback, IntPtr.Zero);
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to activate to the remote device, Error - " + (BluetoothError)ret);
                    BluetoothErrorFactory.ThrowBluetoothException(ret);
                }
            }
            else
            {
                Log.Error(Globals.LogTag, "Failed to initialize HID Device, BT not initialized");
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotInitialized);
            }
        }

        private void Deinitialize()
        {
            int ret = Interop.Bluetooth.DeactivateHidDevice();
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to deactivate to the remote device, Error - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
        }
    }
}

