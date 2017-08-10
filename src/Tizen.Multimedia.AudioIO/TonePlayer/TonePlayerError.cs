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

namespace Tizen.Multimedia
{
    internal enum TonePlayerError
    {
        None = ErrorCode.None,
        InvalidParameter = ErrorCode.InvalidParameter,
        InvalidOperation = ErrorCode.InvalidOperation,
        TizenErrorTonePlayer = -0x01970000,
        TypeNotSupported = TizenErrorTonePlayer | 0x01
    }

    internal static class TonePlayerErrorExtensions
    {
        internal static void Validate(this TonePlayerError error, string message)
        {
            if (error == TonePlayerError.None)
            {
                return;
            }

            switch (error)
            {
                case TonePlayerError.InvalidParameter:
                    throw new ArgumentException(message);

                case TonePlayerError.TypeNotSupported:
                    throw new NotSupportedException(message);

                case TonePlayerError.InvalidOperation:
                    throw new InvalidOperationException(message);

                default:
                    throw new InvalidOperationException(message);

            }
        }
    }
}
