/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
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
        internal static class AccessibilitySignal
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityDoGestureSignal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AccessibilityDoGestureConnect(BaseComponents.View.ControlHandle jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityDoGestureSignal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AccessibilityDoGestureDisconnect(BaseComponents.View.ControlHandle jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityGetNameSignal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AccessibilityGetNameConnect(BaseComponents.View.ControlHandle jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityGetNameSignal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AccessibilityGetNameDisconnect(BaseComponents.View.ControlHandle jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityGetNameSignal_Empty", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool AccessibilityGetNameEmpty(BaseComponents.View.ControlHandle jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityGetDescriptionSignal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AccessibilityGetDescriptionConnect(BaseComponents.View.ControlHandle jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityGetDescriptionSignal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AccessibilityGetDescriptionDisconnect(BaseComponents.View.ControlHandle jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityActivateSignal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AccessibilityActivateConnect(BaseComponents.View.ControlHandle jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityActivateSignal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AccessibilityActivateDisconnect(BaseComponents.View.ControlHandle jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityActivateSignal_Empty", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool AccessibilityActivateEmpty(BaseComponents.View.ControlHandle jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityActivateSignal_Emit", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AccessibilityActivateEmit(BaseComponents.View.ControlHandle jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityReadingSkippedSignal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AccessibilityReadingSkippedConnect(BaseComponents.View.ControlHandle jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityReadingSkippedSignal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AccessibilityReadingSkippedDisconnect(BaseComponents.View.ControlHandle jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityReadingSkippedSignal_Empty", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool AccessibilityReadingSkippedEmpty(BaseComponents.View.ControlHandle jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityReadingSkippedSignal_Emit", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AccessibilityReadingSkippedEmit(BaseComponents.View.ControlHandle jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityReadingPausedSignal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AccessibilityReadingPausedConnect(BaseComponents.View.ControlHandle jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityReadingPausedSignal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AccessibilityReadingPausedDisconnect(BaseComponents.View.ControlHandle jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityReadingPausedSignal_Empty", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool AccessibilityReadingPausedEmpty(BaseComponents.View.ControlHandle jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityReadingPausedSignal_Emit", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AccessibilityReadingPausedEmit(BaseComponents.View.ControlHandle jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityReadingResumedSignal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AccessibilityReadingResumedConnect(BaseComponents.View.ControlHandle jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityReadingResumedSignal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AccessibilityReadingResumedDisconnect(BaseComponents.View.ControlHandle jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityReadingResumedSignal_Empty", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool AccessibilityReadingResumedEmpty(BaseComponents.View.ControlHandle jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityReadingResumedSignal_Emit", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AccessibilityReadingResumedEmit(BaseComponents.View.ControlHandle jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityReadingCancelledSignal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AccessibilityReadingCancelledConnect(BaseComponents.View.ControlHandle jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityReadingCancelledSignal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AccessibilityReadingCancelledDisconnect(BaseComponents.View.ControlHandle jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityReadingCancelledSignal_Empty", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool AccessibilityReadingCancelledEmpty(BaseComponents.View.ControlHandle jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityReadingCancelledSignal_Emit", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AccessibilityReadingCancelledEmit(BaseComponents.View.ControlHandle jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityReadingStoppedSignal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AccessibilityReadingStoppedConnect(BaseComponents.View.ControlHandle jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityReadingStoppedSignal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AccessibilityReadingStoppedDisconnect(BaseComponents.View.ControlHandle jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityReadingStoppedSignal_Empty", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool AccessibilityReadingStoppedEmpty(BaseComponents.View.ControlHandle jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityReadingStoppedSignal_Emit", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AccessibilityReadingStoppedEmit(BaseComponents.View.ControlHandle jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityActionSignal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AccessibilityActionConnect(BaseComponents.View.ControlHandle jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityActionSignal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AccessibilityActionDisconnect(BaseComponents.View.ControlHandle jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityHighlightedSignal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AccessibilityHighlightedConnect(BaseComponents.View.ControlHandle jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Toolkit_DevelControl_AccessibilityHighlightedSignal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AccessibilityHighlightedDisconnect(BaseComponents.View.ControlHandle jarg1, IntPtr jarg2);
        }
    }
}





