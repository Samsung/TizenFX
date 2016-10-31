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
using System.IO;
using Tizen.Internals.Errors;

namespace Tizen.Network.IoTConnectivity
{
    internal enum IoTConnectivityError
    {
        None = ErrorCode.None,
        InvalidParameter = ErrorCode.InvalidParameter,
        OutOfMemory = ErrorCode.OutOfMemory,
        Io = ErrorCode.IoError,
        PermissionDenied = ErrorCode.PermissionDenied,
        NotSupported = ErrorCode.NotSupported,
        NoData = ErrorCode.NoData,
        TimedOut = ErrorCode.TimedOut,
        Iotivity = -0x01C80000 | 0x01,
        Representation = -0x01C80000 | 0x02,
        InvalidType = -0x01C80000 | 0x03,
        Already = -0x01C80000 | 0x04,
        System = -0x01C80000 | 0x06,
    }

    internal static class IoTConnectivityErrorFactory
    {
        internal const string LogTag = "Tizen.Network.IoTConnectivity";

        internal static void ThrowException(int err)
        {
            throw GetException(err);
        }

        internal static Exception GetException(int err)
        {
            IoTConnectivityError error = (IoTConnectivityError)err;
            if (error == IoTConnectivityError.OutOfMemory)
            {
                return new OutOfMemoryException("Out of memory");
            }
            else if (error == IoTConnectivityError.InvalidParameter)
            {
                return new ArgumentException("Invalid parameter");
            }
            else if (error == IoTConnectivityError.Io)
            {
                return new IOException("I/O Error");
            }
            else if (error == IoTConnectivityError.NoData)
            {
                return new InvalidOperationException("No data found");
            }
            else if (error == IoTConnectivityError.TimedOut)
            {
                return new TimeoutException("timed out");
            }
            else if (error == IoTConnectivityError.PermissionDenied)
            {
                return new UnauthorizedAccessException("Permission denied");
            }
            else if (error == IoTConnectivityError.NotSupported)
            {
                return new NotSupportedException("Not supported");
            }
            else if (error == IoTConnectivityError.Representation)
            {
                return new InvalidOperationException("Representation error");
            }
            else if (error == IoTConnectivityError.InvalidType)
            {
                return new ArgumentException("Invalid type");
            }
            else if (error == IoTConnectivityError.Already)
            {
                return new InvalidOperationException("Duplicate");
            }
            else if (error == IoTConnectivityError.System)
            {
                return new InvalidOperationException("System error");
            }
            else
            {
                return new InvalidOperationException("Invalid operation");
            }
        }
    }
}
