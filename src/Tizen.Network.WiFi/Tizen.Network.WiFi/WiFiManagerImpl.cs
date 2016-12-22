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
using System.Threading.Tasks;

namespace Tizen.Network.WiFi
{
    static internal class Globals
    {
        internal const string LogTag = "Tizen.Network.WiFi";
    }

    internal partial class WiFiManagerImpl : IDisposable
    {
        private static readonly WiFiManagerImpl _instance = new WiFiManagerImpl();
        private Dictionary<IntPtr, Interop.WiFi.VoidCallback> _callback_map = new Dictionary<IntPtr, Interop.WiFi.VoidCallback>();
        private int _requestId = 0;
        private string _macAddress;
        private bool disposed = false;

        internal string MacAddress
        {
            get
            {
                if (String.IsNullOrEmpty(_macAddress))
                {
                    string address;
                    int ret = Interop.WiFi.GetMacAddress(out address);
                    if (ret != (int)WiFiError.None)
                    {
                        Log.Error(Globals.LogTag, "Failed to get mac address, Error - " + (WiFiError)ret);
                        _macAddress = "";
                    }
                    else
                    {
                        _macAddress = address;
                    }
                }
                return _macAddress;
            }
        }
        internal string InterfaceName
        {
            get
            {
                string name;
                int ret = Interop.WiFi.GetNetworkInterfaceName(out name);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get interface name, Error - " + (WiFiError)ret);
                    return "";
                }
                return name;
            }
        }
        internal WiFiConnectionState ConnectionState
        {
            get
            {
                int state;
                int ret = Interop.WiFi.GetConnectionState(out state);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get connection state, Error - " + (WiFiError)ret);
                    return WiFiConnectionState.Failure;
                }
                return (WiFiConnectionState)state;
            }
        }
        internal bool IsActivated
        {
            get
            {
                bool active;
                int ret = Interop.WiFi.IsActivated(out active);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get isActive, Error - " + (WiFiError)ret);
                }
                return active;
            }
        }

        internal static WiFiManagerImpl Instance
        {
            get
            {
                return _instance;
            }
        }

        private WiFiManagerImpl()
        {
            initialize();
        }

        ~WiFiManagerImpl()
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
            RemoveAllRegisteredEvent();
            disposed = true;
        }

        private void initialize()
        {
            int ret = Interop.WiFi.Initialize();
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to initialize wifi, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret);
            }
            string address;
            ret = Interop.WiFi.GetMacAddress(out address);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get mac address, Error - " + (WiFiError)ret);
                _macAddress = "";
            }
            _macAddress = address;
        }

        private void deinitialize()
        {
            int ret = Interop.WiFi.Deinitialize();
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to deinitialize wifi, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret);
            }
        }

        internal IEnumerable<WiFiAp> GetFoundAps()
        {
            List<WiFiAp> apList = new List<WiFiAp>();
            Interop.WiFi.HandleCallback callback = (IntPtr apHandle, IntPtr userData) =>
            {
                if (apHandle != IntPtr.Zero)
                {
                    IntPtr clonedHandle;
                    Interop.WiFi.Ap.Clone(out clonedHandle, apHandle);
                    WiFiAp apItem = new WiFiAp(clonedHandle);
                    apList.Add(apItem);
                    return true;
                }
                return false;
            };

            int ret = Interop.WiFi.GetForeachFoundAps(callback, IntPtr.Zero);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get all APs, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret);
            }

            return apList;
        }

        internal IEnumerable<WiFiAp> GetFoundSpecificAps()
        {
            List<WiFiAp> apList = new List<WiFiAp>();
            Interop.WiFi.HandleCallback callback = (IntPtr apHandle, IntPtr userData) =>
            {
                if (apHandle != IntPtr.Zero)
                {
                    IntPtr clonedHandle;
                    Interop.WiFi.Ap.Clone(out clonedHandle, apHandle);
                    WiFiAp apItem = new WiFiAp(clonedHandle);
                    apList.Add(apItem);
                    return true;
                }
                return false;

            };

            int ret = Interop.WiFi.GetForeachFoundSpecificAps(callback, IntPtr.Zero);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get specific APs, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret);
            }

            return apList;
        }

        internal IEnumerable<WiFiConfiguration> GetWiFiConfigurations()
        {
            List<WiFiConfiguration> configList = new List<WiFiConfiguration>();
            Interop.WiFi.HandleCallback callback = (IntPtr configHandle, IntPtr userData) =>
            {
                if (configHandle != IntPtr.Zero)
                {
                    IntPtr clonedConfig;
                    Interop.WiFi.Config.Clone(configHandle, out clonedConfig);
                    WiFiConfiguration configItem = new WiFiConfiguration(clonedConfig);
                    configList.Add(configItem);
                    return true;
                }
                return false;
            };

            int ret = Interop.WiFi.Config.GetForeachConfiguration(callback, IntPtr.Zero);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get configurations, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret);
            }

            return configList;
        }

        internal void SaveWiFiNetworkConfiguration(WiFiConfiguration config)
        {
            IntPtr configHandle = config.GetHandle();
            int ret = Interop.WiFi.Config.SaveConfiguration(configHandle);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to save configuration, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret);
            }
        }

        internal WiFiAp GetConnectedAp()
        {
            IntPtr apHandle;

            int ret = Interop.WiFi.GetConnectedAp(out apHandle);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to connect with AP, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret);
            }
            WiFiAp ap = new WiFiAp(apHandle);
            return ap;
        }

        internal void RemoveAp(WiFiAp ap)
        {
            IntPtr apHandle = ap.GetHandle();
            int ret = Interop.WiFi.RemoveAp(apHandle);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to remove with AP, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret);
            }
        }

        internal Task ActivateAsync()
        {
            TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
            IntPtr id;
            lock (_callback_map)
            {
                id = (IntPtr)_requestId++;
                _callback_map[id] = (error, key) =>
                {
                    Log.Debug(Globals.LogTag, "wifi activated");
                    if (error != (int)WiFiError.None)
                    {
                        Log.Error(Globals.LogTag, "Error occurs during WiFi activating, " + (WiFiError)error);
                        task.SetException(new InvalidOperationException("Error occurs during WiFi activating, " + (WiFiError)error));
                    }
                    task.SetResult(true);
                    lock (_callback_map)
                    {
                        _callback_map.Remove(key);
                    }
                };
            }
            int ret = Interop.WiFi.Activate(_callback_map[id], id);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to activate wifi, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret);
            }
            return task.Task;
        }

        internal Task ActivateWithWiFiPickerTestedAsync()
        {
            TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
            IntPtr id;
            lock (_callback_map)
            {
                id = (IntPtr)_requestId++;
                _callback_map[id] = (error, key) =>
                {
                    Log.Debug(Globals.LogTag, "Activation finished");
                    if (error != (int)WiFiError.None)
                    {
                        Log.Error(Globals.LogTag, "Error occurs during WiFi activating, " + (WiFiError)error);
                        task.SetException(new InvalidOperationException("Error occurs during WiFi activating, " + (WiFiError)error));
                    }
                    task.SetResult(true);
                    lock (_callback_map)
                    {
                        _callback_map.Remove(key);
                    }
                };
            }
            int ret = Interop.WiFi.ActivateWithWiFiPickerTested(_callback_map[id], id);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to activate wifi, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret);
            }
            return task.Task;
        }

        internal Task DeactivateAsync()
        {
            TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
            IntPtr id;
            lock (_callback_map)
            {
                id = (IntPtr)_requestId++;
                _callback_map[id] = (error, key) =>
                {
                    Log.Debug(Globals.LogTag, "Deactivation finished");
                    if (error != (int)WiFiError.None)
                    {
                        Log.Error(Globals.LogTag, "Error occurs during WiFi deactivating, " + (WiFiError)error);
                        task.SetException(new InvalidOperationException("Error occurs during WiFi deactivating, " + (WiFiError)error));
                    }
                    task.SetResult(true);
                    lock (_callback_map)
                    {
                        _callback_map.Remove(key);
                    }
                };
            }
            int ret = Interop.WiFi.Deactivate(_callback_map[id], id);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to deactivate wifi, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret);
            }
            return task.Task;
        }

        internal Task ScanAsync()
        {
            TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
            IntPtr id;
            lock (_callback_map)
            {
                id = (IntPtr)_requestId++;
                _callback_map[id] = (error, key) =>
                {
                    Log.Debug(Globals.LogTag, "Scanning finished");
                    if (error != (int)WiFiError.None)
                    {
                        Log.Error(Globals.LogTag, "Error occurs during WiFi scanning, " + (WiFiError)error);
                        task.SetException(new InvalidOperationException("Error occurs during WiFi scanning, " + (WiFiError)error));
                    }
                    task.SetResult(true);
                    lock (_callback_map)
                    {
                        _callback_map.Remove(key);
                    }
                };
            }
            int ret = Interop.WiFi.Scan(_callback_map[id], id);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to scan all AP, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret);
            }
            return task.Task;
        }

        internal Task ScanSpecificApAsync(string essid)
        {
            TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
            IntPtr id;
            lock (_callback_map)
            {
                id = (IntPtr)_requestId++;
                _callback_map[id] = (error, key) =>
                {
                    Log.Debug(Globals.LogTag, "Scanning with specific AP finished");
                    if (error != (int)WiFiError.None)
                    {
                        Log.Error(Globals.LogTag, "Error occurs during WiFi scanning, " + (WiFiError)error);
                        task.SetException(new InvalidOperationException("Error occurs during WiFi scanning, " + (WiFiError)error));
                    }
                    task.SetResult(true);
                    lock (_callback_map)
                    {
                        _callback_map.Remove(key);
                    }
                };
            }
            int ret = Interop.WiFi.ScanSpecificAp(essid, _callback_map[id], id);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to scan with specific AP, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret);
            }
            return task.Task;
        }

        internal Task ConnectAsync(WiFiAp ap)
        {
            TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
            IntPtr id;
            lock (_callback_map)
            {
                id = (IntPtr)_requestId++;
                _callback_map[id] = (error, key) =>
                {
                    Log.Debug(Globals.LogTag, "Connecting finished : " + (WiFiError)error);
                    if (error != (int)WiFiError.None)
                    {
                        Log.Error(Globals.LogTag, "Error occurs during WiFi connecting, " + (WiFiError)error);
                        task.SetException(new InvalidOperationException("Error occurs during WiFi connecting, " + (WiFiError)error));
                    }
                    task.SetResult(true);
                    lock (_callback_map)
                    {
                        _callback_map.Remove(key);
                    }
                };
            }
            IntPtr apHandle = ap.GetHandle();
            int ret = Interop.WiFi.Connect(apHandle, _callback_map[id], id);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to connect wifi, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret);
            }
            return task.Task;
        }

        internal Task DisconnectAsync(WiFiAp ap)
        {
            TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
            IntPtr id;
            lock (_callback_map)
            {
                id = (IntPtr)_requestId++;
                _callback_map[id] = (error, key) =>
                {
                    Log.Debug(Globals.LogTag, "Disconnecting finished");
                    if (error != (int)WiFiError.None)
                    {
                        Log.Error(Globals.LogTag, "Error occurs during WiFi disconnecting, " + (WiFiError)error);
                        task.SetException(new InvalidOperationException("Error occurs during WiFi disconnecting, " + (WiFiError)error));
                    }
                    task.SetResult(true);
                    lock (_callback_map)
                    {
                        _callback_map.Remove(key);
                    }
                };
            }
            IntPtr apHandle = ap.GetHandle();
            int ret = Interop.WiFi.Disconnect(apHandle, _callback_map[id], id);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to disconnect wifi, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret);
            }
            return task.Task;
        }

        internal Task ConnectByWpsPbcAsync(WiFiAp ap)
        {
            TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
            IntPtr id;
            lock (_callback_map)
            {
                id = (IntPtr)_requestId++;
                _callback_map[id] = (error, key) =>
                {
                    Log.Debug(Globals.LogTag, "Connecting by WPS PBC finished");
                    if (error != (int)WiFiError.None)
                    {
                        Log.Error(Globals.LogTag, "Error occurs during WiFi connecting, " + (WiFiError)error);
                        task.SetException(new InvalidOperationException("Error occurs during WiFi connecting, " + (WiFiError)error));
                    }
                    task.SetResult(true);
                    lock (_callback_map)
                    {
                        _callback_map.Remove(key);
                    }
                };
            }
            IntPtr apHandle = ap.GetHandle();
            int ret = Interop.WiFi.ConnectByWpsPbc(apHandle, _callback_map[id], id);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to connect wifi, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret);
            }
            return task.Task;
        }

        internal Task ConnectByWpsPinAsync(WiFiAp ap, string pin)
        {
            TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
            IntPtr id;
            lock (_callback_map)
            {
                id = (IntPtr)_requestId++;
                _callback_map[id] = (error, key) =>
                {
                    Log.Debug(Globals.LogTag, "Connecting by WPS PIN finished");
                    if (error != (int)WiFiError.None)
                    {
                        Log.Error(Globals.LogTag, "Error occurs during WiFi connecting, " + (WiFiError)error);
                        task.SetException(new InvalidOperationException("Error occurs during WiFi connecting, " + (WiFiError)error));
                    }
                    task.SetResult(true);
                    lock (_callback_map)
                    {
                        _callback_map.Remove(key);
                    }
                };
            }
            IntPtr apHandle = ap.GetHandle();
            int ret = Interop.WiFi.ConnectByWpsPin(apHandle, pin, _callback_map[id], id);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to connect wifi, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret);
            }
            return task.Task;
        }
    }
}
