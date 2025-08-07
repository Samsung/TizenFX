/*
 * Copyright(c) 2023 Samsung Electronics Co., Ltd.
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
    // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class AudioOptions
    {
        private int sampleRate;
        private AudioChannel channel;
        private AudioSampleType sampleType;
        private AudioStreamType streamType;

        private double duckingRatio;
        private uint duckingDuration;
        private AudioStreamType duckingTargetStreamType;


        /// <summary>
        /// Initializes a new instance of the AudioOptions class with the specified sample rate, channel, sampleType and streamType.
        /// </summary>
        /// <param name="sampleRate">the audio sample rate (8000 ~ 192000Hz)</param>
        /// <param name="channel">the audio channel type.</param>
        /// <param name="sampleType">the audio sample type.</param>
        /// <param name="streamType">the audio Stream type.</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AudioOptions(int sampleRate, AudioChannel channel, AudioSampleType sampleType, AudioStreamType streamType)
        {
            this.sampleRate = sampleRate;
            this.channel = channel;
            this.sampleType = sampleType;
            this.streamType = streamType;

            DuckingOptions(AudioStreamType.Media, 500, 0.2);
        }

        /// <summary>
        /// Initialize the DuckingOption values of the AudioOptions class using the specified target StreamType, Duration, and Ratio.
        /// </summary>
        /// <param name="duckingTargetStreamType">the audio Ducking target Stream type.</param>
        /// <param name="duckingDuration">the ducking duration.</param>
        /// <param name="duckingRatio">the ducking target volume ratio.</param>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void DuckingOptions(AudioStreamType duckingTargetStreamType, uint duckingDuration, double duckingRatio)
        {
            this.duckingTargetStreamType = duckingTargetStreamType;
            this.duckingDuration = duckingDuration;
            this.duckingRatio = duckingRatio;
        }

        /// <summary>
        /// The audio sample rate (8000 ~ 192000Hz)
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int SampleRate { get => sampleRate; set => sampleRate = value; }

        /// <summary>
        /// The audio channel type
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AudioChannel Channel { get => channel; set => channel = value; }

        /// <summary>
        /// The audio sample type
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AudioSampleType SampleType { get => sampleType; set => sampleType = value; }

        /// <summary>
        /// The audio stream type
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AudioStreamType StreamType { get => streamType; set => streamType = value; }

        /// <summary>
        /// The audio ducking duration.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint DuckingDuration { get => duckingDuration; set => duckingDuration = value; }

        /// <summary>
        /// The audio ducking ratio.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public double DuckingRatio { get => duckingRatio; set => duckingRatio = value; }

        /// <summary>
        /// The audio ducking target stream type.
        /// </summary>
        // This will be public opened after ACR done. (Before ACR, need to be hidden as Inhouse API)
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AudioStreamType DuckingTargetStreamType { get => duckingTargetStreamType; }
    }
}
