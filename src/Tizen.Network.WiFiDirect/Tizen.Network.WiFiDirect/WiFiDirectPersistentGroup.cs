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

namespace Tizen.Network.WiFiDirect
{
    /// <summary>
    /// A class to handle persistent groups.
    /// </summary>
    public class WiFiDirectPersistentGroup
    {
        private string _address;
        private string _ssid;

        internal WiFiDirectPersistentGroup(string address, string id)
        {
            _address = address;
            _ssid = id;
        }

        /// <summary>
        /// The MAC address of the persistent group owner.
        /// </summary>
        public string MacAddress
        {
            get
            {
                return _address;
            }
        }

        /// <summary>
        /// The SSID (Service Set Identifier) of the persistent group owner.
        /// </summary>
        public string Ssid
        {
            get
            {
                return _ssid;
            }
        }
    }
}
