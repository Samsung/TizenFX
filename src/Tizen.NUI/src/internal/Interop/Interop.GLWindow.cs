using System;
using System.Collections.Generic;
using System.Text;
using global::System.Runtime.InteropServices;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class GLWindow
        {
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_New__SWIG_0")]
            public static extern global::System.IntPtr GlWindow_New__SWIG_0();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_New__SWIG_1")]
            public static extern global::System.IntPtr GlWindow_New__SWIG_1(HandleRef jarg1, string jarg2, string jarg3, bool jarg4 );

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_GlWindow__SWIG_0")]
            public static extern global::System.IntPtr new_GlWindow__SWIG_0();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_GlWindow")]
            public static extern void delete_GlWindow(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_GlWindow__SWIG_1")]
            public static extern global::System.IntPtr new_GlWindow__SWIG_1(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_Assign")]
            public static extern global::System.IntPtr GlWindow_Assign(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_SetEglConfig")]
            public static extern global::System.IntPtr GlWindow_SetEglConfig(HandleRef jarg1, bool jarg2, bool jarg3, int jarg4, int jarg5);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_Raise")]
            public static extern void GlWindow_Raise(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_Lower")]
            public static extern void GlWindow_Lower(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_Activate")]
            public static extern void GlWindow_Activate(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_Show")]
            public static extern void GlWindow_Show(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_Hide")]
            public static extern void GlWindow_Hide(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_SetPositionSize")]
            public static extern void GlWindow_SetPositionSize(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_GetPositionSize")]
            public static extern global::System.IntPtr GlWindow_GetPositionSize(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_GetSupportedAuxiliaryHintCount")]
            public static extern uint GlWindow_GetSupportedAuxiliaryHintCount(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_GetSupportedAuxiliaryHint")]
            public static extern string GlWindow_GetSupportedAuxiliaryHint(HandleRef jarg1, uint jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_AddAuxiliaryHint")]
            public static extern uint GlWindow_AddAuxiliaryHint(HandleRef jarg1, string jarg2, string jarg3);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_RemoveAuxiliaryHint")]
            public static extern bool GlWindow_RemoveAuxiliaryHint(HandleRef jarg1, uint jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_SetAuxiliaryHintValue")]
            public static extern bool GlWindow_SetAuxiliaryHintValue(HandleRef jarg1, uint jarg2, string jarg3);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_GetAuxiliaryHintValue")]
            public static extern string GlWindow_GetAuxiliaryHintValue(HandleRef jarg1, uint jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_GetAuxiliaryHintId")]
            public static extern uint GlWindow_GetAuxiliaryHintId(HandleRef jarg1, string jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_SetInputRegion")]
            public static extern void GlWindow_SetInputRegion(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_SetOpaqueState")]
            public static extern void GlWindow_SetOpaqueState(HandleRef jarg1, bool jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_IsOpaqueState")]
            public static extern bool GlWindow_IsOpaqueState(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_GetCurrentOrientation")]
            public static extern int GlWindow_GetCurrentOrientation(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_SetAvailableOrientations")]
            public static extern void GlWindow_SetAvailableOrientations(HandleRef jarg1, HandleRef jarg2, int jarg3);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_SetPreferredOrientation")]
            public static extern void GlWindow_SetPreferredOrientation(HandleRef jarg1, int jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_RegisterGlCallback")]
            public static extern void GlWindow_RegisterGlCallback(HandleRef  jarg1, HandleRef  jarg2, HandleRef  jarg3, HandleRef  jarg4);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_RenderOnce")]
            public static extern void GlWindow_RenderOnce(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_SWIGUpcast")]
            public static extern global::System.IntPtr GlWindow_SWIGUpcast(global::System.IntPtr jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_TouchSignal")]
            public static extern global::System.IntPtr GlWindow_TouchSignal(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_FocusChangedSignal")]
            public static extern global::System.IntPtr GlWindow_FocusChangedSignal(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_KeyEventSignal")]
            public static extern global::System.IntPtr GlWindow_KeyEventSignal(HandleRef jarg1);

            // For windows resized signal
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_ResizedSignal")]
            public static extern global::System.IntPtr GlWindow_ResizedSignal(HandleRef jarg1);

        }
    }
}
