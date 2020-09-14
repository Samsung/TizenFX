/*
 * Copyright (c) 2020 Samsung Electronics Co., Ltd All Rights Reserved
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

using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// Enumeration for the frame broker result.
    /// </summary>
    internal enum FrameBrokerBaseResult
    {
        /// <summary>
        /// Successful.
        /// </summary>
        None = Interop.FrameBroker.ErrorCode.None,

        /// <summary>
        /// Invalid parameter.
        /// </summary>
        InvalidParameter = Interop.FrameBroker.ErrorCode.InvalidParameter,

        /// <summary>
        /// The memory is insufficient.
        /// </summary>
        OutOfMemory = Interop.FrameBroker.ErrorCode.OutOfMemory,

        /// <summary>
        /// The application to run the given launch request is not found.
        /// </summary>
        AppNotFound = Interop.FrameBroker.ErrorCode.AppNotFound,

        /// <summary>
        /// The application cannot be launched in current context.
        /// </summary>
        LaunchRejected = Interop.FrameBroker.ErrorCode.LaunchRejected,

        /// <summary>
        /// I/O error.
        /// </summary>
        IoError = Interop.FrameBroker.ErrorCode.IoError,

        /// <summary>
        /// Permission denied.
        /// </summary>
        PermissionDenied = Interop.FrameBroker.ErrorCode.PermissionDenied,
    }
}
