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
using System.Runtime.CompilerServices;
using Tizen;

internal static partial class Interop
{
    internal enum ErrorCode
    {
        None = Tizen.Internals.Errors.ErrorCode.None,
        IoError = Tizen.Internals.Errors.ErrorCode.IoError,
        InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
        PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,
        NoSuchDevice = Tizen.Internals.Errors.ErrorCode.NoSuchDevice,
        ResourceBusy = Tizen.Internals.Errors.ErrorCode.ResourceBusy,
        TimedOut = Tizen.Internals.Errors.ErrorCode.TimedOut,
        BrokenPipe = Tizen.Internals.Errors.ErrorCode.BrokenPipe,
        InterruptedSysCall = Tizen.Internals.Errors.ErrorCode.InterruptedSysCall,
        OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,
        NotSupported = Tizen.Internals.Errors.ErrorCode.NotSupported,
        Unknown = Tizen.Internals.Errors.ErrorCode.Unknown,

        NotFound = -0x024B0000 | 0x01, // USB_HOST_ERROR_NOT_FOUND,
        Overflow = -0x024B0000 | 0x02, // USB_HOST_ERROR_OVERFLOW
        DeviceNotOpened = -0x024B0000 | 0x03, // USB_HOST_ERROR_DEVICE_NOT_OPENED
    }
}

internal static class ErrorCodeExtensions
{
    private const string LogTag = "USB_HOST_CSHARP";

    internal static bool IsSuccess(this Interop.ErrorCode err)
    {
        return err == Interop.ErrorCode.None;
    }

    internal static bool IsFailed(this Interop.ErrorCode err)
    {
        return !err.IsSuccess();
    }

    /// <summary>
    /// The Utility method to check for an error, returns false if failed and prints warning messages.
    /// </summary>
    /// <returns>true in case of no error, false otherwise.</returns>
    internal static bool WarnIfFailed(this Interop.ErrorCode err, string msg, [CallerFilePath] string file = "", [CallerMemberName] string func = "", [CallerLineNumber] int line = 0)
    {
        if (err.IsFailed())
        {
            Log.Info(LogTag, $"{msg}, err: {err.ToString()}", file, func, line);
            Console.WriteLine($"I/{LogTag}: {msg}, err: {err.ToString()}");
            return false;
        }
        return true;
    }

    /// <summary>
    /// The Utility method checks for an error, returns false if failed and throws an exception.
    /// </summary>
    /// <returns>true in case of no error.</returns>
    internal static bool ThrowIfFailed(this Interop.ErrorCode err, string msg, [CallerFilePath] string file = "", [CallerMemberName] string func = "", [CallerLineNumber] int line = 0)
    {
        if (err.IsFailed())
        {
            Log.Error(LogTag, $"{msg}, err: {err.ToString()}", file, func, line);
            Console.WriteLine($"E/{LogTag}: {msg}, err: {err.ToString()}");
            throw err.GetException(msg);
        }
        return true;
    }

    internal static Exception GetException(this Interop.ErrorCode err, string message)
    {
        string errMessage = $"{message}, err: {err.ToString()}";
        switch (err)
        {
            //case Interop.ErrorCode.None:
            case Interop.ErrorCode.PermissionDenied:
                return new UnauthorizedAccessException(errMessage);
            case Interop.ErrorCode.InvalidParameter:
                return new ArgumentException(errMessage);
            case Interop.ErrorCode.TimedOut:
                return new TimeoutException(errMessage);
            case Interop.ErrorCode.OutOfMemory:
                return new OutOfMemoryException(errMessage);
            case Interop.ErrorCode.NotSupported:
                return new NotSupportedException(errMessage);

            case Interop.ErrorCode.IoError:
            case Interop.ErrorCode.NoSuchDevice:
            case Interop.ErrorCode.ResourceBusy:
            case Interop.ErrorCode.BrokenPipe:
            case Interop.ErrorCode.InterruptedSysCall:
            case Interop.ErrorCode.Unknown:

            case Interop.ErrorCode.NotFound:
            case Interop.ErrorCode.Overflow:
            case Interop.ErrorCode.DeviceNotOpened:

            default: return new InvalidOperationException(errMessage);
        }
    }
}
