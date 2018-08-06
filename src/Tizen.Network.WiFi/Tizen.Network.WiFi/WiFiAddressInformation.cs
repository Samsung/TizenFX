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
using System.Net;
using Tizen.Network.Connection;

namespace Tizen.Network.WiFi
{
    internal class WiFiAddressInformation : IAddressInformation
    {
        private Interop.WiFi.SafeWiFiAPHandle _handle;
        private AddressFamily _family;

        internal WiFiAddressInformation(Interop.WiFi.SafeWiFiAPHandle handle, AddressFamily family)
        {
            _handle = handle;
            _family = family;
        }

        public System.Net.IPAddress Dns1
        {
            get
            {
                IntPtr addrPtr;
                int ret = Interop.WiFi.AP.GetDnsAddress(_handle, 1, (int)_family, out addrPtr);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get first dns address, Error - " + (WiFiError)ret);
                    return System.Net.IPAddress.Parse("0.0.0.0");
                }
                string addrStr = Marshal.PtrToStringAnsi(addrPtr);
                Interop.Libc.Free(addrPtr);
                if (addrStr == null || addrStr.Length == 0)
                    return System.Net.IPAddress.Parse("0.0.0.0");
                return System.Net.IPAddress.Parse(addrStr);
            }
            set
            {
                int ret = Interop.WiFi.AP.SetDnsAddress(_handle, 1, (int)_family, value.ToString());
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set first dns address, Error - " + (WiFiError)ret);
                    WiFiErrorFactory.ThrowWiFiException(ret, _handle.DangerousGetHandle());
                }
            }
        }

        public System.Net.IPAddress Dns2
        {
            get
            {
                IntPtr addrPtr;
                int ret = Interop.WiFi.AP.GetDnsAddress(_handle, 2, (int)_family, out addrPtr);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get second dns address, Error - " + (WiFiError)ret);
                    return System.Net.IPAddress.Parse("0.0.0.0");
                }
                string addrStr = Marshal.PtrToStringAnsi(addrPtr);
                Interop.Libc.Free(addrPtr);
                if (addrStr == null || addrStr.Length == 0)
                    return System.Net.IPAddress.Parse("0.0.0.0");
                return System.Net.IPAddress.Parse(addrStr);
            }
            set
            {
                int ret = Interop.WiFi.AP.SetDnsAddress(_handle, 2, (int)_family, value.ToString());
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set second dns address, Error - " + (WiFiError)ret);
                    WiFiErrorFactory.ThrowWiFiException(ret, _handle.DangerousGetHandle());
                }
            }
        }

        public System.Net.IPAddress Gateway
        {
            get
            {
                IntPtr addrPtr;
                int ret = Interop.WiFi.AP.GetGatewayAddress(_handle, (int)_family, out addrPtr);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get gateway address, Error - " + (WiFiError)ret);
                    return System.Net.IPAddress.Parse("0.0.0.0");
                }
                string addrStr = Marshal.PtrToStringAnsi(addrPtr);
                Interop.Libc.Free(addrPtr);
                if (addrStr == null || addrStr.Length == 0)
                    return System.Net.IPAddress.Parse("0.0.0.0");
                return System.Net.IPAddress.Parse(addrStr);
            }
            set
            {
                int ret = Interop.WiFi.AP.SetGatewayAddress(_handle, (int)_family, value.ToString());
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set gateway address, Error - " + (WiFiError)ret);
                    WiFiErrorFactory.ThrowWiFiException(ret, _handle.DangerousGetHandle());
                }
            }
        }

        public System.Net.IPAddress SubnetMask
        {
            get
            {
                IntPtr addrPtr;
                int ret = Interop.WiFi.AP.GetSubnetMask(_handle, (int)_family, out addrPtr);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get subnet mask, Error - " + (WiFiError)ret);
                    return System.Net.IPAddress.Parse("0.0.0.0");
                }
                string addrStr = Marshal.PtrToStringAnsi(addrPtr);
                Interop.Libc.Free(addrPtr);
                if (addrStr == null || addrStr.Length == 0)
                    return System.Net.IPAddress.Parse("0.0.0.0");
                return System.Net.IPAddress.Parse(addrStr);
            }
            set
            {
                int ret = Interop.WiFi.AP.SetSubnetMask(_handle, (int)_family, value.ToString());
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set subnet mask, Error - " + (WiFiError)ret);
                    WiFiErrorFactory.ThrowWiFiException(ret, _handle.DangerousGetHandle());
                }
            }
        }

        public System.Net.IPAddress IP
        {
            get
            {
                IntPtr addrPtr;
                int ret = Interop.WiFi.AP.GetIPAddress(_handle, (int)_family, out addrPtr);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get ip address, Error - " + (WiFiError)ret);
                    return System.Net.IPAddress.Parse("0.0.0.0");
                }
                string addrStr = Marshal.PtrToStringAnsi(addrPtr);
                Interop.Libc.Free(addrPtr);
                if (addrStr == null || addrStr.Length == 0)
                    return System.Net.IPAddress.Parse("0.0.0.0");
                return System.Net.IPAddress.Parse(addrStr);
            }
            set
            {
                int ret = Interop.WiFi.AP.SetIPAddress(_handle, (int)_family, value.ToString());
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set ip address, Error - " + (WiFiError)ret);
                    WiFiErrorFactory.ThrowWiFiException(ret, _handle.DangerousGetHandle());
                }
            }
        }

        public IPConfigType IPConfigType
        {
            get
            {
                int type;
                int ret = Interop.WiFi.AP.GetIPConfigType(_handle, (int)_family, out type);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get ip config type, Error - " + (WiFiError)ret);
                }
                return (IPConfigType)type;
            }
            set
            {
                int ret = Interop.WiFi.AP.SetIPConfigType(_handle, (int)_family, (int)value);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set ip config type, Error - " + (WiFiError)ret);
                    WiFiErrorFactory.ThrowWiFiException(ret, _handle.DangerousGetHandle());
                }
            }
        }

        public int PrefixLength
        {
            get
            {
                int Value;
                int ret = Interop.WiFi.AP.GetPrefixLength(_handle, (int)_family, out Value);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get prefix length, " + (WiFiError)ret);
                    return -1;
                }
                return Value;
            }

            set
            {
                int ret = Interop.WiFi.AP.SetPrefixLength(_handle, (int)_family, value);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to set prefix length, " + (WiFiError)ret);
                    WiFiErrorFactory.ThrowWiFiException(ret, _handle.DangerousGetHandle());
                }
            }
        }

        public DnsConfigType DnsConfigType
        {
            get
            {
                int Value;
                int ret = Interop.WiFi.AP.GetDnsConfigType(_handle, (int)_family, out Value);
                if ((WiFiError)ret != WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get DNS config type, " + (WiFiError)ret);
                }
                return (DnsConfigType)Value;
            }
            set
            {
                int ret = Interop.WiFi.AP.SetDnsConfigType(_handle, (int)_family, (int)value);
                if ((WiFiError)ret != WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to set DNS config type, " + (WiFiError)ret);
                    WiFiErrorFactory.ThrowWiFiException(ret, _handle.DangerousGetHandle());
                }
            }
        }

        /// <summary>
        /// DHCP server address. It is only supported for IPv4 address family.
        /// </summary>
        /// <value>Represents DHCP server address.</value>
        public System.Net.IPAddress DhcpServerAddress
        {
            get
            {
                string dhcpServer;
                int ret = Interop.WiFi.AP.GetDhcpServerAddress(_handle, AddressFamily.IPv4, out dhcpServer);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get DHCP server address, Error - " + (WiFiError)ret);
                }

                if (dhcpServer == null || dhcpServer.Length == 0)
                {
                    return IPAddress.Parse("0.0.0.0");
                }

                return IPAddress.Parse(dhcpServer);
            }
        }

        /// <summary>
        /// DHCP lease duration. It is only supported for IPv4 address family.
        /// </summary>
        /// <value>Represents DHCP lease duration.</value>
        public int  DhcpLeaseDuration
        {
            get
            {
                int leaseDuration;
                int ret = Interop.WiFi.AP.GetDhcpLeaseDuration(_handle, AddressFamily.IPv4, out leaseDuration);
                if (ret != (int)WiFiError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get DHCP lease duration, Error - " + (WiFiError)ret);
                    return 0;
                }

                return leaseDuration;
            }
        }
    }
}
