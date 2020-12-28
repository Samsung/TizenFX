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
            public static extern bool ViewLayoutDirectionChangedSignalEmpty(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewLayoutDirectionSignal_GetConnectionCount")]
            public static extern uint ViewLayoutDirectionChangedSignalGetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewLayoutDirectionSignal_Connect")]
            public static extern void ViewLayoutDirectionChangedSignalConnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewLayoutDirectionSignal_Disconnect")]
            public static extern void ViewLayoutDirectionChangedSignalDisconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewLayoutDirectionSignal_Emit")]
            public static extern void ViewLayoutDirectionChangedSignalEmit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_ViewLayoutDirectionSignal")]
            public static extern global::System.IntPtr NewViewLayoutDirectionChangedSignal();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_ViewLayoutDirectionSignal")]
            public static extern void DeleteViewLayoutDirectionChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);
        }
    }
}
