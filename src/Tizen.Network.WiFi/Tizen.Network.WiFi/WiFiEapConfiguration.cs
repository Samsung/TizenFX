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
using System.Runtime.InteropServices;

namespace Tizen.Network.WiFi
{
    /// <summary>
    /// A class for managing the EAP configuration.
    /// </summary>
    public class WiFiEapConfiguration : IWiFiEap, IDisposable
    {
        private IntPtr _configHandle = IntPtr.Zero;
        private bool disposed = false;

        /// <summary>
        /// The file path of CA Certificate of EAP.
        /// </summary>
        public string CaCertificationFile
        {
            get
            {
                IntPtr strPtr;
                int ret = Interop.WiFi.Config.GetEapCaCertFile(_configHandle, out strPtr);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get caCertFile Error - " + (WiFiError)ret);
                    WiFiErrorFactory.ThrowWiFiException(ret, _configHandle);
                }
                return Marshal.PtrToStringAnsi(strPtr);
            }
            set
            {
                int ret = Interop.WiFi.Config.SetEapCaCertFile(_configHandle, value);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set caCertFile, Error - " + (WiFiError)ret);
                    WiFiErrorFactory.ThrowWiFiException(ret, _configHandle);
                }
            }
        }

        /// <summary>
        /// The EAP type of wifi.
        /// </summary>
        public WiFiEapType EapType
        {
            get
            {
                int type;
                int ret = Interop.WiFi.Config.GetEapType(_configHandle, out type);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to eap type Error - " + (WiFiError)ret);
                    WiFiErrorFactory.ThrowWiFiException(ret, _configHandle);
                }
                return (WiFiEapType)type;
            }
            set
            {
                int ret = Interop.WiFi.Config.SetEapType(_configHandle, (int)value);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set eap type, Error - " + (WiFiError)ret);
                    WiFiErrorFactory.ThrowWiFiException(ret, _configHandle);
                }
            }
        }

        /// <summary>
        /// The type of EAP phase2 authentication of Wi-Fi.
        /// </summary>
        public WiFiAuthenticationType AuthenticationType
        {
            get
            {
                int type;
                int ret = Interop.WiFi.Config.GetEapAuthType(_configHandle, out type);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get auth type Error - " + (WiFiError)ret);
                    WiFiErrorFactory.ThrowWiFiException(ret, _configHandle);
                }
                return (WiFiAuthenticationType)type;
            }
            set
            {
                int ret = Interop.WiFi.Config.SetEapAuthType(_configHandle, (int)value);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set eap auth type, Error - " + (WiFiError)ret);
                    WiFiErrorFactory.ThrowWiFiException(ret, _configHandle);
                }
            }
        }

        /// <summary>
        /// The anonymous identity of access point(AP).
        /// </summary>
        public string AnonymousIdentify
        {
            get
            {
                IntPtr strPtr;
                int ret = Interop.WiFi.Config.GetEapAnonymousIdentity(_configHandle, out strPtr);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get anonymous identify Error - " + (WiFiError)ret);
                    WiFiErrorFactory.ThrowWiFiException(ret, _configHandle);
                    return "";
                }
                return Marshal.PtrToStringAnsi(strPtr);
            }
            set
            {
                int ret = Interop.WiFi.Config.SetEapAnonymousIdentity(_configHandle, value);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set anonymous identify, Error - " + (WiFiError)ret);
                    WiFiErrorFactory.ThrowWiFiException(ret, _configHandle);
                }
            }
        }

        /// <summary>
        /// The identity of access point(AP).
        /// </summary>
        public string Identity
        {
            get
            {
                IntPtr strPtr;
                int ret = Interop.WiFi.Config.GetEapIdentity(_configHandle, out strPtr);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get identify Error - " + (WiFiError)ret);
                    WiFiErrorFactory.ThrowWiFiException(ret, _configHandle);
                    return "";
                }
                return Marshal.PtrToStringAnsi(strPtr);
            }
            set
            {
                int ret = Interop.WiFi.Config.SetEapIdentity(_configHandle, value);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set identify, Error - " + (WiFiError)ret);
                    WiFiErrorFactory.ThrowWiFiException(ret, _configHandle);
                }
            }
        }

        /// <summary>
        /// The subject match of access point(AP).
        /// </summary>
        public string SubjectMatch
        {
            get
            {
                IntPtr strPtr;
                int ret = Interop.WiFi.Config.GetEapSubjectMatch(_configHandle, out strPtr);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get subject match Error - " + (WiFiError)ret);
                    WiFiErrorFactory.ThrowWiFiException(ret, _configHandle);
                    return "";
                }
                return Marshal.PtrToStringAnsi(strPtr);
            }
            set
            {
                int ret = Interop.WiFi.Config.SetEapSubjectMatch(_configHandle, value);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set subject match, Error - " + (WiFiError)ret);
                    WiFiErrorFactory.ThrowWiFiException(ret, _configHandle);
                }
            }
        }

        internal WiFiEapConfiguration(IntPtr handle)
        {
            _configHandle = handle;
        }

        ~WiFiEapConfiguration()
        {
            Dispose(false);
        }

        /// <summary>
        /// A method to destroy the managed objects in WiFiEapConfiguration.
        /// </summary>
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
            _configHandle = IntPtr.Zero;
            disposed = true;
        }

        /// <summary>
        /// Gets access point client cert file from configuration.
        /// </summary>
        /// <returns>The certification authority(CA) certificates file of access point.</returns>
        public string GetClientCertFile()
        {
            IntPtr strPtr;
            int ret = Interop.WiFi.Config.GetEapClientCertFile(_configHandle, out strPtr);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get client cert file, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret, _configHandle);
            }
            return Marshal.PtrToStringAnsi(strPtr);
        }

        /// <summary>
        /// Sets access point client cert file to configuration.
        /// </summary>
        /// <param name="privateKey">The private key file.</param>
        /// <param name="clientCert">The certification authority(CA) certificates file of access point.</param>
        public void SetClientCertFile(string privateKey, string clientCert)
        {
            int ret = Interop.WiFi.Config.SetEapClientCertFile(_configHandle, privateKey, clientCert);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set client cert file, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret, _configHandle);
            }
        }
    } //WiFiEapConfiguration
}
