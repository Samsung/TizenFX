/*
* Copyright (c) 2020 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Peripheral
{
    /// <summary>
    /// The class that represents the exception which will be thrown when the application can not control the peripherial.
    /// </summary>
    internal static class ExceptionFactory
    {
        internal static Exception CreateException(ErrorCode errorCode)
        {
            Log.Error("Peripheral", $"Error {errorCode}");

            switch (errorCode)
            {
                case ErrorCode.IoError:
                    return new InvalidOperationException("I/O Error occured");

                case ErrorCode.NoSuchDevice:
                    return new InvalidOperationException("No such device");

                case ErrorCode.TryAgain:
                    return new InvalidOperationException("Try again");

                case ErrorCode.OutOfMemory:
                    return new Exception("Out of memory");

                case ErrorCode.PermissionDenied:
                    return new UnauthorizedAccessException("Permission denied");

                case ErrorCode.ResourceBusy:
                    return new InvalidOperationException("Resource is busy");

                case ErrorCode.InvalidParameter:
                    return new ArgumentException("Invalid parameters provided");

                case ErrorCode.NotSupported:
                    return new InvalidOperationException("I/O Error occured");

                case ErrorCode.Unknown:
                    return new InvalidOperationException("Unknown exception");

                default:
                    return new Exception("");
            }
        }
    }
}
