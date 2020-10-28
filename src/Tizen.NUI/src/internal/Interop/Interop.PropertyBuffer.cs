using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class PropertyBuffer
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PropertyBuffer_SWIGUpcast")]
            public static extern global::System.IntPtr PropertyBuffer_SWIGUpcast(global::System.IntPtr jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PropertyBuffer_New")]
            public static extern global::System.IntPtr PropertyBuffer_New(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_PropertyBuffer__SWIG_0")]
            public static extern global::System.IntPtr new_PropertyBuffer__SWIG_0();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_PropertyBuffer")]
            public static extern void delete_PropertyBuffer(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_PropertyBuffer__SWIG_1")]
            public static extern global::System.IntPtr new_PropertyBuffer__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PropertyBuffer_DownCast")]
            public static extern global::System.IntPtr PropertyBuffer_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PropertyBuffer_Assign")]
            public static extern global::System.IntPtr PropertyBuffer_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PropertyBuffer_SetData")]
            public static extern void PropertyBuffer_SetData(global::System.Runtime.InteropServices.HandleRef jarg1, System.IntPtr jarg2, uint jarg3);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PropertyBuffer_GetSize")]
            public static extern uint PropertyBuffer_GetSize(global::System.Runtime.InteropServices.HandleRef jarg1);

        }
    }
}
