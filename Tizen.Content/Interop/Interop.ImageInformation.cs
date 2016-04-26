/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc.("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.


using System;
using System.Runtime.InteropServices;
using Tizen.Content.MediaContent;

internal static partial class Interop
{
    internal static partial class ImageInformation
    {
        [DllImport(Libraries.MediaContent, EntryPoint = "image_meta_destroy", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Destroy(IntPtr media);

        [DllImport(Libraries.MediaContent, EntryPoint = "image_meta_clone", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Clone(out SafeImageInformationHandle dst, SafeImageInformationHandle src);

        [DllImport(Libraries.MediaContent, EntryPoint = "image_meta_get_orientation", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetOrientation(SafeImageInformationHandle imageInformationHandle, out MediaContentOrientation orientation);

        [DllImport(Libraries.MediaContent, EntryPoint = "image_meta_get_date_taken", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetDateTaken(SafeImageInformationHandle imageInformationHandle, out string dateTaken);

        [DllImport(Libraries.MediaContent, EntryPoint = "image_meta_get_burst_id", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetBurstId(SafeImageInformationHandle imageInformationHandle, out string burstId);

        [DllImport(Libraries.MediaContent, EntryPoint = "image_meta_get_exposure_time", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetExposureTime(SafeImageInformationHandle imageInformationHandle, out string exposureTime);

        [DllImport(Libraries.MediaContent, EntryPoint = "image_meta_get_fnumber", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetFNumber(SafeImageInformationHandle imageInformationHandle, out double fNumber);

        [DllImport(Libraries.MediaContent, EntryPoint = "image_meta_get_iso", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetISO(SafeImageInformationHandle imageInformationHandle, out int iso);

        [DllImport(Libraries.MediaContent, EntryPoint = "image_meta_get_model", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetModel(SafeImageInformationHandle imageInformationHandle, out string model);

        [DllImport(Libraries.MediaContent, EntryPoint = "image_meta_is_burst_shot", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int IsBurstShot(SafeImageInformationHandle imageInformationHandle, out bool isBurstShot);

        [DllImport(Libraries.MediaContent, EntryPoint = "image_meta_set_orientation", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetOrientation(SafeImageInformationHandle imageInformationHandle, MediaContentOrientation orientation);

        [DllImport(Libraries.MediaContent, EntryPoint = "image_meta_get_media_id", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetMediaId(SafeImageInformationHandle imageInformationHandle, out string mediaId);

        [DllImport(Libraries.MediaContent, EntryPoint = "image_meta_get_width", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetWidth(SafeImageInformationHandle imageInformationHandle, out int width);

        [DllImport(Libraries.MediaContent, EntryPoint = "image_meta_get_height", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetHeight(SafeImageInformationHandle imageInformationHandle, out int width);

        [DllImport(Libraries.MediaContent, EntryPoint = "image_meta_update_to_db", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int UpdateToDB(SafeImageInformationHandle imageInformationHandle);

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
                Tizen.Log.Info(Globals.LogTag, "SafeImageInformationHandle::ReleaseHandle called");
                ImageInformation.Destroy(this.handle);
                this.SetHandle(IntPtr.Zero);
                return true;
            }
        }
    }
}