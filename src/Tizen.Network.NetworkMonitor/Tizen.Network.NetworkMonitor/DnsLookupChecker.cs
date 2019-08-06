/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Threading.Tasks;

namespace Tizen.Network.NetworkMonitor
{
    /// <summary>
    /// A class which checks whether the DNS service is available or not.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public static class DnsLookupChecker
    {
        /// <summary>
        /// Checks whether DNS server is valid or not.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns> A task indicating whether the check method is done or not. </returns>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <feature>http://tizen.org/feature/network.inm</feature>
        /// <exception cref="NotSupportedException">Thrown when a feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the permission is denied.</exception>
        /// <exception cref="NowInProgressException">Thrown when the DnsLookupChecker is already started.</exception>
        public static Task<bool> CheckAsync()
        {
            return NetworkMonitorImpl.Instance.DnsLookupCheckAsync();
        }
    }
}
