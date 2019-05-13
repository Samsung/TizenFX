using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class PreFocusSignal
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_KeyboardPreFocusChangeSignal_Empty")]
            public static extern bool PreFocusChangeSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_KeyboardPreFocusChangeSignal_GetConnectionCount")]
            public static extern uint PreFocusChangeSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_KeyboardPreFocusChangeSignal_Connect")]
            public static extern void PreFocusChangeSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, Tizen.NUI.FocusManager.PreFocusChangeEventCallback delegate1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_KeyboardPreFocusChangeSignal_Disconnect")]
            public static extern void PreFocusChangeSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_KeyboardPreFocusChangeSignal_Emit")]
            public static extern global::System.IntPtr PreFocusChangeSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, int jarg4);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_new_KeyboardPreFocusChangeSignal")]
            public static extern global::System.IntPtr new_PreFocusChangeSignal();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_delete_KeyboardPreFocusChangeSignal")]
            public static extern void delete_PreFocusChangeSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


        }
    }
}
