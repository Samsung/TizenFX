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

using System;

namespace Tizen.Applications
{
    internal enum ToastMessageError
    {
        None = Tizen.Internals.Errors.ErrorCode.None,
        InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
        DBusError = -0x01140000 | 0x03,
    }

    internal class ToastMessageErrorFactory
    {
        private const string _logTag = "Tizen.Applications.ToastMessage";

        internal static Exception GetException(ToastMessageError ret, string msg)
        {
            switch (ret)
            {
                case ToastMessageError.InvalidParameter:
                    Log.Error(_logTag, msg);
                    return new ArgumentException(ret + " error occurred.");
                default:
                    Log.Error(_logTag, msg);
                    return new InvalidOperationException(ret + " error occurred.");
            }
        }
    }
}
