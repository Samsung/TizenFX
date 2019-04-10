using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class VideoView
        {

            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VideoView_Property_VIDEO_get")]
            public static extern int VideoView_Property_VIDEO_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VideoView_Property_LOOPING_get")]
            public static extern int VideoView_Property_LOOPING_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VideoView_Property_MUTED_get")]
            public static extern int VideoView_Property_MUTED_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VideoView_Property_VOLUME_get")]
            public static extern int VideoView_Property_VOLUME_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VideoView_Property_UNDERLAY_get")]
            public static extern int VideoView_Property_UNDERLAY_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_VideoView_Property")]
            public static extern global::System.IntPtr new_VideoView_Property();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_VideoView_Property")]
            public static extern void delete_VideoView_Property(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VideoView_New__SWIG_0")]
            public static extern global::System.IntPtr VideoView_New__SWIG_0();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VideoView_New__SWIG_1")]
            public static extern global::System.IntPtr VideoView_New__SWIG_1(string jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_VideoView__SWIG_0")]
            public static extern global::System.IntPtr new_VideoView__SWIG_0();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_VideoView")]
            public static extern void delete_VideoView(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_VideoView__SWIG_1")]
            public static extern global::System.IntPtr new_VideoView__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VideoView_Assign")]
            public static extern global::System.IntPtr VideoView_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VideoView_DownCast")]
            public static extern global::System.IntPtr VideoView_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VideoView_Play")]
            public static extern void VideoView_Play(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VideoView_Pause")]
            public static extern void VideoView_Pause(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VideoView_Stop")]
            public static extern void VideoView_Stop(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VideoView_Forward")]
            public static extern void VideoView_Forward(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VideoView_Backward")]
            public static extern void VideoView_Backward(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VideoView_FinishedSignal")]
            public static extern global::System.IntPtr VideoView_FinishedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VideoView_SWIGUpcast")]
            public static extern global::System.IntPtr VideoView_SWIGUpcast(global::System.IntPtr jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VideoViewSignal_Empty")]
            public static extern bool VideoViewSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VideoViewSignal_GetConnectionCount")]
            public static extern uint VideoViewSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VideoViewSignal_Connect")]
            public static extern void VideoViewSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VideoViewSignal_Disconnect")]
            public static extern void VideoViewSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_VideoViewSignal_Emit")]
            public static extern void VideoViewSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_VideoViewSignal")]
            public static extern global::System.IntPtr new_VideoViewSignal();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_VideoViewSignal")]
            public static extern void delete_VideoViewSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

        }
    }
}
