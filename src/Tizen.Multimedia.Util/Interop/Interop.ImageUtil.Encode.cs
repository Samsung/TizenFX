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

            [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_encode_set_quality")]
            internal static extern ImageUtilError SetQuality(ImageEncoderHandle handle, int quality);

            [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_encode_set_png_compression")]
            internal static extern ImageUtilError SetPngCompression(ImageEncoderHandle handle, PngCompression compression);

            [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_encode_run_to_buffer")]
            internal static extern ImageUtilError RunToBuffer(ImageEncoderHandle handle, IntPtr imageUtilHandle, out IntPtr buffer, out int size);

            [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_encode_set_lossless")]
            internal static extern ImageUtilError SetLossless(ImageEncoderHandle handle, bool lossless);

            [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_anim_encode_create")]
            internal static extern ImageUtilError AnimationCreate(AnimationType type, out IntPtr animHandle);

            [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_anim_encode_set_loop_count")]
            internal static extern ImageUtilError AnimationSetLoopCount(IntPtr animHandle, uint count);

            [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_anim_encode_set_background_color")]
            internal static extern ImageUtilError AnimationSetBackgroundColor(IntPtr animHandle, byte r, byte g, byte b, byte a);

            [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_anim_encode_set_lossless")]
            internal static extern ImageUtilError AnimationSetLossless(IntPtr animHandle, bool isLossless);

            [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_anim_encode_add_frame")]
            internal static extern ImageUtilError AnimationAddFrame(IntPtr animHandle, IntPtr utilHandle, uint delayTime);

            [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_anim_encode_save_to_file")]
            internal static extern ImageUtilError AnimationSaveToFile(IntPtr animHandle, string path);

            [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_anim_encode_save_to_buffer")]
            internal static extern ImageUtilError AnimationSaveToBuffer(IntPtr animHandle, out IntPtr dstBuffer, out ulong size);

            [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_anim_encode_destroy")]
            internal static extern ImageUtilError AnimationDestroy(IntPtr animHandle);
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

    internal class AgifImageEncoderHandle : SafeHandle
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
