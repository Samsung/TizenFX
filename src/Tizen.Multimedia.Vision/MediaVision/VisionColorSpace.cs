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

namespace Tizen.Multimedia.Vision
{
    /// <summary>
    /// Specifies colorspaces for MediaVision.
    /// </summary>
    internal enum VisionColorSpace
    {
        /// <summary>
        /// The colorspace type is Y800.
        /// </summary>
        Y800 = 1,
        /// <summary>
        /// The colorspace type is I420.
        /// </summary>
        I420,
        /// <summary>
        /// The colorspace type is NV12.
        /// </summary>
        NV12,
        /// <summary>
        /// The colorspace type is YV12.
        /// </summary>
        YV12,
        /// <summary>
        /// The colorspace type is NV21.
        /// </summary>
        NV21,
        /// <summary>
        /// The colorspace type is YUYV.
        /// </summary>
        Yuyv,
        /// <summary>
        /// The colorspace type is UYVY.
        /// </summary>
        Uyvy,
        /// <summary>
        /// The colorspace type is 422P.
        /// </summary>
        Yuv422P,
        /// <summary>
        /// The colorspace type is RGB565.
        /// </summary>
        Rgb565,
        /// <summary>
        /// The colorspace type is RGB888.
        /// </summary>
        Rgb888,
        /// <summary>
        /// The colorspace type is RGBA.
        /// </summary>
        Rgba
    }

    internal static class VisionColorSpaceExtensions
    {
        internal static ColorSpace ToCommonColorSpace(this VisionColorSpace value)
        {
            Debug.Assert(Enum.IsDefined(typeof(VisionColorSpace), value));

            switch (value)
            {
                case VisionColorSpace.Y800: return ColorSpace.Y800;

                case VisionColorSpace.I420: return ColorSpace.I420;

                case VisionColorSpace.NV12: return ColorSpace.NV12;

                case VisionColorSpace.YV12: return ColorSpace.YV12;

                case VisionColorSpace.NV21: return ColorSpace.NV21;

                case VisionColorSpace.Yuyv: return ColorSpace.Yuyv;

                case VisionColorSpace.Uyvy: return ColorSpace.Uyvy;

                case VisionColorSpace.Yuv422P: return ColorSpace.Yuv422P;

                case VisionColorSpace.Rgb565: return ColorSpace.Rgb565;

                case VisionColorSpace.Rgb888: return ColorSpace.Rgb888;

                case VisionColorSpace.Rgba: return ColorSpace.Rgba8888;
            }

            throw new NotSupportedException("Implementation does not support the specified value." + value.ToString());
        }
    }

    internal static class VisionColorSpaceSupport
    {
        internal static VisionColorSpace ToVisionColorSpace(this ColorSpace colorSpace)
        {
            ValidationUtil.ValidateEnum(typeof(ColorSpace), colorSpace, nameof(colorSpace));

            switch (colorSpace)
            {
                case ColorSpace.Y800: return VisionColorSpace.Y800;

                case ColorSpace.I420: return VisionColorSpace.I420;

                case ColorSpace.NV12: return VisionColorSpace.NV12;

                case ColorSpace.YV12: return VisionColorSpace.YV12;

                case ColorSpace.NV21: return VisionColorSpace.NV21;

                case ColorSpace.Yuyv: return VisionColorSpace.Yuyv;

                case ColorSpace.Uyvy: return VisionColorSpace.Uyvy;

                case ColorSpace.Yuv422P: return VisionColorSpace.Yuv422P;

                case ColorSpace.Rgb565: return VisionColorSpace.Rgb565;

                case ColorSpace.Rgb888: return VisionColorSpace.Rgb888;

                case ColorSpace.Rgba8888: return VisionColorSpace.Rgba;
            }

            throw new NotSupportedException("Implementation does not support the specified value." + colorSpace.ToString());
        }
    }
}
