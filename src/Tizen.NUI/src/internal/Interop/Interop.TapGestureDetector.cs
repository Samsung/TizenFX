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

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class TapGestureDetector
        {

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TapGestureDetector_New__SWIG_0")]
            public static extern global::System.IntPtr New();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TapGestureDetector_New__SWIG_1")]
            public static extern global::System.IntPtr New(uint jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_TapGestureDetector")]
            public static extern void DeleteTapGestureDetector(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_TapGestureDetector__SWIG_1")]
            public static extern global::System.IntPtr NewTapGestureDetector(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TapGestureDetector_Assign")]
            public static extern global::System.IntPtr Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TapGestureDetector_SetMinimumTapsRequired")]
            public static extern void SetMinimumTapsRequired(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TapGestureDetector_SetMaximumTapsRequired")]
            public static extern void SetMaximumTapsRequired(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TapGestureDetector_GetMinimumTapsRequired")]
            public static extern uint GetMinimumTapsRequired(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TapGestureDetector_GetMaximumTapsRequired")]
            public static extern uint GetMaximumTapsRequired(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TapGestureDetector_DetectedSignal")]
            public static extern global::System.IntPtr DetectedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_TapGestureDetector_Options")]
            public static extern global::System.IntPtr NewOptions();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_TapGestureDetector_Options")]
            public static extern void DeleteOptions(global::System.Runtime.InteropServices.HandleRef nuiOptions);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TapGestureDetector_GetDefaultOptions")]
            public static extern global::System.IntPtr GetDefaultOptions(global::System.Runtime.InteropServices.HandleRef nuiDetector);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TapGestureDetector_SetDeviceOptions")]
            public static extern void SetDeviceOptions(global::System.Runtime.InteropServices.HandleRef nuiDetector, global::System.Runtime.InteropServices.HandleRef nuiSelector, global::System.Runtime.InteropServices.HandleRef nuiOptions);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TapGestureDetector_GetDeviceOptions")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool GetDeviceOptions(global::System.Runtime.InteropServices.HandleRef nuiDetector, global::System.Runtime.InteropServices.HandleRef nuiSelector, global::System.Runtime.InteropServices.HandleRef nuiOptions);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TapGestureDetector_ClearDeviceOptions")]
            public static extern void ClearDeviceOptions(global::System.Runtime.InteropServices.HandleRef nuiDetector, global::System.Runtime.InteropServices.HandleRef nuiSelector);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TapGestureDetector_Options_SetMinimumTapsRequired")]
            public static extern void OptionsSetMinimumTapsRequired(global::System.Runtime.InteropServices.HandleRef nuiOptions, uint value);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TapGestureDetector_Options_GetMinimumTapsRequired")]
            public static extern uint OptionsGetMinimumTapsRequired(global::System.Runtime.InteropServices.HandleRef nuiOptions);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TapGestureDetector_Options_SetMaximumTapsRequired")]
            public static extern void OptionsSetMaximumTapsRequired(global::System.Runtime.InteropServices.HandleRef nuiOptions, uint value);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TapGestureDetector_Options_GetMaximumTapsRequired")]
            public static extern uint OptionsGetMaximumTapsRequired(global::System.Runtime.InteropServices.HandleRef nuiOptions);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TapGestureDetector_Options_SetReceiveAllTapEventsEnabled")]
            public static extern void OptionsSetReceiveAllTapEventsEnabled(global::System.Runtime.InteropServices.HandleRef nuiOptions, bool value);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TapGestureDetector_Options_IsReceiveAllTapEventsEnabled")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool OptionsIsReceiveAllTapEventsEnabled(global::System.Runtime.InteropServices.HandleRef nuiOptions);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TapGestureDetector_ReceiveAllTapEvents")]
            public static extern void ReceiveAllTapEvents(global::System.Runtime.InteropServices.HandleRef nuiDetector, bool receive);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TapGestureDetector_IsReceiveAllTapEventsEnabled")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool IsReceiveAllTapEventsEnabled(global::System.Runtime.InteropServices.HandleRef nuiDetector);
        }
    }
}
