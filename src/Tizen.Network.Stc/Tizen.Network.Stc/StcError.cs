/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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
        internal static Exception GetStcException(int exception)
        {
            StcError _error = (StcError)exception;
            switch (_error)
            {
                case StcError.NotPermitted:
                    return new InvalidOperationException("Operation not permitted");
                case StcError.OutOfMemory:
                    return new InvalidOperationException("Out of memory");
                case StcError.PermissionDenied:
                    return new UnauthorizedAccessException("Permission denied (http://tizen.org/privilege/network.get)");
                case StcError.ResourceBusy:
                    return new InvalidOperationException("Resource is busy");
                case StcError.InvalidOperation:
                    return new InvalidOperationException("Invalid operation");
                case StcError.InvalidParameter:
                    return new ArgumentException("Invalid parameter");
                case StcError.NotSupported:
                    return new NotSupportedException("Unsupported STC feature http://tizen.org/feature/network.traffic_control");
                case StcError.OperationFailed:
                    return new InvalidOperationException("Operation failed");
                case StcError.NotInitialized:
                    return new InvalidOperationException("Not initialized");
                case StcError.AlreadyInitialized:
                    return new InvalidOperationException("Already initialized");
                case StcError.InProgress:
                    return new InvalidOperationException("In progress");
                default:
                    return new InvalidOperationException("Unexpected value error = " + exception);
            }
        }
    }
}
