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

using System.Threading;

namespace Tizen.Network.Nsd
{
    internal static class Globals
    {
        internal const string LogTag = "Tizen.Network.Nsd";

        internal static void DnssdInitialize()
        {
            int ret = Interop.Nsd.Dnssd.Initialize();
            if(ret!=(int)DnssdError.None)
            {
                Log.Error(LogTag, "Failed to initialize Dnssd, Error - "+ (DnssdError)ret);
                NsdErrorFactory.ThrowDnssdException(ret);
            }
        }

        internal static void SsdpInitialize()
        {
            int ret = Interop.Nsd.Ssdp.Initialize();
            if (ret != (int)SsdpError.None)
            {
                Log.Error(LogTag, "Failed to initialize Ssdp, Error - " + (SsdpError)ret);
                NsdErrorFactory.ThrowSsdpException(ret);
            }
        }

        internal static ThreadLocal<DnssdInitializer> s_threadDns = new ThreadLocal<DnssdInitializer>(() =>
       {
           Log.Info(LogTag, "Inside Dnssd ThreadLocal delegate");
           return new DnssdInitializer();
       });

        internal static ThreadLocal<SsdpInitializer> s_threadSsd = new ThreadLocal<SsdpInitializer>(() =>
        {
            Log.Info(LogTag, "Inside Ssdp ThreadLocal delegate");
            return new SsdpInitializer();
        });
    }

    /// <summary>
    /// This class is used for managing local/network service registration and discovery using DNSSD/SSDP.
    /// </summary>
    public static class NsdManager
    {
        /// <summary>
        /// Registers the DNSSD/SSDP local service for publishing.
        /// </summary>
        /// <remarks>
        /// A service created locally must be passed.
        /// Name of the service must be set for DNSSD/SSDP both. Also, Port and Url must be set for DNSSD and SSDP respectively.
        /// </remarks>
        /// <param name="service">The DNSSD/SSDP service instance.</param>
        /// <exception cref="NotSupportedException">Thrown when DNSSD/SSDP is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when any other error occured.</exception>
        public static void RegisterService(INsdService service)
        {
            if (service.GetType() == typeof(DnssdService))
            {
                DnssdService dnsService = (DnssdService)service;
                dnsService.RegisterService();
            }

            else if (service.GetType() == typeof(SsdpService))
            {
                SsdpService ssdService = (SsdpService)service;
                ssdService.RegisterService();
            }
        }

        /// <summary>
        /// Deregisters the DNSSD/SSDP local service.
        /// </summary>
        /// <remarks>
        /// A local service registered using RegisterService() must be passed.
        /// </remarks>
        /// <param name="service">The DNSSD/SSDP service instance.</param>
        /// <exception cref="NotSupportedException">Thrown when DNSSD/SSDP is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when any other error occured.</exception>
        public static void UnregisterService(INsdService service)
        {
            if (service.GetType() == typeof(DnssdService))
            {
                DnssdService dnsService = (DnssdService)service;
                dnsService.DeregisterService();
            }

            else if (service.GetType() == typeof(SsdpService))
            {
                SsdpService ssdService = (SsdpService)service;
                ssdService.DeregisterService();
            }
        }

        /// <summary>
        /// Starts browsing the DNSSD/SSDP remote service.
        /// </summary>
        /// <remarks>
        /// If there are any services available, ServiceFound event will be invoked.
        /// Application will keep browsing for available/unavailable services until it calls StopDiscovery().
        /// </remarks>
        /// <param name="browser">The DNSSD/SSDP browser instance.</param>
        /// <exception cref="NotSupportedException">Thrown when DNSSD/SSDP is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when any other error occured.</exception>
        public static void StartDiscovery(INsdBrowser browser)
        {
            if (browser.GetType() == typeof(DnssdBrowser))
            {
                DnssdBrowser dnsBrowser = (DnssdBrowser)browser;
                dnsBrowser.StartDiscovery();
            }

            else if (browser.GetType() == typeof(SsdpBrowser))
            {
                SsdpBrowser ssdBrowser = (SsdpBrowser)browser;
                ssdBrowser.StartDiscovery();
            }
        }

        /// <summary>
        /// Stops browsing the DNSSD/SSDP remote service.
        /// </summary>
        /// <param name="browser">The DNSSD/SSDP browser instance.</param>
        /// <exception cref="NotSupportedException">Thrown when DNSSD/SSDP is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when any other error occured.</exception>
        public static void StopDiscovery(INsdBrowser browser)
        {
            if (browser.GetType() == typeof(DnssdBrowser))
            {
                DnssdBrowser dnsBrowser = (DnssdBrowser)browser;
                dnsBrowser.StopDiscovery();
            }

            else if (browser.GetType() == typeof(SsdpBrowser))
            {
                SsdpBrowser ssdBrowser = (SsdpBrowser)browser;
                ssdBrowser.StopDiscovery();
            }
        }
    }
}
