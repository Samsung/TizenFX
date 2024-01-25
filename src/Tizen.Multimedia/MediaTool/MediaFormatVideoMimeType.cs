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
    /// Specifies the mime types for video media formats.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
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
        /// HEVC.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        Hevc = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x2080),

        /// <summary>
        /// HEVC MP.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        HevcMp = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x2081),

        /// <summary>
        /// HEVC M10P.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        HevcM10p = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x2082),

        /// <summary>
        /// VP8.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        Vp8 = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x2090),

        /// <summary>
        /// VP9.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        Vp9 = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x20A0),

        /// <summary>
        /// VC1.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        Vc1 = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x20B0),

        /// <summary>
        /// DIVX4.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        Divx4 = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x20C4),

        /// <summary>
        /// DIVX5.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        Divx5 = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x20C5),

        /// <summary>
        /// XVID.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        Xvid = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x20D0),

        /// <summary>
        /// AOMedia Video 1.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        Av1 = (MediaFormatType.Video | MediaFormatDataType.Encoded | 0x20E0),

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
        Rgb565 = (MediaFormatType.Video | MediaFormatDataType.Raw | 0x25A0),

        /// <summary>
        /// RGB888.
        /// </summary>
        Rgb888 = (MediaFormatType.Video | MediaFormatDataType.Raw | 0x25B0),

        /// <summary>
        /// RGBA.
        /// </summary>
        Rgba = (MediaFormatType.Video | MediaFormatDataType.Raw | 0x25C0),

        /// <summary>
        /// ARGB.
        /// </summary>
        Argb = (MediaFormatType.Video | MediaFormatDataType.Raw | 0x25D0),

        /// <summary>
        /// BGRA.
        /// </summary>
        Bgra = (MediaFormatType.Video | MediaFormatDataType.Raw | 0x25E0),

        /// <summary>
        /// Y8.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        Y8 = (MediaFormatType.Video | MediaFormatDataType.Raw | 0x25F0),
    }
}
