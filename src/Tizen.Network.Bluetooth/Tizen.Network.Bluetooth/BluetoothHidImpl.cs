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

namespace Tizen.Network.Bluetooth
{
    internal class BluetoothHidImpl : IDisposable
    {
        private event EventHandler<HidConnectionStateChangedEventArgs> _hidConnectionChanged;
        private event EventHandler<HidDeviceConnectionStateChangedEventArgs> _hidDeviceConnectionStateChanged;
        private event EventHandler<HidDeviceDataReceivedEventArgs> _hidDeviceDataReceived;

        private static readonly BluetoothHidImpl _instance = new BluetoothHidImpl();
        private bool disposed = false;

        internal event EventHandler<HidConnectionStateChangedEventArgs> HidConnectionStateChanged
        {
            add
            {
                _hidConnectionChanged += value;
            }
            remove
            {
                //nothing to be done
            }
        }

        internal int Connect(string deviceAddress)
        {
            if (Globals.IsHidInitialize)
            {
                int ret = Interop.Bluetooth.Connect(deviceAddress);
                if (ret != (int)BluetoothError.None) {
                    Log.Error(Globals.LogTag, "Failed to connect device with the hid service, Error - " + (BluetoothError)ret);
                }
                return ret;
            }
            return (int)BluetoothError.NotInitialized;
        }

        internal int Disconnect(string deviceAddress)
        {
            if (Globals.IsHidInitialize)
            {
                int ret = Interop.Bluetooth.Disconnect(deviceAddress);
                if (ret != (int)BluetoothError.None) {
                    Log.Error(Globals.LogTag, "Failed to disconnect device with the hid service, Error - " + (BluetoothError)ret);
                }
                return ret;
            }
            return (int)BluetoothError.NotInitialized;
        }

        internal event EventHandler<HidDeviceConnectionStateChangedEventArgs> HidDeviceConnectionStateChanged
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

        internal int ActivateHidDevice()
        {
            Interop.Bluetooth.HidDeviceConnectionStateChangedCallback _hidDeviceConnectionStateChangedCallback = (int result, bool isConnected, string address, IntPtr userData) =>
            {
                if (_hidDeviceConnectionStateChanged != null)
                {
                    _hidDeviceConnectionStateChanged(null, new HidDeviceConnectionStateChangedEventArgs(result, isConnected, address));
                }
            };

            int ret = Interop.Bluetooth.ActivateHidDevice(_hidDeviceConnectionStateChangedCallback, IntPtr.Zero);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to activate to the remote device, Error - " + (BluetoothError)ret);
            }
            return ret;
        }

        internal int DeactivateHidDevice()
        {
            int ret = Interop.Bluetooth.DeactivateHidDevice();
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to deactivate to the remote device, Error - " + (BluetoothError)ret);
            }
            return ret;
        }

        internal int ConnectHidDevice(string deviceAddress)
        {
            int ret = Interop.Bluetooth.ConnectHidDevice(deviceAddress);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to connect to the remote device, Error - " + (BluetoothError)ret);
            }
            return ret;
        }

        internal int DisconnectHidDevice(string deviceAddress)
        {
            int ret = Interop.Bluetooth.DisconnectHidDevice(deviceAddress);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to disconnect to the remote device, Error - " + (BluetoothError)ret);
            }
            return ret;
        }

        internal int SendHidDeviceMouseEvent(string deviceAddress, BluetoothHidMouseData mouseData)
        {
            int ret = Interop.Bluetooth.SendHidDeviceMouseEvent(deviceAddress, mouseData);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to send mouse event to the remote device, Error - " + (BluetoothError)ret);
            }
            return ret;
        }

        internal int SendHidDeviceKeyEvent(string deviceAddress, BluetoothHidKeyData keyData)
        {
            int ret = Interop.Bluetooth.SendHidDeviceKeyEvent(deviceAddress, keyData);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to send key event to the remote device, Error - " + (BluetoothError)ret);
            }
            return ret;
        }

        internal event EventHandler<HidDeviceDataReceivedEventArgs> HidDeviceDataReceived
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
            Interop.Bluetooth.HidDeviceDataReceivedCallback _hidDeviceDataReceivedCallback = (BluetoothHidDeviceReceivedData receivedData, IntPtr userData) =>
            {
                if (_hidDeviceDataReceived != null)
                {
                    _hidDeviceDataReceived(null, new HidDeviceDataReceivedEventArgs(receivedData));
                }
            };

            int ret = Interop.Bluetooth.SetHidDeviceDataReceivedCallback(_hidDeviceDataReceivedCallback, IntPtr.Zero);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set data received callback, Error - " + (BluetoothError)ret);
            }
        }

        private void UnregisterHidDataReceivedEvent()
        {
            int ret = Interop.Bluetooth.UnsetHidDeviceDataReceivedCallback();
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to unset data received callback, Error - " + (BluetoothError)ret);
            }
        }

        internal int ReplyToReportHidDevice(string deviceAddress, BluetoothHidHeaderType headerType, BluetoothHidParamType paramType, byte[] value)
        {
            int ret = Interop.Bluetooth.ReplyToReportHidDevice(deviceAddress, headerType, paramType, value, value.Length, IntPtr.Zero);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to reply to report from hid host, Error - " + (BluetoothError)ret);
            }
            return ret;
        }

        internal static BluetoothHidImpl Instance
        {
            get
            {
                return _instance;
            }
        }
        private BluetoothHidImpl ()
        {
            initialize();
        }
        ~BluetoothHidImpl()
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
            deinitialize();
            disposed = true;
        }

        private void initialize()
        {
            if (Globals.IsInitialize)
            {
                Interop.Bluetooth.HidConnectionStateChangedCallback _hidConnectionChangedCallback = (int result, bool connected, string deviceAddress, IntPtr userData) =>
                {
                    if (_hidConnectionChanged != null)
                    {
                        _hidConnectionChanged(null, new HidConnectionStateChangedEventArgs(result, connected, deviceAddress));
                    }
                };

                int ret = Interop.Bluetooth.InitializeHid (_hidConnectionChangedCallback, IntPtr.Zero);
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to initialize bluetooth hid, Error - " + (BluetoothError)ret);
                    BluetoothErrorFactory.ThrowBluetoothException (ret);
                }
                else
                {
                    Globals.IsHidInitialize = true;
                }
            }
            else
            {
                Log.Error(Globals.LogTag, "Failed to initialize HID, BT not initialized");
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotInitialized);
            }
        }

        private void deinitialize()
        {
            if (Globals.IsHidInitialize)
            {
                int ret = Interop.Bluetooth.DeinitializeHid ();
                if (ret != (int)BluetoothError.None) {
                    Log.Error (Globals.LogTag, "Failed to deinitialize bluetooth hid, Error - " + (BluetoothError)ret);
                    BluetoothErrorFactory.ThrowBluetoothException (ret);
                } else {
                    Globals.IsHidInitialize = false;
                }
            }
        }
    }
}

