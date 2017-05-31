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
using System.Collections;
using System.Runtime.InteropServices;

namespace Tizen.Network.Connection
{
    /// <summary>
    /// This interface provides properties to manage address information of the connection.
    /// </summary>
    public interface IAddressInformation
    {
        /// <summary>
        /// The DNS address.
        /// </summary>
        /// <value>First DNS address of the connection.</value>
        /// <exception cref="System.NotSupportedException">Thrown during set when feature is not supported.</exception>
        /// <exception cref="System.ArgumentException">Thrown during set when value is invalid parameter.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown during set when profile instance is invalid or when method failed due to invalid operation.</exception>
        System.Net.IPAddress Dns1 { get; set; }

        /// <summary>
        /// The DNS address.
        /// </summary>
        /// <value>Second DNS address of the connection.</value>
        /// <exception cref="System.NotSupportedException">Thrown during set when feature is not supported.</exception>
        /// <exception cref="System.ArgumentException">Thrown during set when value is invalid parameter.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown during set when profile instance is invalid or when method failed due to invalid operation.</exception>
        System.Net.IPAddress Dns2 { get; set; }

        /// <summary>
        /// The gateway address.
        /// </summary>
        /// <value>Gateway address of the connection.</value>
        /// <exception cref="System.NotSupportedException">Thrown during set when feature is not supported.</exception>
        /// <exception cref="System.ArgumentException">Thrown during set when value is invalid parameter.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown during set when profile instance is invalid or when method failed due to invalid operation.</exception>
        System.Net.IPAddress Gateway { get; set; }

        /// <summary>
        /// The subnet mask address.
        /// </summary>
        /// <value>Subnet mask of the connection.</value>
        /// <exception cref="System.NotSupportedException">Thrown during set when feature is not supported.</exception>
        /// <exception cref="System.ArgumentException">Thrown during set when value is invalid parameter.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown during set when profile instance is invalid or when method failed due to invalid operation.</exception>
        System.Net.IPAddress SubnetMask { get; set; }

        /// <summary>
        /// The IP address.
        /// </summary>
        /// <value>IP address of the connection.</value>
        /// <exception cref="System.NotSupportedException">Thrown during set when feature is not supported.</exception>
        /// <exception cref="System.ArgumentException">Thrown during set when value is invalid parameter.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown during set when profile instance is invalid or when method failed due to invalid operation.</exception>
        System.Net.IPAddress IP { get; set; }

        /// <summary>
        /// The type of IP config.
        /// </summary>
        /// <value>IP config type of the connection.</value>
        /// <exception cref="System.NotSupportedException">Thrown during set when feature is not supported.</exception>
        /// <exception cref="System.ArgumentException">Thrown during set when value is invalid parameter.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown during set when profile instance is invalid or when method failed due to invalid operation.</exception>
        IPConfigType IPConfigType { get; set; }

        /// <summary>
        /// The prefix length.
        /// </summary>
        /// <value>Prefix length of the connection.</value>
        /// <exception cref="System.NotSupportedException">Thrown during set when feature is not supported.</exception>
        /// <exception cref="System.ArgumentException">Thrown during set when value is invalid parameter.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown during set when profile instance is invalid or when method failed due to invalid operation.</exception>
        int PrefixLength { get; set; }

        /// <summary>
        /// The DNS config type.
        /// </summary>
        /// <value>Config type of the DNS.</value>
        /// <exception cref="System.NotSupportedException">Thrown during set when feature is not supported.</exception>
        /// <exception cref="System.ArgumentException">Thrown during set when value is invalid parameter.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown during set when profile instance is invalid or when method failed due to invalid operation.</exception>
        DnsConfigType DnsConfigType { get; set; }
    }

    internal class ConnectionAddressInformation : IAddressInformation
    {
        private IntPtr _profileHandle;
        private AddressFamily _family;

        internal ConnectionAddressInformation(IntPtr handle, AddressFamily family)
        {
            _profileHandle = handle;
            _family = family;
        }

        public System.Net.IPAddress Dns1
        {
            get
            {
                IntPtr Value;
                int ret = Interop.ConnectionProfile.GetDnsAddress(_profileHandle, 1, (int)_family, out Value);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get dns1 address, " + (ConnectionError)ret);
                }
                string result = Marshal.PtrToStringAnsi(Value);
                Interop.Libc.Free(Value);
                if (result == null)
                    return System.Net.IPAddress.Parse("0.0.0.0");
                return System.Net.IPAddress.Parse(result);
            }

            set
            {
                int ret = Interop.ConnectionProfile.SetDnsAddress(_profileHandle, (int)_family, value.ToString());
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to set dns1 address, " + (ConnectionError)ret);
                    ConnectionErrorFactory.CheckFeatureUnsupportedException(ret, "http://tizen.org/feature/network.telephony " + "http://tizen.org/feature/network.wifi " + "http://tizen.org/feature/network.tethering.bluetooth " + "http://tizen.org/feature/network.ethernet");
                    ConnectionErrorFactory.CheckHandleNullException(ret, (_profileHandle == IntPtr.Zero), "ProfileHandle may have been disposed or released");
                    ConnectionErrorFactory.ThrowConnectionException(ret);
                }
            }
        }
        public System.Net.IPAddress Dns2
        {
            get
            {
                IntPtr Value;
                int ret = Interop.ConnectionProfile.GetDnsAddress(_profileHandle, 2, (int)_family, out Value);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get dns2 address, " + (ConnectionError)ret);
                }
                string result = Marshal.PtrToStringAnsi(Value);
                Interop.Libc.Free(Value);
                if (result == null)
                    return System.Net.IPAddress.Parse("0.0.0.0");
                return System.Net.IPAddress.Parse(result);
            }

            set
            {
                int ret = Interop.ConnectionProfile.SetDnsAddress(_profileHandle, (int)_family, value.ToString());
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to set dns2 address, " + (ConnectionError)ret);
                    ConnectionErrorFactory.CheckFeatureUnsupportedException(ret, "http://tizen.org/feature/network.telephony " + "http://tizen.org/feature/network.wifi " + "http://tizen.org/feature/network.tethering.bluetooth " + "http://tizen.org/feature/network.ethernet");
                    ConnectionErrorFactory.CheckHandleNullException(ret, (_profileHandle == IntPtr.Zero), "ProfileHandle may have been disposed or released");
                    ConnectionErrorFactory.ThrowConnectionException(ret);
                }
            }
        }

        public System.Net.IPAddress Gateway
        {
            get
            {
                IntPtr Value;
                int ret = Interop.ConnectionProfile.GetGatewayAddress(_profileHandle, (int)_family, out Value);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get gateway, " + (ConnectionError)ret);
                }
                string result = Marshal.PtrToStringAnsi(Value);
                Interop.Libc.Free(Value);
                if (result == null)
                    return System.Net.IPAddress.Parse("0.0.0.0");
                return System.Net.IPAddress.Parse(result);
            }

            set
            {
                int ret = Interop.ConnectionProfile.SetGatewayAddress(_profileHandle, (int)_family, value.ToString());
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to set gateway, " + (ConnectionError)ret);
                    ConnectionErrorFactory.CheckFeatureUnsupportedException(ret, "http://tizen.org/feature/network.telephony " + "http://tizen.org/feature/network.wifi " + "http://tizen.org/feature/network.tethering.bluetooth " + "http://tizen.org/feature/network.ethernet");
                    ConnectionErrorFactory.CheckHandleNullException(ret, (_profileHandle == IntPtr.Zero), "ProfileHandle may have been disposed or released");
                    ConnectionErrorFactory.ThrowConnectionException(ret);
                }
            }
        }


        public System.Net.IPAddress SubnetMask
        {
            get
            {
                IntPtr Value;
                int ret = Interop.ConnectionProfile.GetSubnetMask(_profileHandle, (int)_family, out Value);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get subnet mask, " + (ConnectionError)ret);
                }
                string result = Marshal.PtrToStringAnsi(Value);
                Interop.Libc.Free(Value);
                if (result == null)
                    return System.Net.IPAddress.Parse("0.0.0.0");
                return System.Net.IPAddress.Parse(result);
            }

            set
            {
                int ret = Interop.ConnectionProfile.SetSubnetMask(_profileHandle, (int)_family, value.ToString());
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to set subnet mask, " + (ConnectionError)ret);
                    ConnectionErrorFactory.CheckFeatureUnsupportedException(ret, "http://tizen.org/feature/network.telephony " + "http://tizen.org/feature/network.wifi " + "http://tizen.org/feature/network.tethering.bluetooth " + "http://tizen.org/feature/network.ethernet");
                    ConnectionErrorFactory.CheckHandleNullException(ret, (_profileHandle == IntPtr.Zero), "ProfileHandle may have been disposed or released");
                    ConnectionErrorFactory.ThrowConnectionException(ret);
                }
            }
        }


        public System.Net.IPAddress IP
        {
            get
            {
                IntPtr Value;
                int ret = Interop.ConnectionProfile.GetIPAddress(_profileHandle, (int)_family, out Value);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get ip, " + (ConnectionError)ret);
                }
                string result = Marshal.PtrToStringAnsi(Value);
                Interop.Libc.Free(Value);
                if (result == null)
                    return System.Net.IPAddress.Parse("0.0.0.0");
                return System.Net.IPAddress.Parse(result);
            }

            set
            {
                int ret = Interop.ConnectionProfile.SetIPAddress(_profileHandle, (int)_family, value.ToString());
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to set ip, " + (ConnectionError)ret);
                    ConnectionErrorFactory.CheckFeatureUnsupportedException(ret, "http://tizen.org/feature/network.telephony " + "http://tizen.org/feature/network.wifi " + "http://tizen.org/feature/network.tethering.bluetooth " + "http://tizen.org/feature/network.ethernet");
                    ConnectionErrorFactory.CheckHandleNullException(ret, (_profileHandle == IntPtr.Zero), "ProfileHandle may have been disposed or released");
                    ConnectionErrorFactory.ThrowConnectionException(ret);
                }
            }
        }

        public IPConfigType IPConfigType
        {
            get
            {
                int Value;
                int ret = Interop.ConnectionProfile.GetIPConfigType(_profileHandle, (int)_family, out Value);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get ip config type, " + (ConnectionError)ret);
                }
                return (IPConfigType)Value;
            }

            set
            {
                int ret = Interop.ConnectionProfile.SetIPConfigType(_profileHandle, (int)_family, (int)value);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to set ip config type, " + (ConnectionError)ret);
                    ConnectionErrorFactory.CheckFeatureUnsupportedException(ret, "http://tizen.org/feature/network.telephony " + "http://tizen.org/feature/network.wifi " + "http://tizen.org/feature/network.tethering.bluetooth " + "http://tizen.org/feature/network.ethernet");
                    ConnectionErrorFactory.CheckHandleNullException(ret, (_profileHandle == IntPtr.Zero), "ProfileHandle may have been disposed or released");
                    ConnectionErrorFactory.ThrowConnectionException(ret);
                }
            }
        }

        public int PrefixLength
        {
            get
            {
                int Value;
                int ret = Interop.ConnectionProfile.GetPrefixLength(_profileHandle, (int)_family, out Value);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get prefix length, " + (ConnectionError)ret);
                }
                return Value;
            }

            set
            {
                int ret = Interop.ConnectionProfile.SetPrefixLength(_profileHandle, (int)_family, value);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to set prefix length, " + (ConnectionError)ret);
                    ConnectionErrorFactory.CheckFeatureUnsupportedException(ret, "http://tizen.org/feature/network.telephony " + "http://tizen.org/feature/network.wifi " + "http://tizen.org/feature/network.tethering.bluetooth " + "http://tizen.org/feature/network.ethernet");
                    ConnectionErrorFactory.CheckHandleNullException(ret, (_profileHandle == IntPtr.Zero), "ProfileHandle may have been disposed or released");
                    ConnectionErrorFactory.ThrowConnectionException(ret);
                }
            }
        }

        public DnsConfigType DnsConfigType
        {
            get
            {
                int Value;
                int ret = Interop.ConnectionProfile.GetDnsConfigType(_profileHandle, (int)_family, out Value);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get DNS config type, " + (ConnectionError)ret);
                }
                return (DnsConfigType)Value;
            }

            set
            {
                int ret = Interop.ConnectionProfile.SetDnsConfigType(_profileHandle, (int)_family, (int)value);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to set DNS config type, " + (ConnectionError)ret);
                    ConnectionErrorFactory.CheckFeatureUnsupportedException(ret, "http://tizen.org/feature/network.telephony " + "http://tizen.org/feature/network.wifi " + "http://tizen.org/feature/network.tethering.bluetooth " + "http://tizen.org/feature/network.ethernet");
                    ConnectionErrorFactory.CheckHandleNullException(ret, (_profileHandle == IntPtr.Zero), "ProfileHandle may have been disposed or released");
                    ConnectionErrorFactory.ThrowConnectionException(ret);
                }
            }
        }
    }
}
