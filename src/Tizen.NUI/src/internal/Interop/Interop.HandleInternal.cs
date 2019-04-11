using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class HandleInternal
        {
            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Handle_Supports")]
            public static extern bool Handle_Supports(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Handle_GetPropertyCount")]
            public static extern uint Handle_GetPropertyCount(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Handle_IsPropertyAConstraintInput")]
            public static extern bool Handle_IsPropertyAConstraintInput(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Handle_GetPropertyIndices")]
            public static extern void Handle_GetPropertyIndices(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Handle_RemoveConstraints__SWIG_0")]
            public static extern void Handle_RemoveConstraints__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1);
            

            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Handle_RemoveConstraints__SWIG_1")]
            public static extern void Handle_RemoveConstraints__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

        }
    }
}
