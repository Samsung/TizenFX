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
using System.Linq;
using Native = Interop.StreamRecorder;

namespace Tizen.Multimedia
{
    public partial class StreamRecorder
    {
        internal void LoadCapabilities()
        {
            _videoCodecs = LoadVideoCodecs(this);
            _audioCodecs = LoadAudioCodecs(this);
            _fileFormats = LoadFileFormats(this);
            _videoResolutions = LoadResolutions(this);
        }

        private static IEnumerable<RecorderVideoCodec> LoadVideoCodecs(StreamRecorder recorder)
        {
            var result = new List<RecorderVideoCodec>();
            Native.VideoEncoderCallback callback = (codec, _) =>
            {
                result.Add(codec.ToRecorderEnum());
                return true;
            };

            Native.VideoEncoders(recorder.Handle, callback).ThrowIfError("Failed to get the supported video codecs.");

            return result.AsReadOnly();
        }

        private static IEnumerable<RecorderAudioCodec> LoadAudioCodecs(StreamRecorder recorder)
        {
            var result = new List<RecorderAudioCodec>();

            Native.AudioEncoders(recorder.Handle, (codec, _) =>
            {
                result.Add(codec.ToRecorderEnum());
                return true;
            }).ThrowIfError("Failed to get the supported audio codecs.");

            return result.AsReadOnly();
        }

        private static IEnumerable<RecorderFileFormat> LoadFileFormats(StreamRecorder recorder)
        {
            var result = new List<RecorderFileFormat>();

            Native.FileFormats(recorder.Handle, (fileFormat, _) =>
            {
                result.Add(fileFormat.ToRecorderEnum());
                return true;
            }).ThrowIfError("Failed to get the supported file formats.");

            return result.AsReadOnly();
        }

        private static IEnumerable<Size> LoadResolutions(StreamRecorder recorder)
        {
            List<Size> result = new List<Size>();

            Native.VideoResolutionCallback callback = (width, height, _) =>
            {
                result.Add(new Size(width, height));
                return true;
            };

            Native.VideoResolution(recorder.Handle, callback).
                ThrowIfError("Failed to get the supported video resolutions.");

            return result.AsReadOnly();
        }

        private IEnumerable<RecorderFileFormat> _fileFormats;

        /// <summary>
        /// Gets the file formats that the current device supports.
        /// </summary>
        /// <returns>An IEnumerable of <see cref="RecorderFileFormat"/> representing the supported file formats.</returns>
        /// <since_tizen> 4 </since_tizen>
        public IEnumerable<RecorderFileFormat> GetSupportedFileFormats() => _fileFormats;

        private IEnumerable<RecorderAudioCodec> _audioCodecs;

        /// <summary>
        /// Gets the audio codecs that the current device supports.
        /// </summary>
        /// <returns>An IEnumerable of <see cref="RecorderAudioCodec"/> representing the supported audio codecs.</returns>
        /// <since_tizen> 4 </since_tizen>
        public IEnumerable<RecorderAudioCodec> GetSupportedAudioCodecs() => _audioCodecs;

        private IEnumerable<RecorderVideoCodec> _videoCodecs;

        /// <summary>
        /// Gets the video codecs that the current device supports.
        /// </summary>
        /// <returns>An IEnumerable of <see cref="RecorderVideoCodec"/> representing the supported video codecs.</returns>
        /// <since_tizen> 4 </since_tizen>
        public IEnumerable<RecorderVideoCodec> GetSupportedVideoCodecs() => _videoCodecs;

        private IEnumerable<Size> _videoResolutions;

        /// <summary>
        /// Gets the video resolutions that the current device supports.
        /// </summary>
        /// <returns>An IEnumerable of <see cref="Size"/> representing the supported resolutions.</returns>
        /// <since_tizen> 4 </since_tizen>
        public IEnumerable<Size> GetSupportedVideoResolutions() => _videoResolutions;

        internal void ValidateFileFormat(RecorderFileFormat format)
        {
            if (_fileFormats.Contains(format) == false)
            {
                throw new NotSupportedException($"{format.ToString()} is not supported.");
            }
        }

        internal void ValidateAudioCodec(RecorderAudioCodec codec)
        {
            if (_audioCodecs.Contains(codec) == false)
            {
                throw new NotSupportedException($"{codec.ToString()} is not supported.");
            }
        }

        internal void ValidateVideoCodec(RecorderVideoCodec codec)
        {
            if (_videoCodecs.Contains(codec) == false)
            {
                throw new NotSupportedException($"{codec.ToString()} is not supported.");
            }
        }

        internal void ValidateVideoResolution(Size resolution)
        {
            if (_videoResolutions.Contains(resolution) == false)
            {
                throw new NotSupportedException($"Resolution({resolution.ToString()}) is not supported.");
            }
        }
    }
}