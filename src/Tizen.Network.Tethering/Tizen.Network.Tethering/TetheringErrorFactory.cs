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

    internal enum TetheringError
    {
        None = ErrorCode.None,
        NotPermitted = ErrorCode.NotPermitted,
        InvalidParam = ErrorCode.InvalidParameter,
        OutOfMemory = ErrorCode.OutOfMemory,
        ResourceBusy = ErrorCode.ResourceBusy,
        NotEnabled = -0x01C40000 | 0x0501,
        OperationFailed = -0x01C40000 | 0x0502,
        InvalidOperation = ErrorCode.InvalidOperation,
        ApiNotSupported = ErrorCode.NotSupported,
        PermissionDenied = ErrorCode.PermissionDenied,
    }

    internal static class TetheringErrorFactory
    {
        static internal void ThrowTetheringException(int e, IntPtr handle)
        {
            ThrowException(e, (handle == IntPtr.Zero), false, "");
        }

        static internal void ThrowTetheringException(int e, IntPtr handle1, IntPtr handle2)
        {
            ThrowException(e, (handle1 == IntPtr.Zero), (handle2 == IntPtr.Zero), "");
        }

        static internal void ThrowTetheringException(int e, string message)
        {
            ThrowException(e, false, false, message);
        }

        static internal void ThrowTetheringException(int e, IntPtr handle, string message)
        {
            ThrowException(e, (handle == IntPtr.Zero), false, message);
        }

        static internal void ThrowTetheringException(int e, IntPtr handle1, IntPtr handle2, string message)
        {
            ThrowException(e, (handle1 == IntPtr.Zero), (handle2 == IntPtr.Zero), message);
        }

        // Used for return value of native API
        static private void ThrowException(int e, bool isHandle1Null, bool isHandle2Null, string message)
        {
            TetheringError err = (TetheringError)e;
            // TODO: based on different values of err, throw exception
            // switch (err) {}
        }

        // Used in callback
        static internal Exception GetException(int e, string message)
        {
            TetheringError err = (TetheringError)e;
            // TODO: based on different values of err, throw different exceptions
            // switch (err) {}
            return new InvalidOperationException(message + " " + err.ToString());
        }
    }
}
