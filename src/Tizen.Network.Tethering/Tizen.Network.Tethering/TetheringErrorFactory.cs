/*
 * Copyright (c) 2025 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Network.Tethering
{

    internal enum TetheringExtError
    {
        None = 0x00,

        // Common Errors
        Unknown = -999,

        // Client Register Related Errors
        AppAlreadyRegistered = -990,
        AppNotRegistered = -989,

        // Other Errors
        AccessDenied = -799,
        InProgress = -798,
        OperationAborted = -797,
        InvalidParam = -796,
        InvalidOperation = -795,
        NotSupported = -794,
        Timeout = -793,
        UnknownMethod = -792,
        AlreadyExists = -791,
        OutOfMemory = -790,
        ServiceUnknown = -789,
        OperationFailed = -788,
        NotSet = -787
    }

    internal static class TetheringExtErrorFactory
    {
        static internal void ThrowTetheringExtException(int e, IntPtr handle)
        {
            ThrowException(e, (handle == IntPtr.Zero), false, "");
        }

        static internal void ThrowTetheringExtException(int e, IntPtr handle1, IntPtr handle2)
        {
            ThrowException(e, (handle1 == IntPtr.Zero), (handle2 == IntPtr.Zero), "");
        }

        static internal void ThrowTetheringExtException(int e, string message)
        {
            ThrowException(e, false, false, message);
        }

        static internal void ThrowTetheringExtException(int e, IntPtr handle, string message)
        {
            ThrowException(e, (handle == IntPtr.Zero), false, message);
        }

        static internal void ThrowTetheringExtException(int e, IntPtr handle1, IntPtr handle2, string message)
        {
            ThrowException(e, (handle1 == IntPtr.Zero), (handle2 == IntPtr.Zero), message);
        }

        // Used for return value of native API
        static private void ThrowException(int e, bool isHandle1Null, bool isHandle2Null, string message)
        {
            TetheringExtError err = (TetheringExtError)e;
            switch (err) {
                case TetheringExtError.AccessDenied:
                    throw new UnauthorizedAccessException("Access denied: " + message);
                case TetheringExtError.OperationAborted:
                    throw new OperationCanceledException("Operation aborted: " + message);
                case TetheringExtError.InvalidParam:
                    throw new ArgumentException("Invalid param: " + message);
                case TetheringExtError.NotSupported:
                    throw new NotSupportedException("Not supported: " + message);
                case TetheringExtError.Timeout:
                    throw new TimeoutException("Timeout: "+ message);
                case TetheringExtError.OutOfMemory:
                    throw new OutOfMemoryException("Out of memory " + message);
                case TetheringExtError.OperationFailed:
                    throw new Exception("Operation failed: " + message);
                default:
                    throw new InvalidOperationException(err.ToString() + ": " +  message);
            }
        }

        // Used in callback
        // static internal Exception GetException(int e, string message)
        // {
        //     TetheringExtError err = (TetheringExtError)e;
        //     // switch (err) {}
        //     return new InvalidOperationException(message + " " + err.ToString());
        // }
    }
}
