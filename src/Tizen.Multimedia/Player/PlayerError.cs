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
    internal enum PlayerErrorCode
    {
        None = ErrorCode.None,
        InvalidArgument = ErrorCode.InvalidParameter,
        OutOfMemory = ErrorCode.OutOfMemory,
        NoSuchFile = ErrorCode.NoSuchFile,
        InvalidOperation = ErrorCode.InvalidOperation,
        NoSpaceOnDevice = ErrorCode.FileNoSpaceOnDevice,
        FeatureNotSupported = ErrorCode.NotSupported,
        PermissionDenied = ErrorCode.PermissionDenied,
        NoBufferSpace = ErrorCode.BufferSpace,
        TizenPlayerError = -0x01940000,
        PlayerErrorClass = TizenPlayerError | 0x20,
        SeekFailed = PlayerErrorClass | 0x01,
        InvalidState = PlayerErrorClass | 0x02,
        NotSupportedFile = PlayerErrorClass | 0x03,
        InvalidUri = PlayerErrorClass | 0x04,
        SoundPolicyError = PlayerErrorClass | 0x05,
        ConnectionFailed = PlayerErrorClass | 0x06,
        VideoCaptureFailed = PlayerErrorClass | 0x07,
        DrmExpired = PlayerErrorClass | 0x08,
        DrmNoLicense = PlayerErrorClass | 0x09,
        DrmFutureUse = PlayerErrorClass | 0x0a,
        DrmNotPermitted = PlayerErrorClass | 0x0b,
        ResourceLimit = PlayerErrorClass | 0x0c,
        ServiceDisconnected = PlayerErrorClass | 0x0d
    }

    internal static class PlayerErrorConverter
    {
        internal static void ThrowIfError(int errorCode, string errorMessage)
        {
            if (errorCode == (int)PlayerErrorCode.None)
            {
                return;
            }
            PlayerErrorCode err = (PlayerErrorCode)errorCode;

            string msg = $"{ (errorMessage ?? "Operation failed") } : { err.ToString() }.";

            switch ((PlayerErrorCode)errorCode)
            {
                case PlayerErrorCode.InvalidArgument:
                case PlayerErrorCode.InvalidUri:
                case PlayerErrorCode.NoSuchFile:
                    throw new ArgumentException(msg);

                case PlayerErrorCode.OutOfMemory:
                case PlayerErrorCode.NoSpaceOnDevice:
                    throw new OutOfMemoryException(msg);

                case PlayerErrorCode.PermissionDenied:
                case PlayerErrorCode.InvalidOperation:
                case PlayerErrorCode.InvalidState:
                case PlayerErrorCode.FeatureNotSupported:
                case PlayerErrorCode.SeekFailed:
                case PlayerErrorCode.NotSupportedFile:
                case PlayerErrorCode.ConnectionFailed:
                case PlayerErrorCode.VideoCaptureFailed:
                case PlayerErrorCode.DrmExpired:
                case PlayerErrorCode.DrmNoLicense:
                case PlayerErrorCode.DrmFutureUse:
                case PlayerErrorCode.DrmNotPermitted:
                    throw new InvalidOperationException(msg);

                case PlayerErrorCode.NoBufferSpace:
                    throw new NoBufferSpaceException(msg);

                case PlayerErrorCode.ResourceLimit:
                    throw new ResouceLimitException(msg);
            }

            throw new Exception(msg);
        }
    }
    /// <summary>
    /// The exception that is thrown when there is no available space in a buffer.
    /// </summary>
    public class NoBufferSpaceException : InvalidOperationException
    {
        /// <summary>
        /// Initializes a new instance of the NoBufferSpaceException class with a specified error message.
        /// </summary>
        /// <param name="message">Error description.</param>
        public NoBufferSpaceException(string message) : base(message)
        {
        }
    }

    /// <summary>
    /// The exception that is thrown when there is no available resource for internal use.
    /// </summary>
    public class ResouceLimitException : InvalidOperationException
    {
        /// <summary>
        /// Initializes a new instance of the ResouceLimitException class with a specified error message.
        /// </summary>
        /// <param name="message">Error description.</param>
        public ResouceLimitException(string message) : base(message)
        {
        }
    }
}

