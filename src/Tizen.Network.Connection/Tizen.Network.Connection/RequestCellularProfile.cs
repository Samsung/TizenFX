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


namespace Tizen.Network.Connection
{
    /// <summary>
    /// This Class is RequestCellularProfile.
    /// CellularServiceType should be set before AddProfile method of ConnectionProfileManager is called.
    /// </summary>
    public class RequestCellularProfile : RequestProfile
    {
        internal IntPtr ProfileHandle = IntPtr.Zero;
        private IAddressInformation Ipv4;
        private IAddressInformation Ipv6;
        private bool disposed = false;

        private CellularAuthInformation AuthInfo;
        /// <summary>
        /// The constructor of CellularProfile class with profile type and keyword.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        internal RequestCellularProfile(IntPtr handle)
        {
            Log.Debug(Globals.LogTag, "RequestCellularProfile is created : " + handle);

            ProfileHandle = handle;
            Ipv4 = new ConnectionAddressInformation(ProfileHandle, AddressFamily.Ipv4);
            Ipv6 = new ConnectionAddressInformation(ProfileHandle, AddressFamily.Ipv6);
            AuthInfo = new CellularAuthInformation(ProfileHandle);
        }

        /// <summary>
        /// The destructor of CellularProfile class
        /// </summary>
        ~RequestCellularProfile()
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
            Interop.ConnectionProfile.Destroy(ProfileHandle);
            disposed = true;
        }

        /// <summary>
        /// Gets the network type.
        /// </summary>
        public ConnectionProfileType Type
        {
            get
            {
                int Value;
                int ret = Interop.ConnectionProfile.GetType(ProfileHandle, out Value);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get profile type, " + (ConnectionError)ret);
                }
                return (ConnectionProfileType)Value;
            }
        }

        /// <summary>
        /// Gets the Proxy type.
        /// </summary>
        public ProxyType ProxyType
        {
            get
            {
                int Value;
                int ret = Interop.ConnectionProfile.GetProxyType(ProfileHandle, out Value);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get proxy type, " + (ConnectionError)ret);
                }
                return (ProxyType)Value;

            }
            set
            {
                int ret = Interop.ConnectionProfile.SetProxyType(ProfileHandle, (int)value);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to set proxy type, " + (ConnectionError)ret);
                    ConnectionErrorFactory.ThrowConnectionException(ret);
                }
            }
        }

        /// <summary>
        /// The proxy address.
        /// </summary>
        public System.Net.IPAddress ProxyAddress
        {
            get
            {
                IntPtr Value;
                int ret = Interop.ConnectionProfile.GetProxyAddress(ProfileHandle, (int)AddressFamily.Ipv4, out Value);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get proxy address, " + (ConnectionError)ret);
                }
                string result = Marshal.PtrToStringAnsi(Value);
                Interop.Libc.Free(Value);
                if (result == null)
                    return System.Net.IPAddress.Parse("0.0.0.0");
                return System.Net.IPAddress.Parse(result);

            }
            set
            {
                int ret = Interop.ConnectionProfile.SetProxyAddress(ProfileHandle, (int)AddressFamily.Ipv4, value.ToString());
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to set proxy address, " + (ConnectionError)ret);
                    ConnectionErrorFactory.ThrowConnectionException(ret);
                }
            }

        }

        /// <summary>
        /// The subnet mask address(Ipv4).
        /// </summary>
        public IAddressInformation Ipv4Settings
        {
            get
            {
                return Ipv4;
            }
        }


        /// <summary>
        /// The subnet mask address(Ipv4).
        /// </summary>
        public IAddressInformation Ipv6Settings
        {
            get
            {
                return Ipv6;
            }
        }

        /// <summary>
        /// Gets the APN (access point name).
        /// </summary>
        public string Apn
        {
            get
            {
                IntPtr Value;
                int ret = Interop.ConnectionCellularProfile.GetApn(ProfileHandle, out Value);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get apn, " + (ConnectionError)ret);
                }
                string result = Marshal.PtrToStringAnsi(Value);
                Interop.Libc.Free(Value);
                return result;
            }
            set
            {
                int ret = Interop.ConnectionCellularProfile.SetApn(ProfileHandle, (string)value);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to set apn, " + (ConnectionError)ret);
                    ConnectionErrorFactory.ThrowConnectionException(ret);
                }
            }
        }

        /// <summary>
        /// Gets the home URL.
        /// </summary>
        public string HomeUri
        {
            get
            {
                IntPtr Value;
                int ret = Interop.ConnectionCellularProfile.GetHomeUrl(ProfileHandle, out Value);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get home uri, " + (ConnectionError)ret);
                }
                string result = Marshal.PtrToStringAnsi(Value);
                Interop.Libc.Free(Value);
                return result;
            }
            set
            {
                int ret = Interop.ConnectionCellularProfile.SetHomeUrl(ProfileHandle, value);
                Log.Error(Globals.LogTag, "home uri  " + value);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to set home uri, " + (ConnectionError)ret);
                    ConnectionErrorFactory.ThrowConnectionException(ret);
                }
            }
        }

        /// <summary>
        /// Gets the service type.
        /// </summary>
        public CellularServiceType ServiceType
        {
            get
            {
                int value;
                int ret = Interop.ConnectionCellularProfile.GetServiceType(ProfileHandle, out value);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to get service type, " + (ConnectionError)ret);
                }
                return (CellularServiceType)value;
            }
            set
            {
                int ret = Interop.ConnectionCellularProfile.SetServiceType(ProfileHandle, (int)value);
                if ((ConnectionError)ret != ConnectionError.None)
                {
                    Log.Error(Globals.LogTag, "It failed to set service type, " + (ConnectionError)ret);
                    ConnectionErrorFactory.ThrowConnectionException(ret);
                }
            }
        }

        /// <summary>
        /// Gets cellular Authentification Information.
        /// </summary>
        public CellularAuthInformation CellularAuthInfo
        {
            get
            {
                return AuthInfo;
            }
        }
    }
}
