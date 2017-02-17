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
    public enum WiFiEapType
    {
        /// <summary>
        /// EAP PEAP type
        /// </summary>
        Peap = 0,
        /// <summary>
        /// EAP TLS type
        /// </summary>
        Tls = 1,
        /// <summary>
        /// EAP TTLS type
        /// </summary>
        Ttls = 2,
        /// <summary>
        /// EAP SIM type
        /// </summary>
        Sim = 3,
        /// <summary>
        /// EAP AKA type
        /// </summary>
        Aka = 4
    }

    /// <summary>
    /// Enumeration for Wi-Fi RSSI level.
    /// </summary>
    public enum WiFiRssiLevel
    {
        /// <summary>
        /// Level 0
        /// </summary>
        Level0 = 0,
        /// <summary>
        /// Level 1
        /// </summary>
        Level1 = 1,
        /// <summary>
        /// Level 2
        /// </summary>
        Level2 = 2,
        /// <summary>
        /// Level 3
        /// </summary>
        Level3 = 3,
        /// <summary>
        /// Level 4
        /// </summary>
        Level4 = 4
    }

    /// <summary>
    /// Enumeration for Wi-Fi connection state.
    /// </summary>
    public enum WiFiConnectionState
    {
        /// <summary>
        /// Connection failed state
        /// </summary>
        Failure = -1,
        /// <summary>
        /// Disconnected state
        /// </summary>
        Disconnected = 0,
        /// <summary>
        /// Association state
        /// </summary>
        Association = 1,
        /// <summary>
        /// Configuration state
        /// </summary>
        Congfiguration = 2,
        /// <summary>
        /// Connected state
        /// </summary>
        Connected = 3
    }

    /// <summary>
    /// Enumeration for Wi-Fi device state.
    /// </summary>
    public enum WiFiDeviceState
    {
        /// <summary>
        /// Wi-Fi is Deactivated
        /// </summary>
        Deactivated = 0,
        /// <summary>
        /// Wi-Fi is activated
        /// </summary>
        Activated = 1
    }

    /// <summary>
    /// Enumeration for Wi-Fi proxy type.
    /// </summary>
    public enum WiFiProxyType
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
        Manual = 2
    }

    /// <summary>
    /// Enumeration for Wi-Fi authentication type.
    /// </summary>
    public enum WiFiAuthenticationType
    {
        /// <summary>
        /// EAP phase2 authentication none
        /// </summary>
        None = 0,
        /// <summary>
        /// EAP phase2 authentication PAP
        /// </summary>
        Pap = 1,
        /// <summary>
        /// EAP phase2 authentication MSCHAP
        /// </summary>
        Mschap = 2,
        /// <summary>
        /// EAP phase2 authentication MSCHAPv2
        /// </summary>
        Mschapv2 = 3,
        /// <summary>
        /// EAP phase2 authentication GTC
        /// </summary>
        Gtc = 4,
        /// <summary>
        /// EAP phase2 authentication MD5
        /// </summary>
        Md5 = 5
    }
}
