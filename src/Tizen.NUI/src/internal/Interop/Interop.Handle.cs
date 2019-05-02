using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class Handle
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Handle__SWIG_0")]
            public static extern global::System.IntPtr new_Handle__SWIG_0();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Handle_New")]
            public static extern global::System.IntPtr Handle_New();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Handle")]
            public static extern void delete_Handle(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Handle__SWIG_1")]
            public static extern global::System.IntPtr new_Handle__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Handle_Assign")]
            public static extern global::System.IntPtr Handle_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Handle_DownCast")]
            public static extern global::System.IntPtr Handle_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);
            

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Handle_GetPropertyName")]
            public static extern string Handle_GetPropertyName(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Handle_GetPropertyIndex")]
            public static extern int Handle_GetPropertyIndex(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Handle_IsPropertyWritable")]
            public static extern bool Handle_IsPropertyWritable(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Handle_IsPropertyAnimatable")]
            public static extern bool Handle_IsPropertyAnimatable(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);
            

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Handle_GetPropertyType")]
            public static extern int Handle_GetPropertyType(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Handle_SetProperty")]
            public static extern void Handle_SetProperty(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Handle_RegisterProperty__SWIG_0")]
            public static extern int Handle_RegisterProperty__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Handle_RegisterProperty__SWIG_1")]
            public static extern int Handle_RegisterProperty__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, int jarg4);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Handle_GetProperty")]
            public static extern global::System.IntPtr Handle_GetProperty(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);
            

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Handle_AddPropertyNotification__SWIG_0")]
            public static extern global::System.IntPtr Handle_AddPropertyNotification__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Handle_AddPropertyNotification__SWIG_1")]
            public static extern global::System.IntPtr Handle_AddPropertyNotification__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Handle_RemovePropertyNotification")]
            public static extern void Handle_RemovePropertyNotification(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Handle_RemovePropertyNotifications")]
            public static extern void Handle_RemovePropertyNotifications(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Handle_SWIGUpcast")]
            public static extern global::System.IntPtr Handle_SWIGUpcast(global::System.IntPtr jarg1);
        }
    }
}
