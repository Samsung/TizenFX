using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class BaseObject
        {
            
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_BaseObject_DoAction")]
            public static extern bool BaseObject_DoAction(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_BaseObject_GetTypeName")]
            public static extern string BaseObject_GetTypeName(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_BaseObject_GetTypeInfo")]
            public static extern bool BaseObject_GetTypeInfo(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_BaseObject_DoConnectSignal")]
            public static extern bool BaseObject_DoConnectSignal(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, string jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_BaseObject_SWIGUpcast")]
            public static extern global::System.IntPtr BaseObject_SWIGUpcast(global::System.IntPtr jarg1);
        }
    }
}
