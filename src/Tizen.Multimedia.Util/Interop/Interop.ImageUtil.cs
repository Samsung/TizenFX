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
using System.Runtime.InteropServices.Marshalling;
using Tizen;
using Tizen.Multimedia.Util;

internal static partial class Interop
{
    internal static partial class ImageUtil
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool SupportedColorspaceCallback(ImageColorSpace colorspace, IntPtr userData);

        [LibraryImport(Libraries.ImageUtil, EntryPoint = "image_util_foreach_supported_colorspace", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ImageUtilError ForeachSupportedColorspace(ImageFormat type, SupportedColorspaceCallback callback,
            IntPtr userData = default(IntPtr));

        [LibraryImport(Libraries.ImageUtil, EntryPoint = "image_util_extract_color_from_memory")]
        internal static partial ImageUtilError ExtractColorFromMemory(byte[] buffer, int width, int height, out byte rgbR, out byte rgbG, out byte rgbB);

        [LibraryImport(Libraries.ImageUtil, EntryPoint = "image_util_get_image", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ImageUtilError GetImage(IntPtr handle, out int width, out int height,
            out ImageColorSpace colorspace, out IntPtr data, out int size);

        [LibraryImport(Libraries.ImageUtil, EntryPoint = "image_util_destroy_image")]
        internal static partial ImageUtilError Destroy(IntPtr handle);

        [LibraryImport(Libraries.ImageUtil, EntryPoint = "image_util_create_image")]
        internal static partial ImageUtilError Create(uint width, uint height, ImageColorSpace colorSpace, byte[] srcBuffer, int size, out IntPtr handle);
    }
}
