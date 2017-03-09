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
using Tizen.Content.MediaContent;

internal static partial class Interop
{
    internal static partial class ImageInformation
    {
        [DllImport(Libraries.MediaContent, EntryPoint = "image_meta_destroy", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError Destroy(IntPtr media);

        [DllImport(Libraries.MediaContent, EntryPoint = "image_meta_clone", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError Clone(out SafeImageInformationHandle dst, SafeImageInformationHandle src);

        [DllImport(Libraries.MediaContent, EntryPoint = "image_meta_get_orientation", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetOrientation(SafeImageInformationHandle imageInformationHandle, out MediaContentOrientation orientation);

        [DllImport(Libraries.MediaContent, EntryPoint = "image_meta_get_date_taken", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetDateTaken(SafeImageInformationHandle imageInformationHandle, out IntPtr dateTaken);

        [DllImport(Libraries.MediaContent, EntryPoint = "image_meta_get_burst_id", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetBurstId(SafeImageInformationHandle imageInformationHandle, out IntPtr burstId);

        [DllImport(Libraries.MediaContent, EntryPoint = "image_meta_get_exposure_time", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetExposureTime(SafeImageInformationHandle imageInformationHandle, out IntPtr exposureTime);

        [DllImport(Libraries.MediaContent, EntryPoint = "image_meta_get_fnumber", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetFNumber(SafeImageInformationHandle imageInformationHandle, out double fNumber);

        [DllImport(Libraries.MediaContent, EntryPoint = "image_meta_get_iso", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetISO(SafeImageInformationHandle imageInformationHandle, out int iso);

        [DllImport(Libraries.MediaContent, EntryPoint = "image_meta_get_model", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetModel(SafeImageInformationHandle imageInformationHandle, out IntPtr model);

        [DllImport(Libraries.MediaContent, EntryPoint = "image_meta_is_burst_shot", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError IsBurstShot(SafeImageInformationHandle imageInformationHandle, out bool isBurstShot);

        [DllImport(Libraries.MediaContent, EntryPoint = "image_meta_set_orientation", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError SetOrientation(SafeImageInformationHandle imageInformationHandle, MediaContentOrientation orientation);

        [DllImport(Libraries.MediaContent, EntryPoint = "image_meta_get_media_id", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetMediaId(SafeImageInformationHandle imageInformationHandle, out IntPtr mediaId);

        [DllImport(Libraries.MediaContent, EntryPoint = "image_meta_get_width", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetWidth(SafeImageInformationHandle imageInformationHandle, out int width);

        [DllImport(Libraries.MediaContent, EntryPoint = "image_meta_get_height", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError GetHeight(SafeImageInformationHandle imageInformationHandle, out int width);

        [DllImport(Libraries.MediaContent, EntryPoint = "image_meta_update_to_db", CallingConvention = CallingConvention.Cdecl)]
        internal static extern MediaContentError UpdateToDB(IntPtr imageInformationHandle);

        internal sealed class SafeImageInformationHandle : SafeHandle
        {
            public SafeImageInformationHandle()
                : base(IntPtr.Zero, true)
            {
            }

            public override bool IsInvalid
            {
                get { return this.handle == IntPtr.Zero; }
            }

            protected override bool ReleaseHandle()
            {
                ImageInformation.Destroy(this.handle);
                this.SetHandle(IntPtr.Zero);
                return true;
            }
        }
    }
}
