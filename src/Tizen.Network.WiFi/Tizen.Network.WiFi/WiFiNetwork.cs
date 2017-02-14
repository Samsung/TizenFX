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
using System.Net;
using System.Runtime.InteropServices;
using Tizen.Network.Connection;

namespace Tizen.Network.WiFi
{
    /// <summary>
    /// A class for managing the Wi-Fi information. It allows applications to manager network information.
    /// This class is not intended to create instance directly from applications.
    /// </summary>
    public class WiFiNetwork : IDisposable
    {
        private IntPtr _apHandle = IntPtr.Zero;
        private IAddressInformation _ipv4;
        private IAddressInformation _ipv6;
        private bool disposed = false;
        private string _essid;

        /// <summary>
        /// The Extended Service Set Identifier(ESSID).
        /// </summary>
        public string Essid
        {
            get
            {
                if (string.IsNullOrEmpty(_essid))
                {
                    IntPtr strPtr;
                    int ret = Interop.WiFi.AP.GetEssid(_apHandle, out strPtr);
                    if (ret != (int)WiFiError.None)
                    {
                        Log.Error(Globals.LogTag, "Failed to get essid, Error - " + (WiFiError)ret);
                        _essid = "";
                    }
                    else
                    {
                        _essid = Marshal.PtrToStringAnsi(strPtr);
                    }
                }
                return _essid;
            }
        }
        /// <summary>
        /// The Basic Service Set Identifier(BSSID).
        /// </summary>
        public string Bssid
        {
            get
            {
                IntPtr strPtr;
                int ret = Interop.WiFi.AP.GetBssid(_apHandle, out strPtr);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get bssid, Error - " + (WiFiError)ret);
                    return "";
                }
                return Marshal.PtrToStringAnsi(strPtr);
            }
        }
        /// <summary>
        /// The address informaiton for IPv4.
        /// </summary>
        public IAddressInformation IPv4Setting
        {
            get
            {
                return _ipv4;
            }
        }
        /// <summary>
        /// The address ainformation for IPv6.
        /// </summary>
        public IAddressInformation IPv6Setting
        {
            get
            {
                return _ipv6;
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
                int ret = Interop.WiFi.AP.GetProxyAddress(_apHandle, (int)AddressFamily.IPv4, out strPtr);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get proxy address, Error - " + (WiFiError)ret);
                    return "";
                }
                return Marshal.PtrToStringAnsi(strPtr);
            }
            set
            {
                int ret = Interop.WiFi.AP.SetProxyAddress(_apHandle, (int)AddressFamily.IPv4, value);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set proxy address, Error - " + (WiFiError)ret);
                }
            }
        }
        /// <summary>
        /// The proxy type(IPv6).
        /// </summary>
        public WiFiProxyType ProxyType
        {
            get
            {
                int type;
                int ret = Interop.WiFi.AP.GetProxyType(_apHandle, out type);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get proxy type, Error - " + (WiFiError)ret);
                }
                return (WiFiProxyType)type;
            }
            set
            {
                int ret = Interop.WiFi.AP.SetProxyType(_apHandle, (int)value);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set proxy type, Error - " + (WiFiError)ret);
                }
            }
        }
        /// <summary>
        /// The frequency band(MHz).
        /// </summary>
        public int Frequency
        {
            get
            {
                int freq;
                int ret = Interop.WiFi.AP.GetFrequency(_apHandle, out freq);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get frequency, Error - " + (WiFiError)ret);
                }
                return freq;
            }
        }
        /// <summary>
        /// The Received signal strength indication(RSSI).
        /// </summary>
        public int Rssi
        {
            get
            {
                int rssi;
                int ret = Interop.WiFi.AP.GetRssi(_apHandle, out rssi);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get rssi, Error - " + (WiFiError)ret);
                }
                return rssi;
            }
        }
        /// <summary>
        /// Rhe max speed (Mbps).
        /// </summary>
        public int MaxSpeed
        {
            get
            {
                int maxSpeed;
                int ret = Interop.WiFi.AP.GetMaxSpeed(_apHandle, out maxSpeed);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get max speed, Error - " + (WiFiError)ret);
                }
                return maxSpeed;
            }
        }
        /// <summary>
        /// A property to check whether the access point is favorite or not.
        /// </summary>
        public bool IsFavorite
        {
            get
            {
                bool isFavorite;
                int ret = Interop.WiFi.AP.IsFavorite(_apHandle, out isFavorite);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get favorite, Error - " + (WiFiError)ret);
                }
                return isFavorite;
            }
        }
        /// <summary>
        /// A property to check whether the access point is passpoint or not.
        /// </summary>
        public bool IsPasspoint
        {
            get
            {
                bool isPasspoint;
                Log.Debug(Globals.LogTag, "Handle: " + _apHandle);
                int ret = Interop.WiFi.AP.IsPasspoint(_apHandle, out isPasspoint);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get isPassport, Error - " + (WiFiError)ret);
                }
                return isPasspoint;
            }
        }
        /// <summary>
        /// The connection state.
        /// </summary>
        public WiFiConnectionState ConnectionState
        {
            get
            {
                int state;
                int ret = Interop.WiFi.AP.GetConnectionState(_apHandle, out state);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get connection state, Error - " + (WiFiError)ret);
                }
                return (WiFiConnectionState)state;
            }
        }

        internal WiFiNetwork(IntPtr apHandle)
        {
            _apHandle = apHandle;
            _ipv4 = new WiFiAddressInformation(apHandle, AddressFamily.IPv4);
            _ipv6 = new WiFiAddressInformation(apHandle, AddressFamily.IPv6);

            IntPtr strPtr;
            int ret = Interop.WiFi.AP.GetEssid(_apHandle, out strPtr);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get essid, Error - " + (WiFiError)ret);
            }
            _essid = Marshal.PtrToStringAnsi(strPtr);
        }

        ~WiFiNetwork()
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
                _ipv4.Dispose();
                _ipv6.Dispose();
            }
            _apHandle = IntPtr.Zero;
            disposed = true;
        }

    } //WiFiNetworkInformation
}
