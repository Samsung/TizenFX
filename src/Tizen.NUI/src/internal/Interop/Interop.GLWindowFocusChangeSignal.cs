using System;
using System.Collections.Generic;
using System.Text;
using global::System.Runtime.InteropServices;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class GLWindowFocusSignalType
        {
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_FocusSignalType_Empty")]
            public static extern bool GlWindow_FocusSignalType_Empty(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_FocusSignalType_GetConnectionCount")]
            public static extern uint GlWindow_FocusSignalType_GetConnectionCount(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_FocusSignalType_Connect")]
            public static extern void GlWindow_FocusSignalType_Connect(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_FocusSignalType_Disconnect")]
            public static extern void GlWindow_FocusSignalType_Disconnect(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_FocusSignalType_Emit")]
            public static extern void GlWindow_FocusSignalType_Emit(HandleRef signalType, HandleRef window, bool focusIn);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_GlWindow_FocusSignalType")]
            public static extern global::System.IntPtr new_GlWindow_FocusSignalType();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_GlWindow_FocusSignalType")]
            public static extern void delete_GlWindow_FocusSignalType(HandleRef jarg1);
        }
    }
}
