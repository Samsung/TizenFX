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
    /// An extended EventArgs class which contains the result of ARP request.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class IPFoundEventArgs : EventArgs
    {
        private bool _found;
        private System.Net.IPAddress _ip;

        internal IPFoundEventArgs(bool found, System.Net.IPAddress ip)
        {
            _found = found;
            _ip = ip;
        }

        /// <summary>
        /// A property to check whether the IP address is found or not.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public bool IsFound
        {
            get
            {
                return _found;
            }
        }

        /// <summary>
        /// The IP address which is found by ARP request.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public System.Net.IPAddress IP
        {
            get
            {
                return _ip;
            }
        }
    }
}
