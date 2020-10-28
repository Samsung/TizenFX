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
    /// The base exception class that is thrown when specific camera related error occurs.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class CameraException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CameraException"/> class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public CameraException() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CameraException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">A specified error message.</param>
        /// <since_tizen> 3 </since_tizen>
        public CameraException(string message) : base(message)
        {
        }
    }

    /// <summary>
    /// The exception that is thrown when a camera device-related error occurs.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class CameraDeviceException : CameraException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CameraDeviceException"/> class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public CameraDeviceException() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CameraDeviceException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">A specified error message.</param>
        /// <since_tizen> 3 </since_tizen>
        public CameraDeviceException(string message) : base(message)
        {
        }
    }

    /// <summary>
    /// The exception that is thrown when a camera device is not available.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class CameraDeviceNotFoundException : CameraException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CameraDeviceNotFoundException"/> class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public CameraDeviceNotFoundException() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CameraDeviceNotFoundException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">A specified error message.</param>
        /// <since_tizen> 3 </since_tizen>
        public CameraDeviceNotFoundException(string message) : base(message)
        {
        }
    }
}
