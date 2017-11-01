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
    /// Specifies the options associated with video recording.
    /// </summary>
    /// <seealso cref="StreamRecorder"/>
    /// <seealso cref="StreamRecorderOptions"/>
    /// <seealso cref="StreamRecorderAudioOptions"/>
    /// <since_tizen> 4 </since_tizen>
    public class StreamRecorderVideoOptions
    {
        private const int DefaultBitRate = 0;

        /// <summary>
        /// Initialize a new instance of the <see cref="StreamRecorderVideoOptions"/> class with the specified
        /// codec, resolution, source format, and frame rate.
        /// </summary>
        /// <param name="codec">The <see cref="RecorderVideoCodec"/> for encoding video stream.</param>
        /// <param name="resolution">The resolution of video recording.</param>
        /// <param name="sourceFormat">The format of source stream.</param>
        /// <param name="frameRate">The frame rate for encoding video stream.</param>
        /// <remarks>
        /// <see cref="BitRate"/> will be set as default.
        /// </remarks>
        /// <exception cref="ArgumentException">
        ///     <paramref name="codec"/> is not valid.<br/>
        ///     -or-<br/>
        ///     <paramref name="sourceFormat"/> is not valid.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Width or height of <paramref name="resolution"/> is less than or equal to zero.<br/>
        ///     -or-<br/>
        ///     <paramref name="frameRate"/> is less than or equal to zero.
        /// </exception>
        /// <since_tizen> 4 </since_tizen>
        public StreamRecorderVideoOptions(RecorderVideoCodec codec, Size resolution,
            StreamRecorderVideoFormat sourceFormat, int frameRate) :
            this(codec, resolution, sourceFormat, frameRate, DefaultBitRate)
        {
        }

        /// <summary>
        /// Initialize a new instance of the <see cref="StreamRecorderVideoOptions"/> class with the specified
        /// codec, resolution, source format, frame rate, and bit rate.
        /// </summary>
        /// <param name="codec">The <see cref="RecorderVideoCodec"/> for encoding video stream.</param>
        /// <param name="resolution">The resolution of video recording.</param>
        /// <param name="sourceFormat">The format of source stream.</param>
        /// <param name="frameRate">The frame rate for encoding video stream.</param>
        /// <param name="bitRate">The bit rate for encoding video stream.</param>
        /// <exception cref="ArgumentException">
        ///     <paramref name="codec"/> is not valid.<br/>
        ///     -or-<br/>
        ///     <paramref name="sourceFormat"/> is not valid.<br/>
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Width or height of <paramref name="resolution"/> is less than or equal to zero.<br/>
        ///     -or-<br/>
        ///     <paramref name="frameRate"/> is less than or equal to zero.<br/>
        ///     -or-<br/>
        ///     <paramref name="bitRate"/> is less than zero.
        /// </exception>
        /// <since_tizen> 4 </since_tizen>
        public StreamRecorderVideoOptions(RecorderVideoCodec codec, Size resolution,
            StreamRecorderVideoFormat sourceFormat, int frameRate, int bitRate)
        {
            Codec = codec;
            Resolution = resolution;
            SourceFormat = sourceFormat;
            FrameRate = frameRate;
            BitRate = bitRate;
        }

        private RecorderVideoCodec _codec;

        /// <summary>
        /// Gets or sets the video codec for encoding video stream.
        /// </summary>
        /// <value>The codec for video stream recording.</value>
        /// <exception cref="ArgumentException"><paramref name="value"/> is not valid.</exception>
        /// <seealso cref="StreamRecorder.GetSupportedVideoCodecs"/>
        /// <since_tizen> 4 </since_tizen>
        public RecorderVideoCodec Codec
        {
            get => _codec;
            set
            {
                ValidationUtil.ValidateEnum(typeof(RecorderVideoCodec), value, nameof(value));

                _codec = value;
            }
        }

        private Size _resolution;

        /// <summary>
        /// Gets or sets the resolution of the video recording.
        /// </summary>
        /// <value>The output resolution for video stream recording.</value>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     Width or height of <paramref name="value"/> is less than or equal to zero.
        /// </exception>
        /// <seealso cref="StreamRecorder.GetSupportedVideoResolutions"/>
        /// <since_tizen> 4 </since_tizen>
        public Size Resolution
        {
            get => _resolution;
            set
            {
                if (value.Width <= 0 || value.Height <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value,
                        "Resolution can't be less than or equal to zero.");
                }

                _resolution = value;
            }
        }

        private int _frameRate;

        /// <summary>
        /// Gets or sets the frame rate for recording media stream.
        /// </summary>
        /// <value>The frame rate value for video stream recording.</value>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is less than or equal to zero.</exception>
        /// <since_tizen> 4 </since_tizen>
        public int FrameRate
        {
            get => _frameRate;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value,
                        "Frame rate can't be less than or equal to zero.");
                }
                _frameRate = value;
            }
        }

        private StreamRecorderVideoFormat _sourceFormat;

        /// <summary>
        /// Gets or sets the video source format for recording media stream.
        /// </summary>
        /// <value>The source format of buffers for video stream recording.</value>
        /// <exception cref="ArgumentException"><paramref name="value"/> is not valid.</exception>
        /// <since_tizen> 4 </since_tizen>
        public StreamRecorderVideoFormat SourceFormat
        {
            get => _sourceFormat;
            set
            {
                ValidationUtil.ValidateEnum(typeof(StreamRecorderVideoFormat), value, nameof(value));

                _sourceFormat = value;
            }
        }

        private int _bitRate;

        /// <summary>
        /// The bit rate of the video encoder in bits per second.
        /// </summary>
        /// <value>The bit rate value for video stream recording. The default is 0.</value>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is less than zero.</exception>
        /// <since_tizen> 4 </since_tizen>
        public int BitRate
        {
            get => _bitRate;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value,
                        "Bit rate can't be less than or equal to zero.");
                }
                _bitRate = value;
            }
        }

        internal void Apply(StreamRecorder recorder)
        {
            recorder.ValidateVideoCodec(Codec);

            Native.SetVideoEncoder(recorder.Handle, Codec.ToStreamRecorderEnum()).
                ThrowIfError("Failed to set video codec.");

            recorder.ValidateVideoResolution(Resolution);

            Native.SetVideoResolution(recorder.Handle, Resolution.Width, Resolution.Height).
                ThrowIfError("Failed to set video resolution.");

            Native.SetVideoFrameRate(recorder.Handle, FrameRate).
                ThrowIfError("Failed to set video frame rate.");

            Native.SetVideoEncoderBitRate(recorder.Handle, BitRate).
                ThrowIfError("Failed to set video bit rate.");

            Native.SetVideoSourceFormat(recorder.Handle, SourceFormat).
                ThrowIfError("Failed to set video source format.");
        }
    }

}
