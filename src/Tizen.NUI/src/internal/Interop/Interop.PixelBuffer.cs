using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{

    internal static partial class Interop
    {
        internal static partial class PixelBuffer
        {
            //for PixelBuffer and ImageLoading
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelBuffer_SWIGUpcast")]
            public static extern global::System.IntPtr PixelBuffer_SWIGUpcast(global::System.IntPtr jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelBuffer_New")]
            public static extern global::System.IntPtr PixelBuffer_New(uint jarg1, uint jarg2, int jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_PixelBuffer__SWIG_0")]
            public static extern global::System.IntPtr new_PixelBuffer__SWIG_0();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_PixelBuffer")]
            public static extern void delete_PixelBuffer(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_PixelBuffer__SWIG_1")]
            public static extern global::System.IntPtr new_PixelBuffer__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelBuffer_Assign")]
            public static extern global::System.IntPtr PixelBuffer_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelBuffer_Convert")]
            public static extern global::System.IntPtr PixelBuffer_Convert(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelBuffer_CreatePixelData")]
            public static extern global::System.IntPtr PixelBuffer_CreatePixelData(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelBuffer_GetBuffer")]
            public static extern global::System.IntPtr PixelBuffer_GetBuffer(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelBuffer_GetWidth")]
            public static extern uint PixelBuffer_GetWidth(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelBuffer_GetHeight")]
            public static extern uint PixelBuffer_GetHeight(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelBuffer_GetPixelFormat")]
            public static extern int PixelBuffer_GetPixelFormat(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelBuffer_ApplyMask__SWIG_0")]
            public static extern void PixelBuffer_ApplyMask__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, float jarg3, bool jarg4);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelBuffer_ApplyMask__SWIG_1")]
            public static extern void PixelBuffer_ApplyMask__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, float jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelBuffer_ApplyMask__SWIG_2")]
            public static extern void PixelBuffer_ApplyMask__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelBuffer_ApplyGaussianBlur")]
            public static extern void PixelBuffer_ApplyGaussianBlur(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelBuffer_Crop")]
            public static extern void PixelBuffer_Crop(global::System.Runtime.InteropServices.HandleRef jarg1, ushort jarg2, ushort jarg3, ushort jarg4, ushort jarg5);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelBuffer_Resize")]
            public static extern void PixelBuffer_Resize(global::System.Runtime.InteropServices.HandleRef jarg1, ushort jarg2, ushort jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelBuffer_Rotate")]
            public static extern bool PixelBuffer_Rotate(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelBuffer_GetBrightness")]
            public static extern uint GetBrightness(global::System.Runtime.InteropServices.HandleRef jarg1);
        }
    }
}