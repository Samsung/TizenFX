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

namespace Tizen.Applications.NotificationEventListener
{
    using System;
    using System.Runtime.CompilerServices;

    internal static class NotificationEventListenerErrorFactory
    {
        private const string LogTag = "Tizen.Applications.NotificationEventListener";

        internal static Exception GetException(
            Interop.NotificationEventListener.ErrorCode err,
            string msg,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            Log.Error(LogTag, memberName + " : " + lineNumber);
            switch (err)
            {
                case Interop.NotificationEventListener.ErrorCode.InvalidParameter:
                    Log.Error(LogTag, msg);
                    return new ArgumentException(err + " error occurred.");
                case Interop.NotificationEventListener.ErrorCode.PermissionDenied:
                    Log.Error(LogTag, msg);
                    return new UnauthorizedAccessException(err + "Permission denied.");
                default:
                    Log.Error(LogTag, msg);
                    return new InvalidOperationException(err + " error occurred.");
            }
        }
    }
}
