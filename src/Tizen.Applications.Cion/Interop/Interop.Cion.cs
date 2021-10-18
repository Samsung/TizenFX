/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class Cion
    {
        internal enum ErrorCode : int
        {
            None = Tizen.Internals.Errors.ErrorCode.None,
            IoError = Tizen.Internals.Errors.ErrorCode.IoError,
            OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,
            PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,
            InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
            InvalidOperation = Tizen.Internals.Errors.ErrorCode.InvalidOperation,
            AlreadyInProgress = Tizen.Internals.Errors.ErrorCode.AlreadyInProgress,
            NotSupported = Tizen.Internals.Errors.ErrorCode.NotSupported,
            TimedOut = Tizen.Internals.Errors.ErrorCode.TimedOut,
            OperationFailed = -0x030C0000 | 0x01,
        }

        [DllImport(Libraries.Libc, EntryPoint = "malloc")]
        internal static extern IntPtr Malloc(int size);
    }
}
