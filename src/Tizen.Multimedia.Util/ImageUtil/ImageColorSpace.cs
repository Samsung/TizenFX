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
using System.Diagnostics;

namespace Tizen.Multimedia.Util
{
    internal enum ImageColorSpace
    {
        /// <summary>
        /// YV12 - YCrCb planar format.
        /// </summary>
        YV12,
        /// <summary>
        /// YUV422 - planar.
        /// </summary>
        Yuv422,
        /// <summary>
        /// YUV420 - planar.
        /// </summary>
        I420,
        /// <summary>
        /// NV12- planar.
        /// </summary>
        NV12,
        /// <summary>
        /// UYVY - packed.
        /// </summary>
        Uyvy,
        /// <summary>
        /// YUYV - packed.
        /// </summary>
        Yuyv,
        /// <summary>
        /// RGB565, high-byte is blue.
        /// </summary>
        Rgb565,
        /// <summary>
        /// RGB888, high-byte is blue.
        /// </summary>
        Rgb888,
        /// <summary>
        /// ARGB8888, high-byte is blue.
        /// </summary>
        Argb8888,
        /// <summary>
        /// BGRA8888, high-byte is alpha.
        /// </summary>
        Bgra8888,
        /// <summary>
        /// RGBA8888, high-byte is alpha.
        /// </summary>
        Rgba8888,
        /// <summary>
        /// BGRX8888, high-byte is X.
        /// </summary>
        Bgrx8888,
        /// <summary>
        /// NV21- planar.
        /// </summary>
        NV21,
        /// <summary>
        /// NV16- planar.
        /// </summary>
        NV16,
        /// <summary>
        /// NV61- planar.
        /// </summary>
        NV61,
    }

    internal static class ImageColorSpaceExtensions
    {
        internal static ColorSpace ToCommonColorSpace(this ImageColorSpace value)
        {
            Debug.Assert(Enum.IsDefined(typeof(ImageColorSpace), value));

            switch (value)
            {
                case ImageColorSpace.YV12: return ColorSpace.YV12;

                case ImageColorSpace.Uyvy: return ColorSpace.Uyvy;

                case ImageColorSpace.Yuyv: return ColorSpace.Yuyv;

                case ImageColorSpace.Yuv422: return ColorSpace.Yuv422P;

                case ImageColorSpace.I420: return ColorSpace.I420;

                case ImageColorSpace.Rgb565: return ColorSpace.Rgb565;

                case ImageColorSpace.Rgb888: return ColorSpace.Rgb888;

                case ImageColorSpace.Argb8888: return ColorSpace.Argb8888;

                case ImageColorSpace.Bgra8888: return ColorSpace.Bgra8888;

                case ImageColorSpace.Rgba8888: return ColorSpace.Rgba8888;

                case ImageColorSpace.Bgrx8888: return ColorSpace.Bgrx8888;

                case ImageColorSpace.NV12: return ColorSpace.NV12;

                case ImageColorSpace.NV16: return ColorSpace.NV16;

                case ImageColorSpace.NV21: return ColorSpace.NV21;

                case ImageColorSpace.NV61: return ColorSpace.NV61;
            }

            Debug.Fail($"Not supported color space : {value.ToString()}!");
            throw new NotSupportedException("Implementation does not support the specified value.");
        }
    }

    internal static class ImageColorSpaceSupport
    {
        internal static ImageColorSpace ToImageColorSpace(this ColorSpace colorSpace)
        {
            ValidationUtil.ValidateEnum(typeof(ColorSpace), colorSpace, nameof(colorSpace));

            switch (colorSpace)
            {
                case ColorSpace.YV12: return ImageColorSpace.YV12;

                case ColorSpace.Uyvy: return ImageColorSpace.Uyvy;

                case ColorSpace.Yuyv: return ImageColorSpace.Yuyv;

                case ColorSpace.Yuv422: return ImageColorSpace.Yuv422;

                case ColorSpace.I420: return ImageColorSpace.I420;

                case ColorSpace.Rgb565: return ImageColorSpace.Rgb565;

                case ColorSpace.Rgb888: return ImageColorSpace.Rgb888;

                case ColorSpace.Argb8888: return ImageColorSpace.Argb8888;

                case ColorSpace.Bgra8888: return ImageColorSpace.Bgra8888;

                case ColorSpace.Rgba8888: return ImageColorSpace.Rgba8888;

                case ColorSpace.Bgrx8888: return ImageColorSpace.Bgrx8888;

                case ColorSpace.NV12: return ImageColorSpace.NV12;

                case ColorSpace.NV16: return ImageColorSpace.NV16;

                case ColorSpace.NV21: return ImageColorSpace.NV21;

                case ColorSpace.NV61: return ImageColorSpace.NV61;
            }

            throw new NotSupportedException($"The ColorSpace.{colorSpace.ToString()} is not supported.");
        }
    }
}
