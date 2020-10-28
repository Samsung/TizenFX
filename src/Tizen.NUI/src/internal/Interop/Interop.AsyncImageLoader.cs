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
            public static extern global::System.IntPtr AsyncImageLoader_SWIGUpcast(global::System.IntPtr jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_AsyncImageLoader__SWIG_0")]
            public static extern global::System.IntPtr new_AsyncImageLoader__SWIG_0();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_AsyncImageLoader")]
            public static extern void delete_AsyncImageLoader(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_AsyncImageLoader__SWIG_1")]
            public static extern global::System.IntPtr new_AsyncImageLoader__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AsyncImageLoader_Assign")]
            public static extern global::System.IntPtr AsyncImageLoader_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AsyncImageLoader_New")]
            public static extern global::System.IntPtr AsyncImageLoader_New();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AsyncImageLoader_DownCast")]
            public static extern global::System.IntPtr AsyncImageLoader_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AsyncImageLoader_Load__SWIG_0")]
            public static extern uint AsyncImageLoader_Load__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AsyncImageLoader_Load__SWIG_1")]
            public static extern uint AsyncImageLoader_Load__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AsyncImageLoader_Load__SWIG_2")]
            public static extern uint AsyncImageLoader_Load__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, int jarg4, int jarg5, bool jarg6);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AsyncImageLoader_Cancel")]
            public static extern bool AsyncImageLoader_Cancel(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AsyncImageLoader_CancelAll")]
            public static extern void AsyncImageLoader_CancelAll(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AsyncImageLoader_ImageLoadedSignal")]
            public static extern global::System.IntPtr AsyncImageLoader_ImageLoadedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);
        }
    }
}