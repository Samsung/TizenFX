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
    /// ErrorOccurred event arguments
    /// </summary>
    /// <remarks>
    /// ErrorOccurred event arguments
    /// </remarks>
    public class ErrorOccurredEventArgs : EventArgs
    {
        internal int _error;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="error"> Error Occurred </param>
        internal ErrorOccurredEventArgs(int error)
        {
            _error = error;
        }

        /// <summary>
        /// Get the error code.
        /// </summary>
        /// <value> error code </value>
        public SCMirroringError Error
        {
            get
            {
                return (SCMirroringError)_error;
            }
        }
    }
}