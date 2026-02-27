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
        internal static partial class WidgetViewManager
        {
            // For widget view manager
            [LibraryImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_WidgetViewManager_New", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_WidgetViewManager_DownCast", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr DownCast(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_new_WidgetViewManager__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewWidgetViewManager(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_WidgetViewManager_Assign", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Assign(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_delete_WidgetViewManager", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteWidgetViewManager(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_WidgetViewManager_AddWidget", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr AddWidget(IntPtr jarg1, string jarg2, string jarg3, int jarg4, int jarg5, float jarg6);

            [LibraryImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_WidgetViewManager_RemoveWidget", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool RemoveWidget(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_WidgetViewManager_SWIGUpcast", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Upcast(global::System.IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_WidgetViewManager_New", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr WidgetViewManager_New(IntPtr jarg1, string jarg2);
        }
    }
}





