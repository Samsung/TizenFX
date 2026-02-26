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
        internal static partial class Transform
        {
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void TransformCompletedCallback(IntPtr resultPacket, ImageUtilError errorCode,
                IntPtr userData = default(IntPtr));

            [LibraryImport(Libraries.ImageUtil, EntryPoint = "image_util_transform_run", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ImageUtilError Run(TransformHandle handle, IntPtr srcPacket,
                TransformCompletedCallback callback, IntPtr userData = default(IntPtr));

            [DllImport(Libraries.ImageUtil, EntryPoint = "image_util_transform_create")]
            internal static extern ImageUtilError Create(out TransformHandle handle);

            [LibraryImport(Libraries.ImageUtil, EntryPoint = "image_util_transform_destroy", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ImageUtilError Destroy(IntPtr handle);

            [LibraryImport(Libraries.ImageUtil, EntryPoint = "image_util_transform_get_colorspace", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ImageUtilError GetColorspace(TransformHandle handle, out ImageColorSpace colorspace);

            [LibraryImport(Libraries.ImageUtil, EntryPoint = "image_util_transform_set_colorspace", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ImageUtilError SetColorspace(TransformHandle handle, ImageColorSpace colorspace);

            [LibraryImport(Libraries.ImageUtil, EntryPoint = "image_util_transform_set_rotation", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ImageUtilError SetRotation(TransformHandle handle, ImageRotation rotation);

            [LibraryImport(Libraries.ImageUtil, EntryPoint = "image_util_transform_get_crop_area", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ImageUtilError GetCropArea(TransformHandle handle, out uint startX, out uint startY, out uint endX, out uint endY);

            [LibraryImport(Libraries.ImageUtil, EntryPoint = "image_util_transform_set_crop_area", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ImageUtilError SetCropArea(TransformHandle handle, int startX, int startY, int endX, int endY);

            [LibraryImport(Libraries.ImageUtil, EntryPoint = "image_util_transform_get_resolution", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ImageUtilError GetResolution(TransformHandle handle, out uint width, out uint height);

            [LibraryImport(Libraries.ImageUtil, EntryPoint = "image_util_transform_set_resolution", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial ImageUtilError SetResolution(TransformHandle handle, uint width, uint height);
        }
    }

    internal partial class TransformHandle : SafeHandle
    {
        protected TransformHandle() : base(IntPtr.Zero, true)
        {
        }

        public override bool IsInvalid => handle == IntPtr.Zero;

        protected override bool ReleaseHandle()
        {
            var ret = ImageUtil.Transform.Destroy(handle);
            if (ret != ImageUtilError.None)
            {
                Log.Debug(GetType().FullName, $"Failed to release native {GetType().Name}");
                return false;
            }

            return true;
        }
    }
}
