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
    // Image Encoder
    [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_encode_set_resolution")]
    internal static extern ErrorCode SetResolution(this ImageEncoderHandle /* image_util_encode_h */ handle, uint width, uint height);

    [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_encode_set_colorspace")]
    internal static extern ErrorCode SetColorspace(this ImageEncoderHandle /* image_util_encode_h */ handle, ImageColorSpace /* image_util_colorspace_e */ colorspace);

    [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_encode_set_quality")]
    internal static extern ErrorCode SetQuality(this ImageEncoderHandle /* image_util_encode_h */ handle, int quality);

    [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_encode_set_png_compression")]
    internal static extern ErrorCode SetPngCompression(this ImageEncoderHandle /* image_util_encode_h */ handle, PngCompression /* image_util_png_compression_e */ compression);

    [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_encode_set_gif_frame_delay_time")]
    internal static extern ErrorCode SetGifFrameDelayTime(this ImageEncoderHandle /* image_util_encode_h */ handle, ulong delayTime);

    [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_encode_set_output_path")]
    internal static extern ErrorCode SetOutputPath(this ImageEncoderHandle /* image_util_encode_h */ handle, string path);

    [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_encode_set_input_buffer")]
    internal static extern ErrorCode SetInputBuffer(this ImageEncoderHandle /* image_util_encode_h */ handle, byte[] srcBuffer);

    [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_encode_set_output_buffer")]
    internal static extern ErrorCode SetOutputBuffer(this ImageEncoderHandle /* image_util_encode_h */ handle, out IntPtr dstBuffer);

    [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_encode_run")]
    internal static extern ErrorCode EncodeRun(this ImageEncoderHandle /* image_util_encode_h */ handle, out ulong size);

    internal class ImageEncoderHandle : SafeMultimediaHandle
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void EncodeCompletedCallback(ErrorCode errorCode, IntPtr /* void */ userData, ulong size);

        [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_encode_run_async")]
        internal static extern ErrorCode EncodeRunAsync(ImageEncoderHandle /* image_util_encode_h */ handle, EncodeCompletedCallback callback, IntPtr /* void */ userData);


        [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_encode_create")]
        internal static extern ErrorCode Create(ImageType /* image_util_type_e */ type, out IntPtr /* image_util_encode_h */ handle);

        [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_encode_destroy")]
        internal static extern ErrorCode Destroy(IntPtr /* image_util_encode_h */ handle);

        internal ImageEncoderHandle(IntPtr handle, bool needToRelease) : base(handle, needToRelease)
        {
        }

        internal ImageEncoderHandle(ImageType type) : this(CreateNativeHandle(type), true)
        {
        }

        internal ImageColorSpace Colorspace
        {
            set { NativeSet(this.SetColorspace, value); }
        }

        internal int Quality
        {
            set { NativeSet(this.SetQuality, value); }
        }

        internal PngCompression PngCompression
        {
            set { NativeSet(this.SetPngCompression, value); }
        }

        internal ulong GifFrameDelay
        {
            set { NativeSet(this.SetGifFrameDelayTime, value); }
        }

        internal string OutputPath
        {
            set { NativeSet(this.SetOutputPath, value); }
        }

        internal byte[] InputBuffer
        {
            set { NativeSet(this.SetInputBuffer, value); }
        }

        internal static IntPtr CreateNativeHandle(ImageType type)
        {
            IntPtr handle;
            Create(type, out handle).ThrowIfFailed("Failed to create native handle");
            return handle;
        }

        internal override ErrorCode DisposeNativeHandle()
        {
            return Destroy(handle);
        }
    }
}
