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
    /// Enumeration for the connection type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum ConnectionType
    {
        /// <summary>
        /// Disconnected
        /// </summary>
        Disconnected = 0,
        /// <summary>
        /// Wi-Fi type
        /// </summary>
        WiFi = 1,
        /// <summary>
        /// Cellular type
        /// </summary>
        Cellular = 2,
        /// <summary>
        /// Ethernet type
        /// </summary>
        Ethernet = 3,
        /// <summary>
        /// Bluetooth type
        /// </summary>
        Bluetooth = 4,
        /// <summary>
        /// Proxy type for Internet connection
        /// </summary>
        NetProxy = 5
    }

    /// <summary>
    /// Enumeration for the address family.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum AddressFamily
    {
        /// <summary>
        /// IPv4 Address
        /// </summary>
        IPv4 = 0,
        /// <summary>
        /// IPv6 Address
        /// </summary>
        IPv6 = 1
    }

    /// <summary>
    /// Enumeration for the cellular network state.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum CellularState
    {
        /// <summary>
        /// Out of service
        /// </summary>
        OutOfService = 0,
        /// <summary>
        /// Flight mode
        /// </summary>
        FlightMode = 1,
        /// <summary>
        /// Roaming is turned off
        /// </summary>
        RoamingOff = 2,
        /// <summary>
        /// Call is only available
        /// </summary>
        CallOnlyAvailable = 3,
        /// <summary>
        /// Available but not connected yet
        /// </summary>
        Available = 4,
        /// <summary>
        /// Connected
        /// </summary>
        Connected = 5,
    }

    /// <summary>
    /// Enumeration for the connection state.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum ConnectionState
    {
        /// <summary>
        /// Deactivated
        /// </summary>
        Deactivated = 0,
        /// <summary>
        /// Disconnected
        /// </summary>
        Disconnected = 1,
        /// <summary>
        /// Connected
        /// </summary>
        Connected = 2,
    }

    /// <summary>
    /// Enumeration for the attached or detached state of the ethernet cable.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum EthernetCableState
    {
        /// <summary>
        /// Ethernet cable is detached
        /// </summary>
        Detached = 0,
        /// <summary>
        /// Ethernet cable is attached
        /// </summary>
        Attached = 1,
    }

    /// <summary>
    /// Enumeration for the statistics type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum StatisticsType
    {
        /// <summary>
        /// Last received data
        /// </summary>
        LastReceivedData = 0,
        /// <summary>
        /// Last sent data
        /// </summary>
        LastSentData = 1,
        /// <summary>
        /// Total received data
        /// </summary>
        TotalReceivedData = 2,
        /// <summary>
        /// Total sent data
        /// </summary>
        TotalSentData = 3,
    }

    /// <summary>
    /// Enumeration for the network connection type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum ConnectionProfileType
    {
        /// <summary>
        /// Cellular type
        /// </summary>
        Cellular = 0,
        /// <summary>
        /// Wi-Fi type
        /// </summary>
        WiFi = 1,
        /// <summary>
        /// Ethernet type
        /// </summary>
        Ethernet = 2,
        /// <summary>
        /// Bluetooth type
        /// </summary>
        Bt = 3,
    }

    /// <summary>
    /// Enumeration for the profile state type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum ProfileState
    {
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
        Configuration = 2,
        /// <summary>
        /// Connected state
        /// </summary>
        Connected = 3,
    }

    /// <summary>
    /// Enumeration for the proxy method type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
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

    /// <summary>
    /// Enumeration for the IP configuration type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum IPConfigType
    {
        /// <summary>
        /// Not defined
        /// </summary>
        None = 0,
        /// <summary>
        /// Manual IP configuration
        /// </summary>
        Static = 1,
        /// <summary>
        /// Config IP using DHCP client
        /// </summary>
        Dynamic = 2,
        /// <summary>
        /// Config IP from Auto IP pool (169.254/16). Later with DHCP client, if available
        /// </summary>
        Auto = 3,
        /// <summary>
        /// Indicates an IP address that can not be modified
        /// </summary>
        Fixed = 4,
    }

    /// <summary>
    /// Enumeration for the cellular service type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum CellularServiceType
    {
        /// <summary>
        /// Unknown
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// Internet
        /// </summary>
        Internet = 1,
        /// <summary>
        /// MMS
        /// </summary>
        MMS = 2,
        /// <summary>
        /// Prepaid Internet
        /// </summary>
        PrepaidInternet = 3,
        /// <summary>
        /// Prepaid MMS
        /// </summary>
        PrepaidMMS = 4,
        /// <summary>
        /// Tethering
        /// </summary>
        Tethering = 5,
        /// <summary>
        /// Specific application
        /// </summary>
        Application = 6,
    }

    /// <summary>
    /// Enumeration for the cellular pdn type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum CellularPdnType
    {
        /// <summary>
        /// Unknown
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// IPv4
        /// </summary>
        IPv4 = 1,
        /// <summary>
        /// IPv6
        /// </summary>
        IPv6 = 2,
        /// <summary>
        /// Both IPv4 and IPv6
        /// </summary>
        IPv4_IPv6 = 3,
    }

    /// <summary>
    /// Enumeration for the DNS configuration type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum DnsConfigType
    {
        /// <summary>
        /// Not defined
        /// </summary>
        None = 0,
        /// <summary>
        /// Manual DNS configuration
        /// </summary>
        Static = 1,
        /// <summary>
        /// Config DNS using DHCP client
        /// </summary>
        Dynamic = 2,
    }

    static internal class ConnectionErrorValue
    {
        internal const int Base = -0x01C10000;
    }


    /// <summary>
    /// Enumeration for the connection errors.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    // To do : have to assign valid error code
    public enum ConnectionError
    {
        /// <summary>
        /// Successful
        /// </summary>
        None = ErrorCode.None,
        /// <summary>
        /// Invalid parameter
        /// </summary>
        InvalidParameter = ErrorCode.InvalidParameter,
        /// <summary>
        /// Out of memory error
        /// </summary>
        OutOfMemoryError = ErrorCode.OutOfMemory,
        /// <summary>
        /// Invalid operation
        /// </summary>
        InvalidOperation = ErrorCode.InvalidOperation,
        /// <summary>
        /// Address family not supported
        /// </summary>
        AddressFamilyNotSupported = ErrorCode.AddressFamilyNotSupported,
        /// <summary>
        /// Operation failed
        /// </summary>
        OperationFailed = ConnectionErrorValue.Base | 0x0401,
        /// <summary>
        /// End of iteration
        /// </summary>
        EndOfIteration = ConnectionErrorValue.Base | 0x0402,
        /// <summary>
        /// There is no connection
        /// </summary>
        NoConnection = ConnectionErrorValue.Base | 0x0403,
        /// <summary>
        /// Now in progress
        /// </summary>
        NowInProgress = ErrorCode.NowInProgress,
        /// <summary>
        /// Already exists
        /// </summary>
        AlreadyExists = ConnectionErrorValue.Base | 0x0404,
        /// <summary>
        /// Operation is aborted
        /// </summary>
        OperationAborted = ConnectionErrorValue.Base | 0x0405,
        /// <summary>
        /// DHCP failed
        /// </summary>
        DhcpFailed = ConnectionErrorValue.Base | 0x0406,
        /// <summary>
        /// Invalid key
        /// </summary>
        InvalidKey = ConnectionErrorValue.Base | 0x0407,
        /// <summary>
        /// No reply
        /// </summary>
        NoReply = ConnectionErrorValue.Base | 0x0408,
        /// <summary>
        /// Permission denied
        /// </summary>
        PermissionDenied = ErrorCode.PermissionDenied,
        /// <summary>
        /// Not supported
        /// </summary>
        NotSupported = ErrorCode.NotSupported
    }

    /// <summary>
    /// Enumeration for the profile list type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum ProfileListType
    {
        /// <summary>
        /// The iterator of the registered profile
        /// </summary>
        Registered = 0,
        /// <summary>
        /// The iterator of the connected profile
        /// </summary>
        Connected = 1,
        /// <summary>
        /// The iterator of the default profile
        /// </summary>
        Default = 2,
    }

    /// <summary>
    /// Enumeration for the security type of Wi-Fi.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum WiFiSecurityType
    {
        /// <summary>
        /// Security disabled
        /// </summary>
        None  =  0,
        /// <summary>
        /// WEP
        /// </summary>
        Wep = 1,
        /// <summary>
        /// WPA-PSK
        /// </summary>
        WpaPsk = 2,
        /// <summary>
        /// WPA2-PSK
        /// </summary>
        Wpa2Psk = 3,
        /// <summary>
        /// EAP
        /// </summary>
        Eap = 4,
        /// <summary>
        /// WPA3-SAE
        /// </summary>
        Wpa3Sae = 6,
        /// <summary>
        /// WPA3-OWE
        /// </summary>
        Wpa3Owe = 7,
    }

    /// <summary>
    /// Enumeration for the encryption modes.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum WiFiEncryptionType
    {
        /// <summary>
        /// Encryption disabled
        /// </summary>
        None = 0,
        /// <summary>
        /// WEP
        /// </summary>
        Wep = 1,
        /// <summary>
        /// TKIP
        /// </summary>
        Tkip = 2,
        /// <summary>
        /// AES
        /// </summary>
        Aes = 3,
        /// <summary>
        /// TKIP and AES are both supported
        /// </summary>
        TkipAesMixed = 4,
    }

    /// <summary>
    /// Enumeration for the connection profile state.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum ConnectionProfileState
    {
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
        Configuration = 2,
        /// <summary>
        /// Connected state
        /// </summary>
        Connected = 3,
    }

    /// <summary>
    /// Enumeration for the cellular authentication type.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum CellularAuthType
    {
        /// <summary>
        /// No authentication
        /// </summary>
        None = 0,
        /// <summary>
        /// PAP authentication
        /// </summary>
        Pap = 1,
        /// <summary>
        /// CHAP authentication
        /// </summary>
        Chap = 2,
    }

    static internal class Globals
    {
        internal const string LogTag = "Tizen.Network.Connection";
    }
}
