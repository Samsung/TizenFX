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

namespace Tizen.Multimedia.Utility
{
    /// <summary>
    /// Image color space
    /// </summary>
    public enum ImageColorSpace
    {
        /// <summary>
        /// YV12 - YCrCb planar format
        /// </summary>
        Yv12 = Interop.ImageColorSpace.Yv12,
        /// <summary>
        /// UYVY - packed
        /// </summary>
        Uyvy = Interop.ImageColorSpace.Uyvy,
        /// <summary>
        /// YUYV - packed
        /// </summary>
        Yuyv = Interop.ImageColorSpace.Yuyv,
        /// <summary>
        /// YUV422 - planar
        /// </summary>
        Yuv422 = Interop.ImageColorSpace.Yuv422,
        /// <summary>
        /// YUV420 - planar
        /// </summary>
        I420 = Interop.ImageColorSpace.I420,
        /// <summary>
        /// RGB565, high-byte is Blue
        /// </summary>
        Rgb565 = Interop.ImageColorSpace.Rgb565,
        /// <summary>
        /// RGB888, high-byte is Blue
        /// </summary>
        Rgb888 = Interop.ImageColorSpace.Rgb888,
        /// <summary>
        /// ARGB8888, high-byte is Blue
        /// </summary>
        Argb8888 = Interop.ImageColorSpace.Argb8888,
        /// <summary>
        /// BGRA8888, high-byte is Alpha
        /// </summary>
        Bgra8888 = Interop.ImageColorSpace.Bgra8888,
        /// <summary>
        /// RGBA8888, high-byte is Alpha
        /// </summary>
        Rgba8888 = Interop.ImageColorSpace.Rgba8888,
        /// <summary>
        /// BGRX8888, high-byte is X
        /// </summary>
        Bgrx8888 = Interop.ImageColorSpace.Bgrx8888,
        /// <summary>
        /// NV12- planar
        /// </summary>
        Nv12 = Interop.ImageColorSpace.Nv12,
        /// <summary>
        /// NV16- planar
        /// </summary>
        Nv16 = Interop.ImageColorSpace.Nv16,
        /// <summary>
        /// NV21- planar
        /// </summary>
        Nv21 = Interop.ImageColorSpace.Nv21,
        /// <summary>
        /// NV61- planar
        /// </summary>
        Nv61 = Interop.ImageColorSpace.Nv61,
    }
}