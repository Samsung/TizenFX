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
using System.Runtime.InteropServices;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class ActorSignal
        {
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_HitTestResultSignal_Connect")]
            public static extern void HitTestResultConnect(HandleRef actor, HandleRef handler);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_HitTestResultSignal_Disconnect")]
            public static extern void HitTestResultDisconnect(HandleRef actor, HandleRef handler);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_InterceptTouchedSignal_Connect")]
            public static extern void InterceptTouchConnect(HandleRef actor, HandleRef handler);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_InterceptTouchedSignal_Disconnect")]
            public static extern void InterceptTouchDisconnect(HandleRef actor, HandleRef handler);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_TouchedSignal_Connect")]
            public static extern void TouchConnect(HandleRef actor, HandleRef handler);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_TouchedSignal_Disconnect")]
            public static extern void TouchDisconnect(HandleRef actor, HandleRef handler);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_HoveredSignal_Connect")]
            public static extern void HoveredConnect(HandleRef actor, HandleRef handler);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_HoveredSignal_Disconnect")]
            public static extern void HoveredDisconnect(HandleRef actor, HandleRef handler);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_WheelEventSignal_Connect")]
            public static extern void WheelEventConnect(HandleRef actor, HandleRef handler);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_WheelEventSignal_Disconnect")]
            public static extern void WheelEventDisconnect(HandleRef actor, HandleRef handler);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_OnSceneSignal_Connect")]
            public static extern void OnSceneConnect(HandleRef actor, HandleRef handler);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_OnSceneSignal_Disconnect")]
            public static extern void OnSceneDisconnect(HandleRef actor, HandleRef handler);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_OffSceneSignal_Connect")]
            public static extern void OffSceneConnect(HandleRef actor, HandleRef handler);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_OffSceneSignal_Disconnect")]
            public static extern void OffSceneDisconnect(HandleRef actor, HandleRef handler);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_OnRelayoutSignal_Connect")]
            public static extern void OnRelayoutConnect(HandleRef actor, HandleRef hanlder);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_OnRelayoutSignal_Disconnect")]
            public static extern void OnRelayoutDisconnect(HandleRef actor, HandleRef hanlder);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_VisibilityChangedSignal_Connect")]
            public static extern void VisibilityChangedConnect(HandleRef actor, HandleRef handler);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_VisibilityChangedSignal_Disonnect")]
            public static extern void VisibilityChangedDisconnect(HandleRef actor, HandleRef handler);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_LayoutDirectionChangedSignal_Connect")]
            public static extern void LayoutDirectionChangedConnect(HandleRef actor, HandleRef handler);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Actor_LayoutDirectionChangedSignal_Disconnect")]
            public static extern void LayoutDirectionChangedDisconnect(HandleRef actor, HandleRef handler);
        }
    }
}
