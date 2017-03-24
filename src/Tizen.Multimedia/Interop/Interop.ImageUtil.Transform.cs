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

namespace Tizen.Multimedia
{
    internal static partial class Interop
    {
        [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_transform_set_hardware_acceleration")]
        internal static extern ErrorCode SetHardwareAcceleration(this ImageTransformHandle /* transformation_h */ handle, bool mode);

        [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_transform_get_colorspace")]
        internal static extern ErrorCode GetColorspace(this ImageTransformHandle /* transformation_h */ handle, out ImageColorSpace /* image_util_colorspace_e */ colorspace);

        [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_transform_set_colorspace")]
        internal static extern ErrorCode SetColorspace(this ImageTransformHandle /* transformation_h */ handle, ImageColorSpace /* image_util_colorspace_e */ colorspace);

        [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_transform_get_rotation")]
        internal static extern ErrorCode GetRotation(this ImageTransformHandle /* transformation_h */ handle, out ImageRotation /* image_util_rotation_e */ rotation);

        [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_transform_set_rotation")]
        internal static extern ErrorCode SetRotation(this ImageTransformHandle /* transformation_h */ handle, ImageRotation /* image_util_rotation_e */ rotation);

        [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_transform_get_resolution")]
        internal static extern ErrorCode GetResolution(this ImageTransformHandle /* transformation_h */ handle, out uint width, out uint height);

        [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_transform_set_resolution")]
        internal static extern ErrorCode SetResolution(this ImageTransformHandle /* transformation_h */ handle, uint width, uint height);

        [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_transform_get_crop_area")]
        internal static extern ErrorCode GetCropArea(this ImageTransformHandle /* transformation_h */ handle, out uint startX, out uint startY, out uint endX, out uint endY);

        [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_transform_set_crop_area")]
        internal static extern ErrorCode SetCropArea(this ImageTransformHandle /* transformation_h */ handle, int startX, int startY, int endX, int endY);

        internal class ImageTransformHandle : SafeMultimediaHandle
        {
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void TransformCompletedCallback(IntPtr /* media_packet_h */ dst, ErrorCode errorCode, IntPtr /* void */ userData);

            [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_transform_run")]
            internal static extern ErrorCode Transform(ImageTransformHandle /* transformation_h */ handle, IntPtr /* media_packet_h */ src, TransformCompletedCallback callback, IntPtr /* void */ userData);


            [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_transform_create")]
            internal static extern ErrorCode Create(out IntPtr /* transformation_h */ handle);

            [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_transform_destroy")]
            internal static extern ErrorCode Destroy(IntPtr /* transformation_h */ handle);

            internal ImageTransformHandle(IntPtr handle, bool needToRelease) : base(handle, needToRelease)
            {
            }

            internal ImageTransformHandle() : this(CreateNativeHandle(), true)
            {
            }

            internal bool HardwareAccelerationEnabled
            {
                set { NativeSet(this.SetHardwareAcceleration, value); }
            }

            internal ImageColorSpace Colorspace
            {
                get { return NativeGet<ImageColorSpace>(this.GetColorspace); }
                set { NativeSet(this.SetColorspace, value); }
            }

            internal ImageRotation Rotation
            {
                get { return NativeGet<ImageRotation>(this.GetRotation); }
                set { NativeSet(this.SetRotation, value); }
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
}