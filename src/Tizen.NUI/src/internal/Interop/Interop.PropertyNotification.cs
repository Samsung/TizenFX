using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class PropertyNotification
        {

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PropertyNotification_SWIGUpcast")]
            public static extern global::System.IntPtr PropertyNotification_SWIGUpcast(global::System.IntPtr jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_PropertyNotification__SWIG_0")]
            public static extern global::System.IntPtr new_PropertyNotification__SWIG_0();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PropertyNotification_DownCast")]
            public static extern global::System.IntPtr PropertyNotification_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_PropertyNotification")]
            public static extern void delete_PropertyNotification(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_PropertyNotification__SWIG_1")]
            public static extern global::System.IntPtr new_PropertyNotification__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PropertyNotification_Assign")]
            public static extern global::System.IntPtr PropertyNotification_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PropertyNotification_GetCondition__SWIG_0")]
            public static extern global::System.IntPtr PropertyNotification_GetCondition__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PropertyNotification_GetTarget")]
            public static extern global::System.IntPtr PropertyNotification_GetTarget(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PropertyNotification_GetTargetProperty")]
            public static extern int PropertyNotification_GetTargetProperty(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PropertyNotification_SetNotifyMode")]
            public static extern void PropertyNotification_SetNotifyMode(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PropertyNotification_GetNotifyMode")]
            public static extern int PropertyNotification_GetNotifyMode(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PropertyNotification_GetNotifyResult")]
            public static extern bool PropertyNotification_GetNotifyResult(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PropertyNotification_NotifySignal")]
            public static extern global::System.IntPtr PropertyNotification_NotifySignal(global::System.Runtime.InteropServices.HandleRef jarg1);


        }
    }
}
