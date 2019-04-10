using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class NDalic
        {
            static NDalic()
            {
                Tizen.Log.Error("NUI", "NDalic");
            }

            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_int_to_uint")]
            public static extern uint int_to_uint(int jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_DaliAssertMessage")]
            public static extern void DaliAssertMessage(string jarg1, string jarg2);
            

            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Min__SWIG_0")]
            public static extern global::System.IntPtr Min__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Max__SWIG_0")]
            public static extern global::System.IntPtr Max__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Clamp__SWIG_0")]
            public static extern global::System.IntPtr Clamp__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3);
            

            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Min__SWIG_1")]
            public static extern global::System.IntPtr Min__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Max__SWIG_1")]
            public static extern global::System.IntPtr Max__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Clamp__SWIG_1")]
            public static extern global::System.IntPtr Clamp__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3);
            

            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Min__SWIG_2")]
            public static extern global::System.IntPtr Min__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Max__SWIG_2")]
            public static extern global::System.IntPtr Max__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Clamp__SWIG_2")]
            public static extern global::System.IntPtr Clamp__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, float jarg3);
            

            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_EqualTo__SWIG_9")]
            public static extern bool EqualTo__SWIG_9(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_NextPowerOfTwo")]
            public static extern uint NextPowerOfTwo(uint jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_IsPowerOfTwo")]
            public static extern bool IsPowerOfTwo(uint jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_GetRangedEpsilon")]
            public static extern float GetRangedEpsilon(float jarg1, float jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_EqualsZero")]
            public static extern bool EqualsZero(float jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Equals__SWIG_0")]
            public static extern bool Equals__SWIG_0(float jarg1, float jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Equals__SWIG_1")]
            public static extern bool Equals__SWIG_1(float jarg1, float jarg2, float jarg3);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Round")]
            public static extern float Round(float jarg1, int jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WrapInDomain")]
            public static extern float WrapInDomain(float jarg1, float jarg2, float jarg3);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_ShortestDistanceInDomain")]
            public static extern float ShortestDistanceInDomain(float jarg1, float jarg2, float jarg3, float jarg4);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_GetName")]
            public static extern string GetName(int jarg1);
            

            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_GetImplementation")]
            public static extern global::System.IntPtr GetImplementation(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WEIGHT_get")]
            public static extern int WEIGHT_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_RegisterType")]
            public static extern bool RegisterType(string jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);
            

            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_RegisterProperty")]
            public static extern bool RegisterProperty(string jarg1, string jarg2, int jarg3, int jarg4, global::System.Runtime.InteropServices.HandleRef jarg5, global::System.Runtime.InteropServices.HandleRef jarg6);
            

            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_FIRST_VALID_PIXEL_FORMAT_get")]
            public static extern int FIRST_VALID_PIXEL_FORMAT_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_LAST_VALID_PIXEL_FORMAT_get")]
            public static extern int LAST_VALID_PIXEL_FORMAT_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_HasAlpha")]
            public static extern bool HasAlpha(int jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_GetBytesPerPixel")]
            public static extern uint GetBytesPerPixel(int jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_GetAlphaOffsetAndMask")]
            public static extern void GetAlphaOffsetAndMask(int jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_GetDeviceName")]
            public static extern string GetDeviceName(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_GetDeviceClass")]
            public static extern int GetDeviceClass(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_GetDeviceSubClass")]
            public static extern int GetDeviceSubClass(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Raise")]
            public static extern void Raise(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_Lower")]
            public static extern void Lower(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_RaiseToTop")]
            public static extern void RaiseToTop(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_LowerToBottom")]
            public static extern void LowerToBottom(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_RaiseAbove")]
            public static extern void RaiseAbove(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_LowerBelow")]
            public static extern void LowerBelow(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            
            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_GetImplementation__SWIG_0")]
            public static extern global::System.IntPtr GetImplementation__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1);
            

            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_NewItemLayout")]
            public static extern global::System.IntPtr NewItemLayout(int jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_SetCustomAlgorithm")]
            public static extern void SetCustomAlgorithm(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            
        }
    }
}
