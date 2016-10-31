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
	/// <summary>
    /// Enumeration for sound manager's error codes.
    /// </summary>
    internal enum AudioManagerError{

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

	internal static class AudioManagerErrorFactory
	{
		static internal void CheckAndThrowException(int error, string msg)
		{
			AudioManagerError e = (AudioManagerError) error;
			switch (e)
			{
			case AudioManagerError.None:
				return;
			case AudioManagerError.OutOfMemory:
				throw new InvalidOperationException("Out of Memory: " + msg);
			case AudioManagerError.InvalidParameter:
				throw new ArgumentException("Invalid Parameter: " + msg);
			case AudioManagerError.InvalidOperation:
				throw new InvalidOperationException("Invalid Opertation: " + msg);
			case AudioManagerError.PermissionDenied:
				throw new InvalidOperationException("Permission Denied: " + msg);
			case AudioManagerError.NotSupported:
				throw new InvalidOperationException("Not Supported: " + msg);
			case AudioManagerError.NoData:
				throw new InvalidOperationException("No Data: " + msg);
			case AudioManagerError.Internal:
				throw new InvalidOperationException("Internal Error: " + msg);
			case AudioManagerError.Policy:
				throw new InvalidOperationException("Noncomplaince with System Sound Policy error: " + msg);
			case AudioManagerError.NoPlayingSound:
				throw new InvalidOperationException("No playing sound: " + msg);
			case AudioManagerError.InvalidState:
				throw new InvalidOperationException("Invalid State: " + msg);
			default:
				throw new InvalidOperationException("Unknown Error Code: " + msg);
			}
		}

		static internal void CheckAndThrowException(int error, IntPtr handle, string msg)
		{
			if (handle == IntPtr.Zero)
			{
				throw new InvalidOperationException("Invalid instance (object may have been disposed or released)");
			}
			else
			{
				CheckAndThrowException(error, msg);
			}
		}
	}
}