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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Tizen.Network.WiFi
{
    /// <summary>
    /// A class for managing the EAP information of access point(AP).
    /// </summary>
    public class WiFiEap : IWiFiEap
    {
        private Interop.WiFi.SafeWiFiAPHandle _apHandle;

        /// <summary>
        /// The file path of CA Certificate of EAP.
        /// </summary>
        public string CaCertificationFile
        {
            get
            {
                IntPtr strPtr;
                int ret = Interop.WiFi.AP.GetEapCaCertFile(_apHandle, out strPtr);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get caCertFile, Error - " + (WiFiError)ret);
                    WiFiErrorFactory.ThrowWiFiException(ret);
                    return "";
                }
                return Marshal.PtrToStringAnsi(strPtr);
            }
            set
            {
                int ret = Interop.WiFi.AP.SetEapCaCertFile(_apHandle, value);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set caCertFile, Error - " + (WiFiError)ret);
                    WiFiErrorFactory.ThrowWiFiException(ret);
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
                int ret = Interop.WiFi.AP.GetEapType(_apHandle, out type);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get eap type, Error - " + (WiFiError)ret);
                    WiFiErrorFactory.ThrowWiFiException(ret);
                }
                return (WiFiEapType)type;
            }
            set
            {
                int ret = Interop.WiFi.AP.SetEapType(_apHandle, (int)value);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set eap type, Error - " + (WiFiError)ret);
                    WiFiErrorFactory.ThrowWiFiException(ret);
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
                int ret = Interop.WiFi.AP.GetEapAuthType(_apHandle, out type);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get auth type, Error - " + (WiFiError)ret);
                    WiFiErrorFactory.ThrowWiFiException(ret);
                }
                return (WiFiAuthenticationType)type;
            }
            set
            {
                int ret = Interop.WiFi.AP.SetEapAuthType(_apHandle, (int)value);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set eap auth type, Error - " + (WiFiError)ret);
                    WiFiErrorFactory.ThrowWiFiException(ret);
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
        /// <returns>The file path of private key.</returns>
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
        /// <param name="privateKeyFile">The file path of private key.</param>
        /// <param name="password">The password.</param>
        public void SetPrivateKeyFile(string privateKeyFile, string password)
        {
            int ret = Interop.WiFi.AP.SetEapPrivateKeyFile(_apHandle, privateKeyFile, password);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set private key file, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret, _apHandle.DangerousGetHandle());
            }
        }

        /// <summary>
        /// Gets the Client Certificate of EAP.
        /// </summary>
        /// <returns>The file path of Client Certificate.</returns>
        public string GetClientCertFile()
        {
            IntPtr strPtr;
            int ret = Interop.WiFi.AP.GetEapClientCertFile(_apHandle, out strPtr);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get client cert file, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret, _apHandle.DangerousGetHandle());
            }
            return Marshal.PtrToStringAnsi(strPtr);
        }

        /// <summary>
        /// Sets the CA Certificate of EAP.
        /// </summary>
        /// <param name="clientCertFile">The file path of Client Certificate.</param>
        public void SetClientCertFile(string clientCertFile)
        {
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
        /// <returns>The user name</returns>
        public string GetUserName()
        {
            IntPtr strptr;
            bool passwordSet;
            int ret = Interop.WiFi.AP.GetEapPassphrase(_apHandle, out strptr, out passwordSet);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get user name in eap passphrase, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret, _apHandle.DangerousGetHandle());
            }
            return Marshal.PtrToStringAnsi(strptr);
        }

        /// <summary>
        /// Returns whether the password is set or not.
        /// </summary>
        /// <returns>True if password is set, false if password is not set.</returns>
        public bool IsPasswordSet()
        {
            IntPtr strptr;
            bool passwordSet;
            int ret = Interop.WiFi.AP.GetEapPassphrase(_apHandle, out strptr, out passwordSet);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get IsPasswordSet in passphrase, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret, _apHandle.DangerousGetHandle());
            }
            return passwordSet;
        }

        /// <summary>
        /// Sets the user name of EAP.
        /// </summary>
        /// <param name="userName">The user name</param>
        public void SetUserName(string userName)
        {
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
        /// <param name="password">The password</param>
        public void SetPassword(string password)
        {
            int ret = Interop.WiFi.AP.SetEapPassphrase(_apHandle, null, password);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set password, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret, _apHandle.DangerousGetHandle());
            }
        }
    } //WiFiEapInformation
}
