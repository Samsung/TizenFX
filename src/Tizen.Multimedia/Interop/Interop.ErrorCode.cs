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
using System.Runtime.CompilerServices;
using Tizen;

namespace Tizen.Multimedia
{
    internal static partial class Interop
    {
        internal enum ErrorCode
        {
            None = Tizen.Internals.Errors.ErrorCode.None,
            OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,
            InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
            InvalidOperation = Tizen.Internals.Errors.ErrorCode.InvalidOperation,
            PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,
            NotSupported = Tizen.Internals.Errors.ErrorCode.NotSupported,
            ResourceBusy = Tizen.Internals.Errors.ErrorCode.ResourceBusy,
            NoSuchFile = Tizen.Internals.Errors.ErrorCode.NoSuchFile,

            // Radio
            InvalidState = -0x019A0000 | 0x01, // RADIO_ERROR_INVALID_STATE
            SoundPolicy = -0x019A0000 | 0x02, // RADIO_ERROR_SOUND_POLICY
            NoAntenna = -0x019A0000 | 0x03, // RADIO_ERROR_NO_ANTENNA

            // Image/ Video Utility
            NotSupportedFormat = -0x01980000 | 0x01, // VIDEO_UTIL_ERROR_NOT_SUPPORTED_FORMAT
        }
    }

    internal static class ErrorCodeExtensions
    {
        private const string LogTag = "Tizen.Multimedia";

        internal static bool IsSuccess(this Interop.ErrorCode err)
        {
            return err == Interop.ErrorCode.None;
        }

        internal static bool IsFailed(this Interop.ErrorCode err)
        {
            return !err.IsSuccess();
        }

        /// <summary>
        /// Utility method to check for error, returns false if failed and print warning messages
        /// </summary>
        /// <returns>true in case of no error, false otherwise</returns>
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
        /// Utility method to check for error, returns false if failed and throw exception
        /// </summary>
        /// <returns>true in case of no error</returns>
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
                case Interop.ErrorCode.PermissionDenied: return new UnauthorizedAccessException(errMessage);
                case Interop.ErrorCode.InvalidParameter: return new ArgumentException(errMessage);
                case Interop.ErrorCode.NoSuchFile: return new FileNotFoundException(errMessage);
                case Interop.ErrorCode.OutOfMemory: return new OutOfMemoryException(errMessage);
                case Interop.ErrorCode.NoAntenna:
                case Interop.ErrorCode.NotSupported: return new NotSupportedException(errMessage);
                case Interop.ErrorCode.InvalidOperation:
                case Interop.ErrorCode.InvalidState:
                case Interop.ErrorCode.SoundPolicy:
                case Interop.ErrorCode.ResourceBusy:
                default: return new InvalidOperationException(errMessage);
            }
        }
    }
}