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
            public static extern bool GlWindowFocusSignalTypeEmpty(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_FocusSignalType_GetConnectionCount")]
            public static extern uint GlWindowFocusSignalTypeGetConnectionCount(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_FocusSignalType_Connect")]
            public static extern void GlWindowFocusSignalTypeConnect(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_FocusSignalType_Disconnect")]
            public static extern void GlWindowFocusSignalTypeDisconnect(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_FocusSignalType_Emit")]
            public static extern void GlWindowFocusSignalTypeEmit(HandleRef signalType, HandleRef window, bool focusIn);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_GlWindow_FocusSignalType")]
            public static extern global::System.IntPtr NewGlWindowFocusSignalType();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_GlWindow_FocusSignalType")]
            public static extern void DeleteGlWindowFocusSignalType(HandleRef jarg1);
        }
    }
}
