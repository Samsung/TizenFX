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
        internal static partial class WidgetImpl
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WidgetImpl_SWIGUpcast")]
            public static extern global::System.IntPtr Upcast(global::System.IntPtr jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WidgetImpl_New")]
            public static extern global::System.IntPtr New();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WidgetImpl_OnCreate")]
            public static extern void OnCreate(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WidgetImpl_OnCreateSwigExplicitWidgetImpl")]
            public static extern void OnCreateSwigExplicitWidgetImpl(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WidgetImpl_OnTerminate")]
            public static extern void OnTerminate(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, int jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WidgetImpl_OnTerminateSwigExplicitWidgetImpl")]
            public static extern void OnTerminateSwigExplicitWidgetImpl(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, int jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WidgetImpl_OnPause")]
            public static extern void OnPause(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WidgetImpl_OnPauseSwigExplicitWidgetImpl")]
            public static extern void OnPauseSwigExplicitWidgetImpl(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WidgetImpl_OnResume")]
            public static extern void OnResume(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WidgetImpl_OnResumeSwigExplicitWidgetImpl")]
            public static extern void OnResumeSwigExplicitWidgetImpl(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WidgetImpl_OnResize")]
            public static extern void OnResize(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WidgetImpl_OnResizeSwigExplicitWidgetImpl")]
            public static extern void OnResizeSwigExplicitWidgetImpl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WidgetImpl_OnUpdate")]
            public static extern void OnUpdate(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, int jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WidgetImpl_OnUpdateSwigExplicitWidgetImpl")]
            public static extern void OnUpdateSwigExplicitWidgetImpl(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, int jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WidgetImpl_SignalConnected")]
            public static extern void SignalConnected(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WidgetImpl_SignalConnectedSwigExplicitWidgetImpl")]
            public static extern void SignalConnectedSwigExplicitWidgetImpl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WidgetImpl_SignalDisconnected")]
            public static extern void SignalDisconnected(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WidgetImpl_SignalDisconnectedSwigExplicitWidgetImpl")]
            public static extern void SignalDisconnectedSwigExplicitWidgetImpl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WidgetImpl_SetContentInfo")]
            public static extern void SetContentInfo(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WidgetImpl_SetImpl")]
            public static extern void SetImpl(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WidgetImpl_director_connect")]
            public static extern void DirectorConnect(global::System.Runtime.InteropServices.HandleRef jarg1, Tizen.NUI.WidgetImpl.SwigDelegateWidgetImpl_0 delegate0, Tizen.NUI.WidgetImpl.SwigDelegateWidgetImpl_1 delegate1,
                Tizen.NUI.WidgetImpl.SwigDelegateWidgetImpl_2 delegate2, Tizen.NUI.WidgetImpl.SwigDelegateWidgetImpl_3 delegate3, Tizen.NUI.WidgetImpl.SwigDelegateWidgetImpl_4 delegate4, Tizen.NUI.WidgetImpl.SwigDelegateWidgetImpl_5 delegate5,
                Tizen.NUI.WidgetImpl.SwigDelegateWidgetImpl_6 delegate6, Tizen.NUI.WidgetImpl.SwigDelegateWidgetImpl_7 delegate7);
        }
    }
}
