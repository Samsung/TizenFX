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
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal enum ImageColorSpace
    {
        Yv12, // IMAGE_UTIL_COLORSPACE_YV12
        Yuv422, // IMAGE_UTIL_COLORSPACE_YUV422
        I420, // IMAGE_UTIL_COLORSPACE_I420
        Nv12, // IMAGE_UTIL_COLORSPACE_NV12
        Uyvy, // IMAGE_UTIL_COLORSPACE_UYVY
        Yuyv, // IMAGE_UTIL_COLORSPACE_YUYV
        Rgb565, // IMAGE_UTIL_COLORSPACE_RGB565
        Rgb888, // IMAGE_UTIL_COLORSPACE_RGB888
        Argb8888, // IMAGE_UTIL_COLORSPACE_ARGB8888
        Bgra8888, // IMAGE_UTIL_COLORSPACE_BGRA8888
        Rgba8888, // IMAGE_UTIL_COLORSPACE_RGBA8888
        Bgrx8888, // IMAGE_UTIL_COLORSPACE_BGRX8888
        Nv21, // IMAGE_UTIL_COLORSPACE_NV21
        Nv16, // IMAGE_UTIL_COLORSPACE_NV16
        Nv61, // IMAGE_UTIL_COLORSPACE_NV61
    }

    internal enum ImageRotation
    {
        None, // IMAGE_UTIL_ROTATION_NONE
        Rotate90, // IMAGE_UTIL_ROTATION_90
        Rotate180, // IMAGE_UTIL_ROTATION_180
        Rotate270, // IMAGE_UTIL_ROTATION_270
        FlipHorizontal, // IMAGE_UTIL_ROTATION_FLIP_HORZ
        FlipVertical, // IMAGE_UTIL_ROTATION_FLIP_VERT
    }

    internal enum ImageType
    {
        Jpeg, // IMAGE_UTIL_JPEG
        Png, // IMAGE_UTIL_PNG
        Gif, // IMAGE_UTIL_GIF
        Bmp, // IMAGE_UTIL_BMP
    }

    internal enum JpegDownscale
    {
        NoDownscale, // IMAGE_UTIL_DOWNSCALE_1_1
        OneHalf, // IMAGE_UTIL_DOWNSCALE_1_2
        OneFourth, // IMAGE_UTIL_DOWNSCALE_1_4
        OneEighth, // IMAGE_UTIL_DOWNSCALE_1_8
    }

    internal enum PngCompression
    {
        NoCompression, // IMAGE_UTIL_PNG_COMPRESSION_0
        Level1, // IMAGE_UTIL_PNG_COMPRESSION_1
        Level2, // IMAGE_UTIL_PNG_COMPRESSION_2
        Level3, // IMAGE_UTIL_PNG_COMPRESSION_3
        Level4, // IMAGE_UTIL_PNG_COMPRESSION_4
        Level5, // IMAGE_UTIL_PNG_COMPRESSION_5
        Level6, // IMAGE_UTIL_PNG_COMPRESSION_6
        Level7, // IMAGE_UTIL_PNG_COMPRESSION_7
        Level8, // IMAGE_UTIL_PNG_COMPRESSION_8
        Level9, // IMAGE_UTIL_PNG_COMPRESSION_9
    }

    internal class ImageUtil
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool SupportedColorspaceCallback(ImageColorSpace /* image_util_colorspace_e */ colorspace, IntPtr /* void */ userData);

        [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_foreach_supported_colorspace")]
        internal static extern ErrorCode ForeachSupportedColorspace(ImageType /* image_util_type_e */ type, SupportedColorspaceCallback callback, IntPtr /* void */ userData);

        [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_calculate_buffer_size")]
        internal static extern ErrorCode CalculateBufferSize(int width, int height, ImageColorSpace /* image_util_colorspace_e */ colorspace, out uint size);

        [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_extract_color_from_memory")]
        internal static extern ErrorCode ExtractColorFromMemory(byte[] buffer, int width, int height, out byte rgbR, out byte rgbG, out byte rgbB);

        internal static void ForeachSupportedColorspace(ImageType type, Action<ImageColorSpace> action)
        {
            SupportedColorspaceCallback callback = (codec, userData) =>
            {
                action(codec);
                return true;
            };

            ForeachSupportedColorspace(type, callback, IntPtr.Zero).WarnIfFailed("Failed to get supported color-space list from native handle");
        }

        internal static uint CalculateBufferSize(int width, int height, ImageColorSpace colorSpace)
        {
            uint size;
            CalculateBufferSize(width, height, colorSpace, out size).ThrowIfFailed("Failed to calculate buffer size");
            return size;
        }

        internal static ElmSharp.Color ExtractColorFromMemory(byte[] buffer, int width, int height)
        {
            byte r, g, b;
            ExtractColorFromMemory(buffer, width, height, out r, out g, out b);
            return new ElmSharp.Color(r, g, b);
        }

        internal static byte[] NativeToByteArray(IntPtr nativeBuffer, int size)
        {
            Debug.Assert(nativeBuffer != IntPtr.Zero);

            byte[] managedArray = new byte[size];
            Marshal.Copy(nativeBuffer, managedArray, 0, size);

            Libc.Free(nativeBuffer);
            return managedArray;
        }
    }
}
