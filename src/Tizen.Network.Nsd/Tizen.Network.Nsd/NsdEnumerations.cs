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

using Tizen.Internals.Errors;

namespace Tizen.Network.Nsd
{
    /// <summary>
    /// Enumeration for DNS-SD service state.
    /// </summary>
    public enum DnssdServiceState
    {
        /// <summary>
        /// Available DNS-SD service found.
        /// </summary>
        Available,
        /// <summary>
        /// DNS-SD service not available.
        /// </summary>
        Unavailable,
        /// <summary>
        /// Lookup failure for service name.
        /// </summary>
        ServiceNameLookupFailed,
        /// <summary>
        /// Lookup failure for host name and port number.
        /// </summary>
        HostNameLookupFailed,
        /// <summary>
        /// Lookup failure for IP address.
        /// </summary>
        AddressLookupFailed
    }

    /// <summary>
    /// Enumeration for SSDP service state.
    /// </summary>
    public enum SsdpServiceState
    {
        /// <summary>
        /// Available SSDP service found.
        /// </summary>
        Available,
        /// <summary>
        /// SSDP service not available.
        /// </summary>
        Unavailable
    }

    internal enum DnssdError
    {
        None = ErrorCode.None,
        OutOfMemory = ErrorCode.OutOfMemory,
        InvalidOperation = ErrorCode.InvalidOperation,
        InvalidParameter = ErrorCode.InvalidParameter,
        NotSupported = ErrorCode.NotSupported,
        NotInitialized = -0x01CA0000 | 0x01,
        AlreadyRegistered = -0x01CA0000 | 0x02,
        NameConflict = -0x01CA0000 | 0x03,
        ServiceNotRunning = -0x01CA0000 | 0x04,
        ServiceNotFound = -0x01CA0000 | 0x05,
        OperationFailed = -0x01CA0000 | 0x06
    }

    internal enum SsdpError
    {
        None = ErrorCode.None,
        OutOfMemory = ErrorCode.OutOfMemory,
        InvalidParameter = ErrorCode.InvalidParameter,
        NotSupported = ErrorCode.NotSupported,
        NotInitialized = -0x01C90000 | 0x01,
        OperationFailed = -0x01C90000 | 0x04,
        ServiceNotFound = -0x01C90000 | 0x05,
        ServiceAlreadyRegistered = -0x01C90000 | 0x06
    }
}
