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
using Tizen.Network.Connection;

namespace Tizen.Network.WiFi
{
    /// <summary>
    /// A class for managing the WiFi security information.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class WiFiSecurity
    {
        private Interop.WiFi.SafeWiFiAPHandle _apHandle;
        private WiFiEap _eap;

        /// <summary>
        /// The type of Wi-Fi security.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>Represents the security type of WiFi.</value>
        /// <exception cref="NotSupportedException">Thrown while setting this property when WiFi is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown while setting this property due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown while setting this value due to invalid operation.</exception>
        public WiFiSecurityType SecurityType
        {
            get
            {
                int type;
                int ret = Interop.WiFi.AP.GetSecurityType(_apHandle, out type);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get security type, Error - " + (WiFiError)ret);
                }
                return (WiFiSecurityType)type;
            }
            set
            {
                int ret = Interop.WiFi.AP.SetSecurityType(_apHandle, (int)value);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set security type, Error - " + (WiFiError)ret);
                    WiFiErrorFactory.ThrowWiFiException(ret, _apHandle.DangerousGetHandle());
                }
            }
        }

        /// <summary>
        /// The type of Wi-Fi encryption
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>Represents the encryption type of WiFi.</value>
        /// <exception cref="NotSupportedException">Thrown while setting this property when WiFi is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown while setting this property due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown while setting this value due to invalid operation.</exception>
        public WiFiEncryptionType EncryptionType
        {
            get
            {
                int type;
                int ret = Interop.WiFi.AP.GetEncryptionType(_apHandle, out type);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get encryption type, Error - " + (WiFiError)ret);
                }
                return (WiFiEncryptionType)type;
            }
            set
            {
                int ret = Interop.WiFi.AP.SetEncryptionType(_apHandle, (int)value);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set encryption type, Error - " + (WiFiError)ret);
                    WiFiErrorFactory.ThrowWiFiException(ret, _apHandle.DangerousGetHandle());
                }
            }
        }

        /// <summary>
        /// The EAP information
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>Eap information of WiFi.</value>
        public WiFiEap EapInformation
        {
            get
            {
                return _eap;
            }
        }

        /// <summary>
        /// A property to check whether the passphrase is required or not.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>Boolean value to check if passphrase is required or not.</value>
        public bool IsPassphraseRequired
        {
            get
            {
                bool required;
                int ret = Interop.WiFi.AP.IsPassphraseRequired(_apHandle, out required);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get isPassportRequired, Error - " + (WiFiError)ret);
                }
                return required;
            }
        }

        /// <summary>
        /// A property to check whether the Wi-Fi Protected Setup(WPS) is supported or not.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>Boolean value to check if wps is supported or not.</value>
        public bool IsWpsSupported
        {
            get
            {
                bool supported;
                int ret = Interop.WiFi.AP.IsWpsSupported(_apHandle, out supported);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get isWapSupported, Error - " + (WiFiError)ret);
                }
                return supported;
            }
        }

        internal WiFiSecurity(Interop.WiFi.SafeWiFiAPHandle apHandle)
        {
            _apHandle = apHandle;
            _eap = new WiFiEap(apHandle);
        }

        /// <summary>
        /// Sets the passphrase.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="passphrase">The passphrase of the access point.</param>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
        /// <exception cref="NotSupportedException">Thrown when WiFi is not supported.</exception>
        /// <exception cref="ArgumentNullException">Thrown when passphrase is passed as null.</exception>
        /// <exception cref="ArgumentException">Thrown when method is failed due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation.</exception>
        public void SetPassphrase(string passphrase)
        {
            if (passphrase == null)
            {
                throw new ArgumentNullException("Passphrase is null");
            }
            int ret = Interop.WiFi.AP.SetPassphrase(_apHandle, passphrase);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set passphrase, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret, _apHandle.DangerousGetHandle());
            }
        }
    } //WiFiSecurityInformation
}
