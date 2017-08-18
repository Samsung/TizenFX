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
    internal enum AudioManagerError
    {
        SoundManagerError = -0x01960000,
        /// <summary>
        /// Successful
        /// </summary>
        None = ErrorCode.None,
        /// <summary>
        /// Out of memory
        /// </summary>
        OutOfMemory = ErrorCode.OutOfMemory,
        /// <summary>
        /// Invalid parameter
        /// </summary>
        InvalidParameter = ErrorCode.InvalidParameter,
        /// <summary>
        /// Invalid operation
        /// </summary>
        InvalidOperation = ErrorCode.InvalidOperation,
        /// <summary>
        /// Permission denied
        /// </summary>
        PermissionDenied = ErrorCode.PermissionDenied,
        /// <summary>
        /// Not supported
        /// </summary>
        NotSupported = ErrorCode.NotSupported,
        /// <summary>
        /// No data
        /// </summary>
        NoData = ErrorCode.NoData,
        /// <summary>
        /// Internal error inside the sound system
        /// </summary>
        Internal = SoundManagerError | 01,
        /// <summary>
        /// Noncompliance with the sound system policy
        /// </summary>
        Policy = SoundManagerError | 02,
        /// <summary>
        /// No playing sound
        /// </summary>
        NoPlayingSound = SoundManagerError | 03,
        /// <summary>
        /// Invalid state (Since 3.0)
        /// </summary>
        InvalidState = SoundManagerError | 04
    }

    internal static class AudioManagerErrorExtensions
    {
        internal static void Validate(this AudioManagerError err, string msg)
        {
            if (err == AudioManagerError.None)
            {
                return;
            }

            msg = msg ?? "";
            msg += $" : {err}.";

            switch (err)
            {
                case AudioManagerError.OutOfMemory:
                    throw new OutOfMemoryException(msg);

                case AudioManagerError.InvalidParameter:
                    throw new ArgumentException(msg);

                case AudioManagerError.PermissionDenied:
                    throw new UnauthorizedAccessException(msg);

                case AudioManagerError.NotSupported:
                    throw new NotSupportedException(msg);

                case AudioManagerError.Policy:
                    throw new AudioPolicyException(msg);

                case AudioManagerError.NoData:
                    // TODO check when it is thrown
                    throw new InvalidOperationException(msg);

                case AudioManagerError.Internal:
                case AudioManagerError.InvalidOperation:
                case AudioManagerError.NoPlayingSound:
                case AudioManagerError.InvalidState:
                    throw new InvalidOperationException(msg);

                default:
                    throw new InvalidOperationException("Unknown Error : " + msg);
            }
        }
    }
}
