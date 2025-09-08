namespace Tizen.NUI
{
    using global::System;
    using global::System.Runtime.InteropServices;

    internal static partial class Interop
    {
        internal static partial class MaskEffect
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_MaskEffect_New__SWIG_0")]
            public static extern global::System.IntPtr New(HandleRef control);
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_MaskEffect_New__SWIG_1")]
            public static extern global::System.IntPtr New(HandleRef control, MaskEffectMode maskMode, float positionX, float positionY, float scaleX, float scaleY);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_MaskEffect_SetTargetMaskOnce")]
            public static extern void SetTargetMaskOnce(HandleRef effect, bool targetMaskOnce);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_MaskEffect_GetTargetMaskOnce")]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool GetTargetMaskOnce(HandleRef effect);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_MaskEffect_SetSourceMaskOnce")]
            public static extern void SetSourceMaskOnce(HandleRef effect, bool sourceMaskOnce);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_MaskEffect_GetSourceMaskOnce")]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool GetSourceMaskOnce(HandleRef effect);
        }
    }
}
