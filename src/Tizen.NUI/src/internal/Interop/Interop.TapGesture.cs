using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class TapGesture
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TapGesture_SWIGUpcast")]
            public static extern global::System.IntPtr TapGesture_SWIGUpcast(global::System.IntPtr jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_TapGesture__SWIG_0")]
            public static extern global::System.IntPtr new_TapGesture__SWIG_0();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TapGesture_New")]
            public static extern global::System.IntPtr TapGesture_New(int jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_TapGesture__SWIG_1")]
            public static extern global::System.IntPtr new_TapGesture__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TapGesture_Assign")]
            public static extern global::System.IntPtr TapGesture_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_TapGesture")]
            public static extern void delete_TapGesture(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TapGesture_numberOfTaps_set")]
            public static extern void TapGesture_numberOfTaps_set(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TapGesture_numberOfTaps_get")]
            public static extern uint TapGesture_numberOfTaps_get(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TapGesture_numberOfTouches_set")]
            public static extern void TapGesture_numberOfTouches_set(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TapGesture_numberOfTouches_get")]
            public static extern uint TapGesture_numberOfTouches_get(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TapGesture_screenPoint_set")]
            public static extern void TapGesture_screenPoint_set(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TapGesture_screenPoint_get")]
            public static extern global::System.IntPtr TapGesture_screenPoint_get(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TapGesture_localPoint_set")]
            public static extern void TapGesture_localPoint_set(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TapGesture_localPoint_get")]
            public static extern global::System.IntPtr TapGesture_localPoint_get(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TapGesture_sourceType_get")]
            public static extern int SourceTypeGet(global::System.Runtime.InteropServices.HandleRef jarg1);
        }
    }
}