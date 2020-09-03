using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class WatchView
        {
            //for widget view
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WatchView_New")]
            public static extern global::System.IntPtr WatchView_New(global::System.Runtime.InteropServices.HandleRef window, string nuiWatchId, string contentinfo, int width, int height);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WatchView_DownCast")]
            public static extern global::System.IntPtr WatchView_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_WatchView__SWIG_0")]
            public static extern global::System.IntPtr new_WatchView__SWIG_0();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_WatchView__SWIG_1")]
            public static extern global::System.IntPtr new_WatchView__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WatchView_Assign")]
            public static extern global::System.IntPtr WatchView_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_WatchView")]
            public static extern void delete_WatchView(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WatchView_PauseWatch")]
            public static extern bool WatchView_PauseWatch(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WatchView_ResumeWatch")]
            public static extern bool WatchView_ResumeWatch(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WatchView_SWIGUpcast")]
            public static extern global::System.IntPtr WatchView_SWIGUpcast(global::System.IntPtr jarg1);
        }
    }
}