using System;
using global::System.Runtime.InteropServices;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class GLWindowVisibilityChangedSignal
        {
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_Visibility_Changed_Signal")]
            public static extern global::System.IntPtr GetSignal(HandleRef glWindow);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_Visibility_Changed_Signal_Empty")]
            public static extern bool Empty(HandleRef signalType);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_Visibility_Changed_Signal_GetConnectionCount")]
            public static extern uint GetConnectionCount(HandleRef signalType);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_Visibility_Changed_Signal_Connect")]
            public static extern void Connect(HandleRef signalType, HandleRef callback);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_Visibility_Changed_Signal_Disconnect")]
            public static extern void Disconnect(HandleRef signalType, HandleRef callback);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_Visibility_Changed_Signal_Emit")]
            public static extern void Emit(HandleRef signalType, HandleRef window, bool visibility);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_Visibility_Changed_Signal_delete")]
            public static extern void DeleteSignal(HandleRef signalType);
        }
    }
}
