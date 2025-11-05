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
    /// A class to handle persistent groups in Wi-Fi Direct.
    /// Persistent groups allow devices to automatically reconnect to previously established Wi-Fi Direct groups without requiring manual pairing each time.
    /// This class provides information about saved persistent groups that can be used for automatic reconnection.
    /// </summary>
    /// <remarks>
    /// Persistent groups are created when a Wi-Fi Direct connection is established with the persistent group feature enabled.
    /// The group information (SSID and group owner MAC address) is saved and can be used later for automatic reconnection.
    /// Use <see cref="WiFiDirectManager.GetPersistentGroups"/> to retrieve all saved persistent groups,
    /// and <see cref="WiFiDirectManager.RemovePersistentGroup"/> to remove a specific persistent group.
    /// </remarks>
    /// <since_tizen> 3 </since_tizen>
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
        /// This is the unique identifier of the device that acted as the group owner when the persistent group was created.
        /// </summary>
        /// <value>
        /// The MAC address string of the group owner (e.g., "AA:BB:CC:DD:EE:FF").
        /// </value>
        /// <since_tizen> 3 </since_tizen>
        public string MacAddress
        {
            get
            {
                return _address;
            }
        }

        /// <summary>
        /// The SSID (Service Set Identifier) of the persistent group.
        /// This is the network name that was assigned to the Wi-Fi Direct group when it was created.
        /// </summary>
        /// <value>
        /// The SSID string of the persistent group (e.g., "DIRECT-XY-DeviceName").
        /// </value>
        /// <since_tizen> 3 </since_tizen>
        public string Ssid
        {
            get
            {
                return _ssid;
            }
        }
    }
}
