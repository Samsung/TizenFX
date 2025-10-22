/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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
        internal static partial class Accessibility
        {
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void SayCallback(string status);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "csharp_dali_accessibility_say")]
            public static extern void Say(string arg1_text, bool arg2_discardable, SayCallback arg3_callback);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "csharp_dali_accessibility_pause_resume")]
            public static extern void PauseResume(bool jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "csharp_dali_accessibility_stop_reading")]
            public static extern void StopReading(bool jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "csharp_dali_accessibility_suppress_screen_reader")]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool SuppressScreenReader(bool jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "csharp_dali_accessibility_BridgeEnableAutoInit")]
            public static extern void BridgeEnableAutoInit();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "csharp_dali_accessibility_BridgeDisableAutoInit")]
            public static extern void BridgeDisableAutoInit();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "csharp_dali_accessibility_IsEnabled")]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool IsEnabled();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "csharp_dali_accessibility_IsScreenReaderEnabled")]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool IsScreenReaderEnabled();

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void EnabledDisabledSignalHandler();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "csharp_dali_accessibility_RegisterEnabledDisabledSignalHandler")]
            public static extern void RegisterEnabledDisabledSignalHandler(EnabledDisabledSignalHandler enabledSignalHandler, EnabledDisabledSignalHandler disabledSignalHandler);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "csharp_dali_accessibility_RegisterScreenReaderEnabledDisabledSignalHandler")]
            public static extern void RegisterScreenReaderEnabledDisabledSignalHandler(EnabledDisabledSignalHandler enabledSignalHandler, EnabledDisabledSignalHandler disabledSignalHandler);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void AccessibilityRequestHandler();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "csharp_dali_accessibility_RegisterRequestHandler")]
            public static extern void RegisterAccessibilityRequestHandler(AccessibilityRequestHandler accessibilityRequestHandler);
        }
    }
}
