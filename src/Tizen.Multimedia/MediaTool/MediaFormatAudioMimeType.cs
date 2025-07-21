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
        /// L16.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        L16 = (MediaFormatType.Audio | MediaFormatDataType.Encoded | 0x1010),

        /// <summary>
        /// AlAW.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        AlAW = (MediaFormatType.Audio | MediaFormatDataType.Encoded | 0x1020),

        /// <summary>
        /// UlAW.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        UlAW = (MediaFormatType.Audio | MediaFormatDataType.Encoded | 0x1030),

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
        /// G729.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        G729 = (MediaFormatType.Audio | MediaFormatDataType.Encoded | 0x1050),

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
        /// MP2.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        MP2 = (MediaFormatType.Audio | MediaFormatDataType.Encoded | 0x1071),

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
        /// AC3.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        Ac3 = (MediaFormatType.Audio | MediaFormatDataType.Encoded | 0x10B1),

        /// <summary>
        /// Enhanced AC3.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        Eac3 = (MediaFormatType.Audio | MediaFormatDataType.Encoded | 0x10B2),

        /// <summary>
        /// Digital Theater Systems.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        Dts = (MediaFormatType.Audio | MediaFormatDataType.Encoded | 0x10C1),

        /// <summary>
        /// OPUS.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        Opus = (MediaFormatType.Audio | MediaFormatDataType.Encoded | 0x10D1),

        /// <summary>
        /// PCM.
        /// </summary>
        Pcm = (MediaFormatType.Audio | MediaFormatDataType.Raw | 0x1510),

        /// <summary>
        /// PCM signed 16-bit little endian.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        PcmS16le = (MediaFormatType.Audio | MediaFormatDataType.Raw | 0x1510),

        /// <summary>
        /// PCM signed 24-bit little endian.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        PcmS24le = (MediaFormatType.Audio | MediaFormatDataType.Raw | 0x1511),

        /// <summary>
        /// PCM signed 32-bit little endian.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        PcmS32le = (MediaFormatType.Audio | MediaFormatDataType.Raw | 0x1512),

        /// <summary>
        /// PCM signed 16-bit big endian.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        PcmS16be = (MediaFormatType.Audio | MediaFormatDataType.Raw | 0x1513),

        /// <summary>
        /// PCM signed 24-bit big endian.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        PcmS24be = (MediaFormatType.Audio | MediaFormatDataType.Raw | 0x1514),

        /// <summary>
        /// PCM signed 32-bit big endian.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        PcmS32be = (MediaFormatType.Audio | MediaFormatDataType.Raw | 0x1515),

        /// <summary>
        /// PCM 32-bit floating point little endian.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        PcmF32le = (MediaFormatType.Audio | MediaFormatDataType.Raw | 0x1516),

        /// <summary>
        /// PCM 32-bit floating point big endian.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        PcmF32be = (MediaFormatType.Audio | MediaFormatDataType.Raw | 0x1517),

        /// <summary>
        /// PCM unsigned 16-bit little endian.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        PcmU16le = (MediaFormatType.Audio | MediaFormatDataType.Raw | 0x1518),

        /// <summary>
        /// PCM unsigned 24-bit little endian.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        PcmU24le = (MediaFormatType.Audio | MediaFormatDataType.Raw | 0x1519),

        /// <summary>
        /// PCM unsigned 32-bit little endian.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        PcmU32le = (MediaFormatType.Audio | MediaFormatDataType.Raw | 0x151A),

        /// <summary>
        /// PCM unsigned 16-bit big endian.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        PcmU16be = (MediaFormatType.Audio | MediaFormatDataType.Raw | 0x151B),

        /// <summary>
        /// PCM unsigned 24-bit big endian.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        PcmU24be = (MediaFormatType.Audio | MediaFormatDataType.Raw | 0x151C),

        /// <summary>
        /// PCM unsigned 32-bit big endian.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        PcmU32be = (MediaFormatType.Audio | MediaFormatDataType.Raw | 0x151D),

        /// <summary>
        /// PCM A-law.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        PcmA = (MediaFormatType.Audio | MediaFormatDataType.Raw | 0x1520),

        /// <summary>
        /// PCM U-law.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        PcmU = (MediaFormatType.Audio | MediaFormatDataType.Raw | 0x1530)
    }
}
