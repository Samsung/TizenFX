using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{ 
    internal static partial class Interop
    {
        internal static partial class Vector3
        {
            static Vector3()
            {
                ulong ret = Interop.Util.GetNanoSeconds();
                Tizen.Log.Error("NUI", "Vector3 : " + ret);
            }


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_Vector3__SWIG_0")]
            public static extern global::System.IntPtr new_Vector3__SWIG_0();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_Vector3__SWIG_1")]
            public static extern global::System.IntPtr new_Vector3__SWIG_1(float jarg1, float jarg2, float jarg3);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_Vector3__SWIG_2")]
            public static extern global::System.IntPtr new_Vector3__SWIG_2([global::System.Runtime.InteropServices.In, global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.LPArray)]float[] jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_Vector3__SWIG_3")]
            public static extern global::System.IntPtr new_Vector3__SWIG_3(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_Vector3__SWIG_4")]
            public static extern global::System.IntPtr new_Vector3__SWIG_4(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_ONE_get")]
            public static extern global::System.IntPtr Vector3_ONE_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_XAXIS_get")]
            public static extern global::System.IntPtr Vector3_XAXIS_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_YAXIS_get")]
            public static extern global::System.IntPtr Vector3_YAXIS_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_ZAXIS_get")]
            public static extern global::System.IntPtr Vector3_ZAXIS_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_NEGATIVE_XAXIS_get")]
            public static extern global::System.IntPtr Vector3_NEGATIVE_XAXIS_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_NEGATIVE_YAXIS_get")]
            public static extern global::System.IntPtr Vector3_NEGATIVE_YAXIS_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_NEGATIVE_ZAXIS_get")]
            public static extern global::System.IntPtr Vector3_NEGATIVE_ZAXIS_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_ZERO_get")]
            public static extern global::System.IntPtr Vector3_ZERO_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_Assign__SWIG_0")]
            public static extern global::System.IntPtr Vector3_Assign__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, [global::System.Runtime.InteropServices.In, global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.LPArray)]float[] jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_Assign__SWIG_1")]
            public static extern global::System.IntPtr Vector3_Assign__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_Assign__SWIG_2")]
            public static extern global::System.IntPtr Vector3_Assign__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_Add")]
            public static extern global::System.IntPtr Vector3_Add(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_AddAssign")]
            public static extern global::System.IntPtr Vector3_AddAssign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_Subtract__SWIG_0")]
            public static extern global::System.IntPtr Vector3_Subtract__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_SubtractAssign")]
            public static extern global::System.IntPtr Vector3_SubtractAssign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_Multiply__SWIG_0")]
            public static extern global::System.IntPtr Vector3_Multiply__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_Multiply__SWIG_1")]
            public static extern global::System.IntPtr Vector3_Multiply__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_MultiplyAssign__SWIG_0")]
            public static extern global::System.IntPtr Vector3_MultiplyAssign__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_MultiplyAssign__SWIG_1")]
            public static extern global::System.IntPtr Vector3_MultiplyAssign__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_MultiplyAssign__SWIG_2")]
            public static extern global::System.IntPtr Vector3_MultiplyAssign__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_Divide__SWIG_0")]
            public static extern global::System.IntPtr Vector3_Divide__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_Divide__SWIG_1")]
            public static extern global::System.IntPtr Vector3_Divide__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_DivideAssign__SWIG_0")]
            public static extern global::System.IntPtr Vector3_DivideAssign__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_DivideAssign__SWIG_1")]
            public static extern global::System.IntPtr Vector3_DivideAssign__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_Subtract__SWIG_1")]
            public static extern global::System.IntPtr Vector3_Subtract__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_EqualTo")]
            public static extern bool Vector3_EqualTo(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_NotEqualTo")]
            public static extern bool Vector3_NotEqualTo(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_ValueOfIndex__SWIG_0")]
            public static extern float Vector3_ValueOfIndex__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_Dot")]
            public static extern float Vector3_Dot(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_Cross")]
            public static extern global::System.IntPtr Vector3_Cross(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_Length")]
            public static extern float Vector3_Length(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_LengthSquared")]
            public static extern float Vector3_LengthSquared(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_Normalize")]
            public static extern void Vector3_Normalize(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_Clamp")]
            public static extern void Vector3_Clamp(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_AsFloat__SWIG_0")]
            public static extern global::System.IntPtr Vector3_AsFloat__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_GetVectorXY__SWIG_0")]
            public static extern global::System.IntPtr Vector3_GetVectorXY__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_GetVectorYZ__SWIG_0")]
            public static extern global::System.IntPtr Vector3_GetVectorYZ__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_X_set")]
            public static extern void Vector3_X_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_X_get")]
            public static extern float Vector3_X_get(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_Width_set")]
            public static extern void Vector3_Width_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_Width_get")]
            public static extern float Vector3_Width_get(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_r_set")]
            public static extern void Vector3_r_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_r_get")]
            public static extern float Vector3_r_get(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_Y_set")]
            public static extern void Vector3_Y_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_Y_get")]
            public static extern float Vector3_Y_get(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_Height_set")]
            public static extern void Vector3_Height_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_Height_get")]
            public static extern float Vector3_Height_get(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_g_set")]
            public static extern void Vector3_g_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_g_get")]
            public static extern float Vector3_g_get(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_Z_set")]
            public static extern void Vector3_Z_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_Z_get")]
            public static extern float Vector3_Z_get(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_Depth_set")]
            public static extern void Vector3_Depth_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_Depth_get")]
            public static extern float Vector3_Depth_get(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_b_set")]
            public static extern void Vector3_b_set(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Vector3_b_get")]
            public static extern float Vector3_b_get(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_Vector3")]
            public static extern void delete_Vector3(global::System.Runtime.InteropServices.HandleRef jarg1);

        }
    }
}
