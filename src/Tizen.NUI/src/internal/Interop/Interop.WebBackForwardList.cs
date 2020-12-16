
namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class WebBackForwardListItem
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebBackForwardListItem_GetUrl")]
            public static extern string GetUrl(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebBackForwardListItem_GetTitle")]
            public static extern string GetTitle(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebBackForwardListItem_GetOriginalUrl")]
            public static extern string GetOriginalUrl(global::System.Runtime.InteropServices.HandleRef jarg1);
        }

        internal static partial class WebBackForwardList
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebBackForwardList_GetItemCount")]
            public static extern int GetItemCount(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebBackForwardList_GetCurrentItem")]
            public static extern global::System.IntPtr GetCurrentItem(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebBackForwardList_GetItemAtIndex")]
            public static extern global::System.IntPtr GetItemAtIndex(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);
        }
    }
}

