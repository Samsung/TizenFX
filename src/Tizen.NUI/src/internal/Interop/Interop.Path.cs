using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class Path
        {

            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Path_Property_POINTS_get")]
            public static extern int Path_Property_POINTS_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Path_Property_CONTROL_POINTS_get")]
            public static extern int Path_Property_CONTROL_POINTS_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_Path_Property")]
            public static extern global::System.IntPtr new_Path_Property();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_Path_Property")]
            public static extern void delete_Path_Property(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Path_New")]
            public static extern global::System.IntPtr Path_New();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Path_DownCast")]
            public static extern global::System.IntPtr Path_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_Path__SWIG_0")]
            public static extern global::System.IntPtr new_Path__SWIG_0();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_Path")]
            public static extern void delete_Path(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_Path__SWIG_1")]
            public static extern global::System.IntPtr new_Path__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Path_Assign")]
            public static extern global::System.IntPtr Path_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Path_AddPoint")]
            public static extern void Path_AddPoint(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Path_AddControlPoint")]
            public static extern void Path_AddControlPoint(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Path_GenerateControlPoints")]
            public static extern void Path_GenerateControlPoints(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Path_Sample")]
            public static extern void Path_Sample(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Path_GetPoint")]
            public static extern global::System.IntPtr Path_GetPoint(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Path_GetControlPoint")]
            public static extern global::System.IntPtr Path_GetControlPoint(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Path_GetPointCount")]
            public static extern uint Path_GetPointCount(global::System.Runtime.InteropServices.HandleRef jarg1);



            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Path_SWIGUpcast")]
            public static extern global::System.IntPtr Path_SWIGUpcast(global::System.IntPtr jarg1);
        }
    }
}
