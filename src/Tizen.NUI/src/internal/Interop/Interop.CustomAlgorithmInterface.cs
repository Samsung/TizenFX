using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class CustomAlgorithmInterface
        {

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_CustomAlgorithmInterface")]
            public static extern void delete_CustomAlgorithmInterface(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CustomAlgorithmInterface_GetNextFocusableActor")]
            public static extern global::System.IntPtr CustomAlgorithmInterface_GetNextFocusableActor(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, int jarg4);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_CustomAlgorithmInterface")]
            public static extern global::System.IntPtr new_CustomAlgorithmInterface();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_CustomAlgorithmInterface_director_connect")]
            public static extern void CustomAlgorithmInterface_director_connect(global::System.Runtime.InteropServices.HandleRef jarg1, Tizen.NUI.CustomAlgorithmInterface.SwigDelegateCustomAlgorithmInterface_0 delegate0);


        }
    }
}
