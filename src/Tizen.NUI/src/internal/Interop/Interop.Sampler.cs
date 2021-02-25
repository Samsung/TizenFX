using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class Sampler
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Sampler_New")]
            public static extern global::System.IntPtr New();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Sampler__SWIG_0")]
            public static extern global::System.IntPtr NewSampler();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Sampler")]
            public static extern void DeleteSampler(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Sampler__SWIG_1")]
            public static extern global::System.IntPtr NewSampler(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Sampler_DownCast")]
            public static extern global::System.IntPtr DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Sampler_Assign")]
            public static extern global::System.IntPtr Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Sampler_SetFilterMode")]
            public static extern void SetFilterMode(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Sampler_SetWrapMode__SWIG_0")]
            public static extern void SetWrapMode(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Sampler_SetWrapMode__SWIG_1")]
            public static extern void SetWrapMode(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3, int jarg4);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Sampler_SWIGUpcast")]
            public static extern global::System.IntPtr Upcast(global::System.IntPtr jarg1);
        }
    }
}
