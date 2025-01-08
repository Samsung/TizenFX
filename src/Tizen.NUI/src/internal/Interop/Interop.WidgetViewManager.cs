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

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class WidgetViewManager
        {
            // For widget view manager
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_WidgetViewManager_New")]
            public static extern global::System.IntPtr New(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_WidgetViewManager_DownCast")]
            public static extern global::System.IntPtr DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_new_WidgetViewManager__SWIG_1")]
            public static extern global::System.IntPtr NewWidgetViewManager(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_WidgetViewManager_Assign")]
            public static extern global::System.IntPtr Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_delete_WidgetViewManager")]
            public static extern void DeleteWidgetViewManager(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_WidgetViewManager_AddWidget")]
            public static extern global::System.IntPtr AddWidget(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, string jarg3, int jarg4, int jarg5, float jarg6);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_WidgetViewManager_RemoveWidget")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool RemoveWidget(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_WidgetViewManager_SWIGUpcast")]
            public static extern global::System.IntPtr Upcast(global::System.IntPtr jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.WidgetViewerLib, EntryPoint = "CSharp_Dali_WidgetViewManager_New")]
            public static extern global::System.IntPtr WidgetViewManager_New(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);
        }
    }
}
