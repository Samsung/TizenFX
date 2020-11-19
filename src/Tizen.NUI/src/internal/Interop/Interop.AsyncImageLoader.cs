using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class AsyncImageLoader
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AsyncImageLoader_SWIGUpcast")]
            public static extern global::System.IntPtr AsyncImageLoaderUpcast(global::System.IntPtr jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_AsyncImageLoader__SWIG_0")]
            public static extern global::System.IntPtr NewAsyncImageLoader();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_AsyncImageLoader")]
            public static extern void DeleteAsyncImageLoader(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_AsyncImageLoader__SWIG_1")]
            public static extern global::System.IntPtr NewAsyncImageLoader(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AsyncImageLoader_Assign")]
            public static extern global::System.IntPtr AsyncImageLoaderAssign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AsyncImageLoader_New")]
            public static extern global::System.IntPtr AsyncImageLoaderNew();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AsyncImageLoader_DownCast")]
            public static extern global::System.IntPtr AsyncImageLoaderDownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AsyncImageLoader_Load__SWIG_0")]
            public static extern uint AsyncImageLoaderLoad(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AsyncImageLoader_Load__SWIG_1")]
            public static extern uint AsyncImageLoaderLoad(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AsyncImageLoader_Load__SWIG_2")]
            public static extern uint AsyncImageLoaderLoad(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, int jarg4, int jarg5, bool jarg6);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AsyncImageLoader_Cancel")]
            public static extern bool AsyncImageLoaderCancel(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AsyncImageLoader_CancelAll")]
            public static extern void AsyncImageLoaderCancelAll(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AsyncImageLoader_ImageLoadedSignal")]
            public static extern global::System.IntPtr AsyncImageLoaderImageLoadedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);
        }
    }
}