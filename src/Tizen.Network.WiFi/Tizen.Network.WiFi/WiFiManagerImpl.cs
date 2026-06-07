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

namespace Tizen.Network.WiFi
{
    static internal class Globals
    {
        internal const string LogTag = "Tizen.Network.WiFi";
    }

    internal sealed class HandleHolder
    {
        private SafeWiFiManagerHandle _handle;

        internal HandleHolder()
        {
            int tid = Thread.CurrentThread.ManagedThreadId;
            Log.Info(Globals.LogTag, "PInvoke wifi_manager_initialize");
            int ret = Interop.WiFi.Initialize(tid, out _handle);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, $"Initialize Fail, Error - {(WiFiError)ret}");
                WiFiErrorFactory.ThrowWiFiException(ret, "http://tizen.org/privilege/network.get");
            }
            _handle.SetTID(tid);
            Log.Info(Globals.LogTag, $"Handle: {_handle}");
        }

        internal SafeWiFiManagerHandle GetSafeHandle()
        {
            Log.Debug(Globals.LogTag, $"Handleholder safehandle = {_handle}");
            return _handle;
        }
    }

    internal sealed partial class WiFiManagerImpl
    {
        private static WiFiManagerImpl s_instance = null;
        private static readonly object _lock = new object();

        private Dictionary<IntPtr, Interop.WiFi.VoidCallback> _callback_map =
            new Dictionary<IntPtr, Interop.WiFi.VoidCallback>();

        private int _requestId = 0;
        private string _macAddress;
        private string _tdlsMacAddress;
        private IntPtr _specificScanHandle;

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
                        Log.Error(Globals.LogTag, $"Failed to get mac address, Error - {(WiFiError)ret}");
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
                    Log.Error(Globals.LogTag, $"Failed to get interface name, Error - {(WiFiError)ret}");
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
                    Log.Error(Globals.LogTag, $"Failed to get connection state, Error - {(WiFiError)ret}");
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
                    Log.Error(Globals.LogTag, $"Failed to get isActive, Error - {(WiFiError)ret}");
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
                    Log.Error(Globals.LogTag, $"Failed to get scan state, Error - {(WiFiError)ret}");
                    return WiFiScanState.NotScanning;
                }
                return (WiFiScanState)state;
            }
        }

        internal static WiFiManagerImpl Instance
        {
            get
            {
                lock (_lock)
                {
                    if (s_instance == null)
                    {
                        s_instance = new WiFiManagerImpl();
                    }
                    Log.Info(Globals.LogTag, "WiFiManagerImpl.Instance");
                    return s_instance;
                }
            }
        }

        private HandleHolder _handleHolder;

        private WiFiManagerImpl()
        {
            Log.Info(Globals.LogTag, "WiFiManagerImpl constructor");
            _handleHolder = new HandleHolder();
            Log.Info(Globals.LogTag, "Success to get handle");
        }

        internal SafeWiFiManagerHandle GetSafeHandle()
        {
            return _handleHolder.GetSafeHandle();
        }


        // Shared "native foreach -> List<T>" collector for the GetFound*/
        // GetWiFiConfigurations methods. Each call site supplies only what
        // differs: the operation name and privilege (for CheckReturnValue),
        // the native foreach function, and how to wrap a native item handle
        // into its managed type.
        private List<T> EnumerateForeach<T>(string opName, string privilege,
            Func<SafeWiFiManagerHandle, Interop.WiFi.HandleCallback, IntPtr, int> nativeForeach,
            Func<IntPtr, T> wrap)
        {
            Log.Info(Globals.LogTag, opName);
            List<T> list = new List<T>();
            Interop.WiFi.HandleCallback callback = (IntPtr handle, IntPtr userData) =>
            {
                if (handle != IntPtr.Zero)
                {
                    list.Add(wrap(handle));
                    return true;
                }
                return false;
            };

            int ret = nativeForeach(GetSafeHandle(), callback, IntPtr.Zero);
            CheckReturnValue(ret, opName, privilege);
            return list;
        }

        internal IEnumerable<WiFiAP> GetFoundAPs() =>
            EnumerateForeach("GetForeachFoundAPs", PrivilegeNetworkGet,
                (wifi, cb, ud) => Interop.WiFi.GetForeachFoundAPs(wifi, cb, ud),
                apHandle =>
                {
                    Interop.WiFi.AP.Clone(out IntPtr clonedHandle, apHandle);
                    return new WiFiAP(clonedHandle);
                });

        internal IEnumerable<WiFiAP> GetFoundSpecificAPs() =>
            EnumerateForeach("GetForeachFoundSpecificAPs", PrivilegeNetworkGet,
                (wifi, cb, ud) => Interop.WiFi.GetForeachFoundSpecificAPs(wifi, cb, ud),
                apHandle =>
                {
                    Interop.WiFi.AP.Clone(out IntPtr clonedHandle, apHandle);
                    return new WiFiAP(clonedHandle);
                });

        internal IEnumerable<WiFiAP> GetFoundBssids() =>
            EnumerateForeach("GetForeachFoundBssids", PrivilegeNetworkGet,
                (wifi, cb, ud) => Interop.WiFi.GetForeachFoundBssids(wifi, cb, ud),
                apHandle =>
                {
                    Interop.WiFi.AP.Clone(out IntPtr clonedHandle, apHandle);
                    return new WiFiAP(clonedHandle);
                });

        internal IEnumerable<WiFiConfiguration> GetWiFiConfigurations() =>
            EnumerateForeach("GetForeachConfiguration", PrivilegeNetworkProfile,
                (wifi, cb, ud) => Interop.WiFi.Config.GetForeachConfiguration(wifi, cb, ud),
                configHandle =>
                {
                    Interop.WiFi.Config.Clone(configHandle, out IntPtr clonedConfig);
                    return new WiFiConfiguration(clonedConfig);
                });

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

        internal void RemoveWiFiNetworkConfiguration(WiFiConfiguration config)
        {
            Log.Debug(Globals.LogTag, "RemoveWiFiNetworkConfiguration");
            if (config == null)
            {
                throw new ArgumentNullException("WiFi configuraiton is null");
            }
            IntPtr configHandle = config.GetHandle();
            int ret = Interop.WiFi.Config.RemoveConfiguration(GetSafeHandle(), configHandle);
            CheckReturnValue(ret, "RemoveConfiguration", PrivilegeNetworkProfile);
        }

        internal WiFiAP GetConnectedAP()
        {
            Log.Info(Globals.LogTag, "GetConnectedAP");
            IntPtr apHandle;
            int ret = Interop.WiFi.GetConnectedAP(GetSafeHandle(), out apHandle);
            if (ret == (int)WiFiError.NoConnectionError)
            {
                Log.Error(Globals.LogTag, $"No connection {(WiFiError)ret}");
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
                        Log.Error(Globals.LogTag, $"Error occurs during WiFi activating, {(WiFiError)error}");
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
                Log.Error(Globals.LogTag, $"Exception on ActivateAsync\n{e}");
                task.SetException(e);
            }

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
                        Log.Error(Globals.LogTag, $"Error occurs during WiFi activating, {(WiFiError)error}");
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

            Log.Info(Globals.LogTag, "Interop.WiFi.ActivateWithWiFiPickerTestedAsync");
            try
            {
                int ret = (int)WiFiError.None;
                lock (_callback_map)
                {
                    ret = Interop.WiFi.ActivateWithWiFiPickerTested(GetSafeHandle(), _callback_map[id], id);
                }
                CheckReturnValue(ret, "ActivateWithWiFiPickerTested", "");
            }
            catch (Exception e)
            {
                Log.Error(Globals.LogTag, $"Exception on ActivateWithWiFiPickerTestedAsync\n{e}");
                task.SetException(e);
            }

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
                        Log.Error(Globals.LogTag, $"Error occurs during WiFi deactivating, {(WiFiError)error}");
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

            Log.Info(Globals.LogTag, "Interop.WiFi.Deactivate");
            try
            {
                int ret = (int)WiFiError.None;
                lock (_callback_map)
                {
                    ret = Interop.WiFi.Deactivate(GetSafeHandle(), _callback_map[id], id);
                }
                CheckReturnValue(ret, "Deactivate", "");
            }
            catch (Exception e)
            {
                Log.Error(Globals.LogTag, $"Exception on Deactivate\n{e}");
                task.SetException(e);
            }

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
                        Log.Error(Globals.LogTag, $"Error occurs during WiFi scanning, {(WiFiError)error}");
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

            Log.Info(Globals.LogTag, "Interop.WiFi.Scan");
            try
            {
                int ret = (int)WiFiError.None;
                lock (_callback_map)
                {
                    ret = Interop.WiFi.Scan(GetSafeHandle(), _callback_map[id], id);
                }
                CheckReturnValue(ret, "Scan", "");
            }
            catch (Exception e)
            {
                Log.Error(Globals.LogTag, $"Exception on Scan\n{e}");
                task.SetException(e);
            }

            return task.Task;
        }

        internal Task ScanSpecificAPAsync(string essid)
        {
            Log.Info(Globals.LogTag, $"ScanSpecificAPAsync {essid}");
            TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
            IntPtr id;
            lock (_callback_map)
            {
                id = (IntPtr)_requestId++;
                _callback_map[id] = (error, key) =>
                {
                    Log.Info(Globals.LogTag, $"ScanSpecificAPAsync Done {essid}");
                    if (error != (int)WiFiError.None)
                    {
                        Log.Error(Globals.LogTag, $"Error occurs during WiFi scanning, {(WiFiError)error}");
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

            Log.Info(Globals.LogTag, "Interop.WiFi.ScanSpecificAPAsync");
            try
            {
                int ret = (int)WiFiError.None;
                lock (_callback_map)
                {
                    ret = Interop.WiFi.ScanSpecificAP(GetSafeHandle(), essid, _callback_map[id], id);
                }
                CheckReturnValue(ret, "ScanSpecificAP", "");
            }
            catch (Exception e)
            {
                Log.Error(Globals.LogTag, $"Exception on ScanSpecificAPAsync\n{e}");
                task.SetException(e);
            }

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
                        Log.Error(Globals.LogTag, $"Error occurs during bssid scanning, {(WiFiError)error}");
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

            Log.Info(Globals.LogTag, "Interop.WiFi.BssidScan");
            try
            {
                int ret = (int)WiFiError.None;
                lock (_callback_map)
                {
                    ret = Interop.WiFi.BssidScan(GetSafeHandle(), _callback_map[id], id);
                }
                CheckReturnValue(ret, "BssidScan", "");
            }
            catch (Exception e)
            {
                Log.Error(Globals.LogTag, $"Exception on BssidScan\n{e}");
                task.SetException(e);
            }

            return task.Task;
        }

        internal void SetAutoScanMode(int scanMode)
        {
            Log.Info(Globals.LogTag, "SetAutoScanMode");
            int ret = Interop.WiFi.SetAutoScanMode(GetSafeHandle(), scanMode);
            CheckReturnValue(ret, "GetSafeHandle", PrivilegeNetworkGet);
        }

        internal Task HiddenAPConnectAsync(string essid, int secType, string passphrase)
        {
            Log.Info(Globals.LogTag, "HiddenAPConnect");
            TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
            IntPtr id;
            lock (_callback_map)
            {
                id = (IntPtr)_requestId++;
                _callback_map[id] = (error, key) =>
                {
                    Log.Info(Globals.LogTag, $"HiddenAPConnect Done {essid}");
                    if (error != (int)WiFiError.None)
                    {
                        Log.Error(Globals.LogTag, $"Error occurs during HiddenAPConnect, {(WiFiError)error}");
                        task.SetException(new InvalidOperationException("Error occurs during HiddenAPConnect, " + (WiFiError)error));
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

            Log.Info(Globals.LogTag, "Interop.WiFi.HiddenAPConnect");
            try
            {
                int ret = (int)WiFiError.None;
                lock (_callback_map)
                {
                    ret = Interop.WiFi.ConnectHiddenAP(GetSafeHandle(), essid, secType, passphrase, _callback_map[id], id);
                }
                CheckReturnValue(ret, "HiddenAPConnect", "");
            }
            catch (Exception e)
            {
                Log.Error(Globals.LogTag, $"Exception on HiddenAPConnect\n{e}");
                task.SetException(e);
            }

            return task.Task;
        }

        internal void CreateSpecificScanHandle()
        {
            Log.Debug(Globals.LogTag, "CreateSpecificScanHandle");
            int ret = Interop.WiFi.SpecificScanCreate(GetSafeHandle(), out _specificScanHandle);
            CheckReturnValue(ret, "CreateSpecificScanHandle", PrivilegeNetworkProfile);
        }

        internal void DestroySpecificScanHandle()
        {
            Log.Debug(Globals.LogTag, "DestroySpecificScanHandle");
            int ret = Interop.WiFi.SpecificScanDestroy(GetSafeHandle(), _specificScanHandle);
            CheckReturnValue(ret, "DestroySpecificScanHandle", PrivilegeNetworkProfile);
            _specificScanHandle = IntPtr.Zero;
        }

        internal void SetSpecificScanFreq(int freq)
        {
            Log.Debug(Globals.LogTag, "SetSpecificScanFreq");
            int ret = Interop.WiFi.SpecificScanSetFrequency(_specificScanHandle, freq);
            CheckReturnValue(ret, "SetSpecificScanFreq", PrivilegeNetworkProfile);
        }

        internal Task StartMultiScan()
        {
            Log.Debug(Globals.LogTag, "StartMultiScan");
            TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
            IntPtr id;
            lock (_callback_map)
            {
                id = (IntPtr)_requestId++;
                _callback_map[id] = (error, key) =>
                {
                    Log.Info(Globals.LogTag, "Multi Scan done");
                    if (error != (int)WiFiError.None)
                    {
                        Log.Error(Globals.LogTag, $"Error occurs during multi scanning, {(WiFiError)error}");
                        task.SetException(new InvalidOperationException("Error occurs during multi scanning, " + (WiFiError)error));
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

            Log.Info(Globals.LogTag, "Interop.WiFi.SpecificApStartMultiScan");
            try
            {
                int ret = (int)WiFiError.None;
                lock (_callback_map)
                {
                    ret = Interop.WiFi.SpecificApStartMultiScan(GetSafeHandle(), _specificScanHandle, _callback_map[id], id);
                }
                CheckReturnValue(ret, "MultiScan", "");
            }
            catch (Exception e)
            {
                Log.Error(Globals.LogTag, $"Exception on Multi Scan\n{e}");
                task.SetException(e);
            }

            return task.Task;
        }

        internal string TDLSConnectedPeer
        {
            get
            {
                IntPtr strPtr;
                int ret = Interop.WiFi.GetTdlsConnectedPeer(GetSafeHandle(), out strPtr);
                if (ret != (int)WiFiError.None)
                {
                    _tdlsMacAddress = "";
                    Log.Error(Globals.LogTag, $"Failed to get mac address, Error - {(WiFiError)ret}");
                }
                else
                {
                    _tdlsMacAddress = Marshal.PtrToStringAnsi(strPtr);
                    Marshal.FreeHGlobal(strPtr);
                }

                Log.Info(Globals.LogTag, $"Tdls Mac address: {_tdlsMacAddress}");
                return _tdlsMacAddress;
            }
        }

        private void CheckReturnValue(int ret, string method, string privilege)
        {
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, $"{method} Fail, Error - {(WiFiError)ret}");
                if (ret == (int)WiFiError.InvalidParameterError)
                {
                    throw new InvalidOperationException("Invalid handle");
                }
                WiFiErrorFactory.ThrowWiFiException(ret, GetSafeHandle().DangerousGetHandle(), privilege);
            }
        }
    }
}
