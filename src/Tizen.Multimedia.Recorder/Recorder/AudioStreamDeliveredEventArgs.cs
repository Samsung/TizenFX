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
using System.Runtime.InteropServices;

namespace Tizen.Multimedia
{
    /// <summary>
    /// An extended EventArgs class containing details of audio stream.
    /// </summary>
    public class AudioStreamDeliveredEventArgs : EventArgs
    {
        internal AudioStreamDeliveredEventArgs(IntPtr stream, int streamSize, AudioSampleType type, int channel, uint recordingTime)
        {
            Stream = new byte[streamSize];
            Marshal.Copy(stream, Stream, 0, streamSize);
            StreamLength = streamSize;
            Type = type;
            Channel = channel;
            RecordingTime = recordingTime;
        }

        /// <summary>
        /// The audio stream data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public byte[] Stream { get; }

        /// <summary>
        /// The length of audio stream data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int StreamLength { get; }

        /// <summary>
        /// The audio format type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public AudioSampleType Type { get; }

        /// <summary>
        /// The number of channels.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int Channel { get; }

        /// <summary>
        /// The recording time of the stream buffer in milliseconds.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public uint RecordingTime { get; }
    }
}
