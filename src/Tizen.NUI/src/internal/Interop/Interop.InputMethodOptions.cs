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
        internal static partial class InputMethodOptions
        {
            //////////////////////InputMethodOptions
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_InputMethodOptions")]
            public static extern global::System.IntPtr NewInputMethodOptions();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodOptions_IsPassword")]
            public static extern bool IsPassword(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodOptions_ApplyProperty")]
            public static extern void ApplyProperty(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodOptions_RetrieveProperty")]
            public static extern void RetrieveProperty(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_InputMethodOptions_CompareAndSet")]
            public static extern bool CompareAndSet(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_InputMethodOptions")]
            public static extern void DeleteInputMethodOptions(global::System.Runtime.InteropServices.HandleRef jarg1);
        }
    }
}
