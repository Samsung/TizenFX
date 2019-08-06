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
    /// An extended EventArgs class which contains the result of checking default gateway.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class DefaultGatewayFoundEventArgs : EventArgs
    {
        private bool _found;
        private System.Net.IPAddress _gateway;

        internal DefaultGatewayFoundEventArgs(bool found, System.Net.IPAddress gateway)
        {
            _found = found;
            _gateway = gateway;
        }

        /// <summary>
        /// A property to check whether the default gateway is found or not.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value> Boolean value to check whether the default gateway is found or not.</value>
        public bool IsFound
        {
            get
            {
                return _found;
            }
        }

        /// <summary>
        /// The IP address of the default gateway
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <value> IP Address of the default gateway </value>
        public System.Net.IPAddress Gateway
        {
            get
            {
                return _gateway;
            }
        }
    }
}
