/*
* Copyright (c) 2022 Samsung Electronics Co., Ltd All Rights Reserved
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
using Tizen.Uix.Sticker;

/// <summary>
/// Partial Interop Class
/// </summary>
internal static partial class Interop
{    
    /// <summary>
    /// StickerData Interop Class
    /// </summary>
    internal static class StickerData
    {
        internal static string LogTag = "Tizen.Uix.Sticker";
        internal enum ErrorCode
        {
            None = Tizen.Internals.Errors.ErrorCode.None,                          /* Successful */
            NotSupported = Tizen.Internals.Errors.ErrorCode.NotSupported,          /* Sticker NOT supported */
            PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied,  /* Permission denied */
            InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,  /* Invalid parameter */
            OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,            /* Out of Memory */
            OperationFailed = -0x03050000 | 0x0001,         /* Operation failed */
            FileExists = Tizen.Internals.Errors.ErrorCode.FileExists,              /* File exists */
            NoData = Tizen.Internals.Errors.ErrorCode.NoData,                      /* No data available */
            NoSuchFile = Tizen.Internals.Errors.ErrorCode.NoSuchFile,              /* No such file */
        };

        [DllImport(Libraries.StickerProvider, EntryPoint = "sticker_data_create")]
        internal static extern ErrorCode StickerDataCreate(out SafeStickerDataHandle stickerData);

        [DllImport(Libraries.StickerProvider, EntryPoint = "sticker_data_destroy")]
        internal static extern ErrorCode StickerDataDestroy(IntPtr stickerData);

        [DllImport(Libraries.StickerProvider, EntryPoint = "sticker_data_clone")]
        internal static extern ErrorCode StickerDataClone(IntPtr originData, out IntPtr targetData);

        [DllImport(Libraries.StickerProvider, EntryPoint = "sticker_data_get_handle")]
        internal static extern ErrorCode StickerDataGetHandle(string uri, out IntPtr stickerData);

        [DllImport(Libraries.StickerProvider, EntryPoint = "sticker_data_get_app_id")]
        internal static extern ErrorCode StickerDataGetAppId(SafeStickerDataHandle stickerData, out string appId);

        [DllImport(Libraries.StickerProvider, EntryPoint = "sticker_data_set_uri")]
        internal static extern ErrorCode StickerDataSetUri(SafeStickerDataHandle stickerData, UriType uriType, string uri);

        [DllImport(Libraries.StickerProvider, EntryPoint = "sticker_data_get_uri")]
        internal static extern ErrorCode StickerDataGetUri(SafeStickerDataHandle stickerData, out UriType uriType, out string uri);

        [DllImport(Libraries.StickerProvider, EntryPoint = "sticker_data_foreach_keyword")]
        internal static extern ErrorCode StickerDataForeachKeyword(SafeStickerDataHandle stickerData, StickerDataKeywordForeachCallback callback, IntPtr userData);

        [DllImport(Libraries.StickerProvider, EntryPoint = "sticker_data_add_keyword")]
        internal static extern ErrorCode StickerDataAddKeyword(SafeStickerDataHandle stickerData, string keyword);

        [DllImport(Libraries.StickerProvider, EntryPoint = "sticker_data_remove_keyword")]
        internal static extern ErrorCode StickerDataRemoveKeyword(SafeStickerDataHandle stickerData, string keyword);

        [DllImport(Libraries.StickerProvider, EntryPoint = "sticker_data_set_group_name")]
        internal static extern ErrorCode StickerDataSetGroupName(SafeStickerDataHandle stickerData, string group);

        [DllImport(Libraries.StickerProvider, EntryPoint = "sticker_data_get_group_name")]
        internal static extern ErrorCode StickerDataGetGroupName(SafeStickerDataHandle stickerData, out string group);

        [DllImport(Libraries.StickerProvider, EntryPoint = "sticker_data_set_thumbnail")]
        internal static extern ErrorCode StickerDataSetThumbnail(SafeStickerDataHandle stickerData, string thumbnail);

        [DllImport(Libraries.StickerProvider, EntryPoint = "sticker_data_get_thumbnail")]
        internal static extern ErrorCode StickerDataGetThumbnail(SafeStickerDataHandle stickerData, out string thumbnail);

        [DllImport(Libraries.StickerProvider, EntryPoint = "sticker_data_set_description")]
        internal static extern ErrorCode StickerDataSetDescription(SafeStickerDataHandle stickerData, string description);

        [DllImport(Libraries.StickerProvider, EntryPoint = "sticker_data_get_description")]
        internal static extern ErrorCode StickerDataGetDescription(SafeStickerDataHandle stickerData, out string description);

        [DllImport(Libraries.StickerProvider, EntryPoint = "sticker_data_get_date")]
        internal static extern ErrorCode StickerDataGetDate(SafeStickerDataHandle stickerData, out string date);

        [DllImport(Libraries.StickerProvider, EntryPoint = "sticker_data_set_display_type")]
        internal static extern ErrorCode StickerDataSetDisplayType(SafeStickerDataHandle stickerData, DisplayType type);

        [DllImport(Libraries.StickerProvider, EntryPoint = "sticker_data_get_display_type")]
        internal static extern ErrorCode StickerDataGetDisplayType(SafeStickerDataHandle stickerData, out DisplayType type);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void StickerDataKeywordForeachCallback(string keyword, IntPtr userData);

        internal sealed class SafeStickerDataHandle : SafeHandle
        {
            public SafeStickerDataHandle(IntPtr handle)
                : base(IntPtr.Zero, true)
            {
                SetHandle(handle);
            }

            public SafeStickerDataHandle()
                : base(IntPtr.Zero, true)
            {
            }

            public override bool IsInvalid
            {
                get { return this.handle == IntPtr.Zero; }
            }

            protected override bool ReleaseHandle()
            {
                if (!IsInvalid)
                {
                    ErrorCode error = StickerDataDestroy(this.handle);
                    if (error != ErrorCode.None)
                    {
                        Log.Error(LogTag, "Destroy Failed with error " + error);
                    }
                }
                this.SetHandle(IntPtr.Zero);
                return true;
            }
        }
    }
}