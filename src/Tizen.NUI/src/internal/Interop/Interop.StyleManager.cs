using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class StyleManager
        {

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_StyleManager")]
            public static extern global::System.IntPtr new_StyleManager();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_StyleManager")]
            public static extern void delete_StyleManager(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_StyleManager_Get")]
            public static extern global::System.IntPtr StyleManager_Get();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_StyleManager_ApplyTheme")]
            public static extern void StyleManager_ApplyTheme(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_StyleManager_ApplyDefaultTheme")]
            public static extern void StyleManager_ApplyDefaultTheme(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_StyleManager_SetStyleConstant")]
            public static extern void StyleManager_SetStyleConstant(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_StyleManager_GetStyleConstant")]
            public static extern bool StyleManager_GetStyleConstant(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_StyleManager_ApplyStyle")]
            public static extern void StyleManager_ApplyStyle(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, string jarg3, string jarg4);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_StyleManager_StyleChangedSignal")]
            public static extern global::System.IntPtr StyleManager_StyleChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_StyleManager_SWIGUpcast")]
            public static extern global::System.IntPtr StyleManager_SWIGUpcast(global::System.IntPtr jarg1);
        }
    }
}
