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
using System.Collections.Generic;

namespace Tizen.Network.WiFi
{
    /// <summary>
    /// A class for managing the network information of the access point(AP).
    /// </summary>
    public class WiFiAP : IDisposable
    {
        private IntPtr _apHandle = IntPtr.Zero;
        private Dictionary<IntPtr, Interop.WiFi.VoidCallback> _callback_map = new Dictionary<IntPtr, Interop.WiFi.VoidCallback>();
        private static Dictionary<IntPtr, Interop.WiFi.VoidCallback> s_callbackMap = new Dictionary<IntPtr, Interop.WiFi.VoidCallback>();
        private int _requestId = 0;
        private static int s_requestId = 0;
        private WiFiNetwork _network;
        private WiFiSecurity _security;
        private bool _disposed = false;

        /// <summary>
        /// The network information of the access point(AP).
        /// </summary>
        public WiFiNetwork NetworkInformation
        {
            get
            {
                return _network;
            }
        }

        /// <summary>
        /// The security information of the access point(AP).
        /// </summary>
        public WiFiSecurity SecurityInformation
        {
            get
            {
                return _security;
            }
        }

        internal WiFiAP(IntPtr handle)
        {
            Log.Debug(Globals.LogTag, "New WiFiAP. Handle: " + handle);
            _apHandle = handle;
            Initialize();
        }

        /// <summary>
        /// Creates an object for the access point.
        /// </summary>
        /// <param name="essid">The Extended Service Set Identifier of the access point.</param>
        public WiFiAP(string essid)
        {
            Log.Debug(Globals.LogTag, "New WiFiAP. Essid: " + essid);
            createHandle(essid, true);
            Initialize();
        }

        /// <summary>
        /// Creates an object for the hidden access point.
        /// </summary>
        /// <param name="essid">The Extended Service Set Identifier of the access point.</param>
        /// <param name="hidden">The value to set hidden AP</param>
        public WiFiAP(string essid, bool hidden)
        {
            createHandle(essid, hidden);
            Initialize();
        }

        ~WiFiAP()
        {
            Dispose(false);
        }

        /// <summary>
        /// A method to destroy the managed WiFiAP objects.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                Interop.WiFi.AP.Destroy(_apHandle);
                _apHandle = IntPtr.Zero;
            }
            _disposed = true;
        }

        private void createHandle(string id, bool hidden)
        {
            int ret = -1;
            if (hidden)
            {
                ret = Interop.WiFi.AP.CreateHiddenAP(WiFiManagerImpl.Instance.GetSafeHandle(), id, out _apHandle);
            }

            else
            {
                ret = Interop.WiFi.AP.Create(WiFiManagerImpl.Instance.GetSafeHandle(), id, out _apHandle);
            }

            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to create handle, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret);
            }
        }

        private void Initialize()
        {
            Interop.WiFi.SafeWiFiAPHandle apHandle = new Interop.WiFi.SafeWiFiAPHandle(_apHandle);
            _network = new WiFiNetwork(apHandle);
            _security = new WiFiSecurity(apHandle);
        }

        /// <summary>
        /// Refreshes the access point information.
        /// </summary>
        public void Refresh()
        {
            Log.Debug(Globals.LogTag, "Refresh");
            int ret = Interop.WiFi.AP.Refresh(_apHandle);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to refresh ap handle, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret, _apHandle);
            }
        }

        /// <summary>
        /// Connects the access point asynchronously.
        /// </summary>
        /// <returns> A task indicating whether the Connect method is done or not.</returns>
        public Task ConnectAsync()
        {
            Log.Debug(Globals.LogTag, "ConnectAsync");
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
            int ret = Interop.WiFi.Connect(WiFiManagerImpl.Instance.GetSafeHandle(), _apHandle, _callback_map[id], id);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to connect wifi, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret);
            }
            return task.Task;
        }

        /// <summary>
        /// Connects the access point with WPS asynchronously.
        /// </summary>
        /// <param name="info">A WpsInfo instance which is of type WpsPbcInfo or WpsPinInfo.</param>
        /// <returns>A task indicating whether the ConnectWps method is done or not.</returns>
        public Task ConnectWpsAsync(WpsInfo info)
        {
            Log.Debug(Globals.LogTag, "ConnectWpsAsync");
            TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
            IntPtr id;
            lock (_callback_map)
            {
                id = (IntPtr)_requestId++;
                _callback_map[id] = (error, key) =>
                {
                    Log.Debug(Globals.LogTag, "Connecting by WPS finished");
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

            if (info.GetType() == typeof(WpsPbcInfo))
            {
                int ret = Interop.WiFi.ConnectByWpsPbc(WiFiManagerImpl.Instance.GetSafeHandle(), _apHandle, _callback_map[id], id);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to connect wifi, Error - " + (WiFiError)ret);
                    WiFiErrorFactory.ThrowWiFiException(ret);
                }
            }

            else if (info.GetType() == typeof(WpsPinInfo))
            {
                WpsPinInfo pinInfo = (WpsPinInfo)info;
                int ret = Interop.WiFi.ConnectByWpsPin(WiFiManagerImpl.Instance.GetSafeHandle(), _apHandle, pinInfo.GetWpsPin(), _callback_map[id], id);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to connect wifi, Error - " + (WiFiError)ret);
                    WiFiErrorFactory.ThrowWiFiException(ret);
                }
            }

            return task.Task;
        }

        /// <summary>
        /// Connects the access point with WPS without ssid asynchronously.
        /// </summary>
        /// <param name="info">A WpsInfo instance which is of type WpsPbcInfo or WpsPinInfo.</param>
        /// <returns>A task which contains Connected access point information.</returns>
        public static Task<WiFiAP> ConnectWpsWithoutSsidAsync(WpsInfo info)
        {
            TaskCompletionSource<WiFiAP> task = new TaskCompletionSource<WiFiAP>();
            IntPtr id;
            lock (s_callbackMap)
            {
                id = (IntPtr)s_requestId++;
                s_callbackMap[id] = (error, key) =>
                {
                    Log.Debug(Globals.LogTag, "Connecting by WPS finished");
                    if (error != (int)WiFiError.None)
                    {
                        Log.Error(Globals.LogTag, "Error occurs during WiFi connecting, " + (WiFiError)error);
                        task.SetException(new InvalidOperationException("Error occurs during WiFi connecting, " + (WiFiError)error));
                    }
                    WiFiAP ap = WiFiManagerImpl.Instance.GetConnectedAP();
                    task.SetResult(ap);
                    lock (s_callbackMap)
                    {
                        s_callbackMap.Remove(key);
                    }
                };
            }

            if (info.GetType() == typeof(WpsPbcInfo))
            {
                int ret = Interop.WiFi.ConnectByWpsPbcWithoutSsid(WiFiManagerImpl.Instance.GetSafeHandle(), s_callbackMap[id], id);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to connect wifi, Error - " + (WiFiError)ret);
                    WiFiErrorFactory.ThrowWiFiException(ret);
                }
            }

            else if (info.GetType() == typeof(WpsPinInfo))
            {
                WpsPinInfo pinInfo = (WpsPinInfo)info;
                int ret = Interop.WiFi.ConnectByWpsPinWithoutSsid(WiFiManagerImpl.Instance.GetSafeHandle(), pinInfo.GetWpsPin(), s_callbackMap[id], id);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to connect wifi, Error - " + (WiFiError)ret);
                    WiFiErrorFactory.ThrowWiFiException(ret);
                }
            }

            return task.Task;
        }

        /// <summary>
        /// Disconnects the access point asynchronously.
        /// </summary>
        /// <returns> A task indicating whether the Disconnect method is done or not.</returns>
        public Task DisconnectAsync()
        {
            Log.Debug(Globals.LogTag, "DisconnectAsync");
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
            int ret = Interop.WiFi.Disconnect(WiFiManagerImpl.Instance.GetSafeHandle(), _apHandle, _callback_map[id], id);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to disconnect wifi, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret);
            }
            return task.Task;
        }

        /// <summary>
        /// Deletes the information of stored access point and disconnects it when it is connected.<br>
        /// If an AP is connected, then connection information will be stored. This information is used when a connection to that AP is established automatically.
        /// </summary>
        public void ForgetAP()
        {
            Log.Debug(Globals.LogTag, "ForgetAP");
            int ret = Interop.WiFi.RemoveAP(WiFiManagerImpl.Instance.GetSafeHandle(), _apHandle);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to forget AP, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret);
            }
        }
    }

    /// <summary>
    /// An abstract class which is used to represent WPS information of access point.
    /// </summary>
    public abstract class WpsInfo
    {
    }

    /// <summary>
    /// A class which is used to represent WPS PBC information of access point.
    /// </summary>
    public class WpsPbcInfo : WpsInfo
    {
    }

    /// <summary>
    /// A class which is used to represent WPS PIN information of access point.
    /// </summary>
    public class WpsPinInfo : WpsInfo
    {
        private string _pin;

        private WpsPinInfo()
        {
        }

        /// <summary>
        /// A public constructor which instantiates WpsPinInfo class with the given pin.
        /// </summary>
        /// <param name="pin">WPS Pin of the access point.</param>
        public WpsPinInfo(string pin)
        {
            _pin = pin;
        }

        internal string GetWpsPin()
        {
            return _pin;
        }
    }
}
