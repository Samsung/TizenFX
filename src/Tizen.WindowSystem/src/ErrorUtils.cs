/*
 * Copyright(c) 2020 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using System;
using Tizen.Applications.Exceptions;

namespace Tizen.WindowSystem
{
    internal static class ErrorUtils
    {
        private const int ErrorTzsh = -0x02860000;
        private const int NoServiceError = ErrorTzsh | 0x01;

        internal static void ThrowIfError(int error, string message = null)
        {
            if (error == (int)Tizen.Internals.Errors.ErrorCode.None)
            {
                return;
            }

            string msg = message ?? "Unknown Error";

            if (error == (int)Tizen.Internals.Errors.ErrorCode.OutOfMemory)
            {
                throw new Tizen.Applications.Exceptions.OutOfMemoryException("Out of Memory");
            }
            else if (error == (int)Tizen.Internals.Errors.ErrorCode.InvalidParameter)
            {
                throw new ArgumentException("Invalid Parameter");
            }
            else if (error == (int)Tizen.Internals.Errors.ErrorCode.PermissionDenied)
            {
                throw new PermissionDeniedException("Permission denied");
            }
            else if (error == (int)Tizen.Internals.Errors.ErrorCode.NotSupported)
            {
                throw new NotSupportedException("Not Supported");
            }
            else if (error == (int)Tizen.Internals.Errors.ErrorCode.InvalidOperation)
            {
                throw new InvalidOperationException("Invalid Operation");
            }
            else if (error == NoServiceError)
            {
                throw new InvalidOperationException("No Service");
            }
            else
            {
                throw new InvalidOperationException(msg);
            }
        }
    }
}
