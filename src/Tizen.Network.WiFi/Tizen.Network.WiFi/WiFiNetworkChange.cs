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

namespace Tizen.Network.WiFi
{
    internal static class EventHandlerExtension
    {
        internal static void SafeInvoke(this EventHandler evt, object sender, EventArgs e)
        {
            var handler = evt;
            if (handler != null)
            {
                handler(sender, e);
            }
        }

        internal static void SafeInvoke<T>(this EventHandler<T> evt, object sender, T e) where T : EventArgs
        {
            var handler = evt;
            if (handler != null)
            {
                handler(sender, e);
            }
        }
    }

    internal partial class WiFiManagerImpl
    {
        private event EventHandler<DeviceStateChangedEventArgs> _deviceStateChanged;
        private event EventHandler<ConnectionStateChangedEventArgs> _connectionStateChanged;
        private event EventHandler<RssiLevelChangedEventArgs> _rssiLevelChanged;
        private event EventHandler _backgroundScanFinished;

        private Interop.WiFi.DeviceStateChangedCallback _deviceChangedCallback;
        private Interop.WiFi.ConnectionStateChangedCallback _connectionChangedCallback;
        private Interop.WiFi.RssiLevelChangedCallback _rssiChangedCallback;
        private Interop.WiFi.VoidCallback _backgroundScanFinishedCallback;

        internal event EventHandler<DeviceStateChangedEventArgs> DeviceStateChanged
        {
            add
            {
                if (_deviceStateChanged == null)
                {
                    RegisterDeviceStateChangedEvent();
                }
                _deviceStateChanged += value;
            }
            remove
            {
                _deviceStateChanged -= value;
                if (_deviceStateChanged == null)
                {
                    UnregisterDeviceStateChangedEvent();
                }
            }
        }

        internal event EventHandler<ConnectionStateChangedEventArgs> ConnectionStateChanged
        {
            add
            {
                if (_connectionStateChanged == null)
                {
                    RegisterConnectionStateChangedEvent();
                }
                _connectionStateChanged += value;
            }
            remove
            {
                _connectionStateChanged -= value;
                if (_connectionStateChanged == null)
                {
                    UnregisterConnectionStateChangedEvent();
                }
            }
        }

        internal event EventHandler<RssiLevelChangedEventArgs> RssiLevelChanged
        {
            add
            {
                if (_rssiLevelChanged == null)
                {
                    RegisterRssiLevelChangedEvent();
                }
                _rssiLevelChanged += value;
            }
            remove
            {
                _rssiLevelChanged -= value;
                if (_rssiLevelChanged == null)
                {
                    UnregisterRssiLevelChangedEvent();
                }
            }
        }

        internal event EventHandler BackgroundScanFinished
        {
            add
            {
                if (_backgroundScanFinished == null)
                {
                    RegisterBackgroundScanFinishedEvent();
                }
                _backgroundScanFinished += value;
            }
            remove
            {
                _backgroundScanFinished -= value;
                if (_backgroundScanFinished == null)
                {
                    UnregisterBackgroundScanFinishedEvent();
                }
            }
        }

        private void RegisterDeviceStateChangedEvent()
        {
            _deviceChangedCallback = (int deviceState, IntPtr userDate) =>
            {
                WiFiDeviceState state = (WiFiDeviceState)deviceState;
                DeviceStateChangedEventArgs e = new DeviceStateChangedEventArgs(state);
                _deviceStateChanged.SafeInvoke(null, e);
            };
            int ret = Interop.WiFi.SetDeviceStateChangedCallback(GetSafeHandle(), _deviceChangedCallback, IntPtr.Zero);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set device state changed callback, Error - " + (WiFiError)ret);
            }
        }

        private void UnregisterDeviceStateChangedEvent()
        {
            int ret = Interop.WiFi.UnsetDeviceStateChangedCallback(GetSafeHandle());
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to unset device state changed callback, Error - " + (WiFiError)ret);
            }
        }

        private void RegisterConnectionStateChangedEvent()
        {
            _connectionChangedCallback = (int connectionState, IntPtr ap, IntPtr userData) =>
            {
                if (ap != IntPtr.Zero)
                {
                    WiFiConnectionState state = (WiFiConnectionState)connectionState;
                    ConnectionStateChangedEventArgs e = new ConnectionStateChangedEventArgs(state, ap);
                    _connectionStateChanged.SafeInvoke(null, e);
                }
            };
            int ret = Interop.WiFi.SetConnectionStateChangedCallback(GetSafeHandle(), _connectionChangedCallback, IntPtr.Zero);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set copnnection state changed callback, Error - " + (WiFiError)ret);
            }
        }

        private void UnregisterConnectionStateChangedEvent()
        {
            int ret = Interop.WiFi.UnsetConnectionStateChangedCallback(GetSafeHandle());
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to unset device state changed callback, Error - " + (WiFiError)ret);
            }
        }

        private void RegisterRssiLevelChangedEvent()
        {

            _rssiChangedCallback = (int rssiLevel, IntPtr userDate) =>
            {
                WiFiRssiLevel level = (WiFiRssiLevel)rssiLevel;
                RssiLevelChangedEventArgs e = new RssiLevelChangedEventArgs(level);
                _rssiLevelChanged.SafeInvoke(null, e);
            };
            int ret = Interop.WiFi.SetRssiLevelchangedCallback(GetSafeHandle(), _rssiChangedCallback, IntPtr.Zero);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set rssi level changed callback, Error - " + (WiFiError)ret);
            }
        }

        private void UnregisterRssiLevelChangedEvent()
        {
            int ret = Interop.WiFi.UnsetRssiLevelchangedCallback(GetSafeHandle());
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to unset rssi level changed callback, Error - " + (WiFiError)ret);
            }
        }

        private void RegisterBackgroundScanFinishedEvent()
        {
            _backgroundScanFinishedCallback = (int result, IntPtr userDate) =>
            {
                EventArgs e = new EventArgs();
                _backgroundScanFinished.SafeInvoke(null, e);
            };
            int ret = Interop.WiFi.SetBackgroundScanCallback(GetSafeHandle(), _backgroundScanFinishedCallback, IntPtr.Zero);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set background scan callback, Error - " + (WiFiError)ret);
            }
        }

        private void UnregisterBackgroundScanFinishedEvent()
        {
            int ret = Interop.WiFi.UnsetBackgroundScanCallback(GetSafeHandle());
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to unset background scan callback, Error - " + (WiFiError)ret);
            }
        }
    }
}
