/*
 * Copyright(c) 2023 Samsung Electronics Co., Ltd.
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
        internal static partial class WindowData
        {
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_WindowData")]
            public static extern global::System.IntPtr New();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_WindowData")]
            public static extern void DeleteWindowData(HandleRef nuiWindowData);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WindowData_SetPositionSize")]
            public static extern void SetPositionSize(HandleRef nuiWindowData, HandleRef nuiPositionSize);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WindowData_GetPositionSize")]
            public static extern global::System.IntPtr GetPositionSize(HandleRef nuiWindowData);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WindowData_SetWindowType")]
            public static extern void SetWindowType(HandleRef nuiWindowData, int nuiWindowType);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WindowData_GetWindowType")]
            public static extern int GetWindowType(HandleRef nuiWindowData);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WindowData_SetTransparency")]
            public static extern void SetTransparency(HandleRef nuiWindowData, bool nuiTransparency);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WindowData_GetTransparency")]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool GetTransparency(HandleRef nuiWindowData);
        }
    }
}