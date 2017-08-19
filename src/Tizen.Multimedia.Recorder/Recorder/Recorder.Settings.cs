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

namespace Tizen.Multimedia
{
    public partial class Recorder
    {
        private RecorderAudioCodec _audioCodec;

        /// <summary>
        /// Gets the audio codec for encoding an audio stream.
        /// </summary>
        /// <seealso cref="GetSupportedAudioCodecs"/>
        public RecorderAudioCodec AudioCodec
        {
            get => _audioCodec;
            internal set
            {
                Debug.Assert(Enum.IsDefined(typeof(RecorderAudioCodec), value));

                if (this is AudioRecorder || value != RecorderAudioCodec.None)
                {
                    ValidateAudioCodec(value);
                }

                Native.SetAudioEncoder(Handle, value).ThrowIfError("Failed to set audio encoder.");

                _audioCodec = value;
            }
        }

        private RecorderFileFormat _fileFormat;

        /// <summary>
        /// Gets the file format of the recording result.
        /// </summary>
        /// <seealso cref="GetSupportedFileFormats"/>
        public RecorderFileFormat FileFormat
        {
            get => _fileFormat;
            internal set
            {
                Debug.Assert(Enum.IsDefined(typeof(RecorderFileFormat), value));

                ValidateFileFormat(value);

                Native.SetFileFormat(Handle, value).ThrowIfError("Failed to set file format.");

                _fileFormat = value;
            }
        }

        /// <summary>
        /// Gets or sets the number of audio channel.
        /// </summary>
        /// <remarks>
        /// To set, the recorder must be in the <see cref="RecorderState.Idle"/> or <see cref="RecorderState.Ready"/> state.
        /// </remarks>
        /// <value>
        /// For mono recording, set channel to 1.
        /// For stereo recording, set channel to 2.
        /// </value>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is less than or equal to zero.</exception>
        /// <exception cref="InvalidOperationException">The recorder is not in the valid state.</exception>
        /// <exception cref="ObjectDisposedException">The recorder already has been disposed of.</exception>
        public int AudioChannels
        {
            get
            {
                Native.GetAudioChannel(Handle, out var val).ThrowIfError("Failed to get audio channel.");

                return val;
            }

            set
            {
                ValidateState(RecorderState.Idle, RecorderState.Ready);

                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value,
                        "Audio channels can't be less than or equal to zero.");
                }

                Native.SetAudioChannel(Handle, value).ThrowIfError("Failed to set audio channel");
            }
        }

        /// <summary>
        /// Gets or sets the audio device for recording.
        /// </summary>
        /// <remarks>
        /// To set, the recorder must be in the <see cref="RecorderState.Idle"/> or <see cref="RecorderState.Ready"/> state.
        /// </remarks>
        /// <value>A <see cref="RecorderAudioDevice"/> that specifies the type of audio device.</value>
        /// <exception cref="ArgumentException"><paramref name="value"/> is not valid.</exception>
        /// <exception cref="InvalidOperationException">The recorder is not in the valid state.</exception>
        /// <exception cref="ObjectDisposedException">The recorder already has been disposed of.</exception>
        public RecorderAudioDevice AudioDevice
        {
            get
            {
                Native.GetAudioDevice(Handle, out var val).ThrowIfError("Failed to get the audio device.");

                return val;
            }

            set
            {
                ValidateState(RecorderState.Idle, RecorderState.Ready);

                ValidationUtil.ValidateEnum(typeof(RecorderAudioDevice), value, nameof(value));

                Native.SetAudioDevice(Handle, value).ThrowIfError("Failed to set the audio device.");
            }
        }

        /// <summary>
        /// Gets or sets the sampling rate of an audio stream in hertz.
        /// </summary>
        /// <remarks>
        /// To set, the recorder must be in the <see cref="RecorderState.Idle"/> or <see cref="RecorderState.Ready"/> state.
        /// </remarks>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is less than or equal to zero.</exception>
        /// <exception cref="InvalidOperationException">The recorder is not in the valid state.</exception>
        /// <exception cref="ObjectDisposedException">The recorder already has been disposed of.</exception>
        public int AudioSampleRate
        {
            get
            {
                Native.GetAudioSampleRate(Handle, out var val).
                    ThrowIfError("Failed to get audio sample rate.");

                return val;
            }

            set
            {
                ValidateState(RecorderState.Idle, RecorderState.Ready);

                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value,
                        "Sample rate can't be less than or equal to zero.");
                }

                Native.SetAudioSampleRate(Handle, value).
                    ThrowIfError("Failed to set audio sample rate.");
            }
        }

        /// <summary>
        /// Gets or sets the bitrate of an audio encoder in bits per second.
        /// </summary>
        /// <remarks>
        /// To set, the recorder must be in the <see cref="RecorderState.Idle"/> or <see cref="RecorderState.Ready"/> state.
        /// </remarks>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is less than or equal to zero.</exception>
        /// <exception cref="InvalidOperationException">The recorder is not in the valid state.</exception>
        /// <exception cref="ObjectDisposedException">The recorder already has been disposed of.</exception>
        public int AudioBitRate
        {
            get
            {
                Native.GetAudioEncoderBitrate(Handle, out var val).ThrowIfError("Failed to get audio bitrate.");

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

                Native.SetAudioEncoderBitrate(Handle, value).
                    ThrowIfError("Failed to set audio bitrate");
            }
        }

        /// <summary>
        /// Gets or sets the maximum size of a recording file.
        /// </summary>
        /// <value>
        /// The maximum size of a recording file in kilobytes, or 0 for unlimited size.
        /// </value>
        /// <remarks>
        /// After reaching the limitation, the data which is being recorded will
        /// be discarded and not written to the file.\n
        /// \n
        /// To set, the recorder must be in the<see cref="RecorderState.Idle"/> or <see cref= "RecorderState.Ready" /> state.
        /// </remarks>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is less than zero.</exception>
        /// <exception cref="InvalidOperationException">The recorder is not in the valid state.</exception>
        /// <exception cref="ObjectDisposedException">The recorder already has been disposed of.</exception>
        public int SizeLimit
        {
            get
            {
                int val = 0;

                Native.GetSizeLimit(Handle, out val).
                    ThrowIfError("Failed to get size limit.");

                return val;
            }

            set
            {
                ValidateState(RecorderState.Idle, RecorderState.Ready);

                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value,
                        "Size limit can't be less than zero.");
                }

                Native.SetSizeLimit(Handle, value).ThrowIfError("Failed to set size limit");
            }
        }

        /// <summary>
        /// Gets or sets the time limit of recording.
        /// </summary>
        /// <value>
        /// The time of recording in seconds, or 0 for unlimited time.
        /// </value>
        /// <remarks>
        /// After reaching the limitation, the data which is being recorded will
        /// be discarded and not written to the file.\n
        /// \n
        /// To set, the recorder must be in the<see cref="RecorderState.Idle"/> or <see cref= "RecorderState.Ready" /> state.
        /// </remarks>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is less than zero.</exception>
        /// <exception cref="InvalidOperationException">The recorder is not in the valid state.</exception>
        /// <exception cref="ObjectDisposedException">The recorder already has been disposed of.</exception>
        public int TimeLimit
        {
            get
            {
                Native.GetTimeLimit(Handle, out var val).
                    ThrowIfError("Failed to get time limit.");

                return val;
            }

            set
            {
                ValidateState(RecorderState.Idle, RecorderState.Ready);

                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value,
                        "Time limit can't be less than zero.");
                }

                Native.SetTimeLimit(Handle, value).ThrowIfError("Failed to set time limit.");
            }
        }

        /// <summary>
        /// Gets or sets the mute state of a recorder.
        /// </summary>
        /// <exception cref="ObjectDisposedException">The recorder already has been disposed of.</exception>
        public bool Muted
        {
            get => Native.GetMute(Handle);

            set => Native.SetMute(Handle, value).ThrowIfError("Failed to set mute");
        }
    }
}