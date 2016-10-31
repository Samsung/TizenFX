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
using Tizen.Internals.Errors;

namespace Tizen.Sensor
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
                    return new NotSupportedException("Not Supported: " + msg);
                case SensorError.PermissionDenied:
                    return new UnauthorizedAccessException("Permission Denied: " + msg);
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
