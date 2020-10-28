using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class Ruler
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Ruler_SWIGUpcast")]
            public static extern global::System.IntPtr Ruler_SWIGUpcast(global::System.IntPtr jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DefaultRuler_SWIGUpcast")]
            public static extern global::System.IntPtr DefaultRuler_SWIGUpcast(global::System.IntPtr jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FixedRuler_SWIGUpcast")]
            public static extern global::System.IntPtr FixedRuler_SWIGUpcast(global::System.IntPtr jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_RulerDomain__SWIG_0")]
            public static extern global::System.IntPtr new_RulerDomain__SWIG_0(float jarg1, float jarg2, bool jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_RulerDomain__SWIG_1")]
            public static extern global::System.IntPtr new_RulerDomain__SWIG_1(float jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerDomain_min_set")]
            public static extern void RulerDomain_min_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerDomain_min_get")]
            public static extern float RulerDomain_min_get(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerDomain_max_set")]
            public static extern void RulerDomain_max_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerDomain_max_get")]
            public static extern float RulerDomain_max_get(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerDomain_enabled_set")]
            public static extern void RulerDomain_enabled_set(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerDomain_enabled_get")]
            public static extern bool RulerDomain_enabled_get(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerDomain_Clamp__SWIG_0")]
            public static extern float RulerDomain_Clamp__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3, float jarg4);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerDomain_Clamp__SWIG_1")]
            public static extern float RulerDomain_Clamp__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerDomain_Clamp__SWIG_2")]
            public static extern float RulerDomain_Clamp__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerDomain_Clamp__SWIG_3")]
            public static extern float RulerDomain_Clamp__SWIG_3(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3, float jarg4, global::System.Runtime.InteropServices.HandleRef jarg5);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerDomain_GetSize")]
            public static extern float RulerDomain_GetSize(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_RulerDomain")]
            public static extern void delete_RulerDomain(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Ruler_Snap__SWIG_0")]
            public static extern float Ruler_Snap__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Ruler_Snap__SWIG_1")]
            public static extern float Ruler_Snap__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Ruler_GetPositionFromPage")]
            public static extern float Ruler_GetPositionFromPage(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, out uint jarg3, bool jarg4);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Ruler_GetPageFromPosition")]
            public static extern uint Ruler_GetPageFromPosition(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, bool jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Ruler_GetTotalPages")]
            public static extern uint Ruler_GetTotalPages(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Ruler_GetType")]
            public static extern int Ruler_GetType(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Ruler_IsEnabled")]
            public static extern bool Ruler_IsEnabled(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Ruler_Enable")]
            public static extern void Ruler_Enable(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Ruler_Disable")]
            public static extern void Ruler_Disable(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Ruler_SetDomain")]
            public static extern void Ruler_SetDomain(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Ruler_GetDomain")]
            public static extern global::System.IntPtr Ruler_GetDomain(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Ruler_DisableDomain")]
            public static extern void Ruler_DisableDomain(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Ruler_Clamp__SWIG_0")]
            public static extern float Ruler_Clamp__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3, float jarg4);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Ruler_Clamp__SWIG_1")]
            public static extern float Ruler_Clamp__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Ruler_Clamp__SWIG_2")]
            public static extern float Ruler_Clamp__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Ruler_Clamp__SWIG_3")]
            public static extern float Ruler_Clamp__SWIG_3(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3, float jarg4, global::System.Runtime.InteropServices.HandleRef jarg5);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Ruler_SnapAndClamp__SWIG_0")]
            public static extern float Ruler_SnapAndClamp__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3, float jarg4, float jarg5);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Ruler_SnapAndClamp__SWIG_1")]
            public static extern float Ruler_SnapAndClamp__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3, float jarg4);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Ruler_SnapAndClamp__SWIG_2")]
            public static extern float Ruler_SnapAndClamp__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Ruler_SnapAndClamp__SWIG_3")]
            public static extern float Ruler_SnapAndClamp__SWIG_3(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Ruler_SnapAndClamp__SWIG_4")]
            public static extern float Ruler_SnapAndClamp__SWIG_4(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3, float jarg4, float jarg5, global::System.Runtime.InteropServices.HandleRef jarg6);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_DefaultRuler")]
            public static extern global::System.IntPtr new_DefaultRuler();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DefaultRuler_Snap")]
            public static extern float DefaultRuler_Snap(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DefaultRuler_GetPositionFromPage")]
            public static extern float DefaultRuler_GetPositionFromPage(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, out uint jarg3, bool jarg4);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DefaultRuler_GetPageFromPosition")]
            public static extern uint DefaultRuler_GetPageFromPosition(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, bool jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DefaultRuler_GetTotalPages")]
            public static extern uint DefaultRuler_GetTotalPages(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_DefaultRuler")]
            public static extern void delete_DefaultRuler(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_FixedRuler__SWIG_0")]
            public static extern global::System.IntPtr new_FixedRuler__SWIG_0(float jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_FixedRuler__SWIG_1")]
            public static extern global::System.IntPtr new_FixedRuler__SWIG_1();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FixedRuler_Snap")]
            public static extern float FixedRuler_Snap(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FixedRuler_GetPositionFromPage")]
            public static extern float FixedRuler_GetPositionFromPage(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, out uint jarg3, bool jarg4);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FixedRuler_GetPageFromPosition")]
            public static extern uint FixedRuler_GetPageFromPosition(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, bool jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FixedRuler_GetTotalPages")]
            public static extern uint FixedRuler_GetTotalPages(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_FixedRuler")]
            public static extern void delete_FixedRuler(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_RulerPtr__SWIG_0")]
            public static extern global::System.IntPtr new_RulerPtr__SWIG_0();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_RulerPtr__SWIG_1")]
            public static extern global::System.IntPtr new_RulerPtr__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_RulerPtr__SWIG_2")]
            public static extern global::System.IntPtr new_RulerPtr__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_RulerPtr")]
            public static extern void delete_RulerPtr(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_Get")]
            public static extern global::System.IntPtr RulerPtr_Get(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr___deref__")]
            public static extern global::System.IntPtr RulerPtr___deref__(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr___ref__")]
            public static extern global::System.IntPtr RulerPtr___ref__(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_Assign__SWIG_0")]
            public static extern global::System.IntPtr RulerPtr_Assign__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_Assign__SWIG_1")]
            public static extern global::System.IntPtr RulerPtr_Assign__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_Reset__SWIG_0")]
            public static extern void RulerPtr_Reset__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_Reset__SWIG_1")]
            public static extern void RulerPtr_Reset__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_Detach")]
            public static extern global::System.IntPtr RulerPtr_Detach(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_Snap__SWIG_0")]
            public static extern float RulerPtr_Snap__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_Snap__SWIG_1")]
            public static extern float RulerPtr_Snap__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_GetPositionFromPage")]
            public static extern float RulerPtr_GetPositionFromPage(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, out uint jarg3, bool jarg4);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_GetPageFromPosition")]
            public static extern uint RulerPtr_GetPageFromPosition(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, bool jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_GetTotalPages")]
            public static extern uint RulerPtr_GetTotalPages(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_GetType")]
            public static extern int RulerPtr_GetType(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_IsEnabled")]
            public static extern bool RulerPtr_IsEnabled(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_Enable")]
            public static extern void RulerPtr_Enable(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_Disable")]
            public static extern void RulerPtr_Disable(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_SetDomain")]
            public static extern void RulerPtr_SetDomain(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_GetDomain")]
            public static extern global::System.IntPtr RulerPtr_GetDomain(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_DisableDomain")]
            public static extern void RulerPtr_DisableDomain(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_Clamp__SWIG_0")]
            public static extern float RulerPtr_Clamp__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3, float jarg4);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_Clamp__SWIG_1")]
            public static extern float RulerPtr_Clamp__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_Clamp__SWIG_2")]
            public static extern float RulerPtr_Clamp__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_Clamp__SWIG_3")]
            public static extern float RulerPtr_Clamp__SWIG_3(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3, float jarg4, global::System.Runtime.InteropServices.HandleRef jarg5);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_SnapAndClamp__SWIG_0")]
            public static extern float RulerPtr_SnapAndClamp__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3, float jarg4, float jarg5);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_SnapAndClamp__SWIG_1")]
            public static extern float RulerPtr_SnapAndClamp__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3, float jarg4);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_SnapAndClamp__SWIG_2")]
            public static extern float RulerPtr_SnapAndClamp__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_SnapAndClamp__SWIG_3")]
            public static extern float RulerPtr_SnapAndClamp__SWIG_3(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_SnapAndClamp__SWIG_4")]
            public static extern float RulerPtr_SnapAndClamp__SWIG_4(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3, float jarg4, float jarg5, global::System.Runtime.InteropServices.HandleRef jarg6);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_Reference")]
            public static extern void RulerPtr_Reference(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_Unreference")]
            public static extern void RulerPtr_Unreference(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RulerPtr_ReferenceCount")]
            public static extern int RulerPtr_ReferenceCount(global::System.Runtime.InteropServices.HandleRef jarg1);
        }
    }
}