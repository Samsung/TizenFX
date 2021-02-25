using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class TextureSet
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextureSet_New")]
            public static extern global::System.IntPtr New();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_TextureSet__SWIG_0")]
            public static extern global::System.IntPtr NewTextureSet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_TextureSet")]
            public static extern void DeleteTextureSet(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_TextureSet__SWIG_1")]
            public static extern global::System.IntPtr NewTextureSet(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextureSet_DownCast")]
            public static extern global::System.IntPtr DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextureSet_Assign")]
            public static extern global::System.IntPtr Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextureSet_SetTexture")]
            public static extern void SetTexture(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextureSet_GetTexture")]
            public static extern global::System.IntPtr GetTexture(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextureSet_SetSampler")]
            public static extern void SetSampler(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextureSet_GetSampler")]
            public static extern global::System.IntPtr GetSampler(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextureSet_GetTextureCount")]
            public static extern uint GetTextureCount(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TextureSet_SWIGUpcast")]
            public static extern global::System.IntPtr Upcast(global::System.IntPtr jarg1);
        }
    }
}
