using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class LongPressGestureDetector
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_LongPressGestureDetector__SWIG_0")]
            public static extern global::System.IntPtr NewLongPressGestureDetector();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_LongPressGestureDetector_New__SWIG_0")]
            public static extern global::System.IntPtr New();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_LongPressGestureDetector_New__SWIG_1")]
            public static extern global::System.IntPtr New(uint jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_LongPressGestureDetector_New__SWIG_2")]
            public static extern global::System.IntPtr New(uint jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_LongPressGestureDetector_DownCast")]
            public static extern global::System.IntPtr DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_LongPressGestureDetector")]
            public static extern void DeleteLongPressGestureDetector(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_LongPressGestureDetector__SWIG_1")]
            public static extern global::System.IntPtr NewLongPressGestureDetector(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_LongPressGestureDetector_Assign")]
            public static extern global::System.IntPtr Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_LongPressGestureDetector_SetTouchesRequired__SWIG_0")]
            public static extern void SetTouchesRequired(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_LongPressGestureDetector_SetTouchesRequired__SWIG_1")]
            public static extern void SetTouchesRequired(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, uint jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_LongPressGestureDetector_GetMinimumTouchesRequired")]
            public static extern uint GetMinimumTouchesRequired(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_LongPressGestureDetector_GetMaximumTouchesRequired")]
            public static extern uint GetMaximumTouchesRequired(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_LongPressGestureDetector_DetectedSignal")]
            public static extern global::System.IntPtr DetectedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_LongPressGestureDetector_SWIGUpcast")]
            public static extern global::System.IntPtr Upcast(global::System.IntPtr jarg1);
        }
    }
}
