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

internal static partial class Interop
{
    // Image Decoder
    [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_decode_set_input_path")]
    internal static extern ErrorCode SetInputPath(this ImageDecoderHandle /* image_util_decode_h */ handle, string path);

    [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_decode_set_input_buffer")]
    internal static extern ErrorCode SetInputBuffer(this ImageDecoderHandle /* image_util_decode_h */ handle, byte[] srcBuffer, ulong srcSize);

    [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_decode_set_output_buffer")]
    internal static extern ErrorCode SetOutputBuffer(this ImageDecoderHandle /* image_util_decode_h */ handle, out IntPtr dstBuffer);

    [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_decode_set_colorspace")]
    internal static extern ErrorCode SetColorspace(this ImageDecoderHandle /* image_util_encode_h */ handle, ImageColorSpace /* image_util_colorspace_e */ colorspace);

    [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_decode_set_jpeg_downscale")]
    internal static extern ErrorCode SetJpegDownscale(this ImageDecoderHandle /* image_util_encode_h */ handle, JpegDownscale /* image_util_scale_e */ downscale);

    [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_decode_run")]
    internal static extern ErrorCode DecodeRun(this ImageDecoderHandle /* image_util_decode_h */ handle, out int width, out int height, out ulong size);

    internal class ImageDecoderHandle : SafeMultimediaHandle
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void DecodeCompletedCallback(ErrorCode errorCode, IntPtr /* void */ userData, int width, int height, ulong size);

        [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_decode_run_async")]
        internal static extern ErrorCode DecodeRunAsync(ImageDecoderHandle /* image_util_decode_h */ handle, DecodeCompletedCallback callback, IntPtr /* void */ userData);

        [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_decode_create")]
        internal static extern ErrorCode Create(out IntPtr /* image_util_decode_h */ handle);

        [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_decode_destroy")]
        internal static extern ErrorCode Destroy(IntPtr /* image_util_decode_h */ handle);

        internal ImageColorSpace Colorspace
        {
            set { NativeSet(this.SetColorspace, value); }
        }

        internal JpegDownscale JpegDownscale
        {
            set { NativeSet(this.SetJpegDownscale, value); }
        }

        internal ImageDecoderHandle(IntPtr handle, bool needToRelease) : base(handle, needToRelease)
        {
        }

        internal ImageDecoderHandle() : this(CreateNativeHandle(), true)
        {
        }

        internal static IntPtr CreateNativeHandle()
        {
            IntPtr handle;
            Create(out handle).ThrowIfFailed("Failed to create native handle");
            return handle;
        }

        internal override ErrorCode DisposeNativeHandle()
        {
            return Destroy(handle);
        }
    }
}
