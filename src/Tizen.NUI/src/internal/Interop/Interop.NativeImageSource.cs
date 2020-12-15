using System.Runtime.InteropServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    using global::System;
    internal static partial class Interop
    {
        internal static partial class NativeImageSource
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_NativeImageSource_Upcast")]
            public static extern IntPtr Upcast(IntPtr jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_NativeImageSource_New")]
            public static extern IntPtr New(IntPtr handle);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_NativeImageSource_Delete")]
            public static extern void Delete(IntPtr jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_NativeImageSource_New_Handle")]
            public static extern IntPtr NewHandle(uint jarg1, uint jarg2, int jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_NativeImageSource_AcquireBuffer")]
            public static extern IntPtr AcquireBuffer(IntPtr jarg1, ref int jarg2, ref int jarg3, ref int jarg4);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_NativeImageSource_ReleaseBuffer")]
            public static extern bool ReleaseBuffer(IntPtr jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_NativeImageSource_GenerateUrl")]
            public static extern string GenerateUrl(IntPtr handle);
        }
    }
}
