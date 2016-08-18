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

internal static partial class Interop
{
    private const int TizenErrorKeyManager = -0x01E10000;

    internal enum KeyManagerError : int
    {
        // TODO : Add reference to real Tizen project
        //None = Tizen.Internals.Errors.ErrorCode.None,
        //InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter
        None = 0, // CKMC_ERROR_NONE
        InvalidParameter = -22, // CKMC_ERROR_INVALID_PARAMETER
        VerificationFailed = TizenErrorKeyManager | 0x0D // CKMC_ERROR_VERIFICATION_FAILED
    };

    internal class KeyManagerExceptionFactory
    {
        internal const string LogTag = "Tizen.Security.SecureRepository";

        internal static void CheckNThrowException(int err, string msg)
        {
            if (err == (int)KeyManagerError.None)
                return;

            switch (err)
            {
                case (int)KeyManagerError.InvalidParameter:
                    throw new ArgumentException(msg + ", error=" + Interop.GetErrorMessage(err));
                default:
                    throw new InvalidOperationException(msg + ", error=" + Interop.GetErrorMessage(err));
            }
        }
    }
}
