/*
 *  Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
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

using System;
using Tizen.Internals.Errors;

internal static partial class Interop
{
    private const int TizenErrorKeyManager = -0x01E10000;
    private const string LogTag = "Tizen.Security.SecureRepository";


    internal enum KeyManagerError : int
    {
        None = ErrorCode.None,
        InvalidParameter = ErrorCode.InvalidParameter,
        AuthenticationFailed = TizenErrorKeyManager | 0x06, // CKMC_ERROR_AUTHENTICATION_FAILED    
        InvalidFormat = TizenErrorKeyManager | 0x0E, // CKMC_ERROR_INVALID_FORMAT
        UnknownAlias = TizenErrorKeyManager | 0x0C, // CKMC_ERROR_DB_ALIAS_UNKNOWN            
        VerificationFailed = TizenErrorKeyManager | 0x0D // CKMC_ERROR_VERIFICATION_FAILED       
    };

    internal static bool CheckForExistingAlias(int errorCode)
    {
        switch (errorCode)
        {
            case (int)KeyManagerError.None:
            case (int)KeyManagerError.AuthenticationFailed: // Alias already exists, we just may have used the incorrect password
                return true;
            case (int)KeyManagerError.UnknownAlias:
                return false;
            case (int)KeyManagerError.InvalidParameter:
            case (int)KeyManagerError.InvalidFormat:
                throw new ArgumentException(string.Format("[{0}] Failed to determine alias existence, error={2}",
                    LogTag, ErrorFacts.GetErrorMessage(errorCode)));
            default:
                throw new InvalidOperationException(string.Format("[{0}] Failed to determine alias existence, error={2}",
                    LogTag, ErrorFacts.GetErrorMessage(errorCode)));
        }
    }

    internal static void CheckNThrowException(int err, string msg)
    {
        switch (err)
        {
            case (int)KeyManagerError.None:
                return;
            case (int)KeyManagerError.InvalidParameter:
            case (int)KeyManagerError.InvalidFormat:
                throw new ArgumentException(string.Format("[{0}] {1}, error={2}",
                    LogTag, msg, ErrorFacts.GetErrorMessage(err)));
            default:
                throw new InvalidOperationException(string.Format("[{0}] {1}, error={2}",
                    LogTag, msg, ErrorFacts.GetErrorMessage(err)));
        }
    }
}
