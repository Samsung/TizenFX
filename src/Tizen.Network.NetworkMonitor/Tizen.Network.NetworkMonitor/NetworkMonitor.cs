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
using System.Collections.Generic;

namespace Tizen.Network.NetworkMonitor
{
    /// <summary>
    /// NetworkMonitor class provides functions to get information about connections and links.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public static class NetworkMonitor
    {

        /// <summary>
        /// Gets the list of the connections
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns> The list of the connections </returns>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <feature>http://tizen.org/feature/network.ethernet</feature>
        /// <feature>http://tizen.org/feature/network.inm</feature>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <feature>http://tizen.org/feature/network.tethering.bluetooth</feature>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
        /// <exception cref="NotSupportedException">Thrown when a feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the permission is denied.</exception>
        public static IEnumerable<Connection> GetConnections()
        {
            return NetworkMonitorImpl.Instance.GetConnections();
        }

        /// <summary>
        /// Gets the default connection
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns> The default connection </returns>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <feature>http://tizen.org/feature/network.ethernet</feature>
        /// <feature>http://tizen.org/feature/network.inm</feature>
        /// <feature>http://tizen.org/feature/network.telephony</feature>
        /// <feature>http://tizen.org/feature/network.tethering.bluetooth</feature>
        /// <feature>http://tizen.org/feature/network.wifi</feature>
        /// <exception cref="NotSupportedException">Thrown when a feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the permission is denied.</exception>
        public static Connection GetCurrentConnection()
        {
            return NetworkMonitorImpl.Instance.GetCurrentConnection();
        }

        /// <summary>
        /// Gets the list of the links 
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns> The list of the links </returns>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <feature>http://tizen.org/feature/network.inm</feature>
        /// <exception cref="NotSupportedException">Thrown when a feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the permission is denied.</exception>
        public static IEnumerable<Link> GetLinks()
        {
            return NetworkMonitorImpl.Instance.GetLinks();
        }

        /// <summary>
        /// Refreshes link information
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <feature>http://tizen.org/feature/network.inm</feature>
        /// <exception cref="NotSupportedException">Thrown when a feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the permission is denied.</exception>
        public static void RefreshLinks()
        {
            NetworkMonitorImpl.Instance.RefreshLinks();
        }
    }
}
