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

        // Shared boilerplate for the one-shot, callback-completed native async
        // operations on this manager (Activate/Deactivate/Scan/...). Each call
        // site supplies only the parts that actually differ: the operation name
        // (used for logging and CheckReturnValue), the native interop call, and
        // the factory that maps a non-zero error code to an exception.
        private Task RunOneShotAsync(string opName, Func<Interop.WiFi.VoidCallback, IntPtr, int> nativeCall, Func<int, Exception> exceptionFactory)
        {
            Log.Info(Globals.LogTag, opName);
            TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
            IntPtr id;
            lock (_callback_map)
            {
                id = (IntPtr)_requestId++;
                _callback_map[id] = (error, key) =>
                {
                    Log.Info(Globals.LogTag, $"{opName} done");
                    if (error != (int)WiFiError.None)
                    {
                        Log.Error(Globals.LogTag, $"Error occurs during {opName}, {(WiFiError)error}");
                        task.SetException(exceptionFactory(error));
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

            try
            {
                int ret = (int)WiFiError.None;
                lock (_callback_map)
                {
                    ret = nativeCall(_callback_map[id], id);
                }
                CheckReturnValue(ret, opName, "");
            }
            catch (Exception e)
            {
                Log.Error(Globals.LogTag, $"Exception on {opName}\n{e}");
                task.SetException(e);
            }

            return task.Task;
        }

        internal Task ActivateAsync() =>
            RunOneShotAsync("Activate",
                (cb, id) => Interop.WiFi.Activate(GetSafeHandle(), cb, id),
                error => WiFiErrorFactory.GetException(error, "Error occurs during WiFi activating"));

        internal Task ActivateWithWiFiPickerTestedAsync() =>
            RunOneShotAsync("ActivateWithWiFiPickerTested",
                (cb, id) => Interop.WiFi.ActivateWithWiFiPickerTested(GetSafeHandle(), cb, id),
                error => WiFiErrorFactory.GetException(error, "Error occurs during WiFi activating"));

        internal Task DeactivateAsync() =>
            RunOneShotAsync("Deactivate",
                (cb, id) => Interop.WiFi.Deactivate(GetSafeHandle(), cb, id),
                error => WiFiErrorFactory.GetException(error, "Error occurs during WiFi deactivating"));

        internal Task ScanAsync() =>
            RunOneShotAsync("Scan",
                (cb, id) => Interop.WiFi.Scan(GetSafeHandle(), cb, id),
                error => new InvalidOperationException("Error occurs during WiFi scanning, " + (WiFiError)error));

        internal Task ScanSpecificAPAsync(string essid) =>
            RunOneShotAsync("ScanSpecificAP",
                (cb, id) => Interop.WiFi.ScanSpecificAP(GetSafeHandle(), essid, cb, id),
                error => new InvalidOperationException("Error occurs during WiFi scanning, " + (WiFiError)error));

        internal Task BssidScanAsync() =>
            RunOneShotAsync("BssidScan",
                (cb, id) => Interop.WiFi.BssidScan(GetSafeHandle(), cb, id),
                error => new InvalidOperationException("Error occurs during bssid scanning, " + (WiFiError)error));

        internal void SetAutoScanMode(int scanMode)
        {
            Log.Info(Globals.LogTag, "SetAutoScanMode");
            int ret = Interop.WiFi.SetAutoScanMode(GetSafeHandle(), scanMode);
            CheckReturnValue(ret, "GetSafeHandle", PrivilegeNetworkGet);
        }

        internal Task HiddenAPConnectAsync(string essid, int secType, string passphrase) =>
            RunOneShotAsync("HiddenAPConnect",
                (cb, id) => Interop.WiFi.ConnectHiddenAP(GetSafeHandle(), essid, secType, passphrase, cb, id),
                error => new InvalidOperationException("Error occurs during HiddenAPConnect, " + (WiFiError)error));

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

        internal Task StartMultiScan() =>
            RunOneShotAsync("MultiScan",
                (cb, id) => Interop.WiFi.SpecificApStartMultiScan(GetSafeHandle(), _specificScanHandle, cb, id),
                error => new InvalidOperationException("Error occurs during multi scanning, " + (WiFiError)error));

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
