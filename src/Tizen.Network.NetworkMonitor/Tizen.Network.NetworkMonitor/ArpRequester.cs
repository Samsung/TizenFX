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
    /// A class which checks whether an IP address is used on local network or not.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public static class ArpRequester
    {
        private static string _target;
        /// <summary>
        /// Starts to send ARP packets to find the target address.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="ip"> The target address </param>
        /// <param name="seconds"> Packet interval in seconds </param>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <feature>http://tizen.org/feature/network.inm</feature>
        /// <exception cref="NotSupportedException">Thrown when a feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the permission is denied.</exception>
        /// <exception cref="NowInProgressException">Thrown when the ArpRequest is already started.</exception>
        public static void Start(System.Net.IPAddress ip, int seconds)
        {
            _target = ip.ToString();
            NetworkMonitorImpl.Instance.ArpRequesterSetPacketInterval(seconds);
            NetworkMonitorImpl.Instance.ArpRequesterStart(_target);
        }

        /// <summary>
        /// Stops sending ARP packets to find the target address.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <feature>http://tizen.org/feature/network.inm</feature>
        /// <exception cref="NotSupportedException">Thrown when a feature is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the permission is denied.</exception>
        public static void Stop()
        {
            NetworkMonitorImpl.Instance.ArpRequesterStop(_target);
        }

        /// <summary>
        /// IPFound event is raised when the IP is found by ARP requests.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public static event EventHandler<IPFoundEventArgs> IPFound
        {
            add
            {
                NetworkMonitorImpl.Instance.IPFound += value;
            }
            remove
            {
                NetworkMonitorImpl.Instance.IPFound -= value;
            }
        }
    }
}
