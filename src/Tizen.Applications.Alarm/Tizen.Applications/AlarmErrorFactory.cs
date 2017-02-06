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

namespace Tizen.Applications
{
    internal enum AlarmError
    {
        None = Tizen.Internals.Errors.ErrorCode.None,
        InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
        InvalidTime = -0x01100000 | 0x05,
        InvalidDate = -0x01100000 | 0x06,
        ConnectionFail = -0x01100000 | 0x07,
        NotPermittedApp = -0x01100000 | 0x08,
        OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,
        PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied
    }
    internal static class AlarmErrorFactory
    {
        private const string _logTag = "Tizen.Applications.Alarm";

        internal static Exception GetException(AlarmError ret, string msg)
        {
            switch (ret)
            {
                case AlarmError.InvalidParameter:
                //fall through
                case AlarmError.InvalidTime:
                //fall through
                case AlarmError.InvalidDate:
                    Log.Error(_logTag, msg);
                    return new ArgumentException(ret + " error occurred.");
                case AlarmError.NotPermittedApp:
                //fall through
                case AlarmError.PermissionDenied:
                    Log.Error(_logTag, msg);
                    return new UnauthorizedAccessException(ret + "error occured.");
                default:
                    Log.Error(_logTag, msg);
                    return new InvalidOperationException(ret + " error occurred.");
            }
        }
    }
}
