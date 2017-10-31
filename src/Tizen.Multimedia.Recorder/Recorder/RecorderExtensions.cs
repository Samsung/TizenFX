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
    /// Provides extension methods for <see cref="Recorder"/>.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public static class RecorderExtensions
    {
        /// <summary>
        /// Returns supported file formats for a <see cref="RecorderVideoCodec"/>.
        /// </summary>
        /// <returns>An IEnumerable of <see cref="RecorderFileFormat"/> representing the supported file formats.</returns>
        /// <param name="videoCodec">The <see cref="RecorderVideoCodec"/>.</param>
        /// <exception cref="ArgumentException"><paramref name="videoCodec"/> is invalid.</exception>
        /// <since_tizen> 4 </since_tizen>
        public static IEnumerable<RecorderFileFormat> GetSupportedFileFormats(this RecorderVideoCodec videoCodec)
        {
            ValidationUtil.ValidateEnum(typeof(RecorderVideoCodec), videoCodec, nameof(videoCodec));

            switch (videoCodec)
            {
                case RecorderVideoCodec.H263:
                    yield return RecorderFileFormat.ThreeGp;
                    break;

                case RecorderVideoCodec.H264:
                case RecorderVideoCodec.Mpeg4:
                    yield return RecorderFileFormat.ThreeGp;
                    yield return RecorderFileFormat.Mp4;
                    yield return RecorderFileFormat.M2ts;
                    break;

                case RecorderVideoCodec.Theora:
                    yield return RecorderFileFormat.Ogg;
                    break;
            }
        }

        /// <summary>
        /// Returns supported file formats for a <see cref="RecorderAudioCodec"/>.
        /// </summary>
        /// <returns>An IEnumerable of <see cref="RecorderFileFormat"/> representing the supported file formats.</returns>
        /// <param name="audioCodec">The <see cref="RecorderAudioCodec"/>.</param>
        /// <exception cref="ArgumentException"><paramref name="audioCodec"/> is invalid.</exception>
        /// <since_tizen> 4 </since_tizen>
        public static IEnumerable<RecorderFileFormat> GetSupportedFileFormats(this RecorderAudioCodec audioCodec)
        {
            ValidationUtil.ValidateEnum(typeof(RecorderAudioCodec), audioCodec, nameof(audioCodec));

            switch (audioCodec)
            {
                case RecorderAudioCodec.Amr:
                    yield return RecorderFileFormat.ThreeGp;
                    yield return RecorderFileFormat.Amr;
                    break;

                case RecorderAudioCodec.Mp3:
                    yield return RecorderFileFormat.Mp4;
                    yield return RecorderFileFormat.M2ts;
                    break;

                case RecorderAudioCodec.Aac:
                    yield return RecorderFileFormat.ThreeGp;
                    yield return RecorderFileFormat.Mp4;
                    yield return RecorderFileFormat.M2ts;
                    yield return RecorderFileFormat.Adts;
                    break;

                case RecorderAudioCodec.Vorbis:
                    yield return RecorderFileFormat.Ogg;
                    break;

                case RecorderAudioCodec.Pcm:
                    yield return RecorderFileFormat.Wav;
                    break;
            }
        }

        internal static void ThrowIfFormatNotSupported(this RecorderAudioCodec audioCodec, RecorderFileFormat fileFormat)
        {
            ValidationUtil.ValidateEnum(typeof(RecorderFileFormat), fileFormat, nameof(fileFormat));

            if (audioCodec.GetSupportedFileFormats().Contains(fileFormat) == false)
            {
                throw new NotSupportedException($"{audioCodec} does not support {fileFormat}.");
            }
        }

        internal static void ThrowIfFormatNotSupported(this RecorderVideoCodec videoCodec, RecorderFileFormat fileFormat)
        {
            ValidationUtil.ValidateEnum(typeof(RecorderFileFormat), fileFormat, nameof(fileFormat));

            if (videoCodec.GetSupportedFileFormats().Contains(fileFormat) == false)
            {
                throw new NotSupportedException($"{videoCodec} does not support {fileFormat}.");
            }
        }
    }
}