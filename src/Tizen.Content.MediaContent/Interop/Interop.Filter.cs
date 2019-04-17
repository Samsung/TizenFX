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
using Tizen.Content.MediaContent;

internal static partial class Interop
{
    internal static partial class Filter
    {
        [DllImport(Libraries.MediaContent, EntryPoint = "media_filter_create")]
        internal static extern MediaContentError Create(out FilterHandle filter);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_filter_destroy")]
        internal static extern MediaContentError Destroy(IntPtr filter);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_filter_set_offset")]
        internal static extern MediaContentError SetOffset(FilterHandle filter, int offset, int count);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_filter_set_condition")]
        internal static extern MediaContentError SetCondition(FilterHandle filter, string condition,
            Collation type);

        [DllImport(Libraries.MediaContent, EntryPoint = "media_filter_set_order_v2")]
        internal static extern MediaContentError SetOrder(FilterHandle filter, string orderExpression);

        // Please do not use! The public API related this will be deprecated in level 6
        [DllImport(Libraries.MediaContent, EntryPoint = "media_filter_set_storage")]
        internal static extern MediaContentError SetStorage(FilterHandle filter, string storageId);
    }

    internal class FilterHandle : MediaContentCriticalHandle
    {
        public static readonly FilterHandle Null = new FilterHandle();

        protected override MediaContentError DestroyHandle()
        {
            return Filter.Destroy(handle);
        }
    }
}
