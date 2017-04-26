/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Applications
{
    using System;
    using System.Runtime.CompilerServices;

    internal enum BadgeError
    {
        None = Tizen.Internals.Errors.ErrorCode.None,
        InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
        OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,
        PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,
        IoError = Tizen.Internals.Errors.ErrorCode.IoError,
        DbError = -0x01120000 | 0x01,
        AlreadyExists = -0x01120000 | 0x02,
        DBusError = -0x01120000 | 0x03,
        DoesnotExist = -0x01120000 | 0x04,
        ServiceError = -0x01120000 | 0x05,
        InvalidPackage = -0x01120000 | 0x06
    }

    /// <summary>
    /// Immutable class for getting information of the badge.
    /// </summary>
    internal static class BadgeErrorFactory
    {
        private static readonly string LogTag = "Tizen.Applications.Badge";

        internal static Exception GetException(BadgeError ret, string msg, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            Log.Error(LogTag, memberName + " : " + lineNumber);

            switch (ret)
            {
                case BadgeError.InvalidParameter:
                    Log.Error(LogTag, msg);
                    return new ArgumentException(ret + " error occurred.");
                case BadgeError.PermissionDenied:
                    throw new UnauthorizedAccessException("Permission denied (http://tizen.org/privilege/notification)");
                default:
                    Log.Error(LogTag, msg);
                    return new InvalidOperationException(ret + " error occurred.");
            }
        }
    }
}
