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
    internal static class Decode
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void DecodeCompletedCallback(ImageUtilError error, IntPtr userData, int width, int height, ulong size);

        [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_decode_create")]
        public static extern ImageUtilError Create(out ImageDecoderHandle handle);

        [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_decode_destroy")]
        internal static extern ImageUtilError Destroy(IntPtr handle);

        [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_decode_set_input_path")]
        internal static extern ImageUtilError SetInputPath(ImageDecoderHandle handle, IntPtr path);

        [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_decode_set_input_buffer")]
        internal static extern ImageUtilError SetInputBuffer(ImageDecoderHandle handle, byte[] srcBuffer, ulong srcSize);

        [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_decode_set_output_buffer")]
        internal static extern ImageUtilError SetOutputBuffer(ImageDecoderHandle handle, IntPtr dstBuffer);

        [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_decode_set_colorspace")]
        internal static extern ImageUtilError SetColorspace(ImageDecoderHandle handle, ImageColorSpace colorspace);

        [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_decode_set_jpeg_downscale")]
        internal static extern ImageUtilError SetJpegDownscale(ImageDecoderHandle handle, JpegDownscale downscale);

        [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_decode_run_async")]
        internal static extern ImageUtilError DecodeRunAsync(ImageDecoderHandle handle, DecodeCompletedCallback callback,
            IntPtr userData = default(IntPtr));

        [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_decode_run")]
        internal static extern ImageUtilError DecodeRun(ImageDecoderHandle handle, out int width,
            out int height, out ulong size);
    }

    internal class ImageDecoderHandle : SafeHandle
    {
        protected ImageDecoderHandle() : base(IntPtr.Zero, true)
        {
        }

        public override bool IsInvalid => handle == IntPtr.Zero;

        protected override bool ReleaseHandle()
        {
            var ret = Decode.Destroy(handle);
            if (ret != ImageUtilError.None)
            {
                Log.Debug(GetType().FullName, $"Failed to release native {GetType()}");
                return false;
            }

            return true;
        }

    }
}
