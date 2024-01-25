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
    /// StickerConsumer Interop Class
    /// </summary>
    internal static class StickerConsumer
    {
        [DllImport(Libraries.StickerConsumer, EntryPoint = "sticker_consumer_create")]
        internal static extern ErrorCode StickerConsumerCreate(out IntPtr stickerConsumer);

        [DllImport(Libraries.StickerConsumer, EntryPoint = "sticker_consumer_destroy")]
        internal static extern ErrorCode StickerConsumerDestroy(IntPtr stickerConsumer);

        [DllImport(Libraries.StickerConsumer, EntryPoint = "sticker_consumer_data_foreach_all")]
        internal static extern ErrorCode StickerConsumerDataForeachAll(IntPtr stickerConsumer, int offset, int count, out int result, StickerConsumerDataForeachCallback callback, IntPtr userData);

        [DllImport(Libraries.StickerConsumer, EntryPoint = "sticker_consumer_data_foreach_by_keyword")]
        internal static extern ErrorCode StickerConsumerDataForeachByKeyword(IntPtr stickerConsumer, int offset, int count, out int result, string keyword, StickerConsumerDataForeachCallback callback, IntPtr userData);

        [DllImport(Libraries.StickerConsumer, EntryPoint = "sticker_consumer_data_foreach_by_group")]
        internal static extern ErrorCode StickerConsumerDataForeachByGroup(IntPtr stickerConsumer, int offset, int count, out int result, string group, StickerConsumerDataForeachCallback callback, IntPtr userData);

        [DllImport(Libraries.StickerConsumer, EntryPoint = "sticker_consumer_data_foreach_by_type")]
        internal static extern ErrorCode StickerConsumerDataForeachByType(IntPtr stickerConsumer, int offset, int count, out int result, UriType uriType, StickerConsumerDataForeachCallback callback, IntPtr userData);

        [DllImport(Libraries.StickerConsumer, EntryPoint = "sticker_consumer_group_list_foreach_all")]
        internal static extern ErrorCode StickerConsumerGroupListForeachAll(IntPtr stickerConsumer, StickerConsumerGroupListForeachCallback callback, IntPtr userData);

        [DllImport(Libraries.StickerConsumer, EntryPoint = "sticker_consumer_keyword_list_foreach_all")]
        internal static extern ErrorCode StickerConsumerKeywordListForeachAll(IntPtr stickerConsumer, StickerConsumerKeywordListForeachCallback callback, IntPtr userData);

        [DllImport(Libraries.StickerConsumer, EntryPoint = "sticker_consumer_data_foreach_by_display_type")]
        internal static extern ErrorCode StickerConsumerDataForeachByDisplayType(IntPtr stickerConsumer, int offset, int count, out int result, DisplayType type, StickerConsumerDataForeachCallback callback, IntPtr userData);

        [DllImport(Libraries.StickerConsumer, EntryPoint = "sticker_consumer_group_list_foreach_by_display_type")]
        internal static extern ErrorCode StickerConsumerGroupListForeachByDisplayType(IntPtr stickerConsumer, DisplayType type, StickerConsumerGroupListForeachCallback callback, IntPtr userData);

        [DllImport(Libraries.StickerConsumer, EntryPoint = "sticker_consumer_add_recent_data")]
        internal static extern ErrorCode StickerConsumerAddRecentData(IntPtr stickerConsumer, SafeStickerDataHandle stickerData);

        [DllImport(Libraries.StickerConsumer, EntryPoint = "sticker_consumer_get_recent_data_list")]
        internal static extern ErrorCode StickerConsumerGetRecentDataList(IntPtr stickerConsumer, int count, out int result, StickerConsumerDataForeachCallback callback, IntPtr userData);

        [DllImport(Libraries.StickerConsumer, EntryPoint = "sticker_consumer_set_event_cb")]
        internal static extern ErrorCode StickerConsumerSetEventCB(IntPtr stickerConsumer, StickerConsumerEventCallback callback, IntPtr userData);

        [DllImport(Libraries.StickerConsumer, EntryPoint = "sticker_consumer_unset_event_cb")]
        internal static extern ErrorCode StickerConsumerUnsetEventCB(IntPtr stickerConsumer);

        [DllImport(Libraries.StickerConsumer, EntryPoint = "sticker_consumer_group_image_list_foreach_all")]
        internal static extern ErrorCode StickerConsumerGroupImageListForeachAll(IntPtr stickerConsumer, StickerConsumerGroupImageListForeachCallback callback, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void StickerConsumerDataForeachCallback(IntPtr stickerData, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void StickerConsumerGroupListForeachCallback(IntPtr group, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void StickerConsumerKeywordListForeachCallback(IntPtr keyword, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void StickerConsumerEventCallback(EventType type, IntPtr stickerData, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void StickerConsumerGroupImageListForeachCallback(IntPtr group, UriType type, IntPtr uri, IntPtr userData);
    }
}