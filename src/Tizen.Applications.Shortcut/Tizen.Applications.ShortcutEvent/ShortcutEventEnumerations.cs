/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd. All rights reserved.
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

namespace Tizen.Applications.Shortcut
{
    /// <summary>
    /// Enumeration for values of shortcut response types.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum ShortcutError
    {
        /// <summary>
        /// Successful.
        /// </summary>
        None = Tizen.Internals.Errors.ErrorCode.None,

        /// <summary>
        /// Invalid function parameter.
        /// </summary>
        InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,

        /// <summary>
        /// Out of memory.
        /// </summary>
        OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,

        /// <summary>
        /// I/O Error.
        /// </summary>
        IoError = Tizen.Internals.Errors.ErrorCode.IoError,

        /// <summary>
        /// There is no space to add a new shortcut.
        /// </summary>
        NoSpace = -0x01160000 | 0x01,

        /// <summary>
        /// Shortcut is already added.
        /// </summary>
        Exist = -0x01160000 | 0x02,

        /// <summary>
        /// Not exist shortcut.
        /// </summary>
        NotExist = -0x01160000 | 0x08,
    }
}
