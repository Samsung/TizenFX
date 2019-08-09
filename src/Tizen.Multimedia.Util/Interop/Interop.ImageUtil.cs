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
using System.Runtime.InteropServices;
using Tizen;
using Tizen.Multimedia.Util;

internal static partial class Interop
{
    internal static partial class ImageUtil
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool SupportedColorspaceCallback(ImageColorSpace colorspace, IntPtr userData);

        [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_foreach_supported_colorspace")]
        internal static extern ImageUtilError ForeachSupportedColorspace(ImageFormat type, SupportedColorspaceCallback callback,
            IntPtr userData = default(IntPtr));

        [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_calculate_buffer_size")]
        internal static extern ImageUtilError CalculateBufferSize(int width, int height, ImageColorSpace colorspace, out uint size);

        [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_extract_color_from_memory")]
        internal static extern ImageUtilError ExtractColorFromMemory(byte[] buffer, int width, int height, out byte rgbR, out byte rgbG, out byte rgbB);

        [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_get_image")]
        internal static extern ImageUtilError GetImage(IntPtr handle, out int width, out int height,
            out ImageColorSpace colorspace, out IntPtr data, out int size);

        [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_destroy_image")]
        internal static extern ImageUtilError Destroy(IntPtr handle);
    }
}
