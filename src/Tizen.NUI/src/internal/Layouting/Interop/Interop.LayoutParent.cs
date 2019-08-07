using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class LayoutParent
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_LayoutParent_GetParent")]
            public static extern global::System.IntPtr LayoutParent_GetParent(global::System.Runtime.InteropServices.HandleRef jarg1);
        }
    }
}