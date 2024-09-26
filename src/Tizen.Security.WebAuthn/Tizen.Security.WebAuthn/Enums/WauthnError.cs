/*
 *  Copyright (c) 2024 Samsung Electronics Co., Ltd All Rights Reserved
 *
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License
 */

using Tizen.Internals.Errors;
using static Tizen.Security.WebAuthn.ErrorFactory;

namespace Tizen.Security.WebAuthn
{
    /// <summary>
    /// WebAuthn error code.
    /// </summary>
    public enum WauthnError
    {
        /// <summary>
        /// Successful.
        /// </summary>
        None                    = ErrorCode.None,
        /// <summary>
        /// Unknown error.
        /// </summary>
        Unknown                 = ErrorCode.Unknown,
        /// <summary>
        /// Invalid function parameter.
        /// </summary>
        InvalidParameter        = ErrorCode.InvalidParameter,
        /// <summary>
        /// Permission denied.
        /// </summary>
        PermissionDenied        = ErrorCode.PermissionDenied,
        /// <summary>
        /// Not supported operation.
        /// </summary>
        NotSupported            = ErrorCode.NotSupported,
        /// <summary>
        /// Memory error.
        /// </summary>
        OutOfMemory             = ErrorCode.OutOfMemory,
        /// <summary>
        /// Canceled by cancel request.
        /// </summary>
        Canceled                = ErrorCode.Canceled,
        /// <summary>
        /// Timeout.
        /// </summary>
        TimedOut                = ErrorCode.TimedOut,
        /// <summary>
        /// Authenticator is uncontactable.
        /// </summary>
        ConnectionRefused       = ErrorCode.ConnectionRefused,
        /// <summary>
        /// Successful and needs to wait for other result.
        /// </summary>
        NoneAndWait             = TizenErrorWebAuthn | 0x01,
        /// <summary>
        /// Not allowed in the current context.
        /// </summary>
        NotAllowed              = TizenErrorWebAuthn | 0x02,
        /// <summary>
        /// Invalid State.
        /// </summary>
        InvalidState            = TizenErrorWebAuthn | 0x03,
        /// <summary>
        /// Encoding operation failed.
        /// </summary>
        EncodingFailed          = TizenErrorWebAuthn | 0x04,
        /// <summary>
        /// Socket error.
        /// </summary>
        Socket                  = TizenErrorWebAuthn | 0x05,
        /// <summary>
        /// Socket operation on non-socket error.
        /// </summary>
        NoSuchDevice            = TizenErrorWebAuthn | 0x06,
        /// <summary>
        /// Socket access denied.
        /// </summary>
        AccessDenied            = TizenErrorWebAuthn | 0x07,
    }
}