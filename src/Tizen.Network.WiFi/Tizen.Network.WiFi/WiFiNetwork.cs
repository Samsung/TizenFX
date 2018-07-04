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
    /// A class for managing the Wi-Fi network information.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class WiFiNetwork
    {
        private Interop.WiFi.SafeWiFiAPHandle _apHandle;
        private IAddressInformation _ipv4;
        private IAddressInformation _ipv6;
        private string _essid;

        /// <summary>
        /// The Extended Service Set Identifier (ESSID).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>ESSID of the Wi-Fi.</value>
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
                        Interop.Libc.Free(strPtr);
                    }
                }
                return _essid;
            }
        }

        /// <summary>
        /// The raw Service Set Identifier (SSID).
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        /// <value>Raw SSID of the Wi-Fi.</value>
        public byte[] RawSsid
        {
            get
            {
                IntPtr ptr;
                byte[] rawSsid;
                int length;
                int ret = Interop.WiFi.AP.GetRawSsid(_apHandle, out ptr, out length);
                if (ret != (int)WiFiError.None || length == 0)
                {
                    Log.Error(Globals.LogTag, "Failed to get raw essid, Error - " + (WiFiError)ret);
                    rawSsid = null;
                }
                else
                {
                    rawSsid = new byte[length];
                    Marshal.Copy(ptr, rawSsid, 0, length);
                    Interop.Libc.Free(ptr);
                }
                return rawSsid;
            }
        }

        /// <summary>
        /// The Basic Service Set Identifier (BSSID).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>BSSID of the Wi-Fi.</value>
        public string Bssid
        {
            get
            {
                string bssid;
                IntPtr strPtr;
                int ret = Interop.WiFi.AP.GetBssid(_apHandle, out strPtr);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get bssid, Error - " + (WiFiError)ret);
                    bssid = "";
                }
                else
                {
                    bssid = Marshal.PtrToStringAnsi(strPtr);
                }
                return bssid;
            }
        }

        /// <summary>
        /// The address information for IPv4.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>IP address information for IPv4 type.</value>
        public IAddressInformation IPv4Setting
        {
            get
            {
                return _ipv4;
            }
        }

        /// <summary>
        /// The address information for IPv6.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>IP address information for IPv6 type.</value>
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
        /// <since_tizen> 3 </since_tizen>
        /// <value>Represents the proxy address of the Wi-Fi.</value>
        /// <exception cref="NotSupportedException">Thrown while setting this property when Wi-Fi is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown while setting this property due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown while setting this value due to an invalid operation.</exception>
        public string ProxyAddress
        {
            get
            {
                string proxy;
                IntPtr strPtr;
                int ret = Interop.WiFi.AP.GetProxyAddress(_apHandle, (int)AddressFamily.IPv4, out strPtr);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get proxy address, Error - " + (WiFiError)ret);
                    proxy = "";
                }
                else
                {
                    proxy = Marshal.PtrToStringAnsi(strPtr);
                }
                return proxy;
            }
            set
            {
                int ret = Interop.WiFi.AP.SetProxyAddress(_apHandle, (int)AddressFamily.IPv4, value);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set proxy address, Error - " + (WiFiError)ret);
                    WiFiErrorFactory.ThrowWiFiException(ret, _apHandle.DangerousGetHandle());
                }
            }
        }

        /// <summary>
        /// The proxy type (IPv6).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>Represents the proxy type of the Wi-Fi.</value>
        /// <exception cref="NotSupportedException">Thrown while setting this property when Wi-Fi is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown while setting this property due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown while setting this value due to an invalid operation.</exception>
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
                    WiFiErrorFactory.ThrowWiFiException(ret, _apHandle.DangerousGetHandle());
                }
            }
        }

        /// <summary>
        /// The frequency band (MHz).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>Represents the frequency band value.</value>
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
        /// The received signal strength indicator (RSSI).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>Represents RSSI of Wi-Fi (dbm).</value>
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
        /// The Received signal strength indication(RSSI).
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <value>Represents Rssi level of WiFi.</value>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
        /// <exception cref="NotSupportedException">Thrown while setting this property when WiFi is not supported.</exception>
        public WiFiRssiLevel RssiLevel
        {
            get
            {
                int rssi;
                int ret = Interop.WiFi.AP.GetRssiLevel(_apHandle, out rssi);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get rssi level, Error - " + (WiFiError)ret);
                }
                return (WiFiRssiLevel)rssi;
            }
        }

        /// <summary>
        /// The max speed (Mbps).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>Represents the max speed value.</value>
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
        /// A property to check whether the access point is a favorite or not.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>Boolean value to check if the access point is a favorite or not.</value>
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
        /// A property to check whether the access point is a passpoint or not.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>Boolean value to check if the access point is a passpoint or not.</value>
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
        /// <since_tizen> 3 </since_tizen>
        /// <value>Represents the connection state of the Wi-Fi.</value>
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

        /// <summary>
        /// The raw country code
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        /// <value>Represents the raw country code of the Wi-Fi.</value>
        public string CountryCode
        {
            get
            {
                string code;
                IntPtr strPtr;
                int ret = Interop.WiFi.AP.GetCountryCode(_apHandle, out strPtr);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get country code, Error - " + (WiFiError)ret);
                    code = "";
                }
                else
                {
                    code = Marshal.PtrToStringAnsi(strPtr);
                    Interop.Libc.Free(strPtr);
                }
                return code;
            }
        }

        /// <summary>
        /// Gets all IPv6 addresses of the access point.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>A list of IPv6 addresses of the access point.</returns>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
        /// <exception cref="NotSupportedException">Thrown when the Wi-Fi is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when the method failed due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        public IEnumerable<System.Net.IPAddress> GetAllIPv6Addresses()
        {
            Log.Debug(Globals.LogTag, "GetAllIPv6Addresses");
            List<System.Net.IPAddress> ipList = new List<System.Net.IPAddress>();
            Interop.WiFi.HandleCallback callback = (IntPtr ipv6Address, IntPtr userData) =>
            {
                if (ipv6Address != IntPtr.Zero)
                {
                    string ipv6 = Marshal.PtrToStringAnsi(ipv6Address);
                    if (ipv6.Length == 0)
                        ipList.Add(System.Net.IPAddress.Parse("::"));
                    else
                        ipList.Add(System.Net.IPAddress.Parse(ipv6));
                    return true;
                }
                return false;
            };

            int ret = Interop.WiFi.AP.GetAllIPv6Addresses(_apHandle, callback, IntPtr.Zero);
            if (ret != (int)WiFiError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get all IPv6 addresses, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret, _apHandle.DangerousGetHandle());
            }

            return ipList;
        }

        /// <summary>
        /// Gets the Bssid list
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        /// <returns>A list of BSSIDs of access points with the same SSID as that of this access point.</returns>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
        /// <exception cref="NotSupportedException">Thrown when the Wi-Fi is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        public IEnumerable<string> GetBssids()
        {
            Log.Debug(Globals.LogTag, "GetBssids");
            List<string> bssidList = new List<string>();
            Interop.WiFi.AP.FoundBssidCallback callback = (string bssid, int rssi, int freq, IntPtr userData) =>
            {
                if (string.IsNullOrEmpty(bssid))
                {
                    bssidList.Add(bssid);
                    return true;
                }
                return false;
            };

            int ret = Interop.WiFi.AP.GetBssids(_apHandle, callback, IntPtr.Zero);
            if (ret != (int)WiFiError.None)
            {
                if (ret == (int)WiFiError.InvalidParameterError)
                {
                    throw new InvalidOperationException("Invalid handle");
                }
                Log.Error(Globals.LogTag, "Failed to get BSSIDs, Error - " + (WiFiError)ret);
                WiFiErrorFactory.ThrowWiFiException(ret, _apHandle.DangerousGetHandle());
            }

            return bssidList;
        }

        internal WiFiNetwork(Interop.WiFi.SafeWiFiAPHandle apHandle)
        {
            _apHandle = apHandle;
            _ipv4 = new WiFiAddressInformation(apHandle, AddressFamily.IPv4);
            _ipv6 = new WiFiAddressInformation(apHandle, AddressFamily.IPv6);

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
    } //WiFiNetworkInformation
}
