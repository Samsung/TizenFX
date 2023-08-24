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
using Tizen.Multimedia.Util;

internal static partial class Interop
{
    internal static class ThumbnailExtractor
    {
        [DllImport(Libraries.ThumbnailExtractor, EntryPoint = "thumbnail_util_extract_to_buffer")]
        internal static extern ThumbnailExtractorError ExtractToBuffer(string path, uint width, uint height, out IntPtr thumbData,
            out int dataSize, out uint thumbWidth, out uint thumbHeight);

        [DllImport(Libraries.ThumbnailExtractor, EntryPoint = "thumbnail_util_extract_to_file")]
        internal static extern ThumbnailExtractorError ExtractToFile(string path, uint width, uint height, string thumbPath);
    }
}
