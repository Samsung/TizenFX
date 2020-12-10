using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class VectorBlob
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VectorBlob_r_set")]
            public static extern void RSet(global::System.Runtime.InteropServices.HandleRef jarg1, byte jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VectorBlob_r_get")]
            public static extern byte RGet(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VectorBlob_g_set")]
            public static extern void GSet(global::System.Runtime.InteropServices.HandleRef jarg1, byte jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VectorBlob_g_get")]
            public static extern byte GGet(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VectorBlob_b_set")]
            public static extern void BSet(global::System.Runtime.InteropServices.HandleRef jarg1, byte jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VectorBlob_b_get")]
            public static extern byte BGet(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VectorBlob_a_set")]
            public static extern void ASet(global::System.Runtime.InteropServices.HandleRef jarg1, byte jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VectorBlob_a_get")]
            public static extern byte AGet(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_VectorBlob")]
            public static extern global::System.IntPtr NewVectorBlob();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_VectorBlob")]
            public static extern void DeleteVectorBlob(global::System.Runtime.InteropServices.HandleRef jarg1);
        }
    }
}
