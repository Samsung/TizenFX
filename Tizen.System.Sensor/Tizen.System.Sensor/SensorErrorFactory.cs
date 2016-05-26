// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;
using Tizen.Internals.Errors;

namespace Tizen.System.Sensor
{
    internal enum SensorError
    {
        None = ErrorCode.None,
        IOError = ErrorCode.IoError,
        InvalidParameter = ErrorCode.InvalidParameter,
        NotSupported = ErrorCode.NotSupported,
        PermissionDenied = ErrorCode.PermissionDenied,
        OutOfMemory = ErrorCode.OutOfMemory,
        NotNeedCalibration = -0x02440000 | 0x03,
        OperationFailed = -0x02440000 | 0x06
    }

    internal static class SensorErrorFactory
    {
        static internal Exception CheckAndThrowException(int error, string msg)
        {
            SensorError e = (SensorError)error;
            switch (e)
            {
                case SensorError.None:
                    return null;
                case SensorError.IOError:
                    return new InvalidOperationException("I/O Error: " + msg);
                case SensorError.InvalidParameter:
                    return new ArgumentException("Invalid Parameter: " + msg);
                case SensorError.NotSupported:
                    return new InvalidOperationException("Not Supported: " + msg);
                case SensorError.PermissionDenied:
                    return new InvalidOperationException("Permission Denied: " + msg);
                case SensorError.OutOfMemory:
                    return new InvalidOperationException("Out of Memory: " + msg);
                case SensorError.NotNeedCalibration:
                    return new InvalidOperationException("Sensor doesn't need calibration: " + msg);
                case SensorError.OperationFailed:
                    return new InvalidOperationException("Operation Failed: " + msg);
                default:
                    return new InvalidOperationException("Unknown Error Code: " + msg);
            }
        }
    }
}