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
    /// This interface is used for managing the network service discovery using DNS-SD/SSDP.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public interface INsdBrowser
    {
        /// <summary>
        /// Starts browsing the DNS-SD/SSDP remote service.
        /// </summary>
        /// <remarks>
        /// If there are any services available, the ServiceFound event will be invoked.
        /// The application will keep browsing for the available or unavailable services until it calls StopDiscovery().
        /// </remarks>
        /// <since_tizen> 4 </since_tizen>
        /// <privilege>http://tizen.org/privilege/internet</privilege>
        /// <feature>http://tizen.org/feature/network.service_discovery.dnssd</feature>
        /// <feature>http://tizen.org/feature/network.service_discovery.ssdp</feature>
        /// <exception cref="InvalidOperationException">Thrown when any other error occured.</exception>
        /// <exception cref="NotSupportedException">Thrown when DNS-SD/SSDP is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the permission is denied.</exception>
        void StartDiscovery();

        /// <summary>
        /// Stops browsing the DNS-SD/SSDP remote service.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <feature>http://tizen.org/feature/network.service_discovery.dnssd</feature>
        /// <feature>http://tizen.org/feature/network.service_discovery.ssdp</feature>
        /// <exception cref="InvalidOperationException">Thrown when any other error occured.</exception>
        /// <exception cref="NotSupportedException">Thrown when DNS-SD/SSDP is not supported.</exception>
        void StopDiscovery();
    }
}
