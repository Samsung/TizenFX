
namespace Tizen.NUI
{
    using global::System;
    using global::System.Runtime.InteropServices;

    internal static partial class Interop
    {
        internal static partial class WindowInternal
        {
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_GetNativeHandle")]
            public static extern IntPtr WindowGetNativeHandle(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_AddFrameRenderedCallback")]
            public static extern void AddFrameRenderedCallback(HandleRef nuiWindow, HandleRef nuiCallbakc, int nuiFrameId);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_AddFramePresentedCallback")]
            public static extern void AddFramePresentedCallback(HandleRef nuiWindow, HandleRef nuiCallbakc, int nuiFrameId);
        }
    }
}
