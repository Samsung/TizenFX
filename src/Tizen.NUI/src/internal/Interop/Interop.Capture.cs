﻿
namespace Tizen.NUI
{
    using global::System;
    using global::System.Runtime.InteropServices;

    internal static partial class Interop
    {
        internal static partial class Capture
        {
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Capture_Upcast")]
            public static extern IntPtr Upcast(IntPtr jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Capture")]
            public static extern IntPtr NewEmpty();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Capture_New")]
            public static extern IntPtr New();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Capture_DownCast")]
            public static extern IntPtr Downcast(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Capture")]
            public static extern void Delete(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Capture_Assign")]
            public static extern IntPtr Assign(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Capture_Start_1")]
            public static extern void Start1(HandleRef jarg0, HandleRef jarg1, HandleRef jarg2, string jarg3, HandleRef jarg4);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Capture_Start_2")]
            public static extern void Start2(HandleRef capture, HandleRef source, HandleRef size, string path);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Capture_Signal_Empty")]
            public static extern bool SignalEmpty(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Capture_Signal_GetConnectionCount")]
            public static extern uint SignalGetConnectionCount(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Capture_Signal_Connect")]
            public static extern void SignalConnect(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Capture_Signal_Disconnect")]
            public static extern void SignalDisconnect(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Capture_Signal_Emit")]
            public static extern void SignalEmit(HandleRef jarg1, HandleRef jarg2, int jarg3);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Capture_Signal")]
            public static extern IntPtr NewSignal();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Capture_Signal")]
            public static extern void DeleteSignal(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Capture_Signal_Get")]
            public static extern IntPtr Get(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Capture_GetNativeImageSource")]
            public static extern IntPtr GetNativeImageSourcePtr(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Capture_GenerateUrl")]
            public static extern string GenerageUrl(HandleRef capture);

        }
    }
}
