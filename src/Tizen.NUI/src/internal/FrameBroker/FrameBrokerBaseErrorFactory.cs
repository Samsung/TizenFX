/*
 * Copyright (c) 2020 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Runtime.CompilerServices;
using Tizen.Applications.Exceptions;

namespace Tizen.NUI
{
    internal static class FrameBrokerBaseErrorFactory
    {
        private static string logTag = "NUI";

        internal static Exception GetException(Interop.FrameBroker.ErrorCode err, string message, [CallerMemberName] string memberName = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            Log.Error(logTag, memberName + "(" + lineNumber + ") " + message);
            switch (err)
            {
                case Interop.FrameBroker.ErrorCode.InvalidParameter:
                    return new ArgumentException("Invalid Parameter");
                case Interop.FrameBroker.ErrorCode.OutOfMemory:
                    return new Applications.Exceptions.OutOfMemoryException("Out Of Memory");
                case Interop.FrameBroker.ErrorCode.AppNotFound:
                    return new AppNotFoundException("App Not Found");
                case Interop.FrameBroker.ErrorCode.LaunchRejected:
                    return new LaunchRejectedException("Launch Rejected");
                case Interop.FrameBroker.ErrorCode.IoError:
                    return new InvalidOperationException("IO Error");
                case Interop.FrameBroker.ErrorCode.PermissionDenied:
                    return new PermissionDeniedException("Permission Denied");
                default:
                    return new InvalidOperationException(message);
            }
        }
    }
}
