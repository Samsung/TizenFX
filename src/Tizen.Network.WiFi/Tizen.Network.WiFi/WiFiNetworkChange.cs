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
using System.Threading;

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
        private event EventHandler<ScanStateChangedEventArgs> _scanStateChanged;
        private event EventHandler _backgroundScanFinished;

        private Interop.WiFi.DeviceStateChangedCallback _deviceChangedCallback;
        private Interop.WiFi.ConnectionStateChangedCallback _connectionChangedCallback;
        private Interop.WiFi.RssiLevelChangedCallback _rssiChangedCallback;
        private Interop.WiFi.ScanStateChangedCallback _scanChangedCallback;
        private Interop.WiFi.VoidCallback _backgroundScanFinishedCallback;

        internal event EventHandler<DeviceStateChangedEventArgs> DeviceStateChanged
        {
            add
            {
                context.Post((x) =>
                {
                    if (_deviceStateChanged == null)
                    {
                        try
                        {
                            RegisterDeviceStateChangedEvent();
                        } catch (Exception e)
                        {
                            Log.Error(Globals.LogTag, "Exception on adding DeviceStateChanged\n" + e);
                            return;
                        }
                    }
                    _deviceStateChanged += value;
                }, null);
            }
            remove
            {
                context.Post((x) =>
                {
                    _deviceStateChanged -= value;
                    if (_deviceStateChanged == null)
                    {
                        try
                        {
                            UnregisterDeviceStateChangedEvent();
                        }
                        catch (Exception e)
                        {
                            Log.Error(Globals.LogTag, "Exception on removing DeviceStateChanged\n" + e);
                        }
                    }
                }, null);
            }
        }

        internal event EventHandler<ConnectionStateChangedEventArgs> ConnectionStateChanged
        {
            add
            {
                context.Post((x) =>
                {
                    if (_connectionStateChanged == null)
                    {
                        try
                        {
                            RegisterConnectionStateChangedEvent();
                        }
                        catch (Exception e)
                        {
                            Log.Error(Globals.LogTag, "Exception on adding ConnectionStateChanged\n" + e);
                            return;
                        }
                    }
                    _connectionStateChanged += value;
                }, null);
            }
            remove
            {
                context.Post((x) =>
                {
                    _connectionStateChanged -= value;
                    if (_connectionStateChanged == null)
                    {
                        try
                        {
                            UnregisterConnectionStateChangedEvent();
                        }
                        catch (Exception e)
                        {
                            Log.Error(Globals.LogTag, "Exception on removing ConnectionStateChanged\n" + e);
                        }
                    }
                }, null);
            }
        }

        internal event EventHandler<RssiLevelChangedEventArgs> RssiLevelChanged
        {
            add
            {
                context.Post((x) =>
                {
                    if (_rssiLevelChanged == null)
                    {
                        try
                        {
                            RegisterRssiLevelChangedEvent();
                        }
                        catch (Exception e)
                        {
                            Log.Error(Globals.LogTag, "Exception on adding RssiLevelChanged\n" + e);
                            return;
                        }
                    }
                    _rssiLevelChanged += value;
                }, null);
            }
            remove
            {
                context.Post((x) =>
                {
                    _rssiLevelChanged -= value;
                    if (_rssiLevelChanged == null)
                    {
                        try
                        {
                            UnregisterRssiLevelChangedEvent();
                        }
                        catch (Exception e)
                        {
                            Log.Error(Globals.LogTag, "Exception on removing RssiLevelChanged\n" + e);
                        }
                    }
                }, null);
            }
        }

        internal event EventHandler<ScanStateChangedEventArgs> ScanStateChanged
        {
            add
            {
                context.Post((x) =>
                {
                    if (_scanStateChanged == null)
                    {
                        try
                        {
                            RegisterScanStateChangedEvent();
                        }
                        catch (Exception e)
                        {
                            Log.Error(Globals.LogTag, "Exception on adding ScanStateChanged\n" + e);
                            return;
                        }
                    }
                    _scanStateChanged += value;
                }, null);
            }
            remove
            {
                context.Post((x) =>
                {
                    _scanStateChanged -= value;
                    if (_scanStateChanged == null)
                    {
                        try
                        {
                            UnregisterScanStateChangedEvent();
                        }
                        catch (Exception e)
                        {
                            Log.Error(Globals.LogTag, "Exception on removing ScanStateChanged\n" + e);
                        }
                    }
                }, null);
            }
        }

        internal event EventHandler BackgroundScanFinished
        {
            add
            {
                context.Post((x) =>
                {
                    if (_backgroundScanFinished == null)
                    {
                        try
                        {
                            RegisterBackgroundScanFinishedEvent();
                        }
                        catch (Exception e)
                        {
                            Log.Error(Globals.LogTag, "Exception on adding BackgroundScanFinished\n" + e);
                            return;
                        }
                    }
                    _backgroundScanFinished += value;
                }, null);
            }
            remove
            {
                context.Post((x) =>
                {
                    _backgroundScanFinished -= value;
                    if (_backgroundScanFinished == null)
                    {
                        try
                        {
                            UnregisterBackgroundScanFinishedEvent();
                        }
                        catch (Exception e)
                        {
                            Log.Error(Globals.LogTag, "Exception on removing BackgroundScanFinished\n" + e);
                        }
                    }
                }, null);
            }
        }

        private void RegisterDeviceStateChangedEvent()
        {
            Log.Info(Globals.LogTag, "RegisterDeviceStateChangedEvent in Thread " + Thread.CurrentThread.ManagedThreadId);
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
            Log.Info(Globals.LogTag, "UnregisterDeviceStateChangedEvent in Thread " + Thread.CurrentThread.ManagedThreadId);
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

        private void RegisterScanStateChangedEvent()
        {
            _scanChangedCallback = (int scanState, IntPtr userData) =>
            {
                _scanStateChanged?.(null, new ScanStateChangedEventArgs((WiFiScanState)scanState));
            };
            int ret = Interop.WiFi.SetScanStateChangedCallback(GetSafeHandle(), _scanChangedCallback, IntPtr.Zero);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set scan state changed callback, Error - " + (WiFiError)ret);
            }
        }

        private void UnregisterScanStateChangedEvent()
        {
            int ret = Interop.WiFi.UnsetScanStateChangedCallback(GetSafeHandle());
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to unset scan state changed callback, Error - " + (WiFiError)ret);
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
