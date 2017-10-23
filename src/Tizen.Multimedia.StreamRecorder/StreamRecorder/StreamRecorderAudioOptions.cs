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
using Native = Interop.StreamRecorder;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Specifies the options associated with audio recording.
    /// </summary>
    /// <seealso cref="StreamRecorder"/>
    /// <seealso cref="StreamRecorderOptions"/>
    /// <seealso cref="StreamRecorderVideoOptions"/>
    public class StreamRecorderAudioOptions
    {
        private const int DefaultSampleRate = 0;
        private const int DefaultBitRate = 128000;
        private const int DefaultChannels = 2;

        /// <summary>
        /// Initialize a new instance of the <see cref="StreamRecorderAudioOptions"/> class with the specified codec.
        /// </summary>
        /// <param name="codec">The <see cref="RecorderAudioCodec"/> for encoding audio stream.</param>
        /// <remarks>
        /// <see cref="SampleRate"/>, <see cref="BitRate"/> and <see cref="Channels"/> will be set as default.
        /// </remarks>
        /// <exception cref="ArgumentException"><paramref name="codec"/> is not valid.</exception>
        public StreamRecorderAudioOptions(RecorderAudioCodec codec) :
            this(codec, DefaultSampleRate, DefaultBitRate, DefaultChannels)
        {
        }

        /// <summary>
        /// Initialize a new instance of the <see cref="StreamRecorderAudioOptions"/> class with the specified
        /// codec, sample rate, bit rate, and channel value.
        /// </summary>
        /// <param name="codec">The <see cref="RecorderAudioCodec"/> for encoding audio stream.</param>
        /// <param name="sampleRate">The sample rate for encoding audio stream.</param>
        /// <param name="bitRate">The bit rate for encoding audio stream.</param>
        /// <param name="channels">The number of channels for encoding audio stream.</param>
        /// <exception cref="ArgumentException"><paramref name="codec"/> is not valid.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="sampleRate"/> is less than zero.<br/>
        ///     -or-<br/>
        ///     <paramref name="bitRate"/> is less than or equal to zero.<br/>
        ///     -or-<br/>
        ///     <paramref name="channels"/> is less than or equal to zero.
        /// </exception>
        public StreamRecorderAudioOptions(RecorderAudioCodec codec, int sampleRate, int bitRate, int channels)
        {
            Codec = codec;
            SampleRate = sampleRate;
            BitRate = bitRate;
            Channels = channels;
        }

        private RecorderAudioCodec _codec;

        /// <summary>
        /// Gets or sets the audio codec for encoding an audio stream.
        /// </summary>
        /// <value>The codec for audio stream recording.</value>
        /// <exception cref="ArgumentException"><paramref name="value"/> is not valid.</exception>
        /// <seealso cref="StreamRecorder.GetSupportedAudioCodecs"/>
        public RecorderAudioCodec Codec
        {
            get => _codec;
            set
            {
                ValidationUtil.ValidateEnum(typeof(RecorderAudioCodec), value, nameof(value));

                if (value == RecorderAudioCodec.None)
                {
                    throw new ArgumentException("Audio codec can't be None.");
                }

                _codec = value;
            }
        }

        private int _sampleRate;

        /// <summary>
        /// Gets or sets the sampling rate of the audio stream in hertz.
        /// </summary>
        /// <remarks>If the value is zero, the sample rate will be decided based on input buffers.</remarks>
        /// <value>The sample rate value for stream recorder. The default is zero.</value>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is less than zero.</exception>
        public int SampleRate
        {
            get => _sampleRate;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value,
                        "Sample rate can't be less than or equal to zero.");
                }

                _sampleRate = value;
            }
        }

        private int _bitRate;

        /// <summary>
        /// Gets or sets the bit rate of the audio encoder in bits per second.
        /// </summary>
        /// <value>The bit rate value for audio stream recording. The default is 128000.</value>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is less than or equal to zero.</exception>
        public int BitRate
        {
            get => _bitRate;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value,
                        "Bit rate can't be less than or equal to zero.");
                }

                _bitRate = value;
            }
        }

        private int _channels;

        /// <summary>
        /// Gets or sets the number of audio channels.
        /// </summary>
        /// <value>The number of audio channels for audio stream recording. The default is 2.</value>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is less than or equal to zero.</exception>
        public int Channels
        {
            get => _channels;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value,
                        "Channels can't be less than or equal to zero.");
                }

                _channels = value;
            }
        }

        internal void Apply(StreamRecorder recorder)
        {
            recorder.ValidateAudioCodec(Codec);

            Native.SetAudioEncoder(recorder.Handle, Codec.ToStreamRecorderEnum()).
                ThrowIfError("Failed to set audio codec.");

            Native.SetAudioSampleRate(recorder.Handle, SampleRate).
                ThrowIfError("Failed to set audio sample rate.");

            Native.SetAudioEncoderBitrate(recorder.Handle, BitRate).
                ThrowIfError("Failed to set audio bit rate.");

            Native.SetAudioChannel(recorder.Handle, Channels).
                ThrowIfError("Failed to set audio channels.");
        }
    }

}
