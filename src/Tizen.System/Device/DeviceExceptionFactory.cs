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

namespace Tizen.System
{
    internal enum DeviceError
    {
        None = Tizen.Internals.Errors.ErrorCode.None,
        InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
        PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,
        InvalidOperation = Tizen.Internals.Errors.ErrorCode.InvalidOperation,
        AlreadyInProgress = Tizen.Internals.Errors.ErrorCode.NowInProgress,
        NotSupported = Tizen.Internals.Errors.ErrorCode.NotSupported,
        ResourceBusy = Tizen.Internals.Errors.ErrorCode.ResourceBusy,
        OperationFailed = -0x01140000 | 0x01,
        NotInitialized = -0x01140000 | 0x02
    };

    class DeviceExceptionFactory
    {
        internal const string LogTag = "Tizen.System.Device";

        internal static Exception CreateException(DeviceError err, string msg)
        {
            Exception exp;
            switch (err)
            {
                case DeviceError.InvalidParameter:
                case DeviceError.NotInitialized:
                    //fall through
                    exp =  new ArgumentException(msg);
                    break;
                case DeviceError.NotSupported:
                    exp = new NotSupportedException(msg +" : Device does not support the Operation.");
                    break;
                case DeviceError.AlreadyInProgress:
                    //fall through
                case DeviceError.ResourceBusy:
                    //fall through
                case DeviceError.OperationFailed:
                    //fall through
                case DeviceError.InvalidOperation:
                    exp = new InvalidOperationException(msg);
                    break;
                case DeviceError.PermissionDenied:
                    exp = new UnauthorizedAccessException(msg);
                    break;
                default:
                    exp = new InvalidOperationException("Unknown error occured.");
                    break;
            }
            return exp;
        }
    }
}
