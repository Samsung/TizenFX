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
using Native = Interop.StreamRecorder;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Specifies the options associated with <see cref="StreamRecorder"/>.
    /// </summary>
    /// <seealso cref="StreamRecorder"/>
    /// <seealso cref="StreamRecorder.Prepare(StreamRecorderOptions)"/>
    /// <seealso cref="StreamRecorderAudioOptions"/>
    /// <seealso cref="StreamRecorderVideoOptions"/>
    public class StreamRecorderOptions
    {
        /// <summary>
        /// Initialize a new instance of the <see cref="StreamRecorderOptions"/> class with the specified
        /// save path and file format.
        /// </summary>
        /// <param name="savePath">The path that the recording result is saved.</param>
        /// <param name="fileFormat">The file format of output file.</param>
        /// <exception cref="ArgumentNullException"><paramref name="savePath"/>is null.</exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="savePath"/>is an empty string.<br/>
        ///     -or-<br/>
        ///     <paramref name="fileFormat"/> is not valid.
        /// </exception>
        public StreamRecorderOptions(string savePath, RecorderFileFormat fileFormat)
        {
            SavePath = savePath;
            FileFormat = fileFormat;
        }

        private string _savePath;

        /// <summary>
        /// Gets or sets the file path to record.
        /// </summary>
        /// <remarks>
        /// If the same file already exists in the file system, then old file will be overwritten.
        /// </remarks>
        /// <exception cref="ArgumentNullException"><paramref name="value"/>is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="value"/>is an empty string.</exception>
        public string SavePath
        {
            get => _savePath;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Path can't be an empty string.", nameof(value));
                }

                _savePath = value;
            }
        }

        private RecorderFileFormat _fileFormat;

        /// <summary>
        /// Gets or sets the file format for recording media stream.
        /// </summary>
        /// <exception cref="ArgumentException"><paramref name="value"/> is not valid.</exception>
        /// <seealso cref="StreamRecorder.GetSupportedFileFormats"/>
        public RecorderFileFormat FileFormat
        {
            get => _fileFormat;
            set
            {
                ValidationUtil.ValidateEnum(typeof(RecorderFileFormat), value, nameof(value));

                _fileFormat = value;
            }
        }

        private int _timeLimit;

        /// <summary>
        /// Gets or sets the time limit of recording.
        /// </summary>
        /// <value>
        /// The maximum time of recording in seconds, or 0 for unlimited time.
        /// </value>
        /// <remarks>
        /// After reaching the limitation, the data which is being recorded will
        /// be discarded and not written to the file.
        /// The recorder state must be <see cref="RecorderState.Idle"/> state.
        /// </remarks>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is less than zero.</exception>
        /// <seealso cref="StreamRecorder.RecordingLimitReached"/>
        /// <seealso cref="SizeLimit"/>
        public int TimeLimit
        {
            get => _timeLimit;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value,
                        "Time limit can't be less than zero.");
                }

                _timeLimit = value;
            }
        }

        private int _sizeLimit;

        /// <summary>
        /// Gets or sets the maximum size of a recording file.
        /// </summary>
        /// <value>
        /// The maximum size of a recording file in kilobytes, or 0 for unlimited size.
        /// </value>
        /// <remarks>
        /// After reaching the limitation, the data which is being recorded will
        /// be discarded and not written to the file.
        /// </remarks>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is less than zero.</exception>
        /// <seealso cref="StreamRecorder.RecordingLimitReached"/>
        /// <seealso cref="TimeLimit"/>
        public int SizeLimit
        {
            get => _sizeLimit;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value,
                        "Size limit can't be less than zero.");
                }

                _sizeLimit = value;
            }
        }

        /// <summary>
        /// Gets or sets the options for audio recording.
        /// </summary>
        /// <remarks>
        /// <see cref="Audio"/> or <see cref="Video"/> must be set for recording.
        /// </remarks>
        /// <seealso cref="Video"/>
        public StreamRecorderAudioOptions Audio { get; set; }

        /// <summary>
        /// Gets or sets the options for video recording.
        /// </summary>
        /// <remarks>
        /// <see cref="Audio"/> or <see cref="Video"/> must be set for recording.
        /// </remarks>
        /// <seealso cref="Audio"/>
        public StreamRecorderVideoOptions Video { get; set; }

        private StreamRecorderSourceType GetSourceType()
        {
            Debug.Assert(Audio != null || Video != null);

            if (Audio != null && Video != null)
            {
                return StreamRecorderSourceType.VideoAudio;
            }

            return Audio != null ? StreamRecorderSourceType.Audio : StreamRecorderSourceType.Video;
        }

        internal void Apply(StreamRecorder recorder)
        {
            if (Audio == null && Video == null)
            {
                throw new ArgumentException("Both Audio and Video are not set.");
            }

            Native.EnableSourceBuffer(recorder.Handle, GetSourceType()).ThrowIfError("Failed to apply options.");

            Native.SetFileName(recorder.Handle, SavePath).ThrowIfError("Failed to set save path.");

            recorder.ValidateFileFormat(FileFormat);
            Native.SetFileFormat(recorder.Handle, FileFormat.ToStreamRecorderEnum())
                .ThrowIfError("Failed to set file format.");

            Native.SetRecordingLimit(recorder.Handle, RecordingLimitType.Size, SizeLimit).
                ThrowIfError("Failed to set size limit.");

            Native.SetRecordingLimit(recorder.Handle, RecordingLimitType.Time, TimeLimit).
                ThrowIfError("Failed to set time limit.");

            Audio?.Apply(recorder);

            Video?.Apply(recorder);
        }
    }
}
