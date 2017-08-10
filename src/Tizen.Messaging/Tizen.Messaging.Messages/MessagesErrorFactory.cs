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

namespace Tizen.Messaging.Messages
{
    internal enum MessagesError
    {
        None = ErrorCode.None,
        OutOfMemory = ErrorCode.OutOfMemory,
        InvalidParameter = ErrorCode.InvalidParameter,
        ServerNotReady = -0x01710000 | 0x501,
        CommunicationWithServerFailed = -0x01710000 | 0x502,
        OutOfRange = -0x01710000 | 0x503,
        SendingFailed = -0x01710000 | 0x504,
        OperationFailed = -0x01710000 | 0x505,
        NoSimCard = -0x01710000 | 0x506,
        NoData = -0x01710000 | 0x507,
        PermissionDenied = ErrorCode.PermissionDenied,
        NotSupported = ErrorCode.NotSupported
    }

    internal static class MessagesErrorFactory
    {
        static internal void ThrowMessagesException(int e)
        {
            ThrowException(e, false);
        }

        static internal void ThrowMessagesException(int e, IntPtr handle)
        {
            ThrowException(e, (handle == IntPtr.Zero));
        }

        static private void ThrowException(int e, bool isHandleNull)
        {
            MessagesError err = (MessagesError)e;

            if (isHandleNull)
            {
                throw new InvalidOperationException("Invalid instance (object may have been disposed or release)");
            }

            switch (err)
            {
                case MessagesError.OutOfMemory:
                    throw new OutOfMemoryException(err.ToString());
                case MessagesError.InvalidParameter:
                    throw new ArgumentException(err.ToString());
                case MessagesError.PermissionDenied:
                    throw new UnauthorizedAccessException(err.ToString());
                case MessagesError.NotSupported:
                    throw new NotSupportedException(err.ToString());
                default:
                    throw new InvalidOperationException(err.ToString());
            }
        }
    }
}
