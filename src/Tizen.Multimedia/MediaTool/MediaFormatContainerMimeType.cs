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

namespace Tizen.Multimedia
{
    /// <summary>
    /// Specifies the mime types for container media formats.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum MediaFormatContainerMimeType
    {
        /// <summary>
        /// MP4 container, video.
        /// </summary>
        MP4 = (MediaFormatType.Container | 0x3010),

        /// <summary>
        /// AVI container, video.
        /// </summary>
        Avi = (MediaFormatType.Container | 0x3020),

        /// <summary>
        /// MPEG2TS container, video.
        /// </summary>
        Mpeg2TS = (MediaFormatType.Container | 0x3030),

        /// <summary>
        /// MPEG2PS container, video.
        /// </summary>
        Mpeg2PS = (MediaFormatType.Container | 0x3040),

        /// <summary>
        /// MATROSKA container, video.
        /// </summary>
        Matroska = (MediaFormatType.Container | 0x3050),

        /// <summary>
        /// WEBM container, video.
        /// </summary>
        Webm = (MediaFormatType.Container | 0x3060),

        /// <summary>
        /// 3GP container, video.
        /// </summary>
        ThreeGP = (MediaFormatType.Container | 0x3070),

        /// <summary>
        /// WAV container, audio.
        /// </summary>
        Wav = (MediaFormatType.Container | 0x4010),

        /// <summary>
        ///  OGG container, audio
        /// </summary>
        Ogg = (MediaFormatType.Container | 0x4020),

        /// <summary>
        /// AAC_ADTS container, audio
        /// </summary>
        AacAdts = (MediaFormatType.Container | 0x4030),

        /// <summary>
        /// AAC_ADIF container, audio.
        /// </summary>
        AacAdif = (MediaFormatType.Container | 0x4031),
    }
}
