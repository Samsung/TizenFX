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
    internal enum WavPlayerError
    {
        None = ErrorCode.None,
        InvalidParameter = ErrorCode.InvalidParameter,
        InvalidOperation = ErrorCode.InvalidOperation,
        TizenErrorWavPlayer = -0x01990000,
        FormatNotSupported = TizenErrorWavPlayer | 0x01,
        NotSupportedType = TizenErrorWavPlayer | 0x02
    }

    internal static class WavPlayerErrorExtensions
    {
        internal static void Validate(this WavPlayerError error, string message)
        {
            if (error == WavPlayerError.None)
            {
                return;
            }

            switch (error)
            {
                case WavPlayerError.InvalidParameter:
                    throw new ArgumentException(message);

                case WavPlayerError.FormatNotSupported:
                    throw new FileFormatException(message);

                case WavPlayerError.NotSupportedType:
                    throw new NotSupportedException(message);

                case WavPlayerError.InvalidOperation:
                    throw new InvalidOperationException(message);

                default:
                    break;
            }
        }
    }
}
