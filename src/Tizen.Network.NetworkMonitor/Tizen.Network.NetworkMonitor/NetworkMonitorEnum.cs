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

namespace Tizen.Network.NetworkMonitor
{
    /// <summary>
    /// Enumeration for connection state.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public enum ConnectionState
    {
        /// <summary>
        /// Disconnected
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        Disconnected = 0,

        /// <summary>
        /// Association
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        Association = 1,

        /// <summary>
        /// Configuration
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        Configuration = 2,

        /// <summary>
        /// Connected 
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        Connected = 3,
    }

    /// <summary>
    /// 
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public enum LinkFlag
    {

        /// <summary>
        /// Interface is up
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        Up = 0x1,

        /// <summary>
        /// Broadcast address is valid
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        Broadcast = 0x2,

        /// <summary>
        /// Debugging
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        Debug = 0x4,

        /// <summary>
        /// link is a loopback
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        Loopback = 0x8,

        /// <summary>
        /// Interface is has p-p link
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        P2p = 0x10,

        /// <summary>
        /// Avoid use of trailers
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        Notrailers = 0x20,

        /// <summary>
        /// Interface RFC2863 OPER_UP
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        Running = 0x40,

        /// <summary>
        /// No ARP protocol
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        NoArp = 0x80,

        /// <summary>
        /// Receive all packets
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        Promisc = 0x100,

        /// <summary>
        /// Receive all multicast packets
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        AllMulti = 0x200,

        /// <summary>
        /// Supports multicast
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        Multicast = 0x1000,

        /// <summary>
        ///  Dialup device with changing addresses
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        Dynamic = 0x8000,

        /// <summary>
        /// Driver signals L1 up
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        Lower_up = 0x10000,

        /// <summary>
        /// Driver signals dormant
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        Dormant = 0x20000,
    }

    /// <summary>
    /// Enumeration for link RFC 2863 operation status.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public enum LinkOperationState
    {
        /// <summary>
        /// Unknown
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        Unknown,

        /// <summary>
        /// Not present
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        NotPresent,

        /// <summary>
        /// Down
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        Down,

        /// <summary>
        /// Lower layer down
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        LowerLayerDown,

        /// <summary>
        /// Testing
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        Testing,

        /// <summary>
        /// Dormant
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        Dormant,

        /// <summary>
        /// Up
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        Up,
    }

    /// <summary>
    /// Enumeration for link scope.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public enum LinkScope
    {
        /// <summary>
        /// Scope nowhere
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        Nowhere,

        /// <summary>
        /// A route has host scope when it leads to
        /// a destination address on the local host
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        Host,

        /// <summary>
        /// A route has host scope when it leads to
        /// a destination address on the local network
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        Link,

        /// <summary>
        /// Valid only within this site (IPv6)
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        Site,

        /// <summary>
        /// A route has universe scope when it leads to
        /// addresses more than one hop away
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        Universe,
    }

    /// <summary>
    /// Enumeration for link route scope.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public enum RouteType
    {
        /// <summary>
        /// Unspecified
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        Unspec,

        /// <summary>
        /// Gateway or direct
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        Unicast,

        /// <summary>
        /// Accept locally
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        Local,

        /// <summary>
        /// Accept locally as broadcast, send as broadcast
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        Broadcast,

        /// <summary>
        /// Accept locally as broadcast, but send as unicast
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        Anycast,

        /// <summary>
        /// Multicast
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        Multicast,

        /// <summary>
        /// Drop
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        Blackhole,

        /// <summary>
        /// Destination is unreachable
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        Unreachable,

        /// <summary>
        /// Administratively prohibited
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        Prohibit,

        /// <summary>
        /// Not in this table
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        Throw,

        /// <summary>
        /// Translate this address
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        Nat,

        /// <summary>
        /// Use external resolver
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        Xresolve,
    }

    /// <summary>
    /// Enumeration for result of checking URL callback.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public enum UrlCheckResult
    {
        /// <summary>
        /// URL accessed successfully
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        Success,

        /// <summary>
        /// URL is malformed
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        ErrorMalformedUrl,

        /// <summary>
        /// URL couldn't be resolved
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        ErrorDnsResolve,

        /// <summary>
        /// TCP connection error
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        ErrorTcpConnect,

        /// <summary>
        /// SSL error
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        ErrorSsl,

        /// <summary>
        /// HTTP error
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        ErrorHttp,

        /// <summary>
        /// Remote file not foud
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        ErrorFileNotFound,

        /// <summary>
        /// Unknown error
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        ErrorUnknown = 255,
    }
}
