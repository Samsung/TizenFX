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
        internal static partial class ActorSignal
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_HitTestResultSignal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void HitTestResultConnect(IntPtr actor, IntPtr handler);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_HitTestResultSignal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void HitTestResultDisconnect(IntPtr actor, IntPtr handler);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_InterceptTouchedSignal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void InterceptTouchConnect(IntPtr actor, IntPtr handler);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_InterceptTouchedSignal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void InterceptTouchDisconnect(IntPtr actor, IntPtr handler);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_TouchedSignal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void TouchConnect(IntPtr actor, IntPtr handler);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_TouchedSignal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void TouchDisconnect(IntPtr actor, IntPtr handler);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_HoveredSignal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void HoveredConnect(IntPtr actor, IntPtr handler);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_HoveredSignal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void HoveredDisconnect(IntPtr actor, IntPtr handler);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_WheelEventSignal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void WheelEventConnect(IntPtr actor, IntPtr handler);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_WheelEventSignal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void WheelEventDisconnect(IntPtr actor, IntPtr handler);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_InterceptWheelSignal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void InterceptWheelConnect(IntPtr actor, IntPtr handler);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_InterceptWheelSignal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void InterceptWheelDisconnect(IntPtr actor, IntPtr handler);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_OnSceneSignal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void OnSceneConnect(IntPtr actor, IntPtr handler);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_OnSceneSignal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void OnSceneDisconnect(IntPtr actor, IntPtr handler);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_OffSceneSignal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void OffSceneConnect(IntPtr actor, IntPtr handler);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_OffSceneSignal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void OffSceneDisconnect(IntPtr actor, IntPtr handler);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_OnRelayoutSignal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void OnRelayoutConnect(IntPtr actor, IntPtr hanlder);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_OnRelayoutSignal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void OnRelayoutDisconnect(IntPtr actor, IntPtr hanlder);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_VisibilityChangedSignal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void VisibilityChangedConnect(IntPtr actor, IntPtr handler);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_VisibilityChangedSignal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void VisibilityChangedDisconnect(IntPtr actor, IntPtr handler);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_InheritedVisibilityChangedSignal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AggregatedVisibilityChangedConnect(IntPtr actor, IntPtr handler);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_InheritedVisibilityChangedSignal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AggregatedVisibilityChangedDisconnect(IntPtr actor, IntPtr handler);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_LayoutDirectionChangedSignal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void LayoutDirectionChangedConnect(IntPtr actor, IntPtr handler);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_LayoutDirectionChangedSignal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void LayoutDirectionChangedDisconnect(IntPtr actor, IntPtr handler);
        }
    }
}



