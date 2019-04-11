using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class WidgetView
        {
            //for widget view
            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetView_Property_WIDGET_ID_get")]
            public static extern int WidgetView_Property_WIDGET_ID_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetView_Property_INSTANCE_ID_get")]
            public static extern int WidgetView_Property_INSTANCE_ID_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetView_Property_CONTENT_INFO_get")]
            public static extern int WidgetView_Property_CONTENT_INFO_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetView_Property_TITLE_get")]
            public static extern int WidgetView_Property_TITLE_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetView_Property_UPDATE_PERIOD_get")]
            public static extern int WidgetView_Property_UPDATE_PERIOD_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetView_Property_PREVIEW_get")]
            public static extern int WidgetView_Property_PREVIEW_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetView_Property_LOADING_TEXT_get")]
            public static extern int WidgetView_Property_LOADING_TEXT_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetView_Property_WIDGET_STATE_FAULTED_get")]
            public static extern int WidgetView_Property_WIDGET_STATE_FAULTED_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetView_Property_PERMANENT_DELETE_get")]
            public static extern int WidgetView_Property_PERMANENT_DELETE_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetView_Property_RETRY_TEXT_get")]
            public static extern int WidgetView_Property_RETRY_TEXT_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetView_Property_EFFECT_get")]
            public static extern int WidgetView_Property_EFFECT_get();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_WidgetView_Property")]
            public static extern global::System.IntPtr new_WidgetView_Property();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_WidgetView_Property")]
            public static extern void delete_WidgetView_Property(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetView_New")]
            public static extern global::System.IntPtr WidgetView_New(string jarg1, string jarg2, int jarg3, int jarg4, float jarg5);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetView_DownCast")]
            public static extern global::System.IntPtr WidgetView_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_WidgetView__SWIG_0")]
            public static extern global::System.IntPtr new_WidgetView__SWIG_0();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_WidgetView__SWIG_1")]
            public static extern global::System.IntPtr new_WidgetView__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetView_Assign")]
            public static extern global::System.IntPtr WidgetView_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_WidgetView")]
            public static extern void delete_WidgetView(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetView_PauseWidget")]
            public static extern bool WidgetView_PauseWidget(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetView_ResumeWidget")]
            public static extern bool WidgetView_ResumeWidget(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetView_CancelTouchEvent")]
            public static extern bool WidgetView_CancelTouchEvent(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetView_ActivateFaultedWidget")]
            public static extern void WidgetView_ActivateFaultedWidget(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetView_TerminateWidget")]
            public static extern bool WidgetView_TerminateWidget(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetView_WidgetAddedSignal")]
            public static extern global::System.IntPtr WidgetView_WidgetAddedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetView_WidgetDeletedSignal")]
            public static extern global::System.IntPtr WidgetView_WidgetDeletedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetView_WidgetCreationAbortedSignal")]
            public static extern global::System.IntPtr WidgetView_WidgetCreationAbortedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetView_WidgetContentUpdatedSignal")]
            public static extern global::System.IntPtr WidgetView_WidgetContentUpdatedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetView_WidgetUpdatePeriodChangedSignal")]
            public static extern global::System.IntPtr WidgetView_WidgetUpdatePeriodChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetView_WidgetFaultedSignal")]
            public static extern global::System.IntPtr WidgetView_WidgetFaultedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetViewSignal_Empty")]
            public static extern bool WidgetViewSignal_Empty(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetViewSignal_GetConnectionCount")]
            public static extern uint WidgetViewSignal_GetConnectionCount(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetViewSignal_Connect")]
            public static extern void WidgetViewSignal_Connect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetViewSignal_Disconnect")]
            public static extern void WidgetViewSignal_Disconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetViewSignal_Emit")]
            public static extern void WidgetViewSignal_Emit(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_new_WidgetViewSignal")]
            public static extern global::System.IntPtr new_WidgetViewSignal();


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_delete_WidgetViewSignal")]
            public static extern void delete_WidgetViewSignal(global::System.Runtime.InteropServices.HandleRef jarg1);


            [global::System.Runtime.InteropServices.DllImport("libdali-csharp-binder.so", EntryPoint = "CSharp_Dali_WidgetView_SWIGUpcast")]
            public static extern global::System.IntPtr WidgetView_SWIGUpcast(global::System.IntPtr jarg1);

        }
    }
}
