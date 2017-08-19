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
    /// Provides data for the <see cref="Recorder.AudioStreamStoring"/> event.
    /// </summary>
    public class AudioStreamStoringEventArgs : EventArgs
    {
        internal AudioStreamStoringEventArgs(IMediaBuffer stream, AudioSampleType type, int channel,
            uint recordingTime)
        {
            Stream = stream;
            Type = type;
            Channels = channel;
            Timestamp = recordingTime;
        }

        /// <summary>
        /// Gets the audio stream buffer.
        /// </summary>
        /// <remarks>
        /// If the stream is modified in the event handler, the modified data will be stored.
        /// \n
        /// The buffer is only valid in the event.\n
        /// Any attempt to access to this buffer after the event ends will throw an exception.
        /// </remarks>
        public IMediaBuffer Stream { get; }

        /// <summary>
        /// Gets the audio format type.
        /// </summary>
        public AudioSampleType Type { get; }

        /// <summary>
        /// Gets the number of channels.
        /// </summary>
        public int Channels { get; }

        /// <summary>
        /// Gets the timestamp(PTS) of stream buffer in milliseconds.
        /// </summary>
        public long Timestamp { get; }
    }
}
