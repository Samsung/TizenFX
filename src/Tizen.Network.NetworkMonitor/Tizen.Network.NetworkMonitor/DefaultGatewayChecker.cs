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

namespace Tizen.Network.NetworkMonitor
{
    /// <summary>
    /// A class which checks whether the default gateway is available or not.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public static class DefaultGatewayChecker
    {
        /// <summary>
        /// Starts to check whether the default gateway is available or not by sending ARP packets.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="timeout"> The duration of discovery period in seconds. If 0, then there is no limit on how long the discovery takes. </param>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <feature>http://tizen.org/feature/network.inm</feature>
        /// <exception cref="NotSupportedException">Thrown when a feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the permission is denied.</exception>
        /// <exception cref="NowInProgressException">Thrown when the DefaultGatewayChecker is already started.</exception>
        public static void Start(int timeout)
        {
            NetworkMonitorImpl.Instance.GatewayCheckerStart(timeout);
        }

        /// <summary>
        /// Stops checking.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <feature>http://tizen.org/feature/network.inm</feature>
        /// <exception cref="NotSupportedException">Thrown when a feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the permission is denied.</exception>
        public static void Stop()
        {
            NetworkMonitorImpl.Instance.GatewayCheckerStop();
        }

        /// <summary>
        /// GatewayFound event is raised when the default gateway is found on local network.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static event EventHandler<DefaultGatewayFoundEventArgs> GatewayFound
        {
            add
            {
                NetworkMonitorImpl.Instance.GatewayFound += value;
            }
            remove
            {
                NetworkMonitorImpl.Instance.GatewayFound -= value;
            }
        }

    }
}
