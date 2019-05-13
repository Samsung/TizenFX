using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class Adaptor
        {

            //For Adaptor
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Adaptor_New__SWIG_0")]
            public static extern global::System.IntPtr Adaptor_New__SWIG_0(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Adaptor_New__SWIG_1")]
            public static extern global::System.IntPtr Adaptor_New__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Adaptor_New__SWIG_2")]
            public static extern global::System.IntPtr Adaptor_New__SWIG_2(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Adaptor_New__SWIG_3")]
            public static extern global::System.IntPtr Adaptor_New__SWIG_3(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Adaptor")]
            public static extern void delete_Adaptor(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Adaptor_Start")]
            public static extern void Adaptor_Start(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Adaptor_Pause")]
            public static extern void Adaptor_Pause(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Adaptor_Resume")]
            public static extern void Adaptor_Resume(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Adaptor_Stop")]
            public static extern void Adaptor_Stop(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Adaptor_AddIdle")]
            public static extern bool Adaptor_AddIdle(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Adaptor_RemoveIdle")]
            public static extern void Adaptor_RemoveIdle(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Adaptor_ReplaceSurface")]
            public static extern void Adaptor_ReplaceSurface(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Adaptor_GetSurface")]
            public static extern global::System.IntPtr Adaptor_GetSurface(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Adaptor_GetNativeWindowHandle")]
            public static extern global::System.IntPtr Adaptor_GetNativeWindowHandle(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Adaptor_ReleaseSurfaceLock")]
            public static extern void Adaptor_ReleaseSurfaceLock(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Adaptor_SetRenderRefreshRate")]
            public static extern void Adaptor_SetRenderRefreshRate(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Adaptor_SetUseHardwareVSync")]
            public static extern void Adaptor_SetUseHardwareVSync(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Adaptor_Get")]
            public static extern global::System.IntPtr Adaptor_Get();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Adaptor_IsAvailable")]
            public static extern bool Adaptor_IsAvailable();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Adaptor_NotifySceneCreated")]
            public static extern void Adaptor_NotifySceneCreated(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Adaptor_NotifyLanguageChanged")]
            public static extern void Adaptor_NotifyLanguageChanged(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Adaptor_FeedTouchPoint")]
            public static extern void Adaptor_FeedTouchPoint(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, int jarg3);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Adaptor_FeedWheelEvent")]
            public static extern void Adaptor_FeedWheelEvent(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Adaptor_FeedKeyEvent")]
            public static extern void Adaptor_FeedKeyEvent(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Adaptor_SceneCreated")]
            public static extern void Adaptor_SceneCreated(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Adaptor_ResizedSignal")]
            public static extern global::System.IntPtr Adaptor_ResizedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Adaptor_LanguageChangedSignal")]
            public static extern global::System.IntPtr Adaptor_LanguageChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            //Adaptor Signal Type
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AdaptorSignalType_Empty")]
            public static extern bool AdaptorSignalType_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AdaptorSignalType_GetConnectionCount")]
            public static extern uint AdaptorSignalType_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AdaptorSignalType_Connect")]
            public static extern void AdaptorSignalType_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AdaptorSignalType_Disconnect")]
            public static extern void AdaptorSignalType_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AdaptorSignalType_Emit")]
            public static extern void AdaptorSignalType_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_AdaptorSignalType")]
            public static extern global::System.IntPtr new_AdaptorSignalType();


            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_AdaptorSignalType")]
            public static extern void delete_AdaptorSignalType(global::System.Runtime.InteropServices.HandleRef jarg1);

        }
    }
}
