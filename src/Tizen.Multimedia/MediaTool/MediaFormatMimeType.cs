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
    /// Specifies the media format types.
    /// </summary>
    /// <seealso cref="MediaFormat"/>
    public enum MediaFormatType
    {
        /// <summary>
        /// Audio media format.
        /// </summary>
        Audio = 0x01000000,

        /// <summary>
        /// Video media format.
        /// </summary>
        Video = 0x02000000,

        /// <summary>
        /// Container media format.
        /// </summary>
        Container = 0x04000000,

        /// <summary>
        /// Text media format.
        /// </summary>
        Text = 0x03000000,
    }

    /// <summary>
    /// Specifies the media format data types.
    /// </summary>
    internal enum MediaFormatDataType
    {
        /// <summary>
        /// Encoded type.
        /// </summary>
        Encoded = 0x10000000,

        /// <summary>
        /// Raw type.
        /// </summary>
        Raw = 0x20000000,
    }

    /// <summary>
    /// Specifies the mime types for audio media formats.
    /// </summary>
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

    /// <summary>
    /// Specifies the mime types for video media formats.
    /// </summary>
    public enum MediaFormatVideoMimeType
    {
        /// <summary>
        /// H261.
        /// </summary>
        H261 = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x2010),

        /// <summary>
        /// H263.
        /// </summary>
        H263 = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x2020),

        /// <summary>
        /// H263P.
        /// </summary>
        H263P = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x2021),

        /// <summary>
        /// H264_SP.
        /// </summary>
        H264SP = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x2030),

        /// <summary>
        /// H264_MP.
        /// </summary>
        H264MP = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x2031),

        /// <summary>
        /// H264_HP.
        /// </summary>
        H264HP = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x2032),

        /// <summary>
        /// MJPEG
        /// </summary>
        MJpeg = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x2040),

        /// <summary>
        /// MPEG1.
        /// </summary>
        Mpeg1 = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x2050),

        /// <summary>
        /// MPEG2_SP.
        /// </summary>
        Mpeg2SP = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x2060),

        /// <summary>
        /// MPEG2_MP.
        /// </summary>
        Mpeg2MP = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x2061),

        /// <summary>
        /// MPEG2_HP.
        /// </summary>
        Mpeg2HP = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x2062),

        /// <summary>
        /// MPEG4_SP.
        /// </summary>
        Mpeg4SP = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x2070),

        /// <summary>
        /// MPEG4_ASP.
        /// </summary>
        Mpeg4Asp = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x2071),

        /// <summary>
        /// I420.
        /// </summary>
        I420 = (MediaFormatType.Video | MediaFormatDataType.Raw | 0x2510),

        /// <summary>
        /// NV12.
        /// </summary>
        NV12 = (MediaFormatType.Video | MediaFormatDataType.Raw | 0x2520),

        /// <summary>
        /// NV12T.
        /// </summary>
        NV12T = (MediaFormatType.Video | MediaFormatDataType.Raw | 0x2530),

        /// <summary>
        /// YV12.
        /// </summary>
        YV12 = (MediaFormatType.Video | MediaFormatDataType.Raw | 0x2540),

        /// <summary>
        /// NV21.
        /// </summary>
        NV21 = (MediaFormatType.Video | MediaFormatDataType.Raw | 0x2550),

        /// <summary>
        /// NV16.
        /// </summary>
        NV16 = (MediaFormatType.Video | MediaFormatDataType.Raw | 0x2560),

        /// <summary>
        /// YUYV.
        /// </summary>
        Yuyv = (MediaFormatType.Video | MediaFormatDataType.Raw | 0x2570),

        /// <summary>
        /// UYVY.
        /// </summary>
        Uyvy = (MediaFormatType.Video | MediaFormatDataType.Raw | 0x2580),

        /// <summary>
        /// 422P.
        /// </summary>
        Yuv422P = (MediaFormatType.Video | MediaFormatDataType.Raw | 0x2590),

        /// <summary>
        /// RGB565.
        /// </summary>
        Rgb565 = (MediaFormatType.Video | MediaFormatDataType.Raw | 0x25a0),

        /// <summary>
        /// RGB888.
        /// </summary>
        Rgb888 = (MediaFormatType.Video | MediaFormatDataType.Raw | 0x25b0),

        /// <summary>
        /// RGBA.
        /// </summary>
        Rgba = (MediaFormatType.Video | MediaFormatDataType.Raw | 0x25c0),

        /// <summary>
        /// ARGB.
        /// </summary>
        Argb = (MediaFormatType.Video | MediaFormatDataType.Raw | 0x25d0),

        /// <summary>
        /// BGRA.
        /// </summary>
        Bgra = (MediaFormatType.Video | MediaFormatDataType.Raw | 0x25e0),

    }

    /// <summary>
    /// Specifies the mime types for container media formats.
    /// </summary>
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

    /// <summary>
    /// Specifies the text mime types.
    /// </summary>
    public enum MediaFormatTextMimeType
    {
        /// <summary>
        /// MP4.
        /// </summary>
        MP4 = (MediaFormatType.Text | MediaFormatDataType.Encoded | 0x8010),

        /// <summary>
        /// 3GP.
        /// </summary>
        ThreeGP = (MediaFormatType.Text | MediaFormatDataType.Encoded | 0x8020),
    }

}

