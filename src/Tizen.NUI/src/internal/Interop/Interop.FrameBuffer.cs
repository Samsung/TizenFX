/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using global::System;
using global::System.Runtime.InteropServices;
using global::System.Runtime.InteropServices.Marshalling;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class FrameBuffer
        {

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameBuffer_New", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New(uint jarg1, uint jarg2, uint jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_FrameBuffer", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteFrameBuffer(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameBuffer_AttachColorTexture__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AttachColorTexture(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameBuffer_AttachColorTexture__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AttachColorTexture(IntPtr jarg1, IntPtr jarg2, uint jarg3, uint jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameBuffer_AttachDepthTexture", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AttachDepthTexture(IntPtr frameBuffer, IntPtr depthTexture, uint mipmapLevel);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameBuffer_GetColorTexture", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetColorTexture(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameBuffer_GetColorTexture_Index", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetColorTextureByIndex(IntPtr frameBuffer, uint index);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameBuffer_GetDepthTexture", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetDepthTexture(IntPtr frameBuffer);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameBuffer_GenerateUrl", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GenerateUrl(global::System.IntPtr frameBuffer, int pixelFormat, int width, int height);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameBuffer_GenerateUrl_Index", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GenerateUrlByIndex(global::System.IntPtr frameBuffer, uint index);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameBuffer_GenerateDepthUrl", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GenerateDepthUrl(global::System.IntPtr frameBuffer);
        }
    }
}





