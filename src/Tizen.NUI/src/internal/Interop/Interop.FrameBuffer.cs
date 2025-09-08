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

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class FrameBuffer
        {

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameBuffer_New")]
            public static extern global::System.IntPtr New(uint jarg1, uint jarg2, uint jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_FrameBuffer")]
            public static extern void DeleteFrameBuffer(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameBuffer_AttachColorTexture__SWIG_0")]
            public static extern void AttachColorTexture(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameBuffer_AttachColorTexture__SWIG_1")]
            public static extern void AttachColorTexture(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, uint jarg3, uint jarg4);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameBuffer_AttachDepthTexture")]
            public static extern void AttachDepthTexture(global::System.Runtime.InteropServices.HandleRef frameBuffer, global::System.Runtime.InteropServices.HandleRef depthTexture, uint mipmapLevel);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameBuffer_GetColorTexture")]
            public static extern global::System.IntPtr GetColorTexture(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameBuffer_GetColorTexture_Index")]
            public static extern global::System.IntPtr GetColorTextureByIndex(global::System.Runtime.InteropServices.HandleRef frameBuffer, uint index);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameBuffer_GetDepthTexture")]
            public static extern global::System.IntPtr GetDepthTexture(global::System.Runtime.InteropServices.HandleRef frameBuffer);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameBuffer_GenerateUrl")]
            public static extern global::System.IntPtr GenerateUrl(global::System.IntPtr frameBuffer, int pixelFormat, int width, int height);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameBuffer_GenerateUrl_Index")]
            public static extern global::System.IntPtr GenerateUrlByIndex(global::System.IntPtr frameBuffer, uint index);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameBuffer_GenerateDepthUrl")]
            public static extern global::System.IntPtr GenerateDepthUrl(global::System.IntPtr frameBuffer);
        }
    }
}
