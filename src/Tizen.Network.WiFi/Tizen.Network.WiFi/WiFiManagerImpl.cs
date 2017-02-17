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
using System.Threading;
using System.Threading.Tasks;

namespace Tizen.Network.WiFi
{
    static internal class Globals
    {
        internal const string LogTag = "Tizen.Network.WiFi";
    }

    internal class HandleHolder : IDisposable
    {
        private IntPtr _handle = IntPtr.Zero;
        private bool disposed = false;

        internal HandleHolder()
        {
            Log.Debug(Globals.LogTag, "HandleHolder() Constructor");
            _handle = WiFiManagerImpl.Instance.Initialize();
            Log.Debug(Globals.LogTag, "Handle: " + _handle);
        }

        ~HandleHolder()
        {
            Dispose(false);
        }

        internal IntPtr GetHandle()
        {
            Log.Debug(Globals.LogTag, "Handleholder handle = " + _handle);
            return _handle;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            Log.Debug(Globals.LogTag, ">>> HandleHolder Dispose with " + disposing);
            Log.Debug(Globals.LogTag, ">>> Handle: " + _handle);
            if (disposed)
                return;

            if (disposing)
            {
                // Free managed objects.
                WiFiManagerImpl.Instance.Deinitialize(_handle);
            }
            disposed = true;
        }
    }

    internal partial class WiFiManagerImpl : IDisposable
    {
        private static WiFiManagerImpl _instance = null;
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
                    int ret = Interop.WiFi.GetMacAddress(GetHandle(), out address);
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
                int ret = Interop.WiFi.GetNetworkInterfaceName(GetHandle(), out name);
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
                int ret = Interop.WiFi.GetConnectionState(GetHandle(), out state);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get connection state, Error - " + (WiFiError)ret);
                    return WiFiConnectionState.Failure;
                }
                return (WiFiConnectionState)state;
            }
        }

        internal bool IsActive
        {
            get
            {
                bool active;
                int ret = Interop.WiFi.IsActive(GetHandle(), out active);
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
                Log.Debug(Globals.LogTag, "Instance getter");
                if (_instance == null)
                {
                    Log.Debug(Globals.LogTag, "Instance is null");
                    _instance = new WiFiManagerImpl();
                }

                return _instance;
            }
        }

        private static ThreadLocal<HandleHolder> s_threadName = new ThreadLocal<HandleHolder>(() =>
        {
            Log.Info(Globals.LogTag, "In threadlocal delegate");
            return new HandleHolder();
        });

        private WiFiManagerImpl()
        {
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
            RemoveAllRegisteredEvent();
            disposed = true;
        }

        internal IntPtr GetHandle()
        {
            Log.Debug(Globals.LogTag, "GetHandle, Thread Id = " + Thread.CurrentThread.ManagedThreadId);
            return s_threadName.Value.GetHandle();
        }

        internal IntPtr Initialize()
        {
            IntPtr handle;
            int ret = Interop.WiFi.Initialize(out handle);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to initialize wifi, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret);
            }
            return handle;
        }

        internal void Deinitialize(IntPtr handle)
        {
            int ret = Interop.WiFi.Deinitialize(handle);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to deinitialize wifi, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret);
            }
        }

        internal IEnumerable<WiFiAP> GetFoundAPs()
        {
            List<WiFiAP> apList = new List<WiFiAP>();
            Interop.WiFi.HandleCallback callback = (IntPtr apHandle, IntPtr userData) =>
            {
                if (apHandle != IntPtr.Zero)
                {
                    IntPtr clonedHandle;
                    Interop.WiFi.AP.Clone(out clonedHandle, apHandle);
                    WiFiAP apItem = new WiFiAP(clonedHandle);
                    apList.Add(apItem);
                    return true;
                }
                return false;
            };

            int ret = Interop.WiFi.GetForeachFoundAPs(GetHandle(), callback, IntPtr.Zero);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get all APs, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret);
            }

            return apList;
        }

        internal IEnumerable<WiFiAP> GetFoundSpecificAPs()
        {
            List<WiFiAP> apList = new List<WiFiAP>();
            Interop.WiFi.HandleCallback callback = (IntPtr apHandle, IntPtr userData) =>
            {
                if (apHandle != IntPtr.Zero)
                {
                    IntPtr clonedHandle;
                    Interop.WiFi.AP.Clone(out clonedHandle, apHandle);
                    WiFiAP apItem = new WiFiAP(clonedHandle);
                    apList.Add(apItem);
                    return true;
                }
                return false;

            };

            int ret = Interop.WiFi.GetForeachFoundSpecificAPs(GetHandle(), callback, IntPtr.Zero);
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

            int ret = Interop.WiFi.Config.GetForeachConfiguration(GetHandle(), callback, IntPtr.Zero);
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
            int ret = Interop.WiFi.Config.SaveConfiguration(GetHandle(), configHandle);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to save configuration, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret);
            }
        }

        internal WiFiAP GetConnectedAP()
        {
            IntPtr apHandle;

            int ret = Interop.WiFi.GetConnectedAP(GetHandle(), out apHandle);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to connect with AP, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret);
            }
            WiFiAP ap = new WiFiAP(apHandle);
            return ap;
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
            int ret = Interop.WiFi.Activate(GetHandle(), _callback_map[id], id);
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
            int ret = Interop.WiFi.ActivateWithWiFiPickerTested(GetHandle(), _callback_map[id], id);
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
            int ret = Interop.WiFi.Deactivate(GetHandle(), _callback_map[id], id);
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
            int ret = Interop.WiFi.Scan(GetHandle(), _callback_map[id], id);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to scan all AP, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret);
            }
            return task.Task;
        }

        internal Task ScanSpecificAPAsync(string essid)
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
            int ret = Interop.WiFi.ScanSpecificAP(GetHandle(), essid, _callback_map[id], id);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to scan with specific AP, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret);
            }
            return task.Task;
        }
    }
}
