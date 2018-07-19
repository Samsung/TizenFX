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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Tizen.Network.WiFi
{
    /// <summary>
    /// A class for managing the EAP information of the access point (AP).
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class WiFiEap : IWiFiEap
    {
        private Interop.WiFi.SafeWiFiAPHandle _apHandle;

        /// <summary>
        /// The file path of CA Certificate of EAP.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>CA certification file of EAP.</value>
        /// <exception cref="NotSupportedException">Thrown while setting this value when Wi-Fi is not supported.</exception>
        /// <exception cref="ArgumentNullException">Thrown while setting this value when the file value is null.</exception>
        /// <exception cref="ArgumentException">Thrown while setting this property due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown while setting this value due to an invalid operation.</exception>
        public string CaCertificationFile
        {
            get
            {
                IntPtr strPtr;
                int ret = Interop.WiFi.AP.GetEapCaCertFile(_apHandle, out strPtr);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get caCertFile, Error - " + (WiFiError)ret);
                    return "";
                }
                return Marshal.PtrToStringAnsi(strPtr);
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("File value is null");
                }
                int ret = Interop.WiFi.AP.SetEapCaCertFile(_apHandle, value);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set caCertFile, Error - " + (WiFiError)ret);
                    WiFiErrorFactory.ThrowWiFiException(ret, _apHandle.DangerousGetHandle());
                }
            }
        }

        /// <summary>
        /// The EAP type of Wi-Fi.
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
                int ret = Interop.WiFi.AP.GetEapType(_apHandle, out type);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get eap type, Error - " + (WiFiError)ret);
                }
                return (WiFiEapType)type;
            }
            set
            {
                int ret = Interop.WiFi.AP.SetEapType(_apHandle, (int)value);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set eap type, Error - " + (WiFiError)ret);
                    WiFiErrorFactory.ThrowWiFiException(ret, _apHandle.DangerousGetHandle());
                }
            }
        }

        /// <summary>
        /// The type of EAP phase 2 authentication of the Wi-Fi.
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
                int ret = Interop.WiFi.AP.GetEapAuthType(_apHandle, out type);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get auth type, Error - " + (WiFiError)ret);
                }
                return (WiFiAuthenticationType)type;
            }
            set
            {
                int ret = Interop.WiFi.AP.SetEapAuthType(_apHandle, (int)value);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set eap auth type, Error - " + (WiFiError)ret);
                    WiFiErrorFactory.ThrowWiFiException(ret, _apHandle.DangerousGetHandle());
                }
            }
        }

        internal WiFiEap(Interop.WiFi.SafeWiFiAPHandle apHandle)
        {
            _apHandle = apHandle;
        }

        /// <summary>
        /// Gets the private key file of EAP.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>The file path of private key.</returns>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
        /// <exception cref="NotSupportedException">Thrown when the Wi-Fi is not supported.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when the system is out of memory.</exception>
        /// <exception cref="ArgumentException">Thrown when the method fails due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method fails due to an invalid operation.</exception>
        public string GetPrivateKeyFile()
        {
            IntPtr strPtr;
            int ret = Interop.WiFi.AP.GetEapPrivateKeyFile(_apHandle, out strPtr);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get private key file, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret, _apHandle.DangerousGetHandle());
            }
            return Marshal.PtrToStringAnsi(strPtr);
        }

        /// <summary>
        /// Sets the private key information of EAP.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="privateKeyFile">The file path of private key.</param>
        /// <param name="password">The password.</param>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
        /// <exception cref="NotSupportedException">Thrown when the Wi-Fi is not supported.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the file path of private key is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due an to invalid operation.</exception>
        public void SetPrivateKeyFile(string privateKeyFile, string password)
        {
            if (privateKeyFile == null)
            {
                throw new ArgumentNullException("File path of private key is null");
            }
            int ret = Interop.WiFi.AP.SetEapPrivateKeyFile(_apHandle, privateKeyFile, password);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set private key file, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret, _apHandle.DangerousGetHandle());
            }
        }

        /// <summary>
        /// Gets the client certificate of EAP.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>The file path of client certificate.</returns>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
        /// <exception cref="NotSupportedException">Thrown when the Wi-Fi is not supported.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when the system is out of memory.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due an to invalid operation.</exception>
        public string GetClientCertFile()
        {
            IntPtr strPtr;
            int ret = Interop.WiFi.AP.GetEapClientCertFile(_apHandle, out strPtr);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get client cert file, Error - " + (WiFiError)ret);
                if (ret == (int)WiFiError.InvalidParameterError)
                {
                    throw new InvalidOperationException("Invalid handle");
                }
                WiFiErrorFactory.ThrowWiFiException(ret, _apHandle.DangerousGetHandle());
            }
            return Marshal.PtrToStringAnsi(strPtr);
        }

        /// <summary>
        /// Sets the CA certificate of EAP.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="clientCertFile">The file path of client certificate.</param>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
        /// <exception cref="NotSupportedException">Thrown when the Wi-Fi is not supported.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the file path of client certificate is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        public void SetClientCertFile(string clientCertFile)
        {
            if (clientCertFile == null)
            {
                throw new ArgumentNullException("File path of Client certificate is null");
            }
            int ret = Interop.WiFi.AP.SetEapClientCertFile(_apHandle, clientCertFile);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set client cert file, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret, _apHandle.DangerousGetHandle());
            }
        }

        /// <summary>
        /// Gets the username of EAP passphrase.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>The user name</returns>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
        /// <exception cref="NotSupportedException">Thrown when the Wi-Fi is not supported.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when the system is out of memory.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        public string GetUserName()
        {
            IntPtr strptr;
            bool passwordSet;
            int ret = Interop.WiFi.AP.GetEapPassphrase(_apHandle, out strptr, out passwordSet);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get user name in eap passphrase, Error - " + (WiFiError)ret);
                if (ret == (int)WiFiError.InvalidParameterError)
                {
                    throw new InvalidOperationException("Invalid handle");
                }
                WiFiErrorFactory.ThrowWiFiException(ret, _apHandle.DangerousGetHandle());
            }
            return Marshal.PtrToStringAnsi(strptr);
        }

        /// <summary>
        /// Returns whether the password is set or not.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>True if password is set, false if password is not set.</returns>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
        /// <exception cref="NotSupportedException">Thrown when the Wi-Fi is not supported.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when the system is out of memory.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        public bool IsPasswordSet()
        {
            IntPtr strptr;
            bool passwordSet;
            int ret = Interop.WiFi.AP.GetEapPassphrase(_apHandle, out strptr, out passwordSet);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get IsPasswordSet in passphrase, Error - " + (WiFiError)ret);
                if (ret == (int)WiFiError.InvalidParameterError)
                {
                    throw new InvalidOperationException("Invalid handle");
                }
                WiFiErrorFactory.ThrowWiFiException(ret, _apHandle.DangerousGetHandle());
            }
            return passwordSet;
        }

        /// <summary>
        /// Sets the user name of EAP.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="userName">The user name</param>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
        /// <exception cref="NotSupportedException">Thrown when the Wi-Fi is not supported.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the user name is passed as null.</exception>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        public void SetUserName(string userName)
        {
            if (userName == null)
            {
                throw new ArgumentNullException("User name is null");
            }
            int ret = Interop.WiFi.AP.SetEapPassphrase(_apHandle, userName, null);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set username, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret, _apHandle.DangerousGetHandle());
            }
        }

        /// <summary>
        /// Sets the password of EAP.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="password">The password</param>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
        /// <exception cref="NotSupportedException">Thrown when the Wi-Fi is not supported.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the password is passed as null.</exception>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        public void SetPassword(string password)
        {
            if (password == null)
            {
                throw new ArgumentNullException("Password is null");
            }
            int ret = Interop.WiFi.AP.SetEapPassphrase(_apHandle, null, password);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set password, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret, _apHandle.DangerousGetHandle());
            }
        }
    } //WiFiEapInformation
}
