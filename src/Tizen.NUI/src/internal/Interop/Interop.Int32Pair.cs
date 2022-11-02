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
         internal static partial class Int32Pair
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Int32Pair__SWIG_0")]
            public static extern global::System.IntPtr NewInt32Pair();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Int32Pair__SWIG_1")]
            public static extern global::System.IntPtr NewInt32Pair(int x, int y);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Int32Pair_SetX")]
            public static extern void SetX(global::System.Runtime.InteropServices.HandleRef handle, int x);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Int32Pair_GetX")]
            public static extern int GetX(global::System.Runtime.InteropServices.HandleRef handle);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Int32Pair_SetY")]
            public static extern void SetY(global::System.Runtime.InteropServices.HandleRef handle, int y);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Int32Pair_GetY")]
            public static extern int GetY(global::System.Runtime.InteropServices.HandleRef handle);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Int32Pair")]
            public static extern void DeleteInt32Pair(global::System.Runtime.InteropServices.HandleRef handle);
       }
    }
}
