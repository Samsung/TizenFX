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

namespace Tizen.Network.Tethering
{

    internal static class TetheringErrorFactory
    {
        static internal void ThrowTetheringException(int e, string message)
        {
            ThrowException(e, message);
        }

        static private void ThrowException(int e, string message)
        {
            TetheringError err = (TetheringError)e;
            switch (err) {
                case TetheringError.InvalidParam:
                    throw new ArgumentException("Invalid param: " + message);
                case TetheringError.OutOfMemory:
                    throw new OutOfMemoryException("Out of memory " + message);
                case TetheringError.OperationFailed:
                    throw new Exception("Operation failed: " + message);
                case TetheringError.PermissionDenied:
                    throw new UnauthorizedAccessException("Access denied: " + message);
                case TetheringError.InvalidOperation:
                    throw new NotSupportedException("Not supported: " + message);
                default:
                    throw new InvalidOperationException(err.ToString() + ": " +  message);
            }
        }
    }
}
