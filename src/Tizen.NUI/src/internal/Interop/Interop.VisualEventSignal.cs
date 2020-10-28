
using global::System;
using System.Runtime.InteropServices;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class VisualEventSignal
        {
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualEventSignal_Empty")]
            public static extern bool Empty(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualEventSignal_GetConnectionCount")]
            public static extern uint GetConnectionCount(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualEventSignal_Connect")]
            public static extern void Connect(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualEventSignal_Disconnect")]
            public static extern void Disconnect(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VisualEventSignal_Emit")]
            public static extern void Emit(HandleRef jarg1, HandleRef jarg2, int jarg3, int jarg4);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_VisualEventSignal")]
            public static extern IntPtr New();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_VisualEventSignal")]
            public static extern void Delete(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_VisualEventSignal")]
            public static extern IntPtr NewWithView(HandleRef jarg1);
        }
    }
}
