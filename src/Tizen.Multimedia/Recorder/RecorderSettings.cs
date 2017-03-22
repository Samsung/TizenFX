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
        /// <remarks>
        /// The attribute is applied only in Created state.
        /// For mono recording, set channel to 1.
        /// For stereo recording, set channel to 2.
        /// </remarks>
        public int AudioChannel
        {
            get
            {
                int val = 0;

                RecorderErrorFactory.ThrowIfError(Interop.RecorderSettings.GetAudioChannel(_recorder.GetHandle(), out val),
                    "Failed to get audio channel.");

                return val;
            }

            set
            {
                RecorderErrorFactory.ThrowIfError(Interop.RecorderSettings.SetAudioChannel(_recorder.GetHandle(), value),
                    "Failed to set audio channel");
            }
        }

        /// <summary>
        /// The audio device for recording.
        /// </summary>
        public RecorderAudioDevice AudioDevice
        {
            get
            {
                RecorderAudioDevice val = 0;

                RecorderErrorFactory.ThrowIfError(Interop.RecorderSettings.GetAudioDevice(_recorder.GetHandle(), out val),
                    "Failed to get audio device.");

                return val;
            }

            set
            {
                RecorderErrorFactory.ThrowIfError(Interop.RecorderSettings.SetAudioDevice(_recorder.GetHandle(), value),
                    "Failed to set audio device.");
            }
        }

        /// <summary>
        /// Get the peak audio input level in dB
        /// </summary>
        /// <remarks>
        /// 0dB indicates maximum input level, -300dB indicates minimum input level.
        /// </remarks>
        public double AudioLevel
        {
            get
            {
                double level = 0;

                RecorderErrorFactory.ThrowIfError(Interop.RecorderSettings.GetAudioLevel(_recorder.GetHandle(), out level),
                    "Failed to get Audio level.");

                return level;
            }
        }

        /// <summary>
        /// The sampling rate of an audio stream in hertz.
        /// </summary>
        public int AudioSampleRate
        {
            get
            {
                int val = 0;

                RecorderErrorFactory.ThrowIfError(Interop.RecorderSettings.GetAudioSampleRate(_recorder.GetHandle(), out val),
                    "Failed to get audio sample rate.");

                return val;
            }

            set
            {
                RecorderErrorFactory.ThrowIfError(Interop.RecorderSettings.SetAudioSampleRate(_recorder.GetHandle(), value),
                    "Failed to set audio sample rate.");
            }
        }

        /// <summary>
        /// The bitrate of an audio encoder in bits per second.
        /// </summary>
        public int AudioBitRate
        {
            get
            {
                int val = 0;

                RecorderErrorFactory.ThrowIfError(Interop.RecorderSettings.GetAudioEncoderBitrate(_recorder.GetHandle(), out val),
                    "Failed to get audio bitrate.");

                return val;
            }

            set
            {
                RecorderErrorFactory.ThrowIfError(Interop.RecorderSettings.SetAudioEncoderBitrate(_recorder.GetHandle(), value),
                    "Failed to set audio bitrate");
            }
        }

        /// <summary>
        /// The bitrate of an video encoder in bits per second.
        /// </summary>
        public int VideoBitRate
        {
            get
            {
                int val = 0;

                RecorderErrorFactory.ThrowIfError(Interop.RecorderSettings.GetVideoEncoderBitrate(_recorder.GetHandle(), out val),
                    "Failed to get video bitrate.");

                return val;
            }

            set
            {
                RecorderErrorFactory.ThrowIfError(Interop.RecorderSettings.SetVideoEncoderBitrate(_recorder.GetHandle(), value),
                    "Failed to set video bitrate");
            }
        }

        /// <summary>
        /// The audio codec for encoding an audio stream.
        /// </summary>
        public RecorderAudioCodec AudioCodec
        {
            get
            {
                RecorderAudioCodec val = 0;

                RecorderErrorFactory.ThrowIfError(Interop.RecorderSettings.GetAudioEncoder(_recorder.GetHandle(), out val),
                    "Failed to get audio codec");

                return val;
            }

            set
            {
                RecorderErrorFactory.ThrowIfError(Interop.RecorderSettings.SetAudioEncoder(_recorder.GetHandle(), value),
                    "Failed to set audio codec");
            }
        }

        /// <summary>
        /// The video codec for encoding video stream.
        /// </summary>
        public RecorderVideoCodec VideoCodec
        {
            get
            {
                RecorderVideoCodec val = 0;

                RecorderErrorFactory.ThrowIfError(Interop.RecorderSettings.GetVideoEncoder(_recorder.GetHandle(), out val),
                    "Failed to get video codec");

                return val;
            }

            set
            {
                RecorderErrorFactory.ThrowIfError(Interop.RecorderSettings.SetVideoEncoder(_recorder.GetHandle(), value),
                    "Failed to set video codec");
            }
        }

        /// <summary>
        /// The file format for recording media stream.
        /// </summary>
        public RecorderFileFormat FileFormat
        {
            get
            {
                RecorderFileFormat val = 0;

                RecorderErrorFactory.ThrowIfError(Interop.RecorderSettings.GetFileFormat(_recorder.GetHandle(), out val),
                    "Failed to get file format.");

                return val;
            }

            set
            {
                RecorderErrorFactory.ThrowIfError(Interop.RecorderSettings.SetFileFormat(_recorder.GetHandle(), value),
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
        public string FilePath
        {
            get
            {
                IntPtr val;
                int ret = Interop.RecorderSettings.GetFileName(_recorder.GetHandle(), out val);
                if ((RecorderError)ret != RecorderError.None)
                {
                    Log.Error(RecorderLog.Tag, "Failed to get filepath, " + (RecorderError)ret);
                }
                string result = Marshal.PtrToStringAnsi(val);
                Interop.Libc.Free(val);
                return result;
            }

            set
            {
                RecorderErrorFactory.ThrowIfError(Interop.RecorderSettings.SetFileName(_recorder.GetHandle(), value),
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
        ///
        public int SizeLimit
        {
            get
            {
                int val = 0;

                RecorderErrorFactory.ThrowIfError(Interop.RecorderSettings.GetSizeLimit(_recorder.GetHandle(), out val),
                    "Failed to get size limit.");

                return val;
            }

            set
            {
                RecorderErrorFactory.ThrowIfError(Interop.RecorderSettings.SetSizeLimit(_recorder.GetHandle(), value),
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
        public int TimeLimit
        {
            get
            {
                int val = 0;

                RecorderErrorFactory.ThrowIfError(Interop.RecorderSettings.GetTimeLimit(_recorder.GetHandle(), out val),
                    "Failed to get time limit.");

                return val;
            }

            set
            {
                RecorderErrorFactory.ThrowIfError(Interop.RecorderSettings.SetTimeLimit(_recorder.GetHandle(), value),
                    "Failed to set time limit.");
            }
        }

        /// <summary>
        /// The mute state of a recorder.
        /// </summary>
        public bool Mute
        {
            get
            {
                bool ret = Interop.RecorderSettings.GetMute(_recorder.GetHandle());

                RecorderErrorFactory.ThrowIfError(ErrorFacts.GetLastResult(),
                    "Failed to get the mute state of recorder");

                return ret;
            }

            set
            {
                RecorderErrorFactory.ThrowIfError(Interop.RecorderSettings.SetMute(_recorder.GetHandle(), value),
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
        public double MotionRate
        {
            get
            {
                double val = 0.0;

                RecorderErrorFactory.ThrowIfError(Interop.RecorderSettings.GetMotionRate(_recorder.GetHandle(), out val),
                    "Failed to get video motion rate.");

                return val;
            }

            set
            {
                RecorderErrorFactory.ThrowIfError(Interop.RecorderSettings.SetMotionRate(_recorder.GetHandle(), value),
                    "Failed to set video motion rate");
            }
        }

        /// <summary>
        /// The orientation in a video metadata tag.
        /// </summary>
        public RecorderOrientation OrientationTag
        {
            get
            {
                RecorderOrientation val = 0;

                RecorderErrorFactory.ThrowIfError(Interop.RecorderSettings.GetOrientationTag(_recorder.GetHandle(), out val),
                    "Failed to get recorder orientation.");

                return val;
            }

            set
            {
                RecorderErrorFactory.ThrowIfError(Interop.RecorderSettings.SetOrientationTag(_recorder.GetHandle(), value),
                    "Failed to set recorder orientation");
            }
        }

        /// <summary>
        /// Resolution of the video.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/recorder
        /// </privilege>
        /// <exception cref="ArgumentException">In case of invalid parameters</exception>
        public Size VideoResolution
        {
            get
            {
                int width = 0;
                int height = 0;

                CameraErrorFactory.ThrowIfError(Interop.RecorderSettings.GetVideoResolution(_recorder.GetHandle(), out width, out height),
                    "Failed to get camera video resolution");

                return new Size(width, height);
            }

            set
            {
                Size res = value;

                CameraErrorFactory.ThrowIfError(Interop.RecorderSettings.SetVideoResolution(_recorder.GetHandle(), res.Width, res.Height),
                    "Failed to set video resolution.");
            }
        }
    }
}