/*
 * Copyright (c) 2024 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;

namespace Tizen.Core
{
    /// <summary>
    /// The class which provides functions relative to Tizen Core.
    /// </summary>
    public static class TCore
    {
        /// <summary>
        /// Initializes Tizen Core.
        /// </summary>
        /// <example>
        /// <code>
        /// 
        /// TCore.Initialize();
        /// 
        /// </code>
        /// </example>
        /// <since_tizen> 12 </since_tizen>
        static public void Initialize()
        {
            Interop.LibTizenCore.TizenCore.Init();
        }

        /// <summary>
        /// Shuts down Tizen Core.
        /// </summary>
        /// <example>
        /// <code>
        /// 
        /// TCore.Shutdown();
        /// 
        /// </code>
        /// </example>
        /// <since_tizen> 12 </since_tizen>
        static public void Shutdown()
        {
            Interop.LibTizenCore.TizenCore.Shutdown();
        }
    }

    internal static class TCoreErrorFactory
    {
        internal enum TCoreError
        {
            None = Interop.LibTizenCore.ErrorCode.None,
            InvalidParameter = Interop.LibTizenCore.ErrorCode.InvalidParameter,
            OutOfMemory = Interop.LibTizenCore.ErrorCode.OutOfMemory,
            InvalidContext = Interop.LibTizenCore.ErrorCode.InvalidContext,
        }

        static internal void CheckAndThrownException(Interop.LibTizenCore.ErrorCode error, string message)
        {
            if ((TCoreError)error == TCoreError.None)
            {
                return;
            }

            if ((TCoreError)error == TCoreError.InvalidParameter)
            {
                throw new ArgumentException(message);
            }
            else if ((TCoreError)error == TCoreError.OutOfMemory)
            {
                throw new OutOfMemoryException(message);
            }
            else if ((TCoreError)error == TCoreError.InvalidContext)
            {
                throw new InvalidOperationException(message);
            }
        }
    }
}
