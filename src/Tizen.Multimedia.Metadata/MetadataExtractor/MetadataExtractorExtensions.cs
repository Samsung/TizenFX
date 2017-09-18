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
using System.Diagnostics;
using System.Runtime.InteropServices;
using Native = Interop.MetadataExtractor;
using static Interop;

namespace Tizen.Multimedia
{
    internal static class MetadataExtractorExtensions
    {
        internal static string GetMetadata(this MetadataExtractor extractor, MetadataExtractorAttr attr)
        {
            Debug.Assert(extractor != null);

            IntPtr valuePtr = IntPtr.Zero;

            try
            {
                var ret = Native.GetMetadata(extractor.Handle, attr, out valuePtr);
                MetadataExtractorRetValidator.ThrowIfError(ret, "Failed to get value for " + attr);
                return Marshal.PtrToStringAnsi(valuePtr);
            }
            finally
            {
                Libc.Free(valuePtr);
            }
        }

    }
}