using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class ScrollStateChangedSignal
        {

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollStateChangedSignal_Empty")]
            public static extern bool ScrollStateChangedSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollStateChangedSignal_GetConnectionCount")]
            public static extern uint ScrollStateChangedSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollStateChangedSignal_Connect")]
            public static extern void ScrollStateChangedSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollStateChangedSignal_Disconnect")]
            public static extern void ScrollStateChangedSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ScrollStateChangedSignal_Emit")]
            public static extern void ScrollStateChangedSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_ScrollStateChangedSignal")]
            public static extern global::System.IntPtr new_ScrollStateChangedSignal();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_ScrollStateChangedSignal")]
            public static extern void delete_ScrollStateChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        }
    }
}
