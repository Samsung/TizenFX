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
    /// This class is used for managing network service discovery using DNSSD.
    /// </summary>
    public class DnssdBrowser : INsdBrowser
    {
        private string _serviceType;
        private event EventHandler<DnssdServiceFoundEventArgs> _serviceFound;

        /// <summary>
        /// This event is raised when service state changes during service discovery using DNSSD.
        /// </summary>
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
        /// A public constructor for DnssdBrowser class to create a DnssdBrowser instance for the given service type.
        /// </summary>
        /// <param name="serviceType">The DNSSD service type</param>
        public DnssdBrowser(string serviceType)
        {
            _serviceType = serviceType;
        }
    }
}
