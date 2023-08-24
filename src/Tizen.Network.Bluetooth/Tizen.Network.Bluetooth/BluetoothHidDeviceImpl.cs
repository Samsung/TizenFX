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
    internal class BluetoothHidDeviceImpl
    {
        private event EventHandler<HidDeviceConnectionStateChangedEventArgs> _hidDeviceConnectionStateChanged;
        private Interop.Bluetooth.HidDeviceConnectionStateChangedCallback _hidDeviceConnectionStateChangedCallback;

        private event EventHandler<HidDeviceDataReceivedEventArgs> _hidDeviceDataReceived;
        private Interop.Bluetooth.HidDeviceDataReceivedCallback _hidDeviceDataReceivedCallback;

        private static readonly Lazy<BluetoothHidDeviceImpl> _instance = new Lazy<BluetoothHidDeviceImpl>(() =>
        {
            return new BluetoothHidDeviceImpl();
        });

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

        internal int ConnectHidDevice(string deviceAddress)
        {
            return Interop.Bluetooth.ConnectHidDevice(deviceAddress);
        }

        internal int DisconnectHidDevice(string deviceAddress)
        {
            return Interop.Bluetooth.DisconnectHidDevice(deviceAddress);
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
            _hidDeviceDataReceivedCallback = (ref BluetoothHidDeviceReceivedDataStruct receivedData, IntPtr userData) =>
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
                return _instance.Value;
            }
        }

        private BluetoothHidDeviceImpl()
        {
            Initialize();
        }

        ~BluetoothHidDeviceImpl()
        {
            Deinitialize();
        }

        private void Initialize()
        {
            if (Globals.IsInitialize)
            {
                _hidDeviceConnectionStateChangedCallback = (int result, bool isConnected, string address, IntPtr userData) =>
                {
                    _hidDeviceConnectionStateChanged?.Invoke(null, new HidDeviceConnectionStateChangedEventArgs(result, isConnected, address));
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

