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
    /// This is the WiFiProfile class. It provides functions to manage the WiFi profile.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class WiFiProfile : ConnectionProfile
    {
        internal WiFiProfile(IntPtr Handle) : base(Handle)
        {
        }

        /// <summary>
        /// Destroy the WiFiProfile object
        /// </summary>
        ~WiFiProfile()
        {
        }

        /// <summary>
        /// The ESSID (Extended Service Set Identifier).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>ESSID of the WiFi.</value>
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
        /// <since_tizen> 3 </since_tizen>
        /// <value>BSSID of the WiFi.</value>
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
        /// <since_tizen> 3 </since_tizen>
        /// <value>RSSI of the WiFi.</value>
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
        /// <since_tizen> 3 </since_tizen>
        /// <value>Frequency of the WiFi.</value>
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
        /// <since_tizen> 3 </since_tizen>
        /// <value>Maximum speed of the WiFi.</value>
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
        /// The security type of WiFi.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>Security type of the WiFi.</value>
        public WiFiSecurityType SecurityType
        {
            get
            {
                int value;
                int ret = Interop.ConnectionWiFiProfile.GetSecurityType(ProfileHandle, out value);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get security type, " + (ConnectionError)ret);
                }
                return (WiFiSecurityType)value;
            }
        }

        /// <summary>
        /// The encryption type of WiFi.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>Encryption mode of the WiFi.</value>
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
        /// <since_tizen> 3 </since_tizen>
        /// <value>True if a passphrase is required, otherwise false.</value>
        /// <remarks>This property is not valid if <c>WiFiSecurityType</c> is <c>Eap</c>.</remarks>
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
        /// <since_tizen> 3 </since_tizen>
        /// <value>True if WPS is supported, otherwise false.</value>
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
        /// <since_tizen> 3 </since_tizen>
        /// <param name="passphrase">The passphrase of Wi-Fi security.</param>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
        /// <exception cref="System.NotSupportedException">Thrown when a feature is not supported.</exception>
        /// <exception cref="System.ArgumentException">Thrown when a value is an invalid parameter.</exception>
        /// <exception cref="System.ArgumentNullException">Thrown when a passphrase is null.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when a profile instance is invalid or when a method fails due to an invalid operation.</exception>
        /// <exception cref="System.ObjectDisposedException">Thrown when an operation is performed on a disposed object.</exception>
        public void SetPassphrase(string passphrase)
        {
            CheckDisposed();
            if (passphrase != null)
            {
                int ret = Interop.ConnectionWiFiProfile.SetPassphrase(ProfileHandle, passphrase);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to set passphrase, " + (ConnectionError)ret);
                    ConnectionErrorFactory.CheckFeatureUnsupportedException(ret, "http://tizen.org/feature/network.wifi");
                    ConnectionErrorFactory.CheckHandleNullException(ret, (ProfileHandle == IntPtr.Zero), "ProfileHandle may have been disposed or released");
                    ConnectionErrorFactory.ThrowConnectionException(ret);
                }
            }

            else
            {
                throw new ArgumentNullException("Value of passphrase is null");
            }
        }
    }
}
