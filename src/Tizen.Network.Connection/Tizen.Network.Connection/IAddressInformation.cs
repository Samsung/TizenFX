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
    public interface IAddressInformation : IDisposable
    {
        /// <summary>
        /// The DNS address.
        /// </summary>
        System.Net.IPAddress Dns1 { get; set; }

        /// <summary>
        /// The DNS address.
        /// </summary>
        System.Net.IPAddress Dns2 { get; set; }

        /// <summary>
        /// The gateway address.
        /// </summary>
        System.Net.IPAddress Gateway { get; set; }

        /// <summary>
        /// The subnet mask address.
        /// </summary>
        System.Net.IPAddress SubnetMask { get; set; }

        /// <summary>
        /// The IP address.
        /// </summary>
        System.Net.IPAddress Ip { get; set; }

        /// <summary>
        /// The type of IP config.
        /// </summary>
        IpConfigType IpConfigType { get; set; }
    }

    internal class ConnectionAddressInformation : IAddressInformation
    {
        private IntPtr _profileHandle;
        private AddressFamily _family;
        private bool _disposed = false;

        internal ConnectionAddressInformation(IntPtr handle, AddressFamily family)
        {
            _profileHandle = handle;
            _family = family;
        }

        ~ConnectionAddressInformation()
        {
            Dispose(false);
        }

        protected void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                // Release managed resources.
            }
            // Release unmanaged resources.
            _disposed = true;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
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
                    ConnectionErrorFactory.ThrowConnectionException(ret);
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
                    ConnectionErrorFactory.ThrowConnectionException(ret);
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
                    ConnectionErrorFactory.ThrowConnectionException(ret);
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
                    ConnectionErrorFactory.ThrowConnectionException(ret);
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
                    ConnectionErrorFactory.ThrowConnectionException(ret);
                }
            }
        }


        public System.Net.IPAddress Ip
        {
            get
            {
                IntPtr Value;
                int ret = Interop.ConnectionProfile.GetIpAddress(_profileHandle, (int)_family, out Value);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get ip, " + (ConnectionError)ret);
                    ConnectionErrorFactory.ThrowConnectionException(ret);
                }
                string result = Marshal.PtrToStringAnsi(Value);
                Interop.Libc.Free(Value);
                if (result == null)
                    return System.Net.IPAddress.Parse("0.0.0.0");
                return System.Net.IPAddress.Parse(result);
            }
            set
            {
                int ret = Interop.ConnectionProfile.SetIpAddress(_profileHandle, (int)_family, value.ToString());
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to set ip, " + (ConnectionError)ret);
                    ConnectionErrorFactory.ThrowConnectionException(ret);
                }
            }
        }

        public IpConfigType IpConfigType
        {
            get
            {
                int Value;
                int ret = Interop.ConnectionProfile.GetIpConfigType(_profileHandle, (int)_family, out Value);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get ip config type, " + (ConnectionError)ret);
                    ConnectionErrorFactory.ThrowConnectionException(ret);
                }
                return (IpConfigType)Value;
            }
            set
            {
                int ret = Interop.ConnectionProfile.SetIpConfigType(_profileHandle, (int)_family, (int)value);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to set ip config type, " + (ConnectionError)ret);
                    ConnectionErrorFactory.ThrowConnectionException(ret);
                }
            }
        }
    }
}
