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
        internal static partial class FocusManager
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_new_KeyboardFocusManager", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewFocusManager();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_KeyboardFocusManager_Get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Get();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_KeyboardFocusManager_SetCurrentFocusActor", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool SetCurrentFocusActor(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_KeyboardFocusManager_GetCurrentFocusActor", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetCurrentFocusActor(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_KeyboardFocusManager_MoveFocus", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool MoveFocus(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_KeyboardFocusManager_ClearFocus", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ClearFocus(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_KeyboardFocusManager_SetFocusGroupLoop", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetFocusGroupLoop(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_KeyboardFocusManager_GetFocusGroupLoop", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool GetFocusGroupLoop(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_KeyboardFocusManager_SetAsFocusGroup", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetAsFocusGroup(IntPtr jarg1, IntPtr jarg2, [MarshalAs(UnmanagedType.U1)] bool jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_KeyboardFocusManager_IsFocusGroup", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsFocusGroup(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_KeyboardFocusManager_GetFocusGroup", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetFocusGroup(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_KeyboardFocusManager_SetFocusIndicatorActor", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetFocusIndicatorActor(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_KeyboardFocusManager_GetFocusIndicatorActor", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetFocusIndicatorActor(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_KeyboardFocusManager_MoveFocusBackward", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void MoveFocusBackward(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_KeyboardFocusManager_PreFocusChangeSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr PreFocusChangeSignal(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_KeyboardFocusManager_FocusChangedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr FocusChangedSignal(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_KeyboardFocusManager_FocusGroupChangedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr FocusGroupChangedSignal(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_KeyboardFocusManager_FocusedActorEnterKeySignal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void FocusedActorEnterKeySignalConnect(IntPtr focusManager, IntPtr handler);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_KeyboardFocusManager_FocusedActorEnterKeySignal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void FocusedActorEnterKeySignalDisconnect(IntPtr focusManager, IntPtr handler);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_KeyboardFocusManager_EnableDefaultAlgorithm", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void EnableDefaultAlgorithm(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_KeyboardFocusManager_IsDefaultAlgorithmEnabled", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsDefaultAlgorithmEnabled(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_KeyboardFocusManager_GetNearestFocusableActor", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetNearestFocusableActor(IntPtr rootView, IntPtr currentView, int direction);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_KeyboardFocusManager_SetFocusFinderRootActor", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetFocusFinderRootView(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_KeyboardFocusManager_ResetFocusFinderRootActor", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ResetFocusFinderRootView(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_KeyboardFocusManager_EnableFocusIndicator", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void EnableFocusIndicator(IntPtr focusManager, [MarshalAs(UnmanagedType.U1)] bool enable);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_KeyboardFocusManager_IsFocusIndicatorEnabled", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsFocusIndicatorEnabled(IntPtr focusManager);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_KeyboardFocusManager_GetLastFocusChangeDevice", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetLastFocusChangeDevice(IntPtr focusManager);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_KeyboardFocusManager_GetLastFocusChangeDeviceName", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string GetLastFocusChangeDeviceName(IntPtr focusManager);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_KeyboardFocusManager_SetClearFocusOnWindowFocusLost", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetClearFocusOnWindowFocusLost(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_KeyboardFocusManager_GetClearFocusOnWindowFocusLost", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool GetClearFocusOnWindowFocusLost(IntPtr jarg1);
        }
    }
}





