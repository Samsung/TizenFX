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
using System.Runtime.InteropServices;

namespace Tizen.Network.Connection
{
    /// <summary>
    /// This Class is WiFiProfile. It provides functions to manage the WiFi profile.
    /// </summary>
    public class WiFiProfile : ConnectionProfile
    {
        internal WiFiProfile(IntPtr Handle) : base(Handle)
        {
        }

        ~WiFiProfile()
        {
        }

        /// <summary>
        /// The ESSID (Extended Service Set Identifier).
        /// </summary>
        public string Essid
        {
            get
            {
                IntPtr value;
                int ret = Interop.ConnectionWiFiProfile.GetEssid(ProfileHandle, out value);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to create profile handle, " + (ConnectionError)ret);
                }
                string result = Marshal.PtrToStringAnsi(value);
                Interop.Libc.Free(value);
                return result;
            }
        }

        /// <summary>
        /// The BSSID (Basic Service Set Identifier).
        /// </summary>
        public string Bssid
        {
            get
            {
                IntPtr value;
                int ret = Interop.ConnectionWiFiProfile.GetBssid(ProfileHandle, out value);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get bssid, " + (ConnectionError)ret);
                }
                string result = Marshal.PtrToStringAnsi(value);
                Interop.Libc.Free(value);
                return result;
            }
        }

        /// <summary>
        /// The RSSI.
        /// </summary>
        public int Rssi
        {
            get
            {
                int value;
                int ret = Interop.ConnectionWiFiProfile.GetRssi(ProfileHandle, out value);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get rssi, " + (ConnectionError)ret);
                }
                return value;
            }
        }

        /// <summary>
        /// The frequency (MHz).
        /// </summary>
        public int Frequency
        {
            get
            {
                int value;
                int ret = Interop.ConnectionWiFiProfile.GetFrequency(ProfileHandle, out value);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get frequency, " + (ConnectionError)ret);
                }
                return value;
            }
        }

        /// <summary>
        /// The max speed (Mbps).
        /// </summary>
        public int MaxSpeed
        {
            get
            {
                int value;
                int ret = Interop.ConnectionWiFiProfile.GetMaxSpeed(ProfileHandle, out value);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get max speed, " + (ConnectionError)ret);
                }
                return value;
            }
        }

        /// <summary>
        /// The security type of Wi-Fi.
        /// </summary>
        public WiFiSecureType SecureType
        {
            get
            {
                int value;
                int ret = Interop.ConnectionWiFiProfile.GetSecurityType(ProfileHandle, out value);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get security type, " + (ConnectionError)ret);
                }
                return (WiFiSecureType)value;
            }
        }

        /// <summary>
        /// The encryption type of Wi-Fi.
        /// </summary>
        public WiFiEncryptionType EncryptionType
        {
            get
            {
                int value;
                int ret = Interop.ConnectionWiFiProfile.GetEncryptionType(ProfileHandle, out value);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get encryption type, " + (ConnectionError)ret);
                }
                return (WiFiEncryptionType)value;
            }
        }

        /// <summary>
        /// Checks whether passphrase is required.
        /// </summary>
        public bool PassphraseRequired
        {
            get
            {
                bool value;
                int ret = Interop.ConnectionWiFiProfile.IsRequiredPassphrase(ProfileHandle, out value);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get PassphraseRequired, " + (ConnectionError)ret);
                }
                return value;
            }
        }

        /// <summary>
        /// Checks whether the WPS (Wi-Fi Protected Setup) is supported.
        /// </summary>
        public bool WpsSupported
        {
            get
            {
                bool value;
                int ret = Interop.ConnectionWiFiProfile.IsSupportedWps(ProfileHandle, out value);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get IsSupportedWps, " + (ConnectionError)ret);
                }
                return value;
            }
        }

        /// <summary>
        /// Sets the passphrase of the Wi-Fi WPA.
        /// </summary>
        /// <param name="passphrase">The passphrase of Wi-Fi security</param>
        /// <returns>0 on success, else exception is thrown.</returns>
        /// <exception cref="InvalidOperationException">Thrown when method failed due to invalid operation</exception>
        public int SetPassphrase(string passphrase)
        {
            int ret = Interop.ConnectionWiFiProfile.SetPassphrase(ProfileHandle, (string)passphrase);
            if ((ConnectionError)ret != ConnectionError.None)
            {
                Log.Error(Globals.LogTag, "It failed to set passphrase, " + (ConnectionError)ret);
                ConnectionErrorFactory.ThrowConnectionException(ret);
            }
            return ret;
        }
    }
}
