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

namespace Tizen.Network.Nsd
{
    /// <summary>
    /// This class is used for managing the network service discovery using DNS-SD.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class DnssdBrowser : INsdBrowser
    {
        private string _serviceType;
        private uint _browserHandle;
        private event EventHandler<DnssdServiceFoundEventArgs> _serviceFound;
        private Interop.Nsd.Dnssd.ServiceFoundCallback _serviceFoundCallback;

        /// <summary>
        /// This event is raised when a DNS-SD service is found during the service discovery.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public event EventHandler<DnssdServiceFoundEventArgs> ServiceFound
        {
            add
            {
                _serviceFound += value;
            }

            remove
            {
                _serviceFound -= value;
            }
        }

        /// <summary>
        /// A public constructor for the DnssdBrowser class to create a DnssdBrowser instance for the given service type.
        /// </summary>
        /// <param name="serviceType">The DNS-SD service type.</param>
        /// <since_tizen> 4 </since_tizen>
        /// <feature>http://tizen.org/feature/network.service_discovery.dnssd</feature>
        /// <exception cref="ArgumentException">Thrown when the serviceType is null.</exception>
        /// <exception cref="NotSupportedException">Thrown when DNS-SD is not supported.</exception>
        public DnssdBrowser(string serviceType)
        {
            DnssdInitializer dnssdInit = Globals.s_threadDns.Value;
            Log.Info(Globals.LogTag, "Initialize ThreadLocal<DnssdInitializer> instance = " + dnssdInit);
            if(serviceType == null)
            {
                Log.Debug(Globals.LogTag, "serviceType is null");
                NsdErrorFactory.ThrowDnssdException((int)DnssdError.InvalidParameter);
            }

            _serviceType = serviceType;
        }

        /// <summary>
        /// Starts browsing the DNS-SD remote service.
        /// </summary>
        /// <remarks>
        /// If there are any services available, the ServiceFound event will be invoked.
        /// The application will keep browsing for the available or unavailable services until it calls StopDiscovery().
        /// </remarks>
        /// <since_tizen> 4 </since_tizen>
        /// <privilege>http://tizen.org/privilege/internet</privilege>
        /// <feature>http://tizen.org/feature/network.service_discovery.dnssd</feature>
        /// <exception cref="InvalidOperationException">Thrown when any other error occurred.</exception>
        /// <exception cref="NotSupportedException">Thrown when DNS-SD is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the permission is denied.</exception>
        public void StartDiscovery()
        {
            DnssdInitializer dnssdInit = Globals.s_threadDns.Value;
            Log.Info(Globals.LogTag, "Initialize ThreadLocal<DnssdInitializer> instance = " + dnssdInit);

            _serviceFoundCallback = (DnssdServiceState state, uint service, IntPtr userData) =>
            {
                if (_serviceFound != null)
                {
                    Log.Info(Globals.LogTag, "Inside Service found callback");
                    DnssdService dnsService = new DnssdService(service);
                    _serviceFound(null, new DnssdServiceFoundEventArgs(state, dnsService));
                }
            };

            int ret = Interop.Nsd.Dnssd.StartBrowsing(_serviceType, out _browserHandle, _serviceFoundCallback, IntPtr.Zero);
            if (ret != (int)DnssdError.None)
            {
                Log.Error(Globals.LogTag, "Failed to discover Dnssd remote service, Error - " + (DnssdError)ret);
                NsdErrorFactory.ThrowDnssdException(ret);
            }
        }

        /// <summary>
        /// Stops browsing the DNS-SD remote service.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <feature>http://tizen.org/feature/network.service_discovery.dnssd</feature>
        /// <exception cref="InvalidOperationException">Thrown when any other error occurred.</exception>
        /// <exception cref="NotSupportedException">Thrown when DNS-SD is not supported.</exception>
        public void StopDiscovery()
        {
            int ret = Interop.Nsd.Dnssd.StopBrowsing(_browserHandle);
            if (ret != (int)DnssdError.None)
            {
                Log.Error(Globals.LogTag, "Failed to stop discovery of Dnssd remote service, Error - " + (DnssdError)ret);
                NsdErrorFactory.ThrowDnssdException(ret);
            }
        }
    }
}
