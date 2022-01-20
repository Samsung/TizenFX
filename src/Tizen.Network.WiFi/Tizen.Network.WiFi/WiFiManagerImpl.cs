/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Runtime.InteropServices;
using Tizen.Applications;

namespace Tizen.Network.WiFi
{
    static internal class Globals
    {
        internal const string LogTag = "Tizen.Network.WiFi";
    }

    internal class HandleHolder
    {
        private SafeWiFiManagerHandle _handle;

        internal HandleHolder()
        {
            _handle = WiFiManagerImpl.Instance.Initialize();
            Log.Info(Globals.LogTag, "Handle: " + _handle);
        }

        internal SafeWiFiManagerHandle GetSafeHandle()
        {
            Log.Debug(Globals.LogTag, "Handleholder safehandle = " + _handle);
            return _handle;
        }
    }

    internal partial class WiFiManagerImpl
    {
        private static readonly Lazy<WiFiManagerImpl> _instance =
            new Lazy<WiFiManagerImpl>(() => new WiFiManagerImpl());

        private TizenSynchronizationContext context = new TizenSynchronizationContext();
        
        private Dictionary<IntPtr, Interop.WiFi.VoidCallback> _callback_map =
            new Dictionary<IntPtr, Interop.WiFi.VoidCallback>();
        
        private int _requestId = 0;
        private string _macAddress;

        //private string PrivilegeNetworkSet = "http://tizen.org/privilege/network.set";
        private string PrivilegeNetworkGet = "http://tizen.org/privilege/network.get";
        private string PrivilegeNetworkProfile = "http://tizen.org/privilege/network.get";

        internal string MacAddress
        {
            get
            {
                if (String.IsNullOrEmpty(_macAddress))
                {
                    string address;
                    int ret = Interop.WiFi.GetMacAddress(GetSafeHandle(), out address);
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
                int ret = Interop.WiFi.GetNetworkInterfaceName(GetSafeHandle(), out name);
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
                int ret = Interop.WiFi.GetConnectionState(GetSafeHandle(), out state);
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
                int ret = Interop.WiFi.IsActive(GetSafeHandle(), out active);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get isActive, Error - " + (WiFiError)ret);
                }
                return active;
            }
        }

        internal WiFiScanState ScanState
        {
            get
            {
                int state;
                int ret = Interop.WiFi.GetScanState(GetSafeHandle(), out state);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get scan state, Error - " + (WiFiError)ret);
                    return WiFiScanState.NotScanning;
                }
                return (WiFiScanState)state;
            }
        }

        internal static WiFiManagerImpl Instance
        {
            get
            {
               return _instance.Value;
            }
        }

        private static ThreadLocal<HandleHolder> s_threadName = new ThreadLocal<HandleHolder>(() =>
        {
            Log.Info(Globals.LogTag, "In threadlocal delegate");
            return new HandleHolder();
        });

        private WiFiManagerImpl()
        {
            Log.Info(Globals.LogTag, "WiFiManagerImpl constructor");
        }

        internal SafeWiFiManagerHandle GetSafeHandle()
        {
            return s_threadName.Value.GetSafeHandle();
        }

        internal SafeWiFiManagerHandle Initialize()
        {
            SafeWiFiManagerHandle handle;
            int tid = Thread.CurrentThread.ManagedThreadId;
            Log.Info(Globals.LogTag, "PInvoke wifi_manager_initialize");
            int ret = Interop.WiFi.Initialize(tid, out handle);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Initialize Fail, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret, PrivilegeNetworkGet);
            }
            handle.SetTID(tid);
            return handle;
        }

        internal IEnumerable<WiFiAP> GetFoundAPs()
        {
            Log.Info(Globals.LogTag, "GetFoundAPs");
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

            int ret = Interop.WiFi.GetForeachFoundAPs(GetSafeHandle(), callback, IntPtr.Zero);
            CheckReturnValue(ret, "GetForeachFoundAPs", PrivilegeNetworkGet);

            return apList;
        }

        internal IEnumerable<WiFiAP> GetFoundSpecificAPs()
        {
            Log.Info(Globals.LogTag, "GetFoundSpecificAPs");
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

            int ret = Interop.WiFi.GetForeachFoundSpecificAPs(GetSafeHandle(), callback, IntPtr.Zero);
            CheckReturnValue(ret, "GetForeachFoundSpecificAPs", PrivilegeNetworkGet);
            
            return apList;
        }

        internal IEnumerable<WiFiAP> GetFoundBssids()
        {
            Log.Info(Globals.LogTag, "GetFoundBssids");
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

            int ret = Interop.WiFi.GetForeachFoundBssids(GetSafeHandle(), callback, IntPtr.Zero);
            CheckReturnValue(ret, "GetForeachFoundBssids", PrivilegeNetworkGet);

            return apList;
        }

        internal IEnumerable<WiFiConfiguration> GetWiFiConfigurations()
        {
            Log.Debug(Globals.LogTag, "GetWiFiConfigurations");
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

            int ret = Interop.WiFi.Config.GetForeachConfiguration(GetSafeHandle(), callback, IntPtr.Zero);
            CheckReturnValue(ret, "GetForeachConfiguration", PrivilegeNetworkProfile);
            return configList;
        }

        internal void SaveWiFiNetworkConfiguration(WiFiConfiguration config)
        {
            Log.Debug(Globals.LogTag, "SaveWiFiNetworkConfiguration");
            if (config == null)
            {
                throw new ArgumentNullException("WiFi configuration is null");
            }

            IntPtr configHandle = config.GetHandle();
            int ret = Interop.WiFi.Config.SaveConfiguration(GetSafeHandle(), configHandle);
            CheckReturnValue(ret, "SaveConfiguration", PrivilegeNetworkProfile);
       }

        internal WiFiAP GetConnectedAP()
        {
            Log.Info(Globals.LogTag, "GetConnectedAP");
            IntPtr apHandle;
            int ret = Interop.WiFi.GetConnectedAP(GetSafeHandle(), out apHandle);
            if (ret == (int)WiFiError.NoConnectionError)
            {
                Log.Error(Globals.LogTag, "No connection " + (WiFiError)ret);
                return null;
            }
            CheckReturnValue(ret, "GetConnectedAP", PrivilegeNetworkGet);
            WiFiAP ap = new WiFiAP(apHandle);
            return ap;
        }

        internal Task ActivateAsync()
        {
            Log.Info(Globals.LogTag, "ActivateAsync");
            TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
            IntPtr id;
            lock (_callback_map)
            {
                id = (IntPtr)_requestId++;
                _callback_map[id] = (error, key) =>
                {
                    Log.Info(Globals.LogTag, "ActivateAsync done");
                    if (error != (int)WiFiError.None)
                    {
                        Log.Error(Globals.LogTag, "Error occurs during WiFi activating, " + (WiFiError)error);
                        task.SetException(WiFiErrorFactory.GetException(error, "Error occurs during WiFi activating"));
                    }
                    else
                    {
                        task.SetResult(true);
                    }
                    lock (_callback_map)
                    {
                        _callback_map.Remove(key);
                    }
                };
            }

            context.Post((x) =>
            {
                Log.Info(Globals.LogTag, "Interop.WiFi.ActivateAsync");
                try
                {
                    int ret = (int)WiFiError.None;
                    lock (_callback_map)
                    {
                        ret = Interop.WiFi.Activate(GetSafeHandle(), _callback_map[id], id);
                    }
                    CheckReturnValue(ret, "Activate", "");
                }
                catch (Exception e)
                {
                    Log.Error(Globals.LogTag, "Exception on ActivateAsync\n" + e);
                    task.SetException(e);
                }
            }, null);

            return task.Task;
        }

        internal Task ActivateWithWiFiPickerTestedAsync()
        {
            Log.Info(Globals.LogTag, "ActivateWithWiFiPickerTestedAsync");
            TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
            IntPtr id;
            lock (_callback_map)
            {
                id = (IntPtr)_requestId++;
                _callback_map[id] = (error, key) =>
                {
                    Log.Info(Globals.LogTag, "ActivateWithWiFiPickerTestedAsync done");
                    if (error != (int)WiFiError.None)
                    {
                        Log.Error(Globals.LogTag, "Error occurs during WiFi activating, " + (WiFiError)error);
                        task.SetException(WiFiErrorFactory.GetException(error, "Error occurs during WiFi activating"));
                    }
                    else
                    {
                        task.SetResult(true);
                    }
                    lock (_callback_map)
                    {
                        _callback_map.Remove(key);
                    }
                };
            }

            context.Post((x) =>
            {
                Log.Info(Globals.LogTag, "Interop.WiFi.ActivateWithWiFiPickerTestedAsync");
                try
                {
                    int ret = Interop.WiFi.ActivateWithWiFiPickerTested(GetSafeHandle(), _callback_map[id], id);
                    CheckReturnValue(ret, "ActivateWithWiFiPickerTested", "");
                }
                catch (Exception e)
                {
                    Log.Error(Globals.LogTag, "Exception on ActivateWithWiFiPickerTestedAsync\n" + e);
                    task.SetException(e);
                }
            }, null);
            
            return task.Task;
        }

        internal Task DeactivateAsync()
        {
            Log.Info(Globals.LogTag, "DeactivateAsync");
            TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
            IntPtr id;
            lock (_callback_map)
            {
                id = (IntPtr)_requestId++;
                _callback_map[id] = (error, key) =>
                {
                    Log.Info(Globals.LogTag, "DeactivateAsync done");
                    if (error != (int)WiFiError.None)
                    {
                        Log.Error(Globals.LogTag, "Error occurs during WiFi deactivating, " + (WiFiError)error);
                        task.SetException(WiFiErrorFactory.GetException(error, "Error occurs during WiFi deactivating"));
                    }
                    else
                    {
                        task.SetResult(true);
                    }
                    lock (_callback_map)
                    {
                        _callback_map.Remove(key);
                    }
                };
            }

            context.Post((x) =>
            {
                Log.Info(Globals.LogTag, "Interop.WiFi.Deactivate");
                try
                {
                    int ret = Interop.WiFi.Deactivate(GetSafeHandle(), _callback_map[id], id);
                    CheckReturnValue(ret, "Deactivate", "");
                }
                catch (Exception e)
                {
                    Log.Error(Globals.LogTag, "Exception on Deactivate\n" + e);
                    task.SetException(e);
                }
            }, null);

            return task.Task;           
        }

        internal Task ScanAsync()
        {
            Log.Info(Globals.LogTag, "ScanAsync");
            TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
            IntPtr id;
            lock (_callback_map)
            {
                id = (IntPtr)_requestId++;
                _callback_map[id] = (error, key) =>
                {
                    Log.Info(Globals.LogTag, "ScanAsync done");
                    if (error != (int)WiFiError.None)
                    {
                        Log.Error(Globals.LogTag, "Error occurs during WiFi scanning, " + (WiFiError)error);
                        task.SetException(new InvalidOperationException("Error occurs during WiFi scanning, " + (WiFiError)error));
                    }
                    else
                    {
                        task.SetResult(true);
                    }
                    lock (_callback_map)
                    {
                        _callback_map.Remove(key);
                    }
                };
            }

            context.Post((x) =>
            {
                Log.Info(Globals.LogTag, "Interop.WiFi.Scan");
                try
                {
                    int ret = Interop.WiFi.Scan(GetSafeHandle(), _callback_map[id], id);
                    CheckReturnValue(ret, "Scan", "");
                }
                catch (Exception e)
                {
                    Log.Error(Globals.LogTag, "Exception on Scan\n" + e);
                    task.SetException(e);
                }
            }, null);

            return task.Task;
        }

        internal Task ScanSpecificAPAsync(string essid)
        {
            Log.Info(Globals.LogTag, "ScanSpecificAPAsync " + essid);
            TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
            IntPtr id;
            lock (_callback_map)
            {
                id = (IntPtr)_requestId++;
                _callback_map[id] = (error, key) =>
                {
                    Log.Info(Globals.LogTag, "ScanSpecificAPAsync Done " + essid);
                    if (error != (int)WiFiError.None)
                    {
                        Log.Error(Globals.LogTag, "Error occurs during WiFi scanning, " + (WiFiError)error);
                        task.SetException(new InvalidOperationException("Error occurs during WiFi scanning, " + (WiFiError)error));
                    }
                    else
                    {
                        task.SetResult(true);
                    }
                    lock (_callback_map)
                    {
                        _callback_map.Remove(key);
                    }
                };
            }

            context.Post((x) =>
            {
                Log.Info(Globals.LogTag, "Interop.WiFi.ScanSpecificAPAsync");
                try
                {
                    int ret = Interop.WiFi.ScanSpecificAP(GetSafeHandle(), essid, _callback_map[id], id);
                    CheckReturnValue(ret, "ScanSpecificAP", "");
                }
                catch (Exception e)
                {
                    Log.Error(Globals.LogTag, "Exception on ScanSpecificAPAsync\n" + e);
                    task.SetException(e);
                }
            }, null);

            return task.Task;
        }

        internal Task BssidScanAsync()
        {
            Log.Info(Globals.LogTag, "BssidScanAsync");
            TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
            IntPtr id;
            lock (_callback_map)
            {
                id = (IntPtr)_requestId++;
                _callback_map[id] = (error, key) =>
                {
                    Log.Info(Globals.LogTag, "BssidScanAsync done");
                    if (error != (int)WiFiError.None)
                    {
                        Log.Error(Globals.LogTag, "Error occurs during bssid scanning, " + (WiFiError)error);
                        task.SetException(new InvalidOperationException("Error occurs during bssid scanning, " + (WiFiError)error));
                    }
                    else
                    {
                        task.SetResult(true);
                    }
                    lock (_callback_map)
                    {
                        _callback_map.Remove(key);
                    }
                };
            }

            context.Post((x) =>
            {
                Log.Info(Globals.LogTag, "Interop.WiFi.BssidScan");
                try
                {
                    int ret = Interop.WiFi.BssidScan(GetSafeHandle(), _callback_map[id], id);
                    CheckReturnValue(ret, "BssidScan", "");
                }
                catch (Exception e)
                {
                    Log.Error(Globals.LogTag, "Exception on BssidScan\n" + e);
                    task.SetException(e);
                }
            }, null);

            return task.Task;
        }

        private void CheckReturnValue(int ret, string method, string privilege)
        {
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, method + " Fail, Error - " + (WiFiError)ret);
                if (ret == (int)WiFiError.InvalidParameterError)
                {
                    throw new InvalidOperationException("Invalid handle");
                }
                WiFiErrorFactory.ThrowWiFiException(ret, GetSafeHandle().DangerousGetHandle(), privilege);
            }
        }
    }
}
