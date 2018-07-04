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
    /// <since_tizen> 3 </since_tizen>
    public class WiFiEapConfiguration : IWiFiEap
    {
        private Interop.WiFi.SafeWiFiConfigHandle _configHandle;

        /// <summary>
        /// The file path of CA certificate of EAP.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>CA certification file of EAP.</value>
        /// <exception cref="NotSupportedException">Thrown while setting this value when Wi-Fi is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown while setting this property due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown while setting this value due to an invalid operation.</exception>
        public string CaCertificationFile
        {
            get
            {
                IntPtr strPtr;
                int ret = Interop.WiFi.Config.GetEapCaCertFile(_configHandle, out strPtr);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get caCertFile Error - " + (WiFiError)ret);
                    return "";
                }
                return Marshal.PtrToStringAnsi(strPtr);
            }
            set
            {
                int ret = Interop.WiFi.Config.SetEapCaCertFile(_configHandle, value);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set caCertFile, Error - " + (WiFiError)ret);
                    WiFiErrorFactory.ThrowWiFiException(ret, _configHandle.DangerousGetHandle());
                }
            }
        }

        /// <summary>
        /// The EAP type of the Wi-Fi.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>Type of EAP.</value>
        /// <exception cref="NotSupportedException">Thrown while setting this value when Wi-Fi is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown while setting this property due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown while setting this value due to an invalid operation.</exception>
        public WiFiEapType EapType
        {
            get
            {
                int type;
                int ret = Interop.WiFi.Config.GetEapType(_configHandle, out type);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to eap type Error - " + (WiFiError)ret);
                }
                return (WiFiEapType)type;
            }
            set
            {
                int ret = Interop.WiFi.Config.SetEapType(_configHandle, (int)value);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set eap type, Error - " + (WiFiError)ret);
                    WiFiErrorFactory.ThrowWiFiException(ret, _configHandle.DangerousGetHandle());
                }
            }
        }

        /// <summary>
        /// The type of EAP phase2 authentication of the Wi-Fi.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>Authentication type of the Wi-Fi.</value>
        /// <exception cref="NotSupportedException">Thrown while setting this value when Wi-Fi is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown while setting this property due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown while setting this value due to an invalid operation.</exception>
        public WiFiAuthenticationType AuthenticationType
        {
            get
            {
                int type;
                int ret = Interop.WiFi.Config.GetEapAuthType(_configHandle, out type);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get auth type Error - " + (WiFiError)ret);
                }
                return (WiFiAuthenticationType)type;
            }
            set
            {
                int ret = Interop.WiFi.Config.SetEapAuthType(_configHandle, (int)value);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set eap auth type, Error - " + (WiFiError)ret);
                    WiFiErrorFactory.ThrowWiFiException(ret, _configHandle.DangerousGetHandle());
                }
            }
        }

        /// <summary>
        /// The anonymous identity of the access point (AP).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>Represents the anonymous identity of the access point.</value>
        /// <exception cref="NotSupportedException">Thrown while setting this value when Wi-Fi is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown while setting this property due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown while setting this value due to an invalid operation.</exception>
        public string AnonymousIdentify
        {
            get
            {
                IntPtr strPtr;
                int ret = Interop.WiFi.Config.GetEapAnonymousIdentity(_configHandle, out strPtr);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get anonymous identify Error - " + (WiFiError)ret);
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
                    WiFiErrorFactory.ThrowWiFiException(ret, _configHandle.DangerousGetHandle());
                }
            }
        }

        /// <summary>
        /// The identity of the access point (AP).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>Represents the identity of the access point.</value>
        /// <exception cref="NotSupportedException">Thrown while setting this value when Wi-Fi is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown while setting this property due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown while setting this value due to an invalid operation.</exception>
        public string Identity
        {
            get
            {
                IntPtr strPtr;
                int ret = Interop.WiFi.Config.GetEapIdentity(_configHandle, out strPtr);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get identify Error - " + (WiFiError)ret);
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
                    WiFiErrorFactory.ThrowWiFiException(ret, _configHandle.DangerousGetHandle());
                }
            }
        }

        /// <summary>
        /// The subject match of the access point (AP).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>Represents the subject match of the AP.</value>
        /// <exception cref="NotSupportedException">Thrown while setting this value when Wi-Fi is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown while setting this property due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown while setting this value due to an invalid operation.</exception>
        public string SubjectMatch
        {
            get
            {
                IntPtr strPtr;
                int ret = Interop.WiFi.Config.GetEapSubjectMatch(_configHandle, out strPtr);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get subject match Error - " + (WiFiError)ret);
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
                    WiFiErrorFactory.ThrowWiFiException(ret, _configHandle.DangerousGetHandle());
                }
            }
        }

        internal WiFiEapConfiguration(Interop.WiFi.SafeWiFiConfigHandle handle)
        {
            _configHandle = handle;
        }

        /// <summary>
        /// Gets the access point client certificate file from the configuration.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>The certification authority (CA) certificates file of the access point.</returns>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
        /// <exception cref="NotSupportedException">Thrown when the Wi-Fi is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        public string GetClientCertFile()
        {
            IntPtr strPtr;
            int ret = Interop.WiFi.Config.GetEapClientCertFile(_configHandle, out strPtr);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get client cert file, Error - " + (WiFiError)ret);
                if (ret == (int)WiFiError.InvalidParameterError)
                {
                    throw new InvalidOperationException("Invalid handle");
                }
                WiFiErrorFactory.ThrowWiFiException(ret, _configHandle.DangerousGetHandle());
            }
            return Marshal.PtrToStringAnsi(strPtr);
        }

        /// <summary>
        /// Sets the access point client certificate file to configuration.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="privateKey">The private key file.</param>
        /// <param name="clientCert">The certification authority(CA) certifies the files of access points.</param>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
        /// <exception cref="NotSupportedException">Thrown when the Wi-Fi is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        public void SetClientCertFile(string privateKey, string clientCert)
        {
            int ret = Interop.WiFi.Config.SetEapClientCertFile(_configHandle, privateKey, clientCert);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set client cert file, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret, _configHandle.DangerousGetHandle());
            }
        }
    } //WiFiEapConfiguration
}
