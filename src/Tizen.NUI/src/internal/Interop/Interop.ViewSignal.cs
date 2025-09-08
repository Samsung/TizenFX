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
        internal static partial class ViewSignal
        {
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_KeyEventSignal_Connect")]
            public static extern void KeyEventConnect(HandleRef view, HandleRef handler);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_KeyEventSignal_Disconnect")]
            public static extern void KeyEventDisconnect(HandleRef view, HandleRef handler);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_KeyInputFocusGainedSignal_Connect")]
            public static extern void KeyInputFocusGainedConnect(HandleRef view, HandleRef handler);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_KeyInputFocusGainedSignal_Disconnect")]
            public static extern void KeyInputFocusGainedDisconnect(HandleRef view, HandleRef handler);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_KeyInputFocusLostSignal_Connect")]
            public static extern void KeyInputFocusLostConnect(HandleRef view, HandleRef handler);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_KeyInputFocusLostSignal_Disconnect")]
            public static extern void KeyInputFocusLostDisconnect(HandleRef view, HandleRef handler);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_ResourceReadySignal_Connect")]
            public static extern void ResourceReadyConnect(HandleRef view, HandleRef handler);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_ResourceReadySignal_Disconnect")]
            public static extern void ResourceReadyDisconnect(HandleRef view, HandleRef handler);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_OffScreenRenderingFinishedSignal_Connect")]
            public static extern void OffScreenRenderingFinishedConnect(HandleRef view, HandleRef handler);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_OffScreenRenderingFinishedSignal_Disconnect")]
            public static extern void OffScreenRenderingFinishedDisconnect(HandleRef view, HandleRef handler);
        }
    }
}
