/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.

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
