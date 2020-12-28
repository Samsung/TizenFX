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
        internal static class Encode
        {
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void EncodeCompletedCallback(ImageUtilError ImageUtilError, IntPtr userData, ulong size);

            [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_encode_run_async")]
            internal static extern ImageUtilError EncodeRunAsync(ImageEncoderHandle handle,
                EncodeCompletedCallback callback, IntPtr userData = default(IntPtr));

            [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_encode_create")]
            internal static extern ImageUtilError Create(ImageFormat type, out ImageEncoderHandle handle);

            [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_encode_destroy")]
            internal static extern ImageUtilError Destroy(IntPtr handle);

            [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_encode_set_resolution")]
            internal static extern ImageUtilError SetResolution(ImageEncoderHandle handle, uint width, uint height);

            [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_encode_set_colorspace")]
            internal static extern ImageUtilError SetColorspace(ImageEncoderHandle handle, ImageColorSpace colorspace);

            [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_encode_set_quality")]
            internal static extern ImageUtilError SetQuality(ImageEncoderHandle handle, int quality);

            [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_encode_set_png_compression")]
            internal static extern ImageUtilError SetPngCompression(ImageEncoderHandle handle, PngCompression compression);

            [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_encode_set_gif_frame_delay_time")]
            internal static extern ImageUtilError SetGifFrameDelayTime(ImageEncoderHandle handle, ulong delayTime);

            [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_encode_set_output_path")]
            internal static extern ImageUtilError SetOutputPath(ImageEncoderHandle handle, string path);

            [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_encode_set_input_buffer")]
            internal static extern ImageUtilError SetInputBuffer(ImageEncoderHandle handle, byte[] srcBuffer);

            [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_encode_set_output_buffer")]
            internal static extern ImageUtilError SetOutputBuffer(ImageEncoderHandle handle, out IntPtr dstBuffer);

            [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_encode_run")]
            internal static extern ImageUtilError Run(ImageEncoderHandle handle, out ulong size);

            [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_encode_set_webp_lossless")]
            internal static extern ImageUtilError SetWebPLossless(ImageEncoderHandle handle, bool lossless);
        }
    }

    internal class ImageEncoderHandle : SafeHandle
    {
        protected ImageEncoderHandle() : base(IntPtr.Zero, true)
        {
        }

        public override bool IsInvalid => handle == IntPtr.Zero;


        protected override bool ReleaseHandle()
        {
            var ret = ImageUtil.Encode.Destroy(handle);
            if (ret != ImageUtilError.None)
            {
                Log.Debug(GetType().FullName, $"Failed to release native {GetType().Name}");
                return false;
            }

            return true;
        }
    }
}
