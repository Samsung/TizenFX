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

namespace Tizen.Multimedia
{
    /// <summary>
    /// The camera setting class provides methods/properties to get and
    /// set basic camera attributes.
    /// </summary>
    public class RecorderFeatures
    {
        internal readonly Recorder _recorder = null;

        private List<RecorderFileFormat> _fileFormats;
        private List<RecorderAudioCodec> _audioCodec;
        private List<RecorderVideoCodec> _videoCodec;
        private List<Size> _videoResolution;

        internal RecorderFeatures(Recorder recorder)
        {
            _recorder = recorder;
        }

        /// <summary>
        /// Retrieves all the file formats supported by the recorder.
        /// </summary>
        /// <returns>
        /// It returns a list containing all the supported file
        /// formats by recorder.
        /// </returns>
        public IEnumerable<RecorderFileFormat> SupportedFileFormats
        {
            get
            {
                if (_fileFormats == null)
                {
                    _fileFormats = new List<RecorderFileFormat>();

                    Interop.RecorderFeatures.FileFormatCallback callback = (RecorderFileFormat format, IntPtr userData) =>
                    {
                        _fileFormats.Add(format);
                        return true;
                    };
                    RecorderErrorFactory.ThrowIfError(Interop.RecorderFeatures.FileFormats(_recorder.GetHandle(), callback, IntPtr.Zero),
                        "Failed to get the supported fileformats");
                }

                return _fileFormats;
            }
        }

        /// <summary>
        /// Retrieves all the audio encoders supported by the recorder.
        /// </summary>
        /// <returns>
        /// It returns a list containing all the supported audio encoders
        /// by recorder.
        /// </returns>
        public IEnumerable<RecorderAudioCodec> SupportedAudioEncodings
        {
            get
            {
                if (_audioCodec == null)
                {
                    _audioCodec = new List<RecorderAudioCodec>();

                    Interop.RecorderFeatures.AudioEncoderCallback callback = (RecorderAudioCodec codec, IntPtr userData) =>
                    {
                        _audioCodec.Add(codec);
                        return true;
                    };
                    RecorderErrorFactory.ThrowIfError(Interop.RecorderFeatures.AudioEncoders(_recorder.GetHandle(), callback, IntPtr.Zero),
                        "Failed to get the supported audio encoders");
                }

                return _audioCodec;
            }
        }

        /// <summary>
        /// Retrieves all the video encoders supported by the recorder.
        /// </summary>
        /// <returns>
        /// It returns a list containing all the supported video encoders
        /// by recorder.
        /// </returns>
        public IEnumerable<RecorderVideoCodec> SupportedVideoEncodings
        {
            get
            {
                if (_videoCodec == null)
                {
                    _videoCodec = new List<RecorderVideoCodec>();

                    Interop.RecorderFeatures.VideoEncoderCallback callback = (RecorderVideoCodec codec, IntPtr userData) =>
                    {
                        _videoCodec.Add(codec);
                        return true;
                    };
                    RecorderErrorFactory.ThrowIfError(Interop.RecorderFeatures.VideoEncoders(_recorder.GetHandle(), callback, IntPtr.Zero),
                        "Failed to get the supported video encoders");
                }

                return _videoCodec;
            }
        }

        /// <summary>
        /// Retrieves all the video resolutions supported by the recorder.
        /// </summary>
        /// <returns>
        /// It returns videoresolution list containing the width and height of
        /// different resolutions supported by recorder.
        /// </returns>
        public IEnumerable<Size> SupportedVideoResolutions
        {
            get
            {
                if (_videoResolution == null)
                {
                    _videoResolution = new List<Size>();

                    Interop.RecorderFeatures.VideoResolutionCallback callback = (int width, int height, IntPtr userData) =>
                    {
                        _videoResolution.Add(new Size(width, height));
                        return true;
                    };
                    RecorderErrorFactory.ThrowIfError(Interop.RecorderFeatures.VideoResolution(_recorder.GetHandle(), callback, IntPtr.Zero),
                        "Failed to get the supported video resolutions.");
                }

                return _videoResolution;
            }
        }
    }
}