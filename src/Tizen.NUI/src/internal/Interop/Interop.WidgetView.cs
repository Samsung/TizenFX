/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using global::System;
using global::System.Runtime.InteropServices;
using global::System.Runtime.InteropServices.Marshalling;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class WidgetView
        {
            //for widget view
            [LibraryImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_WidgetView_Property_WIDGET_ID_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int WidgetIdGet();

            [LibraryImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_WidgetView_Property_INSTANCE_ID_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int InstanceIdGet();

            [LibraryImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_WidgetView_Property_CONTENT_INFO_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ContentInfoGet();

            [LibraryImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_WidgetView_Property_TITLE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int TitleGet();

            [LibraryImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_WidgetView_Property_UPDATE_PERIOD_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int UpdatePeriodGet();

            [LibraryImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_WidgetView_Property_PREVIEW_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int PreviewGet();

            [LibraryImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_WidgetView_Property_LOADING_TEXT_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int LoadingTextGet();

            [LibraryImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_WidgetView_Property_WIDGET_STATE_FAULTED_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int WidgetStateFaultedGet();

            [LibraryImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_WidgetView_Property_PERMANENT_DELETE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int PermanentDeleteGet();

            [LibraryImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_WidgetView_Property_RETRY_TEXT_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int RetryTextGet();

            [LibraryImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_WidgetView_Property_EFFECT_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int EffectGet();

            [LibraryImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_WidgetView_Property_KEEP_WIDGET_SIZE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int KeepWidgetSizeGet();

            [LibraryImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_WidgetView_New", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New(string jarg1, string jarg2, int jarg3, int jarg4, float jarg5);

            [LibraryImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_WidgetView_DownCast", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr DownCast(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_new_WidgetView__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewWidgetView(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_WidgetView_Assign", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Assign(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_delete_WidgetView", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteWidgetView(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_WidgetView_PauseWidget", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool PauseWidget(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_WidgetView_ResumeWidget", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool ResumeWidget(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_WidgetView_CancelTouchEvent", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool CancelTouchEvent(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_WidgetView_ActivateFaultedWidget", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ActivateFaultedWidget(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_WidgetView_TerminateWidget", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool TerminateWidget(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_WidgetView_WidgetAddedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr WidgetAddedSignal(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_WidgetView_WidgetDeletedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr WidgetDeletedSignal(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_WidgetView_WidgetCreationAbortedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr WidgetCreationAbortedSignal(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_WidgetView_WidgetContentUpdatedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr WidgetContentUpdatedSignal(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_WidgetView_WidgetUpdatePeriodChangedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr WidgetUpdatePeriodChangedSignal(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_WidgetView_WidgetFaultedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr WidgetFaultedSignal(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_WidgetViewSignal_Empty", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool WidgetViewSignalEmpty(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_WidgetViewSignal_GetConnectionCount", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint WidgetViewSignalGetConnectionCount(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_WidgetViewSignal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void WidgetViewSignalConnect(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_WidgetViewSignal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void WidgetViewSignalDisconnect(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_WidgetViewSignal_Emit", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void WidgetViewSignalEmit(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_new_WidgetViewSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewWidgetViewSignal();

            [LibraryImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_delete_WidgetViewSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteWidgetViewSignal(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_WidgetView_PauseWidget", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool WidgetView_PauseWidget(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_WidgetView_ResumeWidget", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool WidgetView_ResumeWidget(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_WidgetView_TerminateWidget", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool WidgetView_TerminateWidget(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_delete_WidgetView", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void delete_WidgetView(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_WidgetView_SWIGUpcast", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr WidgetView_SWIGUpcast(global::System.IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_WidgetView_WidgetAddedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr WidgetView_WidgetAddedSignal(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_WidgetView_WidgetDeletedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr WidgetView_WidgetDeletedSignal(IntPtr jarg1);
        }
    }
}





