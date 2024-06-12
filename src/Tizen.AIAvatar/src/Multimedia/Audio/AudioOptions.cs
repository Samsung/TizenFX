/*
 * Copyright(c) 2024 Samsung Electronics Co., Ltd.
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
 *
 */

using System.ComponentModel;
using Tizen.Multimedia;

namespace Tizen.AIAvatar
{
    /// <summary>
    /// Provides the ability to audio 
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class AudioOptions
    {
        private int sampleRate;
        private AudioChannel channel;
        private AudioSampleType sampleType;

        /// <summary>
        /// Initializes a new instance of the AudioOptions class with the specified sample rate, channel, and sampleType.
        /// </summary>
        /// <param name="sampleRate">the audio sample rate (8000 ~ 192000Hz)</param>
        /// <param name="channel">the audio channel type.</param>
        /// <param name="sampleType">the audio sample type.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AudioOptions(int sampleRate, AudioChannel channel, AudioSampleType sampleType)
        {
            this.sampleRate = sampleRate;
            this.channel = channel;
            this.sampleType = sampleType;
        }

        /// <summary>
        /// The audio sample rate (8000 ~ 192000Hz)
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int SampleRate { get => sampleRate; set => sampleRate = value; }

        /// <summary>
        /// The audio channel type
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AudioChannel Channel { get => channel; set => channel = value; }

        /// <summary>
        /// The audio sample type
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AudioSampleType SampleType { get => sampleType; set => sampleType = value; }
    }
}
