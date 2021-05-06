
namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class WebSettings
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_AllowMixedContents")]
            public static extern void AllowMixedContents(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_EnableSpatialNavigation")]
            public static extern void EnableSpatialNavigation(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_GetDefaultFontSize")]
            public static extern int GetDefaultFontSize(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_SetDefaultFontSize")]
            public static extern void SetDefaultFontSize(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_EnableWebSecurity")]
            public static extern void EnableWebSecurity(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_AllowFileAccessFromExternalUrl")]
            public static extern void AllowFileAccessFromExternalUrl(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_IsJavaScriptEnabled")]
            public static extern bool IsJavaScriptEnabled(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_EnableJavaScript")]
            public static extern void EnableJavaScript(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_AllowScriptsOpenWindows")]
            public static extern void AllowScriptsOpenWindows(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_AreImagesLoadedAutomatically")]
            public static extern bool AreImagesLoadedAutomatically(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_AllowImagesLoadAutomatically")]
            public static extern void AllowImagesLoadAutomatically(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_GetDefaultTextEncodingName")]
            public static extern string GetDefaultTextEncodingName(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_SetDefaultTextEncodingName")]
            public static extern void SetDefaultTextEncodingName(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);
        }
    }
}

