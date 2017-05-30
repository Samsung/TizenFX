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
    /// Provides data for the <see cref="MediaStreamConfiguration.BufferStatusChanged"/> event.
    /// </summary>
    public class MediaStreamBufferStatusChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the MediaStreamBufferStatusChangedEventArgs class.
        /// </summary>
        /// <param name="status">The value indicating the status of the stream.</param>
        public MediaStreamBufferStatusChangedEventArgs(MediaStreamBufferStatus status)
        {
            Status = status;
        }

        /// <summary>
        /// Gets the status.
        /// </summary>
        public MediaStreamBufferStatus Status { get; }

        public override string ToString()
        {
            return $"Status : { Status.ToString() }";
        }
    }
}
