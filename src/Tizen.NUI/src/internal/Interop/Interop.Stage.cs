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
        internal static partial class Stage
        {
            static Stage()
            {
            }

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Stage_GetCurrent")]
            public static extern global::System.IntPtr GetCurrent();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Stage_IsInstalled")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool IsInstalled();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Stage_GetRenderTaskList")]
            public static extern global::System.IntPtr GetRenderTaskList(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Stage_GetDpi")]
            public static extern global::System.IntPtr GetDpi(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Stage_SetRenderingBehavior")]
            public static extern void SetRenderingBehavior(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Stage_GetRenderingBehavior")]
            public static extern int GetRenderingBehavior(global::System.Runtime.InteropServices.HandleRef jarg1);
        }
    }
}
