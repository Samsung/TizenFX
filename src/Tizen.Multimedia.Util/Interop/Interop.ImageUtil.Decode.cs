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
        internal static partial class Decode
        {
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void DecodeCompletedCallback(ImageUtilError error, IntPtr userData, int width, int height, ulong size);

            [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_decode_create")]
            public static extern ImageUtilError Create(out ImageDecoderHandle handle);

            [LibraryImport(Libraries.ImageUtil, EntryPoint = "image_util_decode_destroy", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ImageUtilError Destroy(IntPtr handle);

            [LibraryImport(Libraries.ImageUtil, EntryPoint = "image_util_decode_set_input_path", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ImageUtilError SetInputPath(ImageDecoderHandle handle, IntPtr path);

            [LibraryImport(Libraries.ImageUtil, EntryPoint = "image_util_decode_set_input_buffer", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ImageUtilError SetInputBuffer(ImageDecoderHandle handle, byte[] srcBuffer, ulong srcSize);

            [LibraryImport(Libraries.ImageUtil, EntryPoint = "image_util_decode_set_colorspace", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ImageUtilError SetColorspace(ImageDecoderHandle handle, ImageColorSpace colorspace);

            [LibraryImport(Libraries.ImageUtil, EntryPoint = "image_util_decode_set_jpeg_downscale", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ImageUtilError SetJpegDownscale(ImageDecoderHandle handle, JpegDownscale downscale);

            [LibraryImport(Libraries.ImageUtil, EntryPoint = "image_util_decode_run2", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ImageUtilError DecodeRun(ImageDecoderHandle handle, out IntPtr imageHandle);
        }
    }

    internal partial class ImageDecoderHandle : SafeHandle
    {
        protected ImageDecoderHandle() : base(IntPtr.Zero, true)
        {
        }

        public override bool IsInvalid => handle == IntPtr.Zero;

        protected override bool ReleaseHandle()
        {
            var ret = ImageUtil.Decode.Destroy(handle);
            if (ret != ImageUtilError.None)
            {
                Log.Debug(GetType().FullName, $"Failed to release native {GetType()}");
                return false;
            }

            return true;
        }
    }
}
