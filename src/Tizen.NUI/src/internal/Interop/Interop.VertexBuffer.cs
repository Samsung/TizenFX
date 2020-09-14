using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class VertexBuffer
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VertexBuffer_SWIGUpcast")]
            public static extern global::System.IntPtr VertexBuffer_SWIGUpcast(global::System.IntPtr jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VertexBuffer_New")]
            public static extern global::System.IntPtr VertexBuffer_New(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_VertexBuffer__SWIG_0")]
            public static extern global::System.IntPtr new_VertexBuffer__SWIG_0();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_VertexBuffer")]
            public static extern void delete_VertexBuffer(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_VertexBuffer__SWIG_1")]
            public static extern global::System.IntPtr new_VertexBuffer__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VertexBuffer_DownCast")]
            public static extern global::System.IntPtr VertexBuffer_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VertexBuffer_Assign")]
            public static extern global::System.IntPtr VertexBuffer_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VertexBuffer_SetData")]
            public static extern void VertexBuffer_SetData(global::System.Runtime.InteropServices.HandleRef jarg1, System.IntPtr jarg2, uint jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VertexBuffer_GetSize")]
            public static extern uint VertexBuffer_GetSize(global::System.Runtime.InteropServices.HandleRef jarg1);
        }
    }
}