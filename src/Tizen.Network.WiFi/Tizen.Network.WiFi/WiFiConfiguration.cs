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
    /// A class for managing the configuration of Wi-Fi. It allows applications to manage the configuration information of Wi-Fi.
    /// </summary>
    public class WiFiConfiguration : IDisposable
    {
        private IntPtr _configHandle = IntPtr.Zero;
        private bool disposed = false;
        private WiFiEapConfiguration _eapConfig;

        /// <summary>
        /// The name of access point(AP).
        /// </summary>
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
        /// The security type of access point(AP).
        /// </summary>
        public WiFiSecureType SecurityType
        {
            get
            {
                int type;
                int ret = Interop.WiFi.Config.GetSecurityType(_configHandle, out type);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get security type, Error - " + (WiFiError)ret);
                }
                return (WiFiSecureType)type;
            }
        }
        /// <summary>
        /// The proxy address.
        /// </summary>
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
                int ret = Interop.WiFi.Config.SetProxyAddress(_configHandle, (int)AddressFamily.IPv4, value);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set proxy address, Error - " + (WiFiError)ret);
                }
            }
        }
        /// <summary>
        /// A property check whether the access point(AP) is hidden or not.
        /// </summary>
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
                int ret = Interop.WiFi.Config.SetHiddenAPProperty(_configHandle, value);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set IsHidden, Error - " + (WiFiError)ret);
                }
            }
        }
        /// <summary>
        /// The EAP Configuration.
        /// </summary>
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
            _eapConfig = new WiFiEapConfiguration(_configHandle);
        }

        public WiFiConfiguration(string name, string passPhrase, WiFiSecureType type)
        {
            int ret = Interop.WiFi.Config.Create(WiFiManagerImpl.Instance.GetHandle(), name, passPhrase, (int)type, out _configHandle);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to create config handle, Error - " + (WiFiError)ret);
            }
            _eapConfig = new WiFiEapConfiguration(_configHandle);
        }

        ~WiFiConfiguration()
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
                _eapConfig.Dispose();
                Interop.WiFi.Config.Destroy(_configHandle);
                _configHandle = IntPtr.Zero;
            }
            disposed = true;
        }

        internal IntPtr GetHandle()
        {
            return _configHandle;
        }
    } //WiFiNetworkConfiguratin
}
