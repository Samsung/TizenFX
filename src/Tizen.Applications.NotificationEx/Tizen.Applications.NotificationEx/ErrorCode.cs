/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Applications.NotificationEx
{
    /// <summary>
    /// Enumeration for error codes.    
    /// </summary>
    /// <since_tizen> 7 </since_tizen>
    public enum ErrorCode
    {
        /// <summary>
        /// No error.
        /// </summary>
        None = Tizen.Internals.Errors.ErrorCode.None,

        /// <summary>
        /// Invalid parameter.
        /// </summary>
        InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,

        /// <summary>
        /// Out of memeory.
        /// </summary>
        OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,

        /// <summary>
        /// IO error.
        /// </summary>
        IO = Tizen.Internals.Errors.ErrorCode.IoError,

        /// <summary>
        /// Permission denied.
        /// </summary>
        PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,

        /// <summary>
        /// Invalid operation.
        /// </summary>
        InvalidOperation = Tizen.Internals.Errors.ErrorCode.InvalidOperation,

        /// <summary>
        /// DB error.
        /// </summary>
        DB = -0x01140000 | 0x01,

        /// <summary>
        /// Already exist ID.
        /// </summary>
        AlreadyExistID = -0x01140000 | 0x02,

        /// <summary>
        /// DBus error.
        /// </summary>
        DBus = -0x01140000 | 0x03,

        /// <summary>
        /// Not exist ID.
        /// </summary>
        NotExistID = -0x01140000 | 0x04,

        /// <summary>
        /// The notification service is not ready.
        /// </summary>
        ServiceNotReady = -0x01140000 | 0x05,

        /// <summary>
        /// Max exceeded.
        /// </summary>
        MaxExceeded = -0x01140000 | 0x06,
    }
}
