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
    /// A class for managing the security information. It allows applications to manager security information.
    /// This class is not intended to create instance directly from applications.
    /// </summary>
    public class WiFiSecurity : IDisposable
    {
        private IntPtr _apHandle = IntPtr.Zero;
        private WiFiEap _eap;
        private bool disposed = false;

        /// <summary>
        /// The type of Wi-Fi security.
        /// </summary>
        public WiFiSecureType SecurityType
        {
            get
            {
                int type;
                int ret = Interop.WiFi.AP.GetSecurityType(_apHandle, out type);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get security type, Error - " + (WiFiError)ret);
                    WiFiErrorFactory.ThrowWiFiException(ret);
                }
                return (WiFiSecureType)type;
            }
            set
            {
                int ret = Interop.WiFi.AP.SetSecurityType(_apHandle, (int)value);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set security type, Error - " + (WiFiError)ret);
                    WiFiErrorFactory.ThrowWiFiException(ret);
                }
            }
        }
        /// <summary>
        /// The type of Wi-Fi encryption
        /// </summary>
        public WiFiEncryptionType EncryptionType
        {
            get
            {
                int type;
                int ret = Interop.WiFi.AP.GetEncryptionType(_apHandle, out type);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get encryption type, Error - " + (WiFiError)ret);
                    WiFiErrorFactory.ThrowWiFiException(ret);
                }
                return (WiFiEncryptionType)type;
            }
            set
            {
                int ret = Interop.WiFi.AP.SetEncryptionType(_apHandle, (int)value);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set encryption type, Error - " + (WiFiError)ret);
                    WiFiErrorFactory.ThrowWiFiException(ret);
                }
            }
        }
        /// <summary>
        /// The EAP information
        /// </summary>
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
        public bool IsPassphraseRequired
        {
            get
            {
                bool required;
                int ret = Interop.WiFi.AP.IsPassphraseRequired(_apHandle, out required);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get isPassportRequired, Error - " + (WiFiError)ret);
                    WiFiErrorFactory.ThrowWiFiException(ret);
                }
                return required;
            }
        }
        /// <summary>
        /// A property to check whether the Wi-Fi Protected Setup(WPS) is supported or not.
        /// </summary>
        public bool IsWpsSupported
        {
            get
            {
                bool supported;
                int ret = Interop.WiFi.AP.IsWpsSupported(_apHandle, out supported);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get isWapSupported, Error - " + (WiFiError)ret);
                    WiFiErrorFactory.ThrowWiFiException(ret);
                }
                return supported;
            }
        }

        internal WiFiSecurity(IntPtr apHandle)
        {
            _apHandle = apHandle;
            _eap = new WiFiEap(apHandle);
        }

        ~WiFiSecurity()
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
                _eap.Dispose();
            }
            _apHandle = IntPtr.Zero;
            disposed = true;
        }

        /// <summary>
        /// Sets the passphrase.
        /// </summary>
        public void SetPassphrase(string passphrase)
        {
            int ret = Interop.WiFi.AP.SetPassphrase(_apHandle, passphrase);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set passphrase, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret, _apHandle);
            }
        }
    } //WiFiSecurityInformation
}
