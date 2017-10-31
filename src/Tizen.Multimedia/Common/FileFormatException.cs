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

using System;

namespace Tizen.Multimedia
{
    /// <summary>
    /// The exception that is thrown when an input file or a data stream that is supposed to conform
    /// to a certain file format specification, is malformed.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class FileFormatException : FormatException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileFormatException"/> class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public FileFormatException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileFormatException"/> class with a specified error message.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public FileFormatException(string message) : base(message)
        {
        }
    }
}
