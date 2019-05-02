using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class VoidSignalType
        {

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_VoidSignalType")]
            public static extern global::System.IntPtr new_VoidSignalType();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_VoidSignalType")]
            public static extern void delete_VoidSignalType(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VoidSignalType_Empty")]
            public static extern bool VoidSignalType_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VoidSignalType_GetConnectionCount")]
            public static extern uint VoidSignalType_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VoidSignalType_Connect__SWIG_0")]
            public static extern void VoidSignalType_Connect__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VoidSignalType_Disconnect")]
            public static extern void VoidSignalType_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VoidSignalType_Connect__SWIG_4")]
            public static extern void VoidSignalType_Connect__SWIG_4(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VoidSignalType_Emit")]
            public static extern void VoidSignalType_Emit(global::System.Runtime.InteropServices.HandleRef jarg1);

        }
    }
}
