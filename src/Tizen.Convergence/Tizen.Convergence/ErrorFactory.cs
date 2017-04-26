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
using System.Threading.Tasks;
using System.Threading;

namespace Tizen.Convergence
{
    internal enum ConvErrorCode
    {
        None = ErrorCode.None,
        OutOfMemory = ErrorCode.OutOfMemory,
        InvalidParameter = ErrorCode.InvalidParameter,
        InvalidOperation = ErrorCode.InvalidOperation,
        NoData = ErrorCode.NoData,
        NotSupported = ErrorCode.NotSupported,
        PermissionDenied = ErrorCode.PermissionDenied,
    }

    internal class ErrorFactory
    {
        internal static string LogTag = "Tizen.Convergence";

        internal static Exception GetException(int error)
        {
            if ((ConvErrorCode)error == ConvErrorCode.OutOfMemory)
            {
                return new OutOfMemoryException("Out of memory");
            }
            else if ((ConvErrorCode)error == ConvErrorCode.InvalidParameter)
            {
                return new ArgumentException("Invalid parameter");
            }
            else if ((ConvErrorCode)error == ConvErrorCode.InvalidOperation)
            {
                return new InvalidOperationException("Invalid operation");
            }
            else if ((ConvErrorCode)error == ConvErrorCode.NotSupported)
            {
                return new NotSupportedException("Unsupported feature http://tizen.org/feature/convergence.d2d");
            }
            else if ((ConvErrorCode)error == ConvErrorCode.PermissionDenied)
            {
                return new UnauthorizedAccessException("Permission denied. (http://tizen.org/privilege/internet, http://tizen.org/privilege/bluetooth, http://tizen.org/privilege/d2d.datasharing)");
            }
            else if ((ConvErrorCode)error == ConvErrorCode.NoData)
            {
                return new InvalidOperationException("The payload is empty");
            }
            else
            {
                return new Exception("Unknown error");
            }
        }
    }
}
