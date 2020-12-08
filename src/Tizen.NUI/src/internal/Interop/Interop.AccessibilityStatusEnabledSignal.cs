using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class AccessibilityStatusEnabledSignal
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_StatusEnabledSignalType_Empty")]
            public static extern bool AccessibilityStatusEnabledSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_StatusEnabledSignalType_GetConnectionCount")]
            public static extern uint AccessibilityStatusEnabledSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_StatusEnabledSignalType_Connect")]
            public static extern void AccessibilityStatusEnabledSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_StatusEnabledSignalType_Disconnect")]
            public static extern void AccessibilityStatusEnabledSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_StatusEnabledSignalType_Emit")]
            public static extern void AccessibilityStatusEnabledSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_StatusEnabledSignalType")]
            public static extern global::System.IntPtr new_AccessibilityStatusEnabledSignal();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_StatusEnabledSignalType")]
            public static extern void delete_AccessibilityStatusEnabledSignal(global::System.Runtime.InteropServices.HandleRef jarg1);
        }
    }
}