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
        internal static partial class Encode
        {
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void EncodeCompletedCallback(ImageUtilError ImageUtilError, IntPtr userData, ulong size);

            [LibraryImport(Libraries.ImageUtil, EntryPoint = "image_util_encode_run_async", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ImageUtilError EncodeRunAsync(ImageEncoderHandle handle,
                EncodeCompletedCallback callback, IntPtr userData = default(IntPtr));

            [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_encode_create")]
            internal static extern ImageUtilError Create(ImageFormat type, out ImageEncoderHandle handle);

            [LibraryImport(Libraries.ImageUtil, EntryPoint = "image_util_encode_destroy", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ImageUtilError Destroy(IntPtr handle);

            [LibraryImport(Libraries.ImageUtil, EntryPoint = "image_util_encode_set_quality", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ImageUtilError SetQuality(ImageEncoderHandle handle, int quality);

            [LibraryImport(Libraries.ImageUtil, EntryPoint = "image_util_encode_set_png_compression", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ImageUtilError SetPngCompression(ImageEncoderHandle handle, PngCompression compression);

            [LibraryImport(Libraries.ImageUtil, EntryPoint = "image_util_encode_run_to_buffer", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ImageUtilError RunToBuffer(ImageEncoderHandle handle, IntPtr imageUtilHandle, out IntPtr buffer, out int size);

            [LibraryImport(Libraries.ImageUtil, EntryPoint = "image_util_encode_set_lossless", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ImageUtilError SetLossless(ImageEncoderHandle handle, [MarshalAs(UnmanagedType.U1)] bool lossless);

            [LibraryImport(Libraries.ImageUtil, EntryPoint = "image_util_anim_encode_create", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ImageUtilError AnimationCreate(AnimationType type, out IntPtr animHandle);

            [LibraryImport(Libraries.ImageUtil, EntryPoint = "image_util_anim_encode_set_loop_count", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ImageUtilError AnimationSetLoopCount(IntPtr animHandle, uint count);

            [LibraryImport(Libraries.ImageUtil, EntryPoint = "image_util_anim_encode_set_background_color", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ImageUtilError AnimationSetBackgroundColor(IntPtr animHandle, byte r, byte g, byte b, byte a);

            [LibraryImport(Libraries.ImageUtil, EntryPoint = "image_util_anim_encode_set_lossless", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ImageUtilError AnimationSetLossless(IntPtr animHandle, [MarshalAs(UnmanagedType.U1)] bool isLossless);

            [LibraryImport(Libraries.ImageUtil, EntryPoint = "image_util_anim_encode_add_frame", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ImageUtilError AnimationAddFrame(IntPtr animHandle, IntPtr utilHandle, uint delayTime);

            [LibraryImport(Libraries.ImageUtil, EntryPoint = "image_util_anim_encode_save_to_file", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ImageUtilError AnimationSaveToFile(IntPtr animHandle, string path);

            [LibraryImport(Libraries.ImageUtil, EntryPoint = "image_util_anim_encode_save_to_buffer", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ImageUtilError AnimationSaveToBuffer(IntPtr animHandle, out IntPtr dstBuffer, out ulong size);

            [LibraryImport(Libraries.ImageUtil, EntryPoint = "image_util_anim_encode_destroy", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ImageUtilError AnimationDestroy(IntPtr animHandle);
        }
    }

    internal partial class ImageEncoderHandle : SafeHandle
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

    internal partial class AgifImageEncoderHandle : SafeHandle
    {
        protected AgifImageEncoderHandle() : base(IntPtr.Zero, true)
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
