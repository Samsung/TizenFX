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
using System.Linq;
using System.Runtime.InteropServices;
using Tizen.Internals.Errors;
using Native = Interop.RecorderSettings;

namespace Tizen.Multimedia
{
    /// <summary>
    /// The camera setting class provides methods/properties to get and
    /// set basic camera attributes.
    /// </summary>
    public class RecorderSettings
    {
        internal readonly Recorder _recorder = null;

        internal RecorderSettings(Recorder recorder)
        {
            _recorder = recorder;
        }

        /// <summary>
        /// The number of audio channel.
        /// </summary>
        /// <value>
        /// For mono recording, set channel to 1.
        /// For stereo recording, set channel to 2.
        /// </value>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed.</exception>
        public int AudioChannel
        {
            get
            {
                int val = 0;

                RecorderErrorFactory.ThrowIfError(Native.GetAudioChannel(_recorder.GetHandle(), out val),
                    "Failed to get audio channel.");

                return val;
            }

            set
            {
                RecorderErrorFactory.ThrowIfError(Native.SetAudioChannel(_recorder.GetHandle(), value),
                    "Failed to set audio channel");
            }
        }

        /// <summary>
        /// The audio device for recording.
        /// </summary>
        /// <value>A <see cref="RecorderAudioDevice"/> that specifies the type of audio device.</value>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed.</exception>
        public RecorderAudioDevice AudioDevice
        {
            get
            {
                RecorderAudioDevice val = 0;

                RecorderErrorFactory.ThrowIfError(Native.GetAudioDevice(_recorder.GetHandle(), out val),
                    "Failed to get audio device.");

                return val;
            }

            set
            {
                RecorderErrorFactory.ThrowIfError(Native.SetAudioDevice(_recorder.GetHandle(), value),
                    "Failed to set audio device.");
            }
        }

        /// <summary>
        /// Get the peak audio input level in dB
        /// </summary>
        /// <remarks>
        /// 0dB indicates maximum input level, -300dB indicates minimum input level.
        /// </remarks>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed.</exception>
        public double AudioLevel
        {
            get
            {
                double level = 0;

                RecorderErrorFactory.ThrowIfError(Native.GetAudioLevel(_recorder.GetHandle(), out level),
                    "Failed to get Audio level.");

                return level;
            }
        }

        /// <summary>
        /// The sampling rate of an audio stream in hertz.
        /// </summary>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed.</exception>
        public int AudioSampleRate
        {
            get
            {
                int val = 0;

                RecorderErrorFactory.ThrowIfError(Native.GetAudioSampleRate(_recorder.GetHandle(), out val),
                    "Failed to get audio sample rate.");

                return val;
            }

            set
            {
                RecorderErrorFactory.ThrowIfError(Native.SetAudioSampleRate(_recorder.GetHandle(), value),
                    "Failed to set audio sample rate.");
            }
        }

        /// <summary>
        /// The bitrate of an audio encoder in bits per second.
        /// </summary>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed.</exception>
        public int AudioBitRate
        {
            get
            {
                int val = 0;

                RecorderErrorFactory.ThrowIfError(Native.GetAudioEncoderBitrate(_recorder.GetHandle(), out val),
                    "Failed to get audio bitrate.");

                return val;
            }

            set
            {
                RecorderErrorFactory.ThrowIfError(Native.SetAudioEncoderBitrate(_recorder.GetHandle(), value),
                    "Failed to set audio bitrate");
            }
        }

        /// <summary>
        /// The bitrate of an video encoder in bits per second.
        /// </summary>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed.</exception>
        public int VideoBitRate
        {
            get
            {
                int val = 0;

                RecorderErrorFactory.ThrowIfError(Native.GetVideoEncoderBitrate(_recorder.GetHandle(), out val),
                    "Failed to get video bitrate.");

                return val;
            }

            set
            {
                RecorderErrorFactory.ThrowIfError(Native.SetVideoEncoderBitrate(_recorder.GetHandle(), value),
                    "Failed to set video bitrate");
            }
        }

        /// <summary>
        /// The audio codec for encoding an audio stream.
        /// </summary>
        /// <value>A <see cref="RecorderAudioCodec"/> that specifies the type of audio codec.</value>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed.</exception>
        public RecorderAudioCodec AudioCodec
        {
            get
            {
                RecorderAudioCodec val = 0;

                RecorderErrorFactory.ThrowIfError(Native.GetAudioEncoder(_recorder.GetHandle(), out val),
                    "Failed to get audio codec");

                return val;
            }

            set
            {
                RecorderErrorFactory.ThrowIfError(Native.SetAudioEncoder(_recorder.GetHandle(), value),
                    "Failed to set audio codec");
            }
        }

        /// <summary>
        /// The video codec for encoding video stream.
        /// </summary>
        /// <value>A <see cref="RecorderVideoCodec"/> that specifies the type of video codec.</value>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed.</exception>
        public RecorderVideoCodec VideoCodec
        {
            get
            {
                RecorderVideoCodec val = 0;

                RecorderErrorFactory.ThrowIfError(Native.GetVideoEncoder(_recorder.GetHandle(), out val),
                    "Failed to get video codec");

                return val;
            }

            set
            {
                RecorderErrorFactory.ThrowIfError(Native.SetVideoEncoder(_recorder.GetHandle(), value),
                    "Failed to set video codec");
            }
        }

        /// <summary>
        /// The file format for recording media stream.
        /// </summary>
        /// <value>A <see cref="RecorderFileFormat"/> that specifies the file format.</value>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed.</exception>
        public RecorderFileFormat FileFormat
        {
            get
            {
                RecorderFileFormat val = 0;

                RecorderErrorFactory.ThrowIfError(Native.GetFileFormat(_recorder.GetHandle(), out val),
                    "Failed to get file format.");

                return val;
            }

            set
            {
                RecorderErrorFactory.ThrowIfError(Native.SetFileFormat(_recorder.GetHandle(), value),
                    "Failed to set file format");
            }
        }

        /// <summary>
        /// The file path to record.
        /// </summary>
        /// <remarks>
        /// If the same file already exists in the file system, then old file
        /// will be overwritten.
        /// </remarks>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed.</exception>
        public string FilePath
        {
            get
            {
                IntPtr val;
                RecorderError ret = Native.GetFileName(_recorder.GetHandle(), out val);
                if (ret != RecorderError.None)
                {
                    Log.Error(RecorderLog.Tag, "Failed to get filepath, " + (RecorderError)ret);
                }
                string result = Marshal.PtrToStringAnsi(val);
                LibcSupport.Free(val);
                return result;
            }

            set
            {
                RecorderErrorFactory.ThrowIfError(Native.SetFileName(_recorder.GetHandle(), value),
                    "Failed to set filepath");
            }
        }

        /// <summary>
        /// The maximum size of a recording file in KB(kilobytes). If 0, means
        /// unlimited recording size.
        /// </summary>
        /// <remarks>
        /// After reaching the limitation, the data which is being recorded will
        /// be discarded and not written to the file.
        /// The recorder state must be in 'Ready' or 'Created' state.
        /// </remarks>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed.</exception>
        public int SizeLimit
        {
            get
            {
                int val = 0;

                RecorderErrorFactory.ThrowIfError(Native.GetSizeLimit(_recorder.GetHandle(), out val),
                    "Failed to get size limit.");

                return val;
            }

            set
            {
                RecorderErrorFactory.ThrowIfError(Native.SetSizeLimit(_recorder.GetHandle(), value),
                    "Failed to set size limit");
            }
        }

        /// <summary>
        /// The time limit of a recording file in Seconds. If 0, means unlimited recording
        /// time.
        /// </summary>
        /// <remarks>
        /// After reaching the limitation, the data which is being recorded will
        /// be discarded and not written to the file.
        /// The recorder state must be in 'Ready' or 'Created' state.
        /// </remarks>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed.</exception>
        public int TimeLimit
        {
            get
            {
                int val = 0;

                RecorderErrorFactory.ThrowIfError(Native.GetTimeLimit(_recorder.GetHandle(), out val),
                    "Failed to get time limit.");

                return val;
            }

            set
            {
                RecorderErrorFactory.ThrowIfError(Native.SetTimeLimit(_recorder.GetHandle(), value),
                    "Failed to set time limit.");
            }
        }

        /// <summary>
        /// The mute state of a recorder.
        /// </summary>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed.</exception>
        public bool Mute
        {
            get
            {
                return Native.GetMute(_recorder.GetHandle());
            }

            set
            {
                RecorderErrorFactory.ThrowIfError(Native.SetMute(_recorder.GetHandle(), value),
                    "Failed to set mute");
            }
        }

        /// <summary>
        /// The video recording motion rate
        /// </summary>
        /// <remarks>
        /// The attribute is valid only in a video recorder.
        /// If the rate is in range of 0-1, video is recorded in a slow motion mode.
        /// If the rate is bigger than 1, video is recorded in a fast motion mode.
        /// </remarks>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed.</exception>
        public double MotionRate
        {
            get
            {
                double val = 0.0;

                RecorderErrorFactory.ThrowIfError(Native.GetMotionRate(_recorder.GetHandle(), out val),
                    "Failed to get video motion rate.");

                return val;
            }

            set
            {
                RecorderErrorFactory.ThrowIfError(Native.SetMotionRate(_recorder.GetHandle(), value),
                    "Failed to set video motion rate");
            }
        }

        /// <summary>
        /// The orientation in a video metadata tag.
        /// </summary>
        /// <value>A <see cref="RecorderOrientation"/> that specifies the type of orientation.</value>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed.</exception>
        public RecorderOrientation OrientationTag
        {
            get
            {
                RecorderOrientation val = 0;

                RecorderErrorFactory.ThrowIfError(Native.GetOrientationTag(_recorder.GetHandle(), out val),
                    "Failed to get recorder orientation.");

                return val;
            }

            set
            {
                RecorderErrorFactory.ThrowIfError(Native.SetOrientationTag(_recorder.GetHandle(), value),
                    "Failed to set recorder orientation");
            }
        }

        /// <summary>
        /// Resolution of the video.
        /// </summary>
        /// <exception cref="ArgumentException">In case of invalid parameters</exception>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed.</exception>
        public Size VideoResolution
        {
            get
            {
                int width = 0;
                int height = 0;

                RecorderErrorFactory.ThrowIfError(Native.GetVideoResolution(_recorder.GetHandle(), out width, out height),
                    "Failed to get camera video resolution");

                return new Size(width, height);
            }

            set
            {
                Size res = value;

                RecorderErrorFactory.ThrowIfError(Native.SetVideoResolution(_recorder.GetHandle(), res.Width, res.Height),
                    "Failed to set video resolution.");
            }
        }
    }
}