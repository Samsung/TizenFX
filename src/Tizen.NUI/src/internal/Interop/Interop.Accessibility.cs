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

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class Accessibility
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "csharp_dali_accessibility_get_status")]
            public static extern bool accessibility_get_status(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "csharp_dali_accessibility_say")]
            public static extern bool accessibility_say(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, bool jarg3, global::System.IntPtr jarg4);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "csharp_dali_accessibility_pause_resume")]
            public static extern void accessibility_pause_resume(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "csharp_dali_accessibility_IsUp")]
            public static extern bool accessibility_IsUp(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "csharp_dali_accessibility_Enable")]
            public static extern void accessibility_Enable(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "csharp_dali_accessibility_IsScreenReaderEnabled")]
            public static extern bool accessibility_IsScreenReaderEnabled(global::System.Runtime.InteropServices.HandleRef jarg1);

        }
    }
}
