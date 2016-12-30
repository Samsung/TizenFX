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
    /// Enumeration for media format type
    /// </summary>
    public enum MediaFormatType
    {
        /// <summary>
        /// Audio
        /// </summary>
        Audio = 0x01000000,

        /// <summary>
        /// Video
        /// </summary>
        Video = 0x02000000,

        /// <summary>
        /// Container
        /// </summary>
        Container = 0x04000000,

        /// <summary>
        /// Text
        /// </summary>
        Text = 0x03000000,
    }

    /// <summary>
    /// Enumeration for media format data type
    /// </summary>
    internal enum MediaFormatDataType
    {
        /// <summary>
        /// Encoded type
        /// </summary>
        Encoded = 0x10000000,

        /// <summary>
        /// Raw type
        /// </summary>
        Raw = 0x20000000,
    }

    public enum MediaFormatAudioMimeType
    {
        /// <summary>
        /// L16, Audio
        /// </summary>
        //L16 = (MediaFormatType.Audio | MediaFormatDataType.Encoded | 0x1010),

        /// <summary>
        /// ALAW, Audio
        /// </summary>
        //ALaw = (MediaFormatType.Audio | MediaFormatDataType.Encoded | 0x1020),

        /// <summary>
        /// ULAW,  Audio
        /// </summary>
        //ULaw = (MediaFormatType.Audio | MediaFormatDataType.Encoded | 0x1030),

        /// <summary>
        /// AMR, Audio, Alias for AmrNB
        /// </summary>
        Amr = (MediaFormatType.Audio | MediaFormatDataType.Encoded | 0x1040),

        /// <summary>
        /// AMR-NB, Audio
        /// </summary>
        AmrNB = (MediaFormatType.Audio | MediaFormatDataType.Encoded | 0x1040),

        /// <summary>
        /// AMR-WB, Audio
        /// </summary>
        AmrWB = (MediaFormatType.Audio | MediaFormatDataType.Encoded | 0x1041),

        /// <summary>
        /// G729, Audio
        /// </summary>
        //G729 = (MediaFormatType.Audio | MediaFormatDataType.Encoded | 0x1050),

        /// <summary>
        /// AAC, Audio, Alias for AacLc
        /// </summary>
        Aac = (MediaFormatType.Audio | MediaFormatDataType.Encoded | 0x1060),

        /// <summary>
        /// AAC-LC (Advanced Audio Coding Low-Complexity profile), Audio
        /// </summary>
        AacLC = (MediaFormatType.Audio | MediaFormatDataType.Encoded | 0x1060),

        /// <summary>
        /// HE-AAC (High-Efficiency Advanced Audio Coding), Audio
        /// </summary>
        AacHE = (MediaFormatType.Audio | MediaFormatDataType.Encoded | 0x1061),

        /// <summary>
        /// HE-AAC-PS (High-Efficiency Advanced Audio Coding with Parametric Stereo), Audio
        /// </summary>
        AacHEPS = (MediaFormatType.Audio | MediaFormatDataType.Encoded | 0x1062),

        /// <summary>
        /// MP3, Audio
        /// </summary>
        MP3 = (MediaFormatType.Audio | MediaFormatDataType.Encoded | 0x1070),

        /// <summary>
        /// VORBIS, Audio
        /// </summary>
        Vorbis = (MediaFormatType.Audio | MediaFormatDataType.Encoded | 0x1080),

        /// <summary>
        /// FLAC, Audio
        /// </summary>
        Flac = (MediaFormatType.Audio | MediaFormatDataType.Encoded | 0x1090),

        /// <summary>
        /// Windows Media Audio 1, Audio
        /// </summary>
        Wma1 = (MediaFormatType.Audio | MediaFormatDataType.Encoded | 0x10A0),

        /// <summary>
        /// Windows Media Audio 2, Audio
        /// </summary>
        Wma2 = (MediaFormatType.Audio | MediaFormatDataType.Encoded | 0x10A1),

        /// <summary>
        /// Windows Media Audio Professional, Audio
        /// </summary>
        WmaPro = (MediaFormatType.Audio | MediaFormatDataType.Encoded | 0x10A2),

        /// <summary>
        /// Windows Media Audio Lossless, Audio
        /// </summary>
        WmaLossless = (MediaFormatType.Audio | MediaFormatDataType.Encoded | 0x10A3),

        /// <summary>
        /// PCM, Audio, Alias for PcmS16LE
        /// </summary>
        Pcm = (MediaFormatType.Audio | MediaFormatDataType.Raw | 0x1510),

        /// <summary>
        /// PCM signed 16-bit little-endian, Audio
        /// </summary>
        //PcmS16LE = (MediaFormatType.Audio | MediaFormatDataType.Raw | 0x1510),

        /// <summary>
        /// PCM signed 24-bit little-endian, Audio
        /// </summary>
        //PcmS24LE = (MediaFormatType.Audio | MediaFormatDataType.Raw | 0x1511),

        /// <summary>
        /// PCM signed 32-bit little-endian, Audio
        /// </summary>
        //Pcm32LE = (MediaFormatType.Audio | MediaFormatDataType.Raw | 0x1512),

        /// <summary>
        /// PCM signed 16-bit big-endian, Audio
        /// </summary>
        //PcmS16BE = (MediaFormatType.Audio | MediaFormatDataType.Raw | 0x1513),

        /// <summary>
        /// PCM signed 24-bit big-endian, Audio
        /// </summary>
        //PcmS24BE = (MediaFormatType.Audio | MediaFormatDataType.Raw | 0x1514),

        /// <summary>
        /// PCM signed 32-bit big-endian, Audio
        /// </summary>
        //PcmS32BE = (MediaFormatType.Audio | MediaFormatDataType.Raw | 0x1515),

        /// <summary>
        /// PCM 32-bit floating point little-endian, Audio
        /// </summary>
        //PcmF32LE = (MediaFormatType.Audio | MediaFormatDataType.Raw | 0x1516),

        /// <summary>
        /// PCM 32-bit floating point big-endian, Audio
        /// </summary>
        //PcmF32BE = (MediaFormatType.Audio | MediaFormatDataType.Raw | 0x1517),

        /// <summary>
        /// PCM A-law, Audio
        /// </summary>
        //PcmALaw = (MediaFormatType.Audio | MediaFormatDataType.Raw | 0x1520),

        /// <summary>
        /// PCM U-law, Audio
        /// </summary>
        //PcmULaw = (MediaFormatType.Audio | MediaFormatDataType.Raw | 0x1530),
    }

    /// <summary>
    /// Enumeration for media format MIME type
    /// </summary>
    public enum MediaFormatVideoMimeType
    {
        /// <summary>
        /// H261
        /// </summary>
        H261 = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x2010),

        /// <summary>
        /// H263
        /// </summary>
        H263 = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x2020),

        /// <summary>
        /// H263P
        /// </summary>
        H263P = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x2021),

        /// <summary>
        /// H263 Baseline Profile
        /// </summary>
        //H263BP = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x2022),

        /// <summary>
        /// H263 H.320 Coding Efficiency Profile
        /// </summary>
        //H263H320Cep = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x2023),

        /// <summary>
        /// H263 Backward-Compatibility Profile
        /// </summary>
        //H263Bcp = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x2024),

        /// <summary>
        /// H263 Interactive and Streaming Wireless Profile
        /// </summary>
        //H263Isw2p = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x2025),

        /// <summary>
        /// H263 Interactive and Streaming Wireless Profile
        /// </summary>
        //H263Isw3p = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x2026),

        /// <summary>
        /// H263 Conversation High Compression Profile
        /// </summary>
        //H263Chcp = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x2027),

        /// <summary>
        /// H263 Conversational Internet Profile
        /// </summary>
        //H263CInternetP = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x2028),

        /// <summary>
        /// H263 Conversational Interlace Profile
        /// </summary>
        //H263CInterlaceP = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x2029),

        /// <summary>
        /// H263 High Latency Profile
        /// </summary>
        //H263Hlp = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x202A),

        /// <summary>
        /// H264_SP
        /// </summary>
        H264SP = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x2030),

        /// <summary>
        /// H264_MP
        /// </summary>
        H264MP = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x2031),

        /// <summary>
        /// H264_HP
        /// </summary>
        H264HP = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x2032),

        /// <summary>
        /// H264 Extended Profile
        /// </summary>
        //H264XP = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x2033),

        /// <summary>
        /// H264 High10 Profile
        /// </summary>
        //H264H10P = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x2034),

        /// <summary>
        /// H264 High422 Profile
        /// </summary>
        //H264H422P = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x2035),

        /// <summary>
        /// H264 High444 Profile
        /// </summary>
        //H264H444P = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x2036),

        /// <summary>
        /// H264 CAVLC444 Profile
        /// </summary>
        //H264C444P = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x2037),

        /// <summary>
        /// MJPEG
        /// </summary>
        MJpeg = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x2040),

        /// <summary>
        /// MPEG1
        /// </summary>
        Mpeg1 = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x2050),

        /// <summary>
        /// MPEG2_SP
        /// </summary>
        Mpeg2SP = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x2060),

        /// <summary>
        /// MPEG2_MP
        /// </summary>
        Mpeg2MP = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x2061),

        /// <summary>
        /// MPEG2_HP
        /// </summary>
        Mpeg2HP = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x2062),

        /// <summary>
        /// MPEG4_SP
        /// </summary>
        Mpeg4SP = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x2070),

        /// <summary>
        /// MPEG4_ASP
        /// </summary>
        Mpeg4Asp = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x2071),

        /// <summary>
        /// HEVC
        /// </summary>
        //Hevc = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x2080),

        /// <summary>
        /// HEVC Main Profile
        /// </summary>
        //HevcMP = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x2081),

        /// <summary>
        /// HEVC Main10 Profile
        /// </summary>
        //HevcM10P = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x2082),

        /// <summary>
        /// VP8
        /// </summary>
        //VP8 = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x2090),

        /// <summary>
        /// VP9
        /// </summary>
        //VP9 = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x20A0),

        /// <summary>
        /// VC1
        /// </summary>
        //VC1 = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x20B0),

        /// <summary>
        /// I420
        /// </summary>
        I420 = (MediaFormatType.Video | MediaFormatDataType.Raw | 0x2510),

        /// <summary>
        /// NV12
        /// </summary>
        NV12 = (MediaFormatType.Video | MediaFormatDataType.Raw | 0x2520),

        /// <summary>
        /// NV12T
        /// </summary>
        NV12T = (MediaFormatType.Video | MediaFormatDataType.Raw | 0x2530),

        /// <summary>
        /// YV12
        /// </summary>
        YV12 = (MediaFormatType.Video | MediaFormatDataType.Raw | 0x2540),

        /// <summary>
        /// NV21
        /// </summary>
        NV21 = (MediaFormatType.Video | MediaFormatDataType.Raw | 0x2550),

        /// <summary>
        /// NV16
        /// </summary>
        NV16 = (MediaFormatType.Video | MediaFormatDataType.Raw | 0x2560),

        /// <summary>
        /// YUYV
        /// </summary>
        Yuyv = (MediaFormatType.Video | MediaFormatDataType.Raw | 0x2570),

        /// <summary>
        /// UYVY
        /// </summary>
        Uyvy = (MediaFormatType.Video | MediaFormatDataType.Raw | 0x2580),

        /// <summary>
        /// 422P
        /// </summary>
        Yuv422P = (MediaFormatType.Video | MediaFormatDataType.Raw | 0x2590),

        /// <summary>
        /// RGB565
        /// </summary>
        Rgb565 = (MediaFormatType.Video | MediaFormatDataType.Raw | 0x25a0),

        /// <summary>
        /// RGB888
        /// </summary>
        Rgb888 = (MediaFormatType.Video | MediaFormatDataType.Raw | 0x25b0),

        /// <summary>
        /// RGBA
        /// </summary>
        Rgba = (MediaFormatType.Video | MediaFormatDataType.Raw | 0x25c0),

        /// <summary>
        /// ARGB
        /// </summary>
        Argb = (MediaFormatType.Video | MediaFormatDataType.Raw | 0x25d0),

        /// <summary>
        /// BGRA
        /// </summary>
        Bgra = (MediaFormatType.Video | MediaFormatDataType.Raw | 0x25e0),

        /// <summary>
        /// HW dependent
        /// </summary>
        //NativeVideo = (MediaFormatType.Video | MediaFormatDataType.Raw | 0x7000),
    }

    public enum MediaFormatContainerMimeType
    {
        /// <summary>
        /// MP4 container, Video
        /// </summary>
        MP4 = (MediaFormatType.Container | 0x3010),

        /// <summary>
        /// AVI container, Video
        /// </summary>
        Avi = (MediaFormatType.Container | 0x3020),

        /// <summary>
        /// MPEG2TS container, Video
        /// </summary>
        Mpeg2TS = (MediaFormatType.Container | 0x3030),

        /// <summary>
        /// MPEG2PS container, Video
        /// </summary>
        Mpeg2PS = (MediaFormatType.Container | 0x3040),

        /// <summary>
        /// MATROSKA container, Video
        /// </summary>
        Matroska = (MediaFormatType.Container | 0x3050),

        /// <summary>
        /// WEBM container, Video
        /// </summary>
        Webm = (MediaFormatType.Container | 0x3060),

        /// <summary>
        /// 3GP container, Video
        /// </summary>
        ThreeGP = (MediaFormatType.Container | 0x3070),



        /// <summary>
        /// WAV container, Audio
        /// </summary>
        Wav = (MediaFormatType.Container | 0x4010),

        /// <summary>
        ///  OGG container, Audio
        /// </summary>
        Ogg = (MediaFormatType.Container | 0x4020),

        /// <summary>
        /// AAC_ADTS container, Audio
        /// </summary>
        AacAdts = (MediaFormatType.Container | 0x4030),

        /// <summary>
        /// AAC_ADIF container, Audio
        /// </summary>
        AacAdif = (MediaFormatType.Container | 0x4031),
    }

    public enum MediaFormatTextMimeType
    {
        /// <summary>
        /// MP4
        /// </summary>
        MP4 = (MediaFormatType.Text | MediaFormatDataType.Encoded | 0x8010),

        /// <summary>
        /// 3GP
        /// </summary>
        ThreeGP = (MediaFormatType.Text | MediaFormatDataType.Encoded | 0x8020),
    }

}

