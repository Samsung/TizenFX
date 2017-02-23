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
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Tizen.Multimedia.Utility
{
    /// <summary>
    /// Video trans-coding utility
    /// </summary>
    public class VideoTranscoder : IDisposable
    {
        public const AudioCodec DetaultAudioCodec = AudioCodec.Aac;
        public const VideoCodec DetaultVideoCodec = VideoCodec.Mpeg4;
        public const VideoFileFormat DetaultFileFormat = VideoFileFormat.ThreeGp;
        public const bool DefaultAccurateModeEnabled = false;
        public static Size DefaultResolution = new Size(0, 0);
        public const int DefaultFps = 0;

        internal Interop.VideoTranscoderHandle _handle;
        private Size _resolution = DefaultResolution;
        private int _fps = DefaultFps;

        /// <summary>
        /// Creates Video trans-coder
        /// </summary>
        /// <exception cref="OutOfMemoryException">Thrown if framework failed to allocate memory</exception>
        /// <exception cref="NotSupportedException">Thrown if video trans-coding is not supported in device</exception>
        public VideoTranscoder()
        {
            _handle = new Interop.VideoTranscoderHandle();
        }

        /// <summary>
        /// Indicate if trans-coder is busy trans-coding
        /// </summary>
        public bool IsBusy { get; private set; }

        /// <summary>
        /// Indicates if accurate mode is enabled
        /// </summary>
        /// <remarks>Default is false, if set to true, next trans-coding will start from accurate frame for given the duration, otherwise from nearest i-frame</remarks>
        public bool IsAccurateModeEnabled { get; set; } = DefaultAccurateModeEnabled;

        /// <summary>
        /// Audio codec for encoding stream for next trans-coding
        /// </summary>
        /// <remarks>Default is AudioCodec.Aac</remarks>
        public AudioCodec AudioCodec { get; set; } = DetaultAudioCodec;

        /// <summary>
        /// Video codec for encoding stream for next trans-coding
        /// </summary>
        /// <remarks>Default is VideoCodec.Mpeg4</remarks>
        public VideoCodec VideoCodec { get; set; } = DetaultVideoCodec;

        /// <summary>
        /// File format for trans-coding media stream for next trans-coding
        /// </summary>
        /// <remarks>Default is VideoFileFormat.ThreeGp</remarks>
        public VideoFileFormat Format { get; set; } = DetaultFileFormat;

        /// <summary>
        /// Media resolution for next trans-coding
        /// </summary>
        /// <remarks>
        /// Default value is Size(0, 0)
        /// If the width is 0, it set original size.(minimum value is 128)
        /// If the height is 0, it set original size.(minimum value is 96)
        /// </remarks>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if value is not in valid range</exception>
        public Size Resolution
        {
            get { return _resolution; }
            set
            {
                ValidateInputRange(value.Width, () => value.Width >= 128 || value.Width == 0, "Width", "Valid value is 0 and value >= 128");
                ValidateInputRange(value.Height, () => value.Width >= 96 || value.Width == 0, "Height", "Valid value is 0 and value >= 96");
                _resolution = value;
            }
        }

        /// <summary>
        /// Frame rate, in range [5-30] for next trans-coding
        /// </summary>
        /// <remarks>
        /// Default value is 0
        /// If fps is set 0, the default is original fps from source.
        /// </remarks>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if value is not in valid range</exception>
        public int Fps
        {
            get { return _fps; }
            set
            {
                ValidateInputRange(value, 5, 30, "Fps");
                _fps = value;
            }
        }

        /// <summary>
        /// Supported audio codecs
        /// </summary>
        public IEnumerable<AudioCodec> SupportedAudioCodecs
        {
            get
            {
                var audioCodecs = new List<AudioCodec>();
                _handle.ForeachSupportedAudioCodec((codec) => audioCodecs.Add((AudioCodec)codec));
                return audioCodecs;
            }
        }

        /// <summary>
        /// Supported video codecs
        /// </summary>
        public IEnumerable<VideoCodec> SupportedVideoCodecs
        {
            get
            {
                var videoCodecs = new List<VideoCodec>();
                _handle.ForeachSupportedVideoCodec((codec) => videoCodecs.Add((VideoCodec)codec));
                return videoCodecs;
            }
        }

        /// <summary>
        /// Supported video file formats
        /// </summary>
        public IEnumerable<VideoFileFormat> SupportedVideoFileFormats
        {
            get
            {
                var videoFileFormats = new List<VideoFileFormat>();
                _handle.ForeachSupportedFileFormat((codec) => videoFileFormats.Add((VideoFileFormat)codec));
                return videoFileFormats;
            }
        }

        /// <summary>
        /// Trans-code video
        /// </summary>
        /// <param name="sourceFilePath">Source video file to trans-code</param>
        /// <param name="startPosition">Position to start trans-code in seconds</param>
        /// <param name="totalDuration">Total duration to trans-code, in seconds, if set to 0, trans-coding happens until end of the video</param>
        /// <param name="outputFile">Output file path</param>
        /// <param name="progress">progress update provider</param>
        /// <param name="cancelToken">Cancellation token, to be used to cancel trans-coding</param>
        /// <privilege>http://tizen.org/privilege/mediastorage is needed if input or output path are relevant to media storage</privilege>
        /// <privilege>http://tizen.org/privilege/externalstorage is needed if input or output path are relevant to external storage</privilege>
        /// <exception cref="UnauthorizedAccessException">Thrown if application does not have required privilege</exception>
        /// <exception cref="ArgumentNullException">Thrown if sourceFilePath or outputFile is null</exception>
        /// <exception cref="System.IO.FileNotFoundException">Thrown if sourceFilePath does not exist</exception>
        /// <exception cref="NotSupportedException">Thrown if video file format is not supported</exception>
        /// <exception cref="InvalidOperationException">Thrown if Trans-coder is busy trans-coding previous file</exception>
        /// <exception cref="TaskCanceledException">Thrown if trans-coding is canceled</exception>
        /// <returns>Trans-coding task</returns>
        public Task TranscodeAsync(string sourceFilePath, ulong startPosition, ulong totalDuration, string outputFile, IProgress<int> progress, CancellationToken cancelToken)
        {
            ValidateObjectNotDisposed();

            if (sourceFilePath == null) throw new ArgumentNullException(nameof(sourceFilePath));
            if (outputFile == null) throw new ArgumentNullException(nameof(outputFile));

            // CAPI does not allow setting properties or start another trans-coding if trans-coder is busy
            if (IsBusy) throw new InvalidOperationException("Previous trans-coding is still going on");

            ConfigureNativeHandle(sourceFilePath);

            var transcodingTask = new TaskCompletionSource<bool>();
            if (cancelToken != CancellationToken.None)
            {
                if (cancelToken.IsCancellationRequested)
                {
                    IsBusy = false;
                    transcodingTask.TrySetCanceled();
                }

                cancelToken.Register(() =>
                {
                    _handle.CancelTranscoding().ThrowIfFailed("Failed to cancel trans-coding");
                    IsBusy = false;
                    transcodingTask.SetResult(false);
                });
            }

            Interop.VideoTranscoderHandle.TranscodingProgressCallback progressCb = (currentPosition, duration, userData) =>
            {
                progress?.Report((int)((currentPosition - startPosition) / duration));
            };

            Interop.VideoTranscoderHandle.TranscodingCompletedCallback completedCb = (errorCode, userData) =>
            {
                if (IsBusy)
                {
                    IsBusy = false;
                    if (errorCode.IsSuccess())
                    {
                        transcodingTask.TrySetResult(true);
                    }
                    else
                    {
                        transcodingTask.TrySetException(errorCode.GetException("Failed to trans-code"));
                    }
                }
            };

            var err = _handle.StartTranscoding(startPosition, totalDuration, outputFile, progressCb, completedCb, IntPtr.Zero);
            err.ThrowIfFailed("Failed to start trans-coding");

            IsBusy = !transcodingTask.Task.IsCanceled;
            return Interop.PinnedTask(transcodingTask);
        }

        /// <summary>
        /// Trans-code video from start position in input file till end of file.
        /// </summary>
        /// <param name="sourceFilePath">Source video file to trans-code</param>
        /// <param name="startPosition">Position to start trans-code in seconds</param>
        /// <param name="outputFile">Output file path</param>
        /// <param name="progress">progress update provider</param>
        /// <param name="cancelToken">Cancellation token, to be used to cancel trans-coding</param>
        /// <privilege>http://tizen.org/privilege/mediastorage is needed if input or output path are relevant to media storage</privilege>
        /// <privilege>http://tizen.org/privilege/externalstorage is needed if input or output path are relevant to external storage</privilege>
        /// <exception cref="UnauthorizedAccessException">Thrown if application does not have required privilege</exception>
        /// <exception cref="ArgumentNullException">Thrown if sourceFilePath or outputFile is null</exception>
        /// <exception cref="System.IO.FileNotFoundException">Thrown if sourceFilePath does not exist</exception>
        /// <exception cref="NotSupportedException">Thrown if video file format is not supported</exception>
        /// <exception cref="InvalidOperationException">Thrown if Trans-coder is busy trans-coding previous file</exception>
        /// <exception cref="TaskCanceledException">Thrown if trans-coding is canceled</exception>
        /// <returns>Trans-coding task</returns>
        public Task TranscodeAsync(string sourceFilePath, ulong startPosition, string outputFile, IProgress<int> progress, CancellationToken cancelToken)
        {
            return TranscodeAsync(sourceFilePath, startPosition, 0, outputFile, progress, cancelToken);
        }

        /// <summary>
        /// Trans-code video
        /// </summary>
        /// <param name="sourceFilePath">Source video file to trans-code</param>
        /// <param name="startPosition">Position to start trans-code in seconds</param>
        /// <param name="duration">Total duration to trans-code, in seconds, if set to 0, trans-coding happens until end of the video</param>
        /// <param name="outputFile">Output file path</param>
        /// <param name="progress">progress update provider</param>
        /// <privilege>http://tizen.org/privilege/mediastorage is needed if input or output path are relevant to media storage</privilege>
        /// <privilege>http://tizen.org/privilege/externalstorage is needed if input or output path are relevant to external storage</privilege>
        /// <exception cref="UnauthorizedAccessException">Thrown if application does not have required privilege</exception>
        /// <exception cref="ArgumentNullException">Thrown if sourceFilePath or outputFile is null</exception>
        /// <exception cref="System.IO.FileNotFoundException">Thrown if sourceFilePath does not exist</exception>
        /// <exception cref="NotSupportedException">Thrown if video file format is not supported</exception>
        /// <exception cref="InvalidOperationException">Thrown if Trans-coder is busy trans-coding previous file</exception>
        /// <returns>Trans-coding task</returns>
        public Task TranscodeAsync(string sourceFilePath, ulong startPosition, ulong duration, string outputFile, IProgress<int> progress)
        {
            return TranscodeAsync(sourceFilePath, startPosition, duration, outputFile, progress, CancellationToken.None);
        }

        /// <summary>
        /// Trans-code video
        /// </summary>
        /// <param name="sourceFilePath">Source video file to trans-code</param>
        /// <param name="startPosition">Position to start trans-code in seconds</param>
        /// <param name="outputFile">Output file path</param>
        /// <param name="progress">progress update provider</param>
        /// <privilege>http://tizen.org/privilege/mediastorage is needed if input or output path are relevant to media storage</privilege>
        /// <privilege>http://tizen.org/privilege/externalstorage is needed if input or output path are relevant to external storage</privilege>
        /// <exception cref="UnauthorizedAccessException">Thrown if application does not have required privilege</exception>
        /// <exception cref="ArgumentNullException">Thrown if sourceFilePath or outputFile is null</exception>
        /// <exception cref="System.IO.FileNotFoundException">Thrown if sourceFilePath does not exist</exception>
        /// <exception cref="NotSupportedException">Thrown if video file format is not supported</exception>
        /// <exception cref="InvalidOperationException">Thrown if Trans-coder is busy trans-coding previous file</exception>
        /// <returns>Trans-coding task</returns>
        public Task TranscodeAsync(string sourceFilePath, ulong startPosition, string outputFile, IProgress<int> progress)
        {
            return TranscodeAsync(sourceFilePath, startPosition, 0, outputFile, progress, CancellationToken.None);
        }

        private void ConfigureNativeHandle(string sourceFilePath)
        {
            _handle.InputFile = sourceFilePath;

            if (AudioCodec != DetaultAudioCodec) _handle.AudioCodec = (Interop.AudioCodec)AudioCodec;
            if (VideoCodec != DetaultVideoCodec) _handle.VideoCodec = (Interop.VideoCodec)VideoCodec;
            if (Format != DetaultFileFormat) _handle.FileFormat = (Interop.VideoFileFormat)Format;
            if (IsAccurateModeEnabled != DefaultAccurateModeEnabled) _handle.AccurateModeEnabled = IsAccurateModeEnabled;
            if (Fps != DefaultFps) _handle.Fps = Fps;
            if (Resolution.Width != DefaultResolution.Width || Resolution.Height != DefaultResolution.Height)
            {
                _handle.SetResolution(Resolution.Width, Resolution.Height).ThrowIfFailed($"Failed to set resolution to {Resolution}");
            }
        }

        private void ValidateObjectNotDisposed()
        {
            if (_disposedValue)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
        }

        internal static void ValidateInputRange<T>(T actualValue, T min, T max, string paramName) where T : IComparable<T>
        {
            if (min.CompareTo(actualValue) == 1 || max.CompareTo(actualValue) == -1)
            {
                throw new ArgumentOutOfRangeException(paramName, actualValue, $"Valid Range [{min} - {max}]");
            }
        }

        internal static void ValidateInputRange<T>(T actualValue, Func<bool> verifier, string paramName, string message)
        {
            if (verifier() == false)
            {
                throw new ArgumentOutOfRangeException(paramName, actualValue, message);
            }
        }

        #region IDisposable Support
        private bool _disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (IsBusy)
                {
                    _handle.CancelTranscoding();
                }
                _handle.Dispose();
                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}