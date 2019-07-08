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
    internal static class ThumbnailExtractor
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void ThumbnailExtractCallback(ThumbnailExtractorError error, string requestId,
            int thumbWidth, int thumbHeight, IntPtr thumbData, int thumbSize, IntPtr userData);

        [DllImport(Libraries.ThumbnailExtractor, EntryPoint = "thumbnail_util_create")]
        internal static extern ThumbnailExtractorError Create(out ThumbnailExtractorHandle handle);

        [DllImport(Libraries.ThumbnailExtractor, EntryPoint = "thumbnail_util_extract")]
        internal static extern ThumbnailExtractorError Extract(ThumbnailExtractorHandle handle,
            ThumbnailExtractCallback callback, IntPtr userData, out IntPtr requestId);

        [DllImport(Libraries.ThumbnailExtractor, EntryPoint = "thumbnail_util_set_path")]
        internal static extern ThumbnailExtractorError SetPath(ThumbnailExtractorHandle handle, string path);

        [DllImport(Libraries.ThumbnailExtractor, EntryPoint = "thumbnail_util_set_size")]
        internal static extern ThumbnailExtractorError SetSize(ThumbnailExtractorHandle handle, int width, int height);


        [DllImport(Libraries.ThumbnailExtractor, EntryPoint = "thumbnail_util_cancel")]
        internal static extern ThumbnailExtractorError Cancel(ThumbnailExtractorHandle handle, string requestId);

        [DllImport(Libraries.ThumbnailExtractor, EntryPoint = "thumbnail_util_destroy")]
        internal static extern ThumbnailExtractorError Destroy(IntPtr handle);

        [DllImport(Libraries.ThumbnailExtractor, EntryPoint = "thumbnail_util_extract_to_buffer")]
        internal static extern ThumbnailExtractorError ExtractToBuffer(string path, uint width, uint height, IntPtr thumbData,
            out int dataSize, out uint thumbWidth, out uint thumbHeight);

        [DllImport(Libraries.ThumbnailExtractor, EntryPoint = "thumbnail_util_extract_to_file")]
        internal static extern ThumbnailExtractorError ExtractToFile(string path, uint width, uint height, string thumbPath);
    }

    internal class ThumbnailExtractorHandle : CriticalHandle
    {
        protected ThumbnailExtractorHandle() : base(IntPtr.Zero)
        {
        }

        public override bool IsInvalid => handle == IntPtr.Zero;

        protected override bool ReleaseHandle()
        {
            var result = ThumbnailExtractor.Destroy(handle);

            if (result == ThumbnailExtractorError.None)
            {
                return true;
            }

            Log.Error(GetType().Name, $"Failed to destroy handle : {result}");
            return false;
        }
    }
}
