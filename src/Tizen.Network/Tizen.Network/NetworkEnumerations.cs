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

namespace Tizen.Network
{
    /// <summary>
    /// 
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
	public enum ConnectionType
	{
		/// <summary>
		/// Disconnected
		/// </summary>
		/// <since_tizen> 6 </since_tizen>
		Disconnected = 0,

		/// <summary>
		/// Wi-Fi type 
		/// </summary>
		/// <since_tizen> 6 </since_tizen>
		Wifi = 1, 

		/// <summary>
		/// Cellular type 
		/// </summary>
		/// <since_tizen> 6 </since_tizen>
		Cellular = 2,

		/// <summary>
		/// Ethernet type 
		/// </summary>
		/// <since_tizen> 6 </since_tizen>
		Ethernet = 3,

		/// <summary>
		/// Bluetooth type 
		/// </summary>
		/// <since_tizen> 6 </since_tizen>
		Bluetooth = 4,

		/// <summary>
		/// Network Proxy type 
		/// </summary>
		/// <since_tizen> 6 </since_tizen>
		NetProxy,
	}

    /// <summary>
    /// Enumeration for the proxy method type.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public enum ProxyType
    {
        /// <summary>
        /// Direct connection
        /// </summary>
        Direct = 0,
        /// <summary>
        /// Auto configuration(Use PAC file). If URL property is not set, DHCP/WPAD auto-discover will be tried
        /// </summary>
        Auto = 1,
        /// <summary>
        /// Manual configuration
        /// </summary>
        Manual = 2,
    }
}
