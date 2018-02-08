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
    /// Specifies the mime types for audio media formats.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum MediaFormatAudioMimeType
    {
        /// <summary>
        /// AMR, alias for <see cref="AmrNB"/>.
        /// </summary>
        Amr = (MediaFormatType.Audio | MediaFormatDataType.Encoded | 0x1040),

        /// <summary>
        /// AMR-NB.
        /// </summary>
        AmrNB = (MediaFormatType.Audio | MediaFormatDataType.Encoded | 0x1040),

        /// <summary>
        /// AMR-WB.
        /// </summary>
        AmrWB = (MediaFormatType.Audio | MediaFormatDataType.Encoded | 0x1041),

        /// <summary>
        /// AAC, alias for <see cref="AacLC"/>.
        /// </summary>
        Aac = (MediaFormatType.Audio | MediaFormatDataType.Encoded | 0x1060),

        /// <summary>
        /// AAC-LC (Advanced Audio Coding Low-Complexity profile).
        /// </summary>
        AacLC = (MediaFormatType.Audio | MediaFormatDataType.Encoded | 0x1060),

        /// <summary>
        /// HE-AAC (High-Efficiency Advanced Audio Coding).
        /// </summary>
        AacHE = (MediaFormatType.Audio | MediaFormatDataType.Encoded | 0x1061),

        /// <summary>
        /// HE-AAC-PS (High-Efficiency Advanced Audio Coding with Parametric Stereo).
        /// </summary>
        AacHEPS = (MediaFormatType.Audio | MediaFormatDataType.Encoded | 0x1062),

        /// <summary>
        /// MP3.
        /// </summary>
        MP3 = (MediaFormatType.Audio | MediaFormatDataType.Encoded | 0x1070),

        /// <summary>
        /// VORBIS.
        /// </summary>
        Vorbis = (MediaFormatType.Audio | MediaFormatDataType.Encoded | 0x1080),

        /// <summary>
        /// FLAC.
        /// </summary>
        Flac = (MediaFormatType.Audio | MediaFormatDataType.Encoded | 0x1090),

        /// <summary>
        /// Windows Media Audio 1.
        /// </summary>
        Wma1 = (MediaFormatType.Audio | MediaFormatDataType.Encoded | 0x10A0),

        /// <summary>
        /// Windows Media Audio 2.
        /// </summary>
        Wma2 = (MediaFormatType.Audio | MediaFormatDataType.Encoded | 0x10A1),

        /// <summary>
        /// Windows Media Audio Professional.
        /// </summary>
        WmaPro = (MediaFormatType.Audio | MediaFormatDataType.Encoded | 0x10A2),

        /// <summary>
        /// Windows Media Audio Lossless.
        /// </summary>
        WmaLossless = (MediaFormatType.Audio | MediaFormatDataType.Encoded | 0x10A3),

        /// <summary>
        /// PCM.
        /// </summary>
        Pcm = (MediaFormatType.Audio | MediaFormatDataType.Raw | 0x1510),
    }
}
