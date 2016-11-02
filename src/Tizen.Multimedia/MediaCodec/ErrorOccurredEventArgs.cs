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

namespace Tizen.Multimedia.MediaCodec
{
    /// <summary>
    /// Provides data for the <see cref="MediaCodec.ErrorOccurred"/> event.
    /// </summary>
    public class ErrorOccurredEventArgs : EventArgs
    {
        private readonly MediaCodecError _error;

        /// <summary>
        /// Initializes a new instance of the ErrorOccurredEventArgs class.
        /// </summary>
        /// <param name="error">The value representing the type of the error.</param>
        public ErrorOccurredEventArgs(MediaCodecError error)
        {
            _error = error;
        }

        /// <summary>
        /// Gets the value indicating what kind of the error.
        /// </summary>
        public MediaCodecError Error
        {
            get
            {
                return _error;
            }
        }
    }
}
