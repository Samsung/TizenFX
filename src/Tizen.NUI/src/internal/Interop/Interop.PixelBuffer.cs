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
            public static extern global::System.IntPtr Upcast(global::System.IntPtr jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelBuffer_New")]
            public static extern global::System.IntPtr New(uint jarg1, uint jarg2, int jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_PixelBuffer__SWIG_0")]
            public static extern global::System.IntPtr NewPixelBuffer();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_PixelBuffer")]
            public static extern void DeletePixelBuffer(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_PixelBuffer__SWIG_1")]
            public static extern global::System.IntPtr NewPixelBuffer(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelBuffer_Assign")]
            public static extern global::System.IntPtr Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelBuffer_Convert")]
            public static extern global::System.IntPtr Convert(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelBuffer_CreatePixelData")]
            public static extern global::System.IntPtr CreatePixelData(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelBuffer_GetBuffer")]
            public static extern global::System.IntPtr GetBuffer(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelBuffer_GetWidth")]
            public static extern uint GetWidth(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelBuffer_GetHeight")]
            public static extern uint GetHeight(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelBuffer_GetPixelFormat")]
            public static extern int GetPixelFormat(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelBuffer_ApplyMask__SWIG_0")]
            public static extern void ApplyMask(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, float jarg3, bool jarg4);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelBuffer_ApplyMask__SWIG_1")]
            public static extern void ApplyMask(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, float jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelBuffer_ApplyMask__SWIG_2")]
            public static extern void ApplyMask(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelBuffer_ApplyGaussianBlur")]
            public static extern void ApplyGaussianBlur(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelBuffer_Crop")]
            public static extern void Crop(global::System.Runtime.InteropServices.HandleRef jarg1, ushort jarg2, ushort jarg3, ushort jarg4, ushort jarg5);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelBuffer_Resize")]
            public static extern void Resize(global::System.Runtime.InteropServices.HandleRef jarg1, ushort jarg2, ushort jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelBuffer_Rotate")]
            public static extern bool Rotate(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);
        }
    }
}
