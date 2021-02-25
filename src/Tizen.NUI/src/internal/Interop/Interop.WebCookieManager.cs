
namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class WebCookieManager
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebCookieManager_GetCookieAcceptPolicy")]
            public static extern int GetCookieAcceptPolicy(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebCookieManager_SetCookieAcceptPolicy")]
            public static extern void SetCookieAcceptPolicy(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebCookieManager_SetPersistentStorage")]
            public static extern void SetPersistentStorage(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, int jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebCookieManager_ClearCookies")]
            public static extern void ClearCookies(global::System.Runtime.InteropServices.HandleRef jarg1);
        }
    }
}

