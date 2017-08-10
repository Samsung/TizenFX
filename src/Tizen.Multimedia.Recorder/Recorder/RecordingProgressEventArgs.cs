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
    /// An extened EventArgs class which contain the details of current recording status.
    /// </summary>
    public class RecordingProgressEventArgs : EventArgs
    {
        public RecordingProgressEventArgs(ulong elapsedTime, ulong fileSize)
        {
            ElapsedTime = elapsedTime;
            FileSize = fileSize;
        }

        /// <summary>
        /// The time of recording in milliseconds.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ulong ElapsedTime { get; }

        /// <summary>
        /// The size of the recording file in Kilobyte.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public ulong FileSize { get; }
    }
}
