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
    /// A class for managing the EAP information of access point(AP). It allows applications to manager EAP information.
    /// This class is not intended to create instance directly from applications.
    /// </summary>
    public class WiFiEap : IWiFiEap, IDisposable
    {
        private IntPtr _apHandle = IntPtr.Zero;
        private bool disposed = false;

        /// <summary>
        /// The file path of CA Certificate of EAP.
        /// </summary>
        public string CaCertificationFile
        {
            get
            {
                IntPtr strPtr;
                int ret = Interop.WiFi.Ap.GetEapCaCertFile(_apHandle, out strPtr);
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
                int ret = Interop.WiFi.Ap.SetEapCaCertFile(_apHandle, value);
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
                int ret = Interop.WiFi.Ap.GetEapType(_apHandle, out type);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get eap type, Error - " + (WiFiError)ret);
                    WiFiErrorFactory.ThrowWiFiException(ret);
                }
                return (WiFiEapType)type;
            }
            set
            {
                int ret = Interop.WiFi.Ap.SetEapType(_apHandle, (int)value);
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
                int ret = Interop.WiFi.Ap.GetEapAuthType(_apHandle, out type);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get auth type, Error - " + (WiFiError)ret);
                    WiFiErrorFactory.ThrowWiFiException(ret);
                }
                return (WiFiAuthenticationType)type;
            }
            set
            {
                int ret = Interop.WiFi.Ap.SetEapAuthType(_apHandle, (int)value);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set eap auth type, Error - " + (WiFiError)ret);
                    WiFiErrorFactory.ThrowWiFiException(ret);
                }
            }
        }

        internal WiFiEap(IntPtr apHandle)
        {
            _apHandle = apHandle;
        }

        ~WiFiEap()
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
                // Free managed objects.
            }
            _apHandle = IntPtr.Zero;
            disposed = true;
        }

        /// <summary>
        /// Gets the private key file of EAP.
        /// </summary>
        /// <returns>The file path of private key.</returns>
        public string GetPrivateKeyFile()
        {
            IntPtr strPtr;
            int ret = Interop.WiFi.Ap.GetEapPrivateKeyFile(_apHandle, out strPtr);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get private key file, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret, _apHandle);
            }
            return Marshal.PtrToStringAnsi(strPtr);
        }

        /// <summary>
        /// Sets the private key information of EAP.
        /// </summary>
        /// <param name="privateKeyFile">The file path of private key.</param>
        /// <param name="password">The password.</param>
        public void SetPrivateKeyInfo(string privateKeyFile, string password)
        {
            int ret = Interop.WiFi.Ap.SetEapPrivateKeyInfo(_apHandle, privateKeyFile, password);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set private key info, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret, _apHandle);
            }
        }

        /// <summary>
        /// Gets the Client Certificate of EAP.
        /// </summary>
        /// <returns>The file path of Client Certificate.</returns>
        public string GetClientCertFile()
        {
            IntPtr strPtr;
            int ret = Interop.WiFi.Ap.GetEapClientCertFile(_apHandle, out strPtr);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get client cert file, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret, _apHandle);
            }
            return Marshal.PtrToStringAnsi(strPtr);
        }

        /// <summary>
        /// Sets the CA Certificate of EAP.
        /// </summary>
        /// <param name="clientCertFile">The file path of Client Certificate.</param>
        public void SetClientCertFile(string clientCertFile)
        {
            int ret = Interop.WiFi.Ap.SetEapClientCertFile(_apHandle, clientCertFile);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set client cert file, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret, _apHandle);
            }
        }

        /// <summary>
        /// Gets the username of EAP passphrase.
        /// </summary>
        /// <returns>The user name</returns>
        public string GetEapPassphraseUserName()
        {
            IntPtr strptr;
            bool passwordSet;
            int ret = Interop.WiFi.Ap.GetEapPassphrase(_apHandle, out strptr, out passwordSet);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get user name in eap passphrase, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret, _apHandle);
            }
            return Marshal.PtrToStringAnsi(strptr);
        }
        /// <summary>
        /// Returns whether the password is set for not set.
        /// </summary>
        /// <returns>ture if password is set, otherwise flase if password is not set.</returns>
        public bool IsEapPassphrasePasswordSet()
        {
            IntPtr strptr;
            bool passwordSet;
            int ret = Interop.WiFi.Ap.GetEapPassphrase(_apHandle, out strptr, out passwordSet);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get IsPasswordSet in passphrase, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret, _apHandle);
            }
            return passwordSet;
        }

        /// <summary>
        /// Sets the passphrase of EAP.
        /// You can set one of user_name and password as NULL.<br>
        /// In this case, the value of a parameter which is set as NULL will be the previous value. But it is not allowed that both user_name and password are set as NULL.
        /// </summary>
        /// <param name="userName">The user name</param>
        /// <param name="password">The password</param>
        public void SetEapPassphrase(string userName, string password)
        {
            int ret = Interop.WiFi.Ap.SetEapPassphrase(_apHandle, userName, password);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set passphrase, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret, _apHandle);
            }
        }
    } //WiFiEapInformation
}
