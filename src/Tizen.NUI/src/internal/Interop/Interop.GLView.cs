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

using System.Runtime.InteropServices;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class GLView
        {
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlView_New_SWIG")]
            public static extern global::System.IntPtr New(int nuiColorFormat);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_GlView_SWIG_0")]
            public static extern global::System.IntPtr NewGlView();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_GlView_SWIG_1")]
            public static extern global::System.IntPtr NewGlView(HandleRef nuiGlView);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_GlView")]
            public static extern void DeleteGlView(HandleRef nuiGlView);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlView_Assign")]
            public static extern global::System.IntPtr GlViewAssign(HandleRef nuiGlView1, HandleRef nuiGlView2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlView_RegisterGlCallbacks")]
            public static extern void GlViewRegisterGlCallbacks(HandleRef nuiGlView, HandleRef nuiInitCB, HandleRef nuiRenderFrameCB, HandleRef nuiTerminateCB);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlView_SetResizeCallback")]
            public static extern void GlViewSetResizeCallback(HandleRef nuiGlView, HandleRef nuiResizeCB);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlView_SetGraphicsConfig")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool GlViewSetGraphicsConfig(HandleRef nuiGlView, bool nuiDepth, bool nuiStencil, int nuiMsaa, int nuiVersion);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlView_SetRenderingMode")]
            public static extern void GlViewSetRenderingMode(HandleRef nuiGlView, int nuiRenderingMode);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlView_GetRenderingMode")]
            public static extern global::System.IntPtr GlViewGetRenderingMode(HandleRef nuiGlView);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlView_RenderOnce")]
            public static extern void GlViewRenderOnce(HandleRef nuiGlView);
        }
    }
}
