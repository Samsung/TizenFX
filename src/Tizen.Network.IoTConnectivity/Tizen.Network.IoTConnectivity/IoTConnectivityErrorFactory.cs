/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.

using System;
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
        // TODO: Fix IoTivity error mask
        Representation = 0x10700000 | 0x01,
        InvalidType = 0x10700000 | 0x02,
        Already = 0x10700000 | 0x03,
        System = 0x10700000 | 0x04,
    }

    internal static class IoTConnectivityErrorFactory
    {
        internal const string LogTag = "Tizen.Network.IoTConnectivity";

        internal static void ThrowException(int err)
        {
            IoTConnectivityError error = (IoTConnectivityError)err;
            if (error == IoTConnectivityError.OutOfMemory)
            {
                throw new InvalidOperationException("Out of memory");
            }
            else if (error == IoTConnectivityError.InvalidParameter)
            {
                throw new ArgumentException("Invalid parameter");
            }
            else if (error == IoTConnectivityError.Io)
            {
                throw new ArgumentException("I/O Error");
            }
            else if (error == IoTConnectivityError.NoData)
            {
                throw new ArgumentException("No data found");
            }
            else if (error == IoTConnectivityError.TimedOut)
            {
                throw new ArgumentException("timed out");
            }
            else if (error == IoTConnectivityError.PermissionDenied)
            {
                throw new ArgumentException("Permission denied");
            }
            else if (error == IoTConnectivityError.NotSupported)
            {
                throw new ArgumentException("Not supported");
            }
            else if (error == IoTConnectivityError.Representation)
            {
                throw new ArgumentException("Representation error");
            }
            else if (error == IoTConnectivityError.InvalidType)
            {
                throw new ArgumentException("Invalid type");
            }
            else if (error == IoTConnectivityError.Already)
            {
                throw new ArgumentException("Duplicate");
            }
            else if (error == IoTConnectivityError.System)
            {
                throw new InvalidOperationException("System error");
            }
        }

        internal static Exception GetException(int err)
        {
            IoTConnectivityError error = (IoTConnectivityError)err;
            if (error == IoTConnectivityError.OutOfMemory)
            {
                return new InvalidOperationException("Out of memory");
            }
            else if (error == IoTConnectivityError.InvalidParameter)
            {
                return new ArgumentException("Invalid parameter");
            }
            else if (error == IoTConnectivityError.Io)
            {
                return new ArgumentException("I/O Error");
            }
            else if (error == IoTConnectivityError.NoData)
            {
                return new ArgumentException("No data found");
            }
            else if (error == IoTConnectivityError.TimedOut)
            {
                return new ArgumentException("timed out");
            }
            else if (error == IoTConnectivityError.PermissionDenied)
            {
                return new ArgumentException("Permission denied");
            }
            else if (error == IoTConnectivityError.NotSupported)
            {
                return new ArgumentException("Not supported");
            }
            else if (error == IoTConnectivityError.Representation)
            {
                return new ArgumentException("Representation error");
            }
            else if (error == IoTConnectivityError.InvalidType)
            {
                return new ArgumentException("Invalid type");
            }
            else if (error == IoTConnectivityError.Already)
            {
                return new ArgumentException("Duplicate");
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
