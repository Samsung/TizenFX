/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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
using Tizen.Internals.Errors;

namespace Tizen.Network.Stc
{
    /// <summary>
    /// Internal Enumeration for Stc time period.
    /// </summary>
    internal enum NativeTimePeriodType
    {
        /// <summary>
        /// Unknown
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// Hour
        /// </summary>
        Hour = 3600,
        /// <summary>
        /// Day
        /// </summary>
        Day = 86400,
        /// <summary>
        /// Week
        /// </summary>
        Week = 604800,
        /// <summary>
        /// Month
        /// </summary>
        Month = 2419200
    }

    /// <summary>
    /// Enumeration for Stc time period.
    /// </summary>
    public enum TimePeriodType
    {
        /// <summary>
        /// Hour
        /// </summary>
        Hour = 3600,
        /// <summary>
        /// Day
        /// </summary>
        Day = 86400,
        /// <summary>
        /// Week
        /// </summary>
        Week = 604800,
        /// <summary>
        /// Month
        /// </summary>
        Month = 2419200
    }

    /// <summary>
    /// Internal Enumeration for network interface type.
    /// </summary>
    internal enum NativeNetworkInterface
    {
        /// <summary>
        /// Network interface type is Unknown.
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// Network interface type is datacall.
        /// </summary>
        Datacall,
        /// <summary>
        /// Network interface type is  wifi.
        /// </summary>
        Wifi,
        /// <summary>
        /// Network interface type is  wired.
        /// </summary>
        Wired,
        /// <summary>
        /// Network interface type is bluetooth.
        /// </summary>
        Bluetooth,
        /// <summary>
        /// Network interface type is all.
        /// </summary>
        All
    }

    /// <summary>
    /// Enumeration for network interface type.
    /// </summary>
    public enum NetworkInterface
    {
        /// <summary>
        /// Network interface type is datacall. 
        /// </summary>
        Datacall,
        /// <summary>
        /// Network interface type is  wifi.
        /// </summary>
        Wifi,
        /// <summary>
        /// Network interface type is  wired.
        /// </summary>
        Wired,
        /// <summary>
        /// Network interface type is bluetooth.
        /// </summary>
        Bluetooth,
        /// <summary>
        /// Network interface type is all.
        /// </summary>
        All
    }

    /// <summary>
    /// Internal Enumeration for network roaming type
    /// </summary>
    internal enum RoamingType
    {
        /// <summary>
        /// Not in roaming.
        /// </summary>
        Disabled,
        /// <summary>
        /// In roaming.
        /// </summary>
        Enabled
    }

    /// <summary>
    /// Internal Enumeration for hardware network protocol type.
    /// </summary>
    internal enum NativeNetworkProtocol
    {
        /// <summary>
        /// Network unknown.
        /// </summary>
        Unknown,
        /// <summary>
        /// Network no service.
        /// </summary>
        NoService,
        /// <summary>
        /// Network emergency.
        /// </summary>
        Emergency,
        /// <summary>
        /// Network search 1900.
        /// </summary>
        Search,
        /// <summary>
        /// Network 2G.
        /// </summary>
        Datacall_2G,
        /// <summary>
        /// Network 2.5G.
        /// </summary>
        Datacall_2_5G,
        /// <summary>
        /// Network EDGE.
        /// </summary>
        Datacall_2_5G_Edge,
        /// <summary>
        /// Network UMTS.
        /// </summary>
        Datacall_3G,
        /// <summary>
        /// Network HSDPA.
        /// </summary>
        Hsdpa,
        /// <summary>
        /// Network LTE.
        /// </summary>
        Lte
    }

    /// <summary>
    /// Enumeration for hardware network protocol type.
    /// </summary>
    public enum NetworkProtocol
    {
        /// <summary>
        /// Network no service.
        /// </summary>
        NoService,
        /// <summary>
        /// Network emergency.
        /// </summary>
        Emergency,
        /// <summary>
        /// Network search 1900.
        /// </summary>
        Search,
        /// <summary>
        /// Network 2G.
        /// </summary>
        Datacall_2G,
        /// <summary>
        /// Network 2.5G.
        /// </summary>
        Datacall_2_5G,
        /// <summary>
        /// Network EDGE.
        /// </summary>
        Datacall_2_5G_Edge,
        /// <summary>
        /// Network UMTS.
        /// </summary>
        Datacall_3G,
        /// <summary>
        /// Network HSDPA.
        /// </summary>
        Hsdpa,
        /// <summary>
        /// Network LTE.
        /// </summary>
        Lte
    }

    /// <summary>
    /// Internal Enumeration for monitored process state.
    /// </summary>
    internal enum ProcessState
    {
        /// <summary>
        /// Unknown state.
        /// </summary>
        Unknown,
        /// <summary>
        /// Foreground state.
        /// </summary>
        Foreground,
        /// <summary>
        /// Background state.
        /// </summary>
        Background
    }

    /// <summary>
    /// Enumeration for return type of the callback.
    /// </summary>
    internal enum CallbackRet
    {
        /// <summary>
        /// Cancel
        /// </summary>
        Cancel,
        /// <summary>
        /// Continue
        /// </summary>
        Continue
    }

    /// <summary>
    /// Internal Enumeration for the Stc error code.
    /// </summary>
    internal enum StcError
    {
        /// <summary>
        /// Successful.
        /// </summary>
        None = ErrorCode.None,
        /// <summary>
        /// Operation not permitted.
        /// </summary>
        NotPermitted = ErrorCode.NotPermitted,
        /// <summary>
        /// Out of memory.
        /// </summary>
        OutOfMemory = ErrorCode.OutOfMemory,
        /// <summary>
        /// Permission denied.
        /// </summary>
        PermissionDenied = ErrorCode.PermissionDenied,
        /// <summary>
        /// Device or the resource is busy.
        /// </summary>
        ResourceBusy = ErrorCode.ResourceBusy,
        /// <summary>
        /// Invalid operation.
        /// </summary>
        InvalidOperation = ErrorCode.InvalidOperation, 
        /// <summary>
        /// Invalid function parameter.
        /// </summary>
        InvalidParameter = ErrorCode.InvalidParameter,
        /// <summary>
        /// Not supported.
        /// </summary>
        NotSupported = ErrorCode.NotSupported,
        /// <summary>
        /// Operation failed.
        /// </summary>
        OperationFailed = -0x02F80000 | 0x01,
        /// <summary>
        /// Not initialized.
        /// </summary>
        NotInitialized = -0x02F80000 | 0x02,
        /// <summary>
        /// Already initialized the client.
        /// </summary>
        AlreadyInitialized = -0x02F80000 | 0x03,
        /// <summary>
        /// In progress.
        /// </summary>
        InProgress = -0x02F80000 | 0x04
    }
}
