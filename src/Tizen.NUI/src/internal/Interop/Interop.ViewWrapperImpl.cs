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
        internal static partial class ViewWrapperImpl
        {

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewWrapperImpl_CONTROL_BEHAVIOUR_FLAG_COUNT_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ControlBehaviourFlagCountGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_ViewWrapperImpl", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewViewWrapperImpl(int jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewWrapperImpl_New", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New(string jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewWrapperImpl_director_connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DirectorConnect(IntPtr jarg1,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_0 delegate0, Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_1 delegate1,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_2 delegate2, Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_3 delegate3,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_4 delegate4, Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_5 delegate5,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_6 delegate6, Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_9 delegate9,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_11 delegate11,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_12 delegate12, Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_13 delegate13,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_14 delegate14, Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_15 delegate15,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_16 delegate16, Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_17 delegate17,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_18 delegate18, Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_19 delegate19,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_20 delegate20, Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_21 delegate21,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_24 delegate24, Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_25 delegate25,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_30 delegate30, Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_31 delegate31,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_32 delegate32, Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_33 delegate33,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_34 delegate34, Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_35 delegate35,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_36 delegate36, Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_37 delegate37,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_38 delegate38, Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_39 delegate39,
                Tizen.NUI.ViewWrapperImpl.DelegateViewWrapperImpl_40 delegate40);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ViewWrapperImpl_RelayoutRequest", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RelayoutRequest(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ViewWrapperImpl_GetHeightForWidthBase", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float GetHeightForWidthBase(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ViewWrapperImpl_GetWidthForHeightBase", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float GetWidthForHeightBase(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ViewWrapperImpl_CalculateChildSizeBase", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float CalculateChildSizeBase(IntPtr jarg1, IntPtr jarg2, int jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ViewWrapperImpl_RelayoutDependentOnChildrenBase__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool RelayoutDependentOnChildrenBase(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ViewWrapperImpl_RelayoutDependentOnChildrenBase__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool RelayoutDependentOnChildrenBase(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ViewWrapperImpl_RegisterVisual__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RegisterVisual(IntPtr jarg1, int jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ViewWrapperImpl_RegisterVisual__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RegisterVisual(IntPtr jarg1, int jarg2, IntPtr jarg3, [MarshalAs(UnmanagedType.U1)] bool jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ViewWrapperImpl_UnregisterVisual", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void UnregisterVisual(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ViewWrapperImpl_GetVisual", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetVisual(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ViewWrapperImpl_EnableVisual", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void EnableVisual(IntPtr jarg1, int jarg2, [MarshalAs(UnmanagedType.U1)] bool jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ViewWrapperImpl_IsVisualEnabled", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsVisualEnabled(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ViewWrapperImpl_CreateTransition", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr CreateTransition(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_ViewWrapperImpl_EmitKeyInputFocusSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void EmitKeyInputFocusSignal(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ViewWrapperImpl_ApplyThemeStyle", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ApplyThemeStyle(IntPtr jarg1);
        }
    }
}





