using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class WindowInternal
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_GetNativeHandle")]
            public static extern global::System.IntPtr Window_GetNativeHandle(global::System.Runtime.InteropServices.HandleRef jarg1);
        }
    }
}