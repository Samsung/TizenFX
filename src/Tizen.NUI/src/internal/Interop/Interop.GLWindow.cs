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
        internal static partial class GLWindow
        {
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_New__SWIG_0")]
            public static extern global::System.IntPtr GlWindowNew();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_New__SWIG_1")]
            public static extern global::System.IntPtr GlWindowNew(HandleRef jarg1, string jarg2, string jarg3, bool jarg4);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_GlWindow__SWIG_0")]
            public static extern global::System.IntPtr NewGlWindow();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_GlWindow")]
            public static extern void DeleteGlWindow(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_GlWindow__SWIG_1")]
            public static extern global::System.IntPtr NewGlWindow(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_Assign")]
            public static extern global::System.IntPtr GlWindowAssign(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_SetEglConfig")]
            public static extern global::System.IntPtr GlWindowSetEglConfig(HandleRef jarg1, bool jarg2, bool jarg3, int jarg4, int jarg5);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_Raise")]
            public static extern void GlWindowRaise(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_Lower")]
            public static extern void GlWindowLower(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_Activate")]
            public static extern void GlWindowActivate(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_Show")]
            public static extern void GlWindowShow(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_Hide")]
            public static extern void GlWindowHide(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_SetPositionSize")]
            public static extern void GlWindowSetPositionSize(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_GetPositionSize")]
            public static extern global::System.IntPtr GlWindowGetPositionSize(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_GetSupportedAuxiliaryHintCount")]
            public static extern uint GlWindowGetSupportedAuxiliaryHintCount(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_GetSupportedAuxiliaryHint")]
            public static extern string GlWindowGetSupportedAuxiliaryHint(HandleRef jarg1, uint jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_AddAuxiliaryHint")]
            public static extern uint GlWindowAddAuxiliaryHint(HandleRef jarg1, string jarg2, string jarg3);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_RemoveAuxiliaryHint")]
            public static extern bool GlWindowRemoveAuxiliaryHint(HandleRef jarg1, uint jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_SetAuxiliaryHintValue")]
            public static extern bool GlWindowSetAuxiliaryHintValue(HandleRef jarg1, uint jarg2, string jarg3);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_GetAuxiliaryHintValue")]
            public static extern string GlWindowGetAuxiliaryHintValue(HandleRef jarg1, uint jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_GetAuxiliaryHintId")]
            public static extern uint GlWindowGetAuxiliaryHintId(HandleRef jarg1, string jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_SetInputRegion")]
            public static extern void GlWindowSetInputRegion(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_SetOpaqueState")]
            public static extern void GlWindowSetOpaqueState(HandleRef jarg1, bool jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_IsOpaqueState")]
            public static extern bool GlWindowIsOpaqueState(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_GetCurrentOrientation")]
            public static extern int GlWindowGetCurrentOrientation(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_SetAvailableOrientations")]
            public static extern void GlWindowSetAvailableOrientations(HandleRef jarg1, HandleRef jarg2, int jarg3);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_SetPreferredOrientation")]
            public static extern void GlWindowSetPreferredOrientation(HandleRef jarg1, int jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_RegisterGlCallback")]
            public static extern void GlWindowRegisterGlCallback(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, HandleRef jarg4);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_RenderOnce")]
            public static extern void GlWindowRenderOnce(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_SWIGUpcast")]
            public static extern global::System.IntPtr GlWindowUpcast(global::System.IntPtr jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_TouchSignal")]
            public static extern global::System.IntPtr GlWindowTouchSignal(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_FocusChangedSignal")]
            public static extern global::System.IntPtr GlWindowFocusChangedSignal(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_KeyEventSignal")]
            public static extern global::System.IntPtr GlWindowKeyEventSignal(HandleRef jarg1);

            // For windows resized signal
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_ResizedSignal")]
            public static extern global::System.IntPtr GlWindowResizedSignal(HandleRef jarg1);

        }
    }
}
