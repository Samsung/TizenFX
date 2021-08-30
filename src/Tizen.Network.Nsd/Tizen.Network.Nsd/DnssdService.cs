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
using System.Text;
using System.Threading;
using System.Net;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace Tizen.Network.Nsd
{
    internal class DnssdInitializer
    {
        internal DnssdInitializer()
        {
            Globals.DnssdInitialize();
        }

        ~DnssdInitializer()
        {
            int ret = Interop.Nsd.Dnssd.Deinitialize();
            if (ret != (int)DnssdError.None)
            {
                Log.Error(Globals.LogTag, "Failed to deinitialize Dnssd, Error - " + (DnssdError)ret);
            }
        }
    }
    /// <summary>
    /// This class is used for managing the local service registration and its properties using DNS-SD.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class DnssdService : INsdService
    {
        private uint _serviceHandle;
        private string _serviceType;
        private ushort _dnsRecordtype = 16;
        private Interop.Nsd.Dnssd.ServiceRegisteredCallback _serviceRegisteredCallback;

        /// <summary>
        /// The constructor to create the DnssdService instance that sets the serviceType to a given value.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="serviceType">The DNS-SD service type. It is expressed as a type followed by the protocol, separated by a dot (For example, "_ftp._tcp").
        /// It must begin with an underscore followed by 1-15 characters, which may be letters, digits, or hyphens.
        /// </param>
        /// <feature>http://tizen.org/feature/network.service_discovery.dnssd</feature>
        /// <exception cref="NotSupportedException">Thrown while setting this property when DNS-SD is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when the serviceType is set to null.</exception>
        public DnssdService(string serviceType)
        {
            _serviceType = serviceType;
            DnssdInitializeCreateService();
        }

        internal DnssdService(uint service)
        {
            _serviceHandle = service;
        }

        internal void DnssdInitializeCreateService()
        {
            DnssdInitializer dnssdInit = Globals.s_threadDns.Value;
            Log.Info(Globals.LogTag, "Initialize ThreadLocal<DnssdInitializer> instance = " + dnssdInit);
            int ret = Interop.Nsd.Dnssd.CreateService(_serviceType, out _serviceHandle);
            if (ret != (int)DnssdError.None)
            {
                Log.Error(Globals.LogTag, "Failed to create a local Dnssd service handle, Error - " + (DnssdError)ret);
                NsdErrorFactory.ThrowDnssdException(ret);
            }
        }

        /// <summary>
        /// Name of the DNS-SD service.
        /// </summary>
        /// <remarks>
        /// Set the name for only an unregistered service created locally.
        /// It may be up to 63 bytes.
        /// In case of an error, null will be returned during get and exception will be thrown during set.
        /// </remarks>
        /// <since_tizen> 4 </since_tizen>
        /// <feature>http://tizen.org/feature/network.service_discovery.dnssd</feature>
        /// <exception cref="NotSupportedException">Thrown while setting this property when DNS-SD is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when the name value is set to null.</exception>
        /// <exception cref="InvalidOperationException">Thrown while setting this property when any other error occurred.</exception>
        public string Name
        {
            get
            {
                string name;
                int ret = Interop.Nsd.Dnssd.GetName(_serviceHandle, out name);
                if (ret != (int)DnssdError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get name of service, Error: " + (DnssdError)ret);
                    return null;
                }

                return name;
            }

            set
            {
                if (!Globals.s_threadDns.IsValueCreated)
                {
                    DnssdInitializeCreateService();
                }

                int ret = Interop.Nsd.Dnssd.SetName(_serviceHandle, value);
                if (ret != (int)DnssdError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set name of service, Error: " + (DnssdError)ret);
                    NsdErrorFactory.ThrowDnssdException(ret);
                }
            }
        }

        /// <summary>
        /// Type of the DNS-SD local or remote service.
        /// </summary>
        /// <remarks>
        /// It is expressed as a type followed by the protocol, separated by a dot (For example, "_ftp._tcp").
        /// It must begin with an underscore followed by 1-15 characters, which may be letters, digits, or hyphens.
        /// In case of an error, null will be returned.
        /// </remarks>
        /// <since_tizen> 4 </since_tizen>
        public string Type
        {
            get
            {
                string type;
                int ret = Interop.Nsd.Dnssd.GetType(_serviceHandle, out type);
                if (ret != (int)DnssdError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get type of service, Error: " + (DnssdError)ret);
                    return null;
                }

                return type;
            }
        }

        /// <summary>
        /// Port number of the DNS-SD local or remote service.
        /// </summary>
        /// <remarks>
        /// Set the port for only an unregistered service created locally. The default value of the port is 0.
        /// In case of an error, -1 will be returned during get and exception will be thrown during set.
        /// </remarks>
        /// <since_tizen> 4 </since_tizen>
        /// <feature>http://tizen.org/feature/network.service_discovery.dnssd</feature>
        /// <exception cref="NotSupportedException">Thrown while setting this property when DNS-SD is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown if the value of port is set to less than 0 or more than 65535.</exception>
        /// <exception cref="InvalidOperationException">Thrown while setting this property when any other error occurred.</exception>
        public int Port
        {
            get
            {
                int port;
                int ret = Interop.Nsd.Dnssd.GetPort(_serviceHandle, out port);
                if (ret != (int)DnssdError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get port number of Dnssd service, Error: " + (DnssdError)ret);
                    return -1;
                }

                return port;
            }

            set
            {
                if (!Globals.s_threadDns.IsValueCreated)
                {
                    DnssdInitializeCreateService();
                }

                int ret = Interop.Nsd.Dnssd.SetPort(_serviceHandle, value);
                if (ret != (int)DnssdError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set port number of Dnssd service, Error: " + (DnssdError)ret);
                    NsdErrorFactory.ThrowDnssdException(ret);
                }
            }
        }

        /// <summary>
        /// IP address of the DNS-SD remote service.
        /// </summary>
        /// <remarks>
        /// If the remote service has no IPv4 Address, then IPv4Address would contain null and if it has no IPv6 Address, then IPv6Address would contain null.
        /// In case of an error, null object will be returned.
        /// </remarks>
        /// <since_tizen> 4 </since_tizen>
        public IPAddressInformation IP
        {
            get
            {
                string IPv4, IPv6;
                int ret = Interop.Nsd.Dnssd.GetIP(_serviceHandle, out IPv4, out IPv6);
                if (ret != (int)DnssdError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get the IP of Dnssd remote service, Error: " + (DnssdError)ret);
                    return null;
                }

                IPAddressInformation IPAddressInstance = new IPAddressInformation(IPv4, IPv6);
                return IPAddressInstance;
            }
        }

        /// <summary>
        /// Returns raw TXT records.
        /// </summary>
        /// <returns>Returns empty bytes array in case TXT record has not been set, else returns raw TXT record.</returns>
        /// <since_tizen> 9 </since_tizen>
        /// <feature>http://tizen.org/feature/network.service_discovery.dnssd</feature>
        /// <exception cref="NotSupportedException">Thrown when DNS-SD is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when any other error occurred.</exception>
        public byte[] GetRawTXTRecords()
        {
            int ret = Interop.Nsd.Dnssd.GetAllTxtRecord(_serviceHandle, out ushort length, out IntPtr data);
            if (ret != (int)DnssdError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get the TXT record, Error: " + (DnssdError)ret);
                NsdErrorFactory.ThrowDnssdException(ret);
            }
            byte[] value = Array.Empty<byte>();
            if (length > 0)
            {
                value = new byte[length];
                Marshal.Copy(data, value, 0, length);
                Interop.Libc.Free(data);
            }
            return value;
        }

        /// <summary>
        /// Adds the TXT record.
        /// </summary>
        /// <remarks>
        /// TXT record should be added after registering the local service using RegisterService().
        /// </remarks>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="key">The key of the TXT record. It must be a null-terminated string with 9 characters or fewer excluding null. It is case insensitive.</param>
        /// <param name="value">The value of the TXT record. If null, then "key" will be added with no value. If non-null but the value_length is zero, then "key=" will be added with an empty value.</param>
        /// <feature>http://tizen.org/feature/network.service_discovery.dnssd</feature>
        /// <exception cref="NotSupportedException">Thrown when DNS-SD is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when the value of the key is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when any other error occurred.</exception>
        public void AddTXTRecord(string key, string value)
        {
            byte[] byteValue = Encoding.UTF8.GetBytes(value);
            ushort length = Convert.ToUInt16(byteValue.Length);
            int ret = Interop.Nsd.Dnssd.AddTxtRecord(_serviceHandle, key, length, byteValue);
            if (ret != (int)DnssdError.None)
            {
                Log.Error(Globals.LogTag, "Failed to add the TXT record, Error: " + (DnssdError)ret);
                NsdErrorFactory.ThrowDnssdException(ret);
            }
            byte[] txtValue;
            byte[] txtValue = GetRawTXTRecords();
            ret = Interop.Nsd.Dnssd.SetRecord(_serviceHandle, _dnsRecordtype, (ushort)txtValue.Length, txtValue);
            if (ret != (int)DnssdError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set the DNS resource record, Error: " + (DnssdError)ret);
                NsdErrorFactory.ThrowDnssdException(ret);
            }
        }
        /// <summary>
        /// Removes the TXT record.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="key">The key of the TXT record to be removed.</param>
        /// <feature>http://tizen.org/feature/network.service_discovery.dnssd</feature>
        /// <exception cref="NotSupportedException">Thrown when DNS-SD is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when the value of the key is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when any other error occurred.</exception>
        public void RemoveTXTRecord(string key)
        {
            int ret = Interop.Nsd.Dnssd.RemoveTxtRecord(_serviceHandle, key);
            if (ret != (int)DnssdError.None)
            {
                Log.Error(Globals.LogTag, "Failed to remove the TXT record, Error: " + (DnssdError)ret);
                NsdErrorFactory.ThrowDnssdException(ret);
            }
        }

        /// <summary>
        /// Registers the DNS-SD local service for publishing.
        /// </summary>
        /// Name of the service must be set.
        /// <since_tizen> 4 </since_tizen>
        /// <privilege>http://tizen.org/privilege/internet</privilege>
        /// <feature>http://tizen.org/feature/network.service_discovery.dnssd</feature>
        /// <exception cref="InvalidOperationException">Thrown when any other error occurred.</exception>
        /// <exception cref="NotSupportedException">Thrown when DNS-SD is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the permission is denied.</exception>
        public void RegisterService()
        {
            if (!Globals.s_threadDns.IsValueCreated)
            {
                DnssdInitializeCreateService();
            }

            _serviceRegisteredCallback = (DnssdError result, uint service, IntPtr userData) =>
            {
                if (result != DnssdError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to finish the registration of Dnssd local service, Error: " + result);
                    NsdErrorFactory.ThrowDnssdException((int)result);
                }
            };

            int ret = Interop.Nsd.Dnssd.RegisterService(_serviceHandle, _serviceRegisteredCallback, IntPtr.Zero);
            if (ret != (int)DnssdError.None)
            {
                Log.Error(Globals.LogTag, "Failed to register the Dnssd local service, Error: " + (DnssdError)ret);
                NsdErrorFactory.ThrowDnssdException(ret);
            }
        }

        /// <summary>
        /// Deregisters the DNS-SD local service.
        /// </summary>
        /// <remarks>
        /// A local service registered using RegisterService() must be passed.
        /// </remarks>
        /// <since_tizen> 4 </since_tizen>
        /// <feature>http://tizen.org/feature/network.service_discovery.dnssd</feature>
        /// <exception cref="InvalidOperationException">Thrown when any other error occurred.</exception>
        /// <exception cref="NotSupportedException">Thrown when DNS-SD is not supported.</exception>
        public void DeregisterService()
        {
            int ret = Interop.Nsd.Dnssd.DeregisterService(_serviceHandle);
            if (ret != (int)DnssdError.None)
            {
                Log.Error(Globals.LogTag, "Failed to deregister the Dnssd local service, Error: " + (DnssdError)ret);
                NsdErrorFactory.ThrowDnssdException(ret);
            }
        }

        #region IDisposable Support
        private bool _disposedValue = false; // To detect redundant calls

        private void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    if (_serviceHandle != 0)
                    {
                        int ret = Interop.Nsd.Dnssd.DestroyService(_serviceHandle);
                        if (ret != (int)DnssdError.None)
                        {
                            Log.Error(Globals.LogTag, "Failed to destroy the local Dnssd service handle, Error - " + (DnssdError)ret);
                        }
                    }
                }

                _disposedValue = true;
            }
        }

        /// <summary>
        /// Destroys the DnssdService object.
        /// </summary>
        ~DnssdService()
        {
            Dispose(false);
        }

        /// <summary>
        /// Disposes the memory allocated to unmanaged resources.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }

    /// <summary>
    /// This class manages the IP address properties of the DNS-SD service.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class IPAddressInformation
    {
        private string _ipv4, _ipv6;
        internal IPAddressInformation()
        {
        }

        internal IPAddressInformation(string ipv4, string ipv6)
        {
            _ipv4 = ipv4;
            _ipv6 = ipv6;
        }

        /// <summary>
        /// The IP version 4 address of the DNS-SD service.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public IPAddress IPv4Address
        {
            get
            {
                if (_ipv4 == null)
                    return IPAddress.Parse("0.0.0.0");
                return IPAddress.Parse(_ipv4);
            }
        }

        /// <summary>
        /// The IP version 6 address of the DNS-SD service.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public IPAddress IPv6Address
        {
            get
            {
                if (_ipv6 == null)
                    return IPAddress.Parse("0:0:0:0:0:0:0:0");
                return IPAddress.Parse(_ipv6);
            }
        }
    }
}
