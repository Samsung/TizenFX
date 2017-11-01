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
using System.Diagnostics;
using Native = Interop.Recorder;
using NativeHandle = Interop.RecorderHandle;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Provides the ability to control video recording.
    /// </summary>
    public partial class VideoRecorder : Recorder
    {
        private static NativeHandle CreateHandle(Camera camera)
        {
            if (camera == null)
            {
                throw new ArgumentNullException(nameof(camera));
            }

            Native.CreateVideo(camera.Handle, out var handle).
                ThrowIfError("Failed to create video recorder.");

            return handle;
        }

        private static void ThrowIfCodecAndFormatNotValid(RecorderVideoCodec videoCodec,
            RecorderAudioCodec audioCodec, RecorderFileFormat fileFormat)
        {
            videoCodec.ThrowIfFormatNotSupported(fileFormat);

            if (audioCodec != RecorderAudioCodec.None)
            {
                audioCodec.ThrowIfFormatNotSupported(fileFormat);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoRecorder"/> class with the specified
        /// camera, video codec, and file format.
        /// </summary>
        /// <remarks>
        /// If the state of <see cref="Camera"/> is <see cref="CameraState.Created"/>,
        /// the <see cref="CameraSettings.PreviewPixelFormat"/> will be changed to the recommended format for recording.<br/>
        /// <br/>
        /// The initial state of the Recorder will be <see cref="RecorderState.Ready"/>
        /// if the state of <see cref="Camera"/> is <see cref="CameraState.Preview"/> or <see cref="CameraState.Captured"/>.
        /// </remarks>
        /// <param name="camera">The camera object.</param>
        /// <param name="videoCodec">The codec for video encoding.</param>
        /// <param name="fileFormat">The format of result file.</param>
        /// <feature>http://tizen.org/feature/camera</feature>
        /// <exception cref="InvalidOperationException">An internal error occurred.</exception>
        /// <exception cref="NotSupportedException">
        ///     A required feature is not supported.<br/>
        ///     -or-<br/>
        ///     <paramref name="videoCodec"/> is not supported.<br/>
        ///     -or-<br/>
        ///     <paramref name="fileFormat"/> is not supported with the specified video codec.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="videoCodec"/> is not valid.<br/>
        ///     -or-<br/>
        ///     <paramref name="fileFormat"/> is not valid.<br/>
        ///     -or-<br/>
        ///     <paramref name="camera"/> is being used by another object.
        /// </exception>
        /// <exception cref="ObjectDisposedException"><paramref name="camera"/> has been disposed of.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="camera"/> is null.</exception>
        /// <seealso cref="GetSupportedVideoCodecs"/>
        /// <seealso cref="Recorder.GetSupportedFileFormats"/>
        /// <seealso cref="RecorderExtensions.GetSupportedFileFormats(RecorderVideoCodec)"/>
        /// <seealso cref="SetFormatAndCodec(RecorderVideoCodec, RecorderFileFormat)"/>
        /// <seealso cref="SetFormatAndCodec(RecorderVideoCodec, RecorderAudioCodec, RecorderFileFormat)"/>
        /// <since_tizen> 4 </since_tizen>
        public VideoRecorder(Camera camera, RecorderVideoCodec videoCodec, RecorderFileFormat fileFormat) :
            this(camera, videoCodec, RecorderAudioCodec.None, fileFormat)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoRecorder"/> class with the specified
        /// camera, video codec, audio codec, and file format.
        /// </summary>
        /// <remarks>
        /// If the state of <see cref="Camera"/> is <see cref="CameraState.Created"/>,
        /// the <see cref="CameraSettings.PreviewPixelFormat"/> will be changed to the recommended format for recording.<br/>
        /// <br/>
        /// The initial state of the Recorder will be <see cref="RecorderState.Ready"/>
        /// if the state of <see cref="Camera"/> is <see cref="CameraState.Preview"/> or <see cref="CameraState.Captured"/>.
        /// </remarks>
        /// <param name="camera">The camera object.</param>
        /// <param name="videoCodec">The codec for video encoding.</param>
        /// <param name="audioCodec">The codec for audio encoding.</param>
        /// <param name="fileFormat">The format of result file.</param>
        /// <feature>http://tizen.org/feature/camera</feature>
        /// <exception cref="InvalidOperationException">An internal error occurred.</exception>
        /// <exception cref="NotSupportedException">
        ///     A required feature is not supported.<br/>
        ///     -or-<br/>
        ///     <paramref name="videoCodec"/> is not supported.<br/>
        ///     -or-<br/>
        ///     <paramref name="audioCodec"/> is not supported.<br/>
        ///     -or-<br/>
        ///     <paramref name="fileFormat"/> is not supported with the specified video codec.<br/>
        ///     -or-<br/>
        ///     <paramref name="fileFormat"/> is not supported with the specified audio codec.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="videoCodec"/> is not valid.<br/>
        ///     -or-<br/>
        ///     <paramref name="audioCodec"/> is not valid.<br/>
        ///     -or-<br/>
        ///     <paramref name="fileFormat"/> is not valid.
        /// </exception>
        /// <exception cref="ObjectDisposedException"><paramref name="camera"/> has been disposed of.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="camera"/> is null.</exception>
        /// <seealso cref="Recorder.GetSupportedAudioCodecs"/>
        /// <seealso cref="GetSupportedVideoCodecs"/>
        /// <seealso cref="Recorder.GetSupportedFileFormats"/>
        /// <seealso cref="RecorderExtensions.GetSupportedFileFormats(RecorderAudioCodec)"/>
        /// <seealso cref="RecorderExtensions.GetSupportedFileFormats(RecorderVideoCodec)"/>
        /// <seealso cref="SetFormatAndCodec(RecorderVideoCodec, RecorderFileFormat)"/>
        /// <seealso cref="SetFormatAndCodec(RecorderVideoCodec, RecorderAudioCodec, RecorderFileFormat)"/>
        /// <since_tizen> 4 </since_tizen>
        public VideoRecorder(Camera camera, RecorderVideoCodec videoCodec,
            RecorderAudioCodec audioCodec, RecorderFileFormat fileFormat) : base(CreateHandle(camera))
        {
            SetFormatAndCodec(videoCodec, RecorderAudioCodec.None, fileFormat);
        }

        /// <summary>
        /// Sets the video codec and the file format for recording. Audio will not be recorded.
        /// </summary>
        /// <param name="videoCodec">The codec for video encoding.</param>
        /// <param name="fileFormat">The format of result file.</param>
        /// <exception cref="NotSupportedException">
        ///     <paramref name="videoCodec"/> is not supported.<br/>
        ///     -or-<br/>
        ///     <paramref name="fileFormat"/> is not supported with the specified video codec.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="videoCodec"/> is not valid.<br/>
        ///     -or-<br/>
        ///     <paramref name="fileFormat"/> is not valid.
        /// </exception>
        /// <seealso cref="GetSupportedVideoCodecs"/>
        /// <seealso cref="Recorder.GetSupportedFileFormats"/>
        /// <seealso cref="RecorderExtensions.GetSupportedFileFormats(RecorderVideoCodec)"/>
        /// <seealso cref="SetFormatAndCodec(RecorderVideoCodec, RecorderAudioCodec, RecorderFileFormat)"/>
        /// <seealso cref="Recorder.Start(string)"/>
        /// <since_tizen> 4 </since_tizen>
        public void SetFormatAndCodec(RecorderVideoCodec videoCodec, RecorderFileFormat fileFormat)
        {
            SetFormatAndCodec(videoCodec, RecorderAudioCodec.None, fileFormat);
        }

        /// <summary>
        /// Sets the video codec, audio codec, and the file format for recording.
        /// </summary>
        /// <param name="videoCodec">The codec for video encoding.</param>
        /// <param name="audioCodec">The codec for audio encoding.</param>
        /// <param name="fileFormat">The format of result file.</param>
        /// <exception cref="NotSupportedException">
        ///     <paramref name="videoCodec"/> is not supported.<br/>
        ///     -or-<br/>
        ///     <paramref name="audioCodec"/> is not supported.<br/>
        ///     -or-<br/>
        ///     <paramref name="fileFormat"/> is not supported with the specified video codec.<br/>
        ///     -or-<br/>
        ///     <paramref name="fileFormat"/> is not supported with the specified audio codec.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="videoCodec"/> is not valid.<br/>
        ///     -or-<br/>
        ///     <paramref name="audioCodec"/> is not valid.<br/>
        ///     -or-<br/>
        ///     <paramref name="fileFormat"/> is not valid.
        /// </exception>
        /// <seealso cref="Recorder.GetSupportedAudioCodecs"/>
        /// <seealso cref="VideoRecorder.GetSupportedVideoCodecs"/>
        /// <seealso cref="Recorder.GetSupportedFileFormats"/>
        /// <seealso cref="RecorderExtensions.GetSupportedFileFormats(RecorderAudioCodec)"/>
        /// <seealso cref="RecorderExtensions.GetSupportedFileFormats(RecorderVideoCodec)"/>
        /// <seealso cref="SetFormatAndCodec(RecorderVideoCodec, RecorderFileFormat)"/>
        /// <seealso cref="Recorder.Start(string)"/>
        /// <since_tizen> 4 </since_tizen>
        public void SetFormatAndCodec(RecorderVideoCodec videoCodec, RecorderAudioCodec audioCodec, RecorderFileFormat fileFormat)
        {
            ThrowIfCodecAndFormatNotValid(videoCodec, audioCodec, fileFormat);

            VideoCodec = videoCodec;
            AudioCodec = audioCodec;
            FileFormat = fileFormat;
        }

        #region Properties

        private RecorderVideoCodec _videoCodec;

        /// <summary>
        /// Gets the audio codec for encoding an audio stream.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public RecorderVideoCodec VideoCodec
        {
            get => _videoCodec;
            internal set
            {
                Debug.Assert(Enum.IsDefined(typeof(RecorderVideoCodec), value));

                ValidateVideoCodec(value);

                Native.SetVideoEncoder(Handle, value).ThrowIfError("Failed to set video codec.");

                _videoCodec = value;
            }
        }

        /// <summary>
        /// Gets or sets the video recording motion rate.
        /// </summary>
        /// <remarks>
        /// The attribute is valid only in a video recorder.<br/>
        /// If the rate is in range of 0-1, the video is recorded in a slow motion mode.<br/>
        /// If the rate is greater than 1, the video is recorded in a fast motion mode.<br/>
        /// <br/>
        /// To set, the recorder must be in the <see cref="RecorderState.Idle"/> or the <see cref="RecorderState.Ready"/> state.
        /// </remarks>
        /// <exception cref="ArgumentOutOfRangeException">The <paramref name="value"/> is less than or equal to 0.</exception>
        /// <exception cref="InvalidOperationException">The recorder is not in the valid state.</exception>
        /// <exception cref="ObjectDisposedException">The recorder already has been disposed of.</exception>
        /// <since_tizen> 4 </since_tizen>
        public double VideoMotionRate
        {
            get
            {
                Native.GetMotionRate(Handle, out var val).ThrowIfError("Failed to get video motion rate.");

                return val;
            }

            set
            {
                ValidateState(RecorderState.Idle, RecorderState.Ready);

                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value,
                        "Video Motion rate can't be less than zero.");
                }

                Native.SetMotionRate(Handle, value).
                    ThrowIfError("Failed to set video motion rate");
            }
        }

        /// <summary>
        /// Gets or sets the orientation in the video metadata tag.
        /// </summary>
        /// <value>A <see cref="Rotation"/> that specifies the type of orientation.</value>
        /// <exception cref="ArgumentException"><paramref name="value"/> is not valid.</exception>
        /// <exception cref="ObjectDisposedException">The recorder already has been disposed of.</exception>
        /// <since_tizen> 4 </since_tizen>
        public Rotation VideoOrientationTag
        {
            get
            {
                Native.GetOrientationTag(Handle, out var val).ThrowIfError("Failed to get recorder orientation.");

                return val;
            }

            set
            {
                ValidationUtil.ValidateEnum(typeof(Rotation), value, nameof(value));

                Native.SetOrientationTag(Handle, value).
                    ThrowIfError("Failed to set recorder orientation");
            }
        }

        /// <summary>
        /// Gets or sets the resolution of the video recording.
        /// </summary>
        /// <remarks>
        /// To set, the recorder must be in the <see cref="RecorderState.Idle"/> or the <see cref="RecorderState.Ready"/> state.
        /// </remarks>
        /// <exception cref="ArgumentOutOfRangeException">Width or height of <paramref name="value"/> is less than or equal to zero.</exception>
        /// <exception cref="NotSupportedException"><paramref name="value"/> is not supported.</exception>
        /// <exception cref="InvalidOperationException">The recorder is not in the valid state.</exception>
        /// <exception cref="ObjectDisposedException">The recorder already has been disposed of.</exception>
        /// <seealso cref="VideoRecorder.GetSupportedVideoResolutions(CameraDevice)"/>
        /// <since_tizen> 4 </since_tizen>
        public Size VideoResolution
        {
            get
            {
                Native.GetVideoResolution(Handle, out var width, out var height).
                    ThrowIfError("Failed to get camera video resolution");

                return new Size(width, height);
            }

            set
            {
                ValidateState(RecorderState.Idle, RecorderState.Ready);

                if (value.Width <= 0 || value.Height <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value,
                        "Resolution can't be less than or equal to zero.");
                }

                var ret = Native.SetVideoResolution(Handle, value.Width, value.Height);

                if (ret == RecorderErrorCode.InvalidParameter)
                {
                    throw new NotSupportedException($"Resolution({value.ToString()}) is not supported.");
                }

                ret.ThrowIfError("Failed to set video resolution.");
            }
        }

        /// <summary>
        /// Gets or sets the bitrate of the video encoder in bits per second.
        /// </summary>
        /// <remarks>
        /// To set, the recorder must be in the <see cref="RecorderState.Idle"/> or <see cref="RecorderState.Ready"/> state.
        /// </remarks>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is less than or equal to zero.</exception>
        /// <exception cref="InvalidOperationException">The recorder is not in the valid state.</exception>
        /// <exception cref="ObjectDisposedException">The recorder already has been disposed of.</exception>
        /// <since_tizen> 4 </since_tizen>
        public int VideoBitRate
        {
            get
            {
                Native.GetVideoEncoderBitrate(Handle, out var val).ThrowIfError("Failed to get video bitrate.");

                return val;
            }

            set
            {
                ValidateState(RecorderState.Idle, RecorderState.Ready);

                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value,
                        "Bit rate can't be less than or equal to zero.");
                }

                Native.SetVideoEncoderBitrate(Handle, value).
                    ThrowIfError("Failed to set video bitrate");
            }
        }

        #endregion
    }
}