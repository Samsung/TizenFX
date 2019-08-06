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

using System;
using Tizen.Internals.Errors;

namespace Tizen.Network.NetworkMonitor
{
    static internal class NetworkMonitorErrorValue
    {
        internal const int Base = -0x02FE0000;
    }

    internal enum NetworkMonitorError
    {

        None = ErrorCode.None,
        NotPermitted = ErrorCode.NotPermitted,
        OutOfMemory = ErrorCode.OutOfMemory,
        PermissionDenied = ErrorCode.PermissionDenied,
        ResourceBusy = ErrorCode.ResourceBusy,
        InvalidParameter = ErrorCode.InvalidParameter,
        ConnectionTimeout = ErrorCode.ConnectionTimeout,
        NowInProgress = ErrorCode.NowInProgress,
        NotSupported = ErrorCode.NotSupported,
        NotInitialized = NetworkMonitorErrorValue.Base|0x01,
        AlreadyInitialized = NetworkMonitorErrorValue.Base|0x02,
        OperationFailed = NetworkMonitorErrorValue.Base|0x03,
        DataNotFound = NetworkMonitorErrorValue.Base|0x04,
    }

    internal static class NetworkMonitorErrorFactory
    {
        internal static void ThrowException(int e)
        {
            NetworkMonitorError err = (NetworkMonitorError) e;
            switch (err)
            {
            case NetworkMonitorError.InvalidParameter:
                throw new ArgumentException("Invalid parameter");
            case NetworkMonitorError.NowInProgress:
                throw new NowInProgressException("Now in progress");
            default:
                throw new InvalidOperationException(err.ToString());
            }
        }
    }
}
