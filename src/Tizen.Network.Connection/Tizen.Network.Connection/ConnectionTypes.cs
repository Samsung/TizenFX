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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tizen.Internals.Errors;


namespace Tizen.Network.Connection
{
    /// <summary>
    /// Enumeration for connection type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum ConnectionType
    {
        Disconnected = 0,  /**< Disconnected */
        WiFi = 1,          /**< Wi-Fi type */
        Cellular = 2,      /**< Cellular type */
        Ethernet = 3,      /**< Ethernet type */
        Bluetooth = 4,     /**< Bluetooth type */
        NetProxy = 5       /**< Proxy type for internet connection */
    }

    /// <summary>
    /// Enumeration for address family.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum AddressFamily
    {
        IPv4 = 0,   /**< IPv4 Address */
        IPv6 = 1    /**< IPv6 Address */
    }

    /// <summary>
    /// Enumeration for cellular network state.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum CellularState
    {
        OutOfService = 0,  /**< Out of service */
        FlightMode = 1,    /**< Flight mode */
        RoamingOff = 2,    /**< Roaming is turned off */
        CallOnlyAvailable = 3,  /**< Call is only available */
        Available = 4,     /**< Available but not connected yet */
        Connected = 5,     /**< Connected */
    }

    /// <summary>
    /// Enumeration for connection state.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum ConnectionState
    {
        Deactivated = 0,   /**< Deactivated */
        Disconnected = 1,  /**< Disconnected */
        Connected = 2,     /**< Connected */
    }

    /// <summary>
    /// This enumeration defines the attached or detached state of ethernet cable.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum EthernetCableState
    {
        Detached = 0,  /**< Ethernet cable is detached */
        Attached = 1,  /**< Ethernet cable is attached */
    }

    /// <summary>
    /// Enumeration for statistics type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum StatisticsType
    {
        LastReceivedData = 0,  /**< Last received data */
        LastSentData = 1,  /**< Last sent data */
        TotalReceivedData = 2,  /**< Total received data */
        TotalSentData = 3,  /**< Total sent data */
    }

    /// <summary>
    /// Enumeration for network connection type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum ConnectionProfileType
    {
        Cellular = 0,  /**< Cellular type */
        WiFi = 1,      /**< Wi-Fi type */
        Ethernet = 2,  /**< Ethernet type */
        Bt = 3,        /**< Bluetooth type */
    }

    /// <summary>
    /// Enumeration for profile state type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum ProfileState
    {
        Disconnected = 0,  /**< Disconnected state */
        Association = 1,  /**< Association state */
        Configuration = 2,  /**< Configuration state */
        Connected = 3,  /**< Connected state */
    }

    /// <summary>
    /// Enumeration for proxy method type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum ProxyType
    {
        Direct = 0,  /**< Direct connection */
        Auto = 1,    /**< Auto configuration(Use PAC file). If URL property is not set, DHCP/WPAD auto-discover will be tried */
        Manual = 2,  /**< Manual configuration */
    }

    /// <summary>
    /// Enumeration for IP configuration type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum IPConfigType
    {
        None = 0,  /**< Not defined */
        Static = 1,  /**< Manual IP configuration */
        Dynamic = 2,  /**< Config IP using DHCP client*/
        Auto = 3,  /**< Config IP from Auto IP pool (169.254/16). Later with DHCP client, if available */
        Fixed = 4,  /**< Indicates an IP address that can not be modified */
    }

    /// <summary>
    /// Enumeration for cellular service type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum CellularServiceType
    {
        Unknown = 0,  /**< Unknown */
        Internet = 1,  /**< Internet */
        MMS = 2,  /**< MMS */
        PrepaidInternet = 3,  /**< Prepaid internet */
        PrepaidMMS = 4,  /**< Prepaid MMS */
        Tethering = 5,  /**< Tethering */
        Application = 6,  /**< Specific application */
    }

    /// <summary>
    /// Enumeration for cellular pdn type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum CellularPdnType
    {
        Unknown = 0,  /**< Unknown */
        IPv4 = 1,  /**< IPv4 */
        IPv6 = 2,  /**< IPv6 */
        IPv4_IPv6 = 3,  /**< Both IPv4 and IPv6 */
    }

    /// <summary>
    /// Enumeration for DNS configuration type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum DnsConfigType
    {
        None = 0,  /**< Not defined */
        Static = 1,  /**< Manual DNS configuration */
        Dynamic = 2,  /**< Config DNS using DHCP client */
    }

    static internal class ConnectionErrorValue
    {
        internal const int Base = -0x01C10000;
    }


    /// <summary>
    /// Enumeration for connection errors.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    // To do : have to assign valid error code
    public enum ConnectionError
    {
        None = ErrorCode.None,         /**< Successful */
        InvalidParameter = ErrorCode.InvalidParameter, /**< Invalid parameter */
        OutOfMemoryError = ErrorCode.OutOfMemory, /**< Out of memory error */
        InvalidOperation = ErrorCode.InvalidOperation, /**< Invalid Operation */
        AddressFamilyNotSupported = ErrorCode.AddressFamilyNotSupported, /**< Address family not supported */
        OperationFailed = ConnectionErrorValue.Base | 0x0401,  /**< Operation failed */
        EndOfIteration = ConnectionErrorValue.Base | 0x0402,   /**< End of iteration */
        NoConnection = ConnectionErrorValue.Base | 0x0403,     /**< There is no connection */
        NowInProgress = ErrorCode.NowInProgress,    /** Now in progress */
        AlreadyExists = ConnectionErrorValue.Base | 0x0404, /**< Already exists */
        OperationAborted = ConnectionErrorValue.Base | 0x0405, /**< Operation is aborted */
        DhcpFailed = ConnectionErrorValue.Base | 0x0406, /**< DHCP failed  */
        InvalidKey = ConnectionErrorValue.Base | 0x0407, /**< Invalid key  */
        NoReply = ConnectionErrorValue.Base | 0x0408, /**< No reply */
        PermissionDenied = ErrorCode.PermissionDenied, /**< Permission denied */
        NotSupported = ErrorCode.NotSupported    /**< Not Supported */
    }

    /// <summary>
    /// Enumeration for profile list type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum ProfileListType
    {
        Registered = 0,  /**< The iterator of the registered profile  */
        Connected = 1,   /**< The iterator of the connected profile  */
        Default = 2,      /**< The iterator of the default profile  */
    }

    /// <summary>
    /// Enumeration for security type of Wi-Fi.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum WiFiSecurityType
    {
        None  =  0,       /**< Security disabled */
        Wep = 1,          /**< WEP */
        WpaPsk = 2,    /**< WPA-PSK */
        Wpa2Psk = 3,  /**< WPA2-PSK */
        Eap = 4,            /**< EAP */
    }

    /// <summary>
    /// Enumeration for encryption modes.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum WiFiEncryptionType
    {
        None = 0,  /**< Encryption disabled */
        Wep = 1,  /**< WEP */
        Tkip = 2,  /**< TKIP */
        Aes = 3,  /**< AES */
        TkipAesMixed = 4,  /**< TKIP and AES are both supported */
    }

    /// <summary>
    /// Enumeration for connection profile state.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum ConnectionProfileState
    {
        Disconnected = 0,  /**< Disconnected state */
        Association = 1,  /**< Association state */
        Configuration = 2,  /**< Configuration state */
        Connected = 3,   /**< Connected state */
    }

    /// <summary>
    /// Enumeration for cellular authentication type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum CellularAuthType
    {
        None = 0,  /**< No authentication */
        Pap = 1,  /**< PAP authentication */
        Chap = 2,  /**< CHAP authentication */
    }

    public enum AddressInformationType
    {
        Connection = 0,
        WiFi = 1
    }

    static internal class Globals
    {
        internal const string LogTag = "Tizen.Network.Connection";
    }
}
