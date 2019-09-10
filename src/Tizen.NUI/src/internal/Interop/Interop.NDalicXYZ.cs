using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class NDalicXYZ
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_POSITIVE_X_get")]
            public static extern uint POSITIVE_X_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_NEGATIVE_X_get")]
            public static extern uint NEGATIVE_X_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_POSITIVE_Y_get")]
            public static extern uint POSITIVE_Y_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_NEGATIVE_Y_get")]
            public static extern uint NEGATIVE_Y_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_POSITIVE_Z_get")]
            public static extern uint POSITIVE_Z_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_NEGATIVE_Z_get")]
            public static extern uint NEGATIVE_Z_get();
        }
    }
}