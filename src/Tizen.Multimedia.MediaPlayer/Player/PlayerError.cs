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
using System.IO;
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
        ServiceDisconnected = PlayerErrorClass | 0x0d,
        NotSupportedAudioCodec = PlayerErrorClass | 0x0e,
        NotSupportedVideoCodec = PlayerErrorClass | 0x0f,
        NotSupportedSubtitle = PlayerErrorClass | 0x10,
        NotAvailable = PlayerErrorClass | 0x12
    }

    internal static class PlayerErrorCodeExtensions
    {
        internal static void ThrowIfFailed(this PlayerErrorCode err, Player player, string message)
        {
            if (err == PlayerErrorCode.None)
            {
                return;
            }

            var ex = err.GetException(message);

            if (ex == null)
            {
                // Notify only when it can't be handled.
                player?.NotifyError((int)err, message);

                throw new InvalidOperationException($"{message} : Unknown error({err.ToString()}).");
            }

            throw ex;
        }

        internal static Exception GetException(this PlayerErrorCode err, string message)
        {
            if (err == PlayerErrorCode.None)
            {
                return null;
            }

            string msg = $"{ (message ?? "Operation failed") } : { err.ToString() }.";

            switch (err)
            {
                case PlayerErrorCode.InvalidArgument:
                case PlayerErrorCode.InvalidUri:
                    throw new ArgumentException(msg);

                case PlayerErrorCode.NoSuchFile:
                    throw new FileNotFoundException(msg);

                case PlayerErrorCode.OutOfMemory:
                    throw new OutOfMemoryException(msg);

                case PlayerErrorCode.NoSpaceOnDevice:
                    throw new IOException(msg);

                case PlayerErrorCode.PermissionDenied:
                    throw new UnauthorizedAccessException(msg);

                case PlayerErrorCode.NotSupportedFile:
                    throw new FileFormatException(msg);

                case PlayerErrorCode.FeatureNotSupported:
                    throw new NotSupportedException(msg);

                case PlayerErrorCode.DrmExpired:
                case PlayerErrorCode.DrmNoLicense:
                case PlayerErrorCode.DrmFutureUse:
                case PlayerErrorCode.DrmNotPermitted:
                // TODO consider another exception.
                case PlayerErrorCode.InvalidOperation:
                case PlayerErrorCode.InvalidState:
                case PlayerErrorCode.SeekFailed:
                case PlayerErrorCode.ConnectionFailed:
                case PlayerErrorCode.VideoCaptureFailed:
                    throw new InvalidOperationException(msg);

                case PlayerErrorCode.NoBufferSpace:
                    throw new NoBufferSpaceException(msg);

                case PlayerErrorCode.ResourceLimit:
                    throw new ResourceLimitException(msg);

                case PlayerErrorCode.NotSupportedAudioCodec:
                    throw new CodecNotSupportedException(CodecKind.Audio);

                case PlayerErrorCode.NotSupportedVideoCodec:
                    throw new CodecNotSupportedException(CodecKind.Video);

                case PlayerErrorCode.NotAvailable:
                    throw new NotAvailableException(msg);
            }

            return null;
        }
    }

    /// <summary>
    /// The exception that is thrown when there is no available space in a buffer.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class NoBufferSpaceException : InvalidOperationException
    {
        /// <summary>
        /// Initializes a new instance of the NoBufferSpaceException class with a specified error message.
        /// </summary>
        /// <param name="message">Error description.</param>
        /// <since_tizen> 3 </since_tizen>
        public NoBufferSpaceException(string message) : base(message)
        {
        }
    }

    /// <summary>
    /// The exception that is thrown when there is no available resource for internal use.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class ResourceLimitException : InvalidOperationException
    {
        /// <summary>
        /// Initializes a new instance of the ResourceLimitException class with a specified error message.
        /// </summary>
        /// <param name="message">Error description.</param>
        /// <since_tizen> 3 </since_tizen>
        public ResourceLimitException(string message) : base(message)
        {
        }
    }

    /// <summary>
    /// The exception that is thrown when it is not available.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class NotAvailableException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the NotAvailableException class with a specified error message.
        /// </summary>
        /// <param name="message">Error description.</param>
        /// <since_tizen> 6 </since_tizen>
        public NotAvailableException(string message) : base(message)
        {
        }
    }
}

