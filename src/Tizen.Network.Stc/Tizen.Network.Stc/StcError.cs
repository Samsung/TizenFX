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

namespace Tizen.Network.Stc
{
    internal static class StcErrorFactory
    {
        internal static void ThrowStcException(int exception)
        {
            StcError _error = (StcError)exception;
            switch (_error)
            {
            case StcError.NotPermitted:
                throw new InvalidOperationException("Operation not permitted");
            case StcError.OutOfMemory:
                throw new InvalidOperationException("Out of memory");
            case StcError.PermissionDenied:
                throw new UnauthorizedAccessException("Permission denied (http://tizen.org/privilege/Stc)");
            case StcError.ResourceBusy:
                throw new InvalidOperationException("Resource is busy");
            case StcError.InvalidOperation:
                throw new InvalidOperationException("Invalid operation"); 
            case StcError.InvalidParameter:
                throw new InvalidOperationException("Invalid parameter");
            case StcError.NotSupported:
                throw new NotSupportedException("Not supported");
            case StcError.OperationFailed:
                throw new InvalidOperationException("Operation failed");
            case StcError.NotInitialized:
                throw new InvalidOperationException("Not initialized");
            case StcError.AlreadyInitialized:
                throw new InvalidOperationException("Already initialized");
            case StcError.InProgress:
                throw new InvalidOperationException("In progress");
            }
        }
    }
}
