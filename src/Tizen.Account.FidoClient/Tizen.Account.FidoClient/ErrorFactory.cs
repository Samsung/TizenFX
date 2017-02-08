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

namespace Tizen.Account.FidoClient
{
    internal enum FidoErrorCode
    {
        None = ErrorCode.None,
        OutOfMemory = ErrorCode.OutOfMemory,
        InvalidParameter = ErrorCode.InvalidParameter,
        NoData = ErrorCode.NoData,
        NotSupported = ErrorCode.NotSupported,
        PermissionDenied = ErrorCode.PermissionDenied,
        UserActionInProgress = -0x01030000 | 0x01,
        UserCancelled = -0x01030000 | 0x02,
        UnsupportedVersion = -0x01030000 | 0x03,
        NoSuitableAuthenticator = -0x01030000 | 0x04,
        ProtocolError = -0x01030000 | 0x05,
        UntrustedFacetId = -0x01030000 | 0x06,
        Unknown = ErrorCode.Unknown
    }

    internal class ErrorFactory
    {
        internal static string LogTag = "Tizen.Account.FidoClient";

        internal static Exception GetException(int error)
        {
            if ((FidoErrorCode)error == FidoErrorCode.OutOfMemory)
            {
                return new OutOfMemoryException("Out of memory");
            }
            else if ((FidoErrorCode)error == FidoErrorCode.InvalidParameter)
            {
                return new ArgumentException("Invalid parameter");
            }
            else if ((FidoErrorCode)error == FidoErrorCode.UserActionInProgress)
            {
                return new InvalidOperationException("User action already in progress");
            }
            else if ((FidoErrorCode)error == FidoErrorCode.NotSupported)
            {
                return new NotSupportedException("FIDO is unsupported.");
            }
            else if ((FidoErrorCode)error == FidoErrorCode.PermissionDenied)
            {
                return new UnauthorizedAccessException("Permission denied");
            }
            else if ((FidoErrorCode)error == FidoErrorCode.UnsupportedVersion)
            {
                return new NotSupportedException("UAF message's version is not supported.");
            }
            else if ((FidoErrorCode)error == FidoErrorCode.NoSuitableAuthenticator)
            {
                return new Exception("Suitable authenticator can't be found");
            }
            else if ((FidoErrorCode)error == FidoErrorCode.ProtocolError)
            {
                return new Exception("Protocol error, the interaction may have timed out, or the UAF message is malformed.");
            }
            else if ((FidoErrorCode)error == FidoErrorCode.UserCancelled)
            {
                return new Exception("User has canceled the operation.");
            }
            else if ((FidoErrorCode)error == FidoErrorCode.UntrustedFacetId)
            {
                return new Exception(" The caller's id is not allowed to use this operation.");
            }
            else
            {
                return new Exception("Unknown error");
            }
        }
    }
}
