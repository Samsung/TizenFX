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
        internal static partial class GLView
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlView_New_SWIG", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New(int nuiColorFormat);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlView_New2_SWIG", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New(int backendMode, int nuiColorFormat);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlView_RegisterGlCallbacks", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GlViewRegisterGlCallbacks(IntPtr nuiGlView, IntPtr nuiInitCB, IntPtr nuiRenderFrameCB, IntPtr nuiTerminateCB);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlView_SetResizeCallback", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GlViewSetResizeCallback(IntPtr nuiGlView, IntPtr nuiResizeCB);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlView_SetGraphicsConfig", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool GlViewSetGraphicsConfig(IntPtr nuiGlView, [MarshalAs(UnmanagedType.U1)] bool nuiDepth, [MarshalAs(UnmanagedType.U1)] bool nuiStencil, int nuiMsaa, int nuiVersion);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlView_SetRenderingMode", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GlViewSetRenderingMode(IntPtr nuiGlView, int nuiRenderingMode);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlView_GetRenderingMode", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GlViewGetRenderingMode(IntPtr nuiGlView);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlView_RenderOnce", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GlViewRenderOnce(IntPtr nuiGlView);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlView_Terminate", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GlViewTerminate(IntPtr nuiGlView);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlView_BindTextureResources", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GlViewBindTextureResources(IntPtr nuiGlView, global::System.IntPtr textures, int size);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderCallbackInput_Size_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GlViewGetRednerCallbackInputSize(global::System.IntPtr renderInput);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderCallbackInput_Mvp_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GlViewGetRednerCallbackInputMvp(global::System.IntPtr renderInput);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderCallbackInput_Projection_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GlViewGetRednerCallbackInputProjection(global::System.IntPtr renderInput);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderCallbackInput_ClippingBox_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GlViewGetRednerCallbackInputClipplingBox(global::System.IntPtr renderInput);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderCallbackInput_TextureBindings_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GlViewGetRednerCallbackInputTextureBindings(global::System.IntPtr renderInput, ref int size);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderCallbackInput_WorldColor_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GlViewGetRednerCallbackInputWorldColor(global::System.IntPtr renderInput);
        }
    }
}



