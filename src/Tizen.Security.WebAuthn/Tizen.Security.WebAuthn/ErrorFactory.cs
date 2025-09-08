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

using System;
using System.Runtime.CompilerServices;
using Tizen.Internals.Errors;

namespace Tizen.Security.WebAuthn
{
    internal static class ErrorFactory
    {
        internal const int TizenErrorWebAuthn = -0x03100000;
        private const string LogTag = "Tizen.Security.WebAuthn";

        internal static void CheckErrNThrow(int err, string msg)
        {
            string fullMessage = $"[{LogTag}] {msg}, error={ErrorFacts.GetErrorMessage(err)}";

            switch (err)
            {
                case (int)WauthnError.None:
                    return;
                case (int)WauthnError.InvalidParameter:
                    throw new ArgumentException(fullMessage);
                case (int)WauthnError.PermissionDenied:
                    throw new UnauthorizedAccessException(fullMessage);
                case (int)WauthnError.NotSupported:
                    throw new NotSupportedException(fullMessage);
                case (int)WauthnError.Canceled:
                    throw new OperationCanceledException(fullMessage);
                case (int)WauthnError.TimedOut:
                    throw new TimeoutException(fullMessage);
                default:
                    throw new InvalidOperationException(fullMessage);
            }
        }

        internal static void CheckNullNThrow(object obj, [CallerArgumentExpression("obj")] string name = null)
        {
            if (obj is null)
                throw new ArgumentNullException(name);
        }
    }
}

