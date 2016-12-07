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

namespace Tizen.Account.OAuth2
{
    internal enum OAuth2Error
    {
        // Tizen Account Oauth Error
        // TIZEN_ERROR_ACCOUNT_OAUTH       -0x01010000

        None = ErrorCode.None,
        OutOfMemory = ErrorCode.OutOfMemory,
        InvalidParameter = ErrorCode.InvalidParameter,
        AlreadyInProgress = ErrorCode.AlreadyInProgress,
        NotSupported = ErrorCode.NotSupported,
        PermissionDenied = ErrorCode.PermissionDenied,
        ParseFailed = -0x01010000 | 0X01,
        NetworkError = -0x01010000 | 0X02,
        Server = -0x01010000 | 0X03,
        UserCancelled = -0x01010000 | 0X04,
        ValueNotFound = -0x01010000 | 0X05,
        Unknown = ErrorCode.Unknown
    }

    internal class ErrorFactory
    {
        internal static string LogTag = "Tizen.Account.OAuth2";

        internal static Exception GetException(IntPtr error)
        {
            int serverErrorCode, platformErrorCode;
            int ret = Interop.Error.GetCode(error, out serverErrorCode, out platformErrorCode);
            if (ret != (int)OAuth2Error.None)
            {
                Log.Debug(ErrorFactory.LogTag, "error code can't be found");
            }

            string errorDescription;
            ret = Interop.Error.GetDescription(error, out errorDescription);
            if (ret != (int)OAuth2Error.None)
            {
                Log.Debug(ErrorFactory.LogTag, "error description can't be found");
            }

            string uri;
            Interop.Error.GetUri(error, out uri);
            if (ret != (int)OAuth2Error.None)
            {
                Log.Debug(ErrorFactory.LogTag, "error uri can't be found");
            }

            var errorResponse = new OAuth2ErrorResponse()
            {
                PlatformErrorCode = platformErrorCode,
                ServerErrorCode = serverErrorCode,
                ErrorUri = uri,
                Error = errorDescription
            };

            return new OAuth2Exception() { Error = errorResponse };
        }

        internal static Exception GetException(int error)
        {
            if ((OAuth2Error)error == OAuth2Error.OutOfMemory)
            {
                return new OutOfMemoryException("Out of memory");
            }
            else if ((OAuth2Error)error == OAuth2Error.InvalidParameter)
            {
                return new ArgumentException("Invalid parameter");
            }
            else if ((OAuth2Error)error == OAuth2Error.AlreadyInProgress)
            {
                return new InvalidOperationException("Request already in progress");
            }
            else if ((OAuth2Error)error == OAuth2Error.NotSupported)
            {
                return new NotSupportedException("Not supported");
            }
            else if ((OAuth2Error)error == OAuth2Error.PermissionDenied)
            {
                return new UnauthorizedAccessException("Permission denied");
            }
            else if ((OAuth2Error)error == OAuth2Error.ParseFailed)
            {
                return new FormatException("Parsing failed");
            }
            else if ((OAuth2Error)error == OAuth2Error.NetworkError)
            {
                return new Exception("Networking error occured");
            }
            else if ((OAuth2Error)error == OAuth2Error.Server)
            {
                return new Exception("Server error");
            }
            else if ((OAuth2Error)error == OAuth2Error.UserCancelled)
            {
                return new Exception("User cancelled");
            }
            else if ((OAuth2Error)error == OAuth2Error.ValueNotFound)
            {
                return new Exception("Value not found");
            }
            else
            {
                return new Exception("Unknown error");
            }
        }
    }
}
