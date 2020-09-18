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
        private Interop.Bluetooth.HidConnectionStateChangedCallback _hidConnectionChangedCallback;

        private static readonly Lazy<BluetoothHidImpl> _instance = new Lazy<BluetoothHidImpl>(() =>
        {
            return new BluetoothHidImpl();
        });
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
                int ret = Interop.Bluetooth.Connect (deviceAddress);
                if (ret != (int)BluetoothError.None) {
                    Log.Error (Globals.LogTag, "Failed to connect device with the hid service, Error - " + (BluetoothError)ret);
                }
                return ret;
            }
            return (int)BluetoothError.NotInitialized;
        }

        internal int Disconnect(string deviceAddress)
        {
            if (Globals.IsHidInitialize)
            {
                int ret = Interop.Bluetooth.Disconnect (deviceAddress);
                if (ret != (int)BluetoothError.None) {
                    Log.Error (Globals.LogTag, "Failed to disconnect device with the hid service, Error - " + (BluetoothError)ret);
                }
                return ret;
            }
            return (int)BluetoothError.NotInitialized;
        }

        internal static BluetoothHidImpl Instance
        {
            get
            {
                return _instance.Value;
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
                _hidConnectionChangedCallback = (int result, bool connected, string deviceAddress, IntPtr userData) =>
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

