using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class LanguageChangedSignalType
        {

            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_LanguageChangedSignalType_Empty")]
            public static extern bool LanguageChangedSignalType_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_LanguageChangedSignalType_GetConnectionCount")]
            public static extern uint LanguageChangedSignalType_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_LanguageChangedSignalType_Connect")]
            public static extern void LanguageChangedSignalType_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_LanguageChangedSignalType_Disconnect")]
            public static extern void LanguageChangedSignalType_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_LanguageChangedSignalType_Emit")]
            public static extern void LanguageChangedSignalType_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_LanguageChangedSignalType")]
            public static extern global::System.IntPtr new_LanguageChangedSignalType();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_LanguageChangedSignalType")]
            public static extern void delete_LanguageChangedSignalType(global::System.Runtime.InteropServices.HandleRef jarg1);

        }
    }
}
