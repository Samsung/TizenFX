using System;
using System.Collections.Generic;
using System.Text;
using global::System.Runtime.InteropServices;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class GLWindowResizedSignal
        {
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_ResizedSignal_Empty")]
            public static extern bool GlWindowResizedSignalEmpty(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_ResizedSignal_GetConnectionCount")]
            public static extern uint GlWindowResizedSignalGetConnectionCount(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_ResizedSignal_Connect")]
            public static extern void GlWindowResizedSignalConnect(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_ResizedSignal_Disconnect")]
            public static extern void GlWindowResizedSignalDisconnect(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_ResizedSignal_Emit")]
            public static extern void GlWindowResizedSignalEmit(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_GlWindow_ResizedSignal")]
            public static extern global::System.IntPtr NewGlWindowResizedSignal();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_delete_ResizedSignal")]
            public static extern void GlWindowDeleteResizedSignal(HandleRef jarg1);
        }
    }
}
