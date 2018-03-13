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
using System.Net;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Tizen.Network.Connection;

namespace Tizen.Network.WiFi
{
    /// <summary>
    /// A class for managing the configuration of Wi-Fi.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class WiFiConfiguration : IDisposable
    {
        private IntPtr _configHandle = IntPtr.Zero;
        private bool _disposed = false;
        private WiFiEapConfiguration _eapConfig;

        /// <summary>
        /// The name of the access point (AP).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>Name assigned to AP in the Wi-Fi configuration.</value>
        public string Name
        {
            get
            {
                IntPtr strPtr;
                int ret = Interop.WiFi.Config.GetName(_configHandle, out strPtr);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get name, Error - " + (WiFiError)ret);
                    return "";
                }
                return Marshal.PtrToStringAnsi(strPtr);
            }
        }

        /// <summary>
        /// The security type of the access point (AP).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>Security type of AP in the Wi-Fi configuration.</value>
        public WiFiSecurityType SecurityType
        {
            get
            {
                int type;
                int ret = Interop.WiFi.Config.GetSecurityType(_configHandle, out type);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get security type, Error - " + (WiFiError)ret);
                }
                return (WiFiSecurityType)type;
            }
        }

        /// <summary>
        /// The proxy address.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>Proxy address of the access point.</value>
        /// <exception cref="NotSupportedException">Thrown while setting this property when Wi-Fi is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown while setting this property due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown while setting this value due to an invalid operation.</exception>
        public string ProxyAddress
        {
            get
            {
                IntPtr strPtr;
                int addressFamily;
                int ret = Interop.WiFi.Config.GetProxyAddress(_configHandle, out addressFamily, out strPtr);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get proxy address, Error - " + (WiFiError)ret);
                    return "";
                }
                return Marshal.PtrToStringAnsi(strPtr);
            }
            set
            {
                if (_disposed)
                {
                    throw new ObjectDisposedException("Invalid WiFiConfiguration instance (Object may have been disposed or released)");
                }
                int ret = Interop.WiFi.Config.SetProxyAddress(_configHandle, (int)AddressFamily.IPv4, value);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set proxy address, Error - " + (WiFiError)ret);
                    WiFiErrorFactory.ThrowWiFiException(ret, _configHandle);
                }
            }
        }

        /// <summary>
        /// A property check whether the access point (AP) is hidden.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>Boolean value indicating whether the AP is hidden.</value>
        /// <exception cref="NotSupportedException">Thrown while setting this property when the Wi-Fi is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown while setting this property due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown while setting this value due to an invalid operation.</exception>
        public bool IsHidden
        {
            get
            {
                bool hidden;
                int ret = Interop.WiFi.Config.GetHiddenAPProperty(_configHandle, out hidden);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get isHidden, Error - " + (WiFiError)ret);
                }
                return hidden;
            }
            set
            {
                if (_disposed)
                {
                    throw new ObjectDisposedException("Invalid WiFiConfiguration instance (Object may have been disposed or released)");
                }
                int ret = Interop.WiFi.Config.SetHiddenAPProperty(_configHandle, value);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set IsHidden, Error - " + (WiFiError)ret);
                    WiFiErrorFactory.ThrowWiFiException(ret, _configHandle);
                }
            }
        }

        /// <summary>
        /// EAP configuration.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>EAP configuration assigned to the Wi-Fi.</value>
        public WiFiEapConfiguration EapConfiguration
        {
            get
            {
                return _eapConfig;
            }
        }

        internal WiFiConfiguration(IntPtr handle)
        {
            _configHandle = handle;
            Interop.WiFi.SafeWiFiConfigHandle configHandle = new Interop.WiFi.SafeWiFiConfigHandle(handle);
            _eapConfig = new WiFiEapConfiguration(configHandle);
        }

        /// <summary>
        /// Creates a WiFiConfiguration object with the given name, passphrase, and securetype.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="name">Name of the Wi-Fi.</param>
        /// <param name="passPhrase">Password to access the Wi-Fi.</param>
        /// <param name="type">Security type of the Wi-Fi.</param>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <exception cref="NotSupportedException">Thrown when the Wi-Fi is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when permission is denied.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the object is constructed with name as null.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when the system is out of memory.</exception>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        public WiFiConfiguration(string name, string passPhrase, WiFiSecurityType type)
        {
            if (name == null)
            {
                throw new ArgumentNullException("Name of the WiFi is null");
            }

            int ret = Interop.WiFi.Config.Create(WiFiManagerImpl.Instance.GetSafeHandle(), name, passPhrase, (int)type, out _configHandle);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to create config handle, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret, WiFiManagerImpl.Instance.GetSafeHandle().DangerousGetHandle());
            }

            Interop.WiFi.SafeWiFiConfigHandle configHandle = new Interop.WiFi.SafeWiFiConfigHandle(_configHandle);
            _eapConfig = new WiFiEapConfiguration(configHandle);
        }

        /// <summary>
        /// Destroy of the WiFiConfiguration object
        /// </summary>
        ~WiFiConfiguration()
        {
            Dispose(false);
        }

        /// <summary>
        /// A method to destroy the managed objects in the WiFiConfiguration.
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

            Interop.WiFi.Config.Destroy(_configHandle);
            _configHandle = IntPtr.Zero;
            _disposed = true;
        }

        internal IntPtr GetHandle()
        {
            return _configHandle;
        }
    } //WiFiNetworkConfiguratin
}
