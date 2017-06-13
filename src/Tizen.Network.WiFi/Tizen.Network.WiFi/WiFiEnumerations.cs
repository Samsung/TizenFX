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

namespace Tizen.Network.WiFi
{
    /// <summary>
    /// Enumeration for Wi-Fi EAP type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum WiFiEapType
    {
        /// <summary>
        /// EAP PEAP type
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Peap = 0,
        /// <summary>
        /// EAP TLS type
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Tls = 1,
        /// <summary>
        /// EAP TTLS type
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Ttls = 2,
        /// <summary>
        /// EAP SIM type
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Sim = 3,
        /// <summary>
        /// EAP AKA type
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Aka = 4
    }

    /// <summary>
    /// Enumeration for Wi-Fi RSSI level.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum WiFiRssiLevel
    {
        /// <summary>
        /// Level 0
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Level0 = 0,
        /// <summary>
        /// Level 1
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Level1 = 1,
        /// <summary>
        /// Level 2
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Level2 = 2,
        /// <summary>
        /// Level 3
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Level3 = 3,
        /// <summary>
        /// Level 4
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Level4 = 4
    }

    /// <summary>
    /// Enumeration for Wi-Fi connection state.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum WiFiConnectionState
    {
        /// <summary>
        /// Connection failed state
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Failure = -1,
        /// <summary>
        /// Disconnected state
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Disconnected = 0,
        /// <summary>
        /// Association state
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Association = 1,
        /// <summary>
        /// Configuration state
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Congfiguration = 2,
        /// <summary>
        /// Connected state
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Connected = 3
    }

    /// <summary>
    /// Enumeration for Wi-Fi device state.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum WiFiDeviceState
    {
        /// <summary>
        /// Wi-Fi is Deactivated
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Deactivated = 0,
        /// <summary>
        /// Wi-Fi is activated
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Activated = 1
    }

    /// <summary>
    /// Enumeration for Wi-Fi proxy type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum WiFiProxyType
    {
        /// <summary>
        /// Direct connection
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Direct = 0,
        /// <summary>
        /// Auto configuration(Use PAC file). If URL property is not set, DHCP/WPAD auto-discover will be tried
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Auto = 1,
        /// <summary>
        /// Manual configuration
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Manual = 2
    }

    /// <summary>
    /// Enumeration for Wi-Fi authentication type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum WiFiAuthenticationType
    {
        /// <summary>
        /// EAP phase2 authentication none
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        None = 0,
        /// <summary>
        /// EAP phase2 authentication PAP
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Pap = 1,
        /// <summary>
        /// EAP phase2 authentication MSCHAP
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Mschap = 2,
        /// <summary>
        /// EAP phase2 authentication MSCHAPv2
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Mschapv2 = 3,
        /// <summary>
        /// EAP phase2 authentication GTC
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Gtc = 4,
        /// <summary>
        /// EAP phase2 authentication MD5
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        Md5 = 5
    }
}
