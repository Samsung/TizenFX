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

using System;
using System.Runtime.InteropServices;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class Accessibility
        {
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "csharp_dali_accessibility_get_status")]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool GetStatus(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "csharp_dali_accessibility_say")]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool Say(HandleRef jarg1, string jarg2, bool jarg3, IntPtr jarg4);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "csharp_dali_accessibility_pause_resume")]
            public static extern void PauseResume(HandleRef jarg1, bool jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "csharp_dali_accessibility_stop_reading")]
            public static extern void StopReading(HandleRef jarg1, bool jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "csharp_dali_accessibility_suppress_screen_reader")]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool SuppressScreenReader(HandleRef jarg1, bool jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "csharp_dali_accessibility_BridgeEnableAutoInit")]
            public static extern void BridgeEnableAutoInit();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "csharp_dali_accessibility_BridgeDisableAutoInit")]
            public static extern void BridgeDisableAutoInit();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "csharp_dali_accessibility_IsEnabled")]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool IsEnabled();

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            public delegate void EnabledDisabledSignalHandler();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "csharp_dali_accessibility_RegisterEnabledDisabledSignalHandler")]
            public static extern void RegisterEnabledDisabledSignalHandler(EnabledDisabledSignalHandler enabledSignalHandler, EnabledDisabledSignalHandler disabledSignalHandler);
        }
    }
}
