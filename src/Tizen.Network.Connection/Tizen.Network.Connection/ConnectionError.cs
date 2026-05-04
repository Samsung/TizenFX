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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tizen.Network.Connection
{
    internal static class ConnectionErrorFactory
    {
        internal static void CheckFeatureUnsupportedException(int err, string message)
        {
            if ((ConnectionError)err == ConnectionError.NotSupported)
            {
                ThrowConnectionException(err, message);
            }
        }

        internal static void CheckPermissionDeniedException(int err, string message)
        {
            if ((ConnectionError)err == ConnectionError.PermissionDenied)
            {
                ThrowConnectionException(err, message);
            }
        }

        internal static void CheckHandleNullException(int err, bool isHandleInvalid, string message)
        {
            if ((ConnectionError)err == ConnectionError.InvalidParameter)
            {
                if (isHandleInvalid)
                {
                    ThrowConnectionException((int)ConnectionError.InvalidOperation, message);
                }
            }
        }

        internal static void ThrowConnectionException(int errno, string message = "")
        {
            ConnectionError error = (ConnectionError)errno;
            Log.Debug(Globals.LogTag, $"ThrowConnectionException {error}");

            throw error switch
            {
                ConnectionError.AddressFamilyNotSupported => new InvalidOperationException("Address Family Not Supported"),
                ConnectionError.AlreadyExists             => new InvalidOperationException("Already Exists"),
                ConnectionError.DhcpFailed                => new InvalidOperationException("DHCP Failed"),
                ConnectionError.EndOfIteration            => new InvalidOperationException("End Of Iteration"),
                ConnectionError.InvalidKey                => new InvalidOperationException("Invalid Key"),
                ConnectionError.InvalidOperation          => new InvalidOperationException($"Invalid Operation {message}".TrimEnd()),
                ConnectionError.InvalidParameter          => new ArgumentException($"Invalid Parameter {message}".TrimEnd()),
                ConnectionError.NoConnection              => new InvalidOperationException("No Connection"),
                ConnectionError.NoReply                   => new InvalidOperationException("No Reply"),
                ConnectionError.NotSupported              => new NotSupportedException($"Unsupported feature {message}".TrimEnd()),
                ConnectionError.NowInProgress             => new InvalidOperationException("Now In Progress"),
                ConnectionError.OperationAborted          => new InvalidOperationException("Operation Aborted"),
                ConnectionError.OperationFailed           => new InvalidOperationException("Operation Failed"),
                ConnectionError.OutOfMemoryError          => new OutOfMemoryException("Out Of Memory Error"),
                ConnectionError.PermissionDenied          => new UnauthorizedAccessException($"Permission Denied {message}".TrimEnd()),
                _                                         => new InvalidOperationException(
                                                                 $"Unknown ConnectionError({errno}) {message}".TrimEnd())
            };
        }
    }
}