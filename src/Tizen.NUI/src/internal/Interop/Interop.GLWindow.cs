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
        internal static partial class GLWindow
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_New__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GlWindowNew();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_New__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GlWindowNew(IntPtr jarg1, string jarg2, string jarg3, [MarshalAs(UnmanagedType.U1)] bool jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_SetGraphicsConfig", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GlWindowSetGraphicsConfig(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2, [MarshalAs(UnmanagedType.U1)] bool jarg3, int jarg4, int jarg5);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_Raise", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GlWindowRaise(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_Lower", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GlWindowLower(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_Activate", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GlWindowActivate(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_Show", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GlWindowShow(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_Hide", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GlWindowHide(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_SetPositionSize", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GlWindowSetPositionSize(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_GetPositionSize", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GlWindowGetPositionSize(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_GetSupportedAuxiliaryHintCount", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GlWindowGetSupportedAuxiliaryHintCount(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_GetSupportedAuxiliaryHint", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string GlWindowGetSupportedAuxiliaryHint(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_AddAuxiliaryHint", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GlWindowAddAuxiliaryHint(IntPtr jarg1, string jarg2, string jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_RemoveAuxiliaryHint", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool GlWindowRemoveAuxiliaryHint(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_SetAuxiliaryHintValue", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool GlWindowSetAuxiliaryHintValue(IntPtr jarg1, uint jarg2, string jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_GetAuxiliaryHintValue", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string GlWindowGetAuxiliaryHintValue(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_GetAuxiliaryHintId", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GlWindowGetAuxiliaryHintId(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_SetInputRegion", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GlWindowSetInputRegion(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_SetOpaqueState", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GlWindowSetOpaqueState(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_IsOpaqueState", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool GlWindowIsOpaqueState(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_GetCurrentOrientation", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GlWindowGetCurrentOrientation(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_SetAvailableOrientations", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GlWindowSetAvailableOrientations(IntPtr jarg1, IntPtr jarg2, int jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_SetPreferredOrientation", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GlWindowSetPreferredOrientation(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_RegisterGlCallbacks", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GlWindowRegisterGlCallbacks(IntPtr jarg1, IntPtr jarg2, IntPtr jarg3, IntPtr jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_RenderOnce", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GlWindowRenderOnce(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_GetRenderingMode", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GlWindowGetRenderingMode(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_SetRenderingMode", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GlWindowSetRenderingMode(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_TouchedSignal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GlWindowTouchSignalConnect(IntPtr glWindow, IntPtr handler);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_TouchedSignal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GlWindowTouchSignalDisconnect(IntPtr glWindow, IntPtr handler);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_FocusChangedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GlWindowFocusChangedSignal(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_KeyEventSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GlWindowKeyEventSignal(IntPtr jarg1);

            // For windows resized signal
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_ResizedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GlWindowResizedSignal(IntPtr jarg1);

        }
    }
}



