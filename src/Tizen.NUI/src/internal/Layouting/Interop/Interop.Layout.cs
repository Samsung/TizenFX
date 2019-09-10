using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class Layout
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_LayoutDirectionChangedSignal")]
            public static extern global::System.IntPtr LayoutDirectionChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewLayoutDirectionChangedSignal_Empty")]
            public static extern bool ViewLayoutDirectionChangedSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewLayoutDirectionSignal_GetConnectionCount")]
            public static extern uint ViewLayoutDirectionChangedSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewLayoutDirectionSignal_Connect")]
            public static extern void ViewLayoutDirectionChangedSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewLayoutDirectionSignal_Disconnect")]
            public static extern void ViewLayoutDirectionChangedSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewLayoutDirectionSignal_Emit")]
            public static extern void ViewLayoutDirectionChangedSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_ViewLayoutDirectionSignal")]
            public static extern global::System.IntPtr new_ViewLayoutDirectionChangedSignal();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_ViewLayoutDirectionSignal")]
            public static extern void delete_ViewLayoutDirectionChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);
        }
    }
}