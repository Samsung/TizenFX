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
using static Interop.StickerData;
using Tizen.Uix.Sticker;

/// <summary>
/// Partial Interop Class
/// </summary>
internal static partial class Interop
{
    /// <summary>
    /// StickerProvider Interop Class
    /// </summary>
    internal static class StickerProvider
    {
        [DllImport(Libraries.StickerProvider, EntryPoint = "sticker_provider_create")]
        internal static extern ErrorCode StickerProviderCreate(out IntPtr stickerProvider);

        [DllImport(Libraries.StickerProvider, EntryPoint = "sticker_provider_destroy")]
        internal static extern ErrorCode StickerProviderDestroy(IntPtr stickerProvider);

        [DllImport(Libraries.StickerProvider, EntryPoint = "sticker_provider_insert_data")]
        internal static extern ErrorCode StickerProviderInsertData(IntPtr stickerProvider, SafeStickerDataHandle stickerData);

        [DllImport(Libraries.StickerProvider, EntryPoint = "sticker_provider_insert_data_by_json_file")]
        internal static extern ErrorCode StickerProviderInsertDataByJsonFile(IntPtr stickerProvider, string jsonPath, StickerProviderInsertFinishedCallback callback, IntPtr userData);

        [DllImport(Libraries.StickerProvider, EntryPoint = "sticker_provider_update_data")]
        internal static extern ErrorCode StickerProviderUpdateData(IntPtr stickerProvider, SafeStickerDataHandle stickerData);

        [DllImport(Libraries.StickerProvider, EntryPoint = "sticker_provider_delete_data")]
        internal static extern ErrorCode StickerProviderDeleteData(IntPtr stickerProvider, SafeStickerDataHandle stickerData);

        [DllImport(Libraries.StickerProvider, EntryPoint = "sticker_provider_delete_data_by_uri")]
        internal static extern ErrorCode StickerProviderDeleteDataByUri(IntPtr stickerProvider, string uri);

        [DllImport(Libraries.StickerProvider, EntryPoint = "sticker_provider_get_sticker_count")]
        internal static extern ErrorCode StickerProviderGetStickerCount(IntPtr stickerProvider, out int count);

        [DllImport(Libraries.StickerProvider, EntryPoint = "sticker_provider_data_foreach_all")]
        internal static extern ErrorCode StickerProviderDataForeachAll(IntPtr stickerProvider, int offset, int count, out int result, StickerProviderDataForeachCallback callback, IntPtr userData);

        [DllImport(Libraries.StickerProvider, EntryPoint = "sticker_provider_set_group_image")]
        internal static extern ErrorCode StickerProviderSetGroupImage(IntPtr stickerProvider, string group, UriType uriType, string uri);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void StickerProviderDataForeachCallback(IntPtr stickerData, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void StickerProviderInsertFinishedCallback(ErrorCode error, IntPtr userData);
    }
}