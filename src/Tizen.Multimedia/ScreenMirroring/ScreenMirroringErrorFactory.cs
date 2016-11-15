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

﻿using System;
using Tizen.Internals.Errors;
namespace Tizen.Multimedia
{
    internal enum SCMirroringErrorCode
    {
        None = ErrorCode.None,
        InvalidParameter = ErrorCode.InvalidParameter,
        OutOfMemory = ErrorCode.OutOfMemory,
        InvalidOperation = ErrorCode.InvalidOperation,
        ConnectionTimeOut = ErrorCode.ConnectionTimeout,
        PermissionDenied = ErrorCode.PermissionDenied,
        NotSupported = ErrorCode.NotSupported,
        Unknown = ErrorCode.Unknown
    };
    public class ScreenMirroringErrorFactory
    {
        internal static void ThrowException(int errorCode, string errorMessage = null, string paramName = null)
        {
            SCMirroringErrorCode err = (SCMirroringErrorCode)errorCode;
            if (string.IsNullOrEmpty(errorMessage))
            {
                errorMessage = err.ToString();
            }

            switch ((SCMirroringErrorCode)errorCode)
            {
                case SCMirroringErrorCode.InvalidParameter:
                throw new ArgumentException(errorMessage, paramName);

                case SCMirroringErrorCode.OutOfMemory:
                case SCMirroringErrorCode.InvalidOperation:
                case SCMirroringErrorCode.ConnectionTimeOut:
                case SCMirroringErrorCode.PermissionDenied:
                case SCMirroringErrorCode.NotSupported:
                case SCMirroringErrorCode.Unknown:
                throw new InvalidOperationException(errorMessage);
            }
        }
    }
}

