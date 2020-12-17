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
    /// This interface is used for managing the local service registration using DNS-SD/SSDP.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public interface INsdService : IDisposable
    {
        /// <summary>
        /// Registers the DNS-SD/SSDP local service for publishing.
        /// </summary>
        /// <remarks>
        /// A service that is created locally must be passed.
        /// </remarks>
        /// <since_tizen> 4 </since_tizen>
        /// <privilege>http://tizen.org/privilege/internet</privilege>
        /// <feature>http://tizen.org/feature/network.service_discovery.dnssd</feature>
        /// <feature>http://tizen.org/feature/network.service_discovery.ssdp</feature>
        /// <exception cref="InvalidOperationException">Thrown when any other error occurred.</exception>
        /// <exception cref="NotSupportedException">Thrown when DNS-SD/SSDP is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the permission is denied.</exception>
        void RegisterService();

        /// <summary>
        /// Deregisters the DNS-SD/SSDP local service.
        /// </summary>
        /// <remarks>
        /// A local service that is registered using RegisterService() must be passed.
        /// </remarks>
        /// <since_tizen> 4 </since_tizen>
        /// <feature>http://tizen.org/feature/network.service_discovery.dnssd</feature>
        /// <feature>http://tizen.org/feature/network.service_discovery.ssdp</feature>
        /// <exception cref="InvalidOperationException">Thrown when any other error occurred.</exception>
        /// <exception cref="NotSupportedException">Thrown when DNS-SD/SSDP is not supported.</exception>
        void DeregisterService();
    }
}
