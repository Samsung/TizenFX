/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Applications
{
    /// <summary>
    /// Enumeration for the application control result.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public enum AppControlResult
    {
        /// <summary>
        /// Successful.
        /// </summary>
        None = Interop.AppControl.ErrorCode.None,

        /// <summary>
        /// Invalid parameter.
        /// </summary>
        InvalidParameter = Interop.AppControl.ErrorCode.InvalidParameter,

        /// <summary>
        /// The application to run the given launch request is not found.
        /// </summary>
        AppNotFound = Interop.AppControl.ErrorCode.AppNotFound,

        /// <summary>
        /// The application cannot be launched in current context.
        /// </summary>
        LaunchRejected = Interop.AppControl.ErrorCode.LaunchRejected,

        /// <summary>
        /// Permission denied.
        /// </summary>
        PermissionDenied = Interop.AppControl.ErrorCode.PermissionDenied,
    }
}
