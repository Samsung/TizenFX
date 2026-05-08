/*
 * Copyright(c) 2026 Samsung Electronics Co., Ltd.
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
        internal static partial class UiContext
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_UiContext_Get")]
            public static extern global::System.IntPtr Get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_UiContext")]
            public static extern void DeleteUiContext(global::System.Runtime.InteropServices.HandleRef uiContext);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_UiContext_GetDefaultWindow")]
            public static extern global::System.IntPtr GetDefaultWindow(global::System.Runtime.InteropServices.HandleRef uiContext);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_UiContext_AddIdle")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool AddIdle(global::System.Runtime.InteropServices.HandleRef uiContext, global::System.Runtime.InteropServices.HandleRef callback);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_UiContext_RemoveIdle")]
            public static extern void RemoveIdle(global::System.Runtime.InteropServices.HandleRef uiContext, global::System.Runtime.InteropServices.HandleRef callback);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_UiContext_FlushUpdateMessages")]
            public static extern void FlushUpdateMessages(global::System.Runtime.InteropServices.HandleRef uiContext);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_UiContext_SetApplicationLocale")]
            public static extern void SetApplicationLocale(global::System.Runtime.InteropServices.HandleRef uiContext, string locale);
        }
    }
}
