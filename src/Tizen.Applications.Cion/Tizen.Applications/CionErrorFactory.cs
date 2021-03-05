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

namespace Tizen.Applications
{
    internal static class CionErrorFactory
    {
        internal static Exception GetException(Interop.Cion.ErrorCode err, string message)
        {
            string errMessage = string.Format("{0} err = {1}", message, err);
            switch (err)
            {
                case Interop.Cion.ErrorCode.InvalidParameter:
                    return new ArgumentException(errMessage);
                case Interop.Cion.ErrorCode.OutOfMemory:
                    return new OutOfMemoryException(errMessage);
                case Interop.Cion.ErrorCode.IoError:
                    return new global::System.IO.IOException(errMessage);
                case Interop.Cion.ErrorCode.PermissionDenied:
                    return new UnauthorizedAccessException(errMessage);
                case Interop.Cion.ErrorCode.InvalidOperation:
                    return new InvalidOperationException(errMessage);
                case Interop.Cion.ErrorCode.NotSupported:
                    return new NotSupportedException(errMessage);
                default:
                    return new InvalidOperationException(errMessage);
            }
        }
    }
}
