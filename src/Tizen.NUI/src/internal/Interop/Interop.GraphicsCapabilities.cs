using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class GraphicsCapabilities
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_IsBlendEquationSupported")]
            public static extern bool IsBlendEquationSupported(int blendEquation);
        }
    }
}
