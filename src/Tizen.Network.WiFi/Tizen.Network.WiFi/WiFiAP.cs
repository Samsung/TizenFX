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
    /// A class for managing the network information of the access point (AP).
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
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
        /// The network information of the access point (AP).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The WiFiNetwork instance containing the network information of the AP.</value>
        public WiFiNetwork NetworkInformation
        {
            get
            {
                return _network;
            }
        }

        /// <summary>
        /// The security information of the access point (AP).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The WiFiSecurity instance containing security information of the AP.</value>
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
        /// <since_tizen> 3 </since_tizen>
        /// <param name="essid">The Extended Service Set Identifier of the access point.</param>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <exception cref="NotSupportedException">Thrown when the Wi-Fi is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when permission is denied.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the ESSID is passed as null.</exception>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when the system is out of memory.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        public WiFiAP(string essid)
        {
            Log.Debug(Globals.LogTag, "New WiFiAP. Essid: " + essid);
            createHandle(essid, true);
            Initialize();
        }

        /// <summary>
        /// Creates an object for the hidden access point.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="essid">The Extended Service Set Identifier of the access point.</param>
        /// <param name="hidden">The value to set a hidden AP.</param>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <exception cref="NotSupportedException">Thrown when the Wi-Fi is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when permission is denied.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the ESSID is passed as null.</exception>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when the system is out of memory.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        public WiFiAP(string essid, bool hidden)
        {
            createHandle(essid, hidden);
            Initialize();
        }

        /// <summary>
        /// Destroy the WiFiAP object
        /// </summary>
        ~WiFiAP()
        {
            Dispose(false);
        }

        /// <summary>
        /// A method to destroy the managed WiFiAP objects.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
            if (id == null)
            {
                throw new ArgumentNullException("Essid is null");
            }

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
                WiFiErrorFactory.ThrowWiFiException(ret, WiFiManagerImpl.Instance.GetSafeHandle().DangerousGetHandle());
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
        /// <since_tizen> 3 </since_tizen>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <exception cref="NotSupportedException">Thrown when the Wi-Fi is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when permission is denied.</exception>
        /// <exception cref="ObjectDisposedException">Thrown when the object instance is disposed or released.</exception>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        public void Refresh()
        {
            Log.Debug(Globals.LogTag, "Refresh");
            if (_disposed)
            {
                throw new ObjectDisposedException("Invalid AP instance (Object may have been disposed or released)");
            }
            int ret = Interop.WiFi.AP.Refresh(_apHandle);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to refresh ap handle, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret, _apHandle, "http://tizen.org/privilege/network.get");
            }
        }

        /// <summary>
        /// Connects the access point asynchronously.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns> A task indicating whether the connect method is done or not.</returns>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
        /// <privilege>http://tizen.org/privilege/network.set</privilege>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <exception cref="NotSupportedException">Thrown when the Wi-Fi is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when permission is denied.</exception>
        /// <exception cref="ObjectDisposedException">Thrown when the object instance is disposed or released.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when the system is out of memory.</exception>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        public Task ConnectAsync()
        {
            Log.Debug(Globals.LogTag, "ConnectAsync");
            if (_disposed)
            {
                throw new ObjectDisposedException("Invalid AP instance (Object may have been disposed or released)");
            }
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

            int ret = Interop.WiFi.Connect(WiFiManagerImpl.Instance.GetSafeHandle(), _apHandle, _callback_map[id], id);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to connect wifi, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret, WiFiManagerImpl.Instance.GetSafeHandle().DangerousGetHandle(), _apHandle);
            }

            return task.Task;
        }

        /// <summary>
        /// Connects the access point with the WPS asynchronously.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="info">A WpsInfo instance which is type of WpsPbcInfo or WpsPinInfo.</param>
        /// <returns>A task indicating whether the ConnectWps method is done or not.</returns>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
        /// <privilege>http://tizen.org/privilege/network.profile</privilege>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <exception cref="NotSupportedException">Thrown when the Wi-Fi is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when permission is denied.</exception>
        /// <exception cref="ObjectDisposedException">Thrown when the object instance is disposed or released.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the WpsPinInfo object is constructed with a null pin.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the WpsPinInfo object is constructed with a pin which is an empty string or more than 7 characters.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when the system is out of memory.</exception>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        public Task ConnectWpsAsync(WpsInfo info)
        {
            Log.Debug(Globals.LogTag, "ConnectWpsAsync");
            if (_disposed)
            {
                throw new ObjectDisposedException("Invalid AP instance (Object may have been disposed or released)");
            }
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

            int ret = -1;
            if (info.GetType() == typeof(WpsPbcInfo))
            {
                ret = Interop.WiFi.ConnectByWpsPbc(WiFiManagerImpl.Instance.GetSafeHandle(), _apHandle, _callback_map[id], id);
            }

            else if (info.GetType() == typeof(WpsPinInfo))
            {
                WpsPinInfo pinInfo = (WpsPinInfo)info;
                if (pinInfo.GetWpsPin() == null)
                {
                    throw new ArgumentNullException("Wps pin should not be null");
                }

                if (pinInfo.GetWpsPin().Length == 0 || pinInfo.GetWpsPin().Length > 8)
                {
                    throw new ArgumentOutOfRangeException("Wps pin should not be empty or more than 7 characters");
                }

                ret = Interop.WiFi.ConnectByWpsPin(WiFiManagerImpl.Instance.GetSafeHandle(), _apHandle, pinInfo.GetWpsPin(), _callback_map[id], id);
            }

            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to connect wifi, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret, WiFiManagerImpl.Instance.GetSafeHandle().DangerousGetHandle(), _apHandle);
            }

            return task.Task;
        }

        /// <summary>
        /// Connects the access point with WPS without SSID asynchronously.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="info">A WpsInfo instance which is of type WpsPbcInfo or WpsPinInfo.</param>
        /// <returns>A task which contains Connected access point information.</returns>
        /// <remarks>
        /// If WpsPinInfo is used, its object has to be constructed with a pin which must be 4 or 8 characters long.
        /// </remarks>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
        /// <privilege>http://tizen.org/privilege/network.set</privilege>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <privilege>http://tizen.org/privilege/network.profile</privilege>
        /// <exception cref="NotSupportedException">Thrown when the Wi-Fi is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when permission is denied.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the WpsPinInfo object is constructed with a null pin.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the WpsPinInfo object is constructed with a pin which is not of 4 or 8 characters long.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when the system is out of memory.</exception>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
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
                    else
                    {
                        WiFiAP ap = WiFiManagerImpl.Instance.GetConnectedAP();
                        task.SetResult(ap);
                    }
                    lock (s_callbackMap)
                    {
                        s_callbackMap.Remove(key);
                    }
                };
            }

            int ret = -1;
            if (info.GetType() == typeof(WpsPbcInfo))
            {
                ret = Interop.WiFi.ConnectByWpsPbcWithoutSsid(WiFiManagerImpl.Instance.GetSafeHandle(), s_callbackMap[id], id);   
            }

            else if (info.GetType() == typeof(WpsPinInfo))
            {
                WpsPinInfo pinInfo = (WpsPinInfo)info;
                if (pinInfo.GetWpsPin() == null)
                {
                    throw new ArgumentNullException("Wps pin should not be null");
                }

                if (pinInfo.GetWpsPin().Length != 4 && pinInfo.GetWpsPin().Length != 8)
                {
                    throw new ArgumentOutOfRangeException("Wps pin should be of 4 or 8 characters long");
                }

                ret = Interop.WiFi.ConnectByWpsPinWithoutSsid(WiFiManagerImpl.Instance.GetSafeHandle(), pinInfo.GetWpsPin(), s_callbackMap[id], id);
            }

            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to connect wifi, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret, WiFiManagerImpl.Instance.GetSafeHandle().DangerousGetHandle());
            }

            return task.Task;
        }

        /// <summary>
        /// Disconnects the access point asynchronously.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns> A task indicating whether the disconnect method is done or not.</returns>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
        /// <privilege>http://tizen.org/privilege/network.set</privilege>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <exception cref="NotSupportedException">Thrown when the Wi-Fi is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when permission is denied.</exception>
        /// <exception cref="ObjectDisposedException">Thrown when the object instance is disposed or released.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when the system is out of memory.</exception>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        public Task DisconnectAsync()
        {
            Log.Debug(Globals.LogTag, "DisconnectAsync");
            if (_disposed)
            {
                throw new ObjectDisposedException("Invalid AP instance (Object may have been disposed or released)");
            }
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
            int ret = Interop.WiFi.Disconnect(WiFiManagerImpl.Instance.GetSafeHandle(), _apHandle, _callback_map[id], id);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to disconnect wifi, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret, WiFiManagerImpl.Instance.GetSafeHandle().DangerousGetHandle(), _apHandle);
            }
            return task.Task;
        }

        /// <summary>
        /// Deletes the information of a stored access point and disconnects it when the AP is connected.
        /// If an AP is connected, then the connection information will be stored. This information is used when a connection to that AP is established automatically.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
        /// <privilege>http://tizen.org/privilege/network.profile</privilege>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <exception cref="NotSupportedException">Thrown when the Wi-Fi is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when permission is denied.</exception>
        /// <exception cref="ObjectDisposedException">Thrown when the object instance is disposed or released.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when the system is out of memory.</exception>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        public void ForgetAP()
        {
            Log.Debug(Globals.LogTag, "ForgetAP");
            if (_disposed)
            {
                throw new ObjectDisposedException("Invalid AP instance (Object may have been disposed or released)");
            }
            int ret = Interop.WiFi.RemoveAP(WiFiManagerImpl.Instance.GetSafeHandle(), _apHandle);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to forget AP, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret, WiFiManagerImpl.Instance.GetSafeHandle().DangerousGetHandle(), _apHandle);
            }
        }

        /// <summary>
        /// Update the information of a stored access point.
        /// When a AP information is changed, the change will not be applied until this method is called.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
        /// <privilege>http://tizen.org/privilege/network.profile</privilege>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <exception cref="NotSupportedException">Thrown when the Wi-Fi is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when permission is denied.</exception>
        /// <exception cref="ObjectDisposedException">Thrown when the object instance is disposed or released.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when the system is out of memory.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        public void Update()
        {
            Log.Debug(Globals.LogTag, "Update");
            if (_disposed)
            {
                throw new ObjectDisposedException("Invalid AP instance (Object may have been disposed or released)");
            }
            int ret = Interop.WiFi.UpdateAP(WiFiManagerImpl.Instance.GetSafeHandle(), _apHandle);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to update AP, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret, WiFiManagerImpl.Instance.GetSafeHandle().DangerousGetHandle(), _apHandle);
            }
        }
   }

    /// <summary>
    /// An abstract class which is used to represent the WPS information of the access point.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public abstract class WpsInfo
    {
    }

    /// <summary>
    /// A class which is used to represent WPS PBC information of the access point.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class WpsPbcInfo : WpsInfo
    {
    }

    /// <summary>
    /// A class which is used to represent WPS PIN information of the access point.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class WpsPinInfo : WpsInfo
    {
        private string _pin;

        private WpsPinInfo()
        {
        }

        /// <summary>
        /// A public constructor which instantiates WpsPinInfo class with the given pin.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="pin">WPS Pin of the access point.</param>
        /// <remarks>
        /// Pin should not be null or empty. It should be of less than 8 characters.
        /// </remarks>
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
