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
        PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,
        OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,
        InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
        NotSupported = Tizen.Internals.Errors.ErrorCode.NotSupported,
        ConnectionTimeOut = Tizen.Internals.Errors.ErrorCode.ConnectionTimeout,
        NetworkUnreachable = Tizen.Internals.Errors.ErrorCode.NetworkUnreachable,
        InvalidOperation = Tizen.Internals.Errors.ErrorCode.InvalidOperation,
        KeyNotAvailable = Tizen.Internals.Errors.ErrorCode.KeyNotAvailable,
        ResourceBusy = Tizen.Internals.Errors.ErrorCode.ResourceBusy,
        Canceled = Tizen.Internals.Errors.ErrorCode.Canceled,
        Unknown = Tizen.Internals.Errors.ErrorCode.Unknown,
        UserNotConsented = Tizen.Internals.Errors.ErrorCode.UserNotConsented,
        ServiceNotAvailable = -0x02C20000 | 0x01, // MAPS_ERROR_SERVICE_NOT_AVAILABLE
        NotFound = -0x02C20000 | 0x02, // MAPS_ERROR_NOT_FOUND
    }
}

internal static class ErrorCodeExtensions
{
    private const string LogTag = "Tizen.Maps";

    internal static bool IsSuccess(this Interop.ErrorCode err)
    {
        return err == Interop.ErrorCode.None;
    }

    internal static bool IsFailed(this Interop.ErrorCode err)
    {
        return !err.IsSuccess();
    }

    /// <summary>
    /// The utility method to check for an error. Returns false on failure and prints warning messages.
    /// </summary>
    /// <returns>Returns true in case of no error, otherwise false.</returns>
    internal static bool WarnIfFailed(this Interop.ErrorCode err, string msg, [CallerFilePath] string file = "", [CallerMemberName] string func = "", [CallerLineNumber] int line = 0)
    {
        if (err.IsFailed())
        {
            Log.Debug(LogTag, $"{msg}, err: {err.ToString()}", file, func, line);
            return false;
        }
        return true;
    }

    /// <summary>
    /// The utility method to check for an error. Returns false on failure and throws an exception.
    /// </summary>
    /// <returns>Returns true in case of no error, otherwise false.</returns>
    internal static bool ThrowIfFailed(this Interop.ErrorCode err, string msg, [CallerFilePath] string file = "", [CallerMemberName] string func = "", [CallerLineNumber] int line = 0)
    {
        if (err.IsFailed())
        {
            Log.Error(LogTag, $"{msg}, err: {err.ToString()}", file, func, line);
            throw err.GetException(msg);
        }
        return true;
    }

    internal static Exception GetException(this Interop.ErrorCode err, string message)
    {
        string errMessage = $"{message}, err: {err.ToString()}";
        switch (err)
        {
            //case ErrorCode.None:
            case Interop.ErrorCode.PermissionDenied: return new System.UnauthorizedAccessException(errMessage);
            case Interop.ErrorCode.InvalidParameter: return new System.ArgumentException(errMessage);
            case Interop.ErrorCode.OutOfMemory:
            case Interop.ErrorCode.NotSupported:
            case Interop.ErrorCode.ConnectionTimeOut:
            case Interop.ErrorCode.NetworkUnreachable:
            case Interop.ErrorCode.InvalidOperation:
            case Interop.ErrorCode.KeyNotAvailable:
            case Interop.ErrorCode.ResourceBusy:
            case Interop.ErrorCode.Canceled:
            case Interop.ErrorCode.Unknown:
            case Interop.ErrorCode.ServiceNotAvailable:
            case Interop.ErrorCode.NotFound:
            default: return new System.InvalidOperationException(errMessage);
        }
    }
}
